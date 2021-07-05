using System;
using SorterLibrary;
using Xunit;

namespace NameSorterUtility.Tests
{
    public class NameSorter_SortByLastNameShould
    {
        /// <summary>
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
        public void SortByLastName_SimpleListOfNamesInput_NamesSortedByLastName(string[] unsortedValues, string[] sortedValues)
        {
            // Set up the sorter and pass into it the 
            NameSorter nameSorter = new NameSorter(unsortedValues);

            // Perform the sort
            string[] result = nameSorter.SortByLastName();

            // check the result
            Assert.Equal(sortedValues, result);

        }

        /// <summary>
        /// This test includes a blank string to see if the algorithm will remove the string
        /// </summary>
        /// <param name="unsortedValues">This list of names has one blank string</param>
        /// <param name="sortedValues">This is the exepcted output with the blank string removed</param>
        [Theory]
        [InlineData(new string[] { "Janet Parsons",
                                    "Vaughn Lewis",
                                    "Adonis Julius Archer",
                                    "Shelby Nathan Yoder",
                                    "Marin Alvarez",
                                    "",
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
                                    "Mikayla Lopez",
                                    "Janet Parsons",
                                    "Frankie Conner Ritter",
                                    "Shelby Nathan Yoder" })]
        [InlineData(new string[] { "",
                                    "Vaughn Lewis",
                                    "Adonis Julius Archer",
                                    "Shelby Nathan Yoder",
                                    "Marin Alvarez",
                                    "",
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
                                    "Mikayla Lopez",
                                    "Frankie Conner Ritter",
                                    "Shelby Nathan Yoder" })]
        public void SortByLastName__NamesWithOneZeroLengthString_ZeroLengthStringRemovedFromSortedList(string[] unsortedValues, string[] sortedValues)
        {
            // Set up the sorter and pass into it the 
            NameSorter nameSorter = new NameSorter(unsortedValues);

            // Perform the sort
            string[] result = nameSorter.SortByLastName();

            // check the result
            Assert.Equal(sortedValues, result);
        }
    

        /// <summary>
        /// This test includes some people with the same surname to test whether people with the same surname
        /// will be put together and ordered according to their first names
        /// </summary>
        /// <param name="unsortedValues">This list of names has two people with same surname</param>
        /// <param name="sortedValues">This is the exepcted output</param>
        [Theory]
        [InlineData(new string[] { "Janet Parsons",
                                        "Vaughn Lewis",
                                        "Adonis Julius Archer",
                                        "Shelby Nathan Yoder",
                                        "Marin Alvarez",
                                        "Beau Tristan Bentley",
                                        "Leo Gardner",
                                        "Adonis Bob Archer",
                                        "Hunter Uriah Mathew Clarke",
                                        "Mikayla Lopez",
                                        "Frankie Conner Ritter"},
                    new string[] { "Marin Alvarez",
                                        "Adonis Bob Archer",
                                        "Adonis Julius Archer",
                                        "Beau Tristan Bentley",
                                        "Hunter Uriah Mathew Clarke",
                                        "Leo Gardner",
                                        "Vaughn Lewis",
                                        "Mikayla Lopez",
                                        "Janet Parsons",
                                        "Frankie Conner Ritter",
                                        "Shelby Nathan Yoder" })]
        [InlineData(new string[] { "Vaughn Lewis",
                                        "James Gardner",
                                        "Adonis Julius Archer",
                                        "Shelby Nathan Yoder",
                                        "Marin Alvarez",
                                        "Beau Tristan Bentley",
                                        "Leo Gardner",
                                        "Hunter Uriah Mathew Clarke",
                                        "Mikayla Lopez",
                                        "Frankie Conner Ritter"},
                    new string[] { "Marin Alvarez",
                                        "Adonis Julius Archer",
                                        "Beau Tristan Bentley",
                                        "Hunter Uriah Mathew Clarke",
                                        "James Gardner",
                                        "Leo Gardner",
                                        "Vaughn Lewis",
                                        "Mikayla Lopez",
                                        "Frankie Conner Ritter",
                                        "Shelby Nathan Yoder" })]
        public void SortByLastName__NamesWithSameSurname_SameSurnamesTogetherAndSorted(string[] unsortedValues, string[] sortedValues)
        {
            // Set up the sorter and pass into it the 
            NameSorter nameSorter = new NameSorter(unsortedValues);

            // Perform the sort
            string[] result = nameSorter.SortByLastName();

            // check the result
            Assert.Equal(sortedValues, result);
        }

        /// <summary>
        /// This test includes some people with only their names and no surname. These names should be removed altogether
        /// </summary>
        /// <param name="unsortedValues">This list of names has people with only a firstname and no surname</param>
        /// <param name="sortedValues">This is the exepcted output. Names with no surname removed</param>
        [Theory]
        [InlineData(new string[] { "Janet Parsons",
                                        "Vaughn Lewis",
                                        "Adonis Julius Archer",
                                        "Shelby Nathan Yoder",
                                        "Marin",
                                        "Beau Tristan Bentley",
                                        "Leo Gardner",
                                        "Adonis Bob Archer",
                                        "Hunter Uriah Mathew Clarke",
                                        "Mikayla Lopez",
                                        "Frankie Conner Ritter"},
                    new string[] { "Adonis Bob Archer",
                                        "Adonis Julius Archer",
                                        "Beau Tristan Bentley",
                                        "Hunter Uriah Mathew Clarke",
                                        "Leo Gardner",
                                        "Vaughn Lewis",
                                        "Mikayla Lopez",
                                        "Janet Parsons",
                                        "Frankie Conner Ritter",
                                        "Shelby Nathan Yoder" })]
        [InlineData(new string[] { "Vaughn Lewis",
                                        "James Gardner",
                                        "Adonis Julius Archer",
                                        "Shelby Nathan Yoder",
                                        "Marin Alvarez",
                                        "Beau Tristan Bentley",
                                        "Leo Gardner",
                                        "Hunter",
                                        "Mikayla Lopez",
                                        "Frankie Conner Ritter"},
                    new string[] { "Marin Alvarez",
                                        "Adonis Julius Archer",
                                        "Beau Tristan Bentley",
                                        "James Gardner",
                                        "Leo Gardner",
                                        "Vaughn Lewis",
                                        "Mikayla Lopez",
                                        "Frankie Conner Ritter",
                                        "Shelby Nathan Yoder" })]
        public void SortByLastName__NamesWithNoSurname_NamesSortedAndNamesWithNoSurnamesRemoved(string[] unsortedValues, string[] sortedValues)
        {
            // Set up the sorter and pass into it the 
            NameSorter nameSorter = new NameSorter(unsortedValues);

            // Perform the sort
            string[] result = nameSorter.SortByLastName();

            // check the result
            Assert.Equal(sortedValues, result);
        }

        

    }
}
