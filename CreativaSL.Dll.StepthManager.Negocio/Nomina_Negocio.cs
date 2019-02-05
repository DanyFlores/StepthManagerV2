using CreativaSL.Dll.StephManager.Datos;
using CreativaSL.Dll.StephManager.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Nomina_Negocio
    {
        public void ObtenerEmpleadosNomina(Nomina Datos)
        {
            try
            {
                Nomina_Datos ND = new Nomina_Datos();
                ND.ObtenerEmpleadosNomina(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerConceptosNominaXIDEmpleado(Nomina Datos)
        {
            try
            {
                Nomina_Datos ND = new Nomina_Datos();
                ND.ObtenerConceptosNominaXIDEmpleado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerConceptosFijosXIDEmpleado(Nomina Datos)
        {
            try
            {
                Nomina_Datos ND = new Nomina_Datos();
                ND.ObtenerConceptosFijosXIDEmpleado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerConceptosVariablesXIDEmpleado(Nomina Datos)
        {
            try
            {
                Nomina_Datos ND = new Nomina_Datos();
                ND.ObtenerConceptosVariablesXIDEmpleado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Nomina> ObtenerComboConceptosNomina(Nomina Datos)
        {
            try
            {
                Nomina_Datos ND = new Nomina_Datos();
                return ND.ObtenerComboConceptosNomina(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarConceptoNomina(Nomina Datos)
        {
            try
            {
                Nomina_Datos ND = new Nomina_Datos();
                ND.AgregarConceptoNomina(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void QuitarConceptoNomina(Nomina Datos)
        {
            try
            {
                Nomina_Datos ND = new Nomina_Datos();
                ND.QuitarConceptoNomina(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ObtenerNominas(Nomina Datos)
        {
            try
            {
                Nomina_Datos ND = new Nomina_Datos();
                ND.ObtenerNominas(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GenerarNomina(Nomina Datos)
        {
            try
            {
                Nomina_Datos ND = new Nomina_Datos();
                ND.GenerarNomina(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void ObtenerReporteNominaSaldos(Nomina Datos)
        {
            try
            {
                Nomina_Datos ND = new Nomina_Datos();
                ND.ObtenerReporteNominaSaldos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerReporteNominaDetalle(Nomina Datos)
        {
            try
            {
                Nomina_Datos ND = new Nomina_Datos();
                ND.ObtenerReporteNominaDetalle(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
