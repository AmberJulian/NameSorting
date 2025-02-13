using Namesorting.Utils;
using System.Linq;

namespace NameSorting
{
    public static class NameSorter 
    {
        // ============== VARIABLES =================
        private const string sortedListFileName = "sorted-names-list.txt"; //Providing this as a const string. Might be worth taking it as an argument when app is launched. 

        // ============== FUNCTIONS =================
        /// <summary>
        /// Takes in a file name and attempts to sort contents inside it
        /// </summary>
        /// <param name="fileName"></param> The name of the file
        public static void SortNamesInFile(string fileName, bool forwardSortingOrder = true)
        {
            //Get the strings from the file
            string[]? unsortedFileStrings = FileReadWriter.GetFileContents(fileName);
            if (unsortedFileStrings == null)
            {
                Console.WriteLine("Exiting Program early due to file reading error."); ;
                return;
            }

            List<string> sortedStrings;
            if (forwardSortingOrder)
            {
                sortedStrings = SortStringsForward(unsortedFileStrings);
            }
            else
            {
                sortedStrings = SortStringsBackward(unsortedFileStrings);
            }

            FileReadWriter.WriteStringListToFile(sortedStrings, sortedListFileName);
        }

        /// <summary>
        /// Turn any string array into a sorted string list.
        /// </summary>
        /// <param name="unsortedFileStrings"></param> Unsorted string array
        /// <returns></returns>
        public static List<string> SortStringsForward(string[] unsortedStrings)
        {
            List<string> sortedNames = unsortedStrings.OrderBy(name => name.Split().Last()).ToList();
            return sortedNames;
        }


        /// <summary>
        /// Turn any string array into a sorted string list.
        /// </summary>
        /// <param name="unsortedFileStrings"></param> Unsorted string array
        /// <returns></returns>
        public static List<string> SortStringsBackward(string[] unsortedStrings)
        {
            List<string> sortedNames = SortStringsForward(unsortedStrings);
            sortedNames.Reverse();
            return sortedNames; 
        }
    }
}