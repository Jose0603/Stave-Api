﻿using System;
using System.Collections.Generic;

namespace Stave_Api.Data.Models;

public partial class ProductImage
{
    public int ImageId { get; set; }

    public int ProductId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string? AltText { get; set; }

    public virtual Product Product { get; set; } = null!;
}
