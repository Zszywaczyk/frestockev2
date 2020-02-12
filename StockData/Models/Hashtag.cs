using System;
using System.Collections.Generic;
using System.Text;

namespace StockData.Models
{
    public class Hashtag
    {
        public int id { get; set; }

        public string name { get; set; }
        public IEnumerable<Image> images { get;  set; }

    }
}
