using Dapper;
using RealEstateDapperApi.Dtos.WhoWeAreDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.WhoWeAreRepository
{
    public class WhoWeAreRepository : IWhoWeAreRepository
    {
        private readonly Context _context;

        public WhoWeAreRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoWeAre(CreateWhoWeAreDto createWhoWeAreDto)
        {
            string query = "insert into WhoWeAre (Title,Subtitle,Description1,Description2) values (@title,@subtitle,@description1,@description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createWhoWeAreDto.Title);
            parameters.Add("@subtitle", createWhoWeAreDto.Subtitle);
            parameters.Add("@description1", createWhoWeAreDto.Description1);
            parameters.Add("@description2", createWhoWeAreDto.Description2);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoWeAre(int id)
        {
            string query = "Delete from WhoWeAre Where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDto>> GetAllWhoWeAreAsync()
        {
            string query = "Select * from WhoWeAre";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdWhoWeAreDto> GetByIdWhoWeAreAsync(int id)
        {
            string query = "Select * from WhoWeAre Where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDto> (query,parameters);
                return value;
            }
        }

        public async void UpdateWhoWeAre(UpdateWhoWeAreDto updateWhoWeAreDto)
        {
            string query = "Update WhoWeAre Set Title=@title, Subtitle=@subtitle,Description1=@description1,Description2=@description2 where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updateWhoWeAreDto.Title);
            parameters.Add("@subtitle", updateWhoWeAreDto.Subtitle);
            parameters.Add("@description1", updateWhoWeAreDto.Description1);
            parameters.Add("@description2", updateWhoWeAreDto.Description2);
            parameters.Add("@id", updateWhoWeAreDto.Id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
