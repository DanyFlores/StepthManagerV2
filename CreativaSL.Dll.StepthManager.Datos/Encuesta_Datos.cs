using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Data.SqlTypes;
using System.IO;

namespace CreativaSL.Dll.StephManager.Datos
{
    public class Encuesta_Datos
    {

        public void ACEncuestas(Encuesta Datos)
        {
            try
            {
                Datos.Completado = false;
                int Resultado = 0;
                SqlDataReader dr = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_ac_Encuestas",
                     new SqlParameter("@NuevoRegistro", Datos.NuevoRegistro),
                     new SqlParameter("@IDEncuesta", Datos.IDEncuesta),
                     new SqlParameter("@Titulo", Datos.Titulo),
                     new SqlParameter("@IDTipoEncuesta", Datos.IDTipoEncuesta),
                     new SqlParameter("@Incentivo", Datos.Incentivo),
                     new SqlParameter("@RequierePeriodo", Datos.RequierePeriodo),
                     new SqlParameter("@FechaInicio", Datos.FechaInicio),
                     new SqlParameter("@FechaFin", Datos.FechaFin),
                     new SqlParameter("@TablaPreguntas", Datos.TablaPreguntas),
                     new SqlParameter("@TablaRespuestas", Datos.TablaRespuestas),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                while (dr.Read())
                {
                    Resultado = !dr.IsDBNull(dr.GetOrdinal("Resultado")) ? dr.GetInt32(dr.GetOrdinal("Resultado")) : 0;
                    if (Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.IDEncuesta = dr.GetString(dr.GetOrdinal("IDEncuesta"));
                    }
                    else
                    {
                        Datos.Completado = false;
                        throw new Exception(dr.GetString(dr.GetOrdinal("Mensaje")));
                    }
                    break;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarEncuesta(Encuesta Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_b_Encuestas", Datos.IDEncuesta, Datos.IDUsuario);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoEncuesta> LlenarComboTipoEncuesta(TipoEncuesta Datos)
        {
            try
            {
                List<TipoEncuesta> Lista = new List<TipoEncuesta>();
                TipoEncuesta Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboTipoEncuesta", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new TipoEncuesta();
                    Item.IDTipoEncuesta = Dr.IsDBNull(Dr.GetOrdinal("IDTipoEncuesta")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDTipoEncuesta"));
                    Item.Descripcion = Dr.IsDBNull(Dr.GetOrdinal("Descripcion")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.RequierePeriodo = Dr.IsDBNull(Dr.GetOrdinal("RequierePeriodo")) ? false : Dr.GetBoolean(Dr.GetOrdinal("RequierePeriodo"));
                    Lista.Add(Item);
                }
                Dr.Close();
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoPregunta> LlenarComboTipoPregunta(TipoPregunta Datos)
        {
            try
            {
                List<TipoPregunta> Lista = new List<TipoPregunta>();
                TipoPregunta Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboTipoPregunta", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new TipoPregunta();
                    Item.IDTipoPregunta = Dr.IsDBNull(Dr.GetOrdinal("IDTipoPregunta")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDTipoPregunta"));
                    Item.Descripcion = Dr.IsDBNull(Dr.GetOrdinal("Descripcion")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.OpcionMultiple = Dr.IsDBNull(Dr.GetOrdinal("OpcionMultiple")) ? false : Dr.GetBoolean(Dr.GetOrdinal("OpcionMultiple"));
                    Lista.Add(Item);
                }
                Dr.Close();
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerEncuestas(Encuesta Datos)
        {
            try
            {
                object[] Parametros = { Datos.BuscarTodos, Datos.SoloVigentes };
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_EncuestasActivas", Parametros);
                Datos.TablaDatos = new DataTable();
                if (ds != null)
                    if (ds.Tables.Count == 1)
                        Datos.TablaDatos = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public void ObtenerEncuestasTab(Encuesta Datos)
        {
            try
            {
                object[] Parametros = { Datos.Opcion, Datos.BuscarTodos };
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_EncuestasTab", Parametros);
                Datos.TablaDatos = new DataTable();
                if (ds != null)
                    if (ds.Tables.Count == 1)
                        Datos.TablaDatos = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerEncuestasTabBusqueda(Encuesta Datos)
        {
            try
            {
                object[] Parametros = { Datos.Opcion, Datos.BuscarTodos, Datos.Titulo };
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_EncuestasTabBusqueda", Parametros);
                Datos.TablaDatos = new DataTable();
                if (ds != null)
                    if (ds.Tables.Count == 1)
                        Datos.TablaDatos = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Encuesta ObtenerDetalleEncuestaXID(Encuesta Datos)
        {
            try
            {
                Encuesta DatosResultado = new Encuesta();
                DatosResultado.Completado = false;
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_DetalleEncuesta", Datos.IDEncuesta);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 2)
                    {
                        DataTableReader Dr = Ds.Tables[0].CreateDataReader();
                        while (Dr.Read())
                        {
                            DatosResultado.IDEncuesta = !Dr.IsDBNull(Dr.GetOrdinal("IDEncuesta")) ? Dr.GetString(Dr.GetOrdinal("IDEncuesta")) : string.Empty;
                            DatosResultado.IDTipoEncuesta = !Dr.IsDBNull(Dr.GetOrdinal("IDTipoEncuesta")) ? Dr.GetInt32(Dr.GetOrdinal("IDTipoEncuesta")) : 0;
                            DatosResultado.Incentivo = !Dr.IsDBNull(Dr.GetOrdinal("Incentivo")) ? Dr.GetDecimal(Dr.GetOrdinal("Incentivo")) : 0;
                            DatosResultado.Titulo = !Dr.IsDBNull(Dr.GetOrdinal("Titulo")) ? Dr.GetString(Dr.GetOrdinal("Titulo")) : string.Empty;
                            DatosResultado.RequierePeriodo = !Dr.IsDBNull(Dr.GetOrdinal("RequierePeriodo")) ? Dr.GetBoolean(Dr.GetOrdinal("RequierePeriodo")) : false;
                            if (DatosResultado.RequierePeriodo)
                            {
                                DatosResultado.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("FechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaInicio")) : DateTime.Today;
                                DatosResultado.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("FechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("FechaFin")) : DateTime.Today;
                            }
                            DatosResultado.ListaPreguntas = new List<Pregunta>();
                        }

                        List<Pregunta> ListaPreguntas = new List<Pregunta>();
                        Pregunta Item;
                        DataTableReader DTR = Ds.Tables[1].CreateDataReader();
                        DataTable Tbl1 = Ds.Tables[1];
                        while (DTR.Read())
                        {
                            Item = new Pregunta();
                            Item.ListaRespuestas = new List<Respuesta>();
                            //Item.IDPregunta = !DTR.IsDBNull(DTR.GetOrdinal("IDPregunta")) ? DTR.GetString(Dr.GetOrdinal("IDPregunta")) : string.Empty;
                            //Item.IDTipoPregunta = !DTR.IsDBNull(DTR.GetOrdinal("IDTipoPregunta")) ? DTR.GetInt32(Dr.GetOrdinal("IDTipoPregunta")) : 0;
                            //Item.RequiereRespuestas = !DTR.IsDBNull(DTR.GetOrdinal("OpcionMultiple")) ? DTR.GetBoolean(Dr.GetOrdinal("OpcionMultiple")) : false;
                            //Item.Titulo = !DTR.IsDBNull(DTR.GetOrdinal("Pregunta")) ? DTR.GetString(Dr.GetOrdinal("Pregunta")) : string.Empty;
                            //Item.EsRequerida = !DTR.IsDBNull(DTR.GetOrdinal("EsRequerida")) ? DTR.GetBoolean(Dr.GetOrdinal("EsRequerida")) : false;
                            //XmlReader Respuestas = (XmlReader)DTR.GetValue(DTR.GetOrdinal("TablaRespuestas"));

                            Item.IDPregunta = !DTR.IsDBNull(0) ? DTR.GetString(0) : string.Empty;
                            Item.IDTipoPregunta = !DTR.IsDBNull(1) ? DTR.GetInt32(1) : 0;
                            Item.TipoPreguntaDesc = !DTR.IsDBNull(6) ? DTR.GetString(6) : string.Empty;
                            Item.RequiereRespuestas = !DTR.IsDBNull(2) ? DTR.GetBoolean(2) : false;
                            Item.Titulo = !DTR.IsDBNull(3) ? DTR.GetString(3) : string.Empty;
                            Item.EsRequerida = !DTR.IsDBNull(4) ? DTR.GetBoolean(4) : false;
                            if (Item.RequiereRespuestas)
                            {
                                string Aux = DTR.GetString(5);
                                Aux = string.Format("<Main>{0}</Main>", Aux);
                                XmlDocument xm = new XmlDocument();
                                xm.LoadXml(Aux);
                                XmlNodeList Registros = xm.GetElementsByTagName("Main");
                                XmlNodeList Lista = ((XmlElement)Registros[0]).GetElementsByTagName("C");
                                List<Respuesta> ListaRespuestas = new List<Respuesta>();
                                Respuesta ItemResp;
                                foreach (XmlElement Nodo in Lista)
                                {
                                    ItemResp = new Respuesta();
                                    XmlNodeList IDRespuesta = Nodo.GetElementsByTagName("IDRespuesta");
                                    XmlNodeList Respuesta = Nodo.GetElementsByTagName("Respuesta");
                                    ItemResp.IDRespuesta = IDRespuesta[0].InnerText;
                                    ItemResp.Titulo = Respuesta[0].InnerText;
                                    Item.ListaRespuestas.Add(ItemResp);
                                }
                            }
                            else
                            {
                                Item.ListaRespuestas = new List<Respuesta>();
                            }
                            ListaPreguntas.Add(Item);
                        }
                        DatosResultado.ListaPreguntas = ListaPreguntas;
                        Dr.Close();
                    }
                }
                return DatosResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActivarEncuesta(Encuesta Datos)
        {
            try
            {
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_ActivarEncuesta", Datos.IDEncuesta, Datos.IDUsuario);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SuspenderEncuesta(Encuesta Datos)
        {
            try
            {
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_SuspenderEncuesta", Datos.IDEncuesta, Datos.IDUsuario);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int EnviarNotificacionEncuestas(Encuesta datos)
        {
            try
            {
                int Resultado = 0;
                DataSet Ds = SqlHelper.ExecuteDataset(datos.Conexion, CommandType.StoredProcedure, "spCSLDB_set_NotificacionesEnviarEncuestas",
                new SqlParameter("@IDEncuesta", datos.IDEncuesta),
                new SqlParameter("@NombreNotificacion", datos.Titulo),
                new SqlParameter("@Usuario", datos.IDUsuario));
                if (Ds != null)
                {
                    if (Ds.Tables.Count > 0)
                    {
                        int.TryParse(Ds.Tables[0].Rows[0][0].ToString(), out Resultado);
                        if (Resultado == 1)
                        {
                            if (Ds.Tables.Count == 2)
                            {
                                datos.Completado = true;
                                datos.tablaNotificaciones = Ds.Tables[1];
                            }
                        }
                        else if (Resultado == 2)
                        {
                            if (Ds.Tables.Count == 2)
                            {
                                datos.Completado = true;
                                datos.tablaNotificaciones = Ds.Tables[1];
                            }
                            datos.Resultado = Resultado;
                        }
                        else if (Resultado == -1)
                        {
                            if (Ds.Tables.Count == 2)
                            {
                                datos.Completado = false;
                                datos.tablaNotificaciones = Ds.Tables[1];
                            }
                            datos.Resultado = Resultado;
                        }
                        else if (Resultado == 0)
                        {
                            if (Ds.Tables.Count == 2)
                            {
                                datos.Completado = false;
                                datos.tablaNotificaciones = Ds.Tables[1];
                            }
                            datos.Resultado = Resultado;
                        }
                    }
                }
                return datos.Resultado = Resultado;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
