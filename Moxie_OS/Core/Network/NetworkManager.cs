﻿using System;
using System.Text;
using Cosmos.HAL;
using Cosmos.System.FileSystem;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4;
using Cosmos.System.Network.IPv4.TCP;
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
                Kernel.Log("Initiating Network connection via DHCP...", 1);
                xClient.SendDiscoverPacket();
                var ip = NetworkConfiguration.CurrentNetworkConfig.IPConfig.IPAddress;

                xClient.Close();

                
                Kernel.Log("Etablished Network connection via DHCP IPv4: " + ip, 2);    
            }
            catch (Exception ex)
            {
                Kernel.bird.WriteLine("DHCP Discover failed. Can't apply dynamic IPv4 address. " + ex);
            }
        }

        public void ManualConnect(Address ipAddress, Address subnet, Address gateway, string networkDevice = "eth0")
        {
            try
            {
                var nic = NetworkDevice.GetDeviceByName(networkDevice);

                IPConfig.Enable(nic, ipAddress, subnet, gateway);
                
                Address ip = NetworkConfiguration.CurrentNetworkConfig.IPConfig.IPAddress;
                Address sn = NetworkConfiguration.CurrentNetworkConfig.IPConfig.SubnetMask;
                Address gw = NetworkConfiguration.CurrentNetworkConfig.IPConfig.DefaultGateway;

                Kernel.bird.WriteLine($"Applied! IPv4: {ip} subnet mask: {sn} gateway: {gw}");
            }
            catch (Exception ex)
            {
                Kernel.bird.WriteLine($"e: {ex}");
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

            Kernel.bird.WriteLine(endpoint.ToString());
            Kernel.bird.WriteLine(recvData.ToString());
            Kernel.bird.WriteLine(finalData.ToString());

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
        /// Creates an active anonymous FTP connection, it will close after the client disconnected
        /// </summary>
        /// <param name="fs">Cosmos registered FS</param>
        /// <param name="localDirectory">Directory that the client will access</param>
        public void FTPconnect(CosmosVFS fs, string localDirectory)
        {
            Kernel.bird.WriteLine("Creating FTP server...");
            using var xServer = new CosmosFtpServer.FtpServer(fs, localDirectory);
            Kernel.bird.WriteLine("Listening...");
            xServer.Listen();
            Kernel.bird.WriteLine("Client connected.");
        }
    }
}