using System.Collections.Generic;
using Sys = Cosmos.System;

namespace Moxie.Shell.Cmds.Misc
{
    internal class Shutdown : ICommand
    {
        public List<string> CommandValues => new() { "shutdown", "sd" };

        public void Execute()
        {
            Sys.Power.Shutdown();
        }

        public void Help()
        {
            Kernel.shell.WriteLine("shutdown/sb - Shutdowns Moxie");
        }
    }

    internal class Reboot : ICommand
    {
        public List<string> CommandValues => new() { "reboot", "rb" };

        public void Execute()
        {
            Sys.Power.Reboot();
        }

        public void Help()
        {
            Kernel.shell.WriteLine("reboot/rb - Reboots Moxie");
        }
    }
}