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
using CreativaSL.Dll.Validaciones;
using System.IO;

namespace StephManager
{
    public partial class frmAsignarCaja : Form
    {
        
        #region Constructor

        public frmAsignarCaja()
        {
            try
            {
                InitializeComponent();
                Comun.Conexion = ConfigurationManager.AppSettings.Get("strConnection");
                Comun.Sistema = "Steph v1.0";
                Comun.IDUsuario = "System";
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmAsignarCaja ~ frmAsignarCaja()");
            }
        }

        #endregion

        #region Métodos

        private void CargarCombos()
        {
            try
            {
                this.LLenarComboCajas();
                this.LlenarComboSucursales();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GuardarMac()
        {
            try
            {
                Caja_Negocio CN = new Caja_Negocio();
                Caja DatosCaja = new Caja();
                DatosCaja = this.ObtenerDatos();
                if (string.IsNullOrEmpty(Comun.MACAddress.Trim()))
                    DatosCaja.Opcion = 0;
                else
                    DatosCaja.Opcion = 1;
                CN.AsignarCajaMac(DatosCaja);
                if (DatosCaja.Completado)
                {
                    MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.txtMensajeError.Visible = true;
                    List<Error> ErrorAux = new List<Error>();
                    ErrorAux.Add(new Error { Numero = 1, Descripcion = "No se pudo actualizar la información. Es probable que la dirección MAC ya esté registrada.", ControlSender = mktxtMac });
                    this.MostrarMensajeError(ErrorAux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Inicializar()
        {
            try
            {
                this.CargarCombos();
                this.mktxtMac.Text = Comun.MACAddress;
                this.txtNombreCaja.Text = Comun.HostName;
                if (string.IsNullOrEmpty(Comun.MACAddress))
                {
                    this.mktxtMac.ReadOnly = false;
                }
                this.ActiveControl = this.mktxtMac;
                this.mktxtMac.Focus();
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

        private void LlenarComboSucursales()
        {
            try
            {
                Sucursal Datos = new Sucursal { Opcion = 1, Conexion = Comun.Conexion };
                Sucursal_Negocio SN = new Sucursal_Negocio();
                this.cmbSucCaja.DataSource = SN.LlenarComboCatSucursales(Datos);
                this.cmbSucCaja.ValueMember = "IDSucursal";
                this.cmbSucCaja.DisplayMember = "NombreSucursal";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LLenarComboCajas()
        {
            try
            {
                Caja Datos = new Caja{Opcion = 1, Conexion =  Comun.Conexion};
                Caja_Negocio CN = new Caja_Negocio();                
                this.cmbCajas.DataSource = CN.LlenarComboCatCajas(Datos);
                this.cmbCajas.ValueMember = "IDCajaCat";
                this.cmbCajas.DisplayMember = "CajaCat";

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
                Caja DatosCaja = new Caja();
                Caja CajaSeleccionada = new Caja();
                Sucursal SucSeleccionada = new Sucursal();
                if(this.cmbCajas.SelectedIndex != -1)
                    CajaSeleccionada = (Caja)this.cmbCajas.SelectedItem;
                if(this.cmbSucCaja.SelectedIndex != -1)
                    SucSeleccionada = (Sucursal)this.cmbSucCaja.SelectedItem;
                DatosCaja.IDCajaCat = CajaSeleccionada.IDCajaCat;
                DatosCaja.Mac = this.mktxtMac.Text;
                DatosCaja.NombreCaja = this.txtNombreCaja.Text;
                DatosCaja.IDSucursal = SucSeleccionada.IDSucursal;
                DatosCaja.Conexion = Comun.Conexion;
                return DatosCaja;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Error> ValidarCampos()
        {
            try
            {
                List<Error> ListaErrores = new List<Error>();
                int Aux = 0;
                if (string.IsNullOrEmpty(this.mktxtMac.Text.Trim()))
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese una dirección MAC válida.", ControlSender = this.mktxtMac });
                if (!Validar.IsValidMACAddress(this.mktxtMac.Text.Trim()))
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese una dirección MAC válida.", ControlSender = this.mktxtMac });
                if (this.cmbCajas.SelectedIndex == -1)
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un número de caja.", ControlSender = this.cmbCajas });
                Caja CajaSeleccionada = (Caja)this.cmbCajas.SelectedItem;
                if (string.IsNullOrEmpty(CajaSeleccionada.IDCajaCat))
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un número de caja.", ControlSender = this.cmbCajas });
                if (this.cmbSucCaja.SelectedIndex == -1)
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una sucursal para la caja.", ControlSender = this.cmbSucCaja });
                Sucursal SucSeleccionada = (Sucursal)this.cmbSucCaja.SelectedItem;
                if (string.IsNullOrEmpty(SucSeleccionada.IDSucursal))
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una sucursal para la caja.", ControlSender = this.cmbSucCaja });
                if (string.IsNullOrEmpty(this.txtNombreCaja.Text) || string.IsNullOrWhiteSpace(this.txtNombreCaja.Text))
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Asigne un nombre a la caja..", ControlSender = this.txtNombreCaja });
                return ListaErrores;
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
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAsignarCaja ~ btn_Cancelar_Click");
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtMensajeError.Visible = false;
                List<Error> Errores = ValidarCampos();
                if (Errores.Count == 0)
                {
                    this.GuardarMac();
                }
                else
                {
                    this.MostrarMensajeError(Errores);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAsignarCaja ~ btn_Guardar_Click");
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void frmAsignarCaja_Load(object sender, EventArgs e)
        {
            try
            {
                this.Inicializar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAsignarCaja ~ frmAsignarCaja_Load");
                this.DialogResult = DialogResult.Abort;
            }
        }

        #endregion

    }
}
