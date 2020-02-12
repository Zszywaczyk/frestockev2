using StockData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frestocke.Models.Image
{
    public class AssetCategoryModel
    {
        public AssetCategoryModel()
        {
        }
        public AssetCategoryModel(Category category)
        {
            id = category.id;
            name = category.name;
        }

        public int id { get; set; }
        public string name { get; set; }
    }
}
