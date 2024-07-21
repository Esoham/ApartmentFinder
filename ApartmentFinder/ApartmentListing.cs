namespace ApartmentFinder.Models
{
    public class ApartmentListing
    {
        public string Title { get; set; } = string.Empty;
        public string? Price { get; set; }
        public string Address { get; set; } = string.Empty;

        // Add more fields as necessary
    }
}