using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stave_Api.Data.DTOs
{
    public class ProductChange
    {
        public string Description { get; set; }
        public string Img { get; set; }
        public string Part_number { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public decimal Price { get; set; }
        public string OriginalCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public decimal? ExchangePrice { get; set; }

    }
}
