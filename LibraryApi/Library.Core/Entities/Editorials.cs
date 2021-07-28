using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    public partial class Editorials : BaseEntity
    {
        public Editorials()
        {
            Books = new HashSet<Books>();
        }

        public string EditorialName { get; set; }
        public string Headquarters { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
