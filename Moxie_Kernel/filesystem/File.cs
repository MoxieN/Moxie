using System;
using System.IO;
using Moxie.utils;

namespace Moxie.filesystem;

public class File
{
    public static void CreateFile(string name, string path, FileOptions fileArgs, int bufferSize = 4096)
    {
        System.IO.File.Create($"{StringManipulation.HandleDirectoryPath(path)}{name}", bufferSize, fileArgs);
    }

    public static void DeleteFile(string name, string path)
    {
        var file = $"{StringManipulation.HandleDirectoryPath(path)}{name}";
        if(System.IO.File.Exists(file))
        {
            System.IO.File.Delete($"{StringManipulation.HandleDirectoryPath(path)}{name}");
        }
    }

    public static FileStream GetFileStream(string name, string path)
    {
        var file = $"{StringManipulation.HandleDirectoryPath(path)}{name}";

        if(System.IO.File.Exists(file))
        {
            return System.IO.File.Open(file, FileMode.Open);
        }

        throw new FileNotFoundException();
    }
}