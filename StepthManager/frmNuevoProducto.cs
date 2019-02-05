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
using System.Drawing.Imaging;

namespace StephManager
{
    public partial class frmNuevoProducto : Form
    {
        
        #region Propiedades / Variables
        private int TipoForm = 0;
        private Producto _DatosProducto;
        public Producto DatosProducto
        {
            get { return _DatosProducto; }
            set { _DatosProducto = value; }
        }
        private List<Proveedor> ListaProveedores = new List<Proveedor>();
        private List<Proveedor> ProveedoresXProducto = new List<Proveedor>();
        string UrlImagen = string.Empty;
        #endregion

        #region Constructor(es)

        public frmNuevoProducto()
        {
            try
            {
                InitializeComponent();
                this._DatosProducto = new Producto();
                this.TipoForm = 1;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProducto ~ frmNuevoProducto()");
            }
        }

        public frmNuevoProducto(Producto Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosProducto = Datos;
                this.TipoForm = 2;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProducto ~ frmNuevoProducto(Producto Datos)");
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
                this.ProveedoresXProducto.Add(Item);
                this.ProveedoresXProducto = this.ProveedoresXProducto.OrderBy(x => x.RazonSocial).ToList<Proveedor>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BuscarImagen()
        {
            try
            {
                OpenFileDialog BuscarImagen = new OpenFileDialog();
                BuscarImagen.Filter = "Archivos de Imagen |*.jpg;*.jpeg;*.png";
                BuscarImagen.FileName = "";
                BuscarImagen.Title = "Subir Imagen Productos";
                //BuscarImagen.InitialDirectory = "C:\\";
                if (BuscarImagen.ShowDialog() == DialogResult.OK)
                {
                    //this.BandImagen = true;
                    this.UrlImagen = BuscarImagen.SafeFileName;
                    this.pbImagen.ImageLocation = BuscarImagen.FileName;
                    //Path.GetExtension(BuscarImagen.FileName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarCombos()
        {
            try
            {
                this.LlenarComboFamiliaProducto();
                this.LlenarComboTipoMetrica();
                this.LlenarComboTipoUso();
                this.LlenarComboUnidadMedida();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDatosAModificar(Producto Datos)
        {
            try
            {
                if (!string.IsNullOrEmpty(Datos.IDProducto.Trim()))
                {
                    if(this.cmbFamilia.Items.Count > 0)
                        this.cmbFamilia.SelectedValue = Datos.IDFamilia;
                    if(this.cmbUnidadMedida.Items.Count > 0)
                        this.cmbUnidadMedida.SelectedValue = Datos.IDUnidadMedida;
                    this.txtClave.Text = Datos.Clave;
                    this.txtNumInventario.Text = Datos.NumInventario;
                    this.txtNombreProducto.Text = Datos.NombreProducto;
                    if(this.cmbTipoUso.Items.Count > 0)
                        this.cmbTipoUso.SelectedValue = Datos.IDTipoUso;
                    if(this.cmbTipoMetrica.Items.Count > 0)
                        this.cmbTipoMetrica.SelectedValue = Datos.IDMetrica;
                    this.txtCantidadMetrica.Text = Datos.CantidadMetrica.ToString();
                    this.txtMargenError.Text = Datos.MargenError.ToString();
                    this.txtPrecioPublico.Text = string.Format("{0:c}", Datos.PrecioNormal);
                    this.chkIVA.Checked = Datos.AplicaIVA;
                    this.chkPrecioMayoreo.Checked = Datos.AplicaPrecioMayoreo;
                    if (Datos.AplicaPrecioMayoreo)
                    {
                        this.txtPrecioMayoreo.Enabled = true;
                        this.txtCantidadMayoreo.Enabled = true;
                    }
                    else
                    {
                        this.txtPrecioMayoreo.Enabled = false;
                        this.txtCantidadMayoreo.Enabled = false;
                    }
                    this.txtPrecioMayoreo.Text = string.Format("{0:c}", Datos.PrecioMayoreo);
                    this.txtCantidadMayoreo.Text = Datos.CantidadMayoreo.ToString();
                    this.chkPrecioTemporada.Checked = Datos.AplicaPrecioTemporada;
                    if (Datos.AplicaPrecioTemporada)
                    {
                        this.txtPrecioTemporada.Enabled = true;
                        this.dtpFechaInicioTemp.Enabled = true;
                        this.dtpFechaFinTemp.Enabled = true;
                    }
                    else
                    {
                        this.txtPrecioTemporada.Enabled = false;
                        this.dtpFechaInicioTemp.Enabled = false;
                        this.dtpFechaFinTemp.Enabled = false;
                    }
                    this.txtPrecioTemporada.Text = string.Format("{0:c}", Datos.PrecioTemporada);
                    this.dtpFechaInicioTemp.Value = Datos.FechaInicioTemp;
                    this.dtpFechaFinTemp.Value = Datos.FechaFinTemp;
                    this.chkPrecioEspecial.Checked = Datos.AplicaPrecioEspecial;
                    this.txtDescripcion.Text = Datos.Descripcion;
                    if (Datos.AplicaPrecioEspecial)
                    {
                        this.txtPrecioEspecial.Enabled = true;
                        this.chkAplicaLunes.Enabled = true;
                        this.chkAplicaMartes.Enabled = true;
                        this.chkAplicaMiercoles.Enabled = true;
                        this.chkAplicaJueves.Enabled = true;
                        this.chkAplicaViernes.Enabled = true;
                        this.chkAplicaSabado.Enabled = true;
                        this.chkAplicaDomingo.Enabled = true;
                    }
                    else
                    {
                        this.txtPrecioEspecial.Enabled = false;
                        this.chkAplicaLunes.Enabled = false;
                        this.chkAplicaMartes.Enabled = false;
                        this.chkAplicaMiercoles.Enabled = false;
                        this.chkAplicaJueves.Enabled = false;
                        this.chkAplicaViernes.Enabled = false;
                        this.chkAplicaSabado.Enabled = false;
                        this.chkAplicaDomingo.Enabled = false;
                    }
                    this.txtPrecioEspecial.Text = string.Format("{0:c}", Datos.PrecioEspecial);
                    this.chkAplicaLunes.Checked = Datos.PrecioEspecialLunes;
                    this.chkAplicaMartes.Checked = Datos.PrecioEspecialMartes;
                    this.chkAplicaMiercoles.Checked = Datos.PrecioEspecialMiercoles;
                    this.chkAplicaJueves.Checked = Datos.PrecioEspecialJueves;
                    this.chkAplicaViernes.Checked = Datos.PrecioEspecialViernes;
                    this.chkAplicaSabado.Checked = Datos.PrecioEspecialSabado;
                    this.chkAplicaDomingo.Checked = Datos.PrecioEspecialDomingo;
                    if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Productos\" + Datos.UrlImagen)))
                    {
                        this.pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
                        this.pbImagen.ImageLocation = Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Productos\" + Datos.UrlImagen);
                    }

                    this.chkRequiereStock.Checked = Datos.RequiereStock;
                    if(Datos.RequiereStock)
                    {
                        this.txtStockMaximo.Text = string.Format("{0:F2}", Datos.StockMaximo);
                        this.txtStockMinimo.Text = string.Format("{0:F2}", Datos.StockMinimo);
                    }
                    else
                    {
                        this.txtStockMaximo.Text = "0";
                        this.txtStockMinimo.Text = "0";
                    }

                    this.LlenarTablaMonederos(this._DatosProducto.IDProducto);
                    this.LlenarListaProveedores(this._DatosProducto.IDProducto);
                    this.ObtenerTablaProveedores(this._DatosProducto.IDProducto);
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

        private DataTable GenerarTablaMonedero()
        {
            try
            {
                DataTable Tabla = new DataTable();                
                Tabla.Columns.Add("IDTipoMonederoXProducto", typeof(string));
                Tabla.Columns.Add("IDTipoMonedero", typeof(int));
                Tabla.Columns.Add("Porcentaje", typeof(decimal));
                foreach (DataGridViewRow Fila in this.dgvMonedero.Rows)
                {
                    decimal Porcentaje = 0;
                    decimal.TryParse(Fila.Cells["Porcentaje"].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out Porcentaje);
                    int IDTipoMonedero = 0;
                    int.TryParse(Fila.Cells["IDTipoMonedero"].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out IDTipoMonedero);
                    string IDTipoMonederoXProducto = Fila.Cells["IDProductoXTipoMonedero"].Value.ToString();
                    Tabla.Rows.Add(new object[] { IDTipoMonederoXProducto, IDTipoMonedero, Porcentaje });
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
                if(this.cmbFamilia.Items.Count > 0)
                    this.cmbFamilia.SelectedValue = 0;
                if(this.cmbUnidadMedida.Items.Count > 0)
                    this.cmbUnidadMedida.SelectedValue = 0;
                this.txtClave.Text = string.Empty;
                this.txtNumInventario.Text = string.Empty;
                this.txtNombreProducto.Text = string.Empty;
                if(this.cmbTipoUso.Items.Count > 0)
                    this.cmbTipoUso.SelectedValue = 0;
                if(this.cmbTipoMetrica.Items.Count > 0)
                    this.cmbTipoMetrica.SelectedValue = 0;
                this.txtCantidadMetrica.Text = "0";
                this.txtMargenError.Text = "0";
                this.txtPrecioPublico.Text = string.Format("{0:c}", 0);
                this.chkIVA.Checked = true;
                this.chkPrecioMayoreo.Checked = false;
                this.txtPrecioMayoreo.Enabled = false;
                this.txtPrecioMayoreo.Text = string.Format("{0:c}", 0);
                this.txtCantidadMayoreo.Enabled = false;
                this.txtCantidadMayoreo.Text = "0";
                this.chkPrecioTemporada.Checked = false;
                this.txtPrecioTemporada.Enabled = false;
                this.txtPrecioTemporada.Text = string.Format("{0:c}", 0);
                this.dtpFechaInicioTemp.Enabled = false;
                this.dtpFechaInicioTemp.Value = DateTime.Today;
                this.dtpFechaFinTemp.Enabled = false;
                this.dtpFechaFinTemp.Value = DateTime.Today;
                this.chkPrecioEspecial.Checked = false;
                this.txtPrecioEspecial.Enabled = false;
                this.txtPrecioEspecial.Text = string.Format("{0:c}", 0);

                this.chkAplicaLunes.Checked = false;
                this.chkAplicaLunes.Enabled = false;
                this.chkAplicaMartes.Checked = false;
                this.chkAplicaMartes.Enabled = false;
                this.chkAplicaMiercoles.Checked = false;
                this.chkAplicaMiercoles.Enabled = false;
                this.chkAplicaJueves.Checked = false;
                this.chkAplicaJueves.Enabled = false;
                this.chkAplicaViernes.Checked = false;
                this.chkAplicaViernes.Enabled = false;
                this.chkAplicaSabado.Checked = false;
                this.chkAplicaSabado.Enabled = false;
                this.chkAplicaDomingo.Checked = false;
                this.chkAplicaDomingo.Enabled = false;

                this.txtStockMinimo.Text = "0";
                this.txtStockMaximo.Text = "0";

                this.LlenarTablaMonederos(string.Empty);
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
                this.CargarCombos();
                if (TipoForm == 2)
                {
                    this._DatosProducto = this.ObtenerDetalleProductoXID(this._DatosProducto.IDProducto);
                    this.CargarDatosAModificar(this._DatosProducto);
                }
                else
                    this.IniciarDatos();
                this.LlenarTablaProveedores();
                this.ActiveControl = this.cmbFamilia;
                this.cmbFamilia.Focus();
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

        private void LlenarComboFamiliaProducto()
        {
            try
            {
                FamiliaProducto DatosFamilia = new FamiliaProducto { Conexion = Comun.Conexion, Opcion = 2 };
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerCatFamiliaProductos(DatosFamilia);
                this.cmbFamilia.ValueMember = "IDFamilia";
                this.cmbFamilia.DisplayMember = "Descripcion";
                this.cmbFamilia.DataSource = DatosFamilia.TablaDatos;
                //DatosFamilia.TablaDatos.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboTipoMetrica()
        {
            try
            {
                TipoMetrica DatosMetrica = new TipoMetrica { Conexion = Comun.Conexion, Opcion = 2 };
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerCatTipoMetrica(DatosMetrica);
                this.cmbTipoMetrica.ValueMember = "IDTipoMetrica";
                this.cmbTipoMetrica.DisplayMember = "Descripcion";
                this.cmbTipoMetrica.DataSource = DatosMetrica.TablaDatos;
                //DatosMetrica.TablaDatos.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void LlenarComboTipoUso()
        {
            try
            {
                TipoUso DatosUso = new TipoUso { Conexion = Comun.Conexion, Opcion = 2 };
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerCatTipoUso(DatosUso);
                this.cmbTipoUso.ValueMember = "IDTipoUso";
                this.cmbTipoUso.DisplayMember = "Descripcion";
                this.cmbTipoUso.DataSource = DatosUso.TablaDatos;
                //DatosUso.TablaDatos.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboUnidadMedida()
        {
            try
            {
                UnidadMedida DatosUnidad = new UnidadMedida { Conexion = Comun.Conexion, Opcion = 2 };
                Catalogo_Negocio cn = new Catalogo_Negocio();
                cn.ObtenerCatUnidadMedida(DatosUnidad);
                this.cmbUnidadMedida.ValueMember = "IDUnidadMedida";
                this.cmbUnidadMedida.DisplayMember = "Descripcion";
                this.cmbUnidadMedida.DataSource = DatosUnidad.TablaDatos;
                //DatosUnidad.TablaDatos.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        private void LlenarTablaMonederos(string IDProducto)
        {
            try
            {
                TipoMonedero DatosAux = new TipoMonedero { Conexion = Comun.Conexion, IDProducto = IDProducto };
                Producto_Negocio ProdNeg = new Producto_Negocio();
                ProdNeg.ObtenerCatTipoMonederoXIDProducto(DatosAux);
                this.dgvMonedero.AutoGenerateColumns = false;
                this.dgvMonedero.DataSource = DatosAux.TablaDatos;
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
                this.dgvProveedor.DataSource = ProveedoresXProducto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarListaProveedores(string IDProducto)
        {
            try
            {
                Producto DatosAux = new Producto { IDProducto = IDProducto, Conexion = Comun.Conexion };
                Producto_Negocio ProdNeg = new Producto_Negocio();
                this.ListaProveedores = ProdNeg.ObtenerProveedoresDisponiblesXIDProducto(DatosAux);
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

        private Producto ObtenerDatos()
        {
            try
            {
                Producto DatosAux = new Producto();                
                FamiliaProducto AuxFP = this.ObtenerFamiliaSeleccionada();
                UnidadMedida AuxUM = this.ObtenerUnidadMedidaSeleccionada();
                TipoUso AuxTU = this.ObtenerTipoUsoSeleccionado();
                TipoMetrica AuxTM = this.ObtenerTipoMetricaSeleccionada();
                int CantidadMetrica = 0, CantidadMayoreo = 0, CantidadMargen = 0;
                decimal PrecioNormal = 0, PrecioMayoreo = 0, PrecioTemporada = 0, PrecioEspecial = 0;
                int.TryParse(this.txtCantidadMetrica.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out CantidadMetrica);
                int.TryParse(this.txtMargenError.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out CantidadMargen);
                int.TryParse(this.txtCantidadMayoreo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out CantidadMayoreo);
                decimal.TryParse(this.txtPrecioPublico.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioNormal);
                decimal.TryParse(this.txtPrecioMayoreo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioMayoreo);
                decimal.TryParse(this.txtPrecioTemporada.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioTemporada);
                decimal.TryParse(this.txtPrecioEspecial.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioEspecial);
                DatosAux.IDProducto = TipoForm == 2 ? this._DatosProducto.IDProducto : string.Empty;
                DatosAux.IDTipoProducto = 1;
                DatosAux.TipoProductoDesc = "Producto";
                DatosAux.IDFamilia = AuxFP.IDFamiliaProducto;
                DatosAux.FamiliaDesc = AuxFP.Descripcion;
                DatosAux.IDUnidadMedida = AuxUM.IDUnidadMedida;
                DatosAux.UnidadMedidaDesc = AuxUM.Descripcion;
                DatosAux.Clave = this.txtClave.Text.Trim();
                DatosAux.NumInventario = this.txtNumInventario.Text.Trim();
                DatosAux.NombreProducto = this.txtNombreProducto.Text.Trim();
                DatosAux.IDTipoUso = AuxTU.IDTipoUso;
                DatosAux.TipoUsoDesc = AuxTU.Descripcion;
                DatosAux.IDMetrica = AuxTM.IDTipoMetrica;
                DatosAux.MetricaDesc = AuxTM.Descripcion;
                DatosAux.CantidadMetrica = CantidadMetrica;
                DatosAux.PrecioNormal = PrecioNormal;
                DatosAux.AplicaIVA = this.chkIVA.Checked;
                DatosAux.Descripcion = this.txtDescripcion.Text;
                DatosAux.TablaMonederos = this.GenerarTablaMonedero();
                DatosAux.TablaProveedores = this.GenerarTablaProveedores();
                DatosAux.AplicaPrecioMayoreo = this.chkPrecioMayoreo.Checked;
                DatosAux.PrecioMayoreo = PrecioMayoreo;
                DatosAux.CantidadMayoreo = CantidadMayoreo;
                DatosAux.AplicaPrecioTemporada = this.chkPrecioTemporada.Checked;
                DatosAux.PrecioTemporada = PrecioTemporada;
                DatosAux.FechaInicioTemp = this.dtpFechaInicioTemp.Value;
                DatosAux.FechaFinTemp = this.dtpFechaFinTemp.Value;
                DatosAux.AplicaPrecioEspecial = this.chkPrecioEspecial.Checked;
                DatosAux.PrecioEspecial = PrecioEspecial;
                DatosAux.PrecioEspecialLunes = this.chkAplicaLunes.Checked;
                DatosAux.PrecioEspecialMartes = this.chkAplicaMartes.Checked;
                DatosAux.PrecioEspecialMiercoles = this.chkAplicaMiercoles.Checked;
                DatosAux.PrecioEspecialJueves = this.chkAplicaJueves.Checked;
                DatosAux.PrecioEspecialViernes = this.chkAplicaViernes.Checked;
                DatosAux.PrecioEspecialSabado = this.chkAplicaSabado.Checked;
                DatosAux.PrecioEspecialDomingo = this.chkAplicaDomingo.Checked;

                DatosAux.RequiereStock = this.chkRequiereStock.Checked;
                DatosAux.StockMaximo = DatosAux.RequiereStock ? this.GetStockMaximo() : 0;
                DatosAux.StockMinimo = DatosAux.RequiereStock ? this.GetStockMinimo() : 0;
                DatosAux.UrlImagen = string.Empty;
                DatosAux.Imagen = this.ObtenerImagenByte();
                

                DatosAux.Opcion = this.TipoForm;
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal GetStockMaximo()
        {
            try
            {
                decimal _StockMax = 0;
                decimal.TryParse(this.txtStockMaximo.Text, out _StockMax);
                return _StockMax;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private decimal GetStockMinimo()
        {
            try
            {
                decimal _StockMin = 0;
                decimal.TryParse(this.txtStockMinimo.Text, out _StockMin);
                return _StockMin;
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

        private FamiliaProducto ObtenerFamiliaSeleccionada()
        {
            try
            {
                FamiliaProducto DatosAux = new FamiliaProducto();
                if (this.cmbFamilia.SelectedIndex != -1)
                {
                    DataRowView Fila = (DataRowView)this.cmbFamilia.SelectedItem;
                    int IDFamilia = 0;
                    int.TryParse(Fila["IDFamilia"].ToString(), out IDFamilia);
                    DatosAux.IDFamiliaProducto = IDFamilia;
                    DatosAux.Descripcion = Fila["Descripcion"].ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private UnidadMedida ObtenerUnidadMedidaSeleccionada()
        {
            try
            {
                UnidadMedida DatosAux = new UnidadMedida();
                if (this.cmbUnidadMedida.SelectedIndex != -1)
                {
                    DataRowView Fila = (DataRowView)this.cmbUnidadMedida.SelectedItem;
                    int IDUnidadMedida = 0;
                    int.TryParse(Fila["IDUnidadMedida"].ToString(), out IDUnidadMedida);
                    DatosAux.IDUnidadMedida = IDUnidadMedida;
                    DatosAux.Descripcion = Fila["Descripcion"].ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private TipoUso ObtenerTipoUsoSeleccionado()
        {
            try
            {
                TipoUso DatosAux = new TipoUso();
                if (this.cmbTipoUso.SelectedIndex != -1)
                {
                    DataRowView Fila = (DataRowView)this.cmbTipoUso.SelectedItem;
                    int IDTipoUso = 0;
                    int.TryParse(Fila["IDTipoUso"].ToString(), out IDTipoUso);
                    DatosAux.IDTipoUso = IDTipoUso;
                    DatosAux.Descripcion = Fila["Descripcion"].ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private TipoMetrica ObtenerTipoMetricaSeleccionada()
        {
            try
            {
                TipoMetrica DatosAux = new TipoMetrica();
                if (this.cmbTipoMetrica.SelectedIndex != -1)
                {
                    DataRowView Fila = (DataRowView)this.cmbTipoMetrica.SelectedItem;
                    int IDTipoMetrica = 0;
                    int.TryParse(Fila["IDTipoMetrica"].ToString(), out IDTipoMetrica);
                    DatosAux.IDTipoMetrica = IDTipoMetrica;
                    DatosAux.Descripcion = Fila["Descripcion"].ToString();
                }
                return DatosAux;
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

        private byte[] ObtenerImagenByte()
        {
            try
            {

                ImageFormat Formato = ImageFormat.Jpeg;
                Image ImagenComp = ComprimirImagen.ResizeImage2(this.pbImagen.Image, 100, 100);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ImagenComp.Save(ms, Formato);
                return ms.GetBuffer();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Image ObtenerImagen()
        {
            try
            {
                ImageFormat Formato = ImageFormat.Jpeg;
                return ComprimirImagen.ResizeImage2(this.pbImagen.Image, 100, 100);
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

        private void ObtenerTablaProveedores(string IDProducto)
        {
            try
            {
                Producto DatosAux = new Producto { Conexion = Comun.Conexion, IDProducto = IDProducto };
                Producto_Negocio ProdNeg = new Producto_Negocio();
                this.ProveedoresXProducto = ProdNeg.ObtenerProveedorXIDProducto(DatosAux);
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
                foreach (Proveedor ItemAux in this.ProveedoresXProducto)
                {
                    if (ItemAux.IDProveedor == IDProveedor)
                    {
                        Seleccionado = ItemAux;
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(Seleccionado.IDProveedor))
                    this.ProveedoresXProducto.Remove(Seleccionado);
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
                int Aux = 0, ID = 0;                
                //Validar Combo SubTipo de Registro
                if (this.cmbFamilia.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción en SubTipo Registro.", ControlSender = this.cmbFamilia });
                else
                {
                    int.TryParse(this.cmbFamilia.SelectedValue.ToString(), out ID);
                    if (ID == 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción en SubTipo Registro.", ControlSender = this.cmbFamilia });
                }
                //Validar Combo Unidad de Medida
                if (this.cmbUnidadMedida.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción en Unidad de Medida.", ControlSender = this.cmbUnidadMedida });
                else
                {
                    int.TryParse(this.cmbUnidadMedida.SelectedValue.ToString(), out ID);
                    if (ID == 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción en Unidad de Medida.", ControlSender = this.cmbUnidadMedida });
                }
                //Validar TextBox Código de Barras
                if(string.IsNullOrEmpty(this.txtClave.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la clave o el código del producto.", ControlSender = this.txtClave });
                //Validar TextBox Número de Inventarios
                if(string.IsNullOrEmpty(this.txtNumInventario.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el número de Inventario.", ControlSender = this.txtNumInventario });
                //Validar TextBox Nombre de Producto
                if (string.IsNullOrEmpty(this.txtNombreProducto.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el Nombre del producto.", ControlSender = this.txtNombreProducto });
                //Validar Combo Tipo de uso
                if (this.cmbTipoUso.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción en Tipo de Uso.", ControlSender = this.cmbTipoUso });
                else
                {
                    int.TryParse(this.cmbTipoUso.SelectedValue.ToString(), out ID);
                    if (ID == 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción en Tipo de Uso.", ControlSender = this.cmbTipoUso });
                }
                //Validar Combo Tipo de métrica
                if (this.cmbTipoMetrica.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción en Tipo de Métrica.", ControlSender = this.cmbTipoMetrica });
                else
                {
                    int.TryParse(this.cmbTipoMetrica.SelectedValue.ToString(), out ID);
                    if (ID == 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción en Tipo de Métrica.", ControlSender = this.cmbTipoMetrica });
                }
                
                if (string.IsNullOrEmpty(this.txtCantidadMetrica.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la cantidad de Métrica.", ControlSender = this.txtCantidadMetrica });
                else
                {
                    int CantMet = 0;
                    if(!int.TryParse(this.txtCantidadMetrica.Text, out CantMet))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un dato válido en cantidad de Métrica.", ControlSender = this.txtCantidadMetrica });
                }

                if (string.IsNullOrEmpty(this.txtMargenError.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el margen de error de la métrica.", ControlSender = this.txtMargenError });
                else
                {
                    int CantMargen = 0;
                    if (!int.TryParse(this.txtMargenError.Text, out CantMargen))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un dato válido en margen de error de la métrica.", ControlSender = this.txtMargenError });
                }

                if (string.IsNullOrEmpty(this.txtPrecioPublico.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el Precio al Público.", ControlSender = this.txtPrecioPublico });
                else
                {
                    decimal PrecioNormal =0;
                    if(!decimal.TryParse(txtPrecioPublico.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioNormal))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un dato válido en Precio al Público.", ControlSender = this.txtPrecioPublico });
                }
                if(this.dgvProveedor.Rows.Count <= 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe elegir al menos un proveedor.", ControlSender = this.dgvProveedor });
                if (this.chkPrecioMayoreo.Checked)
                {
                    int CantMay = 0;
                    decimal PrecioMayoreo = 0;
                    if (!decimal.TryParse(this.txtPrecioMayoreo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioMayoreo))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un dato válido para Precio Mayoreo.", ControlSender = this.txtPrecioMayoreo});
                    else if (PrecioMayoreo <= 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Precio Mayoreo debe ser mayor a $ 0.00.", ControlSender = this.txtPrecioMayoreo });
                    if(!int.TryParse(this.txtCantidadMayoreo.Text, out CantMay))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un dato válido en Cantidad Mayoreo.", ControlSender = this.txtCantidadMayoreo });
                    else if(CantMay <= 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Cantidad Mayoreo debe ser mayor a 0.", ControlSender = this.txtCantidadMayoreo });
                }
                if (this.chkPrecioTemporada.Checked)
                {
                    decimal PrecioTemporada = 0;
                    if(!decimal.TryParse(this.txtPrecioTemporada.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioTemporada))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un dato válido para Precio Temporada.", ControlSender = this.txtPrecioTemporada });
                    else if (PrecioTemporada <= 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Precio Temporada debe ser mayor a $ 0.00.", ControlSender = this.txtPrecioTemporada });
                    if(this.dtpFechaInicioTemp.Value > this.dtpFechaFinTemp.Value)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La fecha Final debe ser mayor a la fecha Inicial", ControlSender = this.panelTemporada });
                    if(this.dtpFechaInicioTemp.Value < DateTime.Today)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La fechas de la temporada deben ser mayores a la fecha actual.", ControlSender = this.panelTemporada });
                }
                if (this.chkPrecioEspecial.Checked)
                {
                    decimal PrecioEspecial = 0;
                    if(!decimal.TryParse(this.txtPrecioEspecial.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioEspecial))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un dato válido para Precio Especial.", ControlSender = this.txtPrecioEspecial });
                    else if (PrecioEspecial <= 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Precio Especial debe ser mayor a $ 0.00.", ControlSender = this.txtPrecioEspecial });
                    if(!this.chkAplicaLunes.Checked
                        && !this.chkAplicaMartes.Checked
                        && !this.chkAplicaMiercoles.Checked
                        && !this.chkAplicaJueves.Checked
                        && !this.chkAplicaViernes.Checked
                        && !this.chkAplicaSabado.Checked
                        && !this.chkAplicaDomingo.Checked)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar al menos un día de la semana en Precio Especial", ControlSender = this.txtPrecioEspecial });
                }

                if (this.chkRequiereStock.Checked)
                {
                    decimal StockMinimo = GetStockMinimo();
                    decimal StockMaximo = GetStockMaximo();
                    if (StockMinimo < 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "El stock mínimo no puede ser menor a 0.", ControlSender = this.txtStockMinimo });
                    if (StockMaximo <= 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "El stock Máximo debe ser mayor a 0.", ControlSender = this.txtStockMaximo });
                    if (StockMinimo > StockMaximo)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "El stock Mínimo no puede ser mayor al Stock Máximo.", ControlSender = this.txtStockMaximo });
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
                    Producto Datos = this.ObtenerDatos();
                    Producto_Negocio ProdNeg = new Producto_Negocio();
                    ProdNeg.ABCCatProductos(Datos);                    
                    if (Datos.Completado)
                    {
                        this.ObtenerImagen().Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Productos\" + Datos.UrlImagen.ToLower()));
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosProducto = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (Datos.Resultado > 0)
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

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                this.BuscarImagen();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProductoServicio ~ btnSeleccionarImagen_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkPrecioEspecial_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkPrecioEspecial.Checked)
                {
                    this.txtPrecioEspecial.Enabled = true;
                    this.chkAplicaLunes.Enabled = true;
                    this.chkAplicaMartes.Enabled = true;
                    this.chkAplicaMiercoles.Enabled = true;
                    this.chkAplicaJueves.Enabled = true;
                    this.chkAplicaViernes.Enabled = true;
                    this.chkAplicaSabado.Enabled = true;
                    this.chkAplicaDomingo.Enabled = true;
                }
                else
                {
                    this.txtPrecioEspecial.Enabled = false;
                    this.chkAplicaLunes.Enabled = false;
                    this.chkAplicaMartes.Enabled = false;
                    this.chkAplicaMiercoles.Enabled = false;
                    this.chkAplicaJueves.Enabled = false;
                    this.chkAplicaViernes.Enabled = false;
                    this.chkAplicaSabado.Enabled = false;
                    this.chkAplicaDomingo.Enabled = false;
                }
                this.chkAplicaLunes.Checked = false;
                this.chkAplicaMartes.Checked = false;
                this.chkAplicaMiercoles.Checked = false;
                this.chkAplicaJueves.Checked = false;
                this.chkAplicaViernes.Checked = false;
                this.chkAplicaSabado.Checked = false;
                this.chkAplicaDomingo.Checked = false;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProductoServicio ~ chkPrecioEspecial_CheckedChanged");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkPrecioMayoreo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkPrecioMayoreo.Checked)
                {
                    this.txtPrecioMayoreo.Enabled = true;
                    this.txtCantidadMayoreo.Enabled = true;
                }
                else
                {
                    this.txtPrecioMayoreo.Enabled = false;
                    this.txtCantidadMayoreo.Enabled = false;
                }
                this.txtPrecioMayoreo.Text = string.Format("{0:c}", 0);
                this.txtCantidadMayoreo.Text = "1";
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProductoServicio ~ chkPrecioMayoreo_CheckedChanged");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkPrecioTemporada_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkPrecioTemporada.Checked)
                {
                    this.txtPrecioTemporada.Enabled = true;
                    this.dtpFechaInicioTemp.Enabled = true;
                    this.dtpFechaFinTemp.Enabled = true;
                }
                else
                {
                    this.txtPrecioTemporada.Enabled = false;
                    this.dtpFechaInicioTemp.Enabled = false;
                    this.dtpFechaFinTemp.Enabled = false;
                }
                this.txtPrecioTemporada.Text = string.Format("{0:c}", 0);
                this.dtpFechaInicioTemp.Value = DateTime.Today;
                this.dtpFechaFinTemp.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProductoServicio ~ chkPrecioTemporada_CheckedChanged");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMonedero_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                DataGridView DgvSender = (DataGridView)sender;
                DgvSender.Rows[e.RowIndex].ErrorText = "";
                decimal Aux;
                object aux2 = DgvSender.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (DgvSender.Rows[e.RowIndex].IsNewRow) { return; }
                DataGridViewColumn Columna = DgvSender.Columns[e.ColumnIndex];
                if (Columna.Name == "Porcentaje")
                {
                    if (!decimal.TryParse(e.FormattedValue.ToString().Replace("%", ""), NumberStyles.Currency, CultureInfo.CurrentCulture, out Aux))
                    {
                        e.Cancel = true;
                        DgvSender.Rows[e.RowIndex].ErrorText = "Debe ingresar un porcentaje válido (No ingresar símbolo).";
                    }
                    else
                    {
                        if (Aux < 0)
                        {
                            e.Cancel = true;
                            DgvSender.Rows[e.RowIndex].ErrorText = "El porcentaje debe ser mayor a 0.";
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

        private void dgvMonedero_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView DgvSender = (DataGridView)sender;
                DataGridViewColumn Columna = DgvSender.Columns[e.ColumnIndex];
                if (Columna.Name == "Porcentaje")
                {
                    decimal Porcentaje = 0;
                    string txt = DgvSender.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    decimal.TryParse(DgvSender.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out Porcentaje);
                    if (Porcentaje != 0)
                        Porcentaje = Porcentaje / 100;
                    DgvSender.CellValueChanged -= dgvMonedero_CellValueChanged;
                    DgvSender.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Porcentaje;
                    DgvSender.CellValueChanged += dgvMonedero_CellValueChanged;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProducto ~ dgvMonedero_CellValueChanged");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMonedero_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                DataGridView DgvSender = (DataGridView)sender;
                e.Cancel = true;
                DgvSender.Rows[e.RowIndex].ErrorText = "Debe ingresar un porcentaje válido (No ingresar símbolo).";
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProducto ~ dgvMonedero_DataError");
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

        private void frmNuevoProductoServicio_Resize(object sender, EventArgs e)
        {
            try
            {
                int Porcentaje = 25;
                int WidthPanel = (this.Size.Width * Porcentaje) / 100;
                //Fila 01
                int WidthPanel2 = (this.Size.Width * Porcentaje) / 100;                
                this.panel01_02.Size = new Size(WidthPanel2, this.panel3.Height);
                this.panel01_03.Size = new Size(WidthPanel2, this.panel3.Height);
                this.panel0104.Size = new Size(WidthPanel2, this.panel3.Height);
                //Fila 02
                this.panel02_01.Size = new Size(WidthPanel, this.panel3.Height);
                this.panel02_02.Size = new Size(WidthPanel * 2, this.panel3.Height);
                //Fila 03
                this.panel03_01.Size = new Size(WidthPanel, this.panel3.Height);
                this.panel03_02.Size = new Size(WidthPanel, this.panel3.Height);
                this.panel03_03.Size = new Size(WidthPanel, this.panel3.Height);
                //Fila 04
                this.panel04_01.Size = new Size((WidthPanel * 2) + 20, this.panel3.Height);
                //Fila 05
                this.panel05_01.Size = new Size(WidthPanel * 2, this.panel3.Height);
                //Fila06
                this.panel06_01.Size = new Size(WidthPanel, this.panel3.Height);
                this.panel06_02.Size = new Size(WidthPanel, this.panel3.Height);
                this.panel06_03.Size = new Size(WidthPanel, this.panel3.Height);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProducto ~ frmNuevoProductoServicio_Resize");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCantidad_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                TextBox TextCantidad = (TextBox)sender;
                int Cantidad = 0;
                int.TryParse(TextCantidad.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Cantidad);
                TextCantidad.Text = Cantidad.ToString();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProductoServicio ~ txtCantidad_Validating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrecio_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                TextBox TextPrecio = (TextBox)sender;
                decimal Precio = 0;
                decimal.TryParse(TextPrecio.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Precio);
                TextPrecio.Text = string.Format("{0:c}", Precio);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProductoServicio ~ txtPrecio_Validating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void chkRequiereStock_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkRequiereStock.Checked)
                {
                    this.txtStockMinimo.ReadOnly = false;
                    this.txtStockMaximo.ReadOnly = false;
                }
                else
                {
                    this.txtStockMinimo.ReadOnly = true;
                    this.txtStockMaximo.ReadOnly = true;
                }
                this.txtStockMinimo.Text = string.Format("{0:F0}", 0);
                this.txtStockMaximo.Text = string.Format("{0:F0}", 0);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProducto ~ chkRequiereStock_CheckedChanged");
            }
        }

        private void txtStock_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                TextBox Stock = (TextBox)sender;
                decimal StockDec = 0;
                decimal.TryParse(Stock.Text, out StockDec);
                Stock.Text = string.Format("{0:F0}", StockDec);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventarioCambiar ~ txtStock_Validating");
            }
        }
    }
}
