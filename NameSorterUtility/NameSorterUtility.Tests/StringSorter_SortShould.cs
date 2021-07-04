using System;
using SorterLibrary;
using Xunit;

namespace NameSorterUtility.Tests
{
    public class StringSorter_SortShould
    {
        [Theory]
        [InlineData(new string[] { "Nicola Smith", "James Allen" } , new string[] { "James Allen", "Nicola Smith" })]
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
