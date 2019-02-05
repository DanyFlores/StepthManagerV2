using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;

namespace CreativaSL.Dll.StephManager.Datos
{
    public class Catalogo_Datos
    {
        public void ABCCatFamiliaProductos(FamiliaProducto Datos)
        {
            try
            {
                object [] parametros = {Datos.Opcion, Datos.IDFamiliaProducto, Datos.Descripcion.ToUpper(), Datos.IDUsuario};
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_CatFamiliasProductos", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    int IDRegistro = 0;
                    if (int.TryParse(Resultado.ToString(), out IDRegistro))
                    {
                        if (IDRegistro > 0)
                        {
                            Datos.Completado = true;
                            Datos.IDFamiliaProducto = IDRegistro;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABCCatPadecimientos(Padecimiento Datos)
        {
            try
            {
                
                object[] parametros = { Datos.Opcion, Datos.IDPadecimiento, Datos.Descripcion.ToUpper(), Datos.Validar , Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_CatPadecimientos", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    if (!string.IsNullOrEmpty(Resultado.ToString()))
                    {   
                        Datos.Completado = true;
                        Datos.IDPadecimiento = Resultado.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABCCatProveedores(Proveedor Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDProveedor, Datos.RazonSocial.ToUpper(), Datos.NombreComercial.ToUpper(), Datos.Representante.ToUpper(),
                                        Datos.RegimenFiscal.ToUpper(), Datos.Correo.ToUpper(), Datos.Telefono, Datos.DirCalle.ToUpper(), Datos.DirColonia.ToUpper(), Datos.DirNumero,
                                        Datos.CodigoPostal, Datos.IDPais, Datos.IDEstado, Datos.IDMunicipio, Datos.RFC.ToUpper(), Datos.Mobiliario, Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_CatProveedores", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    if (!string.IsNullOrEmpty(Resultado.ToString()))
                    {
                        Datos.Completado = true;
                        Datos.IDProveedor = Resultado.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABCCatSucursales(Sucursal Datos)
        {
            try
            {
                SqlDataReader Resultado = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_abc_CatSucursales",
                      new SqlParameter("@Opcion", Datos.Opcion),
                      new SqlParameter("@IDSucursal", Datos.IDSucursal),
                      new SqlParameter("@IDEmpresa", Datos.IDEmpresa),
                      new SqlParameter("@IDTipoSucursal", Datos.IDTipoSucursal),
                      new SqlParameter("@NombreSucursal", Datos.NombreSucursal.ToUpper()),
                      new SqlParameter("@Direccion", Datos.Direccion.ToUpper()),
                      new SqlParameter("@Telefono", Datos.Telefono),
                      new SqlParameter("@IDMunicipio", Datos.IDMunicipio),
                      new SqlParameter("@IDEstado", Datos.IDEstado),
                      new SqlParameter("@IDPais", Datos.IDPais),
                      new SqlParameter("@CodigoPostal", Datos.CodigoPostal),
                      new SqlParameter("@PorcentajeMonedero", Datos.PorcentajeMonedero),
                      new SqlParameter("@TablaSucursalesHorario", Datos.TablaSucursalesHorario),
                      new SqlParameter("@RFC", Datos.rfc),
                      new SqlParameter("@NombreRepresentante", Datos.Representante),
                      new SqlParameter("@RegimenFiscal", Datos.RegimenFiscal),
                      new SqlParameter("@IDUsuario", Datos.IDUsuario)
                      );
                Datos.Completado = false;
                if (Resultado != null)
                {
                    if (!string.IsNullOrEmpty(Resultado.ToString()))
                    {
                        Datos.Completado = true;
                        Datos.IDSucursal = Resultado.ToString();
                    }
                }
                Resultado.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABCCatCurso(Curso Datos)
        {
            try
            {
                Datos.Completado = false;
                int Resultado = 0;
                SqlDataReader dr = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_abc_CatCursos",
                     new SqlParameter("@Opcion", Datos.Opcion),
                     new SqlParameter("@IDCurso", Datos.IDCurso),
                     new SqlParameter("@Nombre", Datos.Nombre.ToUpper()),
                     new SqlParameter("@Descripcion", Datos.Descripcion.ToUpper()),
                     new SqlParameter("@ObjetivoGeneral", Datos.ObjetivoGeneral.ToUpper()),
                     new SqlParameter("@Horas", Datos.Horas),
                     new SqlParameter("@CalificacionMinAprobatoria", Datos.CalificacionMinAprobatoria),
                     new SqlParameter("@TablaTema", Datos.TablaTema),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                while (dr.Read())
                {
                    // Resultado = !dr.IsDBNull(dr.GetOrdinal("Resultado")) ? dr.GetInt32(dr.GetOrdinal("Resultado")) : 0;
                    if (Resultado == 0)
                    {
                        Datos.Completado = true;
                        Datos.IDCurso = dr.GetString(dr.GetOrdinal("IDCurso"));
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

        public void ABCCatTemasCurso(TemasCurso Datos)
        {
            try
            {
                Datos.Completado = false;
                int Resultado = 0;
                SqlDataReader dr = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_abc_CatTemasCurso",
                     new SqlParameter("@Opcion", Datos.Opcion),
                     new SqlParameter("@IDTemasCursos", Datos.IDTemaCurso),
                     new SqlParameter("@Descripcion", Datos.Descripcion.ToUpper()),
                     new SqlParameter("@TablaSubTemas", Datos.TablaSubTemas),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                while (dr.Read())
                {
                    if (Resultado == 0)
                    {
                        Datos.Completado = true;
                        Datos.IDTemaCurso = dr.GetString(dr.GetOrdinal("IDTemasCursos"));
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

        public void ABCCatPuesto(Puestos Datos)
        {
            try
            {
                Datos.Completado = false;
                int Resultado = 0;
                SqlDataReader dr = SqlHelper.ExecuteReader(Datos.Conexion, CommandType.StoredProcedure, "spCSLDB_abc_CatPuestos",
                     new SqlParameter("@Opcion", Datos.Opcion),
                     new SqlParameter("@IDPuesto", Datos.IDPuesto),
                     new SqlParameter("@Descripcion", Datos.Descripcion.ToUpper()),
                     new SqlParameter("@TablaCategoriaPuesto", Datos.TablaCategoriaPuesto),
                     new SqlParameter("@EsGerente", Datos.EsGerente),
                     new SqlParameter("@IDUsuario", Datos.IDUsuario)
                     );
                while (dr.Read())
                {
                    if (Resultado == 0)
                    {
                        //Datos.Completado = true;
                        Datos.IDPuesto = dr.GetInt32(dr.GetOrdinal("IDPuesto"));
                        if (Datos.IDPuesto > 0)
                            Datos.Completado = true;
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

        public void ABCHorarioTurnos(Horario Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDTurno, Datos.NombreTurno.ToUpper(), Datos.HoraEntrada, Datos.HoraSalida, Datos.InicioValidezEntrada,
                                        Datos.FinValidezEntrada, Datos.InicioValidezSalida, Datos.FinValidezSalida,
                                        Datos.ToleraciaLlegadaTarde, Datos.ToleranciaSalidaTemprano, Datos.DiasDeTrabajo, Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_HorarioTurno", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    int IDRegistro = 0;
                    if (int.TryParse(Resultado.ToString(), out IDRegistro))
                    {
                        if (IDRegistro > 0)
                        {
                            Datos.Completado = true;
                            Datos.IDTurno = IDRegistro;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABCGastosRubros(Rubro Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDRubro, Datos.Descripcion.ToUpper(), Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_GastosCatRubros", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    int IDRegistro = 0;
                    if (int.TryParse(Resultado.ToString(), out IDRegistro))
                    {
                        if (IDRegistro > 0)
                        {
                            Datos.Completado = true;
                            Datos.IDRubro = IDRegistro;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABCGastosSubRubro(Subrubro Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDSubrubro, Datos.IDRubro, Datos.Descripcion.ToUpper(), Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_GastosSubRubro", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    if (!string.IsNullOrEmpty(Resultado.ToString()))
                    {
                        Datos.Completado = true;
                        Datos.IDSubrubro = Resultado.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABCInstructores(Instructor Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDInstructor, Datos.Nombre.ToUpper(), Datos.ApellidoPat.ToUpper(), Datos.ApellidoMat.ToUpper(),
                                        Datos.IDGenero, Datos.FechaNac, Datos.Correo.ToUpper(), Datos.Telefono, Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_Instructor", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    if (!string.IsNullOrEmpty(Resultado.ToString()))
                    {
                        Datos.Completado = true;
                        Datos.IDInstructor = Resultado.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABCTipoMobiliario(TipoMobiliario Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDTipoMobiliario, Datos.Descripcion.ToUpper(), Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_Mobiliario_Tipo", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    if (!string.IsNullOrEmpty(Resultado.ToString()))
                    {
                        Datos.Completado = true;
                        Datos.IDTipoMobiliario = Resultado.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABCconceptoNomina(ConceptoNomina Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDConceptoNomina, Datos.Descripcion.ToUpper(), Datos.Calculado, Datos.SumaResta, Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_CatConceptoNomina", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    int IDRegistro = 0;
                    if (int.TryParse(Resultado.ToString(), out IDRegistro))
                    {
                        if (IDRegistro > 0)
                        {
                            Datos.Completado = true;
                            Datos.IDConceptoNomina = IDRegistro;
                        }
                        Datos.IDConceptoNomina = IDRegistro;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ABCProductoExtras(Producto Datos)
        {
            try
            {
                object[] Parametros = { Datos.Opcion, Datos.IDProducto, Datos.Clave, Datos.NombreProducto, Datos.Imagen, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_CatServicioExtra", Parametros);
                if (Result != null)
                {
                    if (!string.IsNullOrEmpty(Result.ToString()))
                    {
                        int Resultado = 0;
                        if (!int.TryParse(Result.ToString(), out Resultado))
                        {
                            Datos.Completado = true;
                            Datos.IDProducto = Result.ToString();
                        }
                        else
                        {
                            Datos.Resultado = Resultado;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ABCDiasFestivos(DiasFestivos Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDDiasFestivos, Datos.Descripcion.ToUpper(), Datos.Fecha, Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_Nomina_DiasFestivos", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    if (!string.IsNullOrEmpty(Resultado.ToString()))
                    {
                        int Resultados = 0;
                        if (!int.TryParse(Resultado.ToString(), out Resultados))
                        {
                            Datos.Completado = true;
                            Datos.IDDiasFestivos = Resultado.ToString();
                        }
                        else
                        {
                            Datos.Resultado = Resultados;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ABCBanco(Banco Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDBanco, Datos.Descripcion.ToUpper(), Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_CatBanco", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    int ID = 0;
                    if (int.TryParse(Resultado.ToString(), out ID))
                    {
                        if (ID > 0)
                        {
                            Datos.Completado = true;
                            Datos.IDBanco = ID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ABCCatTagInteres(TagInteres Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDTagInteres, Datos.Descripcion.ToUpper(), Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_CatTagInteres", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    if (!string.IsNullOrEmpty(Resultado.ToString()))
                    {
                        Datos.Completado = true;
                        Datos.IDTagInteres = Resultado.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABCCatTarjetaMonedero(TarjetaMonedero Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDTarjeta, Datos.Folio, Datos.IDTipoMonedero, Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_CatTarjetasMonedero", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    if (!string.IsNullOrEmpty(Resultado.ToString()))
                    {
                        Datos.Completado = true;
                        Datos.IDTarjeta = Resultado.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABCCatTipoMonedero(TipoMonedero Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDTipoMonedero, Datos.Descripcion.ToUpper(), Datos.PuntosMinimos, Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_CatTipoMonedero", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    int IDRegistro = 0;
                    if (int.TryParse(Resultado.ToString(), out IDRegistro))
                    {
                        if (IDRegistro > 0)
                        {
                            Datos.Completado = true;
                            Datos.IDTipoMonedero = IDRegistro;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABCCatUnidadMedida(UnidadMedida Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDUnidadMedida, Datos.Descripcion.ToUpper(), Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_CatUnidadMedida", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    int IDRegistro = 0;
                    if (int.TryParse(Resultado.ToString(), out IDRegistro))
                    {
                        if (IDRegistro > 0)
                        {
                            Datos.Completado = true;
                            Datos.IDUnidadMedida = IDRegistro;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatFamiliaProductos(FamiliaProducto Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatFamiliasProductos", Datos.Opcion);
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

        public void ObtenerCatGeneros(Genero Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatGenero", Datos.Opcion);
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

        public void ObtenerCatPadecimiento(Padecimiento Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatPadecimientos", Datos.Opcion);
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

        public void ObtenerCatProveedores(Proveedor Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatProveedor");
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

        public void ObtenerCatSucursales(Sucursal Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatSucursales");
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

        public List<Sucursal> ObtenerSucursalXIDSucursal(Sucursal Datos)
        {
            try
            {
                List<Sucursal> Lista = new List<Sucursal>();
                Sucursal Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_CatSucursalHorarioXID", Datos.IDSucursal);
                while (Dr.Read())
                {
                    Item = new Sucursal();
                    Item.Dia = Dr.IsDBNull(Dr.GetOrdinal("Dia")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("Dia"));
                    Item.HoraEntrada = Dr.IsDBNull(Dr.GetOrdinal("HoraEntrada")) ? DateTime.Today.TimeOfDay : Dr.GetTimeSpan(Dr.GetOrdinal("HoraEntrada"));
                    Item.HoraSalida = Dr.IsDBNull(Dr.GetOrdinal("HoraSalida")) ? DateTime.Today.TimeOfDay : Dr.GetTimeSpan(Dr.GetOrdinal("HoraSalida"));
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

        public void ObtenerCatCursos(Curso Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatCursos", Datos.BuscarTodos);
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

        public void ObtenerCatTemasCursos(TemasCurso Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatTemasCurso", Datos.BuscarTodos);
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

        public void ObtenerCatPuesto(Puestos Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatPuesto", Datos.BuscarTodos);
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

        public void ObtenerCatHorarios(Horario Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatHorariosTurnos", Datos.BuscarTodos);
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

        public void ObtenerCatGastosRubros(Rubro Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatGastosRubros", Datos.Opcion);
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

        public void ObtenerCatGastosSubRubros(Subrubro Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_GastosCatSubRubro", Datos.Opcion);
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

        public void ObtenerCatInstructor(Instructor Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_Intructor");
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

        public void ObtenerTipoMobiliario(TipoMobiliario Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_Mobiliario_Tipo");
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
        public void ObtenerconceptoNominas(ConceptoNomina Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatConceptoNomina");
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
        public void ObtenerProductoExtra(Producto Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatProductosExtras");
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
        public void ObtenerDiasFestivos(DiasFestivos Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_Nomina_DiasFestivos");
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
        public void ObtenerTipoUsuario(TipoUsuario Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_TipoUsuario");
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
        public void ObtenerBancos(Banco Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatBanco");
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
        public void ObtenerCatTagInteres(TagInteres Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatTagInteres", Datos.Opcion);
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
        
        public void ObtenerCatTarjetaMonedero(TarjetaMonedero Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatTarjetaMonedero", Datos.Opcion);
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

        public void ObtenerCatTipoMetrica(TipoMetrica Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatTipoMetrica", Datos.Opcion);
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

        public void ObtenerCatTipoMonedero(TipoMonedero Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatTipoMonedero", Datos.Opcion);
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

        public void ObtenerCatTipoProducto(TipoProducto Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatTipoProducto", Datos.Opcion);
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

        public List<TipoRegistro> ObtenerCatTipoRegistro(TipoRegistro Datos)
        {
            try
            {
                List<TipoRegistro> Lista = new List<TipoRegistro>();
                TipoRegistro Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_CatTipoRegistro", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new TipoRegistro();
                    Item.IDTipoRegistro = Dr.IsDBNull(Dr.GetOrdinal("IDTipoRegistro")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDTipoRegistro"));
                    Item.Descripcion = Dr.IsDBNull(Dr.GetOrdinal("Descripcion")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Descripcion"));
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

        public void ObtenerCatTipoUso(TipoUso Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatTipoUso", Datos.Opcion);
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

        public void ObtenerCatUnidadMedida(UnidadMedida Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatUnidadMedida", Datos.Opcion);
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

        public void ObtenerComboCatEmpresa(CatEmpresa Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ComboCatEmpresas");
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

        public void ObtenerComboCatTipoSucursal(TipoSucursal Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ComboCatTipoSucursal");
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

        public void ObtenerComboCatPais(CatPais Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ComboCatPaises");
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

        public void ObtenerComboCatEstado(CatEstado Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ComboCatEstados", Datos.IDPais);
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

        public void ObtenerComboCatMunicipio(CatMunicipio Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ComboCatMunicipio", Datos.IDPais, Datos.IDEstado);
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

        public List<CategoriasPuesto> ObtenerComboCatCategorias(CategoriasPuesto Datos)
        {
            try
            {
                List<CategoriasPuesto> Lista = new List<CategoriasPuesto>();
                CategoriasPuesto Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCategoriasPuestos", Datos.IDPuesto, Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new CategoriasPuesto();
                    Item.IDCategoria = Dr.IsDBNull(Dr.GetOrdinal("IDCategoria")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDCategoria"));
                    Item.Descripcion = Dr.IsDBNull(Dr.GetOrdinal("Descripcion")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.SueldoBase = Dr.IsDBNull(Dr.GetOrdinal("SueldoBase")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("SueldoBase"));
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

        public List<Puestos> ObtenerComboCatPuestos(Puestos Datos)
        {
            try
            {
                List<Puestos> Lista = new List<Puestos>();
                Puestos Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCatPuestos", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item= new Puestos();
                    Item.IDPuesto = Dr.IsDBNull(Dr.GetOrdinal("IDPuesto")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDPuesto"));
                    Item.Descripcion = Dr.IsDBNull(Dr.GetOrdinal("Descripcion")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Descripcion"));
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

        public List<Producto> ObtenerComboCatSERVICIO(Producto Datos)
        {
            try
            {
                List<Producto> Lista = new List<Producto>();
                Producto Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCatServicio", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new Producto();
                    Item.IDProducto = Dr.IsDBNull(Dr.GetOrdinal("IDProducto")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDProducto"));
                    Item.NombreServicio = Dr.IsDBNull(Dr.GetOrdinal("NombreServicio")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NombreServicio"));
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

        public DateTime ObtenerFechaSistema(string Conexion)
        {
            try
            {
                DateTime FechaSistema = new DateTime();
                object FechaServidor = SqlHelper.ExecuteScalar(Conexion, "spCSLDB_get_FechaHoraServidor");
                if (FechaServidor != null)
                {
                    DateTime.TryParse(FechaServidor.ToString(), out FechaSistema);
                }
                return FechaSistema;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SubTemas> LlenarGridSubTemas(SubTemas Datos)
        {
            try
            {
                List<SubTemas> Lista = new List<SubTemas>();
                SubTemas Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_SubTemaXID", Datos.IDTemaCurso);
                while (Dr.Read())
                {
                    Item = new SubTemas();
                    Item.IDSubTemas = Dr.IsDBNull(Dr.GetOrdinal("IDSubTema")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDSubTema"));
                    // Item.IDTemaCurso = Dr.IsDBNull(Dr.GetOrdinal("IDTemaCurso")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDTemaCurso"));
                    Item.IDServicio = Dr.IsDBNull(Dr.GetOrdinal("IDServicio")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDServicio"));
                    Item.NombreServicio = Dr.IsDBNull(Dr.GetOrdinal("NombreServicio")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NombreServicio"));
                    Item.Descripcion = Dr.IsDBNull(Dr.GetOrdinal("Descripcion")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.PracticasSugeridas = Dr.IsDBNull(Dr.GetOrdinal("PracticaSugeridas")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("PracticaSugeridas"));
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

        public List<TemasCurso> LlenarGridTemasCursos(TemasCurso Datos)
        {
            try
            {
                List<TemasCurso> Lista = new List<TemasCurso>();
                TemasCurso Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_TemaCursos", Datos.IDTemaCurso);
                while (Dr.Read())
                {
                    Item = new TemasCurso();
                    Item.IDTemaCurso = Dr.IsDBNull(Dr.GetOrdinal("IDTemaCurso")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDTemaCurso"));
                    Item.Descripcion = Dr.IsDBNull(Dr.GetOrdinal("Descripcion")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.Seleccionado = Dr.IsDBNull(Dr.GetOrdinal("Seleccionado")) ? false : Dr.GetBoolean(Dr.GetOrdinal("Seleccionado"));
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

        public List<TemasCurso> LlenarGridTemaXCursosXID(TemasCurso Datos)
        {
            try
            {
                List<TemasCurso> Lista = new List<TemasCurso>();
                TemasCurso Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_TemasXCursosXID", Datos.IDTemaCurso);
                while (Dr.Read())
                {
                    Item = new TemasCurso();
                    Item.IDTemaXCurso = Dr.IsDBNull(Dr.GetOrdinal("IDTemaXCurso")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDTemaXCurso"));
                    Item.IDCurso = Dr.IsDBNull(Dr.GetOrdinal("IDCurso")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDCurso"));
                    Item.IDTemaCurso = Dr.IsDBNull(Dr.GetOrdinal("IDTema")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDTema"));
                    Item.Descripcion = Dr.IsDBNull(Dr.GetOrdinal("Descripcion")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Descripcion"));
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

        public List<CategoriasPuesto> LlenarGridCategoriaPuestoXID(CategoriasPuesto Datos)
        {
            try
            {
                List<CategoriasPuesto> Lista = new List<CategoriasPuesto>();
                CategoriasPuesto Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_CatCategoriaPuestoXID", Datos.IDPuesto);
                while (Dr.Read())
                {
                    Item = new CategoriasPuesto();
                    Item.IDCategoria = Dr.IsDBNull(Dr.GetOrdinal("IDCategoria")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDCategoria"));
                    Item.IDPuesto = Dr.IsDBNull(Dr.GetOrdinal("IDPuesto")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDPuesto"));
                    Item.Descripcion = Dr.IsDBNull(Dr.GetOrdinal("Descripcion")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.SueldoBase = Dr.IsDBNull(Dr.GetOrdinal("SueldoBase")) ? 0 : Dr.GetDecimal(Dr.GetOrdinal("SueldoBase"));
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
        public void AEmpleadoXSucursal(Sucursal Datos)
        {
            try
            {
                object[] parametros = { Datos.IDSucursal, Datos.IDEmpleado, Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_a_CatSucursales", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    if (!string.IsNullOrEmpty(Resultado.ToString()))
                    {
                        int Resultados = 0;
                        if (!int.TryParse(Resultado.ToString(), out Resultados))
                        {
                            Datos.Completado = true;
                            Datos.IDSucursal = Resultado.ToString();
                        }
                        else
                        {
                            Datos.Resultado = Resultados;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Usuario> ObtenerComboEmpleado(Usuario Datos)
        {
            try
            {
                List<Usuario> Lista = new List<Usuario>();
                Usuario Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboEmpleadosXEsGerente", Datos.IncluirSelect, Datos.IDSucursalActual);
                while (Dr.Read())
                {
                    Item = new Usuario();
                    Item.IDEmpleado = Dr.IsDBNull(Dr.GetOrdinal("IDEmpleado")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDEmpleado"));
                    Item.Nombre = Dr.IsDBNull(Dr.GetOrdinal("NombreEmpleado")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("NombreEmpleado"));
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
        public void ABCCategoriaActividades(CategoriaCheckList Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDCategoriaChe, Datos.Descripcion.ToUpper(), Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_CatCategoriaCheckList", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    int ID = 0;
                    if (int.TryParse(Resultado.ToString(), out ID))
                    {
                        if (ID > 0)
                        {
                            Datos.Completado = true;
                            Datos.IDCategoriaChe = ID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerCategoriaActividad(CategoriaCheckList Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatCategoriaCheckList");
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
        public List<CategoriaCheckList> ObtenerComboCategoriaCheck(CategoriaCheckList Datos)
        {
            try
            {
                List<CategoriaCheckList> Lista = new List<CategoriaCheckList>();
                CategoriaCheckList Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCategoriaCheck", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new CategoriaCheckList();
                    Item.IDCategoriaChe = Dr.IsDBNull(Dr.GetOrdinal("IDCategoriaCheck")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDCategoriaCheck"));
                    Item.Descripcion = Dr.IsDBNull(Dr.GetOrdinal("Descripcion")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Descripcion"));
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
        public void ABCActividadesCheck(ActividadesCheckList Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDActividades, Datos.IDCategoriaChe, Datos.Orden, Datos.Descripcion.ToUpper(), Datos.IDUsuario };
                object Resultado = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_abc_ActividadCheckList", parametros);
                Datos.Completado = false;
                if (Resultado != null)
                {
                    int ID = 0;
                    if (int.TryParse(Resultado.ToString(), out ID))
                    {
                        if (ID > 0)
                        {
                            Datos.Completado = true;
                            Datos.IDActividades = ID;
                        }
                        Datos.Resultado = ID;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerActividadCk(ActividadesCheckList Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_CatActividadCheckList");
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
    }
}
