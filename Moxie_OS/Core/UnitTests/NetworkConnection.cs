using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4;

namespace Moxie.Core.UnitTests
{
    public class NetworkConnection : UnitTest
    {
        public NetworkConnection(bool isVital, string name) : base(false, "NetworkConnection") { }
        
        public override bool Test()
        {
            Address ip = NetworkConfiguration.CurrentNetworkConfig.IPConfig.IPAddress;

            if (ip.ToString() == "0.0.0.0")
                return false;

            return true;
        }


        
    }
}