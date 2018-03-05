using Library.Domain.Entities;
using System;

namespace Library.Domain.Dto
{
    public class BookModel
    {
        public BookModel() { }

        public BookModel(Book entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            Subtitle = entity.Subtitle;
            Subject = entity.Subject;
            Publisher = entity.Publisher;
            Author = entity.Author;
            PublishDate = entity.PublishDate;
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Subject { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }

        public bool IsValid()
        {
            bool isvalid = true;
            if (Title.Length < 70)
            {
                return !isvalid;
            }
            if (Subtitle.Length < 70)
            {
                return !isvalid;
            }
            if (Subject.Length < 50)
            {
                return !isvalid;
            }
            if (Publisher.Length < 50)
            {
                return !isvalid;
            }
            if (Author.Length < 50)
            {
                return !isvalid;
            }
            return isvalid;
        }
    }
}
