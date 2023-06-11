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
        //string connectionString = @"Server=DESKTOP-UKT8QUD;Database=dbDentalConnect;User Id=sa;Password=sotwa;";
        string connectionString = @"Server=DESKTOP-8LUHPUR;Database=dbDentalConnect;User Id=sa;Password=Mzhyde;";
        internal string query = "";

        public SqlCommand CreateBasicCommand(string query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            return command;
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


    }
}
