using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using StephManager.ClasesAux;
using CreativaSL.Dll.Validaciones;
using System.Configuration;
using System.IO;

namespace StephManager
{
    public partial class frmInicial : Form
    {

        #region Constructor
        public frmInicial()
        {
            InitializeComponent();
        }
        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                this.ActiveControl = this.txtRazonSocial;
                this.txtRazonSocial.Focus();
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

        private DatosIniciales ObtenerDatos()
        {
            try
            {
                DatosIniciales DatosAux = new DatosIniciales();
                DatosAux.IDProyecto = 1;
                DatosAux.RazonSocial = this.txtRazonSocial.Text.Trim();
                DatosAux.NombreSucursal = this.txtSucursal.Text.Trim();
                DatosAux.CuentaUsuario = this.txtUsuario.Text.Trim();
                DatosAux.Password = this.txtPassword.Text.Trim();
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
                if (string.IsNullOrEmpty(this.txtRazonSocial.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar la razón social de la empresa.", ControlSender = this.txtRazonSocial });
                else
                {
                    if (!Validar.IsValidDescripcion(this.txtRazonSocial.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar una razón social válida.", ControlSender = this.txtRazonSocial });
                }
                if (string.IsNullOrEmpty(this.txtSucursal.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un nombre de sucursal.", ControlSender = this.txtSucursal });
                else
                {
                    if (!Validar.IsValidDescripcion(this.txtSucursal.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar una nombre de sucursal válido.", ControlSender = this.txtSucursal });
                }
                if (string.IsNullOrEmpty(this.txtUsuario.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un nombre de usuario.", ControlSender = this.txtUsuario });
                else
                {
                    if (!Validar.IsValidUserName(this.txtUsuario.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un nombre deusuario válido.", ControlSender = this.txtUsuario });
                }
                if (string.IsNullOrEmpty(this.txtPassword.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar una contraseña.", ControlSender = this.txtPassword });
                else
                {
                    if (!Validar.IsValidPassword(this.txtPassword.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar una contraseña válida: Debe contener al menos una letra mayúscula, una letra minúscula, un número o caracter especial, y mínimo 8 caracteres de longitud.", ControlSender = this.txtPassword });
                }
                return Errores;
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
                this.txtMensajeError.Visible = false;
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                    DatosIniciales Datos = this.ObtenerDatos();
                    Login_Negocio LN = new Login_Negocio();
                    LN.IniciarDatos(Datos);
                    if (Datos.Completado)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Ocurrió un error al guardar los datos. Contacte a Soporte Técnico.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmInicial ~ frmInicial_Load");
            }
        }

        private void frmInicial_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmInicial ~ frmInicial_Load");
            }
        }

        #endregion

    }
}
