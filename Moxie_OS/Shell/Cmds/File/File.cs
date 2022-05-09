using System;
using System.Collections.Generic;

namespace Moxie.Shell.Cmds.File
{
    internal class CreateFile : ICommand
    {
        public List<string> CommandValues => new() { "mkfile" };

        public void Execute(List<string> args)
        {
            try
            {
                System.IO.File.Create(Kernel.CurrentDirectory + @"\" + args[0]);
            }
            catch (Exception ex)
            {
                Kernel.shell.WriteLine(ex.ToString(), type: 3);
            }
        }
    }

    internal class RemoveFile : ICommand
    {
        public List<string> CommandValues => new() { "rmfile" };

        public void Execute(List<string> args)
        {
            try
            {
                System.IO.File.Delete(Kernel.CurrentDirectory + args[0]);
            }
            catch (Exception ex)
            {
                Kernel.shell.WriteLine(ex.ToString(), type: 3);
            }
        }
    }
}