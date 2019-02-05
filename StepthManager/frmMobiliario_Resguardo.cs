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
    public partial class frmMobiliario_Resguardo : Form
    {
        #region Constructores

        public frmMobiliario_Resguardo()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliario_Resguardo ~ frmMobiliario_Resguardo()");
            }
        }

        #endregion

        #region Métodos

        private void BusquedaMobiliario(string TextoMobiliario)
        {
            try
            {
                MobiliarioResguardo DatosAux = new MobiliarioResguardo { Conexion = Comun.Conexion, FolioResguardo = TextoMobiliario, BuscarTodos = false };
                MobiliarioResguardo_Negocio MN = new MobiliarioResguardo_Negocio();
                MN.ObtenerCatMobiliarioResguardoBusqueda(DatosAux);
                this.dgvMobiliarioResguardo.AutoGenerateColumns = false;
                this.dgvMobiliarioResguardo.DataSource = DatosAux.TablaDatos;
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
                this.LlenarGridCatMobiliario(false);
                this.txtBusqueda.Focus();
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

        private void LlenarGridCatMobiliario(bool Band)
        {
            try
            {
                MobiliarioResguardo DatosAux = new MobiliarioResguardo { Conexion = Comun.Conexion, BuscarTodos = Band };
                MobiliarioResguardo_Negocio MN = new MobiliarioResguardo_Negocio();
                MN.ObtenerCatMobiliarioResguardo(DatosAux);
                this.dgvMobiliarioResguardo.AutoGenerateColumns = false;
                this.dgvMobiliarioResguardo.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private MobiliarioResguardo ObtenerDatosMobiliario()
        {
            try
            {
                MobiliarioResguardo DatosAux = new MobiliarioResguardo();
                Int32 RowData = this.dgvMobiliarioResguardo.Rows.GetFirstRow(DataGridViewElementStates.Selected); 
                if (RowData > -1)
                {
                    DataGridViewRow FilaDatos = this.dgvMobiliarioResguardo.Rows[RowData];
                    DatosAux.IDMobiliarioResguardo = FilaDatos.Cells["IDMobiliarioResguardo"].Value.ToString();
                    DatosAux.IDSucursal = FilaDatos.Cells["IDSucursal"].Value.ToString();
                    DatosAux.FolioResguardo = FilaDatos.Cells["FolioReguardo"].Value.ToString();
                    DatosAux.FechaResguardo = Convert.ToDateTime(FilaDatos.Cells["FechaResguardo"].Value.ToString());
                    DatosAux.IDStatusMobiliario = Convert.ToInt32(FilaDatos.Cells["Estatus"].Value.ToString());
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtBusqueda.Text.Trim()))
                {
                    //if (Validar.IsValidName(txtBusqueda.Text.Trim()))
                        this.BusquedaMobiliario(this.txtBusqueda.Text.Trim());
                    //else
                    //    this.txtBusqueda.Text = string.Empty;
                }
                else
                {
                    this.LlenarGridCatMobiliario(false);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliario_Resguardo ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevo_Mobiliario_Resguardo Mobiliario = new frmNuevo_Mobiliario_Resguardo();
                this.Visible = false;
                Mobiliario.ShowDialog();
                this.Visible = true;
                Mobiliario.Dispose();
                if (Mobiliario.DialogResult == DialogResult.OK)
                {
                    this.BusquedaMobiliario(Mobiliario.DatosMobiliarioReguardo.Descripcion);
                    this.LlenarGridCatMobiliario(false);
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmMobiliario_Resguardo ~ btnNuevo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvMobiliarioResguardo.SelectedRows.Count == 1)
                {
                    MobiliarioResguardo DatosAux = this.ObtenerDatosMobiliario();
                    if (!string.IsNullOrEmpty(DatosAux.IDMobiliarioResguardo))
                    {
                        if (DatosAux.IDStatusMobiliario == 1)
                        {
                            frmNuevo_Mobiliario_Resguardo MobiliarioResguardo = new frmNuevo_Mobiliario_Resguardo(DatosAux.IDMobiliarioResguardo);
                            MobiliarioResguardo.ShowDialog();
                            MobiliarioResguardo.Dispose();
                            if (MobiliarioResguardo.DialogResult == DialogResult.OK)
                            {
                                if (MobiliarioResguardo.DatosMobiliarioReguardo.Completado)
                                {
                                    this.LlenarGridCatMobiliario(false);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("El estatus del resguardo no permite modificar.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliario_Resguardo ~ btnModificar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvMobiliarioResguardo.SelectedRows.Count == 1)
                {
                   MobiliarioResguardo DatosAux = this.ObtenerDatosMobiliario();
                    if (!string.IsNullOrEmpty(DatosAux.IDMobiliarioResguardo))
                    {
                        if (DatosAux.IDStatusMobiliario == 1)
                        {
                            if (MessageBox.Show("¿Está seguro de eliminar el registro con el folio " + DatosAux.FolioResguardo + "?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                DatosAux.Conexion = Comun.Conexion;
                                DatosAux.IDUsuario = Comun.IDUsuario;
                                MobiliarioResguardo_Negocio MobNeg = new MobiliarioResguardo_Negocio();
                                MobNeg.EliminarMobiliarioResguardo(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    MessageBox.Show("Registro Eliminado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Int32 RowToDelete = this.dgvMobiliarioResguardo.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                                    if (RowToDelete > -1)
                                        this.dgvMobiliarioResguardo.Rows.RemoveAt(RowToDelete);
                                    else
                                        this.LlenarGridCatMobiliario(false);
                                }
                                else
                                {
                                    MessageBox.Show("Error al guardar los datos. Contacte a Soporte Técnico.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("El estatus del resguardo no permite eliminar.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliario_Resguardo ~ btnEliminar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnviarResguardo_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvMobiliarioResguardo.SelectedRows.Count == 1)
                {
                    MobiliarioResguardo DatosAux = this.ObtenerDatosMobiliario();
                    if (!string.IsNullOrEmpty(DatosAux.IDMobiliarioResguardo))
                    {
                        if (DatosAux.IDStatusMobiliario == 1)
                        {
                            if (MessageBox.Show("¿Está seguro de enviar el resguardo con el  " + DatosAux.FolioResguardo + "?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                DatosAux.Conexion = Comun.Conexion;
                                DatosAux.IDUsuario = Comun.IDUsuario;
                                MobiliarioResguardo_Negocio MRN = new MobiliarioResguardo_Negocio();
                                MRN.EnviarMobiliarioResguardo(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.LlenarGridCatMobiliario(false);
                                }
                                else
                                {
                                    MessageBox.Show("El Mobiliario " + DatosAux.Descripcion + " no cuenta con suficiente existencia", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("El estatus del resguardo no permite enviar.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliario_Resguardo ~ btnEnviarResguardo_Click");
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
                LogError.AddExcFileTxt(ex, "frmMobiliario_Resguardo ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.LlenarGridCatMobiliario(true);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliario_Resguardo ~ btnVerTodos_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCatMobiliario_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliario_Resguardo ~ frmCatMobiliario_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)Keys.Enter)
                {
                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliario_Resguardo ~ txtBusqueda_KeyPress");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnImprimirCarta_Click(object sender, EventArgs e)
        {
            try
            {
                MobiliarioResguardo DatosAux = this.ObtenerDatosMobiliario();
                if (!string.IsNullOrEmpty(DatosAux.IDMobiliarioResguardo))
                {
                    frmVerListados Listado = new frmVerListados(1, DatosAux.IDMobiliarioResguardo);
                    this.Visible = false;
                    Listado.ShowDialog();
                    this.Visible = true;
                    Listado.Dispose();
                }
                else
                    MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmMobiliario_Resguardo ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
