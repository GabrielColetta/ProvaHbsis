using Library.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Library.Domain.Contracts
{
    public interface IBaseService<TEntityModel, TEntity> : IDisposable
        where TEntityModel : class, new()
        where TEntity : IEntity
    {
        Tuple<StatusCode, string, TEntityModel> Create(TEntityModel model);
        Tuple<StatusCode, string> Update(TEntityModel model);
        Tuple<StatusCode, string> Delete(long id);
        Tuple<StatusCode, string, TEntityModel> GetById(long id);
        Tuple<StatusCode, string, IEnumerable<TEntityModel>> GetPaginated(int page);
    }
}
