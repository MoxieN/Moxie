using System;
using System.IO;
using Moxie.Core.User;
using Moxie.Shell;
using Moxie.Shell.Cmds;
using Sys = Cosmos.System;

namespace Moxie
{
    public class Kernel : Sys.Kernel
    {
        //vFS
        public static string CurrentDirectory = @"0:\";
        public static readonly string CurrentVolume = @"0:\";

        //Instantiate
        public static ShellManager shell = new();
        public static CommandManager cManager = new();
        public static Initializer init = new();

        private readonly bool Debug = false;
        public string Input { get; set; }

        protected override void BeforeRun()
        {
            Console.Clear();

            init.vFS();
            init.DHCP();

            shell.Log("Detecting SYSTEM folder", 1);
            //FIXME: File not existing but open requested
            if (Debug == false && Directory.Exists(@"0:\SYSTEM\"))
            {
                shell.Log("Found! SYSTEM folder", 2);
                shell.Log("Checking hostname...", 1);

                if (File.Exists(@"0:\SYSTEM\hostname.hs"))
                    shell.Log($"Found! hostname: {File.ReadAllText(@"0:\SYSTEM\hostname.hs")}", 2);
            }
            else if (Debug)
            {
                shell.Log("Skipped", 2);
            }
            else
            {
                shell.Log("SYSTEM folder not found!", 3);
                Setup setup = new();
                setup.StartSetup();
            }

            shell.Log("Initializing commands", 1);
            cManager.RegisterCommands();
            shell.Log("Done!", 2);
        }

        protected override void Run()
        {
            try
            {
                Start(Debug == false ? File.ReadAllText(@"0:\SYSTEM\hostname.hs") : "Moxie");

                Input = Console.ReadLine();
                if (Input != null) cManager.ExecuteCommand(Input);
            }
            catch (Exception ex)
            {
                shell.WriteLine(ex.ToString(), type: 3);
            }
        }

        public void Start(string name)
        {
            Console.ForegroundColor = ConsoleColor.White;
            shell.Write($"\n{name} ", ConsoleColor.Green);
            if (CurrentDirectory == @"0:\")
                shell.Write("~", ConsoleColor.Cyan);
            else
                shell.Write($@"~\{CurrentDirectory.Split(@"\")[1]}", ConsoleColor.Cyan);
            shell.Write("#", ConsoleColor.Gray);
        }
    }
}