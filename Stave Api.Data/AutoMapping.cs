using AutoMapper;
using Microsoft.Extensions.Logging;
using Stave_Api.Data.DTOs;
using Stave_Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stave_Api.Data
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<ProductImage, ProductImageDTO>();
            CreateMap<ProductImageDTO, ProductImage>();

        }
    }
}
