using System;
using System.Collections.Generic;
using System.IO;
using Bird;

namespace Moxie.Commands.FileSystem;

public class Move : Command
{
    public Move(string[] commandvalues) : base(commandvalues)
    {
        CommandValues = commandvalues;
    }

    public override void Execute(List<string> args)
    {
        throw new NotImplementedException(); // Plug is needed for File.Move() and Directory.Move()
        
        // This is a file
        /*if (File.Exists(args[0]))
            File.Move(args[0], args[1]);
        else if (Directory.Exists(args[0])) // This is a folder
            Directory.Move(args[0], args[1]);*/
    }

    public override void Execute()
    {
        Kernel.bird.WriteLine("e: Bad command formatting, run mv -h for more information");
    }

    public override void Help()
    {
        Kernel.bird.WriteLine(
            "move <sourcePath> <destinationPath> - moves files to another path, can also be used to rename");
    }
}