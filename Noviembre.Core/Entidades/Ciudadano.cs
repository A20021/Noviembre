using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class Ciudadano{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }

        public static List<Ciudadano> GetAllCiudadanos()
        {
            List<Ciudadano> ciudadanos = new List<Ciudadano>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM ciudadano;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Ciudadano ciudadano = new Ciudadano();
                        ciudadano.Id = int.Parse(dataReader["id"].ToString());
                        ciudadano.Nombre = dataReader["nombre"].ToString();
                        ciudadano.ApellidoPaterno = dataReader["apellidoPaterno"].ToString();
                        ciudadano.ApellidoMaterno = dataReader["apellidoMaterno"].ToString();
                        ciudadano.Telefono = dataReader["telefono"].ToString();
                        ciudadano.Direccion = dataReader["direccion"].ToString();
                        ciudadano.Email = dataReader["email"].ToString();
                        ciudadanos.Add(ciudadano);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ciudadanos;
        }

        public static bool Guardar(String nombre,String apellidoPaterno,String apellidoMaterno,String telefono,String direccion,String email)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO ciudadano (nombre,apellidoPaterno,apellidoMaterno,telefono,direccion,email) Values (@nombre,@apellidoPaterno,@apellidoMaterno,@telefono,@direccion,@email)";
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                    cmd.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@email", email);

                    result = cmd.ExecuteNonQuery() == 1;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public bool Editar(String nombre, int id, String apellidoPaterno, String apellidoMaterno, String telefono, String direccion, String email)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "UPDATE ciudadano SET nombre = @nombre, apellidoPaterno = @apellidoPaterno, apellidoMaterno = @apellidoMaterno, telefono = @telefono, direccion = @direccion, email = @email WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                    cmd.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@id", id);

                    result = cmd.ExecuteNonQuery() == 1;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

    }
}
