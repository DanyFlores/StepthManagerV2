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
    public class Promocion_Negocio
    {
        public List<Promocion> ObtenerPromociones(string Conexion, string Busqueda)
        {
            try
            {
                Promocion_Datos PromDat = new Promocion_Datos();
                return PromDat.ObtenerPromociones(Conexion, Busqueda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Promocion ObtenerDetallePromocion(string Conexion, int IDPromocion)
        {
            try
            {
                Promocion_Datos PromDat = new Promocion_Datos();
                return PromDat.ObtenerDetallePromocion(Conexion, IDPromocion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Sucursal> ObtenerSucursalesPromocion(string Conexion)
        {
            try
            {
                Promocion_Datos PromDat = new Promocion_Datos();
                return PromDat.ObtenerSucursalesPromocion(Conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarPromocion(string Conexion, int IDPromocion, string IDUsuario)
        {
            try
            {
                Promocion_Datos PromDat = new Promocion_Datos();
                return PromDat.EliminarPromocion(Conexion, IDPromocion, IDUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CambiarEstatusPromocion(string Conexion, int IDPromocion, string IDUsuario)
        {
            try
            {
                Promocion_Datos PromDat = new Promocion_Datos();
                return PromDat.CambiarEstatusPromocion(Conexion, IDPromocion, IDUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ModificarPromocion(string Conexion, Promocion Datos, string IDUsuario)
        {
            try
            {
                Promocion_Datos PromDat = new Promocion_Datos();
                return PromDat.ModificarPromocion(Conexion, Datos, IDUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AgregarPromocion(string Conexion, Promocion Datos, string IDUsuario)
        {
            try
            {
                Promocion_Datos PromDat = new Promocion_Datos();
                return PromDat.AgregarPromocion(Conexion, Datos, IDUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<PromocionXSucursal> ObtenerPreciosXSucursalPromocion(string Conexion, int IDPromocion)
        {
            try
            {
                Promocion_Datos PromDat = new Promocion_Datos();
                return PromDat.ObtenerPreciosXSucursalPromocion(Conexion, IDPromocion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PromocionServicios> ObtenerPreciosServicioXIDSucIDPromocion(string Conexion, int IDPromocion, string IDSucursal)
        {
            try
            {

                Promocion_Datos PromDat = new Promocion_Datos();
                return PromDat.ObtenerPreciosServicioXIDSucIDPromocion(Conexion, IDPromocion, IDSucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ActualizarPreciosXIDPromocionXIDSucursal(string Conexion, PromocionXSucursal Datos, string IDUsuario)
        {
            try
            {
                Promocion_Datos PromDat = new Promocion_Datos();
                return PromDat.ActualizarPreciosXIDPromocionXIDSucursal(Conexion, Datos, IDUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
