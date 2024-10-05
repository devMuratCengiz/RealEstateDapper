using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.WhoWeAreDtos;
using RealEstateDapperApi.Repositories.WhoWeAreRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreController : ControllerBase
    {
        private readonly IWhoWeAreRepository _whoWeAreRepository;

        public WhoWeAreController(IWhoWeAreRepository whoWeAreRepository)
        {
            _whoWeAreRepository = whoWeAreRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _whoWeAreRepository.GetAllWhoWeAreAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateWhoWeAreDto createWhoWeAreDto) 
        {
            _whoWeAreRepository.CreateWhoWeAre(createWhoWeAreDto);
            return Ok("added");   
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _whoWeAreRepository.DeleteWhoWeAre(id);
            return Ok("deleted");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateWhoWeAreDto updateWhoWeAreDto)
        {
            _whoWeAreRepository.UpdateWhoWeAre(updateWhoWeAreDto);
            return Ok("updated");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(int id)
        {
            var value = await _whoWeAreRepository.GetByIdWhoWeAreAsync(id);
            return Ok(value);
        }

    }
}
