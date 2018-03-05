using Library.Domain.Entities;
using System.Linq;

namespace Library.Persistence.Extension
{
    public static class QueryableExtension
    {
        /// <summary>
        /// Return an IQueryable with paginated value
        /// </summary>
        /// <param name="query">Query expression</param>
        /// <param name="page">Page number</param>
        /// <returns></returns>
        public static IQueryable<Book> GetPagination(this IQueryable<Book> query, int page)
        {
            int index = page * 12;
            return query.OrderBy(item => item.Title).Skip(index).Take(12).Where(item => !item.IsDeleted);
        }
    }
}
