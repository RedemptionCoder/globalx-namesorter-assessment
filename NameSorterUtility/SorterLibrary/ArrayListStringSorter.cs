using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace SorterLibrary
{
    public class ArrayListStringSorter : ISorter
    {

        #region Constructors

        /// <summary>
        /// Default Constructor. Initialises the unsorted and sorted arraylists.
        /// </summary>
        public ArrayListStringSorter()
        {
            unsortedStrings = new ArrayList();
            sortedStrings = new ArrayList();

            // Remove whitepace by default
            removeWhitespace = true;

        }

        #endregion

        #region Properties

        /// <summary>
        /// Sets whether to trim strings in data or not
        /// </summary>
        public bool RemoveWhitespace
        {
            get
            {
                return removeWhitespace;
            }

            set
            {
                removeWhitespace = value;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sorts the Strings in alphabetical order
        /// </summary>
        public void sort()
        {

            // Assign the unsorted strings to the sorted strings
            sortedStrings = unsortedStrings;
            
            // Sort the strings using the ArrayList.sort function
            sortedStrings.Sort();

        }

        /// <summary>
        /// Sets the data to be sorted
        /// </summary>
        /// <param name="data">ArrayList containing data</param>
        public void setData(ArrayList data)
        {
            
            // Remove whitespace if required
            if (removeWhitespace)
            {
                for (int i=0;i<data.Count;i++)
                {
                    data[i] = ((string)(data[i])).Trim();
                }
            }

            unsortedStrings = data;
        }

        /// <summary>
        /// Gets the original unsorted data
        /// </summary>
        /// <returns>ArrayList containing the unsorted data</returns>
        public ArrayList getData()
        {
            return unsortedStrings;
        }

        /// <summary>
        /// Gets the sorted data.
        /// </summary>
        /// <returns>ArrayList containing the sorted data</returns>
        public ArrayList getSortedData()
        {
            return sortedStrings;
        }

        #endregion

        #region Private Attributes

        // The list of string to be sorted
        private ArrayList sortedStrings;

        // The list of strings before they were sorted
        private ArrayList unsortedStrings;

        // Whether to remove whitespace from data
        private bool removeWhitespace;

        #endregion

    }
}
