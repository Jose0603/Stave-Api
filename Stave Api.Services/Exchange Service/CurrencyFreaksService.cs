using Newtonsoft.Json;
using Stave_Api.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Stave_Api.Services.Exchange_Service
{
    public class CurrencyFreaksService : ICurrencyFreaksService
    {
        private readonly string _apiKey;
        private readonly string apiUrl;
        public CurrencyFreaksService(IConfiguration configuration)
        {
            // Retrieve the API key from appsettings.json
            _apiKey = configuration["CurrencyFreaks:ApiKey"];
            apiUrl = $"https://api.currencyfreaks.com/v2.0/rates/latest?apikey={_apiKey}&symbols=";
        }
        public async Task<List<ProductChange>> Exchange(List<ProductChange> products)
        {
            try
            {
                var TargetCurrency = "USD";
                var OriginalCurrency = "";

                TargetCurrency = products.FirstOrDefault().TargetCurrency ?? "USD";
                OriginalCurrency = products.FirstOrDefault().OriginalCurrency;

                var currencyResponse = await GetRates(TargetCurrency, OriginalCurrency);

                if (currencyResponse?.Rates != null && currencyResponse.Rates.TryGetValue(OriginalCurrency, out var originalCurrencyRate))
                {
                    decimal exchangeRate = originalCurrencyRate;

                    if(OriginalCurrency != "USD")
                    {
                        exchangeRate = 1/ originalCurrencyRate;
                    }

                    if (TargetCurrency != "USD" && currencyResponse.Rates.TryGetValue(TargetCurrency, out var targetCurrencyRate))
                    {
                        exchangeRate = targetCurrencyRate / originalCurrencyRate;
                    }

                    if (exchangeRate == 0)
                    {
                        throw new InvalidOperationException($"Exchange rate for currency '{OriginalCurrency}' not found or is zero.");
                    }

                    Parallel.ForEach(products, product =>
                    {
                        product.ExchangePrice = Math.Round(product.Price * exchangeRate, 2, MidpointRounding.AwayFromZero);
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
                    HttpResponseMessage response = await client.GetAsync(apiUrl+ TargetCurrency+","+ OriginalCurrency);
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
