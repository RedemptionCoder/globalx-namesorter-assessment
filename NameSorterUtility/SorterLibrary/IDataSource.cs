using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace SorterLibrary
{
    public interface IDataSource
    {
        /// <summary>
        /// Gets an ArrayList containing the data from the data source
        /// </summary>
        /// <returns></returns>
        public ArrayList getData();

        /// <summary>
        /// Sets or adds the data from the supplied ArrayList to the data source
        /// </summary>
        public void setData(ArrayList data);
    }
}
