using System;
using System.Collections.Generic;
using ApartmentFinder.Models;

namespace ApartmentFinder.Services
{
    public class PriceOptimizationService
    {
        public List<string> GeneratePriceOptimizationTips(List<ApartmentListing> listings)
        {
            var tips = new List<string>();

            if (listings == null || listings.Count == 0)
            {
                tips.Add("No listings available to analyze.");
                return tips;
            }

            double averagePrice = 0;
            int count = 0;
            foreach (var listing in listings)
            {
                if (double.TryParse(listing?.Price?.Replace("$", "").Replace(",", ""), out double price))
                {
                    averagePrice += price;
                    count++;
                }
            }

            if (count > 0)
            {
                averagePrice /= count;
                tips.Add($"The average price of the listings is ${averagePrice:F2}.");
            }

            return tips;
        }

        public void OptimizePrices(List<ApartmentListing> apartmentListings)
        {
            Console.WriteLine("Optimizing prices for the apartment listings...");

            foreach (var listing in apartmentListings)
            {
                if (double.TryParse(listing?.Price?.Replace("$", "").Replace(",", ""), out double price) && price > 1000)
                {
                    listing.Price = $"${(price * 0.9):F2}";
                }
            }

            Console.WriteLine("Prices optimized successfully.");
        }
    }
}