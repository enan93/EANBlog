using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject42020.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public int BlogPostId { get; set; }

        public string AuthorId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public string UpdateReason { get; set; }

        public string CommentBody { get; set; }

        public virtual BlogPost BlogPost { get; set; }
        public virtual ApplicationUser Author { get; set; }




    }
}