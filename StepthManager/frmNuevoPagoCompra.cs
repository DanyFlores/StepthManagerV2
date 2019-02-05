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
    public partial class frmNuevoPagoCompra : Form
    {

        #region Propiedades / Variables
        private bool NuevoRegistro = false;
        private decimal MontoPendiente = 0;
        private string IDCompra = string.Empty;
        public decimal MontoPago = 0;
        private PagoCompra _DatosPago;
        public PagoCompra DatosPago
        {
            get { return _DatosPago; }
            set { _DatosPago = value; }
        }
        #endregion

        #region Constructor

        public frmNuevoPagoCompra(string ID, decimal Monto)
        {
            try
            {
                InitializeComponent();
                this.NuevoRegistro = true;
                this.MontoPendiente = Monto;
                this.IDCompra = ID;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPagoCompra ~ frmNuevoPagoCompra()");
            }
        }

        public frmNuevoPagoCompra(PagoCompra Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosPago = Datos;
                this.NuevoRegistro = false;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPagoCompra ~ frmNuevoPagoCompra(PagoCompra Datos)");
            }
        }

        #endregion

        #region Métodos

        private void IniciarDatos()
        {
            try
            {
                this.txtMontoPendiente.Text = string.Format("{0:c}", this.MontoPendiente);
                this.txtMontoPago.Text = string.Format("{0:c}", 0);
                this.dtpFechaPago.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDatosAModificar(PagoCompra Datos)
        {
            try
            {

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
                if (!this.NuevoRegistro)
                    this.CargarDatosAModificar(_DatosPago);
                else
                    this.IniciarDatos();
                this.ActiveControl = this.txtMontoPago;
                this.txtMontoPago.Focus();
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

        private PagoCompra ObtenerDatos()
        {
            try
            {
                PagoCompra DatosAux = new PagoCompra();
                DatosAux.NuevoRegistro = this.NuevoRegistro;
                DatosAux.IDPagoCompra = this.NuevoRegistro ? string.Empty : this._DatosPago.IDPagoCompra;
                DatosAux.IDCompra = this.IDCompra;
                DatosAux.FechaPago = this.dtpFechaPago.Value;
                DatosAux.MontoPago = this.ObtenerMontoPago();
                DatosAux.IDCajaXSucursal = Comun.IDCaja;
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerMontoPago()
        {
            try
            {
                decimal MontoPago = 0;
                decimal.TryParse(this.txtMontoPago.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out MontoPago);
                return MontoPago;
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
                decimal MontoPago = this.ObtenerMontoPago();
                if (MontoPago <= 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "El monto del pago debe ser mayor a 0.", ControlSender = this.txtMontoPago });
                if (MontoPago > this.MontoPendiente)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "El monto del pago debe ser menor al monto pendiente.", ControlSender = this.txtMontoPago });
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
                LogError.AddExcFileTxt(ex, "frmNuevoPagoCompra ~ btnCancelar_Click");
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
                    PagoCompra Datos = this.ObtenerDatos();
                    Compra_Negocio CN = new Compra_Negocio();
                    CN.ACPagosCompra(Datos);
                    if (Datos.Completado)
                    {
                        this.MontoPago = Datos.MontoPago;
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosPago = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al guardar los datos.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPagoCompraMobiliario ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoPagoCompra_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPagoCompra ~ frmNuevoPagoCompra_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMontoPago_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                decimal Monto = this.ObtenerMontoPago();
                this.txtMontoPago.Text = string.Format("{0:c}", Monto);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPagoCompra ~ txtMontoPago_Validating");
            }
        }

        #endregion

    }
}
