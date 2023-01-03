using SQLiteTestApi.Models;
using System.Diagnostics.Metrics;

namespace SQLiteTestApi.BusinessLogic
{
    public class CountryImpl : CountryInterface
    {
        CountryContext db = new CountryContext();

        public CountryResponse getCountries()
        {
            CountryResponse response= new CountryResponse();
            List<Country> countries = new List<Country>();
            try
            {
                countries = db.Countries.ToList();
                response.statusCode = StatusCodes.Status200OK.ToString();
                response.statusMessage = "SUCCESS";
                response.statusDescription = "SUCCESS";
                response.countries= countries;
            }
            catch(Exception ex)
            {
                response.statusCode = StatusCodes.Status400BadRequest.ToString();
                response.statusMessage = "FAILED";
                response.statusDescription = ex.Message;
            }
            return response;
        }

        public CountryResponse getCountryByCode(string countryCode)
        {
            CountryResponse response = new CountryResponse(); 
            List<Country> countries = new List<Country>();
            try
            {
                Country? cc = db.Countries
                                .FirstOrDefault(b => b.countryCode == countryCode);
                if(cc != null)
                {
                    countries.Add(cc);
                    response.statusCode = StatusCodes.Status200OK.ToString();
                    response.statusMessage = "SUCCESS";
                    response.statusDescription = "SUCCESS";
                    response.countries = countries;
                }
                else
                {
                    response.statusCode = StatusCodes.Status404NotFound.ToString();
                    response.statusMessage = "FAILED";
                    response.statusDescription = "COUNTRY WITH CODE "+ countryCode+" NOT FOUND";
                }
            }
            catch (Exception ex)
            {
                response.statusCode = StatusCodes.Status400BadRequest.ToString();
                response.statusMessage = "FAILED";
                response.statusDescription = ex.Message;
            }
            return response;
        }

        public ApiResponse saveCountry(Country country)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                Country? cc = db.Countries
                                .FirstOrDefault(b => b.countryCode == country.countryCode);
                
                if (cc != null)
                {
                    response.statusCode = StatusCodes.Status400BadRequest.ToString();
                    response.statusMessage = "FAILED";
                    response.statusDescription = "COUNTRY WITH CODE " + country.countryCode + " ALREADY EXISTS";
                    return response;
                }
                cc = db.Countries
                                .FirstOrDefault(b => b.countryName == country.countryName);
                if (cc != null)
                {
                    response.statusCode = StatusCodes.Status400BadRequest.ToString();
                    response.statusMessage = "FAILED";
                    response.statusDescription = "COUNTRY WITH NAME " + country.countryName + " ALREADY EXISTS";
                    return response;
                }
                else
                {
                    db.Add(country);
                    db.SaveChanges();
                    response.statusCode = StatusCodes.Status200OK.ToString();
                    response.statusMessage = "SUCCESS";
                    response.statusDescription = "A COUNTRY HAS BEEN SUCCESSFULLY ADDED";
                }
            }
            catch (Exception ex)
            {
                response.statusCode = StatusCodes.Status400BadRequest.ToString();
                response.statusMessage = "FAILED";
                response.statusDescription = ex.Message;
            }
            return response;
        }

        public ApiResponse removeCountry(Country country)
        {
            ApiResponse response = new ApiResponse();
            try
            {
                Country? cc = db.Countries
                                .FirstOrDefault(b => b.countryCode == country.countryCode);

                if (cc != null)
                {
                    db.Remove(cc);
                    db.SaveChanges();
                    response.statusCode = StatusCodes.Status200OK.ToString();
                    response.statusMessage = "SUCCESS";
                    response.statusDescription = "THE COUNTRY HAS BEEN REMOVED SUCCESSFULLY";
                    return response;
                }
                cc = db.Countries
                                .FirstOrDefault(b => b.countryName == country.countryName);
                if (cc != null)
                {
                    db.Remove(cc);
                    db.SaveChanges();
                    response.statusCode = StatusCodes.Status200OK.ToString();
                    response.statusMessage = "SUCCESS";
                    response.statusDescription = "THE COUNTRY HAS BEEN REMOVED SUCCESSFULLY";
                    return response;    
                }
                else
                {
                    db.Add(country);
                    db.SaveChanges();
                    response.statusCode = StatusCodes.Status404NotFound.ToString();
                    response.statusMessage = "SUCCESS";
                    response.statusDescription = "THE COUNTRY DOESN'T EXIST";
                }
            }
            catch (Exception ex)
            {
                response.statusCode = StatusCodes.Status400BadRequest.ToString();
                response.statusMessage = "FAILED";
                response.statusDescription = ex.Message;
            }
            return response;
        }
    }
}
