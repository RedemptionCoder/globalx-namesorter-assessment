using System;
using SorterLibrary;
using Xunit;

namespace NameSorterUtility.Tests
{
    public class StringSorter_SortShould
    {
        [Theory]
        [InlineData(new string[] { "Nicola Smith", "James Allen" } , new string[] { "James Allen", "Nicola Smith" })]
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
                    new string[] { "Adonis Julius Archer",
                                    "Beau Tristan Bentley",
                                    "Frankie Conner Ritter",
                                    "Hunter Uriah Mathew Clarke",
                                    "Janet Parsons",
                                    "Leo Gardner",
                                    "London Lindsey",
                                    "Marin Alvarez",
                                    "Mikayla Lopez",
                                    "Shelby Nathan Yoder",
                                    "Vaughn Lewis" })]
        public void Sort_SimpleListOfNamesInput_NamesSorted(string[] unsortedValues, string[] sortedValues)
        {
            // Set up the sorter and pass into it the 
            StringSorter nameSorter = new StringSorter(unsortedValues);

            // Perform the sort
            string[] result = nameSorter.Sort();

            // check the result
            Assert.Equal(sortedValues, result);

        }
    }
}
