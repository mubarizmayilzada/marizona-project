using Microsoft.AspNetCore.Http;
using System;

namespace Marizona.WebUI.Models.FormModels
{
    public class BlogFormModel
    {
        public IFormFile file { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string ImagePath { get; set; }
        public DateTime? PublishedDate { get; set; } = DateTime.Now;
        public int BlogTagId { get; set; }
    }
}
