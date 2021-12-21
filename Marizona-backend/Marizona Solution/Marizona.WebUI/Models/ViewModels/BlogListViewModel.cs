using Marizona.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marizona.WebUI.Models.ViewModels
{
    public class BlogListViewModel
    {
        public ICollection<BlogTag> BlogTags { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
