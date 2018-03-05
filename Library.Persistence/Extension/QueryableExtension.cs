using Library.Domain.Contracts;
using Library.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

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
        public static IQueryable<IEntity> GetPagination(
            this IQueryable<IEntity> query, 
            int page, 
            Expression<Func<IEntity, string>> orderedBy = null)
        {
            int index = page * 12;
            if (orderedBy != null)
            {
                return query.OrderBy(orderedBy).Skip(index).Take(12);
            }
            return query.OrderBy(item => item.IncludedDate).Skip(index).Take(12);
        }
    }
}
