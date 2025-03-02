namespace WebUI.Dtos.ProductDtos
{
    public class CreateProductDTO
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public bool ProductStatus { get; set; }
        public int CategoryId { get; set; }
    }
}
