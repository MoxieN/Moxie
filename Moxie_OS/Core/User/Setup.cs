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
            Kernel.Log("Creating SYSTEM folder", 1);

            try
            {
                Directory.CreateDirectory(@"0:\SYSTEM");
                Directory.CreateDirectory(@"0:\SYSTEM\unit\");
                Kernel.Log("Created SYSTEM folder", 2);
            }
            catch (Exception ex)
            {
                Kernel.Log($"{ex} \n Can't continue, press a key to reboot...", 3);
                Console.ReadKey();
                Power.Reboot();
            }

            while (true)
            {
                Kernel.bird.WriteLine("What is your name?", ConsoleColor.Magenta, ConsoleColor.DarkCyan);
                Name = Console.ReadLine();

                Kernel.bird.WriteLine($"Are you sure? Is {Name} correct? [Y/N O/N]");
                var choice = Console.ReadLine();

                if (choice.StartsWith("y"))
                {
                    //Adding user to users.skp
                    Kernel.Log("Adding user...", 1);
                    try
                    {
                        VFSManager.CreateFile(@"0:\SYSTEM\hostname.hs");
                        File.WriteAllText(@"0:\SYSTEM\hostname.hs", Name);

                        Info.user = Name;
                    }
                    catch (Exception ex)
                    {
                        Kernel.Log($"{ex} \n Can't continue, press a key to reboot...", 3);
                        Console.ReadKey();
                        Power.Reboot();
                    }

                    break;
                }
            }
        }
    }
}