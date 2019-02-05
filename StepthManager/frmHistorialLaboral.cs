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
    public partial class frmHistorialLaboral : Form
    {
        private Usuario Empleado = new Usuario();

        public frmHistorialLaboral(Usuario DatosAux)
        {
            try
            {
                InitializeComponent();
                Empleado = DatosAux;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmHistorialLaboral ~ frmHistorialLaboral()");
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
                LogError.AddExcFileTxt(ex, "frmHistorialLaboral ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmHistorialLaboral_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmHistorialLaboral ~ frmHistorialLaboral_Load");
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.txtEmpleado.Text = this.Empleado.Nombre + " " + this.Empleado.ApellidoPat + " " + this.Empleado.ApellidoMat;
                this.CargarGridHistorial();
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

        private void CargarGridHistorial()
        {
            try
            {
                Usuario DatosAux = new Usuario { Conexion = Comun.Conexion, IDEmpleado = this.Empleado.IDEmpleado };
                Usuario_Negocio UN = new Usuario_Negocio();
                UN.ObtenerHistorialLaboral(DatosAux);
                this.dgvUsuario.AutoGenerateColumns = false;
                if (DatosAux.Completado)
                {
                    this.dgvUsuario.DataSource = DatosAux.TablaDatos;
                }
                else
                    this.dgvUsuario.DataSource = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
