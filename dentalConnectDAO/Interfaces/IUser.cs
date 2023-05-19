using dentalConnectDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalConnectDAO.Interfaces
{
    internal interface IUser:IBase<User>
    {
        DataTable Login(string username, string password);
        User Get(byte id);
        bool Verify(string nameUser);
        int change(string password);

    }
}
