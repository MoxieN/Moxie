using System;
using System.IO;
using Cosmos.System;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.ScanMaps;
using Moxie.Properties;
using Console = System.Console;

namespace Moxie.Core.User;

public static class Setup
{
    public static string Name { get; set; }

    /// <summary>
    ///     This is the setup of Moxie, to start only if the SYSTEM folder isn't here
    /// </summary>
    public static void StartSetup()
    {
        Kernel.Log("Creating SYSTEM folder", 1);

        try
        {
            Directory.CreateDirectory(@"0:\SYSTEM");
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
            Kernel.bird.WriteLine("What is your name?");
            Name = Console.ReadLine();

            Kernel.bird.WriteLine($"Are you sure? Is {Name} correct? [Y/N O/N]");
            var choice = Console.ReadLine();

            if (choice != null && choice.StartsWith("y"))
            {
                Kernel.bird.WriteLine("What is your keyboard layout? [fr_FR, en_US, de_DE, tr_TR]");
                var keymap = Console.ReadLine();

                try
                {
                    Kernel.Log("Creating global config file...", 1);
                    Info.user = Name;

                    string[] content =
                    {
                        "This is the global config file of Moxie",
                        $"!keymap :{keymap}",
                        $"!hostname :{Name}"
                    };

                    VFSManager.CreateFile(@"0:\SYSTEM\config.hs");
                    File.WriteAllLines(@"0:\SYSTEM\config.hs", content);

                    foreach (var tag in HsLexer.Lexer(File.ReadAllLines(@"0:\SYSTEM\config.hs")))
                        if (tag.Name == "keyMap")
                            SetKeyboardLayout(tag.Value);

                    Kernel.Log("Global config file created", 2);
                }
                catch (Exception ex)
                {
                    Kernel.Log($"{ex} \n Can't continue, press a key to reboot...", 3);
                    Console.ReadKey();
                    Power.Reboot();
                }

                Power.Reboot();

                break;
            }
        }
    }

    /// <summary>
    ///     Changes the keyboard layout in function of the string
    /// </summary>
    /// <param name="keyLayout">just put a key layout like "fr_FR" for example</param>
    public static void SetKeyboardLayout(string keyLayout)
    {
        switch (keyLayout)
        {
            case "fr_FR":
                KeyboardManager.SetKeyLayout(new FR_Standard());
                break;

            case "en_US":
                KeyboardManager.SetKeyLayout(new US_Standard());
                break;

            case "de_DE":
                KeyboardManager.SetKeyLayout(new DE_Standard());
                break;

            case "tr_TR":
                KeyboardManager.SetKeyLayout(new TR_StandardQ());
                break;
        }
    }
}