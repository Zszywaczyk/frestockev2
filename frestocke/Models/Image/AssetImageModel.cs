using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frestocke.Models.Image
{
    public class AssetImageModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public virtual AssetUserModel user { get; set; } //virtual??
        public virtual AssetCategoryModel category { get; set; }
        public string filetype { get; set; }
        public int xsize { get; set; }
        public int ysize { get; set; }
        public string filename { get; set; }
        public string filepath { get; set; }


        public DateTime DateOfAdd { get; set; }
    }
}
