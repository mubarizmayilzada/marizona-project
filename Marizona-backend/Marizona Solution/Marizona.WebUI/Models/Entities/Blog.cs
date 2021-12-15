using System;

namespace Marizona.WebUI.Models.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string ImagePath { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int BlogTagId { get; set; }
        public BlogTag BlogTag { get; set; }

    }
}
