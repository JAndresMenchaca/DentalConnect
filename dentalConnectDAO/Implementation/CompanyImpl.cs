using dentalConnectDAO.Interfaces;
using dentalConnectDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace dentalConnectDAO.Implementation
{
    public class CompanyImpl : BaseImpl, ICompany
    {
        public int Delete(Company t, int session)
        {
            query = @"UPDATE Company SET status=0, lastUpdate=CURRENT_TIMESTAMP, userID= @userID
                        WHERE id = @id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@userID", session/*Session.SessionID*/); //OJO                                                      
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

        public int Delete(Company t)
        {
            throw new NotImplementedException();
        }

        public Company Get(int id)
        {
            Company company = null;

            query = @"SELECT id, nit, businessName, phone, status, registerDate, ISNULL(lastUpdate, CURRENT_TIMESTAMP), contactID, userID, latitude, longitude
                    FROM Company
                    WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable table = GetTable(command);
                if (table.Rows.Count > 0)
                {
                    int ID = int.Parse(table.Rows[0][0].ToString());
                    string nit = table.Rows[0][1].ToString();
                    string businessName = table.Rows[0][2].ToString();
                    string phone = table.Rows[0][3].ToString();
                    byte status = byte.Parse(table.Rows[0][4].ToString());
                    DateTime registerDate = DateTime.Parse(table.Rows[0][5].ToString());
                    DateTime lastUpdate = DateTime.Parse(table.Rows[0][6].ToString());
                    int contactID = int.Parse(table.Rows[0][7].ToString());
                    byte idUser = byte.Parse(table.Rows[0][8].ToString());
                    double latitude = double.Parse(table.Rows[0][9].ToString());
                    double longitude = double.Parse(table.Rows[0][10].ToString());


                    company = new Company(ID, nit, businessName, phone, latitude, longitude, 
                         contactID, status, registerDate, lastUpdate, idUser);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return company;
        }

        public int Insert(Company t, int session)
        {
            query = @"INSERT INTO Company (nit, businessName, phone, contactID, userID, latitude, longitude)
                        VALUES (@nit, @businessName, @phone, @contactID, @userID, @latitude, @longitude)";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@nit", t.Nit);
            command.Parameters.AddWithValue("@businessName", t.BusinessName);
            command.Parameters.AddWithValue("@phone", t.Phone);
            command.Parameters.AddWithValue("@contactID", t.ContactID);
            command.Parameters.AddWithValue("@userID", session/*Session.SessionID)*/); //OJO
            command.Parameters.AddWithValue("@latitude", t.Latitude);
            command.Parameters.AddWithValue("@longitude", t.Longitude);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert(Company t)
        {
            throw new NotImplementedException();
        }

        public DataTable Select()
        {
            query = @"SELECT *
                        FROM vwCompany
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

        public int Update(Company t, int session)
        {
            query = @"UPDATE Company
                        SET nit = @nit,
                            businessName = @businessName,
                            phone = @phone,
                            contactID = @contactID,
                            userID = @userID,
                            latitude = @latitude,
                            longitude = @longitude
                        WHERE id = @id
                        ";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@nit", t.Nit);
            command.Parameters.AddWithValue("@businessName", t.BusinessName);
            command.Parameters.AddWithValue("@phone", t.Phone);
            command.Parameters.AddWithValue("@contactID", t.ContactID);
            command.Parameters.AddWithValue("@latitude", t.Latitude);
            command.Parameters.AddWithValue("@longitude", t.Longitude);
            command.Parameters.AddWithValue("@userID", session /*Session.SessionID*/); //OJO
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

        public int Update(Company t)
        {
            throw new NotImplementedException();
        }
    }
}
