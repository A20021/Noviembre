using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class Tramite
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static List<Tramite> GetAllTramites()
        {
            List<Tramite> tramites = new List<Tramite>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM tramite;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Tramite tramite = new Tramite();
                        tramite.Id = int.Parse(dataReader["id"].ToString());
                        tramite.Nombre = dataReader["nombre"].ToString();
                        tramites.Add(tramite);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tramites;
        }

        public static bool Guardar(String nombre){
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO tramite (nombre) Values (@nombre)";
                    cmd.Parameters.AddWithValue("@nombre", nombre);

                    result = cmd.ExecuteNonQuery() == 1;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public bool Editar(String nombre, int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "UPDATE tramite SET nombre = @nombre WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@nombre", nombre);
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
