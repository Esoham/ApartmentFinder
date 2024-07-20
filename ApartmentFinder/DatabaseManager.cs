using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ApartmentFinder.Models;
using Microsoft.VisualBasic;

namespace ApartmentFinder.Services
{
    public class DatabaseManager
    {
        private string connectionString = Constants.DATABASE_CONNECTION_STRING;

        public void SaveListing(ApartmentListing listing)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Listings (Title, Price, Address) VALUES (@Title, @Price, @Address)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", listing.Title);
                    command.Parameters.AddWithValue("@Price", listing.Price);
                    command.Parameters.AddWithValue("@Address", listing.Address);
                    // Add more parameters as necessary
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ApartmentListing> GetListings()
        {
            var listings = new List<ApartmentListing>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Listings";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var listing = new ApartmentListing
                        {
                            Title = reader["Title"].ToString(),
                            Price = reader["Price"].ToString(),
                            Address = reader["Address"].ToString(),
                            // Add more fields as necessary
                        };
                        listings.Add(listing);
                    }
                }
            }
            return listings;
        }
    }
}