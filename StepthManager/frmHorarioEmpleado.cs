using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
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
    public partial class frmHorarioEmpleado : Form
    {

        private string IDEmpleado = string.Empty;

        public frmHorarioEmpleado(string ID)
        {
            try
            {
                InitializeComponent();
                this.IDEmpleado = ID;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmHorarioEmpleado ~ frmHorarioEmpleado()");
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.dtpFechaInicio.Value = DateTime.Today;
                this.dateTimePicker1.Value = DateTime.Today;
                this.dtpFechaInicio.Focus();
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

        private void CargarTablaHorarios(DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
                Checador DatosAux = new Checador();
                Checador_Negocio CN = new Checador_Negocio();
                DatosAux.IDEmpleado = this.IDEmpleado;
                DatosAux.FechaInicio = FechaInicio;
                DatosAux.FechaFin = FechaFin;
                DatosAux.Conexion = Comun.Conexion;
                CN.ObtenerHorariosXFecha(DatosAux);
                this.dgvHorarios.DataSource = null;
                this.dgvHorarios.AutoGenerateColumns = false;
                this.dgvHorarios.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dateTimePicker1.Value >= this.dtpFechaInicio.Value)
                {
                    this.CargarTablaHorarios(this.dtpFechaInicio.Value, this.dateTimePicker1.Value);
                }
                else
                    this.dgvHorarios.DataSource = null;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmHorarioEmpleado ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmHorarioEmpleado ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmHorarioEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmHorarioEmpleado ~ frmHorarioEmpleado_Load");
            }
        }

        private void dgvHorarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
