using System;
using System.Text;
using Cosmos.HAL;
using Cosmos.System.FileSystem;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4;
using Cosmos.System.Network.IPv4.TCP;
using Cosmos.System.Network.IPv4.TCP.FTP;
using Cosmos.System.Network.IPv4.UDP.DHCP;

namespace Moxie.Core.Network
{
    public class NetworkManager
    {
        public void DCHPConnect()
        {
            var xClient = new DHCPClient();

            try
            {
                Kernel.shell.Log("Initiating Network connection via DHCP...", 1);
                xClient.SendDiscoverPacket();
                var ip = NetworkConfig.CurrentConfig.Value.IPAddress;

                xClient.Close();

                if (ip.ToString() == "0.0.0.0")
                    Kernel.shell.Log($"DHCP Discover failed. IP set to {ip}", 3);
                else
                    Kernel.shell.Log("Etablished Network connection via DHCP IPv4: " + ip, 2);
            }
            catch (Exception ex)
            {
                Kernel.shell.WriteLine("DHCP Discover failed. Can't apply dynamic IPv4 address. " + ex, type: 3);
            }
        }

        public void ManualConnect(string networkDevice)
        {
            try
            {
                var nic = NetworkDevice.GetDeviceByName(networkDevice);

                IPConfig.Enable(nic, new Address(192, 168, 1, 69), new Address(255, 255, 255, 0),
                    new Address(192, 168, 1, 254));
                var ip = NetworkConfig.CurrentConfig.Value.IPAddress;
                var sn = NetworkConfig.CurrentConfig.Value.SubnetMask;
                var gw = NetworkConfig.CurrentConfig.Value.DefaultGateway;

                Kernel.shell.WriteLine($"Applied! IPv4: {ip} subnet mask: {sn} gateway: {gw}");
            }
            catch (Exception ex)
            {
                Kernel.shell.WriteLine(ex.ToString(), type: 3);
            }
        }

        /// <summary>
        ///     Create a TCP connection to an IP.
        /// </summary>
        /// <param name="destip">Destination IP</param>
        /// <param name="data">Data to send to destip</param>
        /// <param name="destport">Destination Port</param>
        /// <param name="localport">Local port to open TCP connection to</param>
        /// <param name="timeout">Timeout</param>
        public byte[] TCPconnect(Address destip, int destport, int localport, string data, int timeout = 80)
        {
            using var xClient = new TcpClient(localport);
            xClient.Connect(destip, destport, timeout);

            xClient.Send(Encoding.ASCII.GetBytes(data));

            var endpoint = new EndPoint(Address.Zero, 0);
            var recvData = xClient.Receive(ref endpoint); //set endpoint to remote machine IP:port
            var finalData = xClient.NonBlockingReceive(ref endpoint); //retrieve receive buffer without waiting

            xClient.Close();

            Kernel.shell.WriteLine(endpoint.ToString());
            Kernel.shell.WriteLine(recvData.ToString());
            Kernel.shell.WriteLine(finalData.ToString());

            return finalData;
        }

        /// <summary>
        ///     Create a UDP connection to an IP.
        /// </summary>
        /// <param name="destip">Destination IP</param>
        /// <param name="data">Data to send to destip</param>
        /// <param name="destport">Destination Port</param>
        /// <param name="localport">Local port to open TCP connection to</param>
        /// <param name="timeout">Timeout</param>
        public byte[] UDPconnect(Address destip, int destport, int localport, string data, int timeout = 80)
        {
            using var xClient = new TcpClient(localport);
            xClient.Connect(destip, destport, timeout);

            xClient.Send(Encoding.ASCII.GetBytes(data));

            var endpoint = new EndPoint(Address.Zero, 0);
            var recvData = xClient.Receive(ref endpoint); //set endpoint to remote machine IP:port
            var data2 = xClient.NonBlockingReceive(ref endpoint); //retrieve receive buffer without waiting

            return recvData;
        }

        /// <summary>
        /// </summary>
        /// <param name="fs">Cosmos registered FS</param>
        /// <param name="localDirectory">Directory that the client will access</param>
        public void FTPconnect(CosmosVFS fs, string localDirectory)
        {
            using var xServer = new FtpServer(fs, localDirectory);
            xServer.Listen();
        }
    }
}