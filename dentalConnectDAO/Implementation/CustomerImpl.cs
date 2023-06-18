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
    public class CustomerImpl : BaseImpl, ICustomer
    {
        public void Insertar(Person t, Customer customer, int sesssion)
        {
            string query = @"INSERT INTO Person (ci, firstName, lastName, secondLastName, birthDate, gender, email, numberPhone, userID)
                            VALUES (@ci, @name, @lastName, @secondLastName, @date, @gender, @email, @phone, @userID)";

            string query2 = @"INSERT INTO [Customer] (id, nit, businessName, businessReason, userID, shippingAddress)
                              VALUES (@id, @nit, @bn, @br, @userID, @shipping)";

            List<SqlCommand> cmds = Create2BasicCommand(query, query2);


            
            cmds[0].Parameters.AddWithValue("@ci", t.Ci);
            cmds[0].Parameters.AddWithValue("@name", t.Name);
            cmds[0].Parameters.AddWithValue("@lastName", t.LastName);
            cmds[0].Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            cmds[0].Parameters.AddWithValue("@date", t.Birthdate);
            cmds[0].Parameters.AddWithValue("@gender", t.Gender);
            cmds[0].Parameters.AddWithValue("@email", t.Email);
            cmds[0].Parameters.AddWithValue("@phone", t.Phone);
            cmds[0].Parameters.AddWithValue("@userID", sesssion); //OJO

            int id =  int.Parse(GetGenerateIDTable("Person"));
            
            cmds[1].Parameters.AddWithValue("@nit", customer.Nit);
            cmds[1].Parameters.AddWithValue("@id", id);
            cmds[1].Parameters.AddWithValue("@bn", customer.businessName);
            cmds[1].Parameters.AddWithValue("@br", customer.businessReason);
            cmds[1].Parameters.AddWithValue("@userID", sesssion); //OJO
            cmds[1].Parameters.AddWithValue("@shipping", customer.shippingAddress);

            try
            {
                ExecuteNBasicCommand(cmds);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int Delete(Customer c,  int sesssion)
        {
            query = @"UPDATE Customer SET status=0, lastUpdate=CURRENT_TIMESTAMP, userID=@userID
	                  WHERE id = @id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@userID", sesssion); //OJO
            command.Parameters.AddWithValue("@id", c.Id);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer Get(int id)
        {
            Customer customer = null;

            query = @"SELECT
        p.id,
        p.ci,
        p.firstName,
        p.lastName,
        p.secondLastName,
        p.birthDate,
        p.gender,
        p.email,
        p.numberPhone,
        c.nit,
        c.businessName,
        c.businessReason,
        c.shippingAddress,
        c.lastUpdate,
        c.registerDate,
        c.status,
        c.userID
    FROM
        Person p
    INNER JOIN
        Customer c ON p.id = c.id
    WHERE c.id = @id";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable table = GetTable(command);
                if (table.Rows.Count > 0)
                {
                    int ID;
                    if (int.TryParse(table.Rows[0]["id"].ToString(), out ID))
                    {
                        string ci = table.Rows[0]["ci"].ToString();
                        string name = table.Rows[0]["firstName"].ToString();
                        string lastName = table.Rows[0]["lastName"].ToString();
                        string secondLastName = table.Rows[0]["secondLastName"].ToString();

                        DateTime birthdate;
                        if (DateTime.TryParse(table.Rows[0]["birthDate"].ToString(), out birthdate))
                        {
                            char gender;
                            if (char.TryParse(table.Rows[0]["gender"].ToString(), out gender))
                            {
                                string email = table.Rows[0]["email"].ToString();
                                string phone = table.Rows[0]["numberPhone"].ToString();
                                string nit = table.Rows[0]["nit"].ToString();
                                string bn = table.Rows[0]["businessName"].ToString();
                                string br = table.Rows[0]["businessReason"].ToString();
                                string shipping = table.Rows[0]["shippingAddress"].ToString();

                                DateTime lastUpdate;
                                DateTime.TryParse(table.Rows[0]["lastUpdate"].ToString(), out lastUpdate);
                                
                                DateTime registerDate;
                                DateTime.TryParse(table.Rows[0]["registerDate"].ToString(), out registerDate);
                                    
                                byte status;
                                byte.TryParse(table.Rows[0]["status"].ToString(), out status);
                                        
                                int idUser;
                                int.TryParse(table.Rows[0]["userID"].ToString(), out idUser);
                                            
                                customer = new Customer(ID, ci, name, lastName, secondLastName, birthdate,
                                                            gender, phone, email, nit, bn, br, shipping,
                                                            status, registerDate, lastUpdate, idUser);
                                            
                                        
                                    
                                
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return customer;
        }


        public DataTable Select()
        {
            query = @"SELECT *
                      FROM vwCustomer
                      ORDER BY 3";
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

        public void Update(Customer t, Person p ,int session)
        {
            query = @"UPDATE Person
                    SET
                        ci = @ci,
                        firstName = @firstName,
                        LastName = @LastName,
                        secondLastName = @secondLastName,
                        email = @email,
                        numberPhone = @numberPhone,
                        birthDate = @birthDate,
                        gender = @gender,
	                    lastUpdate=CURRENT_TIMESTAMP, 
	                    userID= @userID
                    WHERE
                        id = @id;";

            string query2 = @"UPDATE Customer
                                SET
	                                lastUpdate=CURRENT_TIMESTAMP,
		                            businessName = @bn,
		                            nit = @nit,
		                            businessReason = @br,
		                            shippingAddress = @shipping,
	                                userID= @userID
        
                                WHERE
                                    id = @id;";

            List<SqlCommand> cmds = Create2BasicCommand(query, query2);

            SqlCommand command = CreateBasicCommand(query);

            cmds[0].Parameters.AddWithValue("@ci", p.Ci);
            cmds[0].Parameters.AddWithValue("@firstName", p.Name);
            cmds[0].Parameters.AddWithValue("@lastName", p.LastName);
            cmds[0].Parameters.AddWithValue("@secondLastName", p.SecondLastName);
            cmds[0].Parameters.AddWithValue("@birthDate", p.Birthdate);
            cmds[0].Parameters.AddWithValue("@gender", p.Gender);
            cmds[0].Parameters.AddWithValue("@email", p.Email);
            cmds[0].Parameters.AddWithValue("@numberPhone", p.Phone);
            cmds[0].Parameters.AddWithValue("@userID", session); //OJO
            cmds[0].Parameters.AddWithValue("@id", p.Id);


            cmds[1].Parameters.AddWithValue("@nit", t.Nit);
            cmds[1].Parameters.AddWithValue("@id", p.Id);
            cmds[1].Parameters.AddWithValue("@bn", t.businessName);
            cmds[1].Parameters.AddWithValue("@br", t.businessReason);
            cmds[1].Parameters.AddWithValue("@userID", session); //OJO
            cmds[1].Parameters.AddWithValue("@shipping", t.shippingAddress); ;

            try
            {
                ExecuteNBasicCommand(cmds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insertar(Person person, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
