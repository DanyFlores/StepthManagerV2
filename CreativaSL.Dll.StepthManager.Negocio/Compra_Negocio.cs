using CreativaSL.Dll.StephManager.Datos;
using CreativaSL.Dll.StephManager.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Compra_Negocio
    {
        public void ACCompras(Compra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                CD.ACCompras(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ACComprasMobiliario(Compra Datos)
        {
            try
            {
                Compra_Datos CN = new Compra_Datos();
                CN.ACComprasMobiliario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CancelarCompra(Compra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                CD.CancelarCompra(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CancelarCompraMobiliario(Compra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                CD.CancelarCompraMobiliario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerComprasPendientes(Compra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                CD.ObtenerComprasPendientes(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerComprasMobiliarioPendientes(Compra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                CD.ObtenerComprasMobiliarioPendientes(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerComprasPendientesBusq(Compra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                CD.ObtenerComprasPendientesBusq(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerComprasMobiliarioPendientesBusq(Compra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                CD.ObtenerComprasMobiliarioPendientesBusq(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Compra ObtenerDatosCompra(Compra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                return CD.ObtenerDatosCompra(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Compra ObtenerDatosCompraMobiliario(Compra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                return CD.ObtenerDatosCompraMobiliario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Compra ObtenerDatosCompraDetalle(Compra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                return CD.ObtenerDatosCompraDetalle(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Compra ObtenerDatosCompraMobiliarioDetalle(Compra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                return CD.ObtenerDatosCompraMobiliarioDetalle(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ProcesarCompra(Compra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                CD.ProcesarCompra(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ProcesarCompraMobiliario(Compra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                CD.ProcesarCompraMobiliario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerPagosCompraMobiliario(Compra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                CD.ObtenerPagosCompraMobiliario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerPagosCompra(Compra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                CD.ObtenerPagosCompra(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ACPagosCompraMobiliario(PagoCompra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                CD.ACPagosCompraMobiliario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ACPagosCompra(PagoCompra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                CD.ACPagosCompra(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CancelarPagoCompraMobiliario(PagoCompra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                CD.CancelarPagoCompraMobiliario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CancelarPagoCompra(PagoCompra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                CD.CancelarPagoCompra(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
