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
            command.Parameters.AddWithValue("@idUser", 5/*Session.SessionID)*/); //OJO
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
            command.Parameters.AddWithValue("@idUser", 5 /*Session.SessionID*/); //OJO
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

            command.Parameters.AddWithValue("@idUser", 5/*Session.SessionID*/); //OJO                                                      
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

        public Category Get(byte id)
        {
            Category category=null;
            query = @"SELECT id, name, description, status, registerDate, ISNULL(lastUpdate, CURRENT_TIMESTAMP), idUser
                        FROM Category
                        WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable table = GetTable(command);
                if(table.Rows.Count > 0)
                {
                    byte ID = byte.Parse(table.Rows[0][0].ToString());
                    string nombre = table.Rows[0][1].ToString();
                    string descrip = table.Rows[0][2].ToString();
                    byte status = byte.Parse(table.Rows[0][3].ToString());
                    DateTime registerDate = DateTime.Parse(table.Rows[0][4].ToString());
                    DateTime lastUpdate = DateTime.Parse(table.Rows[0][5].ToString());
                    byte idUser = byte.Parse(table.Rows[0][6].ToString());

                    category = new Category(ID, nombre, descrip, status, registerDate, lastUpdate, idUser);
                    
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return category;
        }
    }
}
