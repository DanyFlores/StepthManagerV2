using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Vales_Negocio
    {
        public void ActivarVale(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                VD.ActivarVale(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReActivarVale(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                VD.ReActivarVale(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarVale(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                VD.EliminarVale(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void SuspenderVale(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                VD.SuspenderVale(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABCVales(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                VD.ABCVales(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerVales(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                VD.ObtenerVales(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerValesBusqueda(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                VD.ObtenerValesBusqueda(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoVales> ObtenerComboTipoVales(TipoVales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                return VD.ObtenerComboTipoVale(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Producto> ObtenerComboCatProducto(Producto Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                return VD.ObtenerComboCatProducto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Vales ObtenerValeDetalle(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                return VD.ObtenerValeDetalle(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Vales> ObternerCorreosClientes(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                return VD.ObtenerCorreosClientes(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EnviarValeNotificacion(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                VD.EnviarValeNotificaciones(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EnviarVale(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                VD.EnviarVale(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ABCClientesXVales(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                VD.ABCClientesXVales(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EliminarValesXClientes(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                VD.EliminarValexClientes(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObternerValesXClientes(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                VD.ObtenerLlegarGribClientes(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Vales ObtenerValeDetallecORREO(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                return VD.ObtenerValeDetalleCorreos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
