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
    public partial class frmNuevaTarjetaRegalo : Form
    {
        #region Variables

        private Producto Datos = new Producto();
        private bool NuevoRegistro = false;

        #endregion

        #region Constructor

        public frmNuevaTarjetaRegalo()
        {
            try
            {
                InitializeComponent();
                NuevoRegistro = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaTarjetaRegalo ~ frmNuevaTarjetaRegalo()");
            }
        }

        public frmNuevaTarjetaRegalo(Producto DatosAux)
        {
            try
            {
                InitializeComponent();
                Datos = DatosAux;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaTarjetaRegalo ~ frmNuevaTarjetaRegalo()");
            }
        }

        #endregion

        #region Métodos

        private void CargarDatos()
        {
            try
            {
                this.txtClave.Text = this.Datos.Clave;
                this.txtDescripcion.Text = this.Datos.NombreProducto;
                this.txtMonto.Text = string.Format("{0:c}", this.Datos.PrecioNormal);
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
                this.txtDescripcion.Text = string.Empty;
                this.txtMonto.Text = string.Format("{0:c}", 0);
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
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                } 
                if (this.NuevoRegistro)
                    this.IniciarDatos();
                else
                    this.CargarDatos();
                this.ActiveControl = this.txtClave;
                this.txtClave.Focus();
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
                DatosAux.NuevoRegistro = this.NuevoRegistro;
                DatosAux.IDProducto = this.NuevoRegistro ? string.Empty : this.Datos.IDProducto;
                DatosAux.Clave = this.txtClave.Text.Trim();
                DatosAux.NombreProducto = this.txtDescripcion.Text.Trim();
                DatosAux.PrecioNormal = this.ObtenerMonto();
                DatosAux.Imagen = new byte[0];
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerMonto()
        {
            try
            {
                decimal Monto = 0;
                decimal.TryParse(this.txtMonto.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Monto);
                return Monto;
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
                if (string.IsNullOrEmpty(this.txtClave.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la clave del producto tarjeta.", ControlSender = this.txtClave });
                if (string.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la descripción.", ControlSender = this.txtDescripcion });
                decimal Monto = this.ObtenerMonto();
                if (Monto <= 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "El monto debe ser mayor a $ 0.00.", ControlSender = this.txtDescripcion });
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
                LogError.AddExcFileTxt(ex, "frmNuevaReglaComision ~ btnCancelar_Click");
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
                    Producto Datos = this.ObtenerDatos();
                    Producto_Negocio ProdNeg = new Producto_Negocio();
                    ProdNeg.ACTarjetasRegalo(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (Datos.Resultado == 51000)
                        {
                            Error ResultError = new Error { Numero = 1, ControlSender = this.txtClave, Descripcion = "La clave del producto ya existe." };
                            Errores = new List<Error>();
                            Errores.Add(ResultError);
                            this.MostrarMensajeError(Errores);
                        }
                        else if (Datos.Resultado == 51001)
                        {
                            Error ResultError = new Error { Numero = 1, ControlSender = this.txtMonto, Descripcion = "El monto de la tarjeta ya existe" };
                            Errores = new List<Error>();
                            Errores.Add(ResultError);
                            this.MostrarMensajeError(Errores);
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
                LogError.AddExcFileTxt(ex, "frmNuevaTarjetaRegalo ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevaTarjetaRegalo_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaTarjetaRegalo ~ frmNuevaTarjetaRegalo_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMonto_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                this.txtMonto.Text = string.Format("{0:c}", this.ObtenerMonto());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaReglaComision ~ btnCancelar_Click");
            }
        }

        #endregion

    }
}