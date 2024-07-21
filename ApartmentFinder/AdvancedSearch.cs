using System.Collections.Generic;
using ApartmentFinder.Models;

namespace ApartmentFinder.Services
{
    public class AdvancedSearch
    {
        public List<ApartmentListing> SearchByCriteria(string location, decimal maxPrice, int bedrooms, int bathrooms)
        {
            // Implementation of the method returning dummy data
            return new List<ApartmentListing>
            {
                new ApartmentListing { Address = "123 Main St", Price = "$1200" },
                new ApartmentListing { Address = "456 Elm St", Price = "$800" },
                new ApartmentListing { Address = "789 Oak St", Price = "$1500" }
            };
        }
    }
}