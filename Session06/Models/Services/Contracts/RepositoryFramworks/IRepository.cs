using System.Linq.Expressions;

namespace Session06.Models.Services.Contracts.RepositoryFramworks
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>A collection of products.</returns>
        void Add(T objModel);
        T? GetId(int id);
        T? Select(Expression<Func<T, bool>> predicate);
        IEnumerable<T> SelectList(Expression<Func<T, bool>> where = null);
        IEnumerable<T> SelectList(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, string includes = "");
        IEnumerable<T> SelectAll();
        int Count();
        void Update(T objModel);
        void Delete(T objModel);
    }
}
