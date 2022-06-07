using System;
using System.Collections.Generic;
using System.IO;
using Bird;

namespace Moxie.Commands.FileSystem
{
    internal class CreateDirectory : Command
    {
        public CreateDirectory(string[] commandvalues) : base(commandvalues)
        {
            CommandValues = commandvalues;
        }

        public override void Execute(List<string> args)
        {
            try
            {
                Directory.CreateDirectory(Kernel.CurrentDirectory + args[0]);
            }
            catch (Exception ex)
            {
                Kernel.bird.WriteLine($"e: {ex}");
            }
        }

        public override void Help()
        {
            Kernel.bird.WriteLine("mkdir <directory (name/directory+name)> - Create directory to filesystem");        
        }
    }

    internal class RemoveDirectory : Command
    {
        public RemoveDirectory(string[] commandvalues) : base(commandvalues)
        {
            CommandValues = commandvalues;
        }

        public override void Execute(List<string> args)
        {
            if (!args[0].EndsWith(@"\")) args[0] += @"\";

            try
            {
                if (Directory.Exists(Kernel.CurrentDirectory + args[0]))
                    Directory.Delete(Kernel.CurrentDirectory + args[0]);
                else
                    Kernel.bird.WriteLine("e: Please enter a valid directory");
            }
            catch (Exception ex)
            {
                Kernel.bird.WriteLine($"e: {ex}");
            }
        }

        public override void Help()
        {
            Kernel.bird.WriteLine("rmdir <directory> - Removes directory from filesystem");
        }
    }
}