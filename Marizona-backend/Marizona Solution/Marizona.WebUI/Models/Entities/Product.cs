using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marizona.WebUI.Models.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int BarCode { get; set; }
        public string ImagePath { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<ProductIngredient> Ingridients { get; set; }
        
    }
}
