using Library.Core.Entities;
using Library.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<AuthorsHasBooks> AuthorsHasBooks { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Editorials> Editorials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorsConfiguration());

            modelBuilder.ApplyConfiguration(new AuthorsHasBooksConfiguration());

            modelBuilder.ApplyConfiguration(new BookConfiguration());

            modelBuilder.ApplyConfiguration(new EditorialsConfiguration());
        }
    }
}
