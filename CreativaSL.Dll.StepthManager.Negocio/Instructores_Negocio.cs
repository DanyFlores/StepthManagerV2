using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Instructores_Negocio
    {
        public List<Instructor> LlenarComboInstructores(Instructor Datos)
        {
            try
            {
                Instructores_Datos PD = new Instructores_Datos();
                return PD.LlenarComboInstructores(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
