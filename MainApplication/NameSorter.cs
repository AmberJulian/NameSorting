using Namesorting.Utils;

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
        public static void SortNamesInFile(string fileName, bool forwardSortingOrder)
        {
            //Get the strings from the file
            string[]? unsortedFileStrings = FileReadWriter.GetFileContents(fileName);
            if (unsortedFileStrings == null)
            {
                Console.WriteLine("Exiting Program early due to file reading error."); ;
                return;
            }

            List<string> sortedStrings = SortStrings(unsortedFileStrings, forwardSortingOrder);



            FileReadWriter.WriteStringListToFile(sortedStrings, sortedListFileName);
        }

        /// <summary>
        /// Turn any string array into a sorted string list.
        /// </summary>
        /// <param name="unsortedFileStrings"></param> Unsorted string array
        /// <returns></returns>
        public static List<string> SortStrings(string[] unsortedStrings, bool forwardSortingOrder)
        {
            List<string> stringList = new List<string>(unsortedStrings);
            stringList.Sort( );
            if (forwardSortingOrder)
            {
                stringList.Reverse();
            }

            return stringList;
        }
    }
}