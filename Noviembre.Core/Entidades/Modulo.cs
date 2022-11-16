using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class Modulo{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Horario { get; set; }
        public string Referencias { get; set; }
        public Municipio Municipio { get; set; }

        public static List<Modulo> GetAllModulos()
        {
            List<Modulo> modulos = new List<Modulo>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM modulo;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Modulo modulo = new Modulo();
                        modulo.Id = int.Parse(dataReader["id"].ToString());
                        modulo.Nombre = dataReader["nombre"].ToString();
                        modulo.Direccion = dataReader["direccion"].ToString();
                        modulo.Horario = dataReader["horario"].ToString();
                        modulo.Referencias = dataReader["referencias"].ToString();

                        Municipio municipio = new Municipio();
                        municipio.Id = int.Parse(dataReader["idMunicipio"].ToString());
                        modulo.Municipio = municipio;
                        modulos.Add(modulo);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return modulos;
        }

        public static bool Guardar(String nombre, String direccion, String horario, String referencias, int idMunicipio)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO modulo (nombre, direccion, horario, referencias, idMunicipio) Values (@nombre, @direccion, @horario, @referencias, @idMunicipio)";
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@horario", horario);
                    cmd.Parameters.AddWithValue("@referencias", referencias);
                    cmd.Parameters.AddWithValue("@idMunicipio", idMunicipio);

                    result = cmd.ExecuteNonQuery() == 1;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public bool Editar(String nombre, int id, String direccion, String horario, String referencias, int idMunicipio)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "UPDATE estado SET nombre = @nombre, direccion = @direccion, horario = @horario, referencias = @referencias, idMunicipio = @idMunicipio WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@horario", horario);
                    cmd.Parameters.AddWithValue("@referencias", referencias);
                    cmd.Parameters.AddWithValue("@idMunicipio", idMunicipio);
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
