using System.Collections.Generic;
using Cosmos.System.ScanMaps;
using Moxie.Properties;
using Sys = Cosmos.System;

namespace Moxie.Shell.Cmds.Console
{
    internal class KeyboardMap : ICommand
    {
        public List<string> CommandValues => new() { "setKeyboardMap", "sKBmp" };

        public void Execute(List<string> args)
        {
            switch (args[0])
            {
                case "en_US":
                    if (Info.langSelected != "en_US")
                    {
                        Sys.KeyboardManager.SetKeyLayout(new US_Standard());
                        Info.langSelected = "en_US";
                    }
                    else
                    {
                        Kernel.shell.WriteLine("The Keyboard mapping is already on en_US.", type: 3);
                    }

                    break;

                case "fr_FR":
                    if (Info.langSelected != "fr_FR")
                    {
                        Sys.KeyboardManager.SetKeyLayout(new FR_Standard());
                        Info.langSelected = "fr_FR";
                    }
                    else
                    {
                        Kernel.shell.WriteLine("The Keyboard mapping is already on fr_FR.", type: 3);
                    }

                    break;

                case "en_DE":
                    if (Info.langSelected != "en_DE")
                    {
                        Sys.KeyboardManager.SetKeyLayout(new DE_Standard());
                        Info.langSelected = "en_DE";
                    }
                    else
                    {
                        Kernel.shell.WriteLine("The Keyboard mapping is already on en_DE.", type: 3);
                    }

                    break;

                default:
                    Kernel.shell.Write("Please enter a valid keyboard language. Example: \"en_US\"", type: 3);
                    break;
            }
        }
    }
}