using System;
using System.Collections.Generic;
using ApartmentFinder.Models;

namespace ApartmentFinder.UI
{
    public class UserInterface
    {
        public void DisplayListings(List<ApartmentListing> listings)
        {
            foreach (var listing in listings)
            {
                Console.WriteLine($"Title: {listing.Title}");
                Console.WriteLine($"Price: {listing.Price}");
                Console.WriteLine($"Address: {listing.Address}");
                Console.WriteLine(new string('-', 20));
            }
        }
    }
}