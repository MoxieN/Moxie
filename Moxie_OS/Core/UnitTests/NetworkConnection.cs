using Cosmos.System.Network.Config;

namespace Moxie.Core.UnitTests;

public class NetworkConnection : UnitTest
{
    public NetworkConnection(bool isVital, string name) : base(false, "NetworkConnection")
    {
    }

    public override void Execute(bool passed = true)
    {
        var ip = NetworkConfiguration.CurrentNetworkConfig.IPConfig.IPAddress;

        if (ip.ToString() == "0.0.0.0")
            passed = false;

        base.Execute(passed);
    }
}