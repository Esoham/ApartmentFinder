namespace ApartmentFinder.Models
{
    public class User
    {
        public string Username { get; set; }
        public UserPreferences Preferences { get; set; }

        public User()
        {
            Username = string.Empty; // Initialize with a default value
            Preferences = new UserPreferences(); // Initialize with a default value
        }
    }
}