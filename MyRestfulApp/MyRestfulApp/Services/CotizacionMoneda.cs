using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MyRestfulApp.Services
{
    public class CotizacionMoneda
    {
        public static HttpResponseMessage ObtenerCotizacionMoneda(string moneda)
        {
            return Business.CotizacionSelector.SeleccionarCotizacion(moneda);
        } 

        public static HttpResponseMessage CotizacionDolar()
        {
            string res = string.Empty;
            HttpResponseMessage resp = new HttpResponseMessage();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["urlCotizacionDolar"].ToString());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("").Result;
                if (response.IsSuccessStatusCode)
                {
                    res = response.Content.ReadAsStringAsync().Result;
                }
            }

            resp.StatusCode = System.Net.HttpStatusCode.OK;
            resp.Content = new StringContent(res);

            return resp;
        }
    }
}