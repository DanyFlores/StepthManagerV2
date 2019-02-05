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
    public class Instructores_Datos
    {
    
        public List<Instructor> LlenarComboInstructores(Instructor Datos)
        {
            try
            {
                List<Instructor> Lista = new List<Instructor>();
                Instructor Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboInstructores", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new Instructor();
                    Item.IDInstructor = !Dr.IsDBNull(Dr.GetOrdinal("IDInstructor")) ? Dr.GetString(Dr.GetOrdinal("IDInstructor")) : string.Empty;
                    Item.Nombre = !Dr.IsDBNull(Dr.GetOrdinal("NombreInstructor")) ? Dr.GetString(Dr.GetOrdinal("NombreInstructor")) : string.Empty;
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
