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
    public class SupplierImpl : BaseImpl, ISupplier
    {
        public int Delete(Supplier t)
        {
            query = @"UPDATE Supplier SET status=0, lastUpdate=CURRENT_TIMESTAMP, idUser=@idUser
                       WHERE id = @id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@idUser", Session.SessionID);                                                       
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

        public Supplier Get(byte id)
        {
            Supplier supplier = null;

            query = @"SELECT id, name, phone, email, webSite, mainStreet, adjacentStreet, idCity, registerDate, ISNULL(lastUpdate, CURRENT_TIMESTAMP),
                             status, idUser
                        FROM Supplier
                        WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable table = GetTable(command);
                if (table.Rows.Count > 0)
                {
                    byte ID = byte.Parse(table.Rows[0][0].ToString());
                    string name = table.Rows[0][1].ToString();
                    string phone = table.Rows[0][2].ToString();
                    string email = table.Rows[0][3].ToString();
                    string webSite = table.Rows[0][4].ToString();
                    string main = table.Rows[0][5].ToString();
                    string adjacent = table.Rows[0][6].ToString();
                    int idCity = int.Parse(table.Rows[0][7].ToString());

                    DateTime registerDate = DateTime.Parse(table.Rows[0][8].ToString());
                    DateTime lastUpdate = DateTime.Parse(table.Rows[0][9].ToString());
                    byte status = byte.Parse(table.Rows[0][10].ToString());
                    byte idUser = byte.Parse(table.Rows[0][11].ToString());

                    supplier = new Supplier(ID, name, phone, email, webSite, main, adjacent, idCity, status, registerDate, lastUpdate, idUser);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return supplier;
        }

        public int Insert(Supplier t)
        {
            query = @"INSERT INTO Supplier(name, phone, email, webSite, mainStreet, adjacentStreet, idCity, idUser)
                    VALUES(@name, @phone, @email, @webSite, @mainStreet, @adjacentStreet, @idCity, @idUser)";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@phone", t.Phone);
            command.Parameters.AddWithValue("@email", t.Email);
            command.Parameters.AddWithValue("@webSite", t.Website);
            command.Parameters.AddWithValue("@mainStreet", t.MainStreet);
            command.Parameters.AddWithValue("@adjacentStreet", t.AdjacentStreet);
            command.Parameters.AddWithValue("@idCity", t.IdCity);
            command.Parameters.AddWithValue("@idUser", Session.SessionID);
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
                      FROM vwSupplier
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

        public int Update(Supplier t)
        {
            query = @"UPDATE Supplier SET name = @name, phone = @phone, email = @email, webSite = @website,
                                          mainStreet = @mainStreet, adjacentStreet = @adjacentStreet,
                                          idCity = @idCity, lastUpdate=CURRENT_TIMESTAMP, idUser=@idUser 
                                          WHERE id = @id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@phone", t.Phone);
            command.Parameters.AddWithValue("@email", t.Email);
            command.Parameters.AddWithValue("@webSite", t.Website);
            command.Parameters.AddWithValue("@mainStreet", t.MainStreet);
            command.Parameters.AddWithValue("@adjacentStreet", t.AdjacentStreet);
            command.Parameters.AddWithValue("@idCity", t.IdCity);
            command.Parameters.AddWithValue("@idUser", Session.SessionID);
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
