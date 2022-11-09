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
    }
}
