using System;
using System.Collections.Generic;
using System.IO;
using Bird;

namespace Moxie.Commands.FileSystem;

internal class Cat : Command
{
    public Cat(string[] commandvalues) : base(commandvalues)
    {
        CommandValues = commandvalues;
    }

    public override void Execute(List<string> args)
    {
        try
        {
            Kernel.bird.WriteLine(File.ReadAllText(Kernel.CurrentDirectory + args[0]));
        }
        catch (Exception ex)
        {
            Kernel.bird.WriteLine($"e: {ex}");
        }
    }

    public override void Help()
    {
        Kernel.bird.WriteLine("cat <file> - Prints file content");
    }
}