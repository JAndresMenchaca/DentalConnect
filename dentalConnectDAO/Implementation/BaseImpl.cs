using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dentalConnectDAO.Implementation
{
    public class BaseImpl
    {
        //string connectionString = @"Server=LAPTOP_ANDRES\SQLEXPRESS;Database=dbDentalConnect;User Id=sa;Password=sotwa";
        string connectionString = @"Server=DESKTOP-UKT8QUD;Database=dbDentalConnect;User Id=sa;Password=sotwa;";
        //string connectionString = @"Server=DESKTOP-8LUHPUR;Database=dbDentalConnect;User Id=sa;Password=Mzhyde;";
        internal string query = "";

        public SqlCommand CreateBasicCommand(string query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            return command;
        }

        public List<SqlCommand> Create2BasicCommand(string sql1, string sql2)
        {
            List<SqlCommand> cmds = new List<SqlCommand>();

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command1 = new SqlCommand(sql1, connection);
            cmds.Add(command1);

            SqlCommand command2 = new SqlCommand(sql2, connection);
            cmds.Add(command2);

            return cmds;
        }


        public int ExecuteBasicCommand(SqlCommand command)
        {
            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
            command.Connection.Close();
            }
        }


        public void ExecuteNBasicCommand(List<SqlCommand> cmds)
        {
            SqlCommand command0 = cmds[0];
            SqlTransaction t = null;
            try
            {
                command0.Connection.Open();
                t = command0.Connection.BeginTransaction();
                foreach(SqlCommand item in cmds)
                {
                    item.Transaction = t;
                    item.ExecuteNonQuery();
                }
                
                t.Commit();
            }
            catch (Exception ex)
            {
                t.Rollback();
                throw ex;
            }
            finally
            {
                command0.Connection.Close();
            }
        }

        public DataTable GetTable(SqlCommand command)
        {
            DataTable table = new DataTable();
            try
            {
                command.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
            return table;
        }

        public string GetGenerateIDTable(string tableName)
        {
            query = "SELECT IDENT_CURRENT('"+tableName+"') + IDENT_INCR('"+tableName+"');";
            SqlCommand sqlCommand = CreateBasicCommand(query);
            try
            {
                sqlCommand.Connection.Open();
                return sqlCommand.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { sqlCommand.Connection.Close(); }  
        }


    }
}
