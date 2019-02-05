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
    public partial class frmNuevoReporteER : Form
    {
        public int _IDReporte = 0;
        public frmNuevoReporteER()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {

                LogError.AddExcFileTxt(ex, "frmNuevoReporteER ~ frmNuevoReporteER()");
            }
        }
        #region Eventos
        private void frmNuevoReporteER_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoReporteER ~ frmNuevoReporteER_Load");
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
                    EstadoResultados Datos = this.ObtenerDatos();
                    Reporte_Negocio Neg = new Reporte_Negocio();
                    int IDReporte = Neg.GenerarReporteEstadoResultados(Comun.Conexion, Datos, Comun.IDUsuario);
                    if (IDReporte > 0)
                    {
                        //Generar el reporte
                        _IDReporte = IDReporte;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al generar el reporte.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoReporteER ~ btnGuardar_Click");
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
                LogError.AddExcFileTxt(ex, "frmNuevoReporteER ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Metodos

        private void IniciarForm()
        {
            try
            {
                LlenarComboSucursal();
                LlenarComboMeses();
                txtAnio.Text = DateTime.Today.Year.ToString();
                txtImpuestoMensual.Text = string.Format("{0:c}", 0);
                txtImpuestoAnual.Text = string.Format("{0:c}", 0);
                this.ActiveControl = cmbSucursales;
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

        private void LlenarComboSucursal()
        {
            try
            {
                Sucursal_Negocio NegSuc = new Sucursal_Negocio();
                this.cmbSucursales.DataSource = NegSuc.LlenarComboCatSucursalesPuntoDeVenta(new Sucursal { Conexion = Comun.Conexion, IncluirSelect = true, Opcion = 1 });
                this.cmbSucursales.DisplayMember = "NombreSucursal";
                this.cmbSucursales.ValueMember = "IDSucursal";
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboMeses()
        {
            try
            {
                Reporte_Negocio NegRep = new Reporte_Negocio();
                cmbMeses.DataSource = NegRep.ObtenerComboMeses(Comun.Conexion);
                cmbMeses.DisplayMember = "MesDesc";
                cmbMeses.ValueMember = "IDMes";
            }
            catch(Exception ex)
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

        private EstadoResultados ObtenerDatos()
        {
            try
            {
                EstadoResultados DatosAux = new EstadoResultados();
                DatosAux.Sucursal = ObtenerSucursalCombo().IDSucursal;
                DatosAux.IDMes = ObtenerMesCombo().IDMes;
                DatosAux.Anio = ObtenerAño();
                DatosAux.ImpuestoMensual = ObtenerValorDecimal(txtImpuestoMensual);
                DatosAux.ImpuestoAnual = ObtenerValorDecimal(txtImpuestoAnual);
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int ObtenerAño()
        {
            try
            {
                int Year = DateTime.Today.Year;
                int.TryParse(txtAnio.Text.Trim(), out Year);
                return Year;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerValorDecimal(TextBox Txt)
        {
            try
            {
                decimal Valor = 0;
                decimal.TryParse(Txt.Text.Trim(), NumberStyles.Currency, CultureInfo.CurrentCulture, out Valor);
                return Valor;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private bool IsValidDecimalValue(TextBox Txt)
        {
            try
            {
                decimal _Value = 0;
                if (decimal.TryParse(Txt.Text.Trim(), NumberStyles.Currency, CultureInfo.CurrentCulture, out _Value))
                    return true;
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private bool IsValidYear()
        {
            try
            {
                int Year;
                if(int.TryParse(txtAnio.Text.Trim(), out Year))
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private Sucursal ObtenerSucursalCombo()
        {
            try
            {
                Sucursal _Datos = new Sucursal();
                if(cmbSucursales.SelectedIndex != -1)
                {
                    _Datos = (Sucursal)cmbSucursales.SelectedItem;
                }
                return _Datos;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private Mes ObtenerMesCombo()
        {
            try
            {
                Mes _Datos = new Mes();
                if(cmbMeses.SelectedIndex != -1)
                {
                    _Datos = (Mes)cmbMeses.SelectedItem;
                }
                return _Datos;
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
                if (string.IsNullOrEmpty(ObtenerSucursalCombo().IDSucursal))
                {
                    Errores.Add(new Error { Numero = 1, Descripcion = "Seleccione una sucursal.", ControlSender = cmbSucursales });
                }
                int _IDMes = ObtenerMesCombo().IDMes;
                if (_IDMes < 0 || _IDMes > 12)
                {
                    Errores.Add(new Error { Numero = 1, Descripcion = "Seleccione un mes de la lista.", ControlSender = cmbMeses });
                }
                if(!IsValidYear())
                {
                    Errores.Add(new Error { Numero = 1, Descripcion = "Ingrese un dato válido para año (YYYY).", ControlSender = txtAnio });
                }
                if (!IsValidDecimalValue(txtImpuestoMensual))
                {
                    Errores.Add(new Error { Numero = 1, Descripcion = "Ingrese un dato válido para Impuesto mensual.", ControlSender = txtImpuestoMensual });
                }
                if (!IsValidDecimalValue(txtImpuestoAnual))
                {
                    Errores.Add(new Error { Numero = 1, Descripcion = "Ingrese un dato válido para Impuesto anual.", ControlSender = txtImpuestoAnual });
                }
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
