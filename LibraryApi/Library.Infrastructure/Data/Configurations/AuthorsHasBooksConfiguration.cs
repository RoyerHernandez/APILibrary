using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Data.Configurations
{
    public class AuthorsHasBooksConfiguration : IEntityTypeConfiguration<AuthorsHasBooks>
    {
        public void Configure(EntityTypeBuilder<AuthorsHasBooks> builder)
        {
            builder.HasKey(e => e.AuthoresId)
                    .HasName("PK__AUTHORS___548E8C9671869641");

            builder.ToTable("AUTHORS_HAS_BOOKS");

            builder.Property(e => e.AuthoresId)
                .HasColumnName("authoresID")
                .ValueGeneratedNever();

            builder.Property(e => e.BooksIsbn).HasColumnName("booksISBN");

            builder.HasOne(d => d.Authores)
                .WithOne(p => p.AuthorsHasBooks)
                .HasForeignKey<AuthorsHasBooks>(d => d.AuthoresId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AUTHORS_H__autho__3E52440B");

            builder.HasOne(d => d.BooksIsbnNavigation)
                .WithMany(p => p.AuthorsHasBooks)
                .HasForeignKey(d => d.BooksIsbn)
                .HasConstraintName("FK__AUTHORS_H__books__3F466844");
        }
    }
}
