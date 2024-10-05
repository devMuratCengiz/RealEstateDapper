using Dapper;
using RealEstateDapperApi.Dtos.ProductDtos;
using RealEstateDapperApi.Models.DapperContext;

namespace RealEstateDapperApi.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async void CreateProduct(CreateProductDto createProductDto)
        {
            string query = "insert into Product (Title,Price,Image,City,District,Address,Description,ProductCategory,EmployeeId,Type) values (@title,@price,@image,@city,@district,@address,@description,@productCategory,@employeeId,@type)";
            var parameters = new DynamicParameters();
            parameters.Add("title", createProductDto.Title);
            parameters.Add("price", createProductDto.Price);
            parameters.Add("image", createProductDto.Image);
            parameters.Add("city", createProductDto.City);
            parameters.Add("district", createProductDto.District);
            parameters.Add("address", createProductDto.Address);
            parameters.Add("description", createProductDto.District);
            parameters.Add("productCategory", createProductDto.ProductCategory);
            parameters.Add("employeeId", createProductDto.EmployeeId);
            parameters.Add("type", createProductDto.Type);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteProduct(int id)
        {
            string query = "Delete from Product where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProdcutsWithCategoryAsync()
        {
            string query = "Select Product.Id,Title,Type,Image,Price,City,District, Category.Name" +
                " from Product" +
                " inner join Category on Product.ProductCategory = Category.Id";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * from Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(int id)
        {
            string query = "Select * from Product where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);
            using (var connection = _context.CreateConnection())
            {
                var value = connection.QueryFirstOrDefault<GetByIdProductDto>(query,parameters);
                return value;
            }
        }

        public async void UpdateProduct(UpdateProductDto updateProductDto)
        {
            string query = "Update Product Set Title=@title,Price=@price,Image=@image,City=@city,District=@district,Address=@address,Description=@description,ProductCategory=@productCategory,EmployeeId=@employeeId,Type=@type where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("title", updateProductDto.Title);
            parameters.Add("price", updateProductDto.Price);
            parameters.Add("image", updateProductDto.Image);
            parameters.Add("city", updateProductDto.City);
            parameters.Add("district", updateProductDto.District);
            parameters.Add("address", updateProductDto.Address);
            parameters.Add("description", updateProductDto.Description);
            parameters.Add("productCategory", updateProductDto.ProductCategory);
            parameters.Add("employeeId", updateProductDto.EmployeeId);
            parameters.Add("type", updateProductDto.Type);
            parameters.Add("id", updateProductDto.Id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
