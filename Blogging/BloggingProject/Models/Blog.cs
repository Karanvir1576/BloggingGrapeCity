using System;
using System.Collections.Generic;

#nullable disable

namespace BloggingProject.Models
{
    public partial class Blog
    {
        public int BlogId { get; set; }
        public string BlogHeader { get; set; }
        public string Content { get; set; }
        public string DttmRcdAdded { get; set; }
        public string DttmRcdUpdated { get; set; }
    }
}
