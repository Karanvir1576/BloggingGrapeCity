using System;
using System.Collections.Generic;

#nullable disable

namespace BloggingProject.Models
{
    public partial class UserXBlog
    {
        public int? UserId { get; set; }
        public int? BlogId { get; set; }

        public virtual Blog Blog { get; set; }
        public virtual UserDetail User { get; set; }
    }
}
