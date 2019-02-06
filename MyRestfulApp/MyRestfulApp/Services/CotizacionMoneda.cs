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
    }
}