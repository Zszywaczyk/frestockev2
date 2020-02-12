using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frestocke.Models.Image
{
    public class AssetIndexModel
    {
        public IEnumerable<AssetImageModel> Images { get; set; }
        public IEnumerable<AssetCategoryModel> Categories { get; set; }
    }
}
