using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    public partial class Editorials
    {
        public Editorials()
        {
            Books = new HashSet<Books>();
        }

        public int Id { get; set; }
        public string EditorialName { get; set; }
        public string Headquarters { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
