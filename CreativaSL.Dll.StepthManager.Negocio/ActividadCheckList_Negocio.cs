using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class ActividadCheckList_Negocio
    {
        public void ObtenerCatActividadCheck(ActividadesCheckList Datos)
        {
            try
            {
                ActividadesCheckList_Datos ACD = new ActividadesCheckList_Datos();
                ACD.ObtenerCatActividadChechList(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenercheckBusquedaAct(ActividadesCheckList Datos)
        {
            try
            {
                ActividadesCheckList_Datos ACD = new ActividadesCheckList_Datos();
                ACD.ObtenerCheckListActividaBusqueda(Datos);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void ABCActividadChecKList(ActividadesCheckList Datos)
        {
            try
            {
                ActividadesCheckList_Datos ACD = new ActividadesCheckList_Datos();
                ACD.ABCActividadCheckList(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
