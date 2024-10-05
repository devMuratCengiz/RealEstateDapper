using RealEstateDapperApi.Dtos.SubFeatureDtos;

namespace RealEstateDapperApi.Repositories.SubFeatureRepositories
{
    public interface ISubFeatureRepository
    {
        Task<List<ResultSubFeatureDto>> GetAllSubFeaturesAsync();
        void CreateSubFeature(CreateSubFeatureDto createSubFeatureDto);
        void DeleteSubFeature(int id);
        void UpdateSubFeature(UpdateSubFeatureDto updateSubFeatureDto);
        Task<GetByIdSubFeatureDto> GetByIdSubFeatureAsync(int id);
    }
}
