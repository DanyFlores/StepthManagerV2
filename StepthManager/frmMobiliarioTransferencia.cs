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
    public partial class frmMobiliarioTransferencia : Form
    {
        #region Variables

        private Mobiliario _Datos = new Mobiliario();

        #endregion

        #region Constructor

        public frmMobiliarioTransferencia(Mobiliario Datos)
        {
            try
            {
                InitializeComponent();
                this._Datos = Datos;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliarioTransferencia ~ frmMobiliarioTransferencia()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
                this.CargarComboSucursales();
                this.LlenarDatos();
                this.ActiveControl = this.cmbSucursalDestino;
                this.cmbSucursalDestino.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarDatos()
        {
            try
            {
                this.txtCodigo.Text = this._Datos.Codigo;
                this.txtDescripcion.Text = this._Datos.Descripcion;
                this.txtSucursalActual.Text = this._Datos.NombreSucursal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarComboDestino(List<Sucursal> Lista)
        {
            try
            {
                List<Sucursal> NuevaLista = new List<Sucursal>();
                foreach (Sucursal Item in Lista)
                {
                    NuevaLista.Add(Item);
                }
                this.cmbSucursalDestino.DataSource = NuevaLista;
                this.cmbSucursalDestino.ValueMember = "IDSucursal";
                this.cmbSucursalDestino.DisplayMember = "NombreSucursal";
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
                Sucursal DatosSuc = new Sucursal { Conexion = Comun.Conexion, Opcion = 1 };
                Sucursal_Negocio SucNeg = new Sucursal_Negocio();
                List<Sucursal> Lista = SucNeg.LlenarComboCatSucursales(DatosSuc);
                this.CargarComboDestino(Lista);
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

        private Mobiliario ObtenerDatos()
        {
            try
            {
                Mobiliario DatosAux = this._Datos;
                DatosAux.IDSucursalDestino = this.ObtenerSucursalSeleccionada(this.cmbSucursalDestino).IDSucursal;
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Sucursal ObtenerSucursalSeleccionada(ComboBox CmbSuc)
        {
            try
            {
                Sucursal DatosSuc = new Sucursal();
                if (CmbSuc.Items.Count > 0)
                {
                    if (CmbSuc.SelectedIndex != -1)
                    {
                        DatosSuc = (Sucursal)CmbSuc.SelectedItem;
                    }
                }
                return DatosSuc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Error> ValidarErrores()
        {
            try
            {
                List<Error> Errores = new List<Error>();
                int Aux = 0;
                Sucursal Suc = this.ObtenerSucursalSeleccionada(this.cmbSucursalDestino);
                if (string.IsNullOrEmpty(Suc.IDSucursal))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione la sucursal de destino.", ControlSender = this.cmbSucursalDestino});
                if(Suc.IDSucursal == this._Datos.IDSucursal)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La sucursal de destino debe ser difeente a la sucursal origen.", ControlSender = this.cmbSucursalDestino });
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
                LogError.AddExcFileTxt(ex, "frmMobiliarioTransferencia ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtMensajeError.Visible = false;
                List<Error> Errores = this.ValidarErrores();
                if (Errores.Count == 0)
                {
                    Mobiliario DatosAux = this.ObtenerDatos();
                    Mobiliario_Negocio MN = new Mobiliario_Negocio();
                    MN.TransferenciaMobiliario(DatosAux);
                    if (DatosAux.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                LogError.AddExcFileTxt(ex, "frmMobiliarioTransferencia ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMobiliarioTransferencia_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliarioTransferencia ~ frmMobiliarioTransferencia_Load");
            }
        }

        private void txtCantidad_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                TextBox Stock = (TextBox)sender;
                decimal StockDec = 0;
                decimal.TryParse(Stock.Text, out StockDec);
                Stock.Text = string.Format("{0:F2}", StockDec);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventarioTransferencia ~ txtStock_Validating");
            }
        }

        #endregion

    }
}
