using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Empleado_Negocio
    {
        public List<Usuario> LlenarComboEmpleado(Usuario Datos)
        {
            try
            {
                Empleado_Datos PD = new Empleado_Datos();
                return PD.LlenarComboEmpleado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
