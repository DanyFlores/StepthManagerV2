using CreativaSL.Dll.StephManager.Global;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Datos
{
    public class Inventario_Datos
    {
        public void ActualizarDatosInventario(Producto Datos)
        {
            try
            {
                Datos.Completado = false;
                object [] Parametros = { Datos.IDProducto, Datos.IDSucursal, Datos.RequiereStock, Datos.StockMinimo, Datos.StockMaximo, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Produccion.spCSLDB_set_ActualizarDatosInventario", Parametros);
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
        
        public void NuevoAjusteInventario(Producto Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDProducto, Datos.IDSucursal, Datos.EsPositivo, Datos.CantidadAjuste, Datos.MotivoAjuste, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Produccion.spCSLDB_set_InventarioAjuste", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    Datos.Resultado = Resultado;
                    if (Resultado == 1)
                        Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TransferenciaInventario(Transferencia Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDSucursalOrigen, Datos.IDSucursalDestino, Datos.IDProducto, Datos.Cantidad, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "Produccion.spCSLDB_set_InventarioTransferencia", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    Datos.Resultado = Resultado;
                    if (Resultado == 1)
                        Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
