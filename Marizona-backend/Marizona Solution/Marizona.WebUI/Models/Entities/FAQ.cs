using System.ComponentModel.DataAnnotations;

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
