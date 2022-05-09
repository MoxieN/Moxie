using System;
using System.Collections.Generic;
using System.IO;

namespace Moxie.Shell.Cmds.File
{
    internal class CD : ICommand
    {
        public List<string> CommandValues => new() { "cd" };

        public void Execute(List<string> args)
        {
            var aPath = args[0];

            try
            {
                if (!aPath.EndsWith(@"\") && aPath != "..") aPath = aPath + @"\";

                var temp = Directory.GetParent($@"{Kernel.CurrentDirectory}{aPath}\")?.FullName;

                if (!string.IsNullOrWhiteSpace(temp))
                {
                    if (aPath.StartsWith("\"") && aPath.EndsWith("\""))
                        Kernel.shell.WriteLine("Not implemented.", type: 3);
                    else
                        Kernel.CurrentDirectory = temp + @"\";
                }
                else
                {
                    if (aPath != "..")
                    {
                        Kernel.shell.WriteLine("Please enter a valid path.", type: 3);
                    }
                    else
                    {
                        if (Kernel.CurrentDirectory != Kernel.CurrentVolume)
                        {
                            var folder = Directory.GetParent(Kernel.CurrentDirectory)?.FullName;
                            Kernel.CurrentDirectory = folder;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Kernel.shell.WriteLine(ex.ToString(), type: 3);
            }
        }
    }
}