using Library.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Data.Configurations
{
    public class EditorialsConfiguration : IEntityTypeConfiguration<Editorials>
    {
        public void Configure(EntityTypeBuilder<Editorials> builder)
        {
            builder.ToTable("EDITORIALS");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.EditorialName)
                .IsRequired()
                .HasColumnName("editorialName")
                .HasMaxLength(45)
                .IsUnicode(false);

            builder.Property(e => e.Headquarters)
                .HasColumnName("headquarters")
                .HasMaxLength(45)
                .IsUnicode(false);
        }
    }
}
