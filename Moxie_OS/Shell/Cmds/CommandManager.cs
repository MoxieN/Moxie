using System.Collections.Generic;
using System.Text;
using Moxie.Shell.Cmds.Console;
using Moxie.Shell.Cmds.File;
using Moxie.Shell.Cmds.Misc;

namespace Moxie.Shell.Cmds
{
    public class CommandManager
    {
        public List<ICommand> Commands = new();

        public void ExecuteCommand(string input)
        {
            var args = ParseCommandLine(input);
            var name = args[0];

            if (args.Count > 0) args.RemoveAt(0); //get only arguments
            
            // It is shown
            Kernel.shell.WriteLine("aaa");
            
            //Its like the foreach is just looping forever
            foreach (var command in Commands)
            {
                Kernel.shell.WriteLine("bbb");
                if (command.ContainsCommand(name))
                {
                    Kernel.shell.WriteLine("ccc");
                    if (args.Count == 0)
                    {
                        command.Execute();
                    }
                    else
                    {
                        command.Execute(args);
                    }
                }
                else
                {
                    // Testing but not showing that the command isnt corresponding to the input
                    Kernel.shell.WriteLine($"command {command} requirements is not met.");
                }
            }
        }

        public void RegisterCommands()
        {
            Commands.Add(new Cat());
            Commands.Add(new ListDir());
            Commands.Add(new Shutdown());
            Commands.Add(new Reboot());
            Commands.Add(new CD());
            Commands.Add(new CreateFile());
            Commands.Add(new RemoveFile());
            Commands.Add(new CreateDirectory());
            Commands.Add(new RemoveDirectory());
            Commands.Add(new DownloadFile());
            Commands.Add(new Echo());
            Commands.Add(new WhoAmI());
            Commands.Add(new Clear());
            Commands.Add(new KeyboardMap());
        }

        private static List<string> ParseCommandLine(string cmdLine)
        {
            var args = new List<string>();
            if (string.IsNullOrWhiteSpace(cmdLine)) return args;

            var currentArg = new StringBuilder();
            var inQuotedArg = false;

            for (var i = 0; i < cmdLine.Length; i++)
                if (cmdLine[i] == '"')
                {
                    if (inQuotedArg)
                    {
                        args.Add(currentArg.ToString());
                        currentArg = new StringBuilder();
                        inQuotedArg = false;
                    }
                    else
                    {
                        inQuotedArg = true;
                    }
                }
                else if (cmdLine[i] == ' ')
                {
                    if (inQuotedArg)
                    {
                        currentArg.Append(cmdLine[i]);
                    }
                    else if (currentArg.Length > 0)
                    {
                        args.Add(currentArg.ToString());
                        currentArg = new StringBuilder();
                    }
                }
                else
                {
                    currentArg.Append(cmdLine[i]);
                }

            if (currentArg.Length > 0) args.Add(currentArg.ToString());

            return args;
        }
    }
}