
using Marizona.WebUI.Models.Entities;
using System.Collections.Generic;

namespace Marizona.WebUI.Models.ViewModels
{
    public class ShopFilterCategoriesViewModel 
    {
        public ICollection<Category> Categories { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Product> RecentProducts { get; set; }
        public ICollection<Blog> RecentBlogs { get; set; }
    }
}
