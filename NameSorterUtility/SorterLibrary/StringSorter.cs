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
        /// Default Constructor. Sets the default sorting algoritm to the ArrayListStringSorter 
        /// which uses the built-in ArrayList.sort method to sort. 
        /// </summary>
        public StringSorter()
        {
            // The default sorting algorithm uses the ArrayList.sort() function
            sortingAlgorithm = new ArrayListStringSorter();
        }

        /// <summary>
        /// Constructor initialises the list of strings to sort using the provided
        /// list of strings as an ArrayList data structure
        /// </summary>
        /// <param name="listOfStrings">The list of strings to sort in ArrayList form</param>
        public StringSorter(ArrayList listOfStrings)
        {
            // The default sorting algorithm uses the ArrayList.sort() function
            sortingAlgorithm = new ArrayListStringSorter();

            // Assign the data to the sorter
            sortingAlgorithm.setData(listOfStrings);
        }

        /// <summary>
        /// Constructor initialises the list of strings to sort using the provided
        /// list of strings as an array of strings
        /// </summary>
        /// <param name="listOfStrings">The list of string to sort as an array of strings</param>
        public StringSorter(string[] listOfStrings)
        {
            // The default sorting algorithm uses the ArrayList.sort() function
            sortingAlgorithm = new ArrayListStringSorter();

            // Initialise the ArrayList
            sortingAlgorithm.setData(new ArrayList(listOfStrings));
                        
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or Sets the list of strings to be sorted.
        /// </summary>
        public ArrayList UnsortedStrings
        {
            get
            {
                return sortingAlgorithm.getData();
            }

            set
            {
                sortingAlgorithm.setData(value);
            }
        }

        /// <summary>
        /// Gets or sets the list of strings to be sorted as a string array
        /// </summary>
        public string[] UnsortedStringsArray
        {
            get
            {
                return ToStringArray(sortingAlgorithm.getData());
            }

            set
            {
                sortingAlgorithm.setData(new ArrayList(value));
            }
        }

        /// <summary>
        /// Gets the sorted strings as an ArrayList
        /// </summary>
        public ArrayList SortedStrings
        {
            get
            {
                return sortingAlgorithm.getSortedData();
            }
        }

        /// <summary>
        /// Gets the sorted strings as a string array
        /// </summary>
        public string[] SortedStringsArray
        {
            get
            {
                return ToStringArray(sortingAlgorithm.getSortedData());
            }
        }
        

        #endregion

        #region Public Methods

        /// <summary>
        /// Sorts the Strings in alphabetical order
        /// </summary>
        /// <returns>Retruns the strings in alphabetical order as a string array. 
        /// This sorted string can also be accessed from the SortedStrings property. </returns>
        public string[] Sort()
        {
            // Sort the strings
            sortingAlgorithm.sort();

            // Return the sorted strings as a string array
            return ToStringArray(sortingAlgorithm.getSortedData());
        }

        #endregion

        #region Private/Protected Functions

        /// <summary>
        /// Converts the list of strings in the supplied ArrayList to an array of strings 
        /// </summary>
        /// <returns>An array of strings containing the strings the supplied ArrayList</returns>
        protected string[] ToStringArray(ArrayList stringsArrayList)
        {
            
            // Return the populated string array
            return (string[])stringsArrayList.ToArray(typeof(string));

        }

        #endregion

        

        #region Private/Protected Attributes

        // The sorting algorithm being used. 
        protected ISorter sortingAlgorithm;

        #endregion

    }
}
