namespace RealEstateDapperApi.Dtos.ProductDtos
{
    public class GetByIdProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Decimal Price { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string District { get; set; }
        public int ProductCategory { get; set; }
        public int EmployeeId { get; set; }
    }
}
