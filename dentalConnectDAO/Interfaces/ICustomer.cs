using dentalConnectDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalConnectDAO.Interfaces
{
    public interface ICustomer
    {
        void Insertar(Person person, Customer customer);
    }
}
