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
    public partial class frmVacaciones : Form
    {
        #region Variables
        private Usuario _DatosUsuario;

        public Usuario DatosUsuario
        {
            get { return _DatosUsuario; }
            set { _DatosUsuario = value; }
        }

        #endregion
        
        #region Constructores

        public frmVacaciones(Usuario Datos)
        {
            try
            {
                InitializeComponent();
                this.DatosUsuario = Datos;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVacaciones ~ frmVacaciones(Usuario Datos)");
            }
        }

        #endregion

        #region Métodos

        private void EliminarVacaciones(Usuario Datos)
        {
            try
            {
                Datos.Conexion = Comun.Conexion;
                Datos.IDUsuario = Comun.IDUsuario;
                Datos.IDEmpleado = _DatosUsuario.IDEmpleado;
                Datos.Opcion = 3;
                Usuario_Negocio MobNeg = new Usuario_Negocio();
                MobNeg.ABNominaVaciones(Datos);
                if (Datos.Completado)
                {
                    MessageBox.Show("Registro Eliminado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Int32 RowToDelete = this.dgvNominaVacaciones.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowToDelete > -1)
                        this.dgvNominaVacaciones.Rows.RemoveAt(RowToDelete);
                    else
                        this.LlenarGridVacaciones(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar los datos. Contacte a Soporte Técnico.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void IniciarForm()
        {
            try
            {
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
                this.txtEmpleado.Text = _DatosUsuario.Nombre + " " + _DatosUsuario.ApellidoPat + " " + _DatosUsuario.ApellidoMat;
                this.LlenarGridVacaciones(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        private void LlenarGridVacaciones(bool Band)
        {
            try
            {
                Usuario DatosAux = new Usuario { Conexion = Comun.Conexion,  IDEmpleado = _DatosUsuario.IDEmpleado , BuscarTodos = Band };
                Usuario_Negocio MN = new Usuario_Negocio();
                MN.ObtenerNomina_Vacaciones(DatosAux);
                this.dgvNominaVacaciones.AutoGenerateColumns = false;
                this.dgvNominaVacaciones.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Usuario ObtenerDatosMobiliario()
        {
            try
            {
                Usuario DatosAux = new Usuario();
                Int32 RowData = this.dgvNominaVacaciones.Rows.GetFirstRow(DataGridViewElementStates.Selected); 
                if (RowData > -1)
                {
                    DataGridViewRow FilaDatos = this.dgvNominaVacaciones.Rows[RowData];
                    DatosAux.IDVacaciones = FilaDatos.Cells["IDVacaciones"].Value.ToString();
                    DateTime FechaInicio;
                    DateTime.TryParse(FilaDatos.Cells["FechaInicio"].Value.ToString(), out FechaInicio);
                    DatosAux.FechaInicio = FechaInicio;
                    DateTime FechaFin;
                    DateTime.TryParse(FilaDatos.Cells["FechaFin"].Value.ToString(), out FechaFin);
                    DatosAux.FechaFin = FechaFin;
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvNominaVacaciones.SelectedRows.Count == 1)
                {
                    Usuario DatosAux = this.ObtenerDatosMobiliario();
                    if (!string.IsNullOrEmpty(DatosAux.IDVacaciones))
                    {
                        if(MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            this.EliminarVacaciones(DatosAux);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVacaciones ~ btnEliminar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmVacacionesFechas Mobiliario = new frmVacacionesFechas(_DatosUsuario);
                Mobiliario.ShowDialog();
                Mobiliario.Dispose();
                if (Mobiliario.DialogResult == DialogResult.OK)
                {
                    this.LlenarGridVacaciones(false);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVacaciones ~ btnNuevo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                LogError.AddExcFileTxt(ex, "frmVacaciones ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.LlenarGridVacaciones(true);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVacaciones ~ btnTodos_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmVacaciones_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVacaciones ~ frmVacaciones_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
