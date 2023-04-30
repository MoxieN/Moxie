using System.Collections.Generic;
using Bird;
using Cosmos.System;
using Moxie.Commands.Console;
using Moxie.Commands.FileSystem;
using Moxie.Commands.Network;
using Moxie.Properties;

namespace Moxie.Commands;

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
        Commands.Add(new Move(new [] { "move", "mv" }));

        // Network
        Commands.Add(new FTP(new[] { "ftp" }));

        // Console
        Commands.Add(new Echo(new[] { "echo" }));
        Commands.Add(new KeyboardMap(new[] { "kbmp", "kbmap", "keyboardMap" }));
        Commands.Add(new CommandAction(new[] { "cls", "clear", "clr" }, System.Console.Clear));
        Commands.Add(new CommandAction(new[] { "wai", "whoami" }, () => Kernel.bird.WriteLine(Info.user)));
        Commands.Add(new Command(new[] { "info" }));

        // Power
        Commands.Add(new CommandAction(new[] { "shutdown", "sd" }, Power.Shutdown));
        Commands.Add(new CommandAction(new[] { "reboot", "rb" }, Power.Reboot));

        // Miscellaneous
        Commands.Add(new Miscellaneous.System(new[] { "sys", "system" }));

        foreach (var cmd in Commands)
            Kernel.bird.RegisterCommand(cmd);
    }
}