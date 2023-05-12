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
            command.Parameters.AddWithValue("@idUser", t.IdUser); // TO DO: Mas adelante usaremos sesiones y modificaremos esta parte

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
            query = @"SELECT *
                      FROM vwCategory
                      ORDER BY 2";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                return GetTable(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(Category t)
        {
            query = @"UPDATE Category SET name=@name, description=@description, lastUpdate=CURRENT_TIMESTAMP, idUser=@idUser
                    WHERE id = @id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@description", t.Description);
            command.Parameters.AddWithValue("@idUser", t.IdUser); // TO DO: Mas adelante usaremos sesiones y modificaremos esta parte
            command.Parameters.AddWithValue("@id", t.Id);
            
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete(Category t)
        {
            query = @"UPDATE Category SET status=0, lastUpdate=CURRENT_TIMESTAMP, idUser=@idUser
                        WHERE id = @id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@idUser", t.IdUser); // TO DO: Mas adelante usaremos sesiones y modificaremos esta parte                                                        
            command.Parameters.AddWithValue("@id", t.Id);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
