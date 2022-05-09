using System.Collections.Generic;

namespace Moxie.Shell.Cmds.Console
{
    internal class Clear : ICommand
    {
        public List<string> CommandValues => new() { "clear" };

        public void Execute()
        {
            System.Console.Clear();
        }
    }
}