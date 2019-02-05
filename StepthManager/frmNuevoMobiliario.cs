using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using CreativaSL.Dll.Validaciones;
using StephManager.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephManager
{
    public partial class frmNuevoMobiliario : Form
    {
        #region Propiedades / Variables
        private bool NuevoRegistro = true;
        private Mobiliario _DatosMobiliario;
        public Mobiliario DatosMobiliario
        {
            get { return _DatosMobiliario; }
            set { _DatosMobiliario = value; }
        }
        private List<Proveedor> ListaProveedores = new List<Proveedor>();
        private List<Proveedor> ProveedoresXMobiliario = new List<Proveedor>();
        #endregion

        #region Constructor(es)

        public frmNuevoMobiliario()
        {
            try
            {
                InitializeComponent();
                this._DatosMobiliario = new Mobiliario();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoMobiliario ~ frmNuevoMobiliario()");
            }
        }

        public frmNuevoMobiliario(Mobiliario Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosMobiliario = Datos;
                this.NuevoRegistro = false;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoMobiliario ~ frmNuevoMobiliario(Producto Datos)");
            }
        }

        #endregion

        #region Métodos

        private void AgregarItemAListaProveedor(Proveedor Item)
        {
            try
            {
                this.ListaProveedores.Add(Item);
                this.ListaProveedores = this.ListaProveedores.OrderBy(x => x.RazonSocial).ToList<Proveedor>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AgregarItemAListaProveedorSeleccionado(Proveedor Item)
        {
            try
            {
                this.ProveedoresXMobiliario.Add(Item);
                this.ProveedoresXMobiliario = this.ProveedoresXMobiliario.OrderBy(x => x.RazonSocial).ToList<Proveedor>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDatosAModificar(Mobiliario Datos)
        {
            try
            {
                if (!string.IsNullOrEmpty(Datos.IDMobiliario.Trim()))
                {
                    this.txtClave.Text = Datos.Codigo;
                    this.txtClave.ReadOnly = true;
                    this.txtDescripcion.Text = Datos.Descripcion;
                    this.txtMarca.Text = Datos.Marca;
                    this.txtModelo.Text = Datos.Modelo;
                    this.LlenarListaProveedores(this._DatosMobiliario.IDMobiliario);
                    this.ObtenerTablaProveedores(this._DatosMobiliario.IDMobiliario);
                    if (ExisteItemEnComboTipoMobiliario(Datos.IDTipoMobiliario))
                        this.cmbTipoMobiliario.SelectedValue = Datos.IDTipoMobiliario;
                }
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
                Tabla.Columns.Add("IDProveedorXProducto", typeof(string));
                Tabla.Columns.Add("IDProveedor", typeof(string));
                Tabla.Columns.Add("Costo", typeof(decimal));
                foreach (DataGridViewRow Fila in this.dgvProveedor.Rows)
                {
                    decimal UltimoCosto = 0;
                    decimal.TryParse(Fila.Cells["CostoUltimo"].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out UltimoCosto);
                    string IDProveedor = Fila.Cells["IDProveedor"].Value.ToString();
                    string IDProveedorXProducto = Fila.Cells["IDProductoXProveedor"].Value.ToString();
                    Tabla.Rows.Add(new object[] { IDProveedorXProducto, IDProveedor, UltimoCosto });
                }
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void IniciarDatos()
        {
            try
            {
                
                this.txtDescripcion.Text = string.Empty;
                //.....
                this.LlenarListaProveedores(string.Empty);
                this.ObtenerTablaProveedores(string.Empty);
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
                this.LlenarComboTipoMobiliario();
                if (!NuevoRegistro)
                {
                    this.CargarDatosAModificar(this._DatosMobiliario);
                }
                else
                    this.IniciarDatos();
                this.LlenarTablaProveedores();
                this.ActiveControl = this.txtClave;
                this.txtClave.Focus();
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

        private void LlenarTablaProveedores()
        {
            try
            {
                this.dgvProveedor.DataSource = null;
                this.dgvProveedor.AutoGenerateColumns = false;
                this.dgvProveedor.DataSource = ProveedoresXMobiliario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboTipoMobiliario()
        {
            try
            {
                TipoMobiliario DatosAux = new TipoMobiliario { Conexion = Comun.Conexion, IncluirSelect = true };
                TipoMobiliario_Negocio PN = new TipoMobiliario_Negocio();
                this.cmbTipoMobiliario.DataSource = PN.LlenarComboTipoMobiliario(DatosAux);
                this.cmbTipoMobiliario.DisplayMember = "Descripcion";
                this.cmbTipoMobiliario.ValueMember = "IDTipoMobiliario";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExisteItemEnComboTipoMobiliario(string IDTipoMobiliario)
        {
            try
            {
                bool Band = false;
                foreach (TipoMobiliario Item in this.cmbTipoMobiliario.Items)
                {
                    if (Item.IDTipoMobiliario == IDTipoMobiliario)
                    {
                        Band = true;
                        break;
                    }
                }
                return Band;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LlenarListaProveedores(string IDMobiliario)
        {
            try
            {
                Mobiliario DatosAux = new Mobiliario { IDMobiliario = IDMobiliario, Conexion = Comun.Conexion };
                Mobiliario_Negocio MobNeg = new Mobiliario_Negocio();
                this.ListaProveedores = MobNeg.ObtenerProveedoresDisponiblesXIDMobiliario(DatosAux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MostrarMensajeError(List<Error> Errores)
        {
            try
            {
                string cadenaErrores = string.Empty;
                cadenaErrores = "No se pudo guardar la información. Se presentaron los siguientes errores: \r\n";
                foreach (Error item in Errores)
                {
                    cadenaErrores += item.Numero + "\t" + item.Descripcion + "\r\n";
                }
                this.txtMensajeError.Visible = true;
                this.txtMensajeError.Text = cadenaErrores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Mobiliario ObtenerDatos()
        {
            try
            {
                Mobiliario DatosAux = new Mobiliario();
                DatosAux.NuevoRegistro = NuevoRegistro;
                DatosAux.IDMobiliario = !NuevoRegistro ? this._DatosMobiliario.IDMobiliario : string.Empty;
                TipoMobiliario TMAux = (TipoMobiliario)this.cmbTipoMobiliario.SelectedItem;
                DatosAux.IDTipoMobiliario = TMAux.IDTipoMobiliario;
                DatosAux.Codigo = this.txtClave.Text.Trim();
                DatosAux.Descripcion = this.txtDescripcion.Text.Trim();
                DatosAux.Modelo = this.txtModelo.Text.Trim();
                DatosAux.Marca = this.txtMarca.Text.Trim();
                DatosAux.TablaDatos = this.GenerarTablaProveedores();
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Producto ObtenerDetalleProductoXID(string IDProducto)
        {
            try
            {
                Producto_Negocio ProdNeg = new Producto_Negocio();
                return ProdNeg.ObtenerDatosProductoXID(new Producto { IDProducto = IDProducto, Conexion = Comun.Conexion });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Proveedor ObtenerDatosProveedorSeleccionado(int Row)
        {
            try
            {
                Proveedor DatosAux = new Proveedor();
                decimal CostoUltimo = 0;
                decimal.TryParse(this.dgvProveedor.Rows[Row].Cells["RazonSocial"].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out CostoUltimo);
                DatosAux.IDProveedor = this.dgvProveedor.Rows[Row].Cells["IDProveedor"].Value.ToString();
                DatosAux.RazonSocial = this.dgvProveedor.Rows[Row].Cells["RazonSocial"].Value.ToString();
                DatosAux.CostoUltimo = CostoUltimo;
                DatosAux.IDProductoXProveedor = this.dgvProveedor.Rows[Row].Cells["IDProductoXProveedor"].Value.ToString();
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Proveedor ObtenerItemProveedor(string IDProveedor)
        {
            try
            {
                Proveedor DatosAux = new Proveedor();

                foreach (Proveedor ItemAux in this.ListaProveedores)
                {
                    if (ItemAux.IDProveedor == IDProveedor)
                    {
                        DatosAux = ItemAux;
                        break;
                    }
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ObtenerTablaProveedores(string IDMobiliario)
        {
            try
            {
                Mobiliario DatosAux = new Mobiliario { Conexion = Comun.Conexion, IDMobiliario = IDMobiliario };
                Mobiliario_Negocio MobNeg = new Mobiliario_Negocio();
                this.ProveedoresXMobiliario = MobNeg.ObtenerProveedorXIDMobiliario(DatosAux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void QuitarItemAListaProveedor(string IDProveedor)
        {
            try
            {
                Proveedor Seleccionado = new Proveedor();
                foreach (Proveedor ItemAux in this.ListaProveedores)
                {
                    if (ItemAux.IDProveedor == IDProveedor)
                    {
                        Seleccionado = ItemAux;
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(Seleccionado.IDProveedor))
                    this.ListaProveedores.Remove(Seleccionado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void QuitarItemAListaProveedorSeleccionado(string IDProveedor)
        {
            try
            {
                Proveedor Seleccionado = new Proveedor();
                foreach (Proveedor ItemAux in this.ProveedoresXMobiliario)
                {
                    if (ItemAux.IDProveedor == IDProveedor)
                    {
                        Seleccionado = ItemAux;
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(Seleccionado.IDProveedor))
                    this.ProveedoresXMobiliario.Remove(Seleccionado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Error> ValidarDatos()
        {
            try
            {
                List<Error> Errores = new List<Error>();
                int Aux = 0;
                //if (string.IsNullOrEmpty(this.txtClave.Text.Trim()))
                //    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese una clave o código de barra", ControlSender = this.txtClave });
                if (this.cmbTipoMobiliario.SelectedIndex == 0 || this.cmbTipoMobiliario.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Selecciones un tipo de mobiliario", ControlSender = this.cmbTipoMobiliario });
                if (string.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese una descripción", ControlSender = this.txtDescripcion });
                else
                {
                    if (!Validar.IsValidDescripcion(this.txtDescripcion.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese una descripción válida.", ControlSender = this.txtDescripcion });
                }
                if (this.dgvProveedor.Rows.Count == 0)
                {
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Al menos se tiene que ingresar un proveedor.", ControlSender = this.dgvProveedor });
                }
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos    

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                frmElegirProveedor ElegirProv = new frmElegirProveedor();
                ElegirProv.DatosActuales = this.ListaProveedores;
                ElegirProv.ShowDialog();
                ElegirProv.Dispose();
                if (ElegirProv.DialogResult == DialogResult.OK)
                {
                    Proveedor ProvElegido = ElegirProv.Seleccionado;
                    this.QuitarItemAListaProveedor(ProvElegido.IDProveedor);
                    ProvElegido.CostoUltimo = 0;
                    ProvElegido.IDProductoXProveedor = string.Empty;
                    this.AgregarItemAListaProveedorSeleccionado(ProvElegido);
                    this.LlenarTablaProveedores();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "btnAgregarProveedor_Click ~ btnbEliminarProveedor_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                LogError.AddExcFileTxt(ex, "frmNuevoProductoServicio ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProveedor.SelectedRows.Count > 0)
                {
                    Int32 RowToDelete = this.dgvProveedor.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowToDelete > -1)
                    {
                        Proveedor ItemSeleccionado = this.ObtenerDatosProveedorSeleccionado(RowToDelete);
                        this.QuitarItemAListaProveedorSeleccionado(ItemSeleccionado.IDProveedor);
                        this.AgregarItemAListaProveedor(ItemSeleccionado);
                        this.LlenarTablaProveedores();
                        //this.dgvProveedor.Rows.RemoveAt(RowToDelete);
                    }
                }
                else
                    MessageBox.Show("Seleccione la fila del registro a eliminar.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProducto ~ btnbEliminarProveedor_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtMensajeError.Visible = false;
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                    Mobiliario Datos = this.ObtenerDatos();
                    Mobiliario_Negocio MobNeg = new Mobiliario_Negocio();
                    MobNeg.ACCatMobiliario(Datos);                    
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosMobiliario = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (Datos.Resultado == 51000)
                        {
                            List<Error> LstError = new List<Error>();
                            LstError.Add(new Error { Numero = 1, Descripcion = Datos.MensajeError, ControlSender = this });
                            this.MostrarMensajeError(LstError);
                        }
                        else
                            MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProductoServicio ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProveedor_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                DataGridView DgvSender = (DataGridView)sender;
                DgvSender.Rows[e.RowIndex].ErrorText = "";
                decimal Aux;
                object aux2 = DgvSender.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (DgvSender.Rows[e.RowIndex].IsNewRow) { return; }
                DataGridViewColumn Columna = DgvSender.Columns[e.ColumnIndex];
                if (Columna.Name == "Precio")
                {
                    if (!decimal.TryParse(e.FormattedValue.ToString().Replace("$", ""), NumberStyles.Currency, CultureInfo.CurrentCulture, out Aux))
                    {
                        e.Cancel = true;
                        DgvSender.Rows[e.RowIndex].ErrorText = "Debe ingresar un precio válido (No ingresar símbolo).";
                    }
                    else
                    {
                        if (Aux < 0)
                        {
                            e.Cancel = true;
                            DgvSender.Rows[e.RowIndex].ErrorText = "El precio debe ser mayor a 0.";
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProducto ~ dgvMonedero_CellValidating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProveedor_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                DataGridView DgvSender = (DataGridView)sender;
                e.Cancel = true;
                DgvSender.Rows[e.RowIndex].ErrorText = "Debe ingresar un precio válido (No ingresar símbolo).";
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProducto ~ dgvMonedero_DataError");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoProductoServicio_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProducto ~ frmNuevoProducto_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
