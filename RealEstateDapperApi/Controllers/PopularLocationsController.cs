using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.PopularLocationDtos;
using RealEstateDapperApi.Repositories.PopularLocationRepositories;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationRepository _locationRepository;

        public PopularLocationsController(IPopularLocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var value = await _locationRepository.GetAllPopularLocationsAsync();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var value = await _locationRepository.GetByIdPopularLocationAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreatePopularLocationDto createPopularLocationDto)
        {
            _locationRepository.CreatePopularLocation(createPopularLocationDto);
            return Ok("Added");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdatePopularLocationDto updatePopularLocationDto)
        {
            _locationRepository.UpdatePopularLocation(updatePopularLocationDto);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            _locationRepository.DeletePopularLocation(id);
            return Ok("Deleted");
        }
    }
}
