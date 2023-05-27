using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalConnectDAO.Model
{
    public class Product : BaseModel
    {
        #region Atributes
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        //public byte[] Photo { get; set; }
        public byte CategoryId { get; set; }
        public byte SupplierId { get; set; }
        #endregion


        #region Constructors

        //GET
        public Product(byte id, string name, string description, double price, int stock, byte categoryId,
               byte supplierId, byte status, DateTime registerDate, DateTime lastUpdate, int idUser)
               : base(status, registerDate, lastUpdate, idUser)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
            SupplierId = supplierId;
        }

        //INSERT
        public Product(string name, string description, double price, int stock, byte categoryId, byte supplierId)
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
            SupplierId = supplierId;
        }






        #endregion
    }
}
