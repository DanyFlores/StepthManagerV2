using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Cliente_Negocio
    {

        public void ABCCatClientes(Cliente Datos)
        {
            try
            {
                Cliente_Datos cd = new Cliente_Datos();
                cd.ABCCatClientes(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AsignarMonederoCliente(Cliente Datos)
        {
            try
            {
                Cliente_Datos CD = new Cliente_Datos();
                CD.AsignarMonederoCliente(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerBusquedaClientes(Cliente Datos)
        {
            try
            {
                Cliente_Datos CD = new Cliente_Datos();
                CD.ObtenerBusquedaClientes(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatClientes(Cliente Datos)
        {
            try
            {
                Cliente_Datos cd = new Cliente_Datos();
                cd.ObtenerCatClientes(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatClientesBusqueda(Cliente Datos)
        {
            try
            {
                Cliente_Datos cd = new Cliente_Datos();
                cd.ObtenerCatClientesBusqueda(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TagInteres> ObtenerCatTagInteresXIDCliente(TagInteres Datos)
        {
            try
            {
                Cliente_Datos cd = new Cliente_Datos();
                return cd.ObtenerCatTagInteresXIDCliente(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TarjetaMonedero> ObtenerCatTarjetasDisponibles(TarjetaMonedero Datos)
        {
            try
            {
                Cliente_Datos cd = new Cliente_Datos();
                return cd.ObtenerCatTarjetasDisponibles(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Padecimiento> ObtenerCatPadecimientosXIDCliente(Padecimiento Datos)
        {
            try
            {
                Cliente_Datos cd = new Cliente_Datos();
                return cd.ObtenerCatPadecimientosXIDCliente(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<Cliente> ObtenerComboClientes(Cliente Datos)
        {
            try
            {
                Cliente_Datos CD = new Cliente_Datos();
                return CD.ObtenerComboClientes(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CambiarFolioTarjetaMonedero(TarjetaMonedero Datos)
        {
            try
            {
                Cliente_Datos CD = new Cliente_Datos();
                CD.CambiarFolioTarjetaMonedero(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SaldoTarjetaMonedero(TarjetaMonedero Datos)
        {
            try
            {
                Cliente_Datos CD = new Cliente_Datos();
                CD.SaldoTarjetaMonedero(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente ObtenerHistoriaCliente(Cliente Datos)
        {
            try
            {
                Cliente_Datos CD = new Cliente_Datos();
                return CD.ObtenerHistorialCita(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente ObtenerHistoriaCompras(Cliente Datos)
        {
            try
            {
                Cliente_Datos CD = new Cliente_Datos();
                return CD.ObtenerHistorialCompra(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente ObtenerHistoriaSucursales(Cliente Datos)
        {
            try
            {
                Cliente_Datos CD = new Cliente_Datos();
                return CD.ObtenerHistorialSucursal(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
