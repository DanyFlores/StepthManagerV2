using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Producto_Negocio
    {

        public void ABCCatProductos(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ABCCatProductos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void ObtenerCatProductos(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ObtenerCatProductos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatProductosBusqueda(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ObtenerCatProductosBusqueda(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatTipoMonederoXIDProducto(TipoMonedero Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ObtenerCatTipoMonederoXIDProducto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Producto ObtenerDatosProductoXID(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                return PD.ObtenerDatosProductoXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Proveedor> ObtenerProveedoresDisponiblesXIDProducto(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                return PD.ObtenerProveedoresDisponiblesXIDProducto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Proveedor> ObtenerProveedorXIDProducto(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                return PD.ObtenerProveedorXIDProducto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerBusquedaProductosServicios(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ObtenerBusquedaProductosServicios(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDatosProductoCompraXID(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ObtenerDatosProductoCompraXID(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerProductosInventario(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ObtenerProductosInventario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerProductosInventarioMatriz(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ObtenerProductosInventarioMatriz(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public void AInventarioEXCEL(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.AInventarioEXCEL(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        //** Tarjetas de regalo **//

        public void ACTarjetasRegalo(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ACTarjetasRegalo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatTarjetasRegalo(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ObtenerCatTarjetasRegalo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatTarjetasRegaloBusqueda(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ObtenerCatTarjetasRegaloBusqueda(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarTarjetasRegalo(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.EliminarTarjetasRegalo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EnviarTarjetasRegalo(Producto Datos, string IDSucursalMatriz)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.EnviarTarjetasRegalo(Datos, IDSucursalMatriz);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerCatProductosStockMinimo(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ObtenerCatProductosStockMinimo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerCatProductosStockMaximo(Producto Datos)
        {
            try
            {
                Producto_Datos PD = new Producto_Datos();
                PD.ObtenerCatProductosStockMaximo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Producto ObtenerPreciosXIDSucursal(Producto Datos)
        {
            try
            {
                Producto_Datos ProdDatos = new Producto_Datos();
                return ProdDatos.ObtenerPreciosXIDSucursal(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GuardarPrecioXIDSucursal(Producto Datos)
        {
            try
            {
                Producto_Datos ProdDatos = new Producto_Datos();
                return ProdDatos.GuardarPrecioXIDSucursal(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
