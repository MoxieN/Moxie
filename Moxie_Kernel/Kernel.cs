using System;
using Sys = Cosmos.System;

namespace Moxie;

public class Kernel : Sys.Kernel
{
    //vFS
    public static string CurrentDirectory = @"0:\";
    public static string CurrentVolume = @"0:\";

    protected override void BeforeRun()
    {
        Console.Clear();
        Console.WriteLine("Print something to get echoed back");
    }

    protected override void Run()
    {
        Console.WriteLine(Console.ReadLine());
    }
}