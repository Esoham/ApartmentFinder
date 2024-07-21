using System;

namespace ApartmentFinder.UI
{
    public class UserInterface
    {
        public void DisplayMenu()
        {
            Console.WriteLine("DisplayMenu called.");
            // Implementation of the method
            Console.WriteLine("Welcome to the Apartment Finder!");
            Console.WriteLine("1. Search for apartments");
            Console.WriteLine("2. Exit");
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine("DisplayMessage called with message: " + message);

            if (string.IsNullOrEmpty(message))
            {
                Console.WriteLine("No message to display.");
            }
            else
            {
                Console.WriteLine(message);
            }
        }
    }
}