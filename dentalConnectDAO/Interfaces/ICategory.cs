using dentalConnectDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalConnectDAO.Interfaces
{
    internal interface ICategory : IBase<Category>
    {
        Category Get(byte id);
    }
}
