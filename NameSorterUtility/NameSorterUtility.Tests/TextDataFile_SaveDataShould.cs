using System;
using SorterLibrary;
using System.Collections;
using System.IO;
using Xunit;

namespace NameSorterUtility.Tests
{
    public class TextDataFile_SaveDataShould
    {
        /// <summary>
        /// This test checks if the TextDataFile class can successfully save the given 
        /// data to the data file
        /// </summary>
        /// <param name="path">Path to hte data file</param>
        /// <param name="dataToSave">The data to save</param>
        [Theory]
        [InlineData("testDataFile.txt",new string[] { "Janet Parsons",
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
        public void SaveData_SaveLoadedDataToFile_LoadedDataSavedToFile(string path, string[] dataToSave)
        {

            // Set up the data file class
            TextDataFile dataFile = new TextDataFile(path);

            // Load the data from the file
            dataFile.setData(new ArrayList(dataToSave));

            // Save the data to the data file
            dataFile.SaveData();

            // Load data from the file and check against dataToSave
            string[] loadedData = File.ReadAllLines(path);

            // check the result
            Assert.Equal(loadedData, dataToSave);

        }

    }
}
