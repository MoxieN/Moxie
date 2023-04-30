using Bird;
using Moxie.Properties;

namespace Moxie.Commands.Console;

public class WhoAmI : Command
{
    public WhoAmI(string[] commandvalues) : base(commandvalues)
    {
        CommandValues = commandvalues;
    }

    public override void Execute()
    {
        Kernel.bird.WriteLine(Info.user);
    }

    public override void Help()
    {
        Kernel.bird.WriteLine("whoami - returns hostname");
    }
}