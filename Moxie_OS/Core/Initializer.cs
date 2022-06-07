using System;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Moxie.Core.Network;
using Console = System.Console;
using Sys = Cosmos.System;

namespace Moxie.Core
{
    public class Initializer
    {
        public CosmosVFS fs;
        public NetworkManager networkManager = new();

        public void vFS()
        {
            try
            {
                Kernel.Log("Initiating file system...", 1);
                fs = new CosmosVFS();
                VFSManager.RegisterVFS(fs);
                
            }
            catch (Exception ex)
            {
                Kernel.Log(ex.ToString(), 3);
                Console.ReadKey();
                Sys.Power.Shutdown();
            }

            Kernel.Log("File system initiated", 2);

            UnitTests.vFS unitTest = new(true, "FileSystem");
            unitTest.Execute();
        }

        public void DHCP()
        {
            Kernel.Log("Sending DHCP discover packet packet...", 1);
            try
            {
                networkManager.DCHPConnect();
            }
            catch (Exception ex)
            {
                Kernel.Log(ex.ToString(), 3);
            }
            
            UnitTests.NetworkConnection unitTest = new(false, "NetworkConnection");
            unitTest.Execute();
            
        }
        
        
    }
}