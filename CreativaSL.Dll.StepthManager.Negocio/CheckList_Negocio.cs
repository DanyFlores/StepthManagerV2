using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class CheckList_Negocio
    {

        public List<TipoChechkList> LlenarComboTipoCheck(TipoChechkList Datos)
        {
            try
            {
                CheckList_Datos ED = new  CheckList_Datos();
                return ED.LlenarComboTipoCheckList(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerCatCheck(ChechkList Datos)
        {
            try
            {
                CheckList_Datos CD = new CheckList_Datos();
                CD.ObtenerCatChechList(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenercheckBusqueda(ChechkList Datos)
        {
            try
            {
                CheckList_Datos CD = new CheckList_Datos();
                CD.ObtenerCheckListBusqueda(Datos);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public void ABCChecKList(ChechkList Datos)
        {
            try
            {
                CheckList_Datos CD = new CheckList_Datos();
                CD.ABCCheckList(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
