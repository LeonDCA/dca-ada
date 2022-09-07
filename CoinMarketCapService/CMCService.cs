using System;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Web;

namespace CoinMarketCapService
{
    public class CMCService
    {
        private static string API_KEY = "5c70d535-3c51-47a1-b6a3-40aef8fbf5e3";
        private readonly HttpClient httpClient;

        public CMCService()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<string> GetData()
        {
            var url = new UriBuilder("https://sandbox-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["start"] = "1";
            queryString["limit"] = "5000";
            queryString["convert"] = "USD";

            url.Query = queryString.ToString();

            using (var request = new HttpRequestMessage(HttpMethod.Get, url.ToString()))
            {
                request.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
                request.Headers.Add("Accepts", "application/json");

                HttpResponseMessage response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return "Internal server Error";
                }
            }
        }
    }
}