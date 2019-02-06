using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRestfulApp.Services
{
    public class UserServices
    {
        DataAccess.IUserData _userData;
        DataAccess.IConexion _conexion;

        public UserServices(DataAccess.IConexion conexion = null, DataAccess.IUserData userData = null)
        {
            _conexion = conexion ?? new DataAccess.Conexion();
            _userData = userData ?? new DataAccess.UserData(_conexion);
        }

        public List<Models.UserModel> GetUsers()
        {
            List<Models.UserModel> users = _userData.GetUsers();
            List<Dtos.UsuarioDto> usersDto = new List<Dtos.UsuarioDto>();

            if (users != null)
                usersDto = Services.TransformDtoModel.UsersModel2Dto(users);

            return users;
        }

        public Dtos.UsuarioDto GetUser(string userID)
        {
            Models.UserModel user = _userData.GetUser(userID);
            Dtos.UsuarioDto userDto = new Dtos.UsuarioDto();

            if (user != null)
                userDto = Services.TransformDtoModel.UserModel2Dto(user);

            return userDto;
        }

        public string AddUser(Dtos.UsuarioDto usuarioDto)
        {
            Models.UserModel user = Services.TransformDtoModel.UserDto2Model(usuarioDto);
            Models.UserModel userNuevo = _userData.AddUser(user);

            if (user != null)
                return string.Empty;
            else
                return "No se dio de alta el usuario nuevo";
        }

        public string UpdateUser(Dtos.UsuarioDto usuarioDto)
        {
            Models.UserModel user = Services.TransformDtoModel.UserDto2Model(usuarioDto);
            Models.UserModel userAct = _userData.UpdateUser(user);

            if (user != null)
                return string.Empty;
            else
                return "No se actualizó el usuario " + userAct.id;
        }

        public string DeleteUser(string userID)
        {
            Models.UserModel user = _userData.DeleteUser(userID);

            if (user != null)
                return "No se eliminó el usuario " + userID;
            else
                return string.Empty;
        }
    }
}