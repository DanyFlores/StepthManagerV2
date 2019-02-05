using CreativaSL.Dll.StephManager.Datos;
using CreativaSL.Dll.StephManager.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class TransferenciaMateriales_Negocio
    {
        public List<TransferenciaMateriales> LlenarComboEmpleado(TransferenciaMateriales Datos)
        {
            try
            {
                TransferenciaMateriales_Datos SD = new TransferenciaMateriales_Datos();
                return SD.LlenarComboEmpleado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GenerarTransferencia(string Conexion, string empleadoOrigen, string empleadoDestino, string observaciones, string IDUsuario)
        {
            try
            {
                TransferenciaMateriales_Datos SD = new TransferenciaMateriales_Datos();
                return SD.GenerarTransferencia(Conexion, empleadoOrigen, empleadoDestino, observaciones, IDUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public List<TransferenciaMateriales> ObtenerTransferenciaMateriales(string Conexion)
        {
            try
            {
                TransferenciaMateriales_Datos Datos = new TransferenciaMateriales_Datos();
                return Datos.ObtenerTransferenciaMateriales(Conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TransferenciaMaterialesGeneral ObtenerDetalleReporteTransferenciaMateriales(string Conexion, int IDReporte)
        {
            try
            {
                TransferenciaMateriales_Datos Datos = new TransferenciaMateriales_Datos();
                return Datos.ObtenerDetalleReporteTransferenciaMateriales(Conexion, IDReporte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TransferenciaMateriales> ObtenerTransferenciaMaterialesBusqueda(string Conexion, DateTime Fecha)
        {
            try
            {
                TransferenciaMateriales_Datos Datos = new TransferenciaMateriales_Datos();
                return Datos.ObtenerTransferenciaMaterialesBusqueda(Conexion, Fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
