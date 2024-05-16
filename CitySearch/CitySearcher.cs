using static System.Formats.Asn1.AsnWriter;

namespace CitySearch
{
    public class CitySearcher
    {
        private List<string> _cityList;

        public CitySearcher(string listOfCities)
        {
            _cityList = listOfCities
                .Split(",")
                .Select(cityString => cityString.Trim())
                .ToList();
        }

        public string Search(string input)
        {
            if (!ValidateInput(input))
            {
                return "";
            }

            if (input.Equals("*"))
            {
                return _cityList.Aggregate((cityCurr, cityNext) => string.Format("{0}, {1}", cityCurr, cityNext));
            }

            return _cityList
                .Where(city => city.ToLower().Contains(input.ToLower()))
                .Aggregate((cityCurr, cityNext) => string.Format("{0}, {1}", cityCurr, cityNext));
        }

        private bool ValidateInput(string input)
        {
            return input.Length > 1 || input.Equals("*");
        }
    }
}
