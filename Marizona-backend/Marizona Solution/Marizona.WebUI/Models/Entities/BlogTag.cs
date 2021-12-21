using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marizona.WebUI.Models.Entities
{
    public class BlogTag : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
