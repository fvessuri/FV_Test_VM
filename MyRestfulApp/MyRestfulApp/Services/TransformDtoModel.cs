using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRestfulApp.Services
{
    public class TransformDtoModel
    {
        public static List<Models.UserModel> UsersDto2Model(List<Dtos.UsuarioDto> usrsDto)
        {
            List<Models.UserModel> users = new List<Models.UserModel>();

            foreach(Dtos.UsuarioDto usrDto in usrsDto)
                users.Add(UserDto2Model(usrDto));

            return users;
        }

        public static Models.UserModel UserDto2Model(Dtos.UsuarioDto usrDto)
        {
            Models.UserModel user = new Models.UserModel();

            user.id = usrDto.id;
            user.Apellido = usrDto.Apellido;
            user.Nombre = usrDto.Nombre;
            user.Email = usrDto.Email;
            user.Password = usrDto.Password;

            return user;
        }

        public static List<Dtos.UsuarioDto> UsersModel2Dto(List<Models.UserModel> usrs)
        {
            List<Dtos.UsuarioDto> usersDto = new List<Dtos.UsuarioDto>();

            foreach (Models.UserModel usr in usrs)
                usersDto.Add(UserModel2Dto(usr));

            return usersDto;
        }

        public static Dtos.UsuarioDto UserModel2Dto(Models.UserModel usr)
        {
            Dtos.UsuarioDto userDto = new Dtos.UsuarioDto();

            userDto.id = usr.id;
            userDto.Apellido = usr.Apellido;
            userDto.Nombre = usr.Nombre;
            userDto.Email = usr.Email;
            userDto.Password = usr.Password;

            return userDto;
        }
    }
}