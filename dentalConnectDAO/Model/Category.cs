using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalConnectDAO.Model
{
    public class Category : BaseModel
    {
        #region Attributes
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion

        #region Constructors

        // GET
        public Category(byte id, string name, string description, byte status, DateTime registerDate, DateTime lastUpdate, int idUser)
            :base(status, registerDate, lastUpdate, idUser)
        {
            Id= id;
            Name= name;
            Description= description;
        }


        // Insert
        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }

        #endregion
    }
}
