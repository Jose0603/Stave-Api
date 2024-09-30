using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stave_Api.Data.Models;

namespace Stave_Api.Services.Exchange_Service
{
    public interface ICurrencyFreaksService
    {
        //Get All Prducts to exchange
        Task<List<Product>> Exchange(List<Product> products);
    }
}
