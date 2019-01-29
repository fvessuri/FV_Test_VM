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
        string Cotizacion();
    }

    public class CotizacionSelector
    {
        public static string SeleccionarCotizacion(string moneda)
        {
            if (moneda.ToUpper() == System.Enum.GetName(typeof(Models.Monedas), Models.Monedas.Dolar).ToUpper())
                return new CotizacionDolar().Cotizacion();
            else if (moneda.ToUpper() == System.Enum.GetName(typeof(Models.Monedas), Models.Monedas.Pesos).ToUpper())
                return new CotizacionPesos().Cotizacion();
            else if (moneda.ToUpper() == System.Enum.GetName(typeof(Models.Monedas), Models.Monedas.Real).ToUpper())
                return new CotizacionReal().Cotizacion();
            else
                return string.Empty;
        }
    }

    public class CotizacionDolar: ICotizacionSelector
    {
        public string Cotizacion()
        {
            return Services.CotizacionMoneda.CotizacionDolar();
        }
    }

    public class CotizacionPesos : ICotizacionSelector
    {
        public string Cotizacion()
        {
            return Defs._unauthorized;
        }
    }

    public class CotizacionReal : ICotizacionSelector
    {
        public string Cotizacion()
        {
            return Defs._unauthorized;
        }
    }

    public static class Defs
    {
        public static string _unauthorized = "unauthorized";
    }
}