using Dapper;
using RealEstateDapperApi.Dtos.EmployeeDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async void CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            string query = "insert into Employee (Name,Title,Mail,PhoneNumber,ImageUrl,Status) values (@name,@title,@mail,@phoneNumber,@imageUrl,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("name", createEmployeeDto.Name);
            parameters.Add("title", createEmployeeDto.Title);
            parameters.Add("phoneNumber", createEmployeeDto.PhoneNumber);
            parameters.Add("imageUrl", createEmployeeDto.ImageUrl);
            parameters.Add("mail", createEmployeeDto.Mail);
            parameters.Add("status", createEmployeeDto.Status);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteEmployee(int id)
        {
            string query = "Delete from Employee where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "Select * from Employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdEmployeeDto> GetByIdEmployeeAsync(int id)
        {
            string query = "Select * from Employee where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(query,parameters);
                return value;
            }
        }

        public async void UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            string query = "Update Employee set Name=@name ,Title=@title, PhoneNumber=@phoneNumber , Mail=@mail ,ImageUrl=@imageUrl, Status=@status where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("name", updateEmployeeDto.Name);
            parameters.Add("title", updateEmployeeDto.Title);
            parameters.Add("phoneNumber", updateEmployeeDto.PhoneNumber);
            parameters.Add("mail", updateEmployeeDto.Mail);
            parameters.Add("status", updateEmployeeDto.Status);
            parameters.Add("imageUrl", updateEmployeeDto.ImageUrl);
            parameters.Add("id", updateEmployeeDto.Id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
