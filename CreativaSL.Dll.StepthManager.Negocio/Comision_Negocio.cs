using CreativaSL.Dll.StephManager.Datos;
using CreativaSL.Dll.StephManager.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Comision_Negocio
    {
        public List<Comision> ObtenerComisionesXIDCategoria(Comision Datos)
        {
            try
            {
                Comision_Datos CD = new Comision_Datos();
                return CD.ObtenerComisionesXIDCategoria(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Comision> ObtenerComisionesXEmpleado(Comision Datos)
        {
            try
            {
                Comision_Datos CD = new Comision_Datos();
                return CD.ObtenerComisionesXEmpleado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Comision> ObtenerComboTipoComision(Comision Datos)
        {
            try
            {
                Comision_Datos CD = new Comision_Datos();
                return CD.ObtenerComboTipoComision(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ACReglasComision(Comision Datos)
        {
            try
            {
                Comision_Datos CD = new Comision_Datos();
                CD.ACReglasComision(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarReglasComision(Comision Datos)
        {
            try
            {
                Comision_Datos CD = new Comision_Datos();
                CD.EliminarReglasComision(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public void ObtenerResumenComisiones(Comision Datos)
        {
            try
            {
                Comision_Datos CD = new Comision_Datos();
                CD.ObtenerResumenComisiones(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerResumenComisionesBusq(Comision Datos)
        {
            try
            {
                Comision_Datos CD = new Comision_Datos();
                CD.ObtenerResumenComisionesBusq(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerComisionesXRango(Comision Datos)
        {
            try
            {
                Comision_Datos CD = new Comision_Datos();
                CD.ObtenerComisionesXRango(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void AResumenComision(Comision Datos)
        {
            try
            {
                Comision_Datos CD = new Comision_Datos();
                CD.AResumenComision(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerReporteComisiones(Comision Datos)
        {
            try
            {
                Comision_Datos CD = new Comision_Datos();
                CD.ObtenerReporteComisiones(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
