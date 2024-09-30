﻿using Newtonsoft.Json;
using Stave_Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Stave_Api.Services.Exchange_Service
{
    public class CurrencyFreaksService : ICurrencyFreaksService
    {
        private static readonly string apiUrl = "https://api.currencyfreaks.com/v2.0/rates/latest?apikey=c69b360ee4b44e25950711867cf2d53f&symbols=PKR,GBP,EUR,USD";
        public async Task<List<Product>> Exchange(List<Product> products)
        {
            try
            {
                var TargetCurrency = "USD";
                var OriginalCurrency = "";

                TargetCurrency = products.FirstOrDefault().TargetCurrency ?? "USD";
                OriginalCurrency = products.FirstOrDefault().OriginalCurrency;

                var currencyResponse = await GetRates(TargetCurrency, OriginalCurrency);

                if (currencyResponse?.Rates != null && currencyResponse.Rates.TryGetValue(OriginalCurrency, out var exchangeRate))
                {
                    if (exchangeRate == 0)
                        throw new InvalidOperationException($"Exchange rate for currency '{OriginalCurrency}' not found or is zero.");

                    Parallel.ForEach(products, product =>
                    {
                        product.ExchangePrice = product.Price * exchangeRate;
                    });
                }
                else
                    throw new InvalidOperationException("Currency response or rates are null.");
                

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                return null;
            }
            return products;

        }

        public async Task<CurrencyResponse> GetRates(string OriginalCurrency, string TargetCurrency)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode(); // Throws if not a success status

                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into a CurrencyRateResponse object
                    CurrencyResponse currencyRates = JsonConvert.DeserializeObject<CurrencyResponse>(responseBody);

                    return currencyRates;
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Request error: {ex.Message}");
                    return null;
                }
            }
        }
    }
}
