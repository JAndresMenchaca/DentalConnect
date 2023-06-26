using dentalConnectDAO.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace dentalConnectDAO.Implementation
{
    public class QuerysImpl
    {
        //public string connectionString = @"Server=DESKTOP-UKT8QUD;Database=dbDentalConnect;User Id=sa;Password=sotwa;";
        //public string connectionString = @"Server=LAPTOP_ANDRES\SQLEXPRESS;Database=dbDentalConnect;User Id=sa;Password=sotwa";   
        public string connectionString = @"Server=DESKTOP-8LUHPUR;Database=dbDentalConnect;User Id=sa;Password=Mzhyde;";
        public int verifyEmail(string email)
        {
            // Establecer la conexión a la base de datos
            using (var conexion = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                conexion.Open();

                // Ejecutar la consulta
                string consulta = "SELECT COUNT(*) FROM Person p INNER JOIN [User] u ON u.id = p.id WHERE p.email = @email AND u.status = 1";
                int count = 0;

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@email", email);
                    count = (int)comando.ExecuteScalar();
                }

                // Cerrar la conexión
                conexion.Close();

                return count;
            }
            

        }

        public int verifyEmailUpdate(string email, int id)
        {
            // Establecer la conexión a la base de datos                 
            using (var conexion = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                conexion.Open();

                // Ejecutar la consulta
                string consulta = "SELECT COUNT(*) FROM Person p INNER JOIN [User] u ON u.id = p.id WHERE p.email = @email AND u.id != @id AND u.status = 1";
                int count = -1;

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@email", email);
                    count = (int)comando.ExecuteScalar();
                }

                // Cerrar la conexión
                conexion.Close();

                return count;
            }


        }

        public int verifyNumber(string phone)
        {
            // Establecer la conexión a la base de datos
            using (var conexion = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                conexion.Open();

                // Ejecutar la consulta
                string consulta = "SELECT COUNT(*) FROM Person p INNER JOIN [User] u ON u.id = p.id WHERE p.numberPhone = @phone AND u.status = 1";
                int count = 0;

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@phone", phone);
                    count = (int)comando.ExecuteScalar();
                }

                // Cerrar la conexión
                conexion.Close();

                return count;
            }


        }

        public int verifyNumberUpdate(string phone, int id)
        {
            // Establecer la conexión a la base de datos
            using (var conexion = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                conexion.Open();

                // Ejecutar la consulta
                string consulta = "SELECT COUNT(*) FROM Person p INNER JOIN [User] u ON u.id = p.id WHERE p.numberPhone = @phone AND u.id != @id AND u.status = 1";
                int count = -1;

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@phone", phone);
                    count = (int)comando.ExecuteScalar();
                }

                // Cerrar la conexión
                conexion.Close();

                return count;
            }


        }


        public int verifyNameCategory(string name)
        {
            using (var conexion = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                conexion.Open();

                // Ejecutar la consulta
                string consulta = @"SELECT COUNT(*) FROM Category WHERE name = @name AND status = 1";
                int count = 0;

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@name", name);
                    count = (int)comando.ExecuteScalar();
                }

                // Cerrar la conexión
                conexion.Close();

                return count;
            }
        }

        public int verifyNameCategoryUpdate(string name, byte id)
        {
            using (var conexion = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                conexion.Open();

                // Ejecutar la consulta
                string consulta = "SELECT COUNT(*) FROM Category WHERE name = @name AND id != @id AND status = 1";
                int count = -1;

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@name", name);
                    count = (int)comando.ExecuteScalar();
                }

                // Cerrar la conexión
                conexion.Close();

                return count;
            }
        }

        public int verifyNameSupplier(string name)
        {
            using (var conexion = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                conexion.Open();

                // Ejecutar la consulta
                string consulta = @"SELECT COUNT(*) FROM Supplier WHERE name = @name AND status = 1";
                int count = 0;

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@name", name);
                    count = (int)comando.ExecuteScalar();
                }

                // Cerrar la conexión
                conexion.Close();

                return count;
            }
        }

        public int verifyNameSupplierUpdate(string name, byte id)
        {
            using (var conexion = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                conexion.Open();

                // Ejecutar la consulta
                string consulta = "SELECT COUNT(*) FROM Supplier WHERE name = @name AND id != @id AND status = 1";
                int count = -1;

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@name", name);
                    count = (int)comando.ExecuteScalar();
                }

                // Cerrar la conexión
                conexion.Close();

                return count;
            }
        }

        public int verifyUsername(string username)
        {
            using (var conexion = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                conexion.Open();

                // Ejecutar la consulta
                string consulta = @"SELECT COUNT(*) FROM [User] WHERE username = @name AND status = 1";
                int count = 0;

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@name", username);
                    count = (int)comando.ExecuteScalar();
                }

                // Cerrar la conexión
                conexion.Close();

                return count;
            }
        }

        public int verifyNameProduct(string name)
        {
            using (var conexion = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                conexion.Open();

                // Ejecutar la consulta
                string consulta = @"SELECT COUNT(*) FROM Product WHERE name = @name AND status = 1";
                int count = 0;

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@name", name);
                    count = (int)comando.ExecuteScalar();
                }

                // Cerrar la conexión
                conexion.Close();

                return count;
            }
        }

        public int verifyNameProductUpdate(string name, byte id)
        {
            using (var conexion = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                conexion.Open();

                // Ejecutar la consulta
                string consulta = "SELECT COUNT(*) FROM Product WHERE name = @name AND id != @id AND status = 1";
                int count = -1;

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@name", name);
                    count = (int)comando.ExecuteScalar();
                }

                // Cerrar la conexión
                conexion.Close();

                return count;
            }
        }

        public int verifyCiUser(string ci)
        {
            using (var conexion = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                conexion.Open();

                // Ejecutar la consulta
                string consulta = @"SELECT COUNT(*) FROM [User] u INNER JOIN Person p ON p.id = u.id WHERE p.ci = @ci AND u.status = 1";
                int count = 0;

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@ci", ci);
                    count = (int)comando.ExecuteScalar();
                }

                // Cerrar la conexión
                conexion.Close();

                return count;
            }
        }

        public int verifyCiUser2(string ci)
        {
            using (var conexion = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                conexion.Open();

                // Ejecutar la consulta
                string consulta = @"SELECT COUNT(*) FROM Customer u INNER JOIN Person p ON p.id = u.id WHERE p.ci = @ci AND u.status = 1";
                int count = 0;

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@ci", ci);
                    count = (int)comando.ExecuteScalar();
                }

                // Cerrar la conexión
                conexion.Close();

                return count;
            }
        }
        public int verifyCiUserUpdate(string ci, int id)
        {
            using (var conexion = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                conexion.Open();

                // Ejecutar la consulta
                string consulta = "SELECT COUNT(*) FROM [User] u INNER JOIN Person p ON p.id = u.id WHERE p.ci = @ci AND u.status = 1 AND u.id != @id";
                int count = -1;

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@ci", ci);
                    count = (int)comando.ExecuteScalar();
                }

                // Cerrar la conexión
                conexion.Close();

                return count;
            }
        }



        public List<ComboBoxItem> comboCateg()
        {
            List<ComboBoxItem> items = new List<ComboBoxItem>();

            string consulta = @"SELECT name, id
                                FROM Category
                                WHERE status = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(consulta, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombre = reader.GetString(0);
                        byte id = reader.GetByte(1);

                        ComboBoxItem item = new ComboBoxItem
                        {
                            Content = nombre,
                            Tag = id
                        };

                        items.Add(item);
                        //comboBox.Items.Add(item);
                    }
                }
            }
            return items;

        }

        public List<ComboBoxItem> comboSuppl()
        {
            List<ComboBoxItem> items = new List<ComboBoxItem>();

            string consulta = @"SELECT name, id
                                FROM Supplier
                                WHERE status = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(consulta, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombre = reader.GetString(0);
                        byte id = reader.GetByte(1);

                        ComboBoxItem item = new ComboBoxItem
                        {
                            Content = nombre,
                            Tag = id
                        };

                        items.Add(item);
                        //comboBox.Items.Add(item);
                    }
                }
            }
            return items;

        }

        public class PersonComboItem
        {
            public string Content { get; set; }
            public int Tag { get; set; }
        }

        public List<PersonComboItem> comboPerson()
        {
            List<PersonComboItem> items = new List<PersonComboItem>();

            string consulta = @"SELECT ci, p.id
                        FROM Person p
                        LEFT JOIN [User] u ON p.id = u.id
                        LEFT JOIN Customer c ON p.id = c.id
                        WHERE u.id IS NULL AND c.id IS NULL AND p.status = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(consulta, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombre = reader.GetString(0);
                        int id = reader.GetInt32(1);

                        PersonComboItem item = new PersonComboItem
                        {
                            Content = nombre,
                            Tag = id
                        };

                        items.Add(item);
                    }
                }
            }

            return items;
        }

        public string namePerson(int id)
        {
            string nombre = string.Empty;

            using (var conexion = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                conexion.Open();

                // Ejecutar la consulta
                string consulta = "SELECT CONCAT(firstName, ' ', lastName) FROM Person WHERE id = @id ";
                int count = -1;

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);

                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Obtener el valor del primer campo (concatenación de firstName y lastName)
                            nombre = reader.GetString(0);
                        }
                    }
                }

                // Cerrar la conexión
                conexion.Close();
            }

            return nombre;
        }




    }
}
