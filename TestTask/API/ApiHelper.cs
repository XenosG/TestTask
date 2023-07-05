using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.API
{
    public class ApiHelper
    {
        public static async Task<List<Currency>> GetCurrencyList(string searchQuery, CancellationToken cancellationToken)
        {
            List<Currency> currencyList = new List<Currency>();

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.coincap.io/v2/assets?search={searchQuery}");
            var response = await client.SendAsync(request, cancellationToken);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ApiCurrencyResponse>(responseContent);

            foreach (var asset in data?.Data)
            {
                var id = asset.Id;
                var rank = asset.Rank;
                var symbol = asset.Symbol;
                var name = asset.Name;
                var supply = asset.Supply;
                var maxSupply = asset.MaxSupply;
                var marketCapUsd = asset.MarketCapUsd;
                var volumeUsd24Hr = asset.VolumeUsd24Hr;
                var priceUsd = asset.PriceUsd;
                var changePercent24Hr = asset.ChangePercent24Hr;
                var vwap24Hr = asset.Vwap24Hr;

                decimal parsedPriceUsd;
                float parsedChangePercent24Hr;
                decimal parsedVwap24Hr;

                decimal.TryParse(priceUsd, NumberStyles.Float, CultureInfo.InvariantCulture, out parsedPriceUsd);
                float.TryParse(changePercent24Hr, NumberStyles.Float, CultureInfo.InvariantCulture, out parsedChangePercent24Hr);
                decimal.TryParse(vwap24Hr, NumberStyles.Float, CultureInfo.InvariantCulture, out parsedVwap24Hr);

                currencyList.Add(new Currency(id, name, symbol, parsedPriceUsd, parsedChangePercent24Hr, parsedVwap24Hr));
            }

            return currencyList;
        }

        public static async Task<List<Market>> GetMarketList(string id)
        {
            List<Market> marketList = new List<Market>();

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.coincap.io/v2/assets/{id}/markets");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ApiMarketResponse>(responseContent);

            foreach (var asset in data?.Data)
            {
                var exchangeId = asset.ExchangeId;
                var baseSymbol = asset.BaseSymbol;
                var quoteSymbol = asset.QuoteSymbol;
                var priceUsd = asset.PriceUsd;

                decimal parsedPriceUsd;

                decimal.TryParse(priceUsd, NumberStyles.Float, CultureInfo.InvariantCulture, out parsedPriceUsd);

                marketList.Add(new Market($"{exchangeId}: {baseSymbol}/{quoteSymbol}", parsedPriceUsd));
            }

            return marketList;
        }
    }
}
