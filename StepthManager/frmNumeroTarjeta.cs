using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using StephManager.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephManager
{
    public partial class frmNumeroTarjeta : Form
    {
        #region Propiedades / Variables
        string IDCliente = string.Empty;
        string IDTarjeta = string.Empty;
        private TarjetaMonedero _DatosAux;
        public TarjetaMonedero DatosAux
        {
            get { return _DatosAux; }
            set { _DatosAux = value; }
        }
        
        #endregion

        #region Constructor

        public frmNumeroTarjeta(Cliente Datos)
        {
            try
            {
                InitializeComponent();
                this.IDTarjeta = Datos.IDTarjeta;
                this.IDCliente = Datos.IDCliente;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNumeroTarjeta ~ frmNumeroTarjeta()");
            }
        }

        #endregion

        #region Métodos

        private void CargarDatosAModificar(UnidadMedida Datos)
        {
            try
            {
                this.txtDescripcion.Text = Datos.Descripcion;
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
                this.ActiveControl = this.txtDescripcion;
                this.txtDescripcion.Focus();
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

        private TarjetaMonedero ObtenerDatos()
        {
            try
            {
                TarjetaMonedero DatosAux = new TarjetaMonedero();
                DatosAux.IDTarjeta = this.IDTarjeta;
                DatosAux.IDCliente = this.IDCliente;
                DatosAux.Folio = this.txtDescripcion.Text.Trim();
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                return DatosAux;
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
                int aux = 0;
                if (string.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
                    Errores.Add(new Error { Numero = (aux += 1), Descripcion = "Ingrese el folio de la tarjeta.", ControlSender = this.txtDescripcion });
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
                LogError.AddExcFileTxt(ex, "frmNumeroTarjeta ~ btnCancelar_Click");
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
                    TarjetaMonedero Datos = this.ObtenerDatos();
                    Cliente_Negocio CN = new Cliente_Negocio();
                    CN.CambiarFolioTarjetaMonedero(Datos);
                    if (Datos.Completado)
                    {
                        this.DatosAux = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (Datos.Opcion == -1)
                        {
                            this.txtMensajeError.Visible = true;
                            this.txtMensajeError.Text = "El número de tarjeta ya está registrado. Intente con un nuevo número.";
                        }
                        else
                            MessageBox.Show(Comun.MensajeError + "Código del error: " + Datos.Opcion, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNumeroTarjeta ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)Keys.Enter)
                    this.btnGuardar_Click(this.btnGuardar, new EventArgs());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNumeroTarjeta ~ txtDescripcion_KeyPress");
            }
        }
        #endregion

        private void frmNumeroTarjeta_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNumeroTarjeta ~ frmNumeroTarjeta_Load");
            }
        }
    }
}
