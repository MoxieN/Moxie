using System;
using System.Collections.Generic;
using System.IO;
using Bird;

namespace Moxie.Commands.FileSystem;

internal class CD : Command
{
    public CD(string[] commandvalues) : base(commandvalues)
    {
        CommandValues = commandvalues;
    }

    public override void Execute(List<string> args)
    {
        var aPath = args[0];

        try
        {
            if (!aPath.EndsWith(@"\") && aPath != "..") aPath += @"\";

            var temp = $@"{Kernel.CurrentDirectory}{aPath}";

            // if (temp.StartsWith(@"0:\")? Directory.Exists(temp) : Directory.Exists(Kernel.CurrentDirectory + temp))
            if (Directory.Exists(temp))
            {
                Kernel.bird.WriteLine(temp);
                Kernel.CurrentDirectory = temp;
            }
            else
            {
                if (aPath != "..")
                {
                    Kernel.bird.WriteLine("e: Please enter a valid path.");
                }
                else
                {
                    if (Kernel.CurrentDirectory != Kernel.CurrentVolume)
                    {
                        var folder = Directory.GetParent(Kernel.CurrentDirectory)?.FullName;
                        Kernel.CurrentDirectory = folder;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Kernel.bird.WriteLine($"e: {ex}");
        }
    }

    public override void Execute()
    {
        Kernel.CurrentDirectory = Kernel.CurrentVolume;
    }

    public override void Help()
    {
        Kernel.bird.WriteLine("cd <directory> - Change current directory");
    }
}