using Session06.Models.DomainModels.ProductAggregates;
using Session06.Models.Services.Contracts;

namespace Session06.Models.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Privete Fields

        private readonly StoreContext _context;

        #endregion

        #region Constructor

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        #endregion

        // Implement methods from IProductRepository here
        // e.g., GetProducts, GetProductById, AddProduct, etc.
        #region IProductRepository Implementation
        public IEnumerable<Product> GetProducts()
        {
            using (_context)
            {
                try
                {
                    return _context.Products.ToList();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    if (_context is not null)
                    {
                        _context.Dispose();
                    }
                }
            }
            
        }

        public Product GetProductById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }
            using (_context)
            {
                try
                {
                    return _context.Products.FirstOrDefault(p => p.Id == id);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (_context is not null)
                    {
                        _context.Dispose();
                    }
                }
            }
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        #endregion
    }
}
