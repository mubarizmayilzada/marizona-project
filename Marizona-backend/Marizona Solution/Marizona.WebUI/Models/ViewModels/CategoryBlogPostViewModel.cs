using Marizona.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marizona.WebUI.Models.ViewModels
{
    public class CategoryBlogPostViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Blog> RecentBlogs { get; set; }
        public Blog BlogPost { get; set; }
        public BlogPostComment comments { get; set; }
    }
}
