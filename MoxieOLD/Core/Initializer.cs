using System;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Moxie.Core.Network;
using Moxie.Core.UnitTests;
using Sys = Cosmos.System;

namespace Moxie.Core;

public static class Initializer
{
    public static CosmosVFS fs;

    /// <summary>
    ///     Initialize the vFS
    /// </summary>
    public static void vFS()
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

        // This is needed, a try catch wont say if the disk is properly ready to go
        vFS unitTest = new(true, "FileSystem");
        unitTest.Execute();
    }

    /// <summary>
    ///     Initialize DHCP connection
    /// </summary>
    public static void DHCP()
    {
        Kernel.Log("Sending DHCP discover packet packet...", 1);
        try
        {
            NetworkManager.DCHPConnect();
        }
        catch (Exception ex)
        {
            Kernel.Log(ex.ToString(), 3);
        }

        NetworkConnection unitTest = new(false, "NetworkConnection");
        unitTest.Execute();
    }
}