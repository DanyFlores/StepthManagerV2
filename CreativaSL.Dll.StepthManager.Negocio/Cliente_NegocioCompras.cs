using CreativaSL.Dll.StephManager.Datos;
using CreativaSL.Dll.StephManager.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Cliente_NegocioCompras
    {
        public List<Cliente> ObtenerComboClientes(Cliente Datos)
        {
            try
            {
                Cliente_DatosCompras CD = new Cliente_DatosCompras();
                return CD.ObtenerComboClientes(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
