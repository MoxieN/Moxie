using System;
using System.IO;
using Moxie.Commands;
using Moxie.Core;
using Moxie.Core.User;
using Moxie.Properties;
using Verde;
using Sys = Cosmos.System;

namespace Moxie;

public class Kernel : Sys.Kernel
{
    //vFS
    public static string CurrentDirectory = @"0:\";
    public static string CurrentVolume = @"0:\";

    //Instantiate
    public static Bird.Bird bird = new();
    public static Manager verde = new();

    public static bool Debug;

    protected override void BeforeRun()
    {
        // This is for debugging purposes
        if (Info.version.Contains("dev"))
        {
            bird.WriteLine("Run in Debug mode? (true/false)");
            var choice = Console.ReadLine();

            if (choice == "true")
                Debug = true;
        }

        Console.Clear();

        // Initializing vFS and DHCP connection
        Initializer.vFS();
        Initializer.DHCP();

        // Detecting if the SYSTEM folder is present, start the setup if not
        Log("Detecting SYSTEM folder", 1);

        if (Debug == false && Directory.Exists(@"0:\SYSTEM\"))
        {
            Log("Found! SYSTEM folder", 2);
            Log("Checking hostname...", 1);

            if (File.Exists(@"0:\SYSTEM\hostname.hs"))
                Log($"Found! hostname: {File.ReadAllText(@"0:\SYSTEM\hostname.hs")}", 2);
        }
        else if (Debug)
        {
            Log("Skipped", 2);
        }
        else
        {
            Log("SYSTEM folder not found!", 3);
            Setup.StartSetup();
        }

        // Set the KeyMap
        Log("Setting keymap layout", 1);
        foreach (var tag in HsLexer.Lexer(File.ReadAllLines(@"0:\SYSTEM\config.hs")))
            if (tag.Name == "!keymap")
            {
                Setup.SetKeyboardLayout(tag.Value);
                Log("Keymap layout set", 2);
            }

        // Register the Bird commands before letting it take care of the rest
        Log("Dropping to Bird shell...", 1);
        CommandRegister.RegisterCommands();
    }

    protected override void Run()
    {
        try
        {
            foreach (var tag in HsLexer.Lexer(File.ReadAllLines(@"0:\SYSTEM\config.hs")))
                if (tag.Name == "!hostname")
                {
                    bird.HandleConsole(tag.Value, CurrentDirectory, ConsoleColor.DarkGreen,
                        ConsoleColor.Cyan, '#');
                    break;
                }
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