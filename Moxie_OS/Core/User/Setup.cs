using System;
using System.IO;
using Cosmos.System;
using Cosmos.System.FileSystem.VFS;
using Moxie.Properties;
using Console = System.Console;

namespace Moxie.Core.User
{
    public class Setup
    {
        public string Name { get; set; }

        public void StartSetup()
        {
            Kernel.shell.Log("Creating SYSTEM folder", 1);

            try
            {
                Directory.CreateDirectory(@"0:\SYSTEM");
                Kernel.shell.Log("Created SYSTEM folder", 2);
            }
            catch (Exception ex)
            {
                Kernel.shell.Log($"{ex} \n Can't continue, press a key to reboot...", 3);
                Console.ReadKey();
                Power.Reboot();
            }

            while (true)
            {
                Kernel.shell.WriteLine("What is your name?", ConsoleColor.Magenta, ConsoleColor.DarkCyan);
                Name = Console.ReadLine();

                Kernel.shell.WriteLine($"Are you sure? Is {Name} correct? [Y/N O/N]");
                var choice = Console.ReadLine();

                if (choice.StartsWith("y"))
                {
                    //Adding user to users.skp
                    Kernel.shell.Log("Adding user...", 1);
                    try
                    {
                        VFSManager.CreateFile(@"0:\SYSTEM\hostname.hs");
                        File.WriteAllText(@"0:\SYSTEM\hostname.hs", Name);

                        Info.user = Name;
                    }
                    catch (Exception ex)
                    {
                        Kernel.shell.Log($"{ex} \n Can't continue, press a key to reboot...", 3);
                        Console.ReadKey();
                        Power.Reboot();
                    }

                    break;
                }
            }
        }
    }
}