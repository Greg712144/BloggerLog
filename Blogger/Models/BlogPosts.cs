using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Models
{
    public class BlogPosts
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string BlogBody { get; set; }
        public string Photo { get; set; }
        public string Slug { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool Published { get; set; }


        public virtual ICollection<Comments> Comments { get; set; }

        public BlogPosts()
        {
            Comments = new HashSet<Comments>();
        }
    }
}