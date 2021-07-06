using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SorterLibrary
{
    public class MergeSortStringSorter : ISorter
    {
        #region Constructors

        /// <summary>
        /// Default constructor. Initialises the string arrays
        /// </summary>
        public MergeSortStringSorter()
        {
            unsortedStrings = new string[0];
            sortedStrings = new string[0];
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
               

        #region Public methods

        /// <summary>
        /// Sets the data to be sorted
        /// </summary>
        /// <param name="data">ArrayList containing data</param>
        public void setData(ArrayList data)
        {

            // Remove whitespace if required
            if (removeWhitespace)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    data[i] = ((string)(data[i])).Trim();
                }
            }

            unsortedStrings = (string[])data.ToArray(typeof(string));
        }

        /// <summary>
        /// Gets the original unsorted data
        /// </summary>
        /// <returns>ArrayList containing the unsorted data</returns>
        public ArrayList getData()
        {
            return new ArrayList(unsortedStrings);
        }

        /// <summary>
        /// Gets the sorted data.
        /// </summary>
        /// <returns>ArrayList containing the sorted data</returns>
        public ArrayList getSortedData()
        {
            return new ArrayList(sortedStrings);
        }

        /// <summary>
        /// Sorts the data using a sorting algoritm. 
        /// </summary>
        public void sort()
        {

            // Assign the unsorted strings to the sorted strings
            sortedStrings = unsortedStrings;

            // Sort the strings using the ArrayList.sort function
            mergeSort(sortedStrings, 0, sortedStrings.Length-1);

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Merges the array chucks together after sorting them
        /// </summary>
        /// <param name="array">The string arrya</param>
        /// <param name="left">The left index</param>
        /// <param name="mid">The mid index</param>
        /// <param name="right">The right index</param>
        void merge(string [] array, int left, int mid, int right)
        {
            int i, j, k;

            // Size of left sublist
            int size_left = mid - left + 1;

            // Size of right sublist
            int size_right = right - mid;

            /* create temp arrays */
            string[] Left = new string[size_left]; 
            string[] Right = new string[size_right];

            /* Copy data to temp arrays L[] and R[] */
            for (i = 0; i < size_left; i++)
            {
                Left[i] = array[left + i];
            }

            for (j = 0; j < size_right; j++)
            {
                Right[j] = array[mid + 1 + j];
            }

            // Merge the temp arrays back into arr[left..right]
            i = 0; // Initial index of left subarray
            j = 0; // Initial index of right subarray
            k = left; // Initial index of merged subarray

            while (i < size_left && j < size_right)
            {
                if (String.Compare(Left[i], Right[j])<=0)
                
                {
                    array[k] = Left[i];
                    i++;
                }
                else
                {
                    array[k] = Right[j];
                    j++;
                }
                k++;
            }

            // Copy the remaining elements of Left[]
            while (i < size_left)
            {
                array[k] = Left[i];
                i++;
                k++;
            }

            // Copy the rest elements of R[]
            while (j < size_right)
            {
                array[k] = Right[j];
                j++;
                k++;
            }
        }

        /// <summary>
        /// Performs the sort of the supplied strings using the well known Merge Sort
        /// algorithm
        /// </summary>
        /// <param name="array">The array of strings</param>
        /// <param name="left">The start position</param>
        /// <param name="right">The last position</param>
        void mergeSort(string [] array, int left, int right)
        {
            if (left < right)
            {
                // Find the mind point to split the array
                int mid = (left + right) / 2;

                // Sort first and second halves
                mergeSort(array, left, mid);
                mergeSort(array, mid + 1, right);

                // Finally merge them
                merge(array, left, mid, right);
            }
        }

        #endregion

        #region Private Attributes

        // The list of strings before they were sorted
        private string[] unsortedStrings;

        // The list of string to be sorted
        private string[] sortedStrings;

        // Whether to remove whitespace from data
        private bool removeWhitespace;

        #endregion

    }
}
