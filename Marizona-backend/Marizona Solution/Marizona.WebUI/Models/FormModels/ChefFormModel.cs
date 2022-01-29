using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marizona.WebUI.Models.FormModels
{
    public class ChefFormModel
    {
        public IFormFile file { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public int PositionChefId { get; set; }
        public string aboutChef { get; set; }
        public int SocialMediaId { get; set; }
    }
}
