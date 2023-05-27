using dentalConnectDAO.Interfaces;
using dentalConnectDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalConnectDAO.Implementation
{
    public class ProductImpl : BaseImpl, IProduct
    {
        public int Delete(Product t)
        {
            query = @"UPDATE Product SET status=0, lastUpdate=CURRENT_TIMESTAMP, idUser=@idUser
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

        public Product Get(byte id)
        {
            Product product = null;
            query = @"SELECT id, name, description, price, stock, idCategory, idSupplier,status, registerDate, ISNULL(lastUpdate, CURRENT_TIMESTAMP), idUser
                        FROM Product
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
                    string descrip = table.Rows[0][2].ToString();
                    double price = double.Parse(table.Rows[0][3].ToString());
                    int stock = int.Parse(table.Rows[0][4].ToString());

                    byte categoryId = byte.Parse(table.Rows[0][5].ToString());
                    byte supplierId = byte.Parse(table.Rows[0][6].ToString());

                    byte status = byte.Parse(table.Rows[0][7].ToString());
                    DateTime registerDate = DateTime.Parse(table.Rows[0][8].ToString());
                    DateTime lastUpdate = DateTime.Parse(table.Rows[0][9].ToString());
                    byte idUser = byte.Parse(table.Rows[0][10].ToString());

                    product = new Product(ID, name, descrip, price, stock, categoryId, supplierId,
                                            status, registerDate, lastUpdate, idUser);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return product;
        }

        public int Insert(Product t)
        {
            query = @"INSERT INTO Product(name, description, price, stock, idCategory, idSupplier, idUSer)
                      VALUES(@name, @description, @price, @stock, @idCategory, @idSupplier, @idUSer)";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@description", t.Description);
            command.Parameters.AddWithValue("@price", t.Price);
            command.Parameters.AddWithValue("@stock", t.Stock);
            command.Parameters.AddWithValue("@idCategory", t.CategoryId);
            command.Parameters.AddWithValue("@idSupplier", t.SupplierId);
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
                        FROM vwProduct
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

        public int Update(Product t)
        {
            query = @"UPDATE Product SET name = @name, description = @description, price = @price, stock = @stock, 
                      idCategory = @idCategory, idSupplier = @idSupplier, lastUpdate=CURRENT_TIMESTAMP, idUser=@idUser
                      WHERE id = @id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@description", t.Description);
            command.Parameters.AddWithValue("@price", t.Price);
            command.Parameters.AddWithValue("@stock", t.Stock);
            command.Parameters.AddWithValue("@idCategory", t.CategoryId);
            command.Parameters.AddWithValue("@idSupplier", t.SupplierId);
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
