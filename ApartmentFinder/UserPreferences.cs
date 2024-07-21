namespace ApartmentFinder.Models
{
    public class UserPreferences
    {
        public string PreferredLocation { get; set; }

        public UserPreferences()
        {
            PreferredLocation = string.Empty; // or any default value you prefer
        }
    }
}