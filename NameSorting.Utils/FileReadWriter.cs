namespace Namesorting.Utils
{
    static class FileReadWriter
    {
        // ================= PROPERTIES =================
        private static string solutionPath 
        {
            get
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                return Path.GetFullPath(Path.Combine(basePath, @"..\..\.."));
            }
        }

        // ============== FUNCTIONS =================
        /// <summary>
        /// Gets the final path of the file name; Expects that the file is in the same folder as the .sln
        /// </summary>
        /// <param name="fileName"></param> Name of file
        /// <returns></returns>
        public static string GetFinalPath(string fileName)
        {
            return solutionPath + "\\" + fileName;
        }

        /// <summary>
        /// Gets the file contents from the file with the file name in the same destination as the .sln. Returns it as a string array
        /// </summary>
        /// <param name="fileName"></param> The files name we want to get contents from
        /// <returns></returns>
        public static string[]? GetFileContents(string fileName)
        {
            string finalPath = GetFinalPath(fileName); //Create final path

            if (!File.Exists(finalPath)) //Error check
            {
                Console.WriteLine("Something has gone wrong with finding the file.");
                Console.WriteLine($"This is the path that was searched: {finalPath}");
                return null;
            }

            return File.ReadAllLines(finalPath); //Read and return file contents as a string array
        }

        /// <summary>
        /// Writes a chosen string list to a file in the directory. Will create the file if none is found. Note: This file will be stored in the project directory
        /// </summary>
        /// <param name="stringList"></param> strings that the file will contain
        /// <param name="fileName"></param> name of the file
        public static void WriteStringListToFile(List<string> stringList, string fileName)
        {
            try
            {
                File.WriteAllLines(GetFinalPath(fileName), stringList);
            }
            catch (IOException e)
            {
                Console.WriteLine("File error: " + e.Message);
            }
        }
    }
}