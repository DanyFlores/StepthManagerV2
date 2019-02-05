using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using CreativaSL.Dll.Validaciones;
using StephManager.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephManager
{
    public partial class frmCatTarjetas : Form
    {
        #region Constructores

        public frmCatTarjetas()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatTarjetas ~ frmCatTarjetas()");
            }
        }

        #endregion

        #region Métodos

        private void BusquedaTarjeta(string TextoProducto)
        {
            try
            {
                Producto DatosAux = new Producto { Conexion = Comun.Conexion, Clave = TextoProducto, BuscarTodos = this.chkTodos.Checked };
                Producto_Negocio PN = new Producto_Negocio();
                PN.ObtenerCatTarjetasRegaloBusqueda(DatosAux);
                this.dgvProductos.AutoGenerateColumns = false;
                this.dgvProductos.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EliminarProducto(Producto Datos)
        {
            try
            {
                Datos.Conexion = Comun.Conexion;
                Datos.IDUsuario = Comun.IDUsuario;
                Producto_Negocio ProdNeg = new Producto_Negocio();
                ProdNeg.EliminarTarjetasRegalo(Datos);
                if (Datos.Completado)
                {
                    MessageBox.Show("Registro Eliminado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Int32 RowToDelete = this.dgvProductos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowToDelete > -1)
                        this.dgvProductos.Rows.RemoveAt(RowToDelete);
                    else
                        this.LlenarGridCatProductos(this.chkTodos.Checked);
                }
                else
                {
                    MessageBox.Show("Error al guardar los datos. Contacte a Soporte Técnico.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogError.AddExcFileTxt(new Exception(Datos.MensajeError), "frmCatTarjetas ~ EliminarProducto -> Método");
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
                this.LlenarGridCatProductos(false);
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

        private void LlenarGridCatProductos(bool Band)
        {
            try
            {
                Producto DatosAux = new Producto { Conexion = Comun.Conexion, BuscarTodos = Band };
                Producto_Negocio PN = new Producto_Negocio();
                PN.ObtenerCatTarjetasRegalo(DatosAux);
                this.dgvProductos.AutoGenerateColumns = false;
                this.dgvProductos.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Producto ObtenerDatosProducto()
        {
            try
            {
                Producto DatosAux = new Producto();
                Int32 RowData = this.dgvProductos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowData > -1)
                {
                    DataGridViewRow FilaDatos = this.dgvProductos.Rows[RowData];
                    DatosAux.IDProducto = FilaDatos.Cells["IDProducto"].Value.ToString();
                    DatosAux.NombreProducto = FilaDatos.Cells["Descripcion"].Value.ToString();
                    DatosAux.Clave = FilaDatos.Cells["Codigo"].Value.ToString();
                    decimal Monto = 0;
                    decimal.TryParse(FilaDatos.Cells["Monto"].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out Monto);
                    DatosAux.PrecioNormal = Monto;
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
                    if (Validar.IsValidDescripcion(txtBusqueda.Text.Trim()))
                        this.BusquedaTarjeta(this.txtBusqueda.Text.Trim());
                    else
                        this.txtBusqueda.Text = string.Empty;
                }
                else
                {
                    this.LlenarGridCatProductos(false);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatTarjetas ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductos.SelectedRows.Count == 1)
                {
                    Producto DatosAux = this.ObtenerDatosProducto();
                    if (!string.IsNullOrEmpty(DatosAux.IDProducto))
                    {
                        if (MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            this.EliminarProducto(DatosAux);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatTarjetas ~ btnEliminar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductos.SelectedRows.Count == 1)
                {
                    Producto DatosAux = this.ObtenerDatosProducto();
                    if (!string.IsNullOrEmpty(DatosAux.IDProducto))
                    {
                        frmNuevaTarjetaRegalo Producto = new frmNuevaTarjetaRegalo(DatosAux);
                        Producto.ShowDialog();
                        Producto.Dispose();
                        if (Producto.DialogResult == DialogResult.OK)
                        {
                            this.LlenarGridCatProductos(this.chkTodos.Checked);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatTarjetas ~ btnModificar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevaTarjetaRegalo Producto = new frmNuevaTarjetaRegalo();
                Producto.ShowDialog();
                Producto.Dispose();
                if (Producto.DialogResult == DialogResult.OK)
                {
                    this.LlenarGridCatProductos(this.chkTodos.Checked);
                }
                this.Visible = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatTarjetas ~ btnNuevo_Click");
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
                LogError.AddExcFileTxt(ex, "frmCatTarjetas ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCatTarjetas_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatTarjetas ~ frmCatTarjetas_Load");
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
                LogError.AddExcFileTxt(ex, "frmCatTarjetas ~ txtBusqueda_KeyPress");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnCancelarBusq_Click(object sender, EventArgs e)
        {
            try
            {
                this.LlenarGridCatProductos(this.chkTodos.Checked);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatTarjetas ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarFolios_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductos.SelectedRows.Count == 1)
                {
                    Producto DatosAux = this.ObtenerDatosProducto();
                    if (!string.IsNullOrEmpty(DatosAux.IDProducto))
                    {
                        frmEnviarTarjetas Datos = new frmEnviarTarjetas(DatosAux);
                        Datos.ShowDialog();
                        Datos.Dispose();
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatTarjetas ~ btnGenerarFolios_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
