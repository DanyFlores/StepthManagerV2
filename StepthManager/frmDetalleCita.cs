using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using CreativaSL.Dll.Validaciones;
using StephManager.ClasesAux;
using System.IO;

namespace StephManager
{
    public partial class frmDetalleCita : Form
    {

        #region Variables

        private string IDCita = string.Empty;

        #endregion

        public frmDetalleCita(string ID)
        {
            try
            {
                InitializeComponent();
                IDCita = ID;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmAtenderCita ~ frmAtenderCita()");
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.LlenarDatos(this.ObtenerDetalleCita());
                this.ActiveControl = this.btnCancelar;
                this.btnCancelar.Focus();
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Cita ObtenerDetalleCita()
        {
            try
            {
                Cita DatosAux = new Cita { Conexion = Comun.Conexion, IDCita = IDCita };
                Cita_Negocio CN = new Cita_Negocio();
                return CN.ObtenerDatosCitasDetalle(DatosAux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarDatos(Cita Aux)
        {
            try
            {
                this.txtNombreCliente.Text = Aux.NombreCliente;
                this.txtNombreSucursal.Text = Aux.NombreSucursal;
                this.txtNombreEmpleado.Text = Aux.NombreEmpleado;
                this.txtFechaCita.Text = Aux.FechaCita.ToShortDateString();
                this.txtHoraCita.Text = Aux.HoraCita;
                this.txtEstatusCita.Text = Aux.EstatusCita;
                this.txtEmpleadoAtendio.Text = Aux.EmpleadoAtendio;
                this.txtFechaAtencion.Text = Aux.FechaHoraAtencion;
                this.txtEmpleadoCancelo.Text = Aux.EmpleadoCancela;
                this.txtFechaCancelacion.Text = Aux.FechaHoraCancelacion;
                this.txtMotivoCancelacion.Text = Aux.MotivoCancelacion;
                this.txtComentarios.Text = Aux.Comentarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void frmDetalleCita_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAtenderCita ~ frmAtenderCita_Load");
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAtenderCita ~ btnCancelar_Click");
            }
        }
    }
}
