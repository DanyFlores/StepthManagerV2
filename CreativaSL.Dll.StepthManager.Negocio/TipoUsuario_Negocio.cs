using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class TipoUsuario_Negocio
    {
        public void ObtenerPermisosXIDUsuario(TipoUsuario Datos)
        {
            try
            {
                TipoUsuario_Datos TUD = new TipoUsuario_Datos();
                TUD.ObtenerPermisosXTipoUsuario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarPermisosXIDUsuario(TipoUsuario Datos)
        {
            try
            {
                TipoUsuario_Datos TUD = new TipoUsuario_Datos();
                TUD.ActualizarPermisosXIDUsuario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
