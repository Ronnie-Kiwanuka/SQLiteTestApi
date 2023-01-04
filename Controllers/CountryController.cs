using Microsoft.AspNetCore.Mvc;
using SQLiteTestApi.BusinessLogic;
using SQLiteTestApi.Models;
using System;

namespace SQLiteTestApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        CountryInterface countryInterface;

        public CountryController()
        {
            countryInterface = new CountryImpl();
        }


        [HttpGet("all")]
        public ActionResult<CountryResponse> getAllCountries()
        {
            return countryInterface.getCountries();
        }

        [HttpGet("countryByCode")]
        public ActionResult<CountryResponse> getCountryByCode(string countryCode)
        {
            return countryInterface.getCountryByCode(countryCode);
        }

        [HttpPost("addCountry")]
        public ActionResult<ApiResponse> addNewCountry(Country country)
        {
            return countryInterface.saveCountry(country);
        }

        [HttpPost("removeCountry")]
        public ActionResult<ApiResponse> removeNewCountry(string countryCode)
        {
            return countryInterface.removeCountry(countryCode);
        }

        [HttpPost("updateCountry")]
        public ActionResult<ApiResponse> updateCountry(Country country)
        {
            return countryInterface.updateCountryDetails(country);
        }
    }
}
