using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShopListAPI.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;
        public CountryController(ICountryService countryService,IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public IActionResult GetAllCountries()
        {
            var result = _countryService.GetAll();
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles ="Admin,User")]
        [HttpGet("{id}")]
        public IActionResult GetCountryById([FromRoute]int id)
        {
            var result = _countryService.GetById(id);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateCountry([FromBody] Country country)
        {
            var result = _countryService.Create(country);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateCountry([FromRoute]int id, [FromBody] CountryDto countryDto)
        {
            var country = _mapper.Map<Country>(countryDto);
            country.Id = id;

            var result = _countryService.Update(country);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry([FromRoute]int id)
        {
            var result = _countryService.Delete(id);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }


    }
}
