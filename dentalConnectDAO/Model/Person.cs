using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalConnectDAO.Model
{
    public class Person : BaseModel
    {
        #region Attributes
        public byte Id { get; set; }
        public string Ci { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public DateTime Birthdate { get; set; }
        public char Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        #endregion

        #region Constructors

        public Person()
        {

        }

        //GET
        public Person(byte id, string ci, string name, string lastName, string secondLastName, DateTime birthdate,
                        char gender, string phone, string email, byte status, DateTime registerDate, DateTime lastUpdate, int idUser)
                        :base(status, registerDate, lastUpdate, idUser)
        {
            Id = id;
            Ci = ci;
            Name = name;
            LastName = lastName;
            SecondLastName = secondLastName;
            Birthdate = birthdate;
            Gender = gender;
            Phone = phone;
            Email = email;
        }

        //INSERT
        public Person(string ci, string name, string lastName, string secondLastName, DateTime birthdate, char gender, string phone, string email)
        {
            Ci = ci;
            Name = name;
            LastName = lastName;
            SecondLastName = secondLastName;
            Birthdate = birthdate;
            Gender = gender;
            Phone = phone;
            Email = email;
        }

        public Person(string ci, string name, string lastName, string secondLastName, DateTime birthdate, char gender, string phone, string email, int idUser) : this(ci, name, lastName, secondLastName, birthdate, gender, phone, email)
        {
        }


        #endregion



    }
}
