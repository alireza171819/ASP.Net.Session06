using Session06.Models.DomainModels.ProductAggregates;

namespace Session06.Models.Services.Contracts
{
    public interface IProductRepository
    {
        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>A collection of products.</returns>
        IEnumerable<Product> GetAllProducts();
        /// <summary>
        /// Gets a product by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the product.</param>
        /// <returns>The product with the specified identifier, or null if not found.</returns>
        Product GetProductById(Guid id);
        /// <summary>
        /// Adds a new product to the repository.
        /// </summary>
        /// <param name="product">The product to add.</param>
        void AddProduct(Product product);
        /// <summary>
        /// Updates an existing product in the repository.
        /// </summary>
        /// <param name="product">The product to update.</param>
        void UpdateProduct(Product product);
        /// <summary>
        /// Deletes a product from the repository.
        /// </summary>
        /// <param name="id">The identifier of the product to delete.</param>
        void DeleteProduct(Guid id);
    }
}
