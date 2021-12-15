using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marizona.WebUI.Models.Entities
{
    public class Ingridient : BaseEntity
    {
        public string Name { get; set; }

        public int ProductId { get; set; }
        public virtual ICollection<ProductIngredient> Products { get; set; }
    }
}
