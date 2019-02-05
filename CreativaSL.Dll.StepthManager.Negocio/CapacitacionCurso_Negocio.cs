using CreativaSL.Dll.StephManager.Datos;
using CreativaSL.Dll.StephManager.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class CapacitacionCurso_Negocio
    {
        public void AbcCapacitacionCurso(CapacitacionCurso Datos)
        {
            try
            {
                CapacitacionCurso_Datos CD = new CapacitacionCurso_Datos();
                CD.ABCCapacitacionCurso(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AbcInscripcionCurso(CapacitacionCurso Datos)
        {
            try
            {
                CapacitacionCurso_Datos CD = new CapacitacionCurso_Datos();
                CD.ABCInscripcionCurso(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void AbcCalificaciones(CapacitacionCurso Datos)
        {
            try
            {
                CapacitacionCurso_Datos CD = new CapacitacionCurso_Datos();
                CD.ABCCalificaciones(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CancelarCompra(Compra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                CD.CancelarCompra(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCursosCreados(CapacitacionCurso Datos)
        {
            try
            {
                CapacitacionCurso_Datos CD = new CapacitacionCurso_Datos();
                CD.ObtenerCursosCreados(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCursosCreadoBusq(CapacitacionCurso Datos)
        {
            try
            {
                CapacitacionCurso_Datos CD = new CapacitacionCurso_Datos();
                CD.ObtenerCursosCreadosBusq(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Compra ObtenerDatosCompra(Compra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                return CD.ObtenerDatosCompra(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Compra ObtenerDatosCompraDetalle(Compra Datos)
        {
            try
            {
                Compra_Datos CD = new Compra_Datos();
                return CD.ObtenerDatosCompraDetalle(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActivarCursos(CapacitacionCurso Datos)
        {
            try
            {
                CapacitacionCurso_Datos CD = new CapacitacionCurso_Datos();
                CD.ActivarCurso(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ConcluirCursos(CapacitacionCurso Datos)
        {
            try
            {
                CapacitacionCurso_Datos CD = new CapacitacionCurso_Datos();
                CD.ConcluirCurso(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerParticipante(CapacitacionCurso Datos)
        {
            try
            {
                CapacitacionCurso_Datos CD = new CapacitacionCurso_Datos();
                CD.ObtenerLlegarGribParticipante(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerTemasSubTemas(CapacitacionCurso Datos)
        {
            try
            {
                CapacitacionCurso_Datos CD = new CapacitacionCurso_Datos();
                CD.ObtenerTemasSubTemas(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
