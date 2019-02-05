using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using CreativaSL.Dll.Validaciones;
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
    public partial class Form2 : Form
    {
        #region Constructores

        public Form2()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "Form2 ~ Form2()");
            }
        }

        #endregion

        #region Métodos
        
        private void IniciarForm()
        {
            try
            {
                this.LlenarGrid(false);
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
        
        private void LlenarGrid(bool Band)
        {
            try
            {
                Usuario DatosAux = new Usuario { Conexion = Comun.Conexion, BuscarTodos = Band };
                Usuario_Negocio CN = new Usuario_Negocio();
                CN.ObtenerUsuario(DatosAux);
                this.dgvUsuario.AutoGenerateColumns = false;
                this.dgvUsuario.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Usuario ObtenerDatosUsuario()
        {
            try
            {
                Usuario DatosAux = new Usuario();
                Int32 RowData = this.dgvUsuario.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowData > -1)
                {
                    int ID = 0;
                    DataGridViewRow FilaDatos = this.dgvUsuario.Rows[RowData];
                    DatosAux.IDEmpleado = FilaDatos.Cells["IDEmpleado"].Value.ToString();
                    int.TryParse(FilaDatos.Cells["IDTipoUsuario"].Value.ToString(), out ID);
                    DatosAux.IDTipoUsuario = ID;
                    int.TryParse(FilaDatos.Cells["IDPuesto"].Value.ToString(), out ID);
                    DatosAux.IDPuesto = ID;
                    DatosAux.IDCategoriaPuesto = FilaDatos.Cells["IDCategoria"].Value.ToString();
                    DatosAux.IDSucursalActual = FilaDatos.Cells["IDSucursal"].Value.ToString();
                    DatosAux.AbrirCaja = Convert.ToBoolean(FilaDatos.Cells["AbrirCaja"].Value.ToString());
                    DatosAux.Nombre = FilaDatos.Cells["Nombre"].Value.ToString();
                    DatosAux.ApellidoPat = FilaDatos.Cells["ApellidoPat"].Value.ToString();
                    DatosAux.ApellidoMat = FilaDatos.Cells["ApellidoMat"].Value.ToString();
                    DatosAux.DirCalle = FilaDatos.Cells["DirCalle"].Value.ToString();
                    DatosAux.DirColonia = FilaDatos.Cells["DirColonia"].Value.ToString();
                    DatosAux.DirNumero = FilaDatos.Cells["DirNumero"].Value.ToString();
                    DatosAux.CuentaUsuario = FilaDatos.Cells["CuentaUsuario"].Value.ToString();
                    DatosAux.Password = FilaDatos.Cells["Contraseña"].Value.ToString();
                    DatosAux.AltaNominal = Convert.ToBoolean(FilaDatos.Cells["AltaNominal"].Value.ToString());
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos
        
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoEmpleado Empleado = new frmNuevoEmpleado();
                Empleado.ShowDialog();
                Empleado.Dispose();
                if (Empleado.DialogResult == DialogResult.OK)
                {
                    //this.BusquedaUsuario(Empleado.DatosUsuario.Nombre + " " + Empleado.DatosUsuario.ApellidoPat + " " + Empleado.DatosUsuario.ApellidoMat);
                }
                this.LlenarGrid(false);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "Form2 ~ btnNuevo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {                
                this.DialogResult = DialogResult.Abort;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "Form2 ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "Form2 ~ Form2_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #endregion
        
    }
}
