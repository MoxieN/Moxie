using System;
using System.Collections.Generic;
using System.IO;
using Bird;

namespace Moxie.Commands.FileSystem;

internal class CreateFile : Command
{
    public CreateFile(string[] commandvalues) : base(commandvalues)
    {
        CommandValues = commandvalues;
    }

    public override void Execute(List<string> args)
    {
        try
        {
            File.Create(Kernel.CurrentDirectory + @"\" + args[0]);
        }
        catch (Exception ex)
        {
            Kernel.bird.WriteLine($"e: {ex}");
        }
    }

    public override void Help()
    {
        Kernel.bird.WriteLine("mkfile <name/directory+name> - Creates file to filesystem");
    }
}

internal class RemoveFile : Command
{
    public RemoveFile(string[] commandvalues) : base(commandvalues)
    {
        CommandValues = commandvalues;
    }

    public override void Execute(List<string> args)
    {
        try
        {
            File.Delete(Kernel.CurrentDirectory + @"\" + args[0]);
        }
        catch (Exception ex)
        {
            Kernel.bird.WriteLine($"e: {ex}");
        }
    }

    public override void Help()
    {
        Kernel.bird.WriteLine("rmfile <name/directory+name> - Removes file from filesystem");
    }
}