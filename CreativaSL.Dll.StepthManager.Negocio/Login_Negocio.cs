using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Datos;

namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Login_Negocio
    {
        public void IniciarDatos(DatosIniciales Datos)
        {
            try
            {
                Login_Datos LD = new Login_Datos();
                LD.IniciarDatos(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool IsNewSystem(string Conexion)
        {
            try
            {
                Login_Datos LD = new Login_Datos();
                return LD.IsNewSystem(Conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ValidarUsuario(Usuario Datos)
        {
            try
            {
                Login_Datos LD = new Login_Datos();
                LD.ValidarUsuario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
