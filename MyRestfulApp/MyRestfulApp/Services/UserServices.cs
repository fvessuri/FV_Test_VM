using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRestfulApp.Services
{
    public class UserServices
    {
        public static List<Models.UserModel> GetUsers()
        {
            List<Models.UserModel> users = DataAccess.UserData.GetUsers();
            List<Dtos.UsuarioDto> usersDto = new List<Dtos.UsuarioDto>();

            if (users != null)
                usersDto = Services.TransformDtoModel.UsersModel2Dto(users);

            return users;
        }

        public static Dtos.UsuarioDto GetUser(string userID)
        {
            Models.UserModel user = DataAccess.UserData.GetUser(userID);
            Dtos.UsuarioDto userDto = new Dtos.UsuarioDto();

            if (user != null)
                userDto = Services.TransformDtoModel.UserModel2Dto(user);

            return userDto;
        }

        public static string AddUser(Dtos.UsuarioDto usuarioDto)
        {
            Models.UserModel user = Services.TransformDtoModel.UserDto2Model(usuarioDto);
            Models.UserModel userNuevo = DataAccess.UserData.AddUser(user);

            if (user != null)
                return string.Empty;
            else
                return "No se dio de alta el usuario nuevo";
        }

        public static string UpdateUser(Dtos.UsuarioDto usuarioDto)
        {
            Models.UserModel user = Services.TransformDtoModel.UserDto2Model(usuarioDto);
            Models.UserModel userAct = DataAccess.UserData.UpdateUser(user);

            if (user != null)
                return string.Empty;
            else
                return "No se actualizó el usuario " + userAct.id;
        }

        public static string DeleteUser(string userID)
        {
            Models.UserModel user = DataAccess.UserData.DeleteUser(userID);

            if (user != null)
                return "No se eliminó el usuario " + userID;
            else
                return string.Empty;
        }
    }
}