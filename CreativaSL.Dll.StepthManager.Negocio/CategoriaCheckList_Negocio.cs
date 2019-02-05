using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class CategoriaCheckList_Negocio
    {

        public List<CategoriaCheckList> LlenarComboCategoriaCheck(CategoriaCheckList Datos)
        {
            try
            {
                CategoriaCheckList_Datos CCD = new CategoriaCheckList_Datos();
                return CCD.LlenarComboCategoriaCheckList(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ABCCategoriaChecKList(CategoriaCheckList Datos)
        {
            try
            {
                CategoriaCheckList_Datos CCD = new CategoriaCheckList_Datos();
                CCD.ABCCategoriaActividades(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
