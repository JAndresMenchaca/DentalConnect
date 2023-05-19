using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalConnectDAO.Model
{
    public class User : Person
    {
        #region Attributes
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        // GET
        public User(byte id, string ci, string name, string lastName, string secondLastName, DateTime birthdate,
                        char gender, string phone, string email, string username, string role,
                        byte status, DateTime registerDate, DateTime lastUpdate, int idUser) 
                        : base(id, ci, name, lastName, secondLastName, birthdate, gender, phone, email, status,
                        registerDate, lastUpdate, idUser)
        {
            Username = username;
            Role = role;
        }

        public User(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        // Insert

        public User(string ci, string name, string lastName, string secondLastName, DateTime birthdate,
                    char gender, string phone, string email, string username, string password, string role)
                    : base(ci, name, lastName, secondLastName, birthdate, gender, phone, email)
        {
            Username = username;
            Password = password;
            Role = role;
        }


        #endregion

        #region Constructors


        // GET


        #endregion
    }
}
