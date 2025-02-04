public interface ICountryService
{
    Task<IEnumerable<Country>> GetAllCountriesAsync();
    Task<CountryDetails?> GetCountryDetailsAsync(string name);
}