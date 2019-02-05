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
using CreativaSL.LibControls.WinForms;
using StephManager.ClasesAux;
using CreativaSL.Dll.Validaciones;
using System.IO;

namespace StephManager
{
    public partial class frmNuevaTarjeta : Form
    {
        #region Propiedades / Variables
        private int TipoForm = 0;
        private TarjetaMonedero _DatosTarjetaMonedero;
        public TarjetaMonedero DatosTarjetaMonedero
        {
            get { return _DatosTarjetaMonedero; }
            set { _DatosTarjetaMonedero = value; }
        }        
        #endregion

        #region Constructor

        public frmNuevaTarjeta()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaTarjeta ~ frmNuevaTarjeta()");
            }
        }

        public frmNuevaTarjeta(TarjetaMonedero Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosTarjetaMonedero = Datos;
                this.TipoForm = 2;
                this.IniciarForm();
                this.CargarDatosAModificar(Datos);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaTarjeta ~ frmNuevaTarjeta(TarjetaMonedero Datos)");
            }
        }

        #endregion

        #region Métodos

        private void CargarDatosAModificar(TarjetaMonedero Datos)
        {
            try
            {
                this.txtFolio.Text = Datos.Folio;
                if(this.ExisteItemEnCombo(Datos.IDTipoMonedero))
                    this.cmbTipoMonedero.SelectedValue = Datos.IDTipoMonedero;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExisteItemEnCombo(int ID)
        {
            try
            {
                int Aux = 0;
                foreach (DataRowView fila in this.cmbTipoMonedero.Items)
                {
                    int.TryParse(fila["IDTipoMonedero"].ToString(), out Aux);
                    if (Aux == ID)
                        return true;
                }
                return false;
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
                this.LlenarComboTipoMonedero();
                this.ActiveControl = this.cmbTipoMonedero;
                this.cmbTipoMonedero.Focus();
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

        private void LlenarComboTipoMonedero()
        {
            try
            {
                TipoMonedero Datos = new TipoMonedero();
                Catalogo_Negocio cn = new Catalogo_Negocio();
                Datos.Conexion = Comun.Conexion;
                Datos.Opcion = 2;
                cn.ObtenerCatTipoMonedero(Datos);
                this.cmbTipoMonedero.DisplayMember = "Descripcion";
                this.cmbTipoMonedero.ValueMember = "IDTipoMonedero";
                this.cmbTipoMonedero.DataSource = Datos.TablaDatos;
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
                object Aux = this.cmbTipoMonedero.SelectedValue;
                int IDTipoMonedero = 0;
                int.TryParse(Aux.ToString(), out IDTipoMonedero);
                DataRowView Seleccionada = (DataRowView)this.cmbTipoMonedero.SelectedItem;
                DatosAux.IDTarjeta = TipoForm == 2 ? this._DatosTarjetaMonedero.IDTarjeta : string.Empty;
                DatosAux.Folio = this.txtFolio.Text.Trim();
                DatosAux.IDTipoMonedero = IDTipoMonedero;

                DatosAux.TipoMonederoDesc = Seleccionada != null ? Seleccionada["Descripcion"].ToString() : string.Empty;
                DatosAux.Opcion = this.TipoForm;
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
                int Aux = 0;
                if (this.cmbTipoMonedero.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción válida.", ControlSender = this.cmbTipoMonedero });
                else
                {
                    int IDTipoMonedero = 0;
                    int.TryParse(this.cmbTipoMonedero.SelectedValue.ToString().Trim(), out IDTipoMonedero);
                    if (IDTipoMonedero == 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción válida.", ControlSender = this.cmbTipoMonedero });
                }
                if (string.IsNullOrEmpty(this.txtFolio.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un folio válido.", ControlSender = this.txtFolio });
                else
                    if(!Validar.IsValidOnlyNumber(this.txtFolio.Text))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un folio válido.", ControlSender = this.txtFolio });
                
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
                LogError.AddExcFileTxt(ex, "frmNuevaTarjeta ~ btnCancelar_Click");
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
                    TarjetaMonedero Datos = this.ObtenerDatos();
                    Catalogo_Negocio cn = new Catalogo_Negocio();
                    cn.ABCCatTarjetaMonedero(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosTarjetaMonedero = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        List<Error> LstError = new List<Error>();
                        LstError.Add(new Error { Numero = 1, Descripcion = "El número de tarjeta ingresado ya existe. ", ControlSender = this.txtFolio });
                        this.MostrarMensajeError(LstError);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaTarjeta ~ btnGuardar_Click");
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
                LogError.AddExcFileTxt(ex, "frmNuevaTarjeta ~ txtDescripcion_KeyPress");
            }
        }

        #endregion
    }
}
