using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marizona.WebUI.Models.Entities
{
    public class Chef : BaseEntity
    {
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public int PositionChefId { get; set; }
        public virtual PositionChef PositionChef { get; set; }
        public string aboutChef { get; set; }

        public int SocialMediaId { get; set; }
        public virtual SocialMedia SocialMedia { get; set; }
    }
}
