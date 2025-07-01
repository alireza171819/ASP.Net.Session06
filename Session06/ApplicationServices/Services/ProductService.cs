using Session06.ApplicationServices.Dtos.ProductDtos;
using Session06.ApplicationServices.Services.Contracts;
using Session06.Models.DomainModels.ProductAggregates;
using Session06.Models.Services.Contracts;


namespace Session06.ApplicationServices.Services
{
    public class ProductService : IProductService
    {
        #region Privet Fields

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructor

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion

        #region Public Methods
        public async Task<List<ProductList>> GetAllProductsAsync()
        {
            var products = await Task.FromResult(_productRepository.GetAllProducts());
            if (products == null || !products.Any())
            {
                return new List<ProductList>();
            }
            var productsList = new List<ProductList>();
            foreach (var product in products)
            {
                var productList = new ProductList
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    UnitPrice = product.UnitPrice,
                };
                productsList.Add(productList);
            }
            return productsList;
        }
        public async Task<ProductDetail> GetProductByIdAsync(Guid id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return null;
            }
            var productDetail = new ProductDetail();
            productDetail.Id = product.Id;
            productDetail.ProductName = product.ProductName;
            productDetail.ProductDescription = product.ProductDescription;
            productDetail.UnitPrice = product.UnitPrice;
            return productDetail;
        }
        public void AddProductAsync(ProductCreate productCreate)
        {
            var product = new Product();
            product.ProductName = productCreate.ProductName;
            product.ProductDescription = productCreate.ProductDescription;
            product.UnitPrice = productCreate.UnitPrice;
            _productRepository.AddProduct(product);
        }
        public void UpdateProductAsync(ProductUpdate productUpdate)
        {
            var product = new Product();
            product.ProductName = productUpdate.ProductName;
            product.ProductDescription = productUpdate.ProductDescription;
            product.UnitPrice = productUpdate.UnitPrice;
            product.Id = productUpdate.Id;
            _productRepository.UpdateProduct(product);
        }
        public void DeleteProductAsync(ProductDelete productDelete)
        {
            _productRepository.DeleteProduct(productDelete.Id);
        }

        #endregion
    }
}
