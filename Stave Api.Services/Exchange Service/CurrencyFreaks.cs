using Stave_Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stave_Api.Services.Exchange_Service
{
    public class CurrencyFreaks : ICurrencyFreaks
    {
        Task<CurrencyResponse> ICurrencyFreaks.GetRates(string OriginalCurrency, string TargetCurrency)
        {
            throw new NotImplementedException();
        }
    }
}
