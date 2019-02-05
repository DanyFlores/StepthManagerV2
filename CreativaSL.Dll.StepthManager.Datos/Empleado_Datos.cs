using CreativaSL.Dll.StephManager.Global;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativaSL.Dll.StephManager.Datos
{
    public class Empleado_Datos
    {

        public List<Usuario> LlenarComboEmpleado(Usuario Datos)
        {
            try
            {
                List<Usuario> Lista = new List<Usuario>();
                Usuario Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboEmpleados", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new Usuario();
                    Item.IDEmpleado = !Dr.IsDBNull(Dr.GetOrdinal("IDEmpleado")) ? Dr.GetString(Dr.GetOrdinal("IDEmpleado")) : string.Empty;
                    Item.Nombre = !Dr.IsDBNull(Dr.GetOrdinal("NombreEmpleado")) ? Dr.GetString(Dr.GetOrdinal("NombreEmpleado")) : string.Empty;
                    Lista.Add(Item);
                }
                Dr.Close();
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
