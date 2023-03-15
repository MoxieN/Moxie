using System;
using System.IO;

namespace Moxie.Core.UnitTests;

public class vFS : UnitTest
{
    public vFS(bool isVital, string name) : base(true, "FileSystem")
    {
    }

    public override void Execute(bool passed = true)
    {
        try
        {
            Directory.CreateDirectory(@"0:\unit\");
            var content = File.CreateText(@"0:\unit\vfs.txt");
            content.Write("This is an unit test!");
            content.Close();
            File.Delete(@"0:\unit\vfs.txt");
            content.Dispose();
        }
        catch (Exception ex)
        {
            passed = false;
        }

        base.Execute(passed);
    }
}