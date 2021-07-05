using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace SorterLibrary
{
    class TextDataFile : IDataSource
    {

        #region Constructors

        /// <summary>
        /// Initialises the TextDataFile object
        /// </summary>
        public TextDataFile()
        {
            // Set text data file name to nothing
            textDataFileName = "";

            // Initialise the data arraylist
            loadedData = new ArrayList();
        }

        /// <summary>
        /// Initialised the TextDataFile object with the supplied filename path
        /// </summary>
        /// <param name="path"></param>
        public TextDataFile(string path)
        {
            // Set the file name
            textDataFileName = path;
        }

        #endregion 

        #region Properties

        /// <summary>
        /// Gets or sets the filename
        /// </summary>
        public string FilePath
        {
            get
            {
                return textDataFileName;
            }

            set
            {
                textDataFileName = value;
            }
        }

        // Gets the data loaded as an ArrayList
        public ArrayList LoadedData
        {
            get
            {
                return loadedData;
            }
        }

        // Gets the data loaded as a string array
        public string[] LoadedDataArray
        {
            get
            {
                return (string[])loadedData.ToArray(typeof(string));
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the data from the data file. An empty ArrayList will be returned if the file 
        /// could not be accessed.
        /// </summary>
        /// <returns>ArrayList containing data.</returns>
        public ArrayList getData()
        {
            
            try
            {
                // Read the contents of the file
                string[] fileLines = File.ReadAllLines(textDataFileName);

                // Convert the string array to ArrayList
                loadedData = new ArrayList(fileLines); 

            } catch
            {
                // Could read from file, do nothing
            }

            // Return the data
            return loadedData;

        }

        /// <summary>
        /// Sets the data to be saved to the file. Use the method SaveData to save the loaded
        /// data to the file after using this method
        /// </summary>
        /// <param name="data">ArrayList containing data to be saved to the file</param>
        public void setData(ArrayList data)
        {
            // Set the loaded data
            loadedData = data;
        }

        

        /// <summary>
        /// Saved the data into the text file
        /// </summary>
        /// <returns>true If successfull, false if there were issues</returns>
        public bool SaveData()
        {
            try
            {
                File.WriteAllLines(textDataFileName, (string[])loadedData.ToArray(typeof(string)));
                return true;
            } catch
            {
                return false;
            }
        }

        #endregion

        #region Private/Protected Attributes

        // The path to the data file
        protected string textDataFileName = "";

        // The data to be read/written
        protected ArrayList loadedData;

        #endregion
    }
}
