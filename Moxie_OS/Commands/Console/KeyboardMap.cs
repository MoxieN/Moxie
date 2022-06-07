using System.Collections.Generic;
using Bird;

namespace Moxie.Commands.Console
{

    public enum KeyMaps
    {
        fr_FR,
        en_US,
        en_DE
    }
    
    public class KeyboardMap : Command
    {
        public KeyboardMap(string[] commandvalues) : base(commandvalues)
        {
            CommandValues = commandvalues;
        }

        public override void Execute(List<string> args)
        {
            //TODO: Handle this in a file insted of a class
            /*
            foreach (string keyMap in Enum.GetNames(typeof(KeyMaps)))
            {
                if(Info.langSelected == keyMap)
                    Kernel.bird.WriteLine($"e: Keymap {keyMap} already selected");
                else
                {
                    Cosmos.System.KeyboardManager.SetKeyLayout(new FR_Standard());
                }
            }*/
            
            Kernel.bird.WriteLine("e: Not Implemented");
        }

        public override void Help()
        {
            Kernel.bird.WriteLine("kbmp <KeyMap> - Change the KeyboardMap");
        }
    }
    
}