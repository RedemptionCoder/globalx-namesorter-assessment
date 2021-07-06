using System;
using SorterLibrary;
using Xunit;

namespace NameSorterUtility.Tests
{
    public class NameSorter_DataSourceShould
    {

        /// <summary>
        /// Tests the entire operation from input data file to output data file with sorted names
        /// </summary>
        /// <param name="path">The input file with unsorted names</param>
        /// <param name="expectedData">The expected contents of the output file</param>
        [Theory]
        [InlineData("sourceDataUnsorted.txt", new string[] { "Marin Alvarez",
                                    "Adonis Julius Archer",
                                    "Beau Tristan Bentley",
                                    "Hunter Uriah Mathew Clarke",
                                    "Leo Gardner",
                                    "Vaughn Lewis",
                                    "London Lindsey",
                                    "Mikayla Lopez",
                                    "Janet Parsons",
                                    "Frankie Conner Ritter",
                                    "Shelby Nathan Yoder" }, "destDataSorted.txt")]
        
        // The sourceDataUnsortedBlanks has some blank characters at the end of one name, and a tab at the end of another
        // Testing to see if sorter can handle blanks or if a trim is required. 
        [InlineData("sourceDataUnsortedBlanks.txt", new string[] { "Marin Alvarez",
                                    "Adonis Julius Archer",
                                    "Beau Tristan Bentley",
                                    "Hunter Uriah Mathew Clarke",
                                    "Leo Gardner",
                                    "Vaughn Lewis",
                                    "London Lindsey",
                                    "Mikayla Lopez",
                                    "Janet Parsons",
                                    "Frankie Conner Ritter",
                                    "Shelby Nathan Yoder" }, "destDataSorted.txt")]
        public void DataSource_SetAndGetDataSource_OutputFileWithSortedNames(string path, string[] expectedData, string outputFile)
        {
            // Set up the text file
            TextDataFile dataFile = new TextDataFile(path);
            
            // Set up the sorter 
            NameSorter nameSorter = new NameSorter();

            // Set the data source
            nameSorter.DataSource = dataFile;

            // Perform the sort
            nameSorter.SortByLastName();

            // Get the data source with the sorted names
            dataFile = (TextDataFile)nameSorter.DataSource;

            // Set the output file name
            dataFile.FilePath = outputFile;

            // Save the data
            dataFile.SaveData();

            // Read in the data from the output file
            string[] result = System.IO.File.ReadAllLines(outputFile);

            // check the result
            Assert.Equal(expectedData, result);

        }

    }
}

