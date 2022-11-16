using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class Cita{
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Modulo Modulo { get; set; }
        public Ciudadano Ciudadano { get; set; }
        public Tramite Tramite { get; set; }
        public DocumentoNacionalidad DocumentoNacionalidad { get; set; }
        public ComprobanteDomicilio ComprobanteDomicilio { get; set; }

        public static List<Cita> GetAllCitas()
        {
            List<Cita> citas = new List<Cita>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM cita;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Cita cita = new Cita();
                        cita.Id = int.Parse(dataReader["id"].ToString());
                        cita.Fecha = DateTime.Parse(dataReader["fecha"].ToString());

                        Modulo modulo = new Modulo();
                        modulo.Id = int.Parse(dataReader["idModulo"].ToString());
                        cita.Modulo = modulo;

                        Ciudadano ciudadano = new Ciudadano();
                        ciudadano.Id = int.Parse(dataReader["idCiudadano"].ToString());
                        cita.Ciudadano = ciudadano;

                        Tramite tramite = new Tramite();
                        tramite.Id = int.Parse(dataReader["idTramite"].ToString());
                        cita.Tramite = tramite;

                        DocumentoNacionalidad documento = new DocumentoNacionalidad();
                        documento.Id = int.Parse(dataReader["idDocumentoNacionalidad"].ToString());
                        cita.DocumentoNacionalidad = documento;

                        ComprobanteDomicilio comprobante = new ComprobanteDomicilio();
                        comprobante.Id = int.Parse(dataReader["idComprobanteDomicilio"].ToString());
                        cita.ComprobanteDomicilio = comprobante;

                        citas.Add(cita);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return citas;
        }

        public static bool Guardar(DateTime fecha, int idModulo, int idCiudadano, int idTramite, int idDocumentoNacionalidad, int idComprobanteDomicilio)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO cita (fecha, idModulo, idCiudadano, idTramite, idDocumentoNacionalidad, idComprobanteDomicilio) Values (@fecha, @idModulo, @idCiudadano, @idTramite, @idDocumentoNacionalidad, @idComprobanteDomicilio)";
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@idModulo", idModulo);
                    cmd.Parameters.AddWithValue("@idCiudadano", idCiudadano);
                    cmd.Parameters.AddWithValue("@idTramite", idTramite);
                    cmd.Parameters.AddWithValue("@idDocumentoNacionalidad", idDocumentoNacionalidad);
                    cmd.Parameters.AddWithValue("@idComprobanteDomicilio", idComprobanteDomicilio);

                    result = cmd.ExecuteNonQuery() == 1;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public bool Editar(DateTime fecha, int id, int idModulo, int idCiudadano, int idTramite, int idDocumentoNacionalidad, int idComprobanteDomicilio)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "UPDATE cita SET fecha = @fecha, idModulo = @idModulo, idCiudadano = @idCiudadano, idTramite = @idTramite, idDocumentoNacionalidad = @idDocumentoNacionalidad, idComprobanteDomicilio = @idComprobanteDomicilio WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@idModulo", idModulo);
                    cmd.Parameters.AddWithValue("@idCiudadano", idCiudadano);
                    cmd.Parameters.AddWithValue("@idTramite", idTramite);
                    cmd.Parameters.AddWithValue("@idDocumentoNacionalidad", idDocumentoNacionalidad);
                    cmd.Parameters.AddWithValue("@idComprobanteDomicilio", idComprobanteDomicilio);
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
