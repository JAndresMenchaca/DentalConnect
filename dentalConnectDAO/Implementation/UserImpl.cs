using dentalConnectDAO.Interfaces;
using dentalConnectDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalConnectDAO.Implementation
{
    public class UserImpl : BaseImpl, IUser
    {
        public int Delete(User t)
        {
            throw new NotImplementedException();
        }

        public int Insert(User t)
        {
            throw new NotImplementedException();
        }

        public DataTable Login(string username, string password)
        {
            query = @"SELECT id, username, role
                        FROM [User]
                        WHERE status = 1 AND username = @name AND password=HASHBYTES('MD5', @password)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", username);
            command.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;

            try
            {
                 return GetTable(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable Select()
        {
            throw new NotImplementedException();
        }

        public int Update(User t)
        {
            throw new NotImplementedException();
        }
    }
}
