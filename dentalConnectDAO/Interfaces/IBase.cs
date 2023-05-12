using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalConnectDAO.Interfaces
{
    internal interface IBase<T>
    {
        //CRUD
        int Insert(T t);
        DataTable Select();
        int Update(T t);
        int Delete(T t);
    }
}
