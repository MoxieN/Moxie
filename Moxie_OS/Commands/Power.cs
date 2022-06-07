using Cosmos.System;

namespace Moxie.Commands
{
    internal class Shutdown : Bird.Command
    {
        public Shutdown(string[] commandvalues) : base(commandvalues)
        {
            CommandValues = commandvalues;
        }

        public override void Execute()
        {
            Power.Shutdown();
        }

        public override void Help()
        {
            Kernel.bird.WriteLine("shutdown/sb - Shutdowns Moxie");
        }
    }

    internal class Reboot : Bird.Command
    {
        public Reboot(string[] commandvalues) : base(commandvalues)
        {
            CommandValues = commandvalues;
        }

        public override void Execute()
        {
            Power.Reboot();
        }

        public override void Help()
        {
            Kernel.bird.WriteLine("reboot/rb - Reboots Moxie");
        }
    }
}