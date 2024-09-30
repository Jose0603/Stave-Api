using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stave_Api.Data.Models;

namespace Stave_Api.Services.Exchange_Service
{
    internal interface ICurrencyFreaks
    {
        //Get Rates of Desired Currencies Only
        Task<CurrencyResponse> GetRates(string OriginalCurrency, string TargetCurrency);
    }
}
