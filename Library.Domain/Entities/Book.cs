using Library.Domain.Contracts;
using Library.Domain.Dto;
using System;

namespace Library.Domain.Entities
{
    public class Book : IEntity
    {
        public Book() { }

        public Book(BookModel model)
        {
            Title = model.Title;
            Subtitle = model.Subtitle;
            Subject = model.Subject;
            Publisher = model.Publisher;
            Author = model.Author;
            PublishDate = model.PublishDate;
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Subject { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime IncludedDate { get; set; } = DateTime.Now;
    }
}
