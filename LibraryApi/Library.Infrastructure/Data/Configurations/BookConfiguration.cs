using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Books>
    {
        public void Configure(EntityTypeBuilder<Books> builder)
        {
            builder.HasKey(e => e.Id)
                   .HasName("PK__BOOKS__447D36EBF8E97067");

            builder.ToTable("BOOKS");

            builder.Property(e => e.Id).HasColumnName("ISBN");

            builder.Property(e => e.EditorialId).HasColumnName("editorialId");

            builder.Property(e => e.Pages)
                .HasColumnName("pages")
                .HasMaxLength(45)
                .IsUnicode(false);

            builder.Property(e => e.Sinopsis)
                .HasColumnName("sinopsis")
                .HasColumnType("text");

            builder.Property(e => e.Title)
                .HasColumnName("title")
                .HasMaxLength(45)
                .IsUnicode(false);

            builder.HasOne(d => d.Editorial)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.EditorialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BOOKS__editorial__3B75D760");
        }
    }
}
