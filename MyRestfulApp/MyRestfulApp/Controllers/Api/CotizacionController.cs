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
        public IHttpActionResult CotizacionGet(string moneda)
        {
            string res = string.Empty;

            res = Business.CotizacionSelector.SeleccionarCotizacion(moneda);

            if (res.ToLower() == "unauthorized")
                return Unauthorized();

            if (string.IsNullOrEmpty(res))
                return BadRequest();

            return Ok(res);
        }
    }
}
