using Namesorting.Utils;

namespace NameSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            string[]? fileStrings = FileReadWriter.GetFileContents("/unsorted-names-list.txt");
            if (fileStrings == null)
            {
                Console.WriteLine("Exiting Program early due to file reading error."); ;
                return;
            }
            foreach (string line in fileStrings)
            {
                Console.WriteLine(line);
            }
        }
    }
}