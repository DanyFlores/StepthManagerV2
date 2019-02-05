using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephManager.ClasesAux
{
    public class Error
    {
        public int Numero { get; set; }
        public string Descripcion { get; set; }
        public Control ControlSender { get; set; }
    }
}
