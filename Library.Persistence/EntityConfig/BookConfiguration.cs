using Library.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Library.Persistence.EntityConfig
{
    public class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            ToTable(nameof(Book));

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(70)
                .HasColumnType("varchar");

            Property(x => x.Subtitle)
                .IsOptional()
                .HasMaxLength(70)
                .HasColumnType("varchar");

            Property(x => x.Subject)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

            Property(x => x.Publisher)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

            Property(x => x.Author)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

            Property(x => x.PublishDate)
                .IsRequired()
                .HasColumnType("datetime2");

            Property(x => x.IsDeleted)
                .IsRequired();
        }
    }
}
