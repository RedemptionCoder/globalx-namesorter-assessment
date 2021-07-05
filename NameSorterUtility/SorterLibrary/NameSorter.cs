using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace SorterLibrary
{
    public class NameSorter : StringSorter
    {

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public NameSorter() : base()
        {
            // Initliase the names by lastname list
            namesByLastName = new ArrayList();

            // Initialise the sorted names list
            sortedByLastName = new ArrayList();

            // Set the data source to null
            dataSource = null;

        }

        /// <summary>
        /// Initialises a NameSorter with the provided list of names
        /// </summary>
        /// <param name="listOfStrings"></param>
        public NameSorter(string[] listOfNames) : base(listOfNames)
        {
            // Initliase the names by lastname list
            namesByLastName = new ArrayList();

            // Initialise the sorted names list
            sortedByLastName = new ArrayList();

            // Set the data source to null
            dataSource = null;
        }

        /// <summary>
        /// Initialises the NameSorter with data from an external data
        /// source.
        /// </summary>
        /// <param name="externalDataSource"></param>
        public NameSorter(IDataSource externalDataSource) : base()
        {

            // Initliase the names by lastname list
            namesByLastName = new ArrayList();

            // Initialise the sorted names list
            sortedByLastName = new ArrayList();

            // Set the datasource
            dataSource = externalDataSource;

            try
            {
                // Load the data from the datasource
                sortingAlgorithm.setData(dataSource.getData());

            } catch
            {
                // failed to read data from data source
                // Do nothing
            }

        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the list of names to be sorted 
        /// </summary>
        public ArrayList UnsortedNames
        {
            get
            {
                return UnsortedStrings;
            }

            set
            {
                sortingAlgorithm.setData(value);
            }
        }

        /// <summary>
        /// Gets or sets the list of names to be sorted as a string array
        /// </summary>
        public string[] UnsortedNamesArray
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
        /// Gets the list of names with last names first
        /// </summary>
        public ArrayList NamesByLastName
        {
            get
            {
                // Rearange the names first
                rearrangeForLastNameFirst();

                // Return names by lastname
                return namesByLastName;
            }
        }

        /// <summary>
        /// Gets the list of names with last names first as string array
        /// </summary>
        public string[] NamesByLastNameArray
        {
            get
            {
                // Rearange the names first
                rearrangeForLastNameFirst();

                // Return names by lastname
                return ToStringArray(namesByLastName);
            }
        }

        /// <summary>
        /// Gets the names sorted by last name. Will sort the names first. 
        /// </summary>
        public ArrayList SortedByLastName
        {
            get
            {
                // Update the sort
                SortByLastName();

                // Return the sorted names
                return sortedByLastName;
            }
        }

        /// <summary>
        /// Gets the names sorted by last name as string array
        /// </summary>
        public string[] SortedByLastNameArray
        {
            get
            {
                // Update the sort
                SortByLastName();

                // Return the sorted names
                return ToStringArray(sortedByLastName);
            }
        }

        /// <summary>
        /// The DateSource propery can be used to load names to be sorted from a data source
        /// such as a text file, or a database. The value of this property will contain the 
        /// data source with it's data updated with the sorted names. If the datasource hasn't 
        /// been set, it will return a null
        /// </summary>
        public IDataSource DataSource
        {
            get
            {
                if (dataSource != null)
                {
                    // Update the data on the datasource
                    dataSource.setData(SortedByLastName);

                    // Return the updated datasource
                    return dataSource;
                } else
                {
                    return null;
                }
            }

            set
            {
                // Set the datasource
                dataSource = value;

                // Load the data from the datasource
                UnsortedNames = dataSource.getData();
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sorts the list of names by surname/lastname and sets the SortedNames
        /// property to the sorted list of names and also returns a string array
        /// of the names sorted by last name
        /// </summary>
        /// <param name="displayLastNameFirst">Set to true if last names should be displayed first. Default is false</param>
        /// <returns>string Array containing the sorted names by last name</returns>
        public string[] SortByLastName(bool displayLastNameFirst=false) 
        {
            // Take a back-up for the original names list
            ArrayList orignalNamesList = UnsortedStrings;

            // Firstly put the last names first
            rearrangeForLastNameFirst();

            // Set the unsorted strings to be the rearranged list of names
            UnsortedStrings = namesByLastName;

            // Perform the sort
            Sort();

            // Set the sorted by last name list
            sortedByLastName = SortedStrings;

            // If required, rearrange the names to have last name last again
            if (!displayLastNameFirst)
            {
                rearrangeSortedByFirstName();
            }

            // Restore the original list of names
            UnsortedStrings = orignalNamesList;

            // Return the names sorted by last name as a string array
            return ToStringArray(sortedByLastName);

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method rearranges the list of strings so that for each string
        /// in the list the last word of the string (assuming it's a last name) becomes the first
        /// word in the string for each string. 
        /// </summary>
        private void rearrangeForLastNameFirst() 
        {

            // Reset the arraylist for having last names first
            namesByLastName = new ArrayList();
            
            foreach (string name in UnsortedStrings)
            {
                // Split the string up to get the seperate names
                string[] names = name.Split();

                // Make sure both name and surname exists
                if (names.Length > 1)
                {
                    // If the first element of names is not blank
                    //if (names[0].Length > 0)
                    //{
                        // Create a new string with the last name first
                        string lastNameFirst = names[names.Length - 1];

                        // Make sure there are first names as well
                        if (names.Length > 1)
                        {
                            // Add the first names to the string
                            for (int i = 0; i < names.Length - 1; i++)
                            {
                                lastNameFirst += ' ' + names[i];
                            }
                        }
                        else
                        {
                            // Do nothing

                            // Only the last name has been provided
                        }

                        // Add the rearranged name to the list for sorting
                        namesByLastName.Add(lastNameFirst);
                    //} else
                    //{
                        //Do nothing, we don't want to sort a blank entry
                    //}

                } else
                {
                    // Do nothing

                    // Exclude invalid names from sorting
                }
            }
            
        }

        /// <summary>
        /// Method rearranges the list of sorted names so that for each string
        /// in the list the first word of the string (assuming it's a last name) becomes the last
        /// word in the string for each string. 
        /// </summary>
        private void rearrangeSortedByFirstName()
        {

            // Create the array list for firstname first
            ArrayList namesByFirstName = new ArrayList();

            foreach (string name in sortedByLastName)
            {
                // Split the string up to get the seperate names
                string[] names = name.Split();

                // Make sure there are names
                if (names.Length > 0)
                {
                    // Create a new string for rearranged result
                    string firstNameFirst = "";

                    // Make sure there are first names as well
                    if (names.Length > 1)
                    {
                        // Firstly Add the first names to the string
                        for (int i = 1; i < names.Length; i++)
                        {
                            firstNameFirst += names[i] + ' ';
                        }

                        // Now finally add the last name
                        firstNameFirst += names[0];
                    }
                    else
                    {

                        // Only the last name has been provided
                        firstNameFirst = names[0];
                    }

                    // Add the rearranged name to the list 
                    namesByFirstName.Add(firstNameFirst);

                }
                else
                {
                    //Do nothing

                    // For some reason there was no name
                }
            }

            // Update the sortedByLastName list with the first names first
            sortedByLastName = namesByFirstName;

        }

        #endregion

        #region Private Attributes

        // Contains the list of names with lastname first
        protected ArrayList namesByLastName;

        // The list of sorted names by lastname
        protected ArrayList sortedByLastName;

        // The data source/store
        protected IDataSource dataSource; 

        #endregion

    }
}
