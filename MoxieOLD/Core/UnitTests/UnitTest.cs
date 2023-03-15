using Cosmos.System;
using Console = System.Console;

namespace Moxie.Core.UnitTests;

public abstract class UnitTest
{
    private readonly bool isVital;
    private readonly string name = "Unnamed";

    public UnitTest(bool isVital, string name)
    {
        this.isVital = isVital;
        this.name = name;
    }

    public virtual void Execute(bool passed = true)
    {
        if (passed)
        {
            Kernel.Log($"{name}'s unit tests passed.", 2);
        }
        else
        {
            if (!isVital)
            {
                Kernel.Log($"{name}'s unit tests didn't passed.", 3);
            }
            else
            {
                if (Kernel.Debug)
                {
                    Kernel.Log($"{name}'s unit tests didn't passed and is vital. But debug mode is enabled.", 3);
                }
                else
                {
                    Kernel.Log($"{name}'s unit tests didn't passed and is vital. Can't keep up.", 3);
                    Console.WriteLine("Press 's' to shutdown, Press another key to reboot");

                    var choice = Console.ReadKey();

                    if (choice.KeyChar == 's')
                        Power.Shutdown();
                    else
                        Power.Reboot();
                }
            }
        }
    }
}