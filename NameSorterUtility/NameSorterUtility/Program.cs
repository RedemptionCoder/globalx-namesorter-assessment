using System;
using SorterLibrary;

namespace NameSorterUtility
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] names = { "Peter Gibbons", "Elize Gibbons", "Cindy Gibbons", "Anthony Gibbons" };

            StringSorter stringToSort = new StringSorter(names);

            stringToSort.Sort();

            

            foreach (string text in stringToSort.Strings)
            {

                Console.WriteLine(text);
            }
        }
    }
}
