using System;

namespace Marizona.WebUI.Models.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int CreatedByUserId { get; set; }
    }
}
