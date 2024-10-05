using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.BottomGridDtos;
using RealEstateDapperApi.Repositories.BottonGridRepositories;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BottomGridsController : ControllerBase
    {
        private readonly IBottomGridRepository _bottonGridRepository;

        public BottomGridsController(IBottomGridRepository bottonGridRepository)
        {
            _bottonGridRepository = bottonGridRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _bottonGridRepository.GetAllBottomGridAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var value = await _bottonGridRepository.GetByIdBottomGridAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateBottomGridDto createBottomGridDto)
        {
            _bottonGridRepository.CreateBottomGrid(createBottomGridDto);
            return Ok("Added");
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateBottomGridDto updateBottomGridDto)
        {
            _bottonGridRepository.UpdateBottomGrid(updateBottomGridDto);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            _bottonGridRepository.DeleteBottomGrid(id);
            return Ok("Deleted");

        }
    }
}
