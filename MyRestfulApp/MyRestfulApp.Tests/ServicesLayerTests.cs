using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;

namespace MyRestfulApp.Tests
{
    [TestFixture]
    public class ServicesLayerTests
    {
        [Test]
        public void UserServices_WhenCalled_VerifyData()
        {
            string usuarioID = "fvTest";
            Dtos.UsuarioDto usuarioNuevo = new Dtos.UsuarioDto();

            usuarioNuevo.id = "mxyzptlk";
            usuarioNuevo.Nombre = "Mxyz";
            usuarioNuevo.Apellido = "Ptlk";
            usuarioNuevo.Email = "mxyzplk@sarasa.com";
            usuarioNuevo.Password = "kltpzyxm";

            //  Users List
            var list = Services.UserServices.GetUsers();

            Assert.That(list, Is.Not.Null);

            //  User by id
            var usu = Services.UserServices.GetUser(usuarioID);

            Assert.That(usu.id, Is.EqualTo(usuarioID));

            //  Add User
            var resAdd = Services.UserServices.AddUser(usuarioNuevo);

            Assert.That(resAdd, Is.Empty);

            var usuAdd = Services.UserServices.GetUser(usuarioNuevo.id);

            Assert.That(usuAdd.id, Is.EqualTo(usuarioNuevo.id));

            //  Update User
            usuarioNuevo.Email = "mxyzplk@sarlanga.com";
            var resUpd = Services.UserServices.UpdateUser(usuarioNuevo);

            Assert.That(resUpd, Is.Empty);

            var usuUpd = Services.UserServices.GetUser(usuarioNuevo.id);

            Assert.That(usuUpd.Email, Is.EqualTo(usuarioNuevo.Email));

            //  Delete User
            var resDel = Services.UserServices.DeleteUser(usuarioNuevo.id);

            Assert.That(resDel, Is.Empty);

            var usuDel = Services.UserServices.GetUser(usuarioNuevo.id);

            Assert.That(usuDel, Is.Null);

        }

        [Test]
        public void TransformDtoModel_UserDto2Model_ReturnUserModel()
        {
            Dtos.UsuarioDto usuarioNuevo = new Dtos.UsuarioDto();

            usuarioNuevo.id = "mxyzptlk";
            usuarioNuevo.Nombre = "Mxyz";
            usuarioNuevo.Apellido = "Ptlk";
            usuarioNuevo.Email = "mxyzplk@sarasa.com";
            usuarioNuevo.Password = "kltpzyxm";

            var res = Services.TransformDtoModel.UserDto2Model(usuarioNuevo);

            Assert.That(res, Is.TypeOf<Models.UserModel>());
        }

        [Test]
        public void TransformDtoModel_UserModel2Dto_ReturnUserDto()
        {
            Models.UserModel usuarioNuevo = new Models.UserModel();

            usuarioNuevo.id = "mxyzptlk";
            usuarioNuevo.Nombre = "Mxyz";
            usuarioNuevo.Apellido = "Ptlk";
            usuarioNuevo.Email = "mxyzplk@sarasa.com";
            usuarioNuevo.Password = "kltpzyxm";

            var res = Services.TransformDtoModel.UserModel2Dto(usuarioNuevo);

            Assert.That(res, Is.TypeOf<Dtos.UsuarioDto>());
        }

        [Test]
        public void TransformDtoModel_UsersDto2Model_ReturnUsersModel()
        {
            List<Dtos.UsuarioDto> usuarios = new List<Dtos.UsuarioDto>();

            usuarios.Add( new Dtos.UsuarioDto { 
                id = "abc",
                Nombre = "abc",
                Apellido = "abc",
                Email = "abc@sarasa.com",
                Password = "abc"
            });

            usuarios.Add(new Dtos.UsuarioDto
            {
                id = "def",
                Nombre = "def",
                Apellido = "def",
                Email = "def@sarasa.com",
                Password = "def"
            });

            var res = Services.TransformDtoModel.UsersDto2Model(usuarios);

            Assert.That(res, Is.Not.Empty);
            Assert.That(res.Count, Is.EqualTo(2));
        }

        [Test]
        public void TransformDtoModel_UsersModel2Dto_ReturnUsersDto()
        {
            List<Models.UserModel> usuarios = new List<Models.UserModel>();

            usuarios.Add(new Models.UserModel
            {
                id = "abc",
                Nombre = "abc",
                Apellido = "abc",
                Email = "abc@sarasa.com",
                Password = "abc"
            });

            usuarios.Add(new Models.UserModel
            {
                id = "def",
                Nombre = "def",
                Apellido = "def",
                Email = "def@sarasa.com",
                Password = "def"
            });

            var res = Services.TransformDtoModel.UsersModel2Dto(usuarios);

            Assert.That(res, Is.Not.Empty);
            Assert.That(res.Count, Is.EqualTo(2));
        }

        [Test]
        public void ObtenerCotizacionMoneda_WhenDolar_ReturnString()
        {
            string moneda = "Dolar";

            var res = Services.CotizacionMoneda.ObtenerCotizacionMoneda(moneda);

            Assert.That(res, Is.Not.Empty);
        }

        [Test]
        public void ObtenerCotizacionMoneda_WhenPesos_ReturnReturnHttpStatusCodeUnauthorized()
        {
            string moneda = "Pesos";

            var res = Services.CotizacionMoneda.ObtenerCotizacionMoneda(moneda);

            Assert.That(res.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Unauthorized));
        }

        [Test]
        public void ObtenerCotizacionMoneda_WhenReal_ReturnReturnHttpStatusCodeUnauthorized()
        {
            string moneda = "Real";

            var res = Services.CotizacionMoneda.ObtenerCotizacionMoneda(moneda);

            Assert.That(res.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Unauthorized));
        }

        [Test]
        public void ObtenerCotizacionMoneda_WhenOther_ReturnHttpStatusCodeNotFound()
        {
            string moneda = "Euro";

            var res = Services.CotizacionMoneda.ObtenerCotizacionMoneda(moneda);

            Assert.That(res.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
        }

        [Test]
        public void CotizacionMoneda_WhenCalled_ReturnHttpStatusCodeOK()
        {
            string moneda = "Dolar";

            var res = Services.CotizacionMoneda.CotizacionDolar();

            Assert.That(res.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }
    }
}
