using System;
using System.Collections.Generic;
using System.IO;

namespace Moxie.Shell.Cmds.File
{
    internal class CreateDirectory : ICommand
    {
        public List<string> CommandValues => new() { "mkdir" };

        public void Execute(List<string> args)
        {
            try
            {
                Directory.CreateDirectory(Kernel.CurrentDirectory + args[0]);
            }
            catch (Exception ex)
            {
                Kernel.shell.WriteLine(ex.ToString(), type: 3);
            }
        }
    }

    internal class RemoveDirectory : ICommand
    {
        public List<string> CommandValues => new() { "rmdir" };

        public void Execute(List<string> args)
        {
            if (!args[0].EndsWith(@"\")) args[0] += @"\";

            try
            {
                if (Directory.Exists(Kernel.CurrentDirectory + args[0]))
                    Directory.Delete(Kernel.CurrentDirectory + args[0]);
                else
                    Kernel.shell.WriteLine("Please enter a valid directory", type: 3);
            }
            catch (Exception ex)
            {
                Kernel.shell.WriteLine(ex.ToString(), type: 3);
            }
        }
    }
}