using System;
using System.Collections.Generic;

namespace Moxie.Shell.Cmds.File
{
    internal class Cat : ICommand
    {
        public List<string> CommandValues => new() { "cat" };

        public void Execute(List<string> args)
        {
            try
            {
                Kernel.shell.WriteLine(System.IO.File.ReadAllText(Kernel.CurrentDirectory + args[0]));
            }
            catch (Exception ex)
            {
                Kernel.shell.WriteLine(ex.ToString(), type: 3);
            }
        }

        public void Help()
        {
            Kernel.shell.WriteLine("cat <file> - Prints file content");
        }
    }
}