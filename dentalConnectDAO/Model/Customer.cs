using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalConnectDAO.Model
{
    public class Customer: Person
    {
        //public int Id { get; set; }
        public string Nit { get; set; }
        public string businessName { get; set; }
        public string businessReason { get; set; }
        public string shippingAddress { get; set; }

        public Customer(string nit, string businessName, string businessReason, string shippingAddress)
        {
            Nit = nit;
            this.businessName = businessName;
            this.businessReason = businessReason;
            this.shippingAddress = shippingAddress;
        }

        public Customer(int id, string ci, string name, string lastName, string secondLastName, DateTime birthdate,
                        char gender, string phone, string email, string nit, string businessName, string businessReason, string shippingAddress,
                        byte status, DateTime registerDate, DateTime lastUpdate, int idUser)
                        : base(id, ci, name, lastName, secondLastName, birthdate, gender, phone, email, status,
                        registerDate, lastUpdate, idUser)
        {
            Nit = nit;
            this.businessName = businessName;
            this.businessReason = businessReason;
            this.shippingAddress = shippingAddress;
        }

        
    }
}
