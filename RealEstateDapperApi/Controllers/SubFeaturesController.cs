using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateDapperApi.Dtos.SubFeatureDtos;
using RealEstateDapperApi.Repositories.SubFeatureRepositories;

namespace RealEstateDapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubFeaturesController : ControllerBase
    {
        private readonly ISubFeatureRepository _subFeatureRepository;

        public SubFeaturesController(ISubFeatureRepository subFeatureRepository)
        {
            _subFeatureRepository = subFeatureRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var value = await _subFeatureRepository.GetAllSubFeaturesAsync();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _subFeatureRepository.GetByIdSubFeatureAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSubFeatureDto createSubFeatureDto)
        {
            _subFeatureRepository.CreateSubFeature(createSubFeatureDto);
            return Ok("Added");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSubFeatureDto updateSubFeatureDto)
        {
            _subFeatureRepository.UpdateSubFeature(updateSubFeatureDto);
            return Ok("Updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _subFeatureRepository.DeleteSubFeature(id);
            return Ok("Deleted");
        }
    }
}
