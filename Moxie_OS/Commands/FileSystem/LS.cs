using System;
using System.Collections.Generic;
using System.IO;
using Bird;

namespace Moxie.Commands.FileSystem;

internal class ListDir : Command
{
    public ListDir(string[] commandvalues) : base(commandvalues)
    {
        CommandValues = commandvalues;
    }

    public override void Execute()
    {
        try
        {
            var filesList = Directory.GetFiles(Kernel.CurrentDirectory);
            var directoriesList = Directory.GetDirectories(Kernel.CurrentDirectory);

            foreach (var entry in directoriesList)
                Kernel.bird.Write(entry + " ", ConsoleColor.Blue);

            foreach (var entry in filesList)
                if (entry.EndsWith(".hs"))
                    Kernel.bird.Write(entry + " ", ConsoleColor.Gray);
                else
                    Kernel.bird.Write(entry + " ");
        }
        catch (Exception ex)
        {
            Kernel.bird.WriteLine($"e: {ex}");
        }
    }

    public override void Execute(List<string> args)
    {
        try
        {
            if (args[0] != "-h")
            {
                var filesList = Directory.GetFiles(args[0]);
                var directoriesList = Directory.GetDirectories(args[0]);

                foreach (var entry in directoriesList)
                    Kernel.bird.Write(entry + " ", ConsoleColor.Blue);

                foreach (var entry in filesList)
                    if (entry.EndsWith(".hs"))
                        Kernel.bird.Write(entry + " ", ConsoleColor.Gray);
                    else
                        Kernel.bird.Write(entry + " ");
            }
        }
        catch (Exception ex)
        {
            Kernel.bird.WriteLine($"e: {ex}");
        }
    }

    public override void Help()
    {
        Kernel.bird.WriteLine("ls <path> - Show entries on path");
    }
}