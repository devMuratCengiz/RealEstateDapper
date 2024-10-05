using RealEstateDapperApi.Dtos.ProductDtos;

namespace RealEstateDapperApi.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProdcutsWithCategoryAsync();
        Task<GetByIdProductDto> GetByIdProductAsync(int id);
        void CreateProduct(CreateProductDto createProductDto);
        void UpdateProduct(UpdateProductDto updateProductDto);
        void DeleteProduct(int id);
    }
}
