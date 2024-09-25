using Dapper;
using RealEstateDapperApi.Dtos.CategoryDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto createCategoryDto)
        {
            string query = "insert into Category (Name,Status) values (@name,@status)";
            var parameter = new DynamicParameters();
            parameter.Add("@name", createCategoryDto.Name);
            parameter.Add("@status", true);
            using (var connection = _context.CreateConnection()) { 
            await connection.ExecuteAsync(query, parameter);
            }


        }

        public async void DeleteCategory(int id)
        {
            string query = "Delete from Category Where Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Category";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id)
        {
            string query = "Select * from Category Where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
                return value;
            }
        }

        public async void UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            string query = "Update Category Set Name=@name, Status=@status where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@name", updateCategoryDto.Name);
            parameters.Add("@status", updateCategoryDto.Status);
            parameters.Add("@id", updateCategoryDto.Id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
