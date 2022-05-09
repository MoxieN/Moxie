using System.Collections.Generic;
using System.IO;
using Cosmos.System.Network.IPv4;

namespace Moxie.Shell.Cmds.File
{
    internal class DownloadFile : ICommand
    {
        public List<string> CommandValues => new() { "dl" };

        public void Execute(List<string> args)
        {
            Address destip = Address.Parse(args[0]);

            byte[] test = Kernel.init.networkManager.TCPconnect(destip, int.Parse(args[1]), int.Parse(args[2]), args[3]);

            foreach (byte t in test)
                Kernel.shell.Write($"{t}");

            StreamWriter text = System.IO.File.CreateText(@"0:\test.txt");
            text.Write(test);
        }
    }

    /*internal class TestFTP : ICommand
    {
        public TestFTP(string[] commandvalues) : base(commandvalues)
        {
            CommandValues = commandvalues;
        }

        public override void Execute()
        {
            Kernel.init.networkManager.FTPconnect(Kernel.init.fs, @"0:\");
        }
    }*/
}