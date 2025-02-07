using System.IO;

namespace Namesorting.Utils
{
    static class FileReadWriter
    {
        public static string[]? GetFileContents(string fileName)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory; //Directory

            string slnPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\..")); //Project .sln file path
            string finalPath = slnPath + fileName; //Add the filename

            if (!File.Exists(finalPath))
            {
                Console.WriteLine("Something has gone wrong with finding the file.");
                Console.WriteLine($"This is the path that was searched: {finalPath}");
                return null;
            }

            return File.ReadAllLines(finalPath);
        }
    }
}