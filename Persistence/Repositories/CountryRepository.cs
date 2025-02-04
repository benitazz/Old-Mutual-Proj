using System.Text.Json;

public class CountryRepository : ICountryRepository
{
    private readonly HttpClient _httpClient;

    private const string CountryBaseUrl = "https://restcountries.com/v3.1";

    public CountryRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Country>> GetAllCountriesAsync()
    {
        var response = await _httpClient.GetStringAsync($"{CountryBaseUrl}/all");
        var countries = JsonSerializer.Deserialize<IEnumerable<Country>>(response) ?? [];
        return countries;
    }

    public async Task<CountryDetails?> GetCountryDetailsAsync(string name)
    {
        try
        {
            var response = await _httpClient.GetStringAsync($"{CountryBaseUrl}/name/{name}");
            var countries = JsonSerializer.Deserialize<List<CountryDetails>>(response);
            return countries?.Count > 0 ? countries[0] : null;
        }
        catch (HttpRequestException ex)
        {
            if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            throw;
        }
    }
}