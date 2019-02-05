using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Datos;
using CreativaSL.Dll.StephManager.Global;


namespace CreativaSL.Dll.StephManager.Negocio
{
    public class Comun_Negocio
    {
        #region Métodos Auxiliares

        public static void AddExcFileTxt(Exception ex, string funcion)
        {
            try
            {
                string mydocpath = Comun.UrlTxtLog;

                if (File.Exists(mydocpath))
                {
                    using (StreamWriter outputFile = new StreamWriter(mydocpath, true))
                    {
                        outputFile.WriteLine(ex.HResult + " - " + DateTime.Now + " - " + funcion + " - " + ex.Message);
                    }
                }
                else
                {
                    using (StreamWriter outputFile = new StreamWriter(mydocpath))
                    {
                        outputFile.WriteLine(ex.HResult + " - " + DateTime.Now + " - " + funcion + " - " + ex.Message);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

      
        #endregion

        //public void ObtenerSucursal(string conexion)
        //{
        //    try
        //    {
        //        Comun_Datos cm = new Comun_Datos();
        //        cm.ObtenerConfiguracion(conexion);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
