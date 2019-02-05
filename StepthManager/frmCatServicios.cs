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
using System.Globalization;
using System.IO;

namespace StephManager
{
    public partial class frmCatServicios : Form
    {
        #region Constructores

        public frmCatServicios()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatServicios ~ frmCatServicios()");
            }
        }

        #endregion

        #region Métodos

        private void BusquedaServicio(string TextoServicio)
        {
            try
            {
                Servicio DatosAux = new Servicio { Conexion = Comun.Conexion, NombreServicio = TextoServicio, BuscarTodos = false };
                Servicio_Negocio PN = new Servicio_Negocio();
                PN.ObtenerCatServicioBusqueda(DatosAux);
                this.dgvServicios.AutoGenerateColumns = false;
                this.dgvServicios.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EliminarServicio(Servicio Datos)
        {
            try
            {
                Datos.Conexion = Comun.Conexion;
                Datos.IDUsuario = Comun.IDUsuario;
                Datos.Opcion = 3;
                Datos.TablaMonederos = this.GenerarTablaMonedero();
                Datos.TablaProductos = this.GenerarTablaProducto();
                Datos.FechaInicioTemp = DateTime.Today;
                Datos.FechaFinTemp = DateTime.Today;
                Datos.Imagen = new byte[0];
                Servicio_Negocio ProdNeg = new Servicio_Negocio();
                ProdNeg.ABCCatServicio(Datos);
                if (Datos.Completado)
                {
                    MessageBox.Show("Registro Eliminado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Int32 RowToDelete = this.dgvServicios.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowToDelete > -1)
                        this.dgvServicios.Rows.RemoveAt(RowToDelete);
                    else
                        this.LlenarGridCatServicio(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar los datos. Contacte a Soporte Técnico.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogError.AddExcFileTxt(new Exception(Datos.MensajeError), "frmCatServicios ~ EliminarServicio -> Método");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ModificarDatos(Servicio Datos)
        {
            try
            {
                Int32 RowToUpdate = this.dgvServicios.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowToUpdate > -1)
                {
                    this.dgvServicios.Rows[RowToUpdate].Cells["Codigo"].Value = Datos.Clave;
                    this.dgvServicios.Rows[RowToUpdate].Cells["Nombre"].Value = Datos.NombreServicio;
                    this.dgvServicios.Rows[RowToUpdate].Cells["Familia"].Value = Datos.FamiliaDesc;
                    this.dgvServicios.Rows[RowToUpdate].Cells["PrecioNormal"].Value = Datos.PrecioNormal;
                    this.dgvServicios.Rows[RowToUpdate].Cells["Descripcion"].Value = Datos.Descripcion;
                }
                else
                    this.LlenarGridCatServicio(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GenerarTablaProducto()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla.Columns.Add("IDProductoXServicio", typeof(string));
                Tabla.Columns.Add("IDProducto", typeof(string));
                Tabla.Columns.Add("Cantidad", typeof(int));
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
                this.LlenarGridCatServicio(false);
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

        private void LlenarGridCatServicio(bool Band)
        {
            try
            {
                Servicio DatosAux = new Servicio { Conexion = Comun.Conexion, BuscarTodos = Band };
                Servicio_Negocio PN = new Servicio_Negocio();
                PN.ObtenerCatServicio(DatosAux);
                this.dgvServicios.AutoGenerateColumns = false;
                this.dgvServicios.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Servicio ObtenerDatosServicios()
        {
            try
            {
                Servicio DatosAux = new Servicio();
                Int32 RowData = this.dgvServicios.Rows.GetFirstRow(DataGridViewElementStates.Selected); 
                if (RowData > -1)
                {
                    DataGridViewRow FilaDatos = this.dgvServicios.Rows[RowData];
                    DatosAux.IDServicio = FilaDatos.Cells["IDProducto"].Value.ToString();//IDServicio
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
                        this.BusquedaServicio(this.txtBusqueda.Text.Trim());
                    else
                        this.txtBusqueda.Text = string.Empty;
                }
                else
                {
                    this.LlenarGridCatServicio(false);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatServicios ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvServicios.SelectedRows.Count == 1)
                {
                    Servicio DatosAux = this.ObtenerDatosServicios();
                    if (!string.IsNullOrEmpty(DatosAux.IDServicio))
                    {
                        if (MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            this.EliminarServicio(DatosAux);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatServicios ~ btnEliminar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvServicios.SelectedRows.Count == 1)
                {
                    Servicio DatosAux = this.ObtenerDatosServicios();
                    if (!string.IsNullOrEmpty(DatosAux.IDServicio))
                    {
                        this.Visible = false;
                        frmNuevoServicio Servicio = new frmNuevoServicio(DatosAux);
                        Servicio.ShowDialog();
                        Servicio.Dispose();
                        if (Servicio.DialogResult == DialogResult.OK)
                        {
                            if (Servicio.DatosServicio.Completado)
                            {
                                this.ModificarDatos(Servicio.DatosServicio);
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
                LogError.AddExcFileTxt(ex, "frmCatServicios ~ btnModificar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmNuevoServicio Servicio = new frmNuevoServicio();
                Servicio.ShowDialog();
                Servicio.Dispose();
                if (Servicio.DialogResult == DialogResult.OK)
                {
                    this.BusquedaServicio(Servicio.DatosServicio.NombreServicio);
                }
                this.Visible = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatServicios ~ btnNuevo_Click");
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
                LogError.AddExcFileTxt(ex, "frmCatServicios ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.LlenarGridCatServicio(true);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatServicios ~ btnTodos_Click");
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
                LogError.AddExcFileTxt(ex, "frmCatServicios ~ frmCatClientes_Load");
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
                LogError.AddExcFileTxt(ex, "frmCatServicios ~ txtBusqueda_KeyPress");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void dgvServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPrecios_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvServicios.SelectedRows.Count == 1)
                {
                    Servicio DatosAux = this.ObtenerDatosServicios();
                    if (!string.IsNullOrEmpty(DatosAux.IDServicio))
                    {
                        frmPreciosProductos Precios = new frmPreciosProductos(DatosAux.IDServicio, true);
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
                LogError.AddExcFileTxt(ex, "frmCatServicios ~ btnPrecios_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }
    }
}
