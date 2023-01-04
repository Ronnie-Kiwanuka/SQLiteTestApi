using SQLiteTestApi.Models;

namespace SQLiteTestApi.BusinessLogic
{
    public interface CountryInterface
    {
        public CountryResponse getCountries();
        public CountryResponse getCountryByCode(string countryCode);
        public ApiResponse saveCountry(Country country);
        public ApiResponse removeCountry(string countryCode);
        public ApiResponse updateCountryDetails(Country country);
    }
}
