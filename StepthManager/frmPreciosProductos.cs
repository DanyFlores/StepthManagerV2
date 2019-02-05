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
    public partial class frmPreciosProductos : Form
    {
        #region Propiedades / Variables
        string IDProducto = string.Empty;
        bool EsServicio = false;
        #endregion

        #region Constructor(es)

        public frmPreciosProductos(string _IDProducto, bool _EsServicio)
        {
            try
            {
                InitializeComponent();
                IDProducto = _IDProducto;
                EsServicio = _EsServicio;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPreciosProductos ~ frmPreciosProductos()");
            }
        }
        
        #endregion

        #region Métodos
        
        private void CargarCombos()
        {
            try
            {
                LlenarComboSucursales();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboSucursales()
        {
            try
            {
                Sucursal_Negocio SucNeg = new Sucursal_Negocio();
                Sucursal Datos = new Sucursal { Conexion = Comun.Conexion, Opcion = 1 };
                List<Sucursal> Lista = SucNeg.LlenarComboCatSucursalesPuntoDeVenta(Datos);
                this.cmbSucursales.DataSource = Lista;
                this.cmbSucursales.DisplayMember = "NombreSucursal";
                this.cmbSucursales.ValueMember = "IDSucursal";
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDatos(Producto Datos)
        {
            try
            {
                if (!string.IsNullOrEmpty(Datos.IDProducto.Trim()))
                {
                    this.txtPrecioPublico.Text = string.Format("{0:c}", Datos.PrecioNormal);
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
                }
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
                this.txtPrecioPublico.Text = string.Format("{0:c}", 0);
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

                if(EsServicio)
                {
                    panel06_01.Visible = false;
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
                this.CargarCombos();
                this.IniciarDatos();
                this.ActiveControl = this.cmbSucursales;
                this.cmbSucursales.Focus();
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
                int CantidadMayoreo = 0;
                decimal PrecioNormal = 0, PrecioMayoreo = 0, PrecioTemporada = 0, PrecioEspecial = 0;
                int.TryParse(this.txtCantidadMayoreo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out CantidadMayoreo);
                decimal.TryParse(this.txtPrecioPublico.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioNormal);
                decimal.TryParse(this.txtPrecioMayoreo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioMayoreo);
                decimal.TryParse(this.txtPrecioTemporada.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioTemporada);
                decimal.TryParse(this.txtPrecioEspecial.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioEspecial);                
                DatosAux.PrecioNormal = PrecioNormal;
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

                DatosAux.IDProducto = IDProducto;
                DatosAux.IDSucursal = this.ObtenerSucursalCombo().IDSucursal;
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private Producto ObtenerPreciosXIDSucursal(string _IDSucursal)
        {
            try
            {
                Producto_Negocio ProdNeg = new Producto_Negocio();
                return ProdNeg.ObtenerPreciosXIDSucursal(new Producto { IDProducto = IDProducto, IDSucursal = _IDSucursal, Conexion = Comun.Conexion });                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private Sucursal ObtenerSucursalCombo()
        {
            try
            {
                Sucursal Datos = new Sucursal();
                if(cmbSucursales.SelectedIndex != -1)
                {
                    Datos = (Sucursal)cmbSucursales.SelectedItem;
                }
                return Datos;
            }
            catch(Exception ex)
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
                // Falta validar la selección de la sucursal
                if (string.IsNullOrEmpty( ObtenerSucursalCombo().IDSucursal))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una sucursal.", ControlSender = this.cmbSucursales });
                if (string.IsNullOrEmpty(this.txtPrecioPublico.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el Precio al Público.", ControlSender = this.txtPrecioPublico });
                else
                {
                    decimal PrecioNormal = 0;
                    if (!decimal.TryParse(txtPrecioPublico.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioNormal))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un dato válido en Precio al Público.", ControlSender = this.txtPrecioPublico });
                }
                if (this.chkPrecioMayoreo.Checked)
                {
                    int CantMay = 0;
                    decimal PrecioMayoreo = 0;
                    if (!decimal.TryParse(this.txtPrecioMayoreo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioMayoreo))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un dato válido para Precio Mayoreo.", ControlSender = this.txtPrecioMayoreo });
                    else if (PrecioMayoreo <= 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Precio Mayoreo debe ser mayor a $ 0.00.", ControlSender = this.txtPrecioMayoreo });
                    if (!int.TryParse(this.txtCantidadMayoreo.Text, out CantMay))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un dato válido en Cantidad Mayoreo.", ControlSender = this.txtCantidadMayoreo });
                    else if (CantMay <= 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Cantidad Mayoreo debe ser mayor a 0.", ControlSender = this.txtCantidadMayoreo });
                }
                if (this.chkPrecioTemporada.Checked)
                {
                    decimal PrecioTemporada = 0;
                    if (!decimal.TryParse(this.txtPrecioTemporada.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioTemporada))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un dato válido para Precio Temporada.", ControlSender = this.txtPrecioTemporada });
                    else if (PrecioTemporada <= 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Precio Temporada debe ser mayor a $ 0.00.", ControlSender = this.txtPrecioTemporada });
                    if (this.dtpFechaInicioTemp.Value > this.dtpFechaFinTemp.Value)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La fecha Final debe ser mayor a la fecha Inicial", ControlSender = this.panelTemporada });
                    if (this.dtpFechaInicioTemp.Value < DateTime.Today)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La fechas de la temporada deben ser mayores a la fecha actual.", ControlSender = this.panelTemporada });
                }
                if (this.chkPrecioEspecial.Checked)
                {
                    decimal PrecioEspecial = 0;
                    if (!decimal.TryParse(this.txtPrecioEspecial.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out PrecioEspecial))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un dato válido para Precio Especial.", ControlSender = this.txtPrecioEspecial });
                    else if (PrecioEspecial <= 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Precio Especial debe ser mayor a $ 0.00.", ControlSender = this.txtPrecioEspecial });
                    if (!this.chkAplicaLunes.Checked
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
                    bool Completado = ProdNeg.GuardarPrecioXIDSucursal(Datos);
                    if (Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
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

        private void frmPreciosProductos_Resize(object sender, EventArgs e)
        {
            try
            {
                int Porcentaje = 25;
                int WidthPanel = (this.Size.Width * Porcentaje) / 100;
                //Fila 01
                Porcentaje = 33;
                int WidthPanel2 = (this.Size.Width * Porcentaje) / 100;
                //Fila 04
                this.panel04_01.Size = new Size((WidthPanel * 2) + 20, this.panel3.Height);
                //Fila06
                this.panel06_01.Size = new Size(WidthPanel2, this.panel06.Height);
                this.panel06_02.Size = new Size(WidthPanel2, this.panel06.Height);                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPreciosProductos ~ frmPreciosProductos_Resize");
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
                LogError.AddExcFileTxt(ex, "frmPreciosProductos ~ txtPrecio_Validating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSucursales_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                Sucursal SucDatos = this.ObtenerSucursalCombo();
                if (!string.IsNullOrEmpty(SucDatos.IDSucursal))
                {
                    Producto Datos = this.ObtenerPreciosXIDSucursal(SucDatos.IDSucursal);
                    if (!string.IsNullOrEmpty(Datos.IDProducto))
                        this.CargarDatos(Datos);
                    else
                        IniciarDatos();
                }
                else
                    IniciarDatos();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPreciosProductos ~ cmbSucursales_SelectedValueChanged");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
