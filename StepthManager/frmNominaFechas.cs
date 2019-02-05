using CreativaSL.Dll.StephManager.Global;
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
    public partial class frmNominaFechas : Form
    {

        public DateTime FechaInicio;
        public DateTime FechaFin;

        #region Constructor

        public frmNominaFechas()
        {
            try
            {
                InitializeComponent();                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNominaFechas ~ frmNominaFechas()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
                this.ActiveControl = this.dtpFechaInicio;
                this.dtpFechaInicio.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MostrarMensajeError(List<Error> Errores)
        {
            try
            {
                string cadenaErrores = string.Empty;
                cadenaErrores = "No se pudo guardar la información. Se presentaron los siguientes errores: \r\n";
                foreach (Error item in Errores)
                {
                    cadenaErrores += item.Numero + "\t" + item.Descripcion + "\r\n";
                }
                this.txtMensajeError.Visible = true;
                this.txtMensajeError.Text = cadenaErrores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Error> ValidarDatos()
        {
            try
            {
                List<Error> Errores = new List<Error>();
                int Aux = 0;
                if(this.dtpFechaInicio.Value > this.dtpFechaFin.Value) 
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese las fechas en el ordern correcto.", ControlSender = this.dtpFechaInicio});
                if (this.dtpFechaInicio.Value > DateTime.Today || this.dtpFechaFin.Value > DateTime.Today)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "No se puede generar una nómina futura.", ControlSender = this.dtpFechaInicio });
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNominaFechas ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                    this.FechaInicio = this.dtpFechaInicio.Value;
                    this.FechaFin = this.dtpFechaFin.Value;
                    this.DialogResult = DialogResult.OK;
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNominaFechas ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNominaFechas_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNominaFechas ~ frmNominaFechas_Load");
            }
        }
        #endregion

    }
}
