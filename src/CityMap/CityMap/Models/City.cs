namespace CityMap.Models
{
    public class City
    {
        public string Name { get; set; }

        public Country Country { get; set; }

        public string Description => $"{Name} is a beautiful city that is located in {Country.Name} country.More information will be available in the future versions of program.Stay tuned!";
    }
}
