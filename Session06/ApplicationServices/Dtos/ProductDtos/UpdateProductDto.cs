namespace Session06.ApplicationServices.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid Id { get; set; }
    }

}
