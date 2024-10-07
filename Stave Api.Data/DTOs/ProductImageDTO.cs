using System;
using System.Collections.Generic;

namespace Stave_Api.Data.DTOs;

public partial class ProductImageDTO
{
    public int ImageId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string? AltText { get; set; }

}
