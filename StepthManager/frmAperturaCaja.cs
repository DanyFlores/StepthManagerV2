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
using StephManager.ClasesAux;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace StephManager
{
    public partial class frmAperturaCaja : Form
    {

        #region Constructor

        public frmAperturaCaja()
        {
            InitializeComponent();
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                this.txtMontoApertura.Text = string.Format("{0:c}", 0);
                this.ActiveControl = this.txtMontoApertura;
                this.txtMontoApertura.Focus();
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

        private Caja ObtenerDatos()
        {
            try
            {
                decimal MontoApertura = 0;
                decimal.TryParse(this.txtMontoApertura.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out MontoApertura);
                Caja DatosAux = new Caja();
                DatosAux.IDCaja = Comun.IDCaja;
                DatosAux.IDCajaCat = Comun.IDCajaCat;
                DatosAux.IDUsuario = Comun.IDUsuario;
                DatosAux.IDSucursal = Comun.IDSucursalCaja;
                DatosAux.Apertura = MontoApertura;
                DatosAux.Conexion = Comun.Conexion;
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
                List<Error> ListaErrores = new List<Error>();
                int Aux = 0;
                if (string.IsNullOrEmpty(this.txtMontoApertura.Text.Trim()))
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un monto de apertura.", ControlSender = this.txtMontoApertura });
                return ListaErrores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                    Caja Datos = this.ObtenerDatos();
                    Caja_Negocio CN = new Caja_Negocio();
                    CN.GuardarAperturaCaja(Datos);
                    if (Datos.Completado)
                    {
                        Comun.CajaAbierta = true;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error en el preceso de apertura de caja.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAperturaCaja ~ btnGuardar_Click");
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
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAperturaCaja ~ btn_Cancelar_Click");
            }
        }

        private void frmAperturaCaja_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAperturaCaja ~ frmAperturaCaja_Load");
            }
        }

        private void txtMontoApertura_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    this.btnGuardar.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAperturaCaja ~ txtMontoApertura_KeyPress");
            }
        }

        private void txtMontoApertura_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                decimal Aux = 0;
                decimal.TryParse(this.txtMontoApertura.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Aux);
                this.txtMontoApertura.Text = string.Format("{0:c}", Aux);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAperturaCaja ~ txtMontoApertura_Validating");
            }
        }

        #endregion

    }
}
