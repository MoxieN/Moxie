using System.Collections.Generic;
using Bird;

namespace Moxie.Commands.Console;

public class Echo : Command
{
    public Echo(string[] commandvalues) : base(commandvalues)
    {
        CommandValues = commandvalues;
    }

    public override void Execute(List<string> args)
    {
        Kernel.bird.WriteLine(args[0]);
    }

    public override void Help()
    {
        Kernel.bird.WriteLine("echo \"(Message)\" - returns the message");
    }
}