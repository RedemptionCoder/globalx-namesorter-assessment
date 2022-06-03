using System;
using SorterLibrary;

namespace NameSorterUtility
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create the app controller
            NameSorterUtilityControl controller = new NameSorterUtilityControl(args);

            // Some test git

            // Run the controller
            controller.Run();

            // End the app
            return;

        }
    }
}
