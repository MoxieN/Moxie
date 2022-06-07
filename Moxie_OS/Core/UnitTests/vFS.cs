using System;
using System.IO;

namespace Moxie.Core.UnitTests
{
    public class vFS : UnitTest
    {
        public vFS(bool isVital, string name) : base(true, "FileSystem") { }
        
        public override bool Test()
        {
            try
            {
                StreamWriter content = File.CreateText(@"0:\SYSTEM\unit\vfs.txt");
                content.Write("This is an unit test!");
                content.Close();
                File.Delete(@"0:\SYSTEM\unit\vfs.txt");
                content.Dispose();
            } catch (Exception ex)
            {
                return false;
            }
            
            return true;
        }

        
    }
}