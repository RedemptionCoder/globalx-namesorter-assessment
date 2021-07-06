using System;
using SorterLibrary;
using Xunit;

namespace NameSorterUtility.Tests
{
    public class NameSorter_NameSorterShould
    {

        /// <summary>
        /// This test checks whether data can be loaded into the NameSorter successfully from the data file class
        /// </summary>
        /// <param name="path">The path to the data file</param>
        /// <param name="expectedData">The list of names loaded from data file</param>
        [Theory]
        [InlineData("sourceData.txt", new string[] { "Janet Parsons",
                                    "Vaughn Lewis",
                                    "Adonis Julius Archer",
                                    "Shelby Nathan Yoder",                                                      
                                    "Marin Alvarez",
                                    "London Lindsey",
                                    "Beau Tristan Bentley",
                                    "Leo Gardner",
                                    "Hunter Uriah Mathew Clarke",
                                    "Mikayla Lopez",
                                    "Frankie Conner Ritter"})]
        public void NameSorter_TextDataFilePassedIntoConstructor_NamesFromDataFileLoadedIntoNameSorter(string path, string[] expectedData)
        {
            // Set up the text file
            TextDataFile dataFile = new TextDataFile(path);
            
            // Set up the sorter and pass into it the 
            NameSorter nameSorter = new NameSorter(dataFile);

            // Perform the sort via the 
            string[] result = nameSorter.UnsortedNamesArray;

            // check the result
            Assert.Equal(expectedData, result);

        }

    }
}

