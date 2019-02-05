using CreativaSL.Dll.StephManager.Datos;
using CreativaSL.Dll.StephManager.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
   public class ReporteConsumoMaterial_Negocio
    {/// <summary>
    /// Metodo para generar el reporte del consumo de material
    /// </summary>
    /// <param name="Conexion">Conexion de la BD</param>
    /// <param name="FechaInicio">Fecha de inicio del reporte</param>
    /// <param name="FechaFin">Fecha en la que inaliza los datos del reporte</param>
    /// <param name="IDUsuario">Identiicados del usuario que realiza esta operacion</param>
    /// <returns></returns>
        public int GenerarReporteConsumoMaterial(string Conexion, DateTime FechaInicio, DateTime FechaFin, string IDUsuario,string id_sucursal)
        {
            try
            {
                ReporteConsumoMaterial_Datos Datos = new ReporteConsumoMaterial_Datos();
                return Datos.GenerarReporteConsumoMaterial(Conexion, FechaInicio, FechaFin, IDUsuario, id_sucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo con el cual se obtiene la infor referente a un reporte especifico
        /// </summary>
        /// <param name="Conexion">Cadena de conexion con la base de datos</param>
        /// <param name="IDReporte">identiicaador del reporte</param>
        /// <returns></returns>
        public ReporteConsumoMaterial ObtenerDetalleReporteConsumoMaterial(string Conexion, int IDReporte)
        {
            try
            {
                ReporteConsumoMaterial_Datos Datos = new ReporteConsumoMaterial_Datos();
                return Datos.ObtenerDetalleReporteConsumoMaterial(Conexion, IDReporte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo que obtiene todos los reportes que han sido generados
        /// </summary>
        /// <param name="Conexion">Cadena de conecxion con la base de datos</param>
        /// <returns></returns>
        public List<ReporteConsumoMaterial> ObtenerReportesConsumoMaterial(string Conexion)
        {
            try
            {
                ReporteConsumoMaterial_Datos Datos = new ReporteConsumoMaterial_Datos();
                return Datos.ObtenerReportesConsumoMaterial(Conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo que obtiene sucursales
        /// </summary>
        /// <param name="Conexion">Cadena de conexion con la base de datos</param>
        /// <returns></returns>
        public List<ReporteConsumoMaterial> ObtenerSucursales(string Conexion)
        {
            try
            {
                ReporteConsumoMaterial_Datos Datos = new ReporteConsumoMaterial_Datos();
                return Datos.LlenarComboSucursales(Conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo que efectua la busqueda del reporte especidficado
        /// </summary>
        /// <param name="Conexion">Conexion con la BD</param>
        /// <param name="Busqueda">Fecha de busqueda del reporte generado</param>
        /// <returns></returns>
        public List<ReporteConsumoMaterial> BuscarReportesConsumoMaterial(string Conexion,DateTime Busqueda)
        {
            try
            {
                ReporteConsumoMaterial_Datos Datos = new ReporteConsumoMaterial_Datos();
                return Datos.BuscarReportesConsumoMaterial(Conexion,Busqueda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
