using Library.Domain.Contracts;
using Library.Domain.Dto;
using Library.Domain.Entities;
using Library.Domain.Enum;
using Library.Persistence.Context;
using Library.Persistence.Extension;
using Library.Resource.Message;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Library.Application.Services
{
    public class BookService : IBookService
    {
        public BookService(IContext context)
        {
            _context = context;
        }

        protected readonly IContext _context;

        public void Dispose()
        {
            _context.Dispose();
        }

        public Tuple<StatusCode, string, BookModel> Create(BookModel model)
        {
            if (model != null && model.IsValid())
            {
                var newEntity = new Book(model);

                _context.Books.Add(newEntity);
                _context.SaveChanges();
                return Tuple.Create(StatusCode.Created, SuccessMessage.SuccessOperation, new BookModel { Id = newEntity.Id });
            }
            return Tuple.Create(StatusCode.InternalServerError, ErrorResource.InvalidModel, new BookModel());
        }

        public Tuple<StatusCode, string> Delete(long id)
        {
            Book myBook = _context.Books.FirstOrDefault(item => !item.IsDeleted);
            if (myBook == null)
            {
                return Tuple.Create(StatusCode.NotFound, ErrorResource.RegistryNotFoundForDeletetion);
            }

            _context.Entry(myBook).State = EntityState.Modified;
            myBook.IsDeleted = true;
            _context.SaveChanges();
            return Tuple.Create(StatusCode.Ok, SuccessMessage.SuccessOperation);
        }

        public Tuple<StatusCode, string> Update(BookModel model)
        {
            if (model != null && model.IsValid())
            {
                var updatedEntity = new Book(model);
                var oldEntity = _context.Books.Find(model.Id);

                _context.Entry(oldEntity).State = EntityState.Modified;
                oldEntity = updatedEntity;
                _context.SaveChanges();
                return Tuple.Create(StatusCode.Ok, SuccessMessage.SuccessOperation);
            }
            return Tuple.Create(StatusCode.InternalServerError, ErrorResource.InvalidModel);
        }

        public Tuple<StatusCode, string, BookModel> GetById(long id)
        {
            var result = _context.Books.FirstOrDefault(item => item.Id == id && !item.IsDeleted);

            if (result != null)
            {
                var bookModel = new BookModel(result);
                return Tuple.Create(StatusCode.Ok, SuccessMessage.SuccessOperation, bookModel);
            }
            return Tuple.Create(StatusCode.NotFound, ErrorResource.RegistryNotFound, new BookModel());
        }

        public Tuple<StatusCode, string, IEnumerable<BookModel>> GetPaginated(int page)
        {
            var paginatedBook = _context.Books.GetPagination(page).ToList();

            ICollection<BookModel> result = new List<BookModel>();
            foreach (var book in paginatedBook)
            {
                result.Add(new BookModel(book as Book));
            }
            return Tuple.Create(StatusCode.Ok, SuccessMessage.SuccessOperation, result.AsEnumerable());
        }
    }
}
