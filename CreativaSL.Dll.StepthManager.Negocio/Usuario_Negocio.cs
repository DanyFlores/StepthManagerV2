using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Usuario_Negocio
    {

        public void ABCUsuario(Usuario Datos)
        {
            try
            {
                Usuario_Datos Ud = new Usuario_Datos();
                Ud.ABCUsuario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AsignarHuellaXIDEmpleado(Usuario Datos)
        {
            try
            {
                Usuario_Datos UD = new Usuario_Datos();
                UD.AsignarHuellaXIDEmpleado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerUsuario(Usuario Datos)
        {
            try
            {
                Usuario_Datos Ud = new Usuario_Datos();
                Ud.ObtenerUsuario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public void ObtenerUsuarioBusqueda(Usuario Datos)
        {
            try
            {
                Usuario_Datos Ud = new Usuario_Datos();
                Ud.ObtenerUsuarioBusqueda(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerComboCatTipoUsuario(TipoUsuario Datos)
        {
            try
            {
                Usuario_Datos Ud = new Usuario_Datos();
                Ud.ObtenerComboCatTipoUsuario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerHuellaDigitalXIDEmpleado(Usuario Datos)
        {
            try
            {
                Usuario_Datos Ud = new Usuario_Datos();
                Ud.ObtenerHuellaDigitalXIDEmpleado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerHuellasDigitales(Usuario Datos)
        {
            try
            {
                Usuario_Datos Ud = new Usuario_Datos();
                Ud.ObtenerHuellasDigitales(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Sucursal> ObtenerSucursales(Usuario Datos)
        {
            try
            {
                Usuario_Datos Ud = new Usuario_Datos();
               return Ud.ObtenerSucursal(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Sucursal> ObtenerSucursalXIDEmpleado(Usuario Datos)
        {
            try
            {
                Usuario_Datos Ud = new Usuario_Datos();
                return Ud.ObtenerSucursalXIDEmpleado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABCCuentaUsuario(Usuario Datos)
        {
            try
            {
                Usuario_Datos Ud = new Usuario_Datos();
                Ud.ABCCuentaUsuario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> LlenarComboCatEmpleados(Usuario Datos)
        {
            try
            {
                Usuario_Datos UD = new Usuario_Datos();
                return UD.LlenarComboCatEmpleados(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> LlenarComboCatEmpleadosCita(Usuario Datos)
        {
            try
            {
                Usuario_Datos UD = new Usuario_Datos();
                return UD.LlenarComboCatEmpleadosCita(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MotivoBaja> LlenarComboMotivoBaja(MotivoBaja Datos)
        {
            try
            {
                Usuario_Datos UD = new Usuario_Datos();
                return UD.LlenarComboMotivoBaja(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoNomina> LlenarComboTipoNomina(TipoNomina Datos)
        {
            try
            {
                Usuario_Datos UD = new Usuario_Datos();
                return UD.LlenarComboTipoNomina(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AltaNominal(Usuario Datos)
        {
            try
            {
                Usuario_Datos UD = new Usuario_Datos();
                UD.AltaNominal(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BajaNominal(Usuario Datos)
        {
            try
            {
                Usuario_Datos UD = new Usuario_Datos();
                UD.BajaNominal(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerHistorialLaboral(Usuario Datos)
        {
            try
            {
                Usuario_Datos UD = new Usuario_Datos();
                UD.ObtenerHistorialLaboral(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerPermisosXIDUsuario(Usuario Datos)
        {
            try
            {
                Usuario_Datos UD = new Usuario_Datos();
                UD.ObtenerPermisosXIDUsuario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarPermisosXIDUsuario(Usuario Datos)
        {
            try
            {
                Usuario_Datos UD = new Usuario_Datos();
                UD.ActualizarPermisosXIDUsuario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AsignarCategoria(Usuario Datos)
        {
            try
            {
                Usuario_Datos UD = new Usuario_Datos();
                UD.AsignarCategoria(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ABNominaVaciones(Usuario Datos)
        {
            try
            {
                Usuario_Datos UD = new Usuario_Datos();
                UD.ABVacacionesEmpleado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerNomina_Vacaciones(Usuario Datos)
        {
            try
            {
                Usuario_Datos Ud = new Usuario_Datos();
                Ud.ObtenerNominaVaciones(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
