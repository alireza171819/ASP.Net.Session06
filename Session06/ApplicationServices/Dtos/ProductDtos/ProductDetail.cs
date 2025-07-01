namespace Session06.ApplicationServices.Dtos.ProductDtos
{
    public class ProductDetail
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }
    }

}
