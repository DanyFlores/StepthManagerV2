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
    public class Cursos_Datos
    {

        public List<Curso> LlenarComboCursos(Curso Datos)
        {
            try
            {
                List<Curso> Lista = new List<Curso>();
                Curso Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboCatCursos", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new Curso();
                    Item.IDCurso = !Dr.IsDBNull(Dr.GetOrdinal("IDCurso")) ? Dr.GetString(Dr.GetOrdinal("IDCurso")) : string.Empty;
                    Item.Nombre = !Dr.IsDBNull(Dr.GetOrdinal("NombreCurso")) ? Dr.GetString(Dr.GetOrdinal("NombreCurso")) : string.Empty;
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
