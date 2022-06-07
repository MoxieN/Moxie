using System.Collections.Generic;
using Bird;
using Moxie.Commands.Console;
using Moxie.Commands.FileSystem;

namespace Moxie.Commands
{
    public static class CommandRegister
    {
        public static List<Command> Commands = new();

        public static void RegisterCommands()
        {
            // FileSystem
            Commands.Add(new Cat(new[] { "cat" }));
            Commands.Add(new ListDir(new[] { "ls" }));
            Commands.Add(new CD(new[] { "cd" }));
            Commands.Add(new CreateFile(new[] { "mkfile" }));
            Commands.Add(new RemoveFile(new[] { "rmfile" }));
            Commands.Add(new CreateDirectory(new[] { "mkdir" }));
            Commands.Add(new RemoveDirectory(new[] { "rmdir" }));
            
            // Console
            Commands.Add(new Clear(new[] { "cls", "clear", "clr" }));
            Commands.Add(new Echo(new[] { "echo" }));
            Commands.Add(new KeyboardMap(new[] { "kbmp", "kbmap", "keyboardMap" }));
            Commands.Add(new WhoAmI(new[] { "wai", "whoami" }));
            
            // Power
            Commands.Add(new Shutdown(new[] { "shutdown", "sd" }));
            Commands.Add(new Reboot(new[] { "reboot", "rb" }));
            
            foreach(Command cmd in Commands)
                Kernel.bird.RegisterCommand(cmd);
        }
    }
}