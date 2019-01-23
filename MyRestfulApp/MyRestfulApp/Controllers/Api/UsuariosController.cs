using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyRestfulApp.Controllers.Api
{
    [RoutePrefix("api/usuarios")]
    public class UsuariosController : ApiController
    {
        //  GET /api/usuarios
        [HttpGet]
        [Route("")]
        public IHttpActionResult UsuariosGet()
        {
            List<Models.UserModel> users = Services.UserServices.GetUsers();

            if (users == null || users.Count == 0)
                return NotFound();

            return Ok(users);
        }

        //  GET /api/usuarios/id
        [HttpGet]
        [Route("{IDusuario:alpha}")]
        public IHttpActionResult UsuarioGet(string IDusuario)
        {
            Dtos.UsuarioDto user = Services.UserServices.GetUser(IDusuario);

            if (user == null || user.id != IDusuario)
                return NotFound();

            return Ok(user);
        }

        //  POST /api/usuarios/id/nombre/apellido/email/password
        [HttpPost]
        public IHttpActionResult UsuarioPost(Dtos.UsuarioDto usuarioDto)
        {
            string userOk = Services.UserServices.AddUser(usuarioDto);

            if (!string.IsNullOrEmpty(userOk))
                return BadRequest(userOk);

            Dtos.UsuarioDto user = Services.UserServices.GetUser(usuarioDto.id);

            if (user == null || user.id != usuarioDto.id)
                return NotFound();

            return Created(new Uri(Request.RequestUri + "/" + user.id), user);
        }

        //  PUT /api/usuarios/id/nombre/apellido/email/password
        [HttpPut]
        public IHttpActionResult UsuarioPut(Dtos.UsuarioDto usuarioDto)
        {
            string userOk = Services.UserServices.UpdateUser(usuarioDto);

            if (!string.IsNullOrEmpty(userOk))
                return BadRequest(userOk);

            Dtos.UsuarioDto user = Services.UserServices.GetUser(usuarioDto.id);

            if (user == null || user.id != usuarioDto.id)
                return NotFound();

            return Ok(user);
        }

        //  DELETE /api/usuarios/id
        [HttpDelete]
        public IHttpActionResult UsuarioDelete(string userID)
        {
            string userOk = Services.UserServices.DeleteUser(userID);

            if (!string.IsNullOrEmpty(userOk))
                return BadRequest(userOk);

            Dtos.UsuarioDto user = Services.UserServices.GetUser(userID);

            if (user != null && user.id != userID)
                return BadRequest("No se eliminó el usuario " + userID);

            return Ok();
        }
    }
}
