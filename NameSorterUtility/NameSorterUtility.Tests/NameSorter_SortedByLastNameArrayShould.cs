using System;
using SorterLibrary;
using Xunit;

namespace NameSorterUtility.Tests
{
    public class NameSorter_SortedByLastNameArrayShould
    {

        /// <summary>
        /// This test checks whether access the properties for sorting works correctly
        /// This test uses the list of names provided in the assessment brief and checks for correct sorting
        /// </summary>
        /// <param name="unsortedValues">The unsorted list of names from brief</param>
        /// <param name="sortedValues">The sorted list of names from brief</param>
        [Theory]
        [InlineData(new string[] { "Janet Parsons",
                                    "Vaughn Lewis",
                                    "Adonis Julius Archer",
                                    "Shelby Nathan Yoder",
                                    "Marin Alvarez",
                                    "London Lindsey",
                                    "Beau Tristan Bentley",
                                    "Leo Gardner",
                                    "Hunter Uriah Mathew Clarke",
                                    "Mikayla Lopez",
                                    "Frankie Conner Ritter"},
                    new string[] { "Marin Alvarez",
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
        public void SortedByLastNameArray_SimpleListOfNamesInputViaProperties_NamesSortedByLastName(string[] unsortedValues, string[] sortedValues)
        {
            // Set up the sorter and pass into it the 
            NameSorter nameSorter = new NameSorter();

            // Set the unsorted names via the UnsortedNamesArray property
            nameSorter.UnsortedNamesArray = unsortedValues;

            // Perform the sort via the 
            string[] result = nameSorter.SortedByLastNameArray;

            // check the result
            Assert.Equal(sortedValues, result);

        }

    }
}
