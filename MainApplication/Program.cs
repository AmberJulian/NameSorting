using System.Collections.Generic;

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

            // ./programName, unsorted - names - list.txt, true

            string fileName = args[0];
            bool forwardSortingOrder = args[1] == "true";



            NameSorter.SortNamesInFile(fileName, forwardSortingOrder);
            Console.WriteLine($"Successfully sorted names from {fileName}!");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            return;
        }     
    }
}