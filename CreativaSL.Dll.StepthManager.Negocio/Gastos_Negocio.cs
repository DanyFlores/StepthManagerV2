
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Gastos_Negocio
    {
        public void ObtenerCatGastos(Gastos Datos)
        {
            try
            {
                Gastos_Datos GD = new Gastos_Datos();
                GD.ObtenerCatGastos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Rubro> ObtenerComboRubros(Rubro Datos)
        {
            try
            {
                Gastos_Datos GD = new Gastos_Datos();
                return GD.ObtenerComboRubros(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Subrubro> ObtenerComboSubrubros(Subrubro Datos)
        {
            try
            {
                Gastos_Datos GD = new Gastos_Datos();
                return GD.ObtenerComboSubrubros(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ACCatGastos(Gastos Datos)
        {
            try
            {
                Gastos_Datos GD = new Gastos_Datos();
                GD.ACCatGastos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarGasto(Gastos Datos)
        {
            try
            {
                Gastos_Datos GD = new Gastos_Datos();
                GD.EliminarGasto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
