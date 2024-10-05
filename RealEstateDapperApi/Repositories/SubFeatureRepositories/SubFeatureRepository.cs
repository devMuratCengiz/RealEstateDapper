using Dapper;
using RealEstateDapperApi.Dtos.SubFeatureDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.SubFeatureRepositories
{
    public class SubFeatureRepository : ISubFeatureRepository
    {
        private readonly Context _context;

        public SubFeatureRepository(Context context)
        {
            _context = context;
        }

        public async void CreateSubFeature(CreateSubFeatureDto createSubFeatureDto)
        {
            string query = "insert into SubFeature (Icon,TopTitle,MainTitle,Description) values (@icon,@topTitle,@mainTitle,@description)";
            var parameters = new DynamicParameters();
            parameters.Add("icon", createSubFeatureDto.Icon);
            parameters.Add("topTitle", createSubFeatureDto.TopTitle);
            parameters.Add("mainTitle", createSubFeatureDto.MainTitle);
            parameters.Add("description", createSubFeatureDto.Description);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteSubFeature(int id)
        {
            string query = "Delete from SubFeature where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultSubFeatureDto>> GetAllSubFeaturesAsync()
        {
            string query = "Select * from SubFeature";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultSubFeatureDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdSubFeatureDto> GetByIdSubFeatureAsync(int id)
        {
            string query = "Select * from SubFeature where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdSubFeatureDto>(query, parameters);
                return value;
            }
        }

        public async void UpdateSubFeature(UpdateSubFeatureDto updateSubFeatureDto)
        {
            string query = "Update SubFeature Set Icon=@icon,TopTitle=@topTitle,MainTitle=@mainTitle,Description=@description where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("icon", updateSubFeatureDto.Icon);
            parameters.Add("topTitle", updateSubFeatureDto.TopTitle);
            parameters.Add("mainTitle", updateSubFeatureDto.MainTitle);
            parameters.Add("description", updateSubFeatureDto.Description);
            parameters.Add("id", updateSubFeatureDto.Id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
