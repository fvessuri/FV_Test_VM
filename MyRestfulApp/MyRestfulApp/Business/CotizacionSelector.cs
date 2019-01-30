using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MyRestfulApp.Business
{
    public interface ICotizacionSelector
    {
        HttpResponseMessage Cotizacion();
    }

    public class CotizacionSelector
    {
        public static HttpResponseMessage SeleccionarCotizacion(string moneda)
        {
            if (moneda.ToUpper() == System.Enum.GetName(typeof(Models.Monedas), Models.Monedas.Dolar).ToUpper())
                return new CotizacionDolar().Cotizacion();
            else if (moneda.ToUpper() == System.Enum.GetName(typeof(Models.Monedas), Models.Monedas.Pesos).ToUpper())
                return new CotizacionPesos().Cotizacion();
            else if (moneda.ToUpper() == System.Enum.GetName(typeof(Models.Monedas), Models.Monedas.Real).ToUpper())
                return new CotizacionReal().Cotizacion();
            else
            {
                HttpResponseMessage resp = new HttpResponseMessage();

                resp.StatusCode = System.Net.HttpStatusCode.NotFound;
                resp.Content = new StringContent("No se encontró cotización para la moneda solicitada");

                return resp;
            }
        }
    }

    public class CotizacionDolar: ICotizacionSelector
    {
        public HttpResponseMessage Cotizacion()
        {
            return Services.CotizacionMoneda.CotizacionDolar();
        }
    }

    public class CotizacionPesos : ICotizacionSelector
    {
        public HttpResponseMessage Cotizacion()
        {
            HttpResponseMessage resp = new HttpResponseMessage();

            resp.StatusCode = System.Net.HttpStatusCode.Unauthorized;
            resp.Content = new StringContent("Usuario no autorizado para consultar la cotización");

            return resp;
        }
    }

    public class CotizacionReal : ICotizacionSelector
    {
        public HttpResponseMessage Cotizacion()
        {
            HttpResponseMessage resp = new HttpResponseMessage();

            resp.StatusCode = System.Net.HttpStatusCode.Unauthorized;
            resp.Content = new StringContent("Usuario no autorizado para consultar la cotización");

            return resp;
        }
    }
}