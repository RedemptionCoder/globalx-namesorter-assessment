using System;
using SorterLibrary;
using NameSorterUtility;
using Xunit;

namespace NameSorterUtility.Tests
{
    public class NameSorterUtilityControl_RunShould
    {

        #region Constants

        // The text file containing the long list of sorted test names to be loaded into memory
        public const string SORTED_NAMES_LIST_LONG_FILE = "sorted-names-list-long-test.txt";

        // The text file containing the long list of unsorted names for testing
        public const string UNSORTED_NAMES_LIST_LONG_FILE = "unsorted-names-list-long.txt";


        #endregion

        #region Constructors

        
        #endregion



        public const string REQUIRED_DEFAULT_OUTPUT_FILE_NAME = "sorted-names-list.txt";

        /// <summary>
        /// Tests the main control of flow of the controller to see if the required input file data is loaded, sorted
        /// and written to the required output file as per the requirements.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// <param name="expectedData">The expected contents of the output data file</param>
        [Theory]
        [InlineData(new string[] {"unsorted-names-list.txt","-ms"}, new string[] { "Marin Alvarez",
                                    "Adonis Julius Archer",
                                    "Beau Tristan Bentley",
                                    "Hunter Uriah Mathew Clarke",
                                    "Leo Gardner",
                                    "Vaughn Lewis",
                                    "London Lindsey",
                                    "Mikayla Lopez",
                                    "Janet Parsons",
                                    "Frankie Conner Ritter",
                                    "Shelby Nathan Yoder" })]
        
        // The sourceDataUnsortedBlanks has some blank characters at the end of one name, and a tab at the end of another
        // Testing to see if sorter can handle blanks or if a trim is required. 
        [InlineData(new string[] { "sourceDataUnsortedBlanks.txt", "-ms" }, new string[] { "Marin Alvarez",
                                    "Adonis Julius Archer",
                                    "Beau Tristan Bentley",
                                    "Hunter Uriah Mathew Clarke",
                                    "Leo Gardner",
                                    "Vaughn Lewis",
                                    "London Lindsey",
                                    "Mikayla Lopez",
                                    "Janet Parsons",
                                    "Frankie Conner Ritter",
                                    "Shelby Nathan Yoder" })]
        public void Run_UseMergeSort_OutputFileWithSortedNames(string [] args, string[] expectedData)
        {

            // Create the app controller
            NameSorterUtilityControl controller = new NameSorterUtilityControl(args);

            // Run the controller
            controller.Run();

            // Read in the data from the output file
            string[] result = System.IO.File.ReadAllLines(REQUIRED_DEFAULT_OUTPUT_FILE_NAME);

            // check the result
            Assert.Equal(expectedData, result);

        }

        /// <summary>
        /// Tests the main control of flow of the controller to see if the required input file data is loaded, sorted
        /// and written to the required output file as per the requirements.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// <param name="expectedData">The expected contents of the output data file</param>
        [Theory]
        [InlineData(new string[] { "unsorted-names-list.txt" }, new string[] { "Marin Alvarez",
                                    "Adonis Julius Archer",
                                    "Beau Tristan Bentley",
                                    "Hunter Uriah Mathew Clarke",
                                    "Leo Gardner",
                                    "Vaughn Lewis",
                                    "London Lindsey",
                                    "Mikayla Lopez",
                                    "Janet Parsons",
                                    "Frankie Conner Ritter",
                                    "Shelby Nathan Yoder" })]

        // The sourceDataUnsortedBlanks has some blank characters at the end of one name, and a tab at the end of another
        // Testing to see if sorter can handle blanks or if a trim is required. 
        [InlineData(new string[] { "sourceDataUnsortedBlanks.txt" }, new string[] { "Marin Alvarez",
                                    "Adonis Julius Archer",
                                    "Beau Tristan Bentley",
                                    "Hunter Uriah Mathew Clarke",
                                    "Leo Gardner",
                                    "Vaughn Lewis",
                                    "London Lindsey",
                                    "Mikayla Lopez",
                                    "Janet Parsons",
                                    "Frankie Conner Ritter",
                                    "Shelby Nathan Yoder" })]
        public void Run_SpecifyCommandlineArgsInputFile_OutputFileWithSortedNames(string[] args, string[] expectedData)
        {

            // Create the app controller
            NameSorterUtilityControl controller = new NameSorterUtilityControl(args);

            // Run the controller
            controller.Run();

            // Read in the data from the output file
            string[] result = System.IO.File.ReadAllLines(REQUIRED_DEFAULT_OUTPUT_FILE_NAME);

            // check the result
            Assert.Equal(expectedData, result);

        }

        /// <summary>
        /// This tests checks if an output file with the supplied commandline filename is generated
        /// </summary>
        /// <param name="args">Arguments containing both the input and output filenames</param>
        /// <param name="expectedData">The expected data</param>
        [Theory]
        [InlineData(new string[] { "unsorted-names-list.txt","-o","customOutputFile.txt" }, new string[] { "Marin Alvarez",
                                    "Adonis Julius Archer",
                                    "Beau Tristan Bentley",
                                    "Hunter Uriah Mathew Clarke",
                                    "Leo Gardner",
                                    "Vaughn Lewis",
                                    "London Lindsey",
                                    "Mikayla Lopez",
                                    "Janet Parsons",
                                    "Frankie Conner Ritter",
                                    "Shelby Nathan Yoder" })]
        
        public void Run_SpecifyCommandlineArgsInputFileWithOutputFilename_OutputFileWithSortedNamesInCustomOutputFileName(string[] args, string[] expectedData)
        {

            // Create the app controller
            NameSorterUtilityControl controller = new NameSorterUtilityControl(args);

            // Run the controller
            controller.Run();

            // Read in the data from the output file
            string[] result = System.IO.File.ReadAllLines("customOutputFile.txt");

            // check the result
            Assert.Equal(expectedData, result);

        }

        [Theory]
        [InlineData(new string[] { "unsorted-names-list-long.txt" }, SORTED_NAMES_LIST_LONG_FILE)]

        public void Run_SpecifyCommandlineArgsInputFileWithLongListNames_OutputFileWithSortedNames(string[] args, string expectedDataFile)
        {

            // Create the app controller
            NameSorterUtilityControl controller = new NameSorterUtilityControl(args);

            // Run the controller
            controller.Run();

            // Read in the data from the output file
            string[] result = System.IO.File.ReadAllLines("sorted-names-list.txt");

            // Get the expected data from the expected data file
            string[] expectedData = System.IO.File.ReadAllLines(expectedDataFile);

            // check the result
            Assert.Equal(expectedData, result);

        }

    }


}

