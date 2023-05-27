﻿using dentalConnectDAO.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int verifyEmailUpdate(string email, byte id)
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

        public int verifyNumberUpdate(string phone, byte id)
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
    }
}
