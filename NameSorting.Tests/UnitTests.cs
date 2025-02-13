using NUnit.Framework;
using Namesorting.Utils;
using System;


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

            File.WriteAllText(FileReadWriter.GetFinalPath(testOneFileName), $"Janet Parsons{newLine}Vaughn Lewis{newLine}Adonis Julius Archer{newLine}Shelby Nathan Yoder{newLine}Marin Alvarez{newLine}London Lindsey{newLine}Beau Tristan Bentley{newLine}Leo Gardner{newLine}Hunter Uriah Mathew Clarke{newLine}Mikayla Lopez{newLine}Frankie Conner Ritter{newLine}");
        }

        [Test]
        public void TestNameSortingFunction()
        {
            string[] nameArrayExample = { "Janet Parsons", "Vaughn Lewis", "Adonis Julius Archer", "Shelby Nathan Yoder", "Marin Alvarez", "London Lindsey", "Beau Tristan Bentley", "Leo Gardner", "Hunter Uriah Mathew Clarke", "Mikayla Lopez", "Frankie Conner Ritter" };
            List<string> namesAfterSorting = NameSorter.SortStringsForward(nameArrayExample);
            List<string> expectedSortedNames = new List<string> { "Marin Alvarez", "Adonis Julius Archer", "Beau Tristan Bentley", "Hunter Uriah Mathew Clarke", "Leo Gardner", "Vaughn Lewis", "London Lindsey", "Mikayla Lopez", "Janet Parsons", "Frankie Conner Ritter", "Shelby Nathan Yoder"};

            Assert.That(namesAfterSorting.SequenceEqual(expectedSortedNames));
        }

        [Test]
        public void TestReverseNameSortingFunction()
        {
            string[] nameArrayExample = { "Janet Parsons", "Vaughn Lewis", "Adonis Julius Archer", "Shelby Nathan Yoder", "Marin Alvarez", "London Lindsey", "Beau Tristan Bentley", "Leo Gardner", "Hunter Uriah Mathew Clarke", "Mikayla Lopez", "Frankie Conner Ritter" };
            List<string> namesAfterSorting = NameSorter.SortStringsBackward(nameArrayExample);
            List<string> expectedSortedNames = new List<string> { "Shelby Nathan Yoder", "Frankie Conner Ritter", "Janet Parsons", "Mikayla Lopez", "London Lindsey", "Vaughn Lewis", "Leo Gardner", "Hunter Uriah Mathew Clarke", "Beau Tristan Bentley", "Adonis Julius Archer", "Marin Alvarez" };

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
        public void TestFullProgramForwardOrderOne()
        {
            NameSorter.SortNamesInFile(testOneFileName, true);
            string filePath = FileReadWriter.GetFinalPath("sorted-names-list.txt");
            List<string> sortedFileStrings = File.ReadAllLines(filePath).ToList();

            List<string> expectedSortedNames = new List<string> { "Marin Alvarez", "Adonis Julius Archer", "Beau Tristan Bentley", "Hunter Uriah Mathew Clarke", "Leo Gardner", "Vaughn Lewis", "London Lindsey", "Mikayla Lopez", "Janet Parsons", "Frankie Conner Ritter", "Shelby Nathan Yoder" };
            Assert.That(sortedFileStrings.SequenceEqual(expectedSortedNames));
        }

        [Test]
        ////Creates a file using functions created in our program, sorts it and tests it. 
        public void TestFullProgramForwardOrderTwo()
        {
            List<string> nameListExample = ["Janet Parsons", "Vaughn Lewis", "Adonis Julius Archer", "Shelby Nathan Yoder", "Marin Alvarez", "London Lindsey", "Beau Tristan Bentley", "Leo Gardner", "Hunter Uriah Mathew Clarke", "Mikayla Lopez", "Frankie Conner Ritter"];
            FileReadWriter.WriteStringListToFile(nameListExample, testTwoFileName);

            NameSorter.SortNamesInFile(testTwoFileName, true);
            string filePath = FileReadWriter.GetFinalPath("sorted-names-list.txt");
            List<string> sortedFileStrings = File.ReadAllLines(filePath).ToList();

            List<string> expectedSortedNames = new List<string> { "Marin Alvarez", "Adonis Julius Archer", "Beau Tristan Bentley", "Hunter Uriah Mathew Clarke", "Leo Gardner", "Vaughn Lewis", "London Lindsey", "Mikayla Lopez", "Janet Parsons", "Frankie Conner Ritter", "Shelby Nathan Yoder" };
            Assert.That(sortedFileStrings.SequenceEqual(expectedSortedNames));
        }

        [Test]
        ////Tests the file created in our set up
        public void TestFullProgramReverseOrderOne()
        {
            NameSorter.SortNamesInFile(testOneFileName, false);
            string filePath = FileReadWriter.GetFinalPath("sorted-names-list.txt");
            List<string> sortedFileStrings = File.ReadAllLines(filePath).ToList();

            List<string> expectedSortedNames = new List<string> { "Shelby Nathan Yoder", "Frankie Conner Ritter", "Janet Parsons", "Mikayla Lopez", "London Lindsey", "Vaughn Lewis", "Leo Gardner", "Hunter Uriah Mathew Clarke", "Beau Tristan Bentley", "Adonis Julius Archer", "Marin Alvarez" };
            Assert.That(sortedFileStrings.SequenceEqual(expectedSortedNames));
        }

        [Test]
        ////Creates a file using functions created in our program, sorts it and tests it. 
        public void TestFullProgramReverseOrderTwo()
        {
            List<string> nameListExample = ["Janet Parsons", "Vaughn Lewis", "Adonis Julius Archer", "Shelby Nathan Yoder", "Marin Alvarez", "London Lindsey", "Beau Tristan Bentley", "Leo Gardner", "Hunter Uriah Mathew Clarke", "Mikayla Lopez", "Frankie Conner Ritter"];
            FileReadWriter.WriteStringListToFile(nameListExample, testTwoFileName);

            NameSorter.SortNamesInFile(testTwoFileName, false);
            string filePath = FileReadWriter.GetFinalPath("sorted-names-list.txt");
            List<string> sortedFileStrings = File.ReadAllLines(filePath).ToList();

            List<string> expectedSortedNames = new List<string> { "Shelby Nathan Yoder", "Frankie Conner Ritter", "Janet Parsons", "Mikayla Lopez", "London Lindsey", "Vaughn Lewis", "Leo Gardner", "Hunter Uriah Mathew Clarke", "Beau Tristan Bentley", "Adonis Julius Archer", "Marin Alvarez" };

            Assert.That(sortedFileStrings.SequenceEqual(expectedSortedNames));
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