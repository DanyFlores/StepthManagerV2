using CreativaSL.Dll.StephManager.Datos;
using CreativaSL.Dll.StephManager.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Pedido_Negocio
    {

        public List<PedidoDetalle> ObtenerComboClavesProduccion(PedidoDetalle Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                return PD.ObtenerComboClavesProduccion(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ACPedidos(Pedido Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                PD.ACPedidos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerPedidos(Pedido Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                PD.ObtenerPedidos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerPedidosTab(Pedido Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                PD.ObtenerPedidosTab(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerPedidosTabBusq(Pedido Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                PD.ObtenerPedidosTabBusq(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PedidoDetalle> ObtenerDetallePedidoClaves(Pedido Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                return PD.ObtenerDetallePedidoClaves(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PedidoDetalle> ObtenerDetallePedido(Pedido Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                return PD.ObtenerDetallePedido(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PedidoDetalle ObtenerPedidoDetalleComparativo(string IDPedido, string IDProducto, string Conexion)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                return PD.ObtenerPedidoDetalleComparativo(IDPedido, IDProducto, Conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SurtirPedido(Pedido Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                PD.SurtirPedido(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerMaterialesCapacitacion(Pedido Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                PD.ObtenerMaterialesCapacitacion(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerMaterialesCapacitacionBusq(Pedido Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                PD.ObtenerMaterialesCapacitacionBusq(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void AgregarMaterialCapacitacion(PedidoDetalle Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                PD.AgregarMaterialCapacitacion(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReemplazoClaveProducto(PedidoDetalle Datos)
        {
            try
            {
                Pedido_Datos PD = new Pedido_Datos();
                PD.ReemplazoClaveProductoSuc(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FinalizarPedido(Pedido Datos)
        {
            try
            {
                Pedido_Datos PedDat = new Pedido_Datos();
                PedDat.FinalizarPedido(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void AgregarProducto(PedidoDetalle Datos)
        {
            try
            {
                Pedido_Datos PedDat = new Pedido_Datos();
                PedDat.AgregarProducto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
