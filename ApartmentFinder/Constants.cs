namespace ApartmentFinder
{
    public static class Constants
    {
        public const string WELCOME_MESSAGE = "Welcome to Apartment Finder!";
        public const string GOODBYE_MESSAGE = "Thank you for using Apartment Finder!";
        public static string DATABASE_CONNECTION_STRING =>
            System.Environment.GetEnvironmentVariable("APARTMENTFINDER_DB_CONNECTION_STRING")
            ?? throw new System.InvalidOperationException(
                "Set APARTMENTFINDER_DB_CONNECTION_STRING in your local environment before using database features.");
        public const string INVALID_COMMAND_MESSAGE = "Invalid command. Please try again.";
        public const string LISTING_ADDED_MESSAGE = "Listing added successfully.";
        public const string INVALID_INPUT_MESSAGE = "Invalid input. Please try again.";

        // Add more constants as needed
    }
}