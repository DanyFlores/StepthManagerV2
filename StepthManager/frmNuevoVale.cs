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
    public partial class frmNuevoVale : Form
    {
        #region Propiedades / Variables
        private int TipoForm = 0;
        private Vales _DatosVales;
        public Vales DatosVales
        {
            get { return _DatosVales; }
            set { _DatosVales = value; }
        }
        private List<Sucursal> ListaSucursales = new List<Sucursal>();
        private List<Sucursal> SucursalesXUsuario = new List<Sucursal>();
        private Producto ProductoM = new Producto();
        private Producto ProductoN = new Producto();
        private List<Producto> ListaProductos = new List<Producto>();
        #endregion

        #region Constructor

        public frmNuevoVale()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoVale ~ frmNuevoVale()");
            }
        }

        public frmNuevoVale(Vales Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosVales = Datos;
                this.TipoForm = 2;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoVale ~ frmNuevoVale(Vales Datos)");
            }
        }

        #endregion

        #region Métodos

        private void CargarDatosAModificar()
        {
            try
            {
                this.txtNombreVale.Text = this._DatosVales.Nombre;
                this.txtFolioVale.ReadOnly = true;
                this.txtFolioVale.TabStop = false;
                this.txtFolioVale.Text = this._DatosVales.Folio;
                this.txtCantidadLimite.Text = this._DatosVales.CantLimite.ToString();
                this.chkAbiertoPublico.Enabled = false;
                this.chkAbiertoPublico.Checked = this._DatosVales.Abierto;
                this.cmbTipoVale.Enabled = false;
                if (this.ExisteItemEnCombo(this._DatosVales.IDTipoVale))
                    this.cmbTipoVale.SelectedValue = this._DatosVales.IDTipoVale;
                this.LimpiarDatosVales();
                switch (this._DatosVales.IDTipoVale)
                {
                    case 1: this.txtPrcentajeDia.Text = string.Format("{0:F2}", this._DatosVales.Porcentaje);
                        break;
                    case 2: this.txtMontoEfectivo.Text = string.Format("{0:c}", this._DatosVales.Monto);
                        break;
                    case 3: this.ProductoN = this._DatosVales.ProductoRequerido;
                        this.txtNxNProducto.Text = this.ProductoN.NombreProducto;
                        this.txtCantidadRequeridadNxN.Text = this._DatosVales.CantidadRequeridaNxN.ToString();
                        this.txtCantidadGratisNxN.Text = this._DatosVales.CantidadGratisNxN.ToString();
                        break;
                    case 4: this.ProductoM = this._DatosVales.ProductoRequerido;
                        this.txtMxNProductoM.Text = this.ProductoM.NombreProducto;
                        this.txtCantidadRequeridadMxN.Text = this._DatosVales.CantRequeridad.ToString();
                        this.ProductoN = this._DatosVales.ProductoGratis;
                        this.txtMxNProductoN.Text = this.ProductoN.NombreProducto;
                        this.txtCantidadGratisMxN.Text = this._DatosVales.CantGratis.ToString();
                        break;
                }
                this.radioBntRangoFechas.Enabled = false;
                this.radioBtnDiasSemanas.Enabled = false;
                if (this._DatosVales.RequierePeriodo)
                {
                    this.radioBntRangoFechas.Checked = true;
                    this.dtpFechaInicio.Value = this._DatosVales.FechaInicio;
                    this.dtpFechaFin.Value = this._DatosVales.FechaFin;
                }
                else
                {
                    this.radioBtnDiasSemanas.Checked = true;
                    this.chkAplicaLunes.Checked = this._DatosVales.Lunes;
                    this.chkAplicaMartes.Checked = this._DatosVales.Martes;
                    this.chkAplicaMiercoles.Checked = this._DatosVales.Miercoles;
                    this.chkAplicaJueves.Checked = this._DatosVales.Jueves;
                    this.chkAplicaViernes.Checked = this._DatosVales.Viernes;
                    this.chkAplicaSabado.Checked = this._DatosVales.Sabado;
                    this.chkAplicaDomingo.Checked = this._DatosVales.Domingo;
                }
                this.ListaProductos = this._DatosVales.ListaProductos;
                this.CargarGridProductos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExisteItemEnCombo(int ID)
        {
            try
            {
                bool Band = false;
                foreach (TipoVales Item in this.cmbTipoVale.Items)
                {
                    if (Item.IDTipoVale == ID)
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

        private void IniciarForm()
        {
            try
            {
                this.LlenarComboTipoVales();
                this.InicializarCampos();
                if (TipoForm == 2)
                    this.CargarDatosAModificar();
                this.ActiveControl = this.txtNombreVale;
                this.txtNombreVale.Focus();
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

        private void InicializarCampos()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboTipoVales()
        {
            try
            {
                TipoVales DatosTipoVale = new TipoVales { Conexion = Comun.Conexion, IncluirSelect = true };
                Vales_Negocio VN = new Vales_Negocio();
                this.cmbTipoVale.ValueMember = "IDTipoVale";
                this.cmbTipoVale.DisplayMember = "Descripcion";
                this.cmbTipoVale.DataSource = VN.ObtenerComboTipoVales(DatosTipoVale);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private TipoVales ObtenerTipoValesSeleccionado()
        {
            try
            {
                TipoVales DatosAux = new TipoVales();
                if (this.cmbTipoVale.SelectedIndex != -1)
                {
                    DatosAux = (TipoVales)this.cmbTipoVale.SelectedItem;                    
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int ObtenerCantidad(TextBox txtCantidad)
        {
            try
            {
                int Cantidad = 0;
                int.TryParse(txtCantidad.Text, out Cantidad);
                return Cantidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Vales ObtenerDatos()
        {
            try
            {
                Vales DatosAux = new Vales();
                TipoVales AuxTV = this.ObtenerTipoValesSeleccionado();
                int CantidadLimite = 0, CantidadRequeridaNxN = 0, CantidadGratisNxN = 0, CantidadRequeridaMxN = 0, CantidadGratisMxN = 0;
                decimal Monto = 0, Porcentaje = 0;
                DatosAux.IDVale =  TipoForm == 2 ? this._DatosVales.IDVale : string.Empty;
                DatosAux.IDTipoVale = Convert.ToInt32(this.cmbTipoVale.SelectedValue.ToString());
                DatosAux.NombreTipoVale = AuxTV.Descripcion;
                DatosAux.Nombre = this.txtNombreVale.Text.Trim();
                DatosAux.Folio = this.txtFolioVale.Text.Trim();
                int.TryParse(this.txtCantidadLimite.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out CantidadLimite);
                decimal.TryParse(this.txtMontoEfectivo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Monto);
                decimal.TryParse(this.txtPrcentajeDia.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Porcentaje);
                DatosAux.CantLimite = CantidadLimite;
                DatosAux.Monto = Monto;
                DatosAux.Porcentaje = Porcentaje;
                DatosAux.Abierto = this.chkAbiertoPublico.Checked;
                DatosAux.RangoFechas = this.radioBntRangoFechas.Checked;
                
                int.TryParse(this.txtCantidadRequeridadNxN.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out CantidadRequeridaNxN);
                int.TryParse(this.txtCantidadGratisNxN.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out CantidadGratisNxN);
                DatosAux.IDProductoNxN = this.ProductoN.IDProducto;
                DatosAux.CantidadRequeridaNxN = CantidadRequeridaNxN;
                DatosAux.CantidadGratisNxN = CantidadGratisNxN;
                
                int.TryParse(this.txtCantidadRequeridadMxN.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out CantidadRequeridaMxN);
                int.TryParse(this.txtCantidadGratisMxN.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out CantidadGratisMxN);
                DatosAux.IDProductoRequerido = this.ProductoM.IDProducto;
                DatosAux.IDProductoGratis = this.ProductoN.IDProducto;
                DatosAux.CantRequeridad = CantidadRequeridaMxN;
                DatosAux.CantGratis = CantidadGratisMxN;
                DatosAux.FechaInicio = this.dtpFechaInicio.Value;
                DatosAux.FechaFin = this.dtpFechaFin.Value;
                DatosAux.Lunes = this.chkAplicaLunes.Checked;
                DatosAux.Martes = this.chkAplicaMartes.Checked;
                DatosAux.Miercoles = this.chkAplicaMiercoles.Checked;
                DatosAux.Jueves = this.chkAplicaJueves.Checked;
                DatosAux.Viernes = this.chkAplicaViernes.Checked;
                DatosAux.Sabado = this.chkAplicaSabado.Checked;
                DatosAux.Domingo = this.chkAplicaDomingo.Checked;
                DatosAux.Opcion = this.TipoForm;
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                DatosAux.TablaDatos = this.ObtenerTablaProductos();
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerMontoDescuento()
        {
            try
            {
                decimal Monto = 0;
                decimal.TryParse(this.txtMontoEfectivo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Monto);
                return Monto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerPorcentaje()
        {
            try
            {
                decimal Porcentaje = 0;
                decimal.TryParse(this.txtPrcentajeDia.Text, out Porcentaje);
                return Porcentaje;
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
                //Validar TextBox Nombre del Vale
                if (string.IsNullOrEmpty(this.txtNombreVale.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el Nombre del Vale.", ControlSender = this.txtNombreVale });
                if (this.cmbTipoVale.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción en Tipo de Vales.", ControlSender = this.cmbTipoVale });
                else
                {
                    TipoVales TVale = (TipoVales)this.cmbTipoVale.SelectedItem;
                    if (TVale.IDTipoVale != 0)
                    {
                        //Validar Datos del PanelPorcentajePorDia
                        if (TVale.Porcentaje)
                        {
                            if (string.IsNullOrEmpty(this.txtPrcentajeDia.Text.Trim()))
                                Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el Porcentaje de descuento.", ControlSender = this.txtPrcentajeDia });
                            else
                            {
                                decimal Porcentaje = this.ObtenerPorcentaje();
                                if (Porcentaje <= 0)
                                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "El porcentaje de descuento debe ser mayor a 0%.", ControlSender = this.txtPrcentajeDia });
                                else if (Porcentaje > 100)
                                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "El porcentaje de descuento no puede ser mayor a 100%.", ControlSender = this.txtPrcentajeDia });
                            }
                            if (this.dgvProductosXVale.Rows.Count == 0)
                                Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe de ingresar al menos un producto al vale.", ControlSender = this.dgvProductosXVale });
                        }
                        //Validar Datos del PanelMontoEfectivo
                        if (TVale.Monto)
                        {
                            if (string.IsNullOrEmpty(this.txtMontoEfectivo.Text.Trim()))
                                Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el Monto en Efectivo.", ControlSender = this.txtMontoEfectivo });
                            else
                            {
                                decimal Monto = this.ObtenerMontoDescuento();
                                if (Monto <= 0)
                                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "El monto de descuento debe ser mayor a $ 0.00.", ControlSender = this.txtMontoEfectivo });
                            }
                            if (this.dgvProductosXVale.Rows.Count == 0)
                                Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe de ingresar al menos un producto al vale.", ControlSender = this.dgvProductosXVale });
                        }
                        //Validar Datos del PanelNxN
                        if (TVale.NxN)
                        {
                            if (string.IsNullOrEmpty(ProductoN.IDProducto))
                                Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione el producto requerido para la promoción.", ControlSender = this.btnElegirProdServNXN });
                            if (string.IsNullOrEmpty(this.txtCantidadRequeridadNxN.Text.Trim()))
                                Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la Cantidad Requerida en N x N.", ControlSender = this.PanelNxN });
                            if (string.IsNullOrEmpty(this.txtCantidadGratisNxN.Text.Trim()))
                                Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la Cantidad Gratis en N x N.", ControlSender = this.PanelNxN });
                            if (!string.IsNullOrEmpty(this.txtCantidadRequeridadNxN.Text.Trim()) && !string.IsNullOrEmpty(this.txtCantidadGratisNxN.Text.Trim()))
                            {
                                int CantidadReq = 0, CantidadGratis = 0;
                                CantidadReq = this.ObtenerCantidad(this.txtCantidadRequeridadNxN);
                                CantidadGratis = this.ObtenerCantidad(this.txtCantidadGratisNxN);
                                if (CantidadReq <= 0)
                                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Cantidad Requerida debe ser mayor a 0", ControlSender = this.txtCantidadRequeridadNxN });
                                if (CantidadGratis <= 0)
                                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Cantidad Gratis debe ser mayor a 0.", ControlSender = this.txtCantidadGratisNxN });
                                if (CantidadReq > 0 && CantidadGratis > 0)
                                {
                                    if (CantidadGratis >= CantidadReq)
                                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Cantidad Gratis debe ser menor a la cantidad requerida.", ControlSender = this.txtCantidadGratisNxN });
                                }
                            }
                        }
                        //Validar Datos del PanelMxN
                        if (TVale.NxM)
                        {
                            if (string.IsNullOrEmpty(ProductoM.IDProducto))
                                Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione el producto requerido para la promoción.", ControlSender = this.btnElegirProdServM });
                            if (string.IsNullOrEmpty(ProductoN.IDProducto))
                                Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione el producto gratis para la promoción.", ControlSender = this.btnElegirProdServN });
                            if (string.IsNullOrEmpty(this.txtCantidadRequeridadMxN.Text.Trim()))
                                Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la Cantidad Requerida en M x N.", ControlSender = this.PanelMxN });
                            if (string.IsNullOrEmpty(this.txtCantidadGratisMxN.Text.Trim()))
                                Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la Cantidad Gratis en M x N.", ControlSender = this.PanelMxN });
                            if (!string.IsNullOrEmpty(this.txtCantidadRequeridadMxN.Text.Trim()) && !string.IsNullOrEmpty(this.txtCantidadGratisMxN.Text.Trim()))
                            {
                                int CantidadReq2 = 0, CantidadGratis2 = 0;
                                CantidadReq2 = this.ObtenerCantidad(this.txtCantidadRequeridadMxN);
                                CantidadGratis2 = this.ObtenerCantidad(this.txtCantidadGratisMxN);
                                if (CantidadReq2 <= 0)
                                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Cantidad Requerida debe ser mayor a 0", ControlSender = this.txtCantidadRequeridadMxN });
                                if (CantidadGratis2 <= 0)
                                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Cantidad Gratis debe ser mayor a 0.", ControlSender = this.txtCantidadGratisMxN });
                                if (CantidadReq2 > 0 && CantidadGratis2 > 0)
                                {
                                    if (CantidadGratis2 >= CantidadReq2)
                                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Cantidad Gratis debe ser menor a la cantidad requerida.", ControlSender = this.txtCantidadGratisMxN });
                                }
                            }
                        }
                    }
                    else
                    {
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción en Tipo Vale.", ControlSender = this.cmbTipoVale });
                    }
                }                
                //Validar TextBox Cantidad Limite
                if (string.IsNullOrEmpty(this.txtCantidadLimite.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la Cantidad Limite.", ControlSender = this.txtCantidadLimite });
                else
                {
                    if (!Validar.IsValidOnlyNumber(this.txtCantidadLimite.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar el Cantidad Limite válido.", ControlSender = this.txtCantidadLimite });
                } 
                
                //Validar RadioButton Para Seleccionar
                if(!this.radioBntRangoFechas.Checked && !this.radioBtnDiasSemanas.Checked)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar Rango de Fecha ó Dias de la Semana", ControlSender = this.PanelDiasSemanas });
                //Validar RadioButton Fecha Inicio y Fecha Fin
                if (this.radioBntRangoFechas.Checked)
                {
                    if (this.dtpFechaInicio.Value > this.dtpFechaFin.Value)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La Fecha Final debe ser mayor a la Fecha Inicial", ControlSender = this.PanelRangoFechas });
                    if (this.dtpFechaInicio.Value < DateTime.Today)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La Fechas deben ser mayores a la Fecha Actual.", ControlSender = this.PanelRangoFechas });
                }
                //Validar RadioButton Para Seleccionar Dias de las Semana
                if (this.radioBtnDiasSemanas.Checked)
                {
                    if (!this.chkAplicaLunes.Checked
                           && !this.chkAplicaMartes.Checked
                           && !this.chkAplicaMiercoles.Checked
                           && !this.chkAplicaJueves.Checked
                           && !this.chkAplicaViernes.Checked
                           && !this.chkAplicaSabado.Checked
                           && !this.chkAplicaDomingo.Checked)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar al menos un Día de la Semana", ControlSender = this.PanelDiasSemanas });
                }
                    return Errores;
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

        private DataTable ObtenerTablaProductos()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla.Columns.Add("IDProducto", typeof(string));
                foreach (Producto Item in ListaProductos)
                {
                    Tabla.Rows.Add(Item.IDProducto);
                }
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void frmNuevoVale_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoVale ~ frmNuevoVale_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTipoVale_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbTipoVale.SelectedIndex != -1)
                {
                    this.LimpiarDatosVales();
                    TipoVales TVale = (TipoVales)this.cmbTipoVale.SelectedItem;
                    ListaProductos = new List<Producto>();
                    if (TVale.Porcentaje)
                    {
                        this.PanelPorcentajePorDia.Enabled = true;
                        this.txtPrcentajeDia.Text = string.Format("{0:F2}", 0);
                        this.PanelMontoEfectivo.Enabled = false;
                        this.PanelNxN.Enabled = false;
                        this.PanelMxN.Enabled = false;
                        this.PanelNXNLayout.Visible = false;
                        this.PanelMXNLayout.Visible = false;
                        this.txtPrcentajeDia.Focus();
                    }
                    else if (TVale.Monto)
                    {
                        this.PanelPorcentajePorDia.Enabled = false;
                        this.PanelMontoEfectivo.Enabled = true;
                        this.txtMontoEfectivo.Text = string.Format("{0:c}", 0);
                        this.PanelNxN.Enabled = false;
                        this.PanelMxN.Enabled = false;
                        this.PanelNXNLayout.Visible = false;
                        this.PanelMXNLayout.Visible = false;
                        this.txtMontoEfectivo.Focus();
                    }
                    else if (TVale.NxN)
                    {
                        this.PanelPorcentajePorDia.Enabled = false;
                        this.PanelMontoEfectivo.Enabled = false;
                        this.PanelNxN.Enabled = true;
                        this.txtCantidadRequeridadNxN.Text = "0";
                        this.txtCantidadGratisNxN.Text = "0";
                        this.PanelMxN.Enabled = false;
                        this.PanelNXNLayout.Visible = true;
                        this.PanelMXNLayout.Visible = true;
                        this.btnElegirProdServNXN.Focus();
                    }
                    else if (TVale.NxM)
                    {
                        this.PanelPorcentajePorDia.Enabled = false;
                        this.PanelMontoEfectivo.Enabled = false;
                        this.PanelNxN.Enabled = false;
                        this.PanelMxN.Enabled = true;
                        this.txtCantidadRequeridadMxN.Text = "0";
                        this.txtCantidadGratisMxN.Text = "0";
                        this.PanelNXNLayout.Visible = true;
                        this.PanelMXNLayout.Visible = true;
                        this.btnElegirProdServM.Focus();
                    }
                    else
                    {
                        this.PanelPorcentajePorDia.Enabled = false;
                        this.PanelMontoEfectivo.Enabled = false;
                        this.PanelNxN.Enabled = false;
                        this.PanelMxN.Enabled = false;
                        this.PanelNXNLayout.Visible = true;
                        this.PanelMXNLayout.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoVale ~ cmbTipoVale_SelectedValueChanged");
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
                LogError.AddExcFileTxt(ex, "frmNuevoVale ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RB_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.radioBntRangoFechas.Checked)
                {
                    this.PanelRangoFechas.Enabled = true;
                    this.PanelDiasSemanas.Enabled = false;
                }
                else if (this.radioBtnDiasSemanas.Checked)
                {
                    this.PanelRangoFechas.Enabled = false;
                    this.PanelDiasSemanas.Enabled = true;
                }
                else
                {
                    this.PanelRangoFechas.Enabled = false;
                    this.PanelDiasSemanas.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoVale ~ btnCancelar_Click");
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
                    Vales Datos = this.ObtenerDatos();
                    Vales_Negocio ValesNeg = new Vales_Negocio();
                    ValesNeg.ABCVales(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosVales = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (Datos.Resultado == 51000)
                        {
                            List<Error> LstError = new List<Error>();
                            LstError.Add(new Error { Numero = 1, Descripcion = "El folio ingresado ya existe.", ControlSender = this });
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
                LogError.AddExcFileTxt(ex, "frmNuevoVale ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void frmNuevoVale_Resize(object sender, EventArgs e)
        {
            try
            {
                int Porcentaje = 33;
                int WidthPanel = (this.Size.Width * Porcentaje) / 100;
                //Fila 01
                int Porcentaje2 = 50;
                int WidthPanel2 = (this.Size.Width * Porcentaje2) / 100;
                this.panelFila05.Size = new Size(WidthPanel2, this.panelFila05.Height);
                this.PanelNXNLayout.Size = new Size(WidthPanel2, this.PanelNXNLayout.Height);
                this.panel15.Size = new Size(WidthPanel2, this.panel15.Height);

                this.PanelFila02.Size = new Size(WidthPanel, this.PanelFila02.Height);
                this.panel17.Size = new Size(WidthPanel, this.panel17.Height);

                this.panel7.Size = new Size(WidthPanel, this.panel7.Height);
                this.panel4.Size = new Size(WidthPanel, this.panel4.Height);
                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProducto ~ frmNuevoProductoServicio_Resize");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElegirProdServNXN_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeleccionarProducto ElegirProducto = new frmSeleccionarProducto(10);
                ElegirProducto.Location = this.txtNxNProducto.PointToScreen(new Point());
                ElegirProducto.Location = new Point(ElegirProducto.Location.X - 1, ElegirProducto.Location.Y - 2);
                ElegirProducto.ShowDialog();
                ElegirProducto.Dispose();
                if (ElegirProducto.DialogResult == DialogResult.OK)
                {
                    this.ProductoN = ElegirProducto.Datos;
                    this.txtNxNProducto.Text = this.ProductoN.NombreProducto;
                    this.txtCantidadRequeridadNxN.Focus();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoVale ~ btnElegirProdServNXN_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMontoEfectivo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                decimal Monto = 0;
                decimal.TryParse(this.txtMontoEfectivo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Monto);
                this.txtMontoEfectivo.Text = string.Format("{0:c}", Monto);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoVale ~ txtMontoEfectivo_Validating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrcentajeDia_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                decimal Monto = 0;
                decimal.TryParse(this.txtMontoEfectivo.Text, out Monto);
                this.txtMontoEfectivo.Text = string.Format("{0:F2}", Monto);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoVale ~ txtPrcentajeDia_Validating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCantidadInt_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                TextBox Txt = (TextBox)sender;
                int Cantidad = 0;
                int.TryParse(Txt.Text, out Cantidad);
                Txt.Text = Cantidad.ToString();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoVale ~ txtCantidadInt_Validating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTipoVale_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.cmbTipoVale.SelectedIndex == -1)
                {
                    this.PanelPorcentajePorDia.Enabled = false;
                    this.PanelMontoEfectivo.Enabled = false;
                    this.PanelNxN.Enabled = false;
                    this.PanelMxN.Enabled = false;
                    this.LimpiarDatosVales();
                    this.PanelNXNLayout.Visible = true;
                    this.PanelMXNLayout.Visible = true;
                    ListaProductos = new List<Producto>();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoVale ~ cmbTipoVale_Validating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarDatosVales()
        {
            try
            {
                this.ProductoN = new Producto();
                this.ProductoM = new Producto();
                this.txtNxNProducto.Text = string.Empty;
                this.txtCantidadRequeridadNxN.Text = string.Empty;
                this.txtCantidadGratisNxN.Text = string.Empty;
                this.txtMxNProductoM.Text = string.Empty;
                this.txtMxNProductoN.Text = string.Empty;
                this.txtCantidadRequeridadMxN.Text = string.Empty;
                this.txtCantidadGratisMxN.Text = string.Empty;
                this.txtMontoEfectivo.Text = string.Empty;
                this.txtPrcentajeDia.Text = string.Empty;
                this.dgvProductosXVale.AutoGenerateColumns = false;
                this.dgvProductosXVale.DataSource = new List<Producto>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridProductos()
        {
            try
            {
                this.dgvProductosXVale.DataSource = null;
                this.dgvProductosXVale.AutoGenerateColumns = false;
                this.dgvProductosXVale.DataSource = this.ListaProductos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExisteProductoEnLista(string IDProducto)
        {
            try
            {
                bool Band = false;
                foreach (Producto Item in ListaProductos)
                {
                    if (Item.IDProducto == IDProducto)
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

        private void btnElegirProdServM_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeleccionarProducto ElegirProducto = new frmSeleccionarProducto(16);
                ElegirProducto.Location = this.txtMxNProductoM.PointToScreen(new Point());
                ElegirProducto.Location = new Point(ElegirProducto.Location.X - 1, ElegirProducto.Location.Y - 2);
                ElegirProducto.ShowDialog();
                ElegirProducto.Dispose();
                if (ElegirProducto.DialogResult == DialogResult.OK)
                {
                    this.ProductoM = ElegirProducto.Datos;
                    this.txtMxNProductoM.Text = this.ProductoM.NombreProducto;
                    this.txtCantidadRequeridadMxN.Focus();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoVale ~ btnElegirProdServM_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElegirProdServN_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeleccionarProducto ElegirProducto = new frmSeleccionarProducto(16);
                ElegirProducto.Location = this.txtMxNProductoN.PointToScreen(new Point());
                ElegirProducto.Location = new Point(ElegirProducto.Location.X - 1, ElegirProducto.Location.Y - 2);
                ElegirProducto.ShowDialog();
                ElegirProducto.Dispose();
                if (ElegirProducto.DialogResult == DialogResult.OK)
                {
                    this.ProductoN = ElegirProducto.Datos;
                    this.txtMxNProductoN.Text = this.ProductoN.NombreProducto;
                    this.txtCantidadGratisMxN.Focus();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoVale ~ btnElegirProdServN_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElegirProducto_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeleccionarProducto ElegirProducto = new frmSeleccionarProducto(16);
                ElegirProducto.Location = this.txtProducto.PointToScreen(new Point());
                ElegirProducto.Location = new Point(ElegirProducto.Location.X - 1, ElegirProducto.Location.Y - 2);
                ElegirProducto.ShowDialog();
                ElegirProducto.Dispose();
                if (ElegirProducto.DialogResult == DialogResult.OK)
                {
                    if (!this.ExisteProductoEnLista(ElegirProducto.Datos.IDProducto))
                    {
                        this.ListaProductos.Add(ElegirProducto.Datos);
                        this.CargarGridProductos();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoVale ~ btnElegirProdServNXN_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductosXVale_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    string ID = this.dgvProductosXVale.Rows[e.RowIndex].Cells["IDProducto"].Value.ToString();
                    if (!string.IsNullOrEmpty(ID))
                    {
                        this.RemoverItemProducto(ID);
                        this.CargarGridProductos();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoVale ~ dgvProductosXVale_CellDoubleClick");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
