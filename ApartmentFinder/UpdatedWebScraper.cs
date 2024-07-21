using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApartmentFinder.Models;
using HtmlAgilityPack;

namespace ApartmentFinder.Services
{
    public class WebScraper
    {
        public async Task<List<ApartmentListing>> ScrapeListingsAsync(string url)
        {
            var listings = new List<ApartmentListing>();
            try
            {
                var web = new HtmlWeb();
                var doc = await Task.Run(() => web.Load(url));

                // Example scraping logic (this needs to be tailored to the actual structure of the website)
                var listingNodes = doc.DocumentNode.SelectNodes("//div[@class='listing']");
                if (listingNodes == null) return listings; // Ensure listingNodes is not null

                foreach (var node in listingNodes)
                {
                    var titleNode = node.SelectSingleNode(".//h2");
                    var priceNode = node.SelectSingleNode(".//span[@class='price']");
                    var addressNode = node.SelectSingleNode(".//span[@class='address']");

                    var title = titleNode?.InnerText;
                    var price = priceNode?.InnerText;
                    var address = addressNode?.InnerText;

                    if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(price) && !string.IsNullOrEmpty(address))
                    {
                        var listing = new ApartmentListing
                        {
                            Title = title,
                            Price = price,
                            Address = address,
                            // Add more fields as necessary
                        };
                        listings.Add(listing);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error scraping data from {url}: {ex.Message}");
            }

            return listings;
        }
    }
}