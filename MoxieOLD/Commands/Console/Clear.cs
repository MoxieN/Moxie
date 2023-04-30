using Bird;

namespace Moxie.Commands.Console;

public class Clear : Command
{
    public Clear(string[] commandvalues) : base(commandvalues)
    {
        CommandValues = commandvalues;
    }

    public override void Execute()
    {
        System.Console.Clear();
    }

    public override void Help()
    {
        Kernel.bird.WriteLine("clear - Clear the console");
    }
}