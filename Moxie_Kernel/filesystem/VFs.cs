using Cosmos.System.FileSystem;

namespace Moxie.filesystem;
public class VFs
{
    public static string CurrentDirectory = @"0:\";
    public static string CurrentVolume = @"0:\";

    public void Init()
    {
        CosmosVFS fs = new CosmosVFS();
        Cosmos.System.FileSystem.VFS.VFSManager.RegisterVFS(fs);
        Kernel.bird.WriteLine("VFs initialized");
    }
}
