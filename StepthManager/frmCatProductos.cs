using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using CreativaSL.Dll.Validaciones;
using StephManager.ClasesAux;
using System.Globalization;

namespace StephManager
{
    public partial class frmCatProductos : Form
    {
        #region Constructores

        public frmCatProductos()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatProductos ~ frmCatProductos()");
            }
        }

        #endregion

        #region Métodos

        private void BusquedaProducto(string TextoProducto)
        {
            try
            {
                Producto DatosAux = new Producto { Conexion = Comun.Conexion, NombreProducto = TextoProducto, BuscarTodos = false };
                Producto_Negocio PN = new Producto_Negocio();
                PN.ObtenerCatProductosBusqueda(DatosAux);
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
                Datos.Opcion = 3;
                Datos.TablaMonederos = this.GenerarTablaMonedero();
                Datos.TablaProveedores = this.GenerarTablaProveedores();
                Datos.FechaInicioTemp = DateTime.Today;
                Datos.FechaFinTemp = DateTime.Today;
                Datos.Imagen = new byte[0];
                Producto_Negocio ProdNeg = new Producto_Negocio();
                ProdNeg.ABCCatProductos(Datos);
                if (Datos.Completado)
                {
                    MessageBox.Show("Registro Eliminado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Int32 RowToDelete = this.dgvProductos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowToDelete > -1)
                        this.dgvProductos.Rows.RemoveAt(RowToDelete);
                    else
                        this.LlenarGridCatProductos(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar los datos. Contacte a Soporte Técnico.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogError.AddExcFileTxt(new Exception(Datos.MensajeError), "frmCatProductos ~ EliminarProducto -> Método");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ModificarDatos(Producto Datos)
        {
            try
            {
                Int32 RowToUpdate = this.dgvProductos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowToUpdate > -1)
                {
                    this.dgvProductos.Rows[RowToUpdate].Cells["Codigo"].Value = Datos.Clave;
                    this.dgvProductos.Rows[RowToUpdate].Cells["NumInventario"].Value = Datos.NumInventario;
                    this.dgvProductos.Rows[RowToUpdate].Cells["Nombre"].Value = Datos.NombreProducto;                    
                    this.dgvProductos.Rows[RowToUpdate].Cells["Familia"].Value = Datos.FamiliaDesc;
                    this.dgvProductos.Rows[RowToUpdate].Cells["UnidadMedida"].Value = Datos.UnidadMedidaDesc;
                    this.dgvProductos.Rows[RowToUpdate].Cells["TipoUso"].Value = Datos.TipoUsoDesc;
                    this.dgvProductos.Rows[RowToUpdate].Cells["TipoMetrica"].Value = Datos.MetricaDesc;
                }
                else
                    this.LlenarGridCatProductos(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GenerarTablaProveedores()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla.Columns.Add("IDProveedor", typeof(string));
                Tabla.Columns.Add("IDProveedorXProducto", typeof(string));
                Tabla.Columns.Add("Costo", typeof(decimal));
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GenerarTablaMonedero()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla.Columns.Add("IDTipoMonedero", typeof(int));
                Tabla.Columns.Add("IDTipoMonederoXProducto", typeof(string));
                Tabla.Columns.Add("Porcentaje", typeof(decimal));
                return Tabla;
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
                PN.ObtenerCatProductos(DatosAux);
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
                        this.BusquedaProducto(this.txtBusqueda.Text.Trim());
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
                LogError.AddExcFileTxt(ex, "frmCatProductos ~ btnBuscar_Click");
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
                if (this.dgvProductos.SelectedRows.Count == 1)
                {
                    Producto DatosAux = this.ObtenerDatosProducto();
                    if (!string.IsNullOrEmpty(DatosAux.IDProducto))
                    {
                        this.Visible = false;
                        frmNuevoProducto Producto = new frmNuevoProducto(DatosAux);
                        Producto.ShowDialog();
                        Producto.Dispose();
                        if (Producto.DialogResult == DialogResult.OK)
                        {
                            if (Producto.DatosProducto.Completado)
                            {
                                this.ModificarDatos(Producto.DatosProducto);
                            }
                        }
                        this.Visible = true;
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
                this.Visible = false;
                frmNuevoProducto Producto = new frmNuevoProducto();
                Producto.ShowDialog();
                Producto.Dispose();
                if (Producto.DialogResult == DialogResult.OK)
                {
                    this.BusquedaProducto(Producto.DatosProducto.NombreProducto);
                }
                this.Visible = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatProductos ~ btnNuevo_Click");
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
                LogError.AddExcFileTxt(ex, "frmCatProductos ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.LlenarGridCatProductos(true);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatProductos ~ btnTodos_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCatProductos_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatProductos ~ frmCatClientes_Load");
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

        private void btnPrecios_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductos.SelectedRows.Count == 1)
                {
                    Producto DatosAux = this.ObtenerDatosProducto();
                    if (!string.IsNullOrEmpty(DatosAux.IDProducto))
                    {
                        frmPreciosProductos Precios = new frmPreciosProductos(DatosAux.IDProducto, false);
                        this.Visible = false;
                        Precios.ShowDialog();
                        Precios.Dispose();
                        this.Visible = true;
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatProductos ~ btnPrecios_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }
    }
}
