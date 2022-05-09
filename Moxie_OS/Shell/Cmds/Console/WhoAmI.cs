using System.Collections.Generic;
using Moxie.Properties;

namespace Moxie.Shell.Cmds.Console
{
    internal class WhoAmI : ICommand
    {
        public List<string> CommandValues => new() { "whoami" };

        public void Execute()
        {
            Kernel.shell.WriteLine(Info.user);
        }

        public void Help()
        {
            Kernel.shell.WriteLine("whoami - Shows hostname");
        }
    }
}