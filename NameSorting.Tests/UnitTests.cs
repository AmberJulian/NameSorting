using NUnit.Framework;
using Namesorting.Utils;


namespace NameSorting.Tests
{
    public class Tests
    {
        const string testOneFileName = "TestFileOne";
        const string testTwoFileName = "TestFileTwo";

        [SetUp]
        public void SetUp()
        {
            //Make a new file to test for full program test one
            string newLine = Environment.NewLine; //usually /n
            File.WriteAllText(FileReadWriter.GetFinalPath(testOneFileName), $"Pandy Paws{newLine}Pillow Cat{newLine}Cakey{newLine}Gabby{newLine}Box Cat");
        }

        [Test]
        public void TestNameSortingFunction()
        {
            string[] nameArrayExample = { "Kitty Fairy", "Pandy", "Mercat", "Gabby", "CatRat" };
            List<string> namesAfterSorting = NameSorter.SortStrings(nameArrayExample);
            List<string> expectedSortedNames = new List<string> { "CatRat", "Gabby", "Kitty Fairy", "Mercat", "Pandy" };

            Assert.That(namesAfterSorting.SequenceEqual(expectedSortedNames));
        }


        [Test]
        //Note for test marker: Depending on the program intentions, I may not want this unit test. I'd prefer my unit tests don't access real data at all, so there is no chance of destroying it. However, if this is just an internal tool and we can get the data back easily, then this should be helpful to see if someone deleted or moved the file from the location we expect. 
        public void CheckThatFileExists()
        {
            if (Environment.GetEnvironmentVariable("APPVEYOR") == "True")
            {
                //Appveyor is checking the wrong place. 
                //It makes no sense to check if a file exists in a location through a test pipeline if it can't use the same location as real world - Disable the test. 
                Assert.Ignore("Test disabled in AppVeyor.");
            }


            string filePath = FileReadWriter.GetFinalPath("unsorted-names-list.txt");
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"This is the file path we are checking for the unsorted names: {filePath}. Something has gone wrong.");
            }
            Assert.That(File.Exists(filePath));
        }

        [Test]
        ////Tests the file created in our set up
        public void TestFullProgramOne()
        {
            NameSorter.SortNamesInFile(testOneFileName);
            string filePath = FileReadWriter.GetFinalPath("sorted-names-list.txt");
            List<string> sortedFileStrings = File.ReadAllLines(filePath).ToList();

            List<string> expectedSortedStrings = new List<string> { "Box Cat", "Cakey", "Gabby", "Pandy Paws", "Pillow Cat" };
            Assert.That(sortedFileStrings.SequenceEqual(expectedSortedStrings));
        }

        [Test]
        ////Creates a file using functions created in our program, sorts it and tests it. 
        public void TestFullProgramTwo()
        {
            List<string> nameListExample = ["Kitty Fairy", "Pandy", "Mercat", "Gabby", "CatRat"];
            FileReadWriter.WriteStringListToFile(nameListExample, testTwoFileName);

            NameSorter.SortNamesInFile(testTwoFileName);
            string filePath = FileReadWriter.GetFinalPath("sorted-names-list.txt");
            List<string> sortedFileStrings = File.ReadAllLines(filePath).ToList();

            List<string> expectedSortedStrings = new List<string> { "CatRat", "Gabby", "Kitty Fairy", "Mercat", "Pandy" };
            Assert.That(sortedFileStrings.SequenceEqual(expectedSortedStrings));
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                if (File.Exists(FileReadWriter.GetFinalPath(testOneFileName)))
                {
                    File.Delete(FileReadWriter.GetFinalPath(testOneFileName));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting test one file: " + ex.Message);
            }

            try
            {
                if (File.Exists(FileReadWriter.GetFinalPath(testTwoFileName)))
                {
                    File.Delete(FileReadWriter.GetFinalPath(testTwoFileName));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting test two file: " + ex.Message);
            }
        }
    }
}