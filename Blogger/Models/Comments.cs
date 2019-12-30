using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string AuthorId { get; set; }
        public string ComBody { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public virtual BlogPosts Blog { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}