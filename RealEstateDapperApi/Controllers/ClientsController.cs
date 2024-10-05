using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.ClientDtos;
using RealEstateDapperApi.Repositories.ClientRepositories;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _clientRepository.GetAllClientAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            var value = await _clientRepository.GetByIdClientAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateClientDto createClientDto)
        {
            _clientRepository.CreateClient(createClientDto);
            return Ok("Added");
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateClientDto updateClientDto)
        {
            _clientRepository.UpdateClient(updateClientDto);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            _clientRepository.DeleteClient(id);
            return Ok("Deleted");
        }
    }
}
