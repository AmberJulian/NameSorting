namespace NameSorting
{
    class Program
    {
        //Program Starts Execution from here
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Error: Please run again providing a file name.");
                return;
            }
            string fileName = args[0];
            NameSorter.SortNamesInFile(fileName);
            Console.WriteLine($"Successfully sorted names from {fileName}!");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            return;
        }     
    }
}