using System;
using ApartmentFinder.Services;
using ApartmentFinder.UI;
using ApartmentFinder.Models;
using Microsoft.VisualBasic;

namespace ApartmentFinder
{
    class Program
    {
        private static WebScraper webScraper = new WebScraper();
        private static DatabaseManager dbManager = new DatabaseManager();
        private static UserInterface userInterface = new UserInterface();

        static void Main(string[] args)
        {
            Console.WriteLine(Constants.WELCOME_MESSAGE);

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Scrape Listings");
                Console.WriteLine("2. View Listings");
                Console.WriteLine("3. Generate Price Optimization Tips");
                Console.WriteLine("4. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ScrapeListings();
                        break;
                    case "2":
                        ViewListings();
                        break;
                    case "3":
                        GeneratePriceOptimizationTips();
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine(Constants.GOODBYE_MESSAGE);
                        break;
                    default:
                        Console.WriteLine(Constants.INVALID_COMMAND_MESSAGE);
                        break;
                }
            }
        }

        private static void ScrapeListings()
        {
            Console.WriteLine("Enter the URL to scrape listings from:");
            string url = Console.ReadLine();

            var listings = webScraper.ScrapeListings(url);
            foreach (var listing in listings)
            {
                dbManager.SaveListing(listing);
            }

            Console.WriteLine($"Scraped and saved {listings.Count} listings.");
        }

        private static void ViewListings()
        {
            var listings = dbManager.GetListings();
            userInterface.DisplayListings(listings);
        }

        public static void GeneratePriceOptimizationTips()
        {
            // Assuming this method generates and displays tips
            Console.WriteLine("Generating price optimization tips...");

            // Placeholder for generating tips
            Console.WriteLine("Tip: Negotiate for a lower price by comparing nearby listings.");

            // Additional tips logic can be implemented here
        }
    }
}