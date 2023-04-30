using Moxie.filesystem;
using System;
using Sys = Cosmos.System;

namespace Moxie;

public class Kernel : Sys.Kernel
{
    public static Bird.Bird bird;
    public VFs vfs;

    protected override void BeforeRun()
    {
        Console.Clear();
        vfs.Init();
        bird.WriteLine("Moxie 23 booted");
    }

    protected override void Run()
    {
        bird.HandleConsole("user", VFs.CurrentDirectory, ConsoleColor.White, ConsoleColor.DarkGreen, '#');
    }
}