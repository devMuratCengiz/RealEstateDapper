using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.ServiceDtos;
using RealEstateDapperApi.Repositories.ServiceRepository;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var value = await _serviceRepository.GetAllServiceAsync();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _serviceRepository.GetByIdServiceAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceDto createServiceDto)
        {
             _serviceRepository.CreateService(createServiceDto);
            return Ok("Added");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _serviceRepository.DeleteService(id);
            return Ok("Deleted");
        }
        [HttpPut]
        public async Task<IActionResult>Update(UpdateServiceDto updateServiceDto)
        {
            _serviceRepository.UpdateService(updateServiceDto);
            return Ok("Updated");
        }
    }
}
