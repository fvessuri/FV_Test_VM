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
        public void UserServices_GetUsersList_VerifyCallGetUsersReturnUsersList()
        {
            var conn = new Moq.Mock<DataAccess.IConexion>();
            var user = new Moq.Mock<DataAccess.IUserData>();
            var service = new Services.UserServices(conn.Object, user.Object);

            user.Setup(u => u.GetUsers()).Returns(new List<Models.UserModel> { new Models.UserModel { id = "a", Nombre = "a", Apellido = "a", Email = "a@a.com", Password = "a" }
                                                                                , new Models.UserModel { id = "b", Nombre = "b", Apellido = "b", Email = "b@b.com", Password = "b" } });

            var res = service.GetUsers();

            user.Verify(u => u.GetUsers());

            Assert.That(res, Is.TypeOf<List<Models.UserModel>>());
        }

        [Test]
        public void UserServices_GetUser_VerifyCallGetUserReturnUser()
        {
            var conn = new Moq.Mock<DataAccess.IConexion>();
            var user = new Moq.Mock<DataAccess.IUserData>();
            var service = new Services.UserServices(conn.Object, user.Object);
            var users = new List<Models.UserModel> { new Models.UserModel { id = "a", Nombre = "a", Apellido = "a", Email = "a@a.com", Password = "a" }
                                                                                , new Models.UserModel { id = "b", Nombre = "b", Apellido = "b", Email = "b@b.com", Password = "b" } };

            user.Setup(u => u.GetUser("a")).Returns(users.Find(u => u.id == "a"));

            var res = service.GetUser("a");

            user.Verify(u => u.GetUser("a"));

            Assert.That(res, Is.TypeOf<Dtos.UsuarioDto>());
        }

        [Test]
        public void UserServices_InsertUser_VerifyCallAddUserReturnStringEmpty()
        {
            var conn = new Moq.Mock<DataAccess.IConexion>();
            var user = new Moq.Mock<DataAccess.IUserData>();
            var service = new Services.UserServices(conn.Object, user.Object);
            var usr = new Models.UserModel { id = "a", Nombre = "a", Apellido = "a", Email = "a@a.com", Password = "a" };
            var usrDto = new Dtos.UsuarioDto { id = "a", Nombre = "a", Apellido = "a", Email = "a@a.com", Password = "a" };

            user.Setup(u => u.AddUser(usr)).Returns(usr);

            var res = service.AddUser(usrDto);

            //user.Verify(u => u.AddUser(usr));

            Assert.That(res, Is.Empty);
        }

        [Test]
        public void UserServices_UpdateUser_VerifyCallUpdateUserReturnStringEmpty()
        {
            var conn = new Moq.Mock<DataAccess.IConexion>();
            var user = new Moq.Mock<DataAccess.IUserData>();
            var service = new Services.UserServices(conn.Object, user.Object);
            var usr = new Models.UserModel { id = "a", Nombre = "a", Apellido = "a", Email = "a@a.com", Password = "a" };
            var usrDto = new Dtos.UsuarioDto { id = "a", Nombre = "a", Apellido = "a", Email = "a@a.com", Password = "a" };

            user.Setup(u => u.UpdateUser(usr)).Returns(usr);

            var res = service.UpdateUser(usrDto);

            //user.Verify(u => u.UpdateUser(usr));

            Assert.That(res, Is.Empty);
        }

        [Test]
        public void UserServices_DeleteUser_VerifyCallDeleteUserReturnStringEmpty()
        {
            var conn = new Moq.Mock<DataAccess.IConexion>();
            var user = new Moq.Mock<DataAccess.IUserData>();
            var service = new Services.UserServices(conn.Object, user.Object);
            var usr = new Models.UserModel { id = "a", Nombre = "a", Apellido = "a", Email = "a@a.com", Password = "a" };
            var usu = new Models.UserModel { id = "a", Nombre = "a", Apellido = "a", Email = "a@a.com", Password = "a" };

            usu = null;

            user.Setup(u => u.DeleteUser("a")).Returns(usu);

            var res = service.DeleteUser("a");

            user.Verify(u => u.DeleteUser("a"));

            Assert.That(res, Is.Empty);
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
            var httpServ = new Moq.Mock<Services.ICotizacionMonedaHttpService>();

            httpServ.Setup(hs => hs.CotizacionDolar()).Returns(new HttpResponseMessage(System.Net.HttpStatusCode.OK));

            var res = Services.CotizacionMoneda.ObtenerCotizacionMoneda(moneda);

            Assert.That(res, Is.EqualTo(System.Net.HttpStatusCode.OK));
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
            var httpServ = new Moq.Mock<Services.ICotizacionMonedaHttpService>();

            httpServ.Setup(hs => hs.CotizacionDolar()).Returns(new HttpResponseMessage(System.Net.HttpStatusCode.OK));

            var res = httpServ.Object.CotizacionDolar();

            Assert.That(res.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }
    }
}
