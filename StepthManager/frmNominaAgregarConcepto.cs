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
    public partial class frmNominaAgregarConcepto : Form
    {
        #region Propiedades / Variables

        Nomina Datos = new Nomina();

        #endregion

        #region Constructor

        public frmNominaAgregarConcepto(Nomina DatosAux)
        {
            try
            {
                InitializeComponent();
                this.Datos = DatosAux;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNominaAgregarConcepto ~ frmNominaAgregarConcepto()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarDatos()
        {
            try
            {
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
                this.LlenarComboConceptos();
                this.ActiveControl = this.cmbConceptos;
                this.cmbConceptos.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboConceptos()
        {
            try
            {
                Nomina DatosAux = new Nomina { Conexion = Comun.Conexion, IncluirSelect = true };
                Nomina_Negocio NN = new Nomina_Negocio();
                List<Nomina> Lista = NN.ObtenerComboConceptosNomina(DatosAux);
                this.cmbConceptos.DataSource = Lista;
                this.cmbConceptos.ValueMember = "IDConcepto";
                this.cmbConceptos.DisplayMember = "ConceptoNomina";
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

        private Nomina ObtenerConceptoCombo()
        {
            try
            {
                Nomina DatosAux = new Nomina();
                if (this.cmbConceptos.Items.Count > 0)
                {
                    if (this.cmbConceptos.SelectedIndex != -1)
                    {
                        DatosAux = (Nomina)this.cmbConceptos.SelectedItem;
                    }
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Nomina ObtenerDatos()
        {
            try
            {
                Nomina DatosAux = new Nomina();
                DatosAux.IDTipoNomina = this.Datos.IDTipoNomina;
                DatosAux.EsFijo = this.Datos.EsFijo;
                DatosAux.IDEmpleado = this.Datos.IDEmpleado;
                DatosAux.IDConcepto = this.ObtenerConceptoCombo().IDConcepto;
                DatosAux.Monto = this.ObtenerMonto();
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
                int aux = 0;
                if(this.ObtenerConceptoCombo().IDConcepto == 0)
                    Errores.Add(new Error { Numero = (aux += 1), Descripcion = "Seleccione un concepto.", ControlSender = this.cmbConceptos });
                if(this.ObtenerMonto() <= 0)
                    Errores.Add(new Error { Numero = (aux += 1), Descripcion = "El monto debe ser mayor a $ 0.00.", ControlSender = this.txtMonto });
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
                LogError.AddExcFileTxt(ex, "frmNominaAgregarConcepto ~ btnCancelar_Click");
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
                    Nomina DatosAux = this.ObtenerDatos();
                    Nomina_Negocio NN = new Nomina_Negocio();
                    NN.AgregarConceptoNomina(DatosAux);
                    if (DatosAux.Completado)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (DatosAux.Resultado == -1)
                        {
                            Error ErrorAux = new Error { Numero = 1, Descripcion = "El concepto ya está agregado.", ControlSender = this.cmbConceptos };
                        }
                        else
                        {
                            MessageBox.Show(Comun.MensajeError + " Código: " + Datos.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNominaAgregarConcepto ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNominaAgregarConcepto_Load(object sender, EventArgs e)
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

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    this.btnGuardar_Click(this.btnGuardar, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNominaAgregarConcepto ~ txtMonto_KeyPress");
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
                LogError.AddExcFileTxt(ex, "frmNominaAgregarConcepto ~ txtMonto_Validating");
            }
        }

        #endregion

    }
}
