using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using CreativaSL.Dll.Validaciones;
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
    public partial class frmValesFechas : Form
    {

        private Vales _DatosVale;

        public Vales DatosVale
        {
            get { return _DatosVale; }
            set { _DatosVale = value; }
        }

        public frmValesFechas(Vales Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosVale = Datos;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmValesFechas ~ frmValesFechas()");
            }
            
        }

        private void IniciarForm()
        {
            try
            {
                this.dtpFechaInicio.Value = DateTime.Today;
                this.dtpFechaFin.Value = DateTime.Today;
                if (!this._DatosVale.RequierePeriodo)
                {
                    this.dtpFechaInicio.Enabled = false;
                    this.dtpFechaFin.Enabled = false;
                }
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
                DatosAux.IDVale = this._DatosVale.IDVale;
                DatosAux.CantLimite = this.ObtenerCantidad(this.txtCantidadLimite);
                DatosAux.FechaInicio = this.dtpFechaInicio.Value;
                DatosAux.FechaFin = this.dtpFechaFin.Value;
                DatosAux.IDUsuario = Comun.IDUsuario;
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
                List<Error> Errores = new List<Error>();
                int Aux = 0;
                //Validar TextBox Cantidad Limite
                if (string.IsNullOrEmpty(this.txtCantidadLimite.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la Cantidad Limite.", ControlSender = this.txtCantidadLimite });
                else
                {
                    if (!Validar.IsValidOnlyNumber(this.txtCantidadLimite.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar el Cantidad Limite válido.", ControlSender = this.txtCantidadLimite });
                }
                if (this._DatosVale.RequierePeriodo)
                {
                    if (this.dtpFechaInicio.Value > this.dtpFechaFin.Value)
                    {
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La fecha de inicio no puede ser mayor a la fecha final.", ControlSender = this.dtpFechaInicio });
                    }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmValesFechas ~ btnCancelar_Click");
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
                    Vales DatosAux = this.ObtenerDatos();
                    Vales_Negocio VN = new Vales_Negocio();
                    VN.ReActivarVale(DatosAux);
                    if (DatosAux.Completado)
                    {
                        MessageBox.Show("El Vale se reactivo correctamentes.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosVale = DatosAux;
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
                LogError.AddExcFileTxt(ex, "frmValesFechas ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmValesFechas_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmValesFechas ~ frmValesFechas_Load");
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

    }
}
