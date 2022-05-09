using System;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Moxie.Core.Network;
using Sys = Cosmos.System;

namespace Moxie
{
    public class Initializer
    {
        public CosmosVFS fs;
        public NetworkManager networkManager = new();

        public void vFS()
        {
            try
            {
                Kernel.shell.Log("Initiating file system...", 1);
                fs = new CosmosVFS();
                VFSManager.RegisterVFS(fs);
            }
            catch (Exception ex)
            {
                Kernel.shell.Log(ex.ToString(), 3);
                Console.ReadKey();
                Sys.Power.Shutdown();
            }

            Kernel.shell.Log("File system initiated", 2);
        }

        public void DHCP()
        {
            var skip = false;

            if (skip == false)
                networkManager.DCHPConnect();
            else
                Kernel.shell.Log("Process Skipped!", 2);
        }
    }
}