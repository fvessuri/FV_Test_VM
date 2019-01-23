using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MyRestfulApp.Services
{
    public class CotizacionMoneda
    {
        public static string CotizacionDolar()
        {
            string res = string.Empty;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.bancoprovincia.com.ar/Principal");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("Dolar").Result;
                if (response.IsSuccessStatusCode)
                {
                    res = response.Content.ReadAsStringAsync().Result;
                }
            }

            return res;
        }
    }
}