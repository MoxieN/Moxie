using System;
using System.Collections.Generic;
using Bird;
using Cosmos.System.FileSystem.VFS;
using Moxie.Properties;

namespace Moxie.Commands.Miscellaneous;

public class System : Command
{
    public System(string[] commandvalues) : base(commandvalues)
    {
        CommandValues = commandvalues;
    }

    public override void Execute(List<string> args)
    {
        switch (args[0])
        {
            case "-a":
                Kernel.bird.WriteLine($"Moxie OS v{Info.version}  MoxieN © 2022");
                break;

            case "-i":
                throw new NotImplementedException();
                
                /*
                var val = false;

                Kernel.bird.WriteLine("Wich disks you want to prepare for Cosmos? (by his letter) \n");
                foreach (var disk in VFSManager.GetDisks())
                {
                    // disk.Mount();
                    Kernel.bird.WriteLine($"IsMBR: {disk.IsMBR}\n" +
                                          $"Size: {disk.Size / 1024 / 1024 / 1024}\n" +
                                          "Partitions:");

                    foreach (var partition in disk.Partitions)
                    {
                        var part = partition.MountedFS;

                        var percentComplete =
                            (int)Math.Round((double)(100 * part.TotalFreeSpace - part.AvailableFreeSpace) /
                                            part.TotalFreeSpace);

                        Kernel.bird.WriteLine($"---Label: {part.Label}\n" +
                                              $"---Letter: {part.RootPath}\n" +
                                              $"---Size: {part.TotalFreeSpace - part.AvailableFreeSpace} {percentComplete}% Used / {part.TotalFreeSpace}\n" +
                                              $"---HasFileSystem: {partition.HasFileSystem}\n");
                    }
                }

                while (val != true)
                {
                    var letter = global::System.Console.ReadLine();

                    foreach (var disk in VFSManager.GetDisks())
                    foreach (var partition in disk.Partitions)
                        if (letter == partition.RootPath.Split(':')[0])
                        {
                            Kernel.bird.WriteLine($"Are you sure you want to install Moxie in {partition.RootPath}?");

                            var choice = global::System.Console.ReadLine();

                            if (choice == "y")
                            {
                                Kernel.bird.WriteLine("Clearing all partitions on disk...");
                                disk.Clear();
                                // TODO: Create MBR partition
                                Kernel.bird.WriteLine("Creating main partition...");
                                disk.CreatePartition(disk.Size / 1024 / 1024);
                                Kernel.bird.WriteLine("Mounting partition...");
                                disk.MountPartition(0);

                                val = true;
                                break;
                            }
                        }
                }*/

                break;
        }
    }

    public override void Execute()
    {
        Kernel.bird.WriteLine("e: Bad command formatting, run sys -h for more information");
    }

    public override void Help()
    {
        Kernel.bird.WriteLine("system <-h/-i/-a> Description...");
    }
}