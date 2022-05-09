using System;
using System.Collections.Generic;
using System.IO;

namespace Moxie.Shell.Cmds.File
{
    internal class ListDir : ICommand
    {
        public List<string> CommandValues => new() {  "ls"  };

        public void Execute()
        {
            try
            {
                string[] filesList = Directory.GetFiles(Kernel.CurrentDirectory);
                string[] directoriesList = Directory.GetDirectories(Kernel.CurrentDirectory);

                foreach (string entry in directoriesList)
                    Kernel.shell.Write(entry + " ", ConsoleColor.Blue);
                foreach (string entry in filesList)
                    Kernel.shell.Write(entry + " ");
            }
            catch (Exception ex)
            {
                Kernel.shell.WriteLine(ex.ToString(), type: 3);
            }
        }

        public void Execute(List<string> args)
        {
            try
            {
                string[] filesList = Directory.GetFiles(args[0]);
                string[] directoriesList = Directory.GetDirectories(args[0]);

                foreach (string entry in directoriesList)
                    Kernel.shell.Write(entry + " ", ConsoleColor.Blue);
                foreach (string entry in filesList)
                    Kernel.shell.Write(entry + " ");
            }
            catch (Exception ex)
            {
                Kernel.shell.WriteLine(ex.ToString(), type: 3);
            }
        }

        public void Help()
        {
            Kernel.shell.WriteLine("ls <path> - show entries on path");
        }
    }
}