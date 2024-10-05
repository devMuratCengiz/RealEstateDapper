namespace RealEstateDapperApi.Dtos.ProductDtos
{
    public class ResultProductWithCategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Name { get; set; }

        public int EmployeeId { get; set; }
    }
}
