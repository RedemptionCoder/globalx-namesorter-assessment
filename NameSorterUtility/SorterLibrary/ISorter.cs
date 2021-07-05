using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SorterLibrary
{
    public interface ISorter
    {
        /// <summary>
        /// Sets the data to be sorted
        /// </summary>
        /// <param name="data">ArrayList containing data</param>
        public void setData(ArrayList data);

        /// <summary>
        /// Gets the original unsorted data
        /// </summary>
        /// <returns>ArrayList containing the unsorted data</returns>
        public ArrayList getData();

        /// <summary>
        /// Gets the sorted data.
        /// </summary>
        /// <returns>ArrayList containing the sorted data</returns>
        public ArrayList getSortedData();

        /// <summary>
        /// Sorts the data using a sorting algoritm. 
        /// </summary>
        public void sort();

    }
}
