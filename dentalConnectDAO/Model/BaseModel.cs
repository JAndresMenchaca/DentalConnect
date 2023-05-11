using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalConnectDAO.Model
{
    public class BaseModel
    {
        #region Atributes
        public byte Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public int IdUser { get; set; }
        #endregion

        #region Constructors
        public BaseModel()
        {

        }

        public BaseModel(byte status, DateTime registerDate, DateTime lastUpdate, int idUser)
        {
            Status = status;
            RegisterDate = registerDate;
            LastUpdate = lastUpdate;
            IdUser = idUser;
        }

        public BaseModel(int idUser)
        {
            IdUser = idUser;
        }



        #endregion
    }
}