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
    public partial class frmCatMobiliario : Form
    {
        #region Constructores

        public frmCatMobiliario()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatMobiliario ~ frmCatMobiliario()");
            }
        }

        #endregion

        #region Métodos

        private void BusquedaMobiliario(string TextoMobiliario)
        {
            try
            {
                Mobiliario DatosAux = new Mobiliario { Conexion = Comun.Conexion, Descripcion = TextoMobiliario, BuscarTodos = false, IDSucursal = Comun.IDSucursalCaja };
                Mobiliario_Negocio MN = new Mobiliario_Negocio();
                MN.ObtenerCatMobiliarioBusqueda(DatosAux);
                this.dgvMobiliario.AutoGenerateColumns = false;
                this.dgvMobiliario.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EliminarProducto(Mobiliario Datos)
        {
            try
            {
                Datos.Conexion = Comun.Conexion;
                Datos.IDUsuario = Comun.IDUsuario;
                Mobiliario_Negocio MobNeg = new Mobiliario_Negocio();
                MobNeg.EliminarMobiliario(Datos);
                if (Datos.Completado)
                {
                    MessageBox.Show("Registro Eliminado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Int32 RowToDelete = this.dgvMobiliario.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowToDelete > -1)
                        this.dgvMobiliario.Rows.RemoveAt(RowToDelete);
                    else
                        this.LlenarGridCatMobiliario(false);
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

        private void ModificarDatos(Mobiliario Datos)
        {
            try
            {
                Int32 RowToUpdate = this.dgvMobiliario.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowToUpdate > -1)
                {
                    this.dgvMobiliario.Rows[RowToUpdate].Cells["IDTipoMobiliario"].Value = Datos.IDTipoMobiliario;
                    this.dgvMobiliario.Rows[RowToUpdate].Cells["Codigo"].Value = Datos.Codigo;
                    this.dgvMobiliario.Rows[RowToUpdate].Cells["Descripcion"].Value = Datos.Descripcion;
                    this.dgvMobiliario.Rows[RowToUpdate].Cells["Marca"].Value = Datos.Marca;
                    this.dgvMobiliario.Rows[RowToUpdate].Cells["Modelo"].Value = Datos.Modelo;
                }
                else
                    this.LlenarGridCatMobiliario(false);
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
                Mobiliario DatosAux = new Mobiliario { Conexion = Comun.Conexion, BuscarTodos = Band, IDSucursal = Comun.IDSucursalCaja };
                Mobiliario_Negocio MN = new Mobiliario_Negocio();
                MN.ObtenerCatMobiliario(DatosAux);
                this.dgvMobiliario.AutoGenerateColumns = false;
                this.dgvMobiliario.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Mobiliario ObtenerDatosMobiliario()
        {
            try
            {
                Mobiliario DatosAux = new Mobiliario();
                Int32 RowData = this.dgvMobiliario.Rows.GetFirstRow(DataGridViewElementStates.Selected); 
                if (RowData > -1)
                {
                    DataGridViewRow FilaDatos = this.dgvMobiliario.Rows[RowData];
                    DatosAux.IDMobiliario = FilaDatos.Cells["IDMobiliario"].Value.ToString();
                    DatosAux.IDTipoMobiliario = FilaDatos.Cells["IDTipoMobiliario"].Value.ToString();
                    DatosAux.Codigo = FilaDatos.Cells["Codigo"].Value.ToString();
                    DatosAux.Descripcion = FilaDatos.Cells["Descripcion"].Value.ToString();
                    DatosAux.Marca = FilaDatos.Cells["Marca"].Value.ToString();
                    DatosAux.Modelo = FilaDatos.Cells["Modelo"].Value.ToString();
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
                    if (Validar.IsValidName(txtBusqueda.Text.Trim()))
                        this.BusquedaMobiliario(this.txtBusqueda.Text.Trim());
                    else
                        this.txtBusqueda.Text = string.Empty;
                }
                else
                {
                    this.LlenarGridCatMobiliario(false);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatProductos ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvMobiliario.SelectedRows.Count == 1)
                {
                    Mobiliario DatosAux = this.ObtenerDatosMobiliario();
                    if (!string.IsNullOrEmpty(DatosAux.IDMobiliario))
                    {
                        if(MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            this.EliminarProducto(DatosAux);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatProductos ~ btnEliminar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvMobiliario.SelectedRows.Count == 1)
                {
                    Mobiliario DatosAux = this.ObtenerDatosMobiliario();
                    if (!string.IsNullOrEmpty(DatosAux.IDMobiliario))
                    {
                        frmNuevoMobiliario Mobiliario = new frmNuevoMobiliario(DatosAux);
                        Mobiliario.ShowDialog();
                        Mobiliario.Dispose();
                        if (Mobiliario.DialogResult == DialogResult.OK)
                        {
                            if (Mobiliario.DatosMobiliario.Completado)
                            {
                                this.ModificarDatos(Mobiliario.DatosMobiliario);
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatProductos ~ btnModificar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoMobiliario Mobiliario = new frmNuevoMobiliario();
                Mobiliario.ShowDialog();
                Mobiliario.Dispose();
                if (Mobiliario.DialogResult == DialogResult.OK)
                {
                    this.BusquedaMobiliario(Mobiliario.DatosMobiliario.Descripcion);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatProductos ~ btnNuevo_Click");
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
                LogError.AddExcFileTxt(ex, "frmCatProductos ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.LlenarGridCatMobiliario(true);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatProductos ~ btnTodos_Click");
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
                LogError.AddExcFileTxt(ex, "frmCatMobiliario ~ frmCatMobiliario_Load");
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
                LogError.AddExcFileTxt(ex, "frmCatProductos ~ txtBusqueda_KeyPress");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
