using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using Xunit;

public class CountriesControllerTests
{
    private readonly Mock<ICountryService> _mockCountryService;

    private readonly CountriesController _controller;

    public CountriesControllerTests()
    {
        _mockCountryService = new Mock<ICountryService>();

        var map = new MapperConfiguration(cfg =>
             {
                 cfg.AddProfile(new EntityToDtoMapping());
             });

        var mapper = map.CreateMapper();

        _controller = new CountriesController(_mockCountryService.Object, mapper);
    }

    [Fact]
    public async Task GetAllCountries_ReturnsOkResult_WithListOfCountries()
    {
        // Arrange
        var countries = new List<Country>
            {
                new Country { name = new Name { common = "South Africa" }, flags = new Flags { png = "https://flagcdn.com/w320/za.png" } },
                new Country { name = new Name { common = "Germany" }, flags = new Flags { png = "https://flagcdn.com/w320/de.png" } }
            };

        _mockCountryService.Setup(service => service.GetAllCountriesAsync()).ReturnsAsync(countries);

        // Act
        var result = await _controller.GetAllCountries();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);

        var returnedCountries = Assert.IsType<List<CountryDto>>(okResult.Value);

        Assert.Equal(2, returnedCountries.Count);

        Assert.Equal("South Africa", returnedCountries[0].Name);
        Assert.Equal("https://flagcdn.com/w320/za.png", returnedCountries[0].Flag);
        Assert.Equal("Germany", returnedCountries[1].Name);
        Assert.Equal("https://flagcdn.com/w320/de.png", returnedCountries[1].Flag);
    }

    [Fact]
    public async Task GetCountryDetails_ExistingCountry_ReturnsOkResult()
    {
        // Arrange
        var country = new CountryDetails { name = new Name { common = "South Africa" }, flags = new Flags { png = "https://flagcdn.com/w320/za.png" }, population = 59308690, capital = new List<string> { "Pretoria" } };
        _mockCountryService.Setup(service => service.GetCountryDetailsAsync("South Africa")).ReturnsAsync(country);

        // Act
        var result = await _controller.GetCountryDetails("South Africa");

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
        var returnValue = Assert.IsAssignableFrom<CountryDetailsDto>(okResult.Value);
        Assert.NotNull(returnValue);

        string json = JsonConvert.SerializeObject(returnValue);

        var countryDetails = JsonConvert.DeserializeObject<CountryDetailsDto>(json);

        Assert.NotNull(countryDetails);
        Assert.Equal("South Africa", countryDetails.Name);
        Assert.Equal("https://flagcdn.com/w320/za.png", countryDetails.Flag);
        Assert.Equal(59308690, countryDetails.Population);
        Assert.Contains("Pretoria", countryDetails.Capital);
    }

    [Fact]
    public async Task GetCountryDetails_NonExistingCountry_ReturnsNotFound()
    {
        // Arrange
        _mockCountryService.Setup(service => service.GetCountryDetailsAsync("UnknownCountry")).ReturnsAsync((CountryDetails?)null);

        // Act
        var result = await _controller.GetCountryDetails("UnknownCountry");

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}
