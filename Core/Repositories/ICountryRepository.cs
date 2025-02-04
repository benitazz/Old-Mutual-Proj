public interface ICountryRepository
{
    Task<IEnumerable<Country>> GetAllCountriesAsync();
    Task<CountryDetails?> GetCountryDetailsAsync(string name);
}