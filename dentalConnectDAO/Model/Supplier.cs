using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalConnectDAO.Model
{
    public class Supplier : BaseModel
    {
        #region Attributes
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string MainStreet { get; set; }
        public string AdjacentStreet { get; set; }
        public int IdCity { get; set; } 


        #endregion

        #region Constructors


        // GET
        public Supplier(byte id, string name, string phone, string email, string website, string mainStreet,  
                        string adjacentStreet, int idCity ,byte status, DateTime registerDate, DateTime lastUpdate, int idUser)
            : base(status, registerDate, lastUpdate, idUser)
        {
            Id = id;
            Name = name;
            Phone= phone;
            Email = email;
            Website = website;
            MainStreet = mainStreet;
            AdjacentStreet= adjacentStreet;
            IdCity = idCity;
        }


        // Insert
        public Supplier(string name, string phone, string email, string website, string mainStreet,
                        string adjacentStreet, int idCity)
        {
            Name = name;
            Phone = phone;
            Email = email;
            Website = website;
            MainStreet = mainStreet;
            AdjacentStreet= adjacentStreet;
            IdCity = idCity;
        }

        #endregion
    }
}