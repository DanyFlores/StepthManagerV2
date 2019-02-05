using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Cursos_Negocio
    {
        public List<Curso> LlenarComboCursos(Curso Datos)
        {
            try
            {
                Cursos_Datos PD = new Cursos_Datos();
                return PD.LlenarComboCursos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
