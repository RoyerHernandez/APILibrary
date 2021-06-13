using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    public partial class AuthorsHasBooks
    {
        public int AuthoresId { get; set; }
        public int? BooksIsbn { get; set; }

        public virtual Authors Authores { get; set; }
        public virtual Books BooksIsbnNavigation { get; set; }
    }
}
