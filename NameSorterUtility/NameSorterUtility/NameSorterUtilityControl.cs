using System;
using SorterLibrary;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NameSorterUtility
{
    public class NameSorterUtilityControl
    {

        #region Constants

        // The default output data file name
        public const string OUTPUT_FILE_NAME = "sorted-names-list.txt";

        #endregion


        #region Constructors

        /// <summary>
        /// Initialised all attributes
        /// </summary>
        public NameSorterUtilityControl()
        {
            // Initialise attributes
            inputData = new TextDataFile();
            outputDataFileName = OUTPUT_FILE_NAME;
            useMergeSort = false;
            supressOutput = false;
            supressErrorsMessages = false;
        }

        public NameSorterUtilityControl(string[] args)
        {
            // Initialise attributes
            inputData = new TextDataFile();
            outputDataFileName = OUTPUT_FILE_NAME;
            useMergeSort = false;
            supressOutput = false;
            supressErrorsMessages = false;

            // The the command line arguments
            arguments = args;
        }


        #endregion

        #region Public Functions

        /// <summary>
        /// Controls the execution flow of the app
        /// </summary>
        public void Run()
        {

            // Get command line options
            if (getCommandLineOptions())
            {

                // Set up the name sorter
                NameSorter nameSorter = new NameSorter();

                // Check if to use MergeSort
                if (useMergeSort)
                {
                    nameSorter.SortAlgorithm = new MergeSortStringSorter();
                }

                // Load the data into the name sorter
                nameSorter.DataSource = inputData;

                // Check if data was loaded successfully
                if (nameSorter.UnsortedNames.Count == 0)
                {
                    if (!supressErrorsMessages) printError("Failed to load data from file, or file was empty");
                }
                else
                {

                    // Perform the sort
                    nameSorter.SortByLastName();

                    // Get the data from the sorter
                    TextDataFile outputData = (TextDataFile)nameSorter.DataSource;

                    // Set the output date file name
                    outputData.FilePath = outputDataFileName;

                    // Save the data
                    if (!outputData.SaveData())
                    {
                        if (!supressErrorsMessages) printError("Failed to save data to " + outputDataFileName);
                    }

                    // Print data to screen
                    if (!supressOutput)
                    {
                        printDataToScreen(nameSorter.SortedByLastName);
                    }
                    else
                    {
                        // If output is supressed, print result of file save operation
                        printMessage("Data saved successfully to " + outputDataFileName);
                    }

                }
            }

        }

        #endregion

        #region Private Functions

        /// <summary>
        /// Prints the contents of the supplied ArrayList to the screen
        /// </summary>
        /// <param name="data">ArrayList containing the data</param>
        private void printDataToScreen(ArrayList data)
        {
            foreach (string outputLine in data)
            {
                Console.WriteLine(outputLine);
            }
        }

        /// <summary>
        /// Prints an error message to console
        /// </summary>
        /// <param name="errorMessage">The error message</param>
        private void printError(string errorMessage)
        {
            Console.WriteLine("");
            Console.WriteLine("ERROR: " + errorMessage);
            Console.WriteLine("");
        }

        /// <summary>
        /// Prints a message to console
        /// </summary>
        /// <param name="message">The message</param>
        private void printMessage(string message)
        {
            Console.WriteLine("");
            Console.WriteLine(message);
            Console.WriteLine("");
        }

        // 
        // 

        /// <summary>
        /// Gets all of the options from the command line and stores settings in 
        /// controller attributes
        /// </summary>
        /// <returns>true If command line options are valid, false if not</returns>
        private bool getCommandLineOptions()
        {

            // Check for help option and print out help information
            if (getArgFlag("h"))
            {
                showHelp();
                return false;
            }

            // Set up the text data file 
            if (arguments.Length > 0)
            {
                inputData = new TextDataFile(arguments[0]);
            } else
            {
                showHelp();
                return false;
            }

            // Get the output data file name
            string path = getArgValue("o");
            if (path.Length>0)
            {
                outputDataFileName = path;
            }

            // Get merge sort flag
            useMergeSort = getArgFlag("ms");

            // Get output supression
            supressOutput = getArgFlag("so");

            // Get error supression
            supressErrorsMessages = getArgFlag("se");

            return true;

        }

        /// <summary>
        /// Looks for the value of the supplied parameter.
        /// </summary>
        /// <param name="parameter">The parameter to look for</param>
        /// <returns>The value of the parameter</returns>
        private string getArgValue(string parameter)
        {

            string lPar = "-" + parameter;

            // Go through each elements of the argument array
            for (int i = 0; i < arguments.Length; i++)
            {

                // If the parameter exists, then return true
                if (arguments[i].Equals(lPar))
                {

                    if ((i + 1) != arguments.Length)
                    {
                        if (arguments[i + 1].StartsWith("-"))
                        {
                            // there is no value for the parameter, the next parameter has been found
                            // return empty string
                            return "";
                        }
                        else
                        {
                            // return the value
                            return arguments[i + 1];
                        }
                    }
                    else
                    {
                        // end of array reached. No value for parameter
                        // return empty string
                        return "";
                    }
                }
            }

            return "";

        }

        /// <summary>
        /// Looks for the presence of a parameter in the command line arguments.
        /// If the parameter exists, is indicates a true for that parameter.
        /// </summary>
        /// <param name="parameter">The parameter to look for</param>
        /// <returns>True if the parameter has been found</returns>
        private bool getArgFlag(string parameter)
        {

            // Attach the prefix character
            string lPar = "-" + parameter;

            // Go through each elements of the argument array
            foreach (string lParEl in arguments)
            {

                // If the parameter exists, then return true
                if (lParEl.Equals(lPar))
                {
                    return true;
                }
            }

            // Parameter does not exist, return false
            return false;
        }

        
        /// <summary>
        /// Displays the command line help information
        /// </summary>
        private void showHelp()
        {

            Console.WriteLine("");
            Console.WriteLine("name-sorter <Input File Name> [OPTIONS...]");
            Console.WriteLine("");
            Console.WriteLine("Where OPTIONS include:");
            Console.WriteLine("");
            Console.WriteLine("  -h\t\t\tShow this help");
            Console.WriteLine("  -ms \t\t\tUse the merge sort algorithm for sorting");
            Console.WriteLine("  -so \t\t\tSupress output of sorted names");
            Console.WriteLine("  -se \t\t\tSupress output of error messages");
            Console.WriteLine("  -o <Output File>\tThe output file name/path. Default is sorted-names-list.txt");
            Console.WriteLine("");

        }

        #endregion

        #region Private Attributes

        // The input data file
        private TextDataFile inputData;

        // The output data file
        private string outputDataFileName;

        // The command line arguments
        private string[] arguments;

        // A flag which specifies whether to use custom merge sort algorithms
        private bool useMergeSort;

        // Whether to supress output of sorted names
        private bool supressOutput;

        // Whether to supress errors and messages
        private bool supressErrorsMessages;

        #endregion

    }
}
