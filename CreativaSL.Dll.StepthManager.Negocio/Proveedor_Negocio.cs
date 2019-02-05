using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Proveedor_Negocio
    {
        public List<Proveedor> LlenarComboProveedores(Proveedor Datos)
        {
            try
            {
                Proveedor_Datos PD = new Proveedor_Datos();
                return PD.LlenarComboProveedores(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Proveedor> LlenarComboProveedoresMobiliario(Proveedor Datos)
        {
            try
            {
                Proveedor_Datos PD = new Proveedor_Datos();
                return PD.LlenarComboProveedoresMobiliario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerDatosFiscalesXProveedor(Proveedor Datos)
        {
            try
            {
                Proveedor_Datos PD = new Proveedor_Datos();
                PD.ObtenerDatosFiscalesXProveedor(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
