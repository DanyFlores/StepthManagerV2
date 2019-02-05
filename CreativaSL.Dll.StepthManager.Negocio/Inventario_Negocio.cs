using CreativaSL.Dll.StephManager.Datos;
using CreativaSL.Dll.StephManager.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Inventario_Negocio
    {
        public void ActualizarDatosInventario(Producto Datos)
        {
            try
            {
                Inventario_Datos ID = new Inventario_Datos();
                ID.ActualizarDatosInventario(Datos);
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
                Inventario_Datos ID = new Inventario_Datos();
                ID.NuevoAjusteInventario(Datos);
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
                Inventario_Datos ID = new Inventario_Datos();
                ID.TransferenciaInventario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
