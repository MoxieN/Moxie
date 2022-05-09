using System.Collections.Generic;

namespace Moxie.Shell.Cmds.Console
{
    internal class Echo : ICommand
    {
        public List<string> CommandValues => new() { "echo" };

        public void Execute(List<string> args)
        {
            foreach (var arg in args)
                Kernel.shell.Write($"{arg} ");
        }
    }
}