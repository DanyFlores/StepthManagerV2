using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class CheckListResultado_Negocio
    {

        public void ObtenerCatCheckResultado(ChechkListResultado Datos)
        {
            try
            {
                CheckListResultado_Datos CD = new CheckListResultado_Datos();
                CD.ObtenerCatChechListResul(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ChechkListResultado> ObtenerCheckListRespuestaDetalle(ChechkListResultado Datos)
        {
            try
            {
                CheckListResultado_Datos MRD = new CheckListResultado_Datos();
                return MRD.ObtenerCheckListDetalle(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ChechkListResultado> ObtenerCheckListActividadDetalle(ChechkListResultado Datos)
        {
            try
            {
                CheckListResultado_Datos MRD = new CheckListResultado_Datos();
                return MRD.ObtenerCheckListDetalleActivadad(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
