using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class ComprobanteDomicilio{
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static List<ComprobanteDomicilio> GetAllComprobantes()
        {
            List<ComprobanteDomicilio> comprobantes = new List<ComprobanteDomicilio>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM comprobante_domicilio;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        ComprobanteDomicilio comprobante = new ComprobanteDomicilio();
                        comprobante.Id = int.Parse(dataReader["id"].ToString());
                        comprobante.Nombre = dataReader["nombre"].ToString();
                        comprobantes.Add(comprobante);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return comprobantes;
        }
    }
}
