using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    public partial class Books
    {
        public Books()
        {
            AuthorsHasBooks = new HashSet<AuthorsHasBooks>();
        }

        public int Isbn { get; set; }
        public int EditorialId { get; set; }
        public string Title { get; set; }
        public string Sinopsis { get; set; }
        public string Pages { get; set; }

        public virtual Editorials Editorial { get; set; }
        public virtual ICollection<AuthorsHasBooks> AuthorsHasBooks { get; set; }
    }
}
