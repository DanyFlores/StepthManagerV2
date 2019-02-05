using CreativaSL.Dll.StephManager.Global;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Datos
{
    public class Home_Datos
    {

        public void HomeGridProductosServicios(Home Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_HomeProductosServicios");
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        Datos.Completado = true;
                        Datos.TablaDatos = Ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void HomeGridIncidencias(Home Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_HomeIncidencias");
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        Datos.Completado = true;
                        Datos.TablaDatos = Ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void HomeGridResumenVentas(Home Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_HomeResumenVentas");
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        Datos.Completado = true;
                        Datos.TablaDatos = Ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void HomeGridOcupacion(Home Datos)
        {
            try
            {
                DataSet Ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_HomeOcupacion", Datos.IDSucursal);
                if (Ds != null)
                {
                    if (Ds.Tables.Count == 1)
                    {
                        Datos.Completado = true;
                        Datos.TablaDatos = Ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
