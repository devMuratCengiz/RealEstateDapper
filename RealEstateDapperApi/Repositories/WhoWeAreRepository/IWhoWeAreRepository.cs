using RealEstateDapperApi.Dtos.CategoryDtos;
using RealEstateDapperApi.Dtos.WhoWeAreDtos;

namespace RealEstateDapperApi.Repositories.WhoWeAreRepository
{
    public interface IWhoWeAreRepository
    {
        Task<List<ResultWhoWeAreDto>> GetAllWhoWeAreAsync();
        void CreateWhoWeAre(CreateWhoWeAreDto createWhoWeAreDto);
        void DeleteWhoWeAre(int id);
        void UpdateWhoWeAre(UpdateWhoWeAreDto updateWhoWeAreDto);
        Task<GetByIdWhoWeAreDto> GetByIdWhoWeAreAsync(int id);
    }
}
