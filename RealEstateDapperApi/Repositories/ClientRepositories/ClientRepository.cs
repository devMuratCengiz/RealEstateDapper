using Dapper;
using RealEstateDapperApi.Dtos.ClientDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.ClientRepositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly Context _context;

        public ClientRepository(Context context)
        {
            _context = context;
        }

        public async void CreateClient(CreateClientDto createClientDto)
        {
 ;           string query = "insert into Client (Name,Title,Comment,Status) values (@name,@title,@comment,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("name", createClientDto.Name);
            parameters.Add("title", createClientDto.Title);
            parameters.Add("comment", createClientDto.Comment);
            parameters.Add("status", createClientDto.Status);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteClient(int id)
        {
            string query = "Delete from Client Where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultClientDto>> GetAllClientAsync()
        {
            string query = "Select * from Client";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultClientDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdClientDto> GetByIdClientAsync(int id)
        {
            string query = "Select * from Client Where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdClientDto>(query,parameters);
                return value;
            }
        }

        public async void UpdateClient(UpdateClientDto updateClientDto)
        {
            string query = "Update Client set Name=@name,Title=@title,Comment=@comment,Status=@status where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", updateClientDto.Id);
            parameters.Add("name", updateClientDto.Name);
            parameters.Add("title", updateClientDto.Title);
            parameters.Add("comment", updateClientDto.Comment);
            parameters.Add("status", updateClientDto.Status);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
