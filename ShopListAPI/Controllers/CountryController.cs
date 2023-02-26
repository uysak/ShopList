using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ShopListAPI.Controllers
{
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult GetAllCountries()
        {
            var result = _countryService.GetAll();
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            var result = _countryService.GetById(id);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public IActionResult CreateCountry([FromBody] Country country)
        {
            var result = _countryService.Create(country);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public IActionResult UpdateCountry([FromBody] Country country)
        {
            var result = _countryService.Update(country);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCountry([FromRoute]int id)
        {
            var result = _countryService.Delete(id);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }


    }
}
