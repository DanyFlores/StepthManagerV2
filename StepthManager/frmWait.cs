using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using CreativaSL.LibControls.WinForms;
using StephManager.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephManager
{
    public partial class frmWait : Form_Creativa
    {
        #region Constructor

        public frmWait()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos

        private void frmWait_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = Comun.NombreComercial + " - Espere...";
                if (File.Exists(Comun.UrlLogo))
                    this.Icon = new Icon(Path.Combine(System.Windows.Forms.Application.StartupPath, Comun.UrlLogo));
                this.label1.Text = "Espere un momento. \r\nReenviando Notificaciones.";
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmWait ~ frmWait_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
        }

        #endregion


        #region Métodos

        public void ActualizarProgreso(int Progreso)
        {
            try
            {
                this.lblPorcentaje.Text = Progreso + " %";
                this.Progreso.Value = Progreso;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmWait ~ ActualizarProgreso");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
