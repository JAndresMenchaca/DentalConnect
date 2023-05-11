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
    public class CategoryImpl : BaseImpl, ICategory
    {
        public int Insert(Category t)
        {
            query = @"INSERT INTO Category(name, description, idUser)
                      VALUES(@name, @description, @idUser)";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@description", t.Description);
            command.Parameters.AddWithValue("@idUser", t.IdUser); // TO DO: Mas adelante usaremos sesiones y modificaremos esta
                                                                  //        parte
            try
            {
                return ExecuteBasicCommand(command);    
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

        public int Update(Category t)
        {
            throw new NotImplementedException();
        }
        public int Delete(Category t)
        {
            throw new NotImplementedException();
        }
    }
}
