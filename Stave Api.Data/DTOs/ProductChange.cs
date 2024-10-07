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
        public string? MainImg { get; set; }
        public string PartNumber { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public decimal Price { get; set; }
        public string OriginalCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public decimal? ExchangePrice { get; set; }
        public int ProductId { get; set; }
        public string? Category { get; set; } = null!;
        public string? AdditionalInfo { get; set; }
        public string? Notes { get; set; }
        public string Page { get; set; }
        public List<ProductImageDTO> ProductImages { get; set; }

    }
}
