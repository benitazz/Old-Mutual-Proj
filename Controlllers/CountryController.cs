using System.Dynamic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/countries")]
public class CountriesController : ControllerBase
{
    private readonly ICountryService _countryService;
    private readonly IMapper _mapper;

    public CountriesController(ICountryService countryService, IMapper mapper)
    {
        _countryService = countryService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCountries()
    {
        try
        {
            var countries = await _countryService.GetAllCountriesAsync();

            var countryDtos = this._mapper.Map<List<CountryDto>>(countries);

            return Ok(countryDtos);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetCountryDetails(string name)
    {
        try
        {
            var countryDetail = await _countryService.GetCountryDetailsAsync(name);
            if (countryDetail == null)
                return NotFound();

            var countryDetailsDto = this._mapper.Map<CountryDetailsDto>(countryDetail);

            return Ok(countryDetailsDto);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}