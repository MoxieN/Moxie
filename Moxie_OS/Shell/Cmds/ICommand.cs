using System.Collections.Generic;

namespace Moxie.Shell.Cmds
{
    public interface ICommand
    {
        public List<string> CommandValues { get; }

        public virtual void Execute()
        {
            
        }

        public virtual void Execute(List<string> args)
        {
            Execute();
        }

        public virtual void Help()
        {
            Kernel.shell.WriteLine("No help available.", type: 3);
        }

        public bool ContainsCommand(string command)
        {
            foreach (var commandValue in CommandValues)
            {
                if (commandValue == command)
                    return true;
                else
                    break;
            }
            // return CommandValues.Contains(command);
            return false;
        }
    }
}