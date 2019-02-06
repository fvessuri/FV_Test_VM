using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyRestfulApp.DataAccess
{
    public interface IUserData
    {
        List<Models.UserModel> GetUsers();
        Models.UserModel GetUser(string userID);
        Models.UserModel AddUser(Models.UserModel user);
        Models.UserModel UpdateUser(Models.UserModel user);
        Models.UserModel DeleteUser(string userID);
    }

    public class UserData : IUserData
    {
        IConexion _conexion;

        public UserData(IConexion conexion = null)
        {
            _conexion = conexion ?? new Conexion();
        }

        public List<Models.UserModel> GetUsers()
        {
            string sql = string.Format("select id, Nombre, Apellido, Email, [Password] from [User]");

            return TransformUsersFromDatatable(_conexion.RealizarConsulta(sql));
        }

        public Models.UserModel GetUser(string userID)
        {
            string sql = string.Format("select id, Nombre, Apellido, Email, [Password] from [User] where id = '{0}'", userID);

            List<Models.UserModel> users = TransformUsersFromDatatable(_conexion.RealizarConsulta(sql));

            if (users != null && users.Count > 0)
                return users[0];
            else
                return null;
        }

        public Models.UserModel AddUser(Models.UserModel user)
        {
            string sql = string.Format("insert into [User] (id, Nombre, Apellido, Email, [Password]) values('{0}', '{1}', '{2}', '{3}', '{4}')", user.id, user.Nombre, user.Apellido, user.Email, user.Password);

            Models.UserModel userNuevo = GetUser(user.id);

            if (user == null)
            {
                _conexion.EjecutarComando(sql);

                userNuevo = GetUser(user.id);

                if (userNuevo != null)
                    return userNuevo;
                else
                    return null;
            }
            else
                return null;
        }

        public Models.UserModel UpdateUser(Models.UserModel user)
        {
            string sql = string.Format("update [User] set Nombre = '{1}', Apellido = '{2}', Email = '{3}', [Password] = '{4}') where id = '{0}'", user.id, user.Nombre, user.Apellido, user.Email, user.Password);

            Models.UserModel userAct = GetUser(user.id);

            if (user == null)
            {
                _conexion.EjecutarComando(sql);

                userAct = GetUser(user.id);

                if (userAct != null)
                    return userAct;
                else
                    return null;
            }
            else
                return null;
        }

        public Models.UserModel DeleteUser(string userID)
        {
            string sql = string.Format("delete [User] where id = '{0}'", userID);

            Models.UserModel user = GetUser(userID);

            if (user == null)
            {
                _conexion.EjecutarComando(sql);

                user = GetUser(userID);

                if (user != null)
                    return user;
                else
                    return null;
            }
            else
                return null;
        }

        private static List<Models.UserModel> TransformUsersFromDatatable(DataTable dt)
        {
            List<Models.UserModel> users = new List<Models.UserModel>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                    users.Add(TransformUserFromDatarow(dr));

                return users;
            }
            else
                return null;
        }

        private static Models.UserModel TransformUserFromDatarow(DataRow dr)
        {
            Models.UserModel user = new Models.UserModel();

            if (dr != null)
            {
                user.id = dr[0].ToString();
                user.Nombre = dr[1].ToString();
                user.Apellido = dr[2].ToString();
                user.Email = dr[3].ToString();
                user.Password = dr[4].ToString();

                return user;
            }
            else
                return null;
        }
    }
}