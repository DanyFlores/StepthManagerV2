using CreativaSL.Dll.StephManager.Datos;
using CreativaSL.Dll.StephManager.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class MobiliarioResguardo_Negocio
    {
        public MobiliarioResguardo ObtenerExistentes(MobiliarioResguardo Datos)
        {
            try
            {
                MobiliarioResguardo_Datos MRD = new MobiliarioResguardo_Datos();
                return MRD.ObtenerExistentes(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ACMobiliarioResguardo(MobiliarioResguardo Datos)
        {
            try
            {
                MobiliarioResguardo_Datos MRD = new MobiliarioResguardo_Datos();
                MRD.ACMobiliarioResguardo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatMobiliarioResguardo(MobiliarioResguardo Datos)
        {
            try
            {
                MobiliarioResguardo_Datos MRD = new MobiliarioResguardo_Datos();
                MRD.ObtenerCatMobiliarioResguardo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarMobiliarioResguardo(MobiliarioResguardo Datos)
        {
            try
            {
                MobiliarioResguardo_Datos MRD = new MobiliarioResguardo_Datos();
                MRD.EliminarMobiliarioResguardo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MobiliarioResguardo> ObtenerDetalleMobiliarioResguardo(MobiliarioResguardo Datos)
        {
            try
            {
                MobiliarioResguardo_Datos MRD = new MobiliarioResguardo_Datos();
                return MRD.ObtenerDetalleMobiliarioResguardo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MobiliarioResguardo ObtenerDatosDetalleMobiliario(MobiliarioResguardo Datos)
        {
            try
            {
                MobiliarioResguardo_Datos MRD = new MobiliarioResguardo_Datos();
                return MRD.ObtenerDetalleMobiliarios(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EnviarMobiliarioResguardo(MobiliarioResguardo Datos)
        {
            try
            {
                MobiliarioResguardo_Datos MRD = new MobiliarioResguardo_Datos();
                MRD.EnviarMobiliarioResguardo(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatMobiliarioResguardoBusqueda(MobiliarioResguardo Datos)
        {
            try
            {
                MobiliarioResguardo_Datos MRD = new MobiliarioResguardo_Datos();
                MRD.ObtenerCatMobiliarioResguaardoBusqueda(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Mobiliario> ObtenerMobiliarioResguardoDetalle(MobiliarioResguardo Datos)
        {
            try
            {
                MobiliarioResguardo_Datos MRD = new MobiliarioResguardo_Datos();
                return MRD.ObtenerMobiliarioResguardoDetalle(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
