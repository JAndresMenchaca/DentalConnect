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
        public int change(string password)
        {
            query = @"UPDATE [User] SET password = HASHBYTES('MD5', @password) , lastUpdate=CURRENT_TIMESTAMP, userID=@userID
                        WHERE id = @userID";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;
            command.Parameters.AddWithValue("@userID", Session.SessionID);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(User t)
        {
            query = @"UPDATE [User] SET status=0, lastUpdate=CURRENT_TIMESTAMP, userID=@userID
                        WHERE id = @id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@userID", Session.SessionID);
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

        public User Get(byte id)
        {
            User user = null;

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
            u.username,
            u.role,
            ISNULL(u.lastUpdate, GETDATE()),
            u.registerDate,
            u.status,
            u.userID
            FROM
                Person p
            INNER JOIN
                [User] u ON p.id = u.id
            WHERE u.id = @id";

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable table = GetTable(command);
                if (table.Rows.Count > 0)
                {
                    byte ID = byte.Parse(table.Rows[0][0].ToString());
                    string ci = table.Rows[0][1].ToString();
                    string name = table.Rows[0][2].ToString();
                    string lastName = table.Rows[0][3].ToString();
                    string secondLastName = table.Rows[0][4].ToString();
                    DateTime birthdate = DateTime.Parse(table.Rows[0][5].ToString());
                    char gender = Convert.ToChar(table.Rows[0][6]);
                    string email = table.Rows[0][7].ToString();
                    string phone = table.Rows[0][8].ToString();
                    string username = table.Rows[0][9].ToString();
                    string role = table.Rows[0][10].ToString();
                    DateTime lastUpdate = DateTime.Parse(table.Rows[0][11].ToString());
                    DateTime registerDate = DateTime.Parse(table.Rows[0][12].ToString());

                    byte status = byte.Parse(table.Rows[0][13].ToString());
                    byte idUser = byte.Parse(table.Rows[0][14].ToString());

                    user = new User(ID, ci, name, lastName, secondLastName, birthdate,
                         gender, phone, email, username, role,
                         status, registerDate, lastUpdate, idUser);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;

        }

        public int Insert(User t)
        {
            query = @"BEGIN TRANSACTION;

                        DECLARE @personaId INT;

                        INSERT INTO Person (ci, firstName, lastName, secondLastName, birthDate, gender, email, numberPhone, userID)
                        VALUES (@ci, @name, @lastName, @secondLastName, @date, @gender, @email, @phone, @userID);

                        SET @personaId = SCOPE_IDENTITY();

                        INSERT INTO [User] (id,username, password, role, userID)
                        VALUES (@personaId, @username, HASHBYTES('MD5', @password) , @role, @userID);
                        COMMIT;";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@ci", t.Ci);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@lastName", t.LastName);
            command.Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            command.Parameters.AddWithValue("@date", t.Birthdate);
            command.Parameters.AddWithValue("@gender", t.Gender);
            command.Parameters.AddWithValue("@email", t.Email);
            command.Parameters.AddWithValue("@phone", t.Phone);

            command.Parameters.AddWithValue("@username", t.Username);
            command.Parameters.AddWithValue("@password", t.Password).SqlDbType = SqlDbType.VarChar;
            command.Parameters.AddWithValue("@role", t.Role);
            
            command.Parameters.AddWithValue("@userID", Session.SessionID);


            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Login(string username, string password)
        {
            query = @"SELECT id, username, role, changePassword
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
            query = @"SELECT *
                      FROM vwUser
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

        public int Update(User t)
        {
            query = @"UPDATE Person
                        SET
                            ci = @ci,
                            firstName = @name,
                            LastName = @lastName,
                            secondLastName = @SecondLastName,
                            email = @email,
                            numberPhone = @number,
                            birthDate = @date,
                            gender = @gender,
	                        lastUpdate=CURRENT_TIMESTAMP, 
	                        userID= @userId
                        WHERE
                            id = @id;

                        UPDATE [User]
                        SET
	                        lastUpdate=CURRENT_TIMESTAMP, 
	                        userID=@userId,
                            role = @role
                        WHERE
                            id = @id";

            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@ci", t.Ci);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@lastName", t.LastName);
            command.Parameters.AddWithValue("@SecondLastName", t.SecondLastName);
            command.Parameters.AddWithValue("@email", t.Email);
            command.Parameters.AddWithValue("@number", t.Phone);
            command.Parameters.AddWithValue("@date", t.Birthdate);
            command.Parameters.AddWithValue("@gender", t.Gender);
            command.Parameters.AddWithValue("@role", t.Role);
            command.Parameters.AddWithValue("@userId", Session.SessionID);
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

        public bool Verify(string nameUser)
        {
            query = @"SELECT COUNT(*) FROM User WHERE userName = @nombreUsuario";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@nombreUsuario", nameUser);
            DataTable table = GetTable(command);
            byte num = byte.Parse(table.Rows[0][0].ToString());
            bool band = true;
            if (num > 0)
            {
                band = false;
            }
            return band;
        }
        public void changePassword()
        {
            query = @"UPDATE Person
                        SET
	                        lastUpdate=CURRENT_TIMESTAMP, 
	                        userID= @userId
                        WHERE
                            id = @userId;

                        UPDATE [User]
                        SET
							changePassword = 1,
	                        lastUpdate = CURRENT_TIMESTAMP, 
	                        userID=@userId
                        WHERE
                            id = @userId";
            SqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@userId", Session.SessionID);
            ExecuteBasicCommand(command);

        }

        public int verifyEmail(string email)
        {
            query = "SELECT COUNT(*) FROM Person WHERE email = @email";
            int count;

            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@email", email);
            count = (int)command.ExecuteScalar();
            ExecuteBasicCommand(command); 
            return count;
        }
    }
}
