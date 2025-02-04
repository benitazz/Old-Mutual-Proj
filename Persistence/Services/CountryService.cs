public class CountryService : ICountryService
{
    private readonly ICountryRepository _countryRepository;

    public CountryService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public Task<IEnumerable<Country>> GetAllCountriesAsync()
    {
        return _countryRepository.GetAllCountriesAsync();
    }

    public Task<CountryDetails?> GetCountryDetailsAsync(string name)
    {
        return _countryRepository.GetCountryDetailsAsync(name);
    }
}