using Microsoft.AspNetCore.Http;

namespace Marizona.WebUI.Models.FormModels
{
    public class ProductFormModel
    {
        public IFormFile file { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int BarCode { get; set; }
        public string ImagePath { get; set; }
        public int SizeId { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public double? IsSalePrice { get; set; }
    }
}
