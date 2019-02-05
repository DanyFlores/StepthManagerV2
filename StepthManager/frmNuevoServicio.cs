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
    public partial class frmNuevoServicio : Form
    {
        #region Propiedades / Variables
        private int TipoForm = 0;
        private Servicio _DatosServicio;
        public Servicio DatosServicio
        {
            get { return _DatosServicio; }
            set { _DatosServicio = value; }
        }
        private List<Producto> ListaProductos = new List<Producto>();
        private List<Producto> ProductosXServicio = new List<Producto>();
        #endregion

        #region Constructor(es)

        public frmNuevoServicio()
        {
            try
            {
                InitializeComponent();
                this._DatosServicio = new Servicio();
                this.TipoForm = 1;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoServicio ~ frmNuevoServicio()");
            }
        }

        public frmNuevoServicio(Servicio Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosServicio = Datos;
                this.TipoForm = 2;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoServicio ~ frmNuevoServicio(Servicio Datos)");
            }
        }

        #endregion

        #region Métodos

        private void AgregarItemAListaProducto(Producto Item)
        {
            try
            {
                this.ListaProductos.Add(Item);
                this.ListaProductos = this.ListaProductos.OrderBy(x => x.NombreProducto).ToList<Producto>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AgregarItemAListaProveedorSeleccionado(Producto Item)
        {
            try
            {
                this.ProductosXServicio.Add(Item);
                this.ProductosXServicio = this.ProductosXServicio.OrderBy(x => x.NombreProducto).ToList<Producto>();
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
                BuscarImagen.Title = "Subir Imagen Servicio";
                //BuscarImagen.InitialDirectory = "C:\\";
                if (BuscarImagen.ShowDialog() == DialogResult.OK)
                {
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDatosAModificar(Servicio Datos)
        {
            try
            {
                if (!string.IsNullOrEmpty(Datos.IDServicio.Trim()))
                {
                    this.cmbFamilia.SelectedValue = Datos.IDFamilia;
                    this.txtClave.Text = Datos.Clave;
                    //this.txtNumInventario.Text = Datos.NumInventario;
                    this.txtNombreProducto.Text = Datos.NombreServicio;
                    this.txtDescripcion.Text = Datos.Descripcion;
                    this.txtTiempoMinutos.Text = Datos.TiempoMinutos.ToString();
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
                    this.LlenarTablaMonederos(this._DatosServicio.IDServicio);
                    this.LlenarListaProductos(this._DatosServicio.IDServicio);
                    this.ObtenerTablaProductos(this._DatosServicio.IDServicio);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GenerarTablaProductos()
        {
            try
            {
                DataTable Tabla = new DataTable();                
                Tabla.Columns.Add("IDProductoXServicio", typeof(string));
                Tabla.Columns.Add("IDProducto", typeof(string));
                Tabla.Columns.Add("Cantidad", typeof(int));
                foreach (DataGridViewRow Fila in this.dgvProducto.Rows)
                {
                    decimal Cantidad = 0;
                    decimal.TryParse(Fila.Cells["Cantidad"].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out Cantidad);
                    string IDProducto = Fila.Cells["IDProducto"].Value.ToString();
                    string IDProductoXServicio = Fila.Cells["IDProductoXServicio"].Value.ToString();
                    Tabla.Rows.Add(new object[] { IDProductoXServicio, IDProducto, Cantidad });
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
                this.txtClave.Text = string.Empty;
                this.cmbFamilia.SelectedValue = 0;
                //this.txtNumInventario.Text = string.Empty;
                this.txtNombreProducto.Text = string.Empty;
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

                this.LlenarTablaMonederos(string.Empty);
                this.LlenarListaProductos(string.Empty);
                this.ObtenerTablaProductos(string.Empty);
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
                    this._DatosServicio = this.ObtenerDetalleServicioXID(this._DatosServicio.IDServicio);
                    this.CargarDatosAModificar(this._DatosServicio);
                }
                else
                    this.IniciarDatos();
                this.LlenarTablaProductos();
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

        private void LlenarTablaProductos()
        {
            try
            {
                this.dgvProducto.DataSource = null;
                this.dgvProducto.AutoGenerateColumns = false;
                this.dgvProducto.DataSource = ProductosXServicio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarListaProductos(string IDServicio)
        {
            try
            {
                Servicio DatosAux = new Servicio { IDServicio = IDServicio, Conexion = Comun.Conexion };
                Servicio_Negocio ProdNeg = new Servicio_Negocio();
                this.ListaProductos = ProdNeg.ObtenerProductoDisponiblesXIDServicio(DatosAux);
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

        private Servicio ObtenerDatos()
        {
            try
            {
                Servicio DatosAux = new Servicio();
                FamiliaProducto AuxFP = this.ObtenerFamiliaSeleccionada();
                int CantidadMayoreo = 0, TiempoMinuto = 0;
                decimal PrecioNormal = 0, PrecioMayoreo = 0, PrecioTemporada = 0, PrecioEspecial = 0;
                int.TryParse(this.txtCantidadMayoreo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out CantidadMayoreo);
                decimal.TryParse(this.txtPrecioPublico.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioNormal);
                decimal.TryParse(this.txtPrecioMayoreo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioMayoreo);
                decimal.TryParse(this.txtPrecioTemporada.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioTemporada);
                decimal.TryParse(this.txtPrecioEspecial.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioEspecial);
                DatosAux.IDServicio = TipoForm == 2 ? this._DatosServicio.IDServicio : string.Empty;
                DatosAux.IDFamilia = AuxFP.IDFamiliaProducto;
                DatosAux.FamiliaDesc = AuxFP.Descripcion;
                DatosAux.Clave = this.txtClave.Text.Trim();
                //DatosAux.NumInventario = this.txtNumInventario.Text.Trim();
                DatosAux.NombreServicio = this.txtNombreProducto.Text.Trim();
                DatosAux.PrecioNormal = PrecioNormal;
                DatosAux.AplicaIVA = this.chkIVA.Checked;
                DatosAux.Descripcion = this.txtDescripcion.Text;
                DatosAux.TablaMonederos = this.GenerarTablaMonedero();
                DatosAux.TablaProductos = this.GenerarTablaProductos();
                DatosAux.AplicaPrecioMayoreo = this.chkPrecioMayoreo.Checked;
                DatosAux.PrecioMayoreo = PrecioMayoreo;
                DatosAux.CantidadMayoreo = CantidadMayoreo;
                DatosAux.AplicaPrecioTemporada = this.chkPrecioTemporada.Checked;
                DatosAux.PrecioTemporada = PrecioTemporada;
                int.TryParse(this.txtTiempoMinutos.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out TiempoMinuto);
                DatosAux.TiempoMinutos = TiempoMinuto;
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
                DatosAux.Imagen = this.ObtenerImagenByte();
                DatosAux.UrlImagen = string.Empty;
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

        private Servicio ObtenerDetalleServicioXID(string IDServicio)
        {
            try
            {
                //return null;
                Servicio_Negocio ServNeg = new Servicio_Negocio();
                return ServNeg.ObtenerDatosServicioXID(new Servicio { IDServicio = IDServicio, Conexion = Comun.Conexion });
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

        private Producto ObtenerDatosProductoSeleccionado(int Row)
        {
            try
            {
                Producto DatosAux = new Producto();
                int Cantidad = 0;
                int.TryParse(this.dgvProducto.Rows[Row].Cells["Cantidad"].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out Cantidad);
                DatosAux.IDProducto = this.dgvProducto.Rows[Row].Cells["IDProducto"].Value.ToString();
                DatosAux.NombreProducto = this.dgvProducto.Rows[Row].Cells["NombreProducto"].Value.ToString();
                //DatosAux.CantidadMayoreo = Cantidad;
                DatosAux.IDProductoXServicio = this.dgvProducto.Rows[Row].Cells["IDProductoXServicio"].Value.ToString();
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

        private Producto ObtenerItemProveedor(string IDProducto)
        {
            try
            {
                Producto DatosAux = new Producto();

                foreach (Producto ItemAux in this.ListaProductos)
                {
                    if (ItemAux.IDProducto == IDProducto)
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

        private void ObtenerTablaProductos(string IDServicio)
        {
            try
            {
                Servicio DatosAux = new Servicio { Conexion = Comun.Conexion, IDServicio = IDServicio };
                Servicio_Negocio ProdNeg = new Servicio_Negocio();
                this.ProductosXServicio = ProdNeg.ObtenerProductoXIDServicio(DatosAux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void QuitarItemAListaProducto(string IDProducto)
        {
            try
            {
                Producto Seleccionado = new Producto();
                foreach (Producto ItemAux in this.ListaProductos)
                {
                    if (ItemAux.IDProducto == IDProducto)
                    {
                        Seleccionado = ItemAux;
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(Seleccionado.IDProducto))
                    this.ListaProductos.Remove(Seleccionado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void QuitarItemAListaProductoSeleccionado(string IDProducto)
        {
            try
            {
                Producto Seleccionado = new Producto();
                foreach (Producto ItemAux in this.ProductosXServicio)
                {
                    if (ItemAux.IDProducto == IDProducto)
                    {
                        Seleccionado = ItemAux;
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(Seleccionado.IDProducto))
                    this.ProductosXServicio.Remove(Seleccionado);
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
                //Validar TextBox Código de Barras
                if(string.IsNullOrEmpty(this.txtClave.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la clave o el código del Servicio.", ControlSender = this.txtClave });
                //Validar TextBox Número de Inventarios
                //if (string.IsNullOrEmpty(this.txtNumInventario.Text.Trim()))
                //    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el número de Inventario.", ControlSender = this.txtNumInventario });
                //Validar TextBox Nombre de Producto
                if (string.IsNullOrEmpty(this.txtNombreProducto.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el Nombre del Servicio.", ControlSender = this.txtNombreProducto });
                
                if (string.IsNullOrEmpty(this.txtPrecioPublico.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el Precio al Público.", ControlSender = this.txtPrecioPublico });
                else
                {
                    decimal PrecioNormal =0;
                    if(!decimal.TryParse(txtPrecioPublico.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioNormal))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un dato válido en Precio al Público.", ControlSender = this.txtPrecioPublico });
                }
                if (string.IsNullOrEmpty(this.txtTiempoMinutos.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el Tiempo se servicio en minutos.", ControlSender = this.txtTiempoMinutos });
                else
                {
                    if (!Validar.IsValidOnlyNumber(this.txtTiempoMinutos.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar Tiempo se servicio en minutos válido.", ControlSender = this.txtTiempoMinutos });
                }     
                if(this.dgvProducto.Rows.Count <= 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe elegir al menos un proveedor.", ControlSender = this.dgvProducto });
                //if (this.chkPrecioMayoreo.Checked)
                //{
                //    int CantMay = 0;
                //    decimal PrecioMayoreo = 0;
                //    if (!decimal.TryParse(this.txtPrecioMayoreo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioMayoreo))
                //        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un dato válido para Precio Mayoreo.", ControlSender = this.txtPrecioMayoreo});
                //    else if (PrecioMayoreo <= 0)
                //        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Precio Mayoreo debe ser mayor a $ 0.00.", ControlSender = this.txtPrecioMayoreo });
                //    if(!int.TryParse(this.txtCantidadMayoreo.Text, out CantMay))
                //        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un dato válido en Cantidad Mayoreo.", ControlSender = this.txtCantidadMayoreo });
                //    else if(CantMay <= 0)
                //        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Cantidad Mayoreo debe ser mayor a 0.", ControlSender = this.txtCantidadMayoreo });
                //}
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
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos    

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                frmElegirProducto ElegirProv = new frmElegirProducto();
                ElegirProv.DatosActuales = this.ListaProductos;
                ElegirProv.ShowDialog();
                ElegirProv.Dispose();
                if (ElegirProv.DialogResult == DialogResult.OK)
                {
                    Producto ProvElegido = ElegirProv.Seleccionado;
                    this.QuitarItemAListaProducto(ProvElegido.IDProducto);
                    ProvElegido.Cantidad = 1;
                    ProvElegido.IDProductoXServicio = string.Empty;
                    this.AgregarItemAListaProveedorSeleccionado(ProvElegido);
                    this.LlenarTablaProductos();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoServicio ~ btnAgregarProducto_Click");
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
                LogError.AddExcFileTxt(ex, "frmNuevoServicio ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProducto.SelectedRows.Count > 0)
                {
                    Int32 RowToDelete = this.dgvProducto.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowToDelete > -1)
                    {
                        Producto ItemSeleccionado = this.ObtenerDatosProductoSeleccionado(RowToDelete);
                        this.QuitarItemAListaProductoSeleccionado(ItemSeleccionado.IDProducto);
                        this.AgregarItemAListaProducto(ItemSeleccionado);
                        this.LlenarTablaProductos();
                    }
                }
                else
                    MessageBox.Show("Seleccione la fila del registro a eliminar.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoServicio ~ btnEliminarProducto_Click");
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
                    Servicio Datos = this.ObtenerDatos();
                    Servicio_Negocio ProdNeg = new Servicio_Negocio();
                    ProdNeg.ABCCatServicio(Datos);
                    if (Datos.Completado)
                    {
                        this.ObtenerImagen().Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Productos\" + Datos.UrlImagen.ToLower()));
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosServicio = Datos;
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
                LogError.AddExcFileTxt(ex, "frmNuevoServicio ~ btnGuardar_Click");
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
                LogError.AddExcFileTxt(ex, "frmNuevoServicio ~ btnSeleccionarImagen_Click");
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
                LogError.AddExcFileTxt(ex, "frmNuevoServicio ~ chkPrecioEspecial_CheckedChanged");
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
                LogError.AddExcFileTxt(ex, "frmNuevoServicio ~ chkPrecioMayoreo_CheckedChanged");
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
                LogError.AddExcFileTxt(ex, "frmNuevoServicio ~ chkPrecioTemporada_CheckedChanged");
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
                LogError.AddExcFileTxt(ex, "frmNuevoServicio ~ dgvMonedero_CellValidating");
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
                LogError.AddExcFileTxt(ex, "frmNuevoServicio ~ dgvMonedero_CellValueChanged");
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
                LogError.AddExcFileTxt(ex, "frmNuevoServicio ~ dgvMonedero_DataError");
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
                LogError.AddExcFileTxt(ex, "frmNuevoServicio ~ dgvMonedero_CellValidating");
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
                LogError.AddExcFileTxt(ex, "frmNuevoServicio ~ dgvMonedero_DataError");
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
                LogError.AddExcFileTxt(ex, "frmNuevoServicio ~ frmNuevoProducto_Load");
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
                this.panel01_01.Size = new Size(WidthPanel, this.panel3.Height);
                this.panel01_02.Size = new Size(WidthPanel, this.panel3.Height);
                this.panel01_03.Size = new Size(WidthPanel, this.panel3.Height);
                //Fila 02
                //this.panel02_01.Size = new Size(WidthPanel, this.panel3.Height);
                this.panel02_02.Size = new Size(WidthPanel * 2, this.panel3.Height);
                //Fila 03
                //this.panel03_01.Size = new Size(WidthPanel, this.panel3.Height);
                //this.panel03_02.Size = new Size(WidthPanel, this.panel3.Height);
                //this.panel03_03.Size = new Size(WidthPanel, this.panel3.Height);
                //Fila 04
                this.panel04_01.Size = new Size((WidthPanel * 2) + 20, this.panel3.Height);
                //Fila 05
                this.panel05_01.Size = new Size(WidthPanel * 3, this.panel3.Height);
                //Fila06
                this.panel06_01.Size = new Size(WidthPanel, this.panel3.Height);
                this.panel06_02.Size = new Size(WidthPanel, this.panel3.Height);
                this.panel06_03.Size = new Size(WidthPanel, this.panel3.Height);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoServicio ~ frmNuevoProductoServicio_Resize");
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
                LogError.AddExcFileTxt(ex, "frmNuevoServicio ~ txtCantidad_Validating");
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
                LogError.AddExcFileTxt(ex, "frmNuevoServicio ~ txtPrecio_Validating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
