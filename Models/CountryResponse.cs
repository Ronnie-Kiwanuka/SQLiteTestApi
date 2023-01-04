namespace SQLiteTestApi.Models
{
    public class CountryResponse : ApiResponse
    {
        public List<Country>? countries { get; set; }
    }
}
