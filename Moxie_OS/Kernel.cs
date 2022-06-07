using System;
using System.IO;
using Moxie.Commands;
using Moxie.Core;
using Moxie.Core.User;
using Sys = Cosmos.System;

namespace Moxie
{
    public class Kernel : Sys.Kernel
    {
        //vFS
        public static string CurrentDirectory = @"0:\";
        public static string CurrentVolume = @"0:\";

        //Instantiate
        public static Bird.Bird bird = new();
        public static Initializer init = new();

        public static readonly bool Debug = false;

        protected override void BeforeRun()
        {
            Console.Clear();

            init.vFS();
            init.DHCP();

            Log("Detecting SYSTEM folder", 1);
            if (Debug == false && Directory.Exists(@"0:\SYSTEM\"))
            {
                Log("Found! SYSTEM folder", 2);
                Log("Checking hostname...", 1);

                if (File.Exists(@"0:\SYSTEM\hostname.hs"))
                    Log($"Found! hostname: {File.ReadAllText(@"0:\SYSTEM\hostname.hs")}", 2);
            }
            else if (Debug)
                Log("Skipped", 2);
            else
            {
                Log("SYSTEM folder not found!", 3);
                Setup setup = new();
                setup.StartSetup();
            }
            
            Log("Dropping to Bird shell...", 1);
            CommandRegister.RegisterCommands();
        }

        protected override void Run()
        {
            try
            {
                bird.HandleConsole(@"0:\SYSTEM\hostname.hs", CurrentDirectory);
            }
            catch (Exception ex)
            {
                bird.WriteLine(ex.ToString());
            }
        }

        #region Logs

        /// <summary>
        ///     Log only used for booting or Debug mode
        /// </summary>
        /// <param name="text">Text to output</param>
        /// <param name="type">Type of log. 1:PROCESS 2:DONE 3:FAILED</param>
        public static void Log(string text, int type)
        {
            switch (type)
            {
                case 1:
                    Console.Write("[ ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("PROCESS");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" ] " + text + "\n");
                    break;
                case 2:
                    Console.Write("[ ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("DONE");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" ] " + text + "\n");
                    break;
                case 3:
                    Console.Write("[ ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("FAILED");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" ] " + text + "\n");
                    break;
            }
        }

        #endregion
    }
}