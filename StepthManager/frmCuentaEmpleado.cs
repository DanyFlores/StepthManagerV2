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
using CreativaSL.Dll.Validaciones;
using StephManager.ClasesAux;
using System.IO;

namespace StephManager
{
    public partial class frmCuentaEmpleado : Form
    {
        #region Propiedades / Variables
        private int TipoForm = 0;
        private Usuario _DatosUsuario;

        public Usuario DatosUsuario
        {
            get { return _DatosUsuario; }
            set { _DatosUsuario = value; }
        }
        
        #endregion

        #region Constructor

        public frmCuentaEmpleado()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCuentaEmpleado ~ frmCuentaEmpleado()");
            }
        }

        public frmCuentaEmpleado(Usuario Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosUsuario = Datos;
                this.TipoForm = 2;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCuentaEmpleado ~ frmCuentaEmpleado(CuentaUsuario Datos)");
            }
        }

        #endregion

        #region Métodos

        private void CargarDatosAModificar(Usuario Datos)
        {
            try
            {
                
                this.txtUsuario.Text = Datos.CuentaUsuario;
                //this.txtPassword.Text = Datos.Password;
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
                if (TipoForm == 1)
                    this.InicializarCampos();
                else
                    this.CargarDatosAModificar(_DatosUsuario);
                if (this.txtUsuario.Text != string.Empty)
                {
                    this.txtUsuario.Enabled = false;
                    this.ActiveControl = this.txtPassword;
                    this.txtPassword.Focus();
                }
                else
                {
                    this.ActiveControl = this.txtUsuario;
                    this.txtUsuario.Focus();
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

        private void InicializarCampos()
        {
            try
            {
                this.txtUsuario.Text = string.Empty;
                this.txtPassword.Text = string.Empty;
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

        private Usuario ObtenerDatos()
        {
            try
            {
                Usuario DatosAux = new Usuario();
                DatosAux.IDEmpleado = TipoForm == 2 ? this._DatosUsuario.IDEmpleado : string.Empty;
                DatosAux.CuentaUsuario = this.txtUsuario.Text.Trim();
                DatosAux.Password = this.txtPassword.Text.Trim();
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
                if (string.IsNullOrEmpty(this.txtUsuario.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar la cuenta de usuario.", ControlSender = this.txtUsuario });
                else
                {
                    if (!Validar.IsValidUserName(this.txtUsuario.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar una cuenta de usuario válido.", ControlSender = this.txtUsuario });
                }
                if (string.IsNullOrEmpty(this.txtPassword.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar la contraseña del usuario.", ControlSender = this.txtPassword });
                //else
                //{
                //    if (!Validar.IsValidPassword(this.txtPassword.Text.Trim()))
                //        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar una contraseña válida.", ControlSender = this.txtPassword });
                //}
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
                LogError.AddExcFileTxt(ex, "frmCuentaEmpleado ~ btnCancelar_Click");
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
                    Usuario Datos = this.ObtenerDatos();
                    Usuario_Negocio CN = new Usuario_Negocio();
                    CN.ABCCuentaUsuario(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosUsuario = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        //if (Datos.Resultado > 0)
                        //{
                            List<Error> LstError = new List<Error>();
                            LstError.Add(new Error { Numero = 1, Descripcion = "La cuenta de usuario ya existe.", ControlSender = this });
                            this.MostrarMensajeError(LstError);
                        //}
                        //else
                        //    MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCuentaEmpleado ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCuentaEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCuentaEmpleado ~ frmCuentaEmpleado_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
