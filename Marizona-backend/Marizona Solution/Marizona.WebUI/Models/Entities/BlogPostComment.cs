using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marizona.WebUI.Models.Entities
{
    public class BlogPostComment : BaseEntity
    {
        public string Comment { get; set; }
        public long BlogPostId { get; set; }
        public virtual Blog BlogPost { get; set; }
        public long? ParentId { get; set; }
        public virtual BlogPostComment Parent { get; set; }
        public virtual ICollection<BlogPostComment> Children { get; set; }
        //public virtual RiodeUser CreatedByUser { get; set; }
    }
}
