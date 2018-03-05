using System;

namespace Library.Domain.Contracts
{
    public interface IEntity
    {
        long Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime IncludedDate { get; set; }
    }
}
