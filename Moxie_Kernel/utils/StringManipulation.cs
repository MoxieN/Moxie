namespace Moxie.utils;

public class StringManipulation
{
    public static string HandleDirectoryPath(string path)
    {
        string r = path;
        
        if(!path.StartsWith("")) r = filesystem.VFs.CurrentDirectory + path;
        if(!path.EndsWith('/')) r += '/';

        return r;
    }
}