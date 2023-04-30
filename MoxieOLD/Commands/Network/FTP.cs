using System;
using System.Collections.Generic;
using Bird;
using Cosmos.System.Network.IPv4;
using Moxie.Core;
using Moxie.Core.Network;

namespace Moxie.Commands.Network;

internal class FTP : Command
{
    public FTP(string[] commandvalues) : base(commandvalues)
    {
        CommandValues = commandvalues;
    }

    public override void Execute(List<string> args)
    {
        try
        {
            Kernel.bird.WriteLine("manual connect");
            NetworkManager.ManualConnect(new Address(192, 168, 1, 230), new Address(255, 255, 255, 0),
                new Address(192, 168, 1, 254));

            Kernel.bird.WriteLine("starting ftp server");
            NetworkManager.FTPconnect(Initializer.fs, args[0]);
        }
        catch (Exception ex)
        {
            Kernel.bird.WriteLine($"e: {ex}");
        }
    }

    public override void Help()
    {
        Kernel.bird.WriteLine("ftp <localDirectory> - Starts a FTP server on the specified local directory");
    }
}