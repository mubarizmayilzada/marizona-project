using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Marizona.WebUI.Models.Entities
{
    public class FAQ : BaseEntity
    {
        [Required]
        public string Question { get; set; }
        
        [Required]
        public string Answer { get; set; }
    }
}
