using System;
using SorterLibrary;
using Xunit;

namespace NameSorterUtility.Tests
{
    public class TextDataFile_getDataShould
    {
        /// <summary>
        /// This test will test if data can be read in successfully from the given data file
        /// </summary>
        /// <param name="path">Data file name</param>
        /// <param name="expectedData">The expected data in the file</param>
        [Theory]
        [InlineData("sourceData.txt",new string[] { "Janet Parsons",
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
        public void getData_LoadListOfNamesFromFile_NamesLoadedIntoLoadedDataArrayList(string path, string[] expectedData)
        {

            // Set up the data file class
            TextDataFile dataFile = new TextDataFile(path);

            // Load the data from the file
            dataFile.getData();

            // Perform the sort
            string[] result = dataFile.LoadedDataArray;

            // check the result
            Assert.Equal(expectedData, result);

        }

        /// <summary>
        /// This test checks whether an empty ArrayList is generated from an 
        /// incorrect or inaccessible source file
        /// </summary>
        /// <param name="path"></param>
        [Theory]
        [InlineData("asdfasdfasdfta.txt")]
        public void getData_IncorrectFileOrPath_EmptyDataArrayList(string path)
        {

            // Set up the data file class
            TextDataFile dataFile = new TextDataFile(path);

            // Load the data from the file
            dataFile.getData();

            // Perform the sort
            int result = dataFile.LoadedData.Count;

            // check the result
            Assert.Equal(0, result);

        }



    }
}
