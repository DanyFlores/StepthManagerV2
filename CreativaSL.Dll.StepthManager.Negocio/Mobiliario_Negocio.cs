using CreativaSL.Dll.StephManager.Datos;
using CreativaSL.Dll.StephManager.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Mobiliario_Negocio
    {
        public void ACCatMobiliario(Mobiliario Datos)
        {
            try
            {
                Mobiliario_Datos MD = new Mobiliario_Datos();
                MD.ACCatMobiliario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarMobiliario(Mobiliario Datos)
        {
            try
            {
                Mobiliario_Datos MD = new Mobiliario_Datos();
                MD.EliminarMobiliario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatMobiliario(Mobiliario Datos)
        {
            try
            {
                Mobiliario_Datos MN = new Mobiliario_Datos();
                MN.ObtenerCatMobiliario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerCatMobiliarioBusqueda(Mobiliario Datos)
        {
            try
            {
                Mobiliario_Datos MN = new Mobiliario_Datos();
                MN.ObtenerCatMobiliarioBusqueda(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerBusquedaMobiliario(Mobiliario Datos)
        {
            try
            {
                Mobiliario_Datos MD = new Mobiliario_Datos();
                MD.ObtenerBusquedaMobiliario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Proveedor> ObtenerProveedorXIDMobiliario(Mobiliario Datos)
        {
            try
            {
                Mobiliario_Datos MD = new Mobiliario_Datos();
                return MD.ObtenerProveedorXIDMobiliario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Proveedor> ObtenerProveedoresDisponiblesXIDMobiliario(Mobiliario Datos)
        {
            try
            {
                Mobiliario_Datos MD = new Mobiliario_Datos();
                return MD.ObtenerProveedoresDisponiblesXIDMobiliario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerBusquedaMobiliario_Res(Mobiliario Datos)
        {
            try
            {
                Mobiliario_Datos MD = new Mobiliario_Datos();
                MD.ObtenerBusquedaMobiliario_Res(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerMobiliarioAsignadoXIDSuc(Mobiliario Datos)
        {
            try
            {
                Mobiliario_Datos MD = new Mobiliario_Datos();
                MD.ObtenerMobiliarioAsignadoXIDSuc(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BajaMobiliario(Mobiliario Datos)
        {
            try
            {
                Mobiliario_Datos MD = new Mobiliario_Datos();
                MD.BajaMobiliario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void TransferenciaMobiliario(Mobiliario Datos)
        {
            try
            {
                Mobiliario_Datos MD = new Mobiliario_Datos();
                MD.TransferenciaMobiliario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
