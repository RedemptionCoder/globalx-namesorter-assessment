using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace SorterLibrary
{
    public class StringSorter
    {

        #region Constructors

        /// <summary>
        /// Default Constructor. Initialises the strings as an empty arraylist
        /// </summary>
        public StringSorter()
        {
            stringsToSort = new ArrayList();
        }

        /// <summary>
        /// Constructor initialises the list of string to sort using the provided
        /// list of strings as an ArrayList data structure
        /// </summary>
        /// <param name="listOfStrings">The list of string to sort in ArrayList form</param>
        public StringSorter(ArrayList listOfStrings)
        {
            stringsToSort = listOfStrings;
        }

        /// <summary>
        /// Constructor initialises the list of string to sort using the provided
        /// list of strings as an array of strings
        /// </summary>
        /// <param name="listOfStrings">The list of string to sort as an array of strings</param>
        public StringSorter(string[] listOfStrings)
        {
            // Initialise the ArrayList
            stringsToSort = new ArrayList(listOfStrings);
                        
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Sorts the Strings in alphabetical order
        /// </summary>
        /// <returns>Retruns the strings in alphabetical order as a string array. 
        /// This sorted string can also be accessed from the Strings property. </returns>
        public string[] Sort()
        {
            // Sort the strings
            stringsToSort.Sort();

            // Return the sorted strings as a string array
            return ToStringArray();
        }

        #endregion

        #region Private Functions

        /// <summary>
        /// Converts the list of strings in the stringsToSort ArrayList to an array of strings 
        /// </summary>
        /// <returns>An array of strings containing the strings the stringsToSort ArrayList</returns>
        private string[] ToStringArray()
        {
            // Initliase the string array
            string[] stringArray = new string[stringsToSort.Count];

            // Add the strings from the arraylist to the string array
            for (int i = 0;i < stringsToSort.Count;i++) {
                stringArray[i] = (string)stringsToSort[i];
            }

            // Return the populated string array
            return stringArray;

        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or Sets the list of strings to be sorted.
        /// </summary>
        public ArrayList Strings
        {
            get
            {
                return stringsToSort;
            }

            set
            {
                stringsToSort = value;
            }
        }

        /// <summary>
        /// Gets or sets the list of strings to be sorted as a string array
        /// </summary>
        public string[] StringsArray
        {
            get
            {
                return ToStringArray();
            }
            
            set
            {
                stringsToSort = new ArrayList(value);
            }
        }

        #endregion

        #region Private Attributes

        // The list of string to be sorted
        private ArrayList stringsToSort; 

        #endregion

    }
}
