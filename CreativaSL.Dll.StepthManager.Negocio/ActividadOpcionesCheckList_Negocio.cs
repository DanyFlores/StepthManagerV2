using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class ActividadOpcionesCheckList_Negocio
    {
        public void ObtenerCatActividadOpcionesCheck(ActividadOpcionesCheckList Datos)
        {
            try
            {
                ActividadesOpcionesCheckList_Datos ACD = new ActividadesOpcionesCheckList_Datos();
                ACD.ObtenerCatActividadOpcionesChechList(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ABCActividadOpcinesChecKList(ActividadOpcionesCheckList Datos)
        {
            try
            {
                ActividadesOpcionesCheckList_Datos ACD = new ActividadesOpcionesCheckList_Datos();
                ACD.ABCActividadOpcionCheckList(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
