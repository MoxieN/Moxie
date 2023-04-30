using System.Collections.Generic;
using Bird;
using Cosmos.System;
using Cosmos.System.ScanMaps;

namespace Moxie.Commands.Console;

public class KeyboardMap : Command
{
    public KeyboardMap(string[] commandvalues) : base(commandvalues)
    {
        CommandValues = commandvalues;
    }

    public override void Execute(List<string> args)
    {
        switch (args[0])
        {
            case "fr_FR":
                KeyboardManager.SetKeyLayout(new FR_Standard());
                break;

            case "en_US":
                KeyboardManager.SetKeyLayout(new US_Standard());
                break;

            case "de_DE":
                KeyboardManager.SetKeyLayout(new DE_Standard());
                break;

            case "tr_TR":
                KeyboardManager.SetKeyLayout(new TR_StandardQ());
                break;
        }

        Kernel.bird.WriteLine("e: Not Implemented");
    }

    public override void Help()
    {
        Kernel.bird.WriteLine("kbmp <KeyMap> - Change the KeyboardMap");
    }
}