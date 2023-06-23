using dentalConnectDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalConnectDAO.Interfaces
{
    internal interface ICompany : IBase<Company>
    {
        Company Get(int id);
    }
}
