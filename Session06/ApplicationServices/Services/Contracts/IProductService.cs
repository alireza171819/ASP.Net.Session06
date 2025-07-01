using Session06.ApplicationServices.Dtos.ProductDtos;
using Session06.Models.DomainModels.ProductAggregates;

namespace Session06.ApplicationServices.Services.Contracts
{
    public interface IProductService
    {
        Task<List<ProductList>> GetAllProductsAsync();
        Task<ProductDetail> GetProductByIdAsync(Guid id);
        void AddProductAsync(ProductCreate product);
        void UpdateProductAsync(ProductUpdate product);
        void DeleteProductAsync(ProductDelete id);
    }
}
