using System.Linq.Expressions;

namespace Session06.Models.Services.Contracts.RepositoryFramworks
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Insert a new product to the repository.
        /// </summary>
        /// <param name="product">The product to add.</param>
        void Insert(T objModel);
        /// <summary>
        /// Gets a product by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the product.</param>
        /// <returns>The product with the specified identifier, or null if not found.</returns>
        T? SelectById(int id);
        T? Select(Expression<Func<T, bool>> predicate);
        IEnumerable<T> SelectList(Expression<Func<T, bool>> where = null);
        IEnumerable<T> SelectList(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, string includes = "");
        IEnumerable<T> SelectAll();
        int Count();
        void Update(T objModel);
        void Delete(T objModel);
    }
}
