using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class DocumentoNacionalidad{
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static List<DocumentoNacionalidad> GetAllDocumentos()
        {
            List<DocumentoNacionalidad> documentos = new List<DocumentoNacionalidad>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM documento_nacionalidad;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DocumentoNacionalidad documento = new DocumentoNacionalidad();
                        documento.Id = int.Parse(dataReader["id"].ToString());
                        documento.Nombre = dataReader["nombre"].ToString();
                        documentos.Add(documento);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return documentos;
        }
    }
}
