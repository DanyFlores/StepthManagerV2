using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Sucursal_Negocio 
    {
        public List<Sucursal> LlenarComboCatSucursales(Sucursal Datos)
        {
            try
            {
                Sucursal_Datos SD = new Sucursal_Datos();
                return SD.LlenarComboCatSucursales(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Sucursal> LlenarComboCatSucursalesPuntoDeVenta(Sucursal Datos)
        {
            try
            {
                Sucursal_Datos SD = new Sucursal_Datos();
                return SD.LlenarComboCatSucursalesPuntoDeVenta(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
