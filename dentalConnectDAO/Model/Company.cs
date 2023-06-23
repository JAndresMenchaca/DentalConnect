using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalConnectDAO.Model
{
    public class Company : BaseModel
    {
        #region Attributes

        public int Id { get; set; }
        public string Nit { get; set; }
        public string BusinessName { get; set; }
        public string Phone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int ContactID { get; set; }

        #endregion

        #region Constructors

        //INSERT
        public Company(string nit, string businessName, string phone, double latitude, double longitude, int contactID)
        {
            Nit = nit;
            BusinessName = businessName;
            Phone = phone;
            Latitude = latitude;
            Longitude = longitude;
            ContactID = contactID;
        }

        //GET
        public Company(int id, string nit, string businessName, string phone, double latitude, double longitude, int contactID, byte status,
                        DateTime registerDate, DateTime lastUpdate, int idUser)
            : base(status, registerDate, lastUpdate, idUser)
        {
            Id = id;
            Nit = nit;
            BusinessName = businessName;
            Phone = phone;
            Latitude = latitude;
            Longitude = longitude;
            ContactID = contactID;
        }


        #endregion

    }
}
