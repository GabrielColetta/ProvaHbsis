using Library.Domain.Dto;
using Library.Domain.Entities;

namespace Library.Domain.Contracts
{
    public interface IBookService : IBaseService<BookModel, Book>
    {
    }
}
