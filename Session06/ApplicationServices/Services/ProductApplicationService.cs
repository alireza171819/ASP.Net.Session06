using Session06.ApplicationServices.Dtos.ProductDtos;
using Session06.ApplicationServices.Services.Contracts;
using Session06.Models.DomainModels.ProductAggregates;
using Session06.Models.Services.Contracts;

namespace Session06.ApplicationServices.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        #region Privet Fields

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructor

        public ProductApplicationService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion

        #region Public Methods
        public async Task<List<GetAllProductDto>> GetAll()
        {
            var products = await Task.FromResult(_productRepository.GetAllProducts());
            if (products == null || !products.Any())
            {
                return new List<GetAllProductDto>();
            }
            var productsList = new List<GetAllProductDto>();
            foreach (var product in products)
            {
                var productList = new GetAllProductDto
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
        public async Task<GetByIdProductDto> GetById(Guid id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return null;
            }
            var productDetail = new GetByIdProductDto();
            productDetail.Id = product.Id;
            productDetail.ProductName = product.ProductName;
            productDetail.ProductDescription = product.ProductDescription;
            productDetail.UnitPrice = product.UnitPrice;
            return productDetail;
        }
        public void Add(AddProductDto addProductDto)
        {
            if (addProductDto == null)
            {
                return;
            }
            var product = new Product();
            product.ProductName = addProductDto.ProductName;
            product.ProductDescription = addProductDto.ProductDescription;
            product.UnitPrice = addProductDto.UnitPrice;
            _productRepository.AddProduct(product);
        }
        public void Update(UpdateProductDto updateProductDto)
        {
            if (updateProductDto == null)
            {
                return;
            }
            var product = new Product();
            product.ProductName = updateProductDto.ProductName;
            product.ProductDescription = updateProductDto.ProductDescription;
            product.UnitPrice = updateProductDto.UnitPrice;
            product.Id = updateProductDto.Id;
            _productRepository.UpdateProduct(product);
        }
        public void Delete(DeleteProductDto deleteProductDto)
        {
            if (deleteProductDto == null)
            {
                return;
            }
            _productRepository.DeleteProduct(deleteProductDto.Id);
        }

        #endregion
    }
}
