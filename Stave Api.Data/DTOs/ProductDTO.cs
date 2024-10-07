using System;
using System.Collections.Generic;

namespace Stave_Api.Data.DTOs;

public partial class ProductDTO
{
    public int ProductId { get; set; }

    public string Title { get; set; } = null!;

    public string Category { get; set; } = null!;

    public decimal Price { get; set; }

    public string? PartNumber { get; set; }

    public string? Description { get; set; }

    public string? Url { get; set; }

    public string? MainImg { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? AdditionalInfo { get; set; }

    public string? Notes { get; set; }
    public List<ProductImageDTO> ProductImages { get; set; }
}
