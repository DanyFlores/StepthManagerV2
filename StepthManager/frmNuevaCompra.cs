using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
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
    public partial class frmNuevaCompra : Form
    {
        #region Propiedades / variables

        private List<Producto> ListaProductos = new List<Producto>();
        private Producto Actual = new Producto();
        private string IDProveedor = string.Empty;
        private bool NuevoRegistro = false;
        private string IDCompra = string.Empty;

        #endregion

        #region Constructor

        public frmNuevaCompra()
        {
            try
            {
                InitializeComponent();
                this.NuevoRegistro = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaCompra ~ frmNuevaCompra()");
            }
        }

        public frmNuevaCompra(string ID)
        {
            try
            {
                InitializeComponent();
                this.NuevoRegistro = false;
                this.IDCompra = ID;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaCompra ~ frmNuevaCompra()");
            }
        }

        #endregion

        #region Métodos

        private void CargarGridProductos()
        {
            try
            {
                this.dgvProductos.DataSource = null;
                this.dgvProductos.AutoGenerateColumns = false;
                this.dgvProductos.DataSource = this.ListaProductos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DibujarTotal()
        {
            try
            {
                ConvertirMonedaTexto Conv = new ConvertirMonedaTexto();
                decimal Total = this.ObtenerTotal();
                this.txtTotal.Text = string.Format("{0:c}", Total);
                this.txtTotalLetras.Text = Conv.Convertir(Total.ToString(), true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExisteProductoEnLista(Producto Datos)
        {
            try
            {
                bool Band = false;
                foreach (Producto Item in ListaProductos)
                {
                    if (Item.IDProducto == Datos.IDProducto)
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

        private bool ExisteItemEnCombo(string IDProveedor)
        {
            try
            {
                bool Band = false;
                foreach (Proveedor Item in this.cmbProveedor.Items)
                {
                    if (Item.IDProveedor == IDProveedor)
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

        private void IniciarDatosNuevoProducto()
        {
            try
            {
                this.Actual = new Producto();
                this.txtProducto.Text = string.Empty;
                this.txtClave.Text = string.Empty;
                this.txtUltimoCosto.Text = string.Format("{0:c}", 0);
                this.txtCantidad.Text = "1";
                this.txtPrecio.Text = string.Format("{0:c}", 0);
                this.txtPrecioUSD.Text = string.Format("{0:c}", 0);
                this.txtIva.Text = string.Format("{0:c}", 0);
                this.txtUnidadMedida.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void IniciarDatosProveedor()
        {
            try
            {
                this.txtProvRazonSocial.Text = string.Empty;
                this.txtProvRFC.Text = string.Empty;
                this.txtProvRegimen.Text = string.Empty;
                this.txtProvDomicilio.Text = string.Empty;
                this.IDProveedor = string.Empty;
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
                this.LlenarComboProveedores();
                this.IniciarDatosNuevoProducto();
                if (!NuevoRegistro)
                {
                    Compra DatosAux = this.ObtenerDatosGuardadosCompra();
                    this.LlenarDatosCompraModificar(DatosAux);
                }
                this.DibujarTotal();
                this.ActiveControl = this.txtNumFactura;
                this.txtNumFactura.Focus();
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

        private void LlenarComboProveedores()
        {
            try
            {
                Proveedor DatosAux = new Proveedor { Conexion = Comun.Conexion, IncluirSelect = true };
                Proveedor_Negocio PN = new Proveedor_Negocio();
                this.cmbProveedor.DataSource = PN.LlenarComboProveedores(DatosAux);
                this.cmbProveedor.DisplayMember = "NombreComercial";
                this.cmbProveedor.ValueMember = "IDProveedor";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarDatosCompraModificar(Compra Aux)
        {
            try
            {
                this.cmbProveedor.SelectedValueChanged -= new System.EventHandler(this.cmbProveedor_SelectedValueChanged);
                this.txtNumFactura.Text = Aux.NumFactura;
                if (ExisteItemEnCombo(Aux.IDProveedor))
                    this.cmbProveedor.SelectedValue = Aux.IDProveedor;
                this.txtProvRazonSocial.Text = Aux.RazonSocial;
                this.txtProvRFC.Text = Aux.RFC;
                this.txtProvDomicilio.Text = Aux.DomicilioFiscal;
                this.txtProvRegimen.Text = Aux.RegimenFiscal;
                this.dtpFechaEmision.Value = Aux.FechaEmision;
                this.dtpFechaHoraCert.Value = Aux.FechaHoraCertificacion;
                this.txtLugarExpedicion.Text = Aux.LugarExpedicion;
                this.txtFolioFiscal.Text = Aux.FolioFiscal;
                this.txtNoSerieCertificadoSat.Text = Aux.NoSerieCertSAT;
                this.txtNoSerieCertificadoEmisor.Text = Aux.NoSerieCertEmisor;
                this.ListaProductos = Aux.ListaProductos;
                this.IDProveedor = Aux.IDProveedor;
                this.CargarGridProductos();
                this.cmbProveedor.SelectedValueChanged += new System.EventHandler(this.cmbProveedor_SelectedValueChanged);
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
                string CadenaErrores = string.Empty;
                CadenaErrores = "No se pudo guardar la información. Se presentaron los siguientes errores: \r\n";
                foreach (Error item in Errores)
                {
                    CadenaErrores += item.Numero + "\t" + item.Descripcion + "\r\n";
                }
                this.txtMensajeError.Visible = true;
                this.txtMensajeError.Text = CadenaErrores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int ObtenerCantidadProductoActual()
        {
            try
            {
                int Cantidad = 0;
                int.TryParse(this.txtCantidad.Text, out Cantidad);
                return Cantidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Compra ObtenerDatosCompra()
        {
            try
            {
                Compra DatosAux = new Compra();
                Compra Totales = this.ObtenerTotales();
                DatosAux.NuevoRegistro = this.NuevoRegistro;
                DatosAux.IDCompra = this.IDCompra;
                DatosAux.IDEstatusCompra = 1;
                DatosAux.IDProveedor = this.IDProveedor;
                DatosAux.IDSucursal = Comun.IDSucursalCaja;
                DatosAux.RazonSocial = this.txtProvRazonSocial.Text.Trim();
                DatosAux.RFC = this.txtProvRFC.Text.Trim();
                DatosAux.DomicilioFiscal = this.txtProvDomicilio.Text.Trim();
                DatosAux.NumFactura = this.txtNumFactura.Text.Trim();
                DatosAux.RegimenFiscal = this.txtProvRegimen.Text.Trim();
                DatosAux.FolioFiscal = this.txtFolioFiscal.Text.Trim();
                DatosAux.NoSerieCertSAT = this.txtNoSerieCertificadoSat.Text.Trim();
                DatosAux.FechaHoraCertificacion = this.dtpFechaHoraCert.Value;
                DatosAux.NoSerieCertEmisor = this.txtNoSerieCertificadoEmisor.Text.Trim();
                DatosAux.FechaEmision = this.dtpFechaEmision.Value;
                DatosAux.LugarExpedicion = this.txtLugarExpedicion.Text.Trim();
                DatosAux.Subtotal = Totales.Subtotal;
                DatosAux.Descuento = Totales.Descuento;
                DatosAux.Iva = Totales.Iva;
                DatosAux.Total = Totales.Total;
                DatosAux.TotalLetras = this.txtTotalLetras.Text.Trim();
                DatosAux.TablaProductos = this.ObtenerTablaDetalleProductos();
                DatosAux.IDUsuario = Comun.IDUsuario;
                DatosAux.Conexion = Comun.Conexion;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Compra ObtenerDatosGuardadosCompra()
        {
            try
            {
                Compra DatosAux = new Compra { Conexion = Comun.Conexion, IDCompra = this.IDCompra };
                Compra_Negocio CN = new Compra_Negocio();
                return CN.ObtenerDatosCompra(DatosAux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ObtenerDatosProveedor(Proveedor DatosAux)
        {
            try
            {
                DatosAux.Conexion = Comun.Conexion;
                Proveedor_Negocio ProvNeg = new Proveedor_Negocio();
                ProvNeg.ObtenerDatosFiscalesXProveedor(DatosAux);
                this.txtProvRazonSocial.Text = string.IsNullOrEmpty(DatosAux.RazonSocial) ? string.Empty : DatosAux.RazonSocial;
                this.txtProvRFC.Text = string.IsNullOrEmpty(DatosAux.RFC) ? string.Empty : DatosAux.RFC;
                this.txtProvRegimen.Text = string.IsNullOrEmpty(DatosAux.RegimenFiscal) ? string.Empty : DatosAux.RegimenFiscal;
                this.txtProvDomicilio.Text = string.IsNullOrEmpty(DatosAux.Direccion) ? string.Empty : DatosAux.Direccion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerIvaProductoActual()
        {
            try
            {
                decimal Iva = 0;
                decimal.TryParse(this.txtIva.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Iva);
                return Iva;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerPrecioProductoActual()
        {
            try
            {
                decimal Precio = 0;
                decimal.TryParse(this.txtPrecio.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Precio);
                return Precio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerPrecioProductoUSDActual()
        {
            try
            {
                decimal Precio = 0;
                decimal.TryParse(this.txtPrecioUSD.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Precio);
                return Precio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Proveedor ObtenerProveedorSeleccionado()
        {
            try
            {
                Proveedor DatosAux = new Proveedor();
                if (this.cmbProveedor.SelectedIndex != -1)
                {
                    DatosAux = (Proveedor)this.cmbProveedor.SelectedItem;
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable ObtenerTablaDetalleProductos()
        {
            try
            {
                string IDProducto = string.Empty, FolioProducto = string.Empty, NombreProducto = string.Empty;
                int IDUnidadMedida = 0, Cantidad = 0;
                decimal PrecioUnitario = 0, DescuentoUnitario = 0, IvaUnitario = 0, Subtotal = 0, Descuento = 0, Iva = 0, Total = 0, PrecioUSD = 0;
                DataTable TablaDatos = new DataTable();
                TablaDatos.Columns.Add("IDProducto", typeof(string));
                TablaDatos.Columns.Add("IDUnidadMedida", typeof(int));
                TablaDatos.Columns.Add("FolioProducto", typeof(string));
                TablaDatos.Columns.Add("NombreProducto", typeof(string));
                TablaDatos.Columns.Add("Cantidad", typeof(int));
                TablaDatos.Columns.Add("PrecioU", typeof(decimal));
                TablaDatos.Columns.Add("Subtotal", typeof(decimal));
                TablaDatos.Columns.Add("DescuentoUnitario", typeof(decimal));
                TablaDatos.Columns.Add("Descuento", typeof(decimal));
                TablaDatos.Columns.Add("IvaUnitario", typeof(decimal));
                TablaDatos.Columns.Add("Iva", typeof(decimal));
                TablaDatos.Columns.Add("Total", typeof(decimal));
                TablaDatos.Columns.Add("PrecioUSD", typeof(decimal));

                foreach (DataGridViewRow Fila in this.dgvProductos.Rows)
                {
                    IDProducto = Fila.Cells["IDProducto"].Value.ToString();
                    int.TryParse(Fila.Cells["IDUnidadMedida"].Value.ToString(), out IDUnidadMedida);
                    FolioProducto = Fila.Cells["Clave"].Value.ToString();
                    NombreProducto = Fila.Cells["NombreProducto"].Value.ToString();
                    int.TryParse(Fila.Cells["Cantidad"].Value.ToString(), out Cantidad);
                    decimal.TryParse(Fila.Cells["PrecioUnitario"].Value.ToString(), out PrecioUnitario);
                    decimal.TryParse(Fila.Cells["Subtotal"].Value.ToString(), out Subtotal);
                    decimal.TryParse(Fila.Cells["DescuentoUnitario"].Value.ToString(), out DescuentoUnitario);
                    decimal.TryParse(Fila.Cells["Descuento"].Value.ToString(), out Descuento);
                    decimal.TryParse(Fila.Cells["IvaUnitario"].Value.ToString(), out IvaUnitario);
                    decimal.TryParse(Fila.Cells["IVA"].Value.ToString(), out Iva);
                    decimal.TryParse(Fila.Cells["Total"].Value.ToString(), out Total);
                    decimal.TryParse(Fila.Cells["PrecioUSD"].Value.ToString(), out PrecioUSD);
                    TablaDatos.Rows.Add(IDProducto, IDUnidadMedida, FolioProducto, NombreProducto,
                        Cantidad, PrecioUnitario, Subtotal, DescuentoUnitario, Descuento, IvaUnitario,
                        Iva, Total, PrecioUSD);
                }
                return TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerTotal()
        {
            try
            {
                decimal Total = 0;
                foreach (Producto Item in ListaProductos)
                {
                    Total += Item.Total;
                }
                return Total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Compra ObtenerTotales()
        {
            try
            {
                Compra DatosAux = new Compra();
                decimal Subtotal = 0, Descuento = 0, Iva = 0, Total = 0;
                foreach (Producto Item in ListaProductos)
                {
                    Subtotal += Item.Subtotal;
                    Descuento += Item.DescuentoTotal;
                    Iva += Item.IvaTotal;
                    Total += Item.Total;
                }
                DatosAux.Subtotal = Subtotal;
                DatosAux.Descuento = Descuento;
                DatosAux.Iva = Iva;
                DatosAux.Total = Total;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool RemoverItemProducto(string ID)
        {
            try
            {
                Producto Remove = new Producto();
                bool Band = false;
                foreach (Producto Item in ListaProductos)
                {
                    if (Item.IDProducto == ID)
                    {
                        Remove = Item;
                        Band = true;
                        break;
                    }
                }
                if (Band)
                    this.ListaProductos.Remove(Remove);
                return Band;
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
                List<Error> Lista = new List<Error>();
                int Aux = 0;
                if (string.IsNullOrEmpty(this.txtNumFactura.Text.Trim()))
                    Lista.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un número de Factura.", ControlSender = this.txtNumFactura });
                if (string.IsNullOrEmpty(this.IDProveedor.Trim()))
                    Lista.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un proveedor de la lista.", ControlSender = this.cmbProveedor });
                if(this.dgvProductos.Rows.Count == 0)
                    Lista.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe agregar productos a la compra.", ControlSender = this.dgvProductos });
                if (this.ObtenerTotal() < 0)
                    Lista.Add(new Error { Numero = (Aux += 1), Descripcion = "El total de la compra no puede ser menor que 0.", ControlSender = this.dgvProductos });

                return Lista;
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
                if (!string.IsNullOrEmpty(this.Actual.IDProducto.Trim()))
                {
                    if (!string.IsNullOrEmpty(this.IDProveedor))
                    {
                        if (!ExisteProductoEnLista(this.Actual))
                        {
                            decimal PrecioCompra = this.ObtenerPrecioProductoActual();
                            decimal IvaProd = this.ObtenerIvaProductoActual();
                            decimal DescProd = 0;
                            decimal PrecioCompraUSD = this.ObtenerPrecioProductoUSDActual();
                            int CantidadProd = this.ObtenerCantidadProductoActual();
                            if (CantidadProd > 0)
                            {
                                if (PrecioCompra >= 0)
                                {
                                    if (DescProd <= (PrecioCompra + IvaProd))
                                    {
                                        Producto NuevoProducto = new Producto { IDProducto = this.Actual.IDProducto, Clave = this.Actual.Clave, NombreProducto = this.Actual.NombreProducto, IDUnidadMedida = this.Actual.IDUnidadMedida, UnidadMedidaDesc = this.Actual.UnidadMedidaDesc };
                                        NuevoProducto.Cantidad = CantidadProd;
                                        NuevoProducto.PrecioCompra = PrecioCompra;
                                        NuevoProducto.Iva = IvaProd;
                                        NuevoProducto.IvaTotal = NuevoProducto.Iva * NuevoProducto.Cantidad;
                                        NuevoProducto.Descuento = DescProd;
                                        NuevoProducto.PrecioUSD = PrecioCompraUSD;
                                        NuevoProducto.DescuentoTotal = NuevoProducto.Descuento * NuevoProducto.Cantidad;
                                        NuevoProducto.Subtotal = NuevoProducto.Cantidad * NuevoProducto.PrecioCompra;
                                        NuevoProducto.Total = NuevoProducto.Subtotal - NuevoProducto.DescuentoTotal + NuevoProducto.IvaTotal;
                                        this.ListaProductos.Add(NuevoProducto);
                                        this.CargarGridProductos();
                                        this.DibujarTotal();
                                    }
                                    else
                                    {
                                        MessageBox.Show("El descuento no puede ser mayor al precio con IVA.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);    
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El precio no puede ser menor a $ 0.00.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("La cantidad debe ser mayor a 0.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaCompra ~ btnAgregarProducto_Click");
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
                LogError.AddExcFileTxt(ex, "frmNuevaCompra ~ btnAgregarProducto_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElegirProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.IDProveedor))
                {
                    frmSeleccionarProducto ElegirProducto = new frmSeleccionarProducto(4);
                    ElegirProducto.Datos.IDProveedor = this.IDProveedor;
                    ElegirProducto.Location = this.txtProducto.PointToScreen(new Point());
                    ElegirProducto.Location = new Point(ElegirProducto.Location.X - 1, ElegirProducto.Location.Y - 2);
                    ElegirProducto.ShowDialog();
                    ElegirProducto.Dispose();
                    if (ElegirProducto.DialogResult == DialogResult.OK)
                    {
                        Producto Aux = ElegirProducto.Datos;
                        Aux.Conexion = Comun.Conexion;
                        this.txtProducto.Text = Aux.NombreProducto;
                        this.txtClave.Text = Aux.Clave;
                        this.txtUltimoCosto.Text = string.Format("{0:c}", Aux.UltimoCosto);
                        this.txtUnidadMedida.Text = Aux.UnidadMedidaDesc;
                        this.txtPrecio.Text = string.Format("{0:c}", 0);
                        this.txtPrecioUSD.Text = string.Format("{0:c}", 0);
                        this.txtIva.Text = string.Format("{0:c}", 0);
                        this.txtCantidad.Text = "1";
                        this.Actual = Aux;
                        this.txtCantidad.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Debe elegir un proveedor.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaCompra ~ btnElegirProducto_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                    Compra Aux = this.ObtenerDatosCompra();
                    Compra_Negocio CN = new Compra_Negocio();
                    CN.ACCompras(Aux);
                    if (Aux.Completado)
                    {
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (Aux.Resultado < 0)
                        {
                            List<Error> Error = new List<Error>();
                            Error.Add(new Error { Numero = 1, Descripcion = Aux.MensajeError, ControlSender = this.dgvProductos });
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al guardar los datos.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LogError.AddExcFileTxt(new Exception(Aux.MensajeError), "frmNuevaCompra ~ btnGuardar_Click");
                        }
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaCompra ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProveedor_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.IDProveedor = string.Empty;
                if (this.cmbProveedor.SelectedIndex != -1)
                {
                    Proveedor DatosAux = this.ObtenerProveedorSeleccionado();
                    if (!string.IsNullOrEmpty(DatosAux.IDProveedor))
                    {
                        this.ObtenerDatosProveedor(DatosAux);
                        this.IDProveedor = DatosAux.IDProveedor;
                    }
                    this.IniciarDatosNuevoProducto();
                    if (this.ListaProductos.Count > 0)
                    {
                        this.ListaProductos = new List<Producto>();
                        this.CargarGridProductos();
                    }
                }
                else
                    this.IniciarDatosNuevoProducto();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaCompra ~ cmbProveedor_SelectedValueChanged");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProveedor_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.cmbProveedor.SelectedIndex == -1)
                {
                    this.IniciarDatosProveedor();
                    
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaCompra ~ cmbProveedor_Validating");
            }
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    string ID = this.dgvProductos.Rows[e.RowIndex].Cells["IDProducto"].Value.ToString();
                    if (!string.IsNullOrEmpty(ID))
                    {
                        this.RemoverItemProducto(ID);
                        this.CargarGridProductos();
                        this.DibujarTotal();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaCompra ~ dgvProductos_CellDoubleClick");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevaCompra_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaCompra ~ frmNuevaCompra_Load");
            }
        }

        private void txtCantidad_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                this.txtCantidad.Text = this.ObtenerCantidadProductoActual().ToString();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaCompra ~ txtCantidad_Validating");
            }
        }

        private void txtIva_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                this.txtIva.Text = string.Format("{0:c}", this.ObtenerIvaProductoActual());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaCompra ~ txtPorcIva_Validating");
            }
        }

        private void txtPrecio_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                this.txtPrecio.Text = string.Format("{0:c}", this.ObtenerPrecioProductoActual());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaCompra ~ txtPrecio_Validating");
            }
        }

        #endregion

        private void txtPrecioUSD_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                this.txtPrecioUSD.Text = string.Format("{0:c}", this.ObtenerPrecioProductoUSDActual());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaCompra ~ txtPrecioUSD_Validating");
            }
        }

    }
}
