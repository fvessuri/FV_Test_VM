using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyRestfulApp.Controllers.Api
{
    [RoutePrefix("api/cotizacion")]
    public class CotizacionController : ApiController
    {
        //  GET /api/cotizacion/moneda
        [HttpGet]
        [Route("{moneda:alpha}")]
        public HttpResponseMessage CotizacionGet(string moneda)
        {
            return Business.CotizacionSelector.SeleccionarCotizacion(moneda);
        }
    }
}
