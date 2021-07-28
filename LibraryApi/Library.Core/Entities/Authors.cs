using System;
using System.Collections.Generic;

namespace Library.Core.Entities
{
    public partial class Authors : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual AuthorsHasBooks AuthorsHasBooks { get; set; }
    }
}
