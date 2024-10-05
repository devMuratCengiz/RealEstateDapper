using RealEstateDapperApi.Dtos.ClientDtos;

namespace RealEstateDapperApi.Repositories.ClientRepositories
{
    public interface IClientRepository
    {
        Task<List<ResultClientDto>> GetAllClientAsync();
        void CreateClient(CreateClientDto createClientDto);
        void DeleteClient(int id);
        void UpdateClient(UpdateClientDto updateClientDto);
        Task<GetByIdClientDto> GetByIdClientAsync(int id);

    }
}
