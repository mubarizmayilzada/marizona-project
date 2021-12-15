using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marizona.WebUI.Models.Entities
{
    public class ProductIngredient
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int IngridientId { get; set; }
        public virtual Ingridient Ingridient { get; set; }
    }
}
