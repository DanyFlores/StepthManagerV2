using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using CreativaSL.Dll.Validaciones;
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
    public partial class frmNuevoGasto : Form
    {
        #region Propiedades / Variables

     //   private bool NuevoRegistro = true;
        private int TipoForm = 0;
        private Gastos _DatosGasto;
        public Gastos DatosGasto
        {
            get { return _DatosGasto; }
            set { _DatosGasto = value; }
        }

        #endregion

        #region Constructor(es)

        public frmNuevoGasto()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
                //this._DatosGasto = new Gastos();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoGasto ~ frmNuevoGasto()");
            }
        }

        public frmNuevoGasto(Gastos Datos)
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 2;
                this._DatosGasto = Datos;
                this.cmbSucursales.Enabled = false;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoGasto ~ frmNuevoGasto(Gastos Datos)");
            }
        }

        #endregion

        #region Métodos

        private void CargarComboRubro()
        {
            try
            {
                Rubro Datos = new Rubro { Conexion = Comun.Conexion, IncluirSelect = true };
                Gastos_Negocio GN = new Gastos_Negocio();
                this.cmbRubro.DataSource = GN.ObtenerComboRubros(Datos);
                this.cmbRubro.DisplayMember = "Descripcion";
                this.cmbRubro.ValueMember = "IDRubro";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarComboSubRubro(int Rubro)
        {
            try
            {
                Subrubro Datos = new Subrubro { Conexion = Comun.Conexion,  IDRubro = Rubro, IncluirSelect = true };
                Gastos_Negocio GN = new Gastos_Negocio();
                this.cmbSubrubro.DataSource = GN.ObtenerComboSubrubros(Datos);
                this.cmbSubrubro.DisplayMember = "Descripcion";
                this.cmbSubrubro.ValueMember = "IDSubrubro";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarComboSucursales()
        {
            try
            {
                Sucursal DatosSuc = new Sucursal { Conexion = Comun.Conexion, Opcion = 2 };
                Sucursal_Negocio SucNeg = new Sucursal_Negocio();
                this.cmbSucursales.DataSource = SucNeg.LlenarComboCatSucursales(DatosSuc);
                this.cmbSucursales.ValueMember = "IDSucursal";
                this.cmbSucursales.DisplayMember = "NombreSucursal";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CargarDatosAModificar(Gastos Datos)
        {
            try
            {
                this.dtpFechaGasto.Value = Datos.FechaGasto;

                this.txtMonto.Text = string.Format("{0:c}", Datos.Monto);
                if (this.ExisteItemEnComboRubro(Datos.IDRubro))
                    this.cmbRubro.SelectedValue = Datos.IDRubro;
                if (this.ExisteItemEnComboSubRubro(Datos.IDSubrubro))
                    this.cmbSubrubro.SelectedValue = Datos.IDSubrubro;
                if (this.ExisteItemEnComboSucursal(Datos.IDSucursal))
                    this.cmbSucursales.SelectedValue = Datos.IDSucursal;
                    this.txtObservaciones.Text = Datos.Observaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExisteItemEnComboRubro(int ID)
        {
            try 
            {
                bool Band = false;
                foreach (Rubro Item in this.cmbRubro.Items)
                {
                    if (Item.IDRubro == ID)
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

        private bool ExisteItemEnComboSubRubro(string ID)
        {
            try
            {
                bool Band = false;
                foreach (Subrubro Item in this.cmbSubrubro.Items)
                {
                    if (Item.IDSubrubro == ID)
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

        private bool ExisteItemEnComboSucursal(string ID)
        {
            try
            {
                bool Band = false;
                foreach (Sucursal Item in this.cmbSucursales.Items)
                {
                    if (Item.IDSucursal == ID)
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

        private void IniciarDatos()
        {
            try
            {
                this.dtpFechaGasto.Value = DateTime.Today;
                this.txtMonto.Text = string.Format("{0:c}", 0);
                this.txtObservaciones.Text = string.Empty;
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
                this.CargarComboRubro();
                this.CargarComboSucursales();
                if (TipoForm == 1)
                    this.IniciarDatos();
                else
                    this.CargarDatosAModificar(this._DatosGasto);
                this.ActiveControl = this.dtpFechaGasto;
                this.dtpFechaGasto.Focus();
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

        private Rubro ObtenerRubroCombo()
        {
            try
            {
                Rubro Datos = new Rubro();
                if (this.cmbRubro.Items.Count > 0)
                    if (this.cmbRubro.SelectedIndex != -1)
                        Datos = (Rubro)this.cmbRubro.SelectedItem;
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Subrubro ObtenerSubRubroCombo()
        {
            try
            {
                Subrubro Datos = new Subrubro();
                if (this.cmbSubrubro.Items.Count > 0)
                    if (this.cmbSubrubro.SelectedIndex != -1)
                        Datos = (Subrubro)this.cmbSubrubro.SelectedItem;
                return Datos;
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
                Sucursal DatosAux = new Sucursal();
                if (this.cmbSucursales.Items.Count > 0)
                {
                    if (this.cmbSucursales.SelectedIndex != -1)
                    {
                        DatosAux = (Sucursal)this.cmbSucursales.SelectedItem;
                    }
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Gastos ObtenerDatos()
        {
            try
            {
                Gastos DatosAux = new Gastos();
                DatosAux.IDGasto = TipoForm == 2 ? this._DatosGasto.IDGasto : string.Empty;
                Rubro RbAux = this.ObtenerRubroCombo();
                Subrubro SrAux = this.ObtenerSubRubroCombo();
                Sucursal SubAux = this.ObtenerSucursalCombo();
                DatosAux.IDRubro = RbAux.IDRubro;
                DatosAux.RubroDesc = RbAux.Descripcion;
                DatosAux.IDSubrubro = SrAux.IDSubrubro;
                DatosAux.SubrubroDesc = SrAux.Descripcion;
                DatosAux.FechaGasto = this.dtpFechaGasto.Value;
                DatosAux.Monto = this.ObtenerMonto();
                DatosAux.Observaciones = this.txtObservaciones.Text.Trim();
                DatosAux.IDUsuario = Comun.IDUsuario;
                DatosAux.IDSucursal = SubAux.IDSucursal;
                DatosAux.Opcion = this.TipoForm;
                DatosAux.nombreSucursal = SubAux.NombreSucursal;
                DatosAux.Conexion = Comun.Conexion;
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
                if(this.ObtenerMonto() <= 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "El monto debe ser mayor a $ 0.00.", ControlSender = this.txtMonto });
                Rubro AuxRb = this.ObtenerRubroCombo();
                if (AuxRb.IDRubro == 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una rubro.", ControlSender = this.cmbRubro });
                Subrubro AuxSr = this.ObtenerSubRubroCombo();
                if (string.IsNullOrEmpty(AuxSr.IDSubrubro))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un sub rubro.", ControlSender = this.cmbSubrubro });
                Sucursal SucAux = this.ObtenerSucursalCombo();
                if (string.IsNullOrEmpty(SucAux.IDSucursal))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione la sucursal", ControlSender = this.cmbSucursales });
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
                LogError.AddExcFileTxt(ex, "frmNuevoCiclo ~ btnCancelar_Click");
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
                    Gastos Datos = this.ObtenerDatos();
                    Gastos_Negocio GN = new Gastos_Negocio();
                    GN.ACCatGastos(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosGasto = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al guardar los datos. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCiclo ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRubro_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                Rubro DatosAux = this.ObtenerRubroCombo();
                this.CargarComboSubRubro(DatosAux.IDRubro);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCiclo ~ cmbUnidadMedida_Validating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbRubro_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.cmbRubro.SelectedIndex == -1)
                    this.CargarComboSubRubro(0);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCiclo ~ cmbUnidadMedida_Validating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoCiclo_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCiclo ~ frmNuevoCiclo_Load");
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
                LogError.AddExcFileTxt(ex, "frmNuevoCiclo ~ txtMonto_Validating");
            }
        }

        #endregion

    }
}
