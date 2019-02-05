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
using System.Configuration;
using System.IO;

namespace StephManager
{
    public partial class frmLogin : Form
    {
        #region Constructor

        public frmLogin()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmLogin ~ frmLogin()");
            }
        }

        #endregion

        #region Eventos

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                List<Error> Errores = this.ValidarDatosEntrada();
                if (Errores.Count == 0)
                {
                    IniciarSistema();
                    Usuario DatosUsuario = new Usuario();
                    DatosUsuario = this.ObtenerDatosUsuario();
                    DatosUsuario.Conexion = Comun.Conexion;
                    if (!string.IsNullOrEmpty(Comun.MACAddress))
                    {
                        this.Ingresar(DatosUsuario);

                        if (Comun.FaltaLogo)
                        {

                            Configuracion_Negocio CN = new Configuracion_Negocio();
                            Configuracion Aux = CN.ObtenerLogoImagen(Comun.Conexion);
                            if (Aux.BufferImagen.Length > 0)
                            {
                                Bitmap imagen = null;
                                Byte[] bytes = Aux.BufferImagen;
                                MemoryStream ms = new MemoryStream(bytes);
                                imagen = new Bitmap(ms);
                                try
                                {
                                    imagen.Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                                }
                                catch (Exception ex)
                                {
                                    LogError.AddExcFileTxt(ex, "SaveImage ~ Login");
                                }
                                Aux.IDSucursal = Comun.IDSucursalCaja;
                                Aux.Conexion = Comun.Conexion;
                                CN.LogoActualizado(Aux);
                            }
                        }


                        if (DatosUsuario.Completado)
                        {
                            if (DatosUsuario.Resultado == 1)
                            {
                                if (DatosUsuario.CrearIDCaja)
                                {
                                    frmAperturaCaja AperturaCaja = new frmAperturaCaja();
                                    AperturaCaja.ShowDialog();
                                    AperturaCaja.Dispose();
                                    if (AperturaCaja.DialogResult == DialogResult.OK)
                                    {
                                        this.Visible = false;
                                        frmMenuInicio Home = new frmMenuInicio();
                                        Home.ShowDialog();
                                        Home.Dispose();
                                        this.Visible = true;
                                        this.txtUsuario.Focus();
                                        this.txtUsuario.Text = "";
                                        this.txtContraseña.Text = "";
                                        this.txtMensajeError.Text = "";
                                        this.txtMensajeError.Visible = false;
                                    }
                                }
                                else
                                {
                                    this.Visible = false;
                                    frmMenuInicio Home = new frmMenuInicio();
                                    Home.ShowDialog();
                                    Home.Dispose();
                                    this.Visible = true;
                                    this.txtUsuario.Focus();
                                    this.txtUsuario.Text = "";
                                    this.txtContraseña.Text = "";
                                    this.txtMensajeError.Text = "";
                                    this.txtMensajeError.Visible = false;
                                }
                            }
                            else
                            {
                                this.DatosIncorrectos(DatosUsuario.Resultado);
                                if (DatosUsuario.Resultado == -8)
                                {
                                    frmAsignarCaja frmac = new frmAsignarCaja();
                                    frmac.ShowDialog();
                                    frmac.Dispose();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "No se pudo obtener la configuración del Equipo. El sistema debe cerrarse.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "No se pudo obtener la configuración del Equipo. El sistema debe cerrarse.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
                else
                {
                    this.MostrarMensajeError(Errores);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmLogin ~ btnAceptar_Click");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CerrarSistema();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmLogin ~ btnCancelar_Click");
            }
        }

        private void frmLogin_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    this.CerrarSistema();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmLogin ~ frmLogin_KeyUp");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmLogin ~ frmLogin_Load");
            }
        }        

        private void txt_Enter(object sender, EventArgs e)
        {
            try
            {
                TextBox Aux = (TextBox)sender;
                Aux.SelectAll();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmLogin ~ txtContraseña_Enter");
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                TextBox Aux = (TextBox)sender;
                if (e.KeyChar == 13)
                {
                    switch (Aux.Name)
                    {
                        case "txtUsuario": 
                            this.txtContraseña.Focus();
                            break;
                        case "txtContraseña":
                            this.btnLogin_Click(sender, e);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmLogin ~ txtContraseña_KeyPress");
            }
        }

        #endregion

        #region Metodos

        private void CerrarSistema()
        {
            try
            {
                if (MessageBox.Show("¿Está seguro que desea salir de la aplicación?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    Application.Exit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDatosIniciales()
        {
            try
            {
                Comun.Conexion = ConfigurationManager.AppSettings.Get("strConnection");
                Comun.MensajeError = "Error al cargar los datos. Contacte a Soporte Técnico.";
                Comun.Sistema = "Steph Manager v1.0.";
                Comun.IDProyecto = 1;
                //Comun.urlLogTxt = @"Resources\documents\LogErrorFile.txt";
                ////Comun.UrlLogo = "logo.png";
                //Comun.UrlAyuda = @"Resources\documents\Ayuda.pdf";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        private void DatosIncorrectos(int opcion)
        {
            try
            {
                switch (opcion)
                {
                    case -1:
                        this.Mensaje("Su cuenta está bloqueada. Comuníquese con un Administrador.");
                        break;
                    case -2:
                        this.Mensaje("El usuario no está registrado para ésta Sucursal.");
                        break;
                    case -3:
                        this.Mensaje("El usuario no tiene permisos para acceder a éste proyecto.");
                        break;
                    case -4:
                        this.Mensaje("El proyecto no está registrado. Contacte a Soporte Técnico.");
                        break;
                    case -5:
                        this.Mensaje("Ha excedido el número de intentos. Su cuenta fue bloqueada. Comuníquese con un Administrador.");
                        break;
                    case -6:
                        this.Mensaje("Contraseña incorrecta. Intente nuevamente.");                        
                        break;
                    case -7:
                        this.Mensaje("No existe la cuenta.");
                        break;
                    case -8:
                        this.Mensaje("No fue localizada la caja. Asigne una caja.");
                        break;
                    case 10:
                        this.Mensaje("No se pudo obtener la configuración del Equipo. El sistema debe cerrarse");
                        break;
                    case 15:
                        this.Mensaje("No se pudo conectar al servidor.");
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Datos incorrectos" + ex.Message);
            }
        }

        private string GetHostName()
        {
            try
            {
                string HostName = String.Empty;
                if (Convert.ToBoolean(ConfigurationManager.AppSettings.Get("strBanHostName")))
                {
                    HostName = ConfigurationManager.AppSettings.Get("strHostName");
                }
                else
                {
                    ManagementObjectSearcher objMOS = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");
                    ManagementObjectCollection objMOC = objMOS.Get();
                    foreach (ManagementObject objMO in objMOC)
                    {
                        if (HostName == String.Empty)
                        {
                            HostName = objMO["DNSHostName"].ToString();
                            break;
                        }
                        objMO.Dispose();
                    }
                }
                return HostName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetMACAddress()
        {
            try
            {
                string MACAddress = String.Empty;
                if (Convert.ToBoolean(ConfigurationManager.AppSettings.Get("strBanMac")))
                {
                    MACAddress = ConfigurationManager.AppSettings.Get("strMac");
                }
                else
                {
                    ManagementObjectSearcher objMOS = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");
                    ManagementObjectCollection objMOC = objMOS.Get();
                    foreach (ManagementObject objMO in objMOC)
                    {
                        if (MACAddress == String.Empty)
                        {
                            MACAddress = objMO["MacAddress"].ToString();
                            break;
                        }
                        objMO.Dispose();
                    }
                }               
                return MACAddress;
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
                this.CargarDatosIniciales();
                this.ActiveControl = this.txtUsuario;
                this.txtUsuario.Focus();
                //Login_Negocio LN = new Login_Negocio();
                //if (LN.IsNewSystem(Comun.Conexion))
                //{
                //    frmInicial FormInicio = new frmInicial();
                //    FormInicio.ShowDialog();
                //    FormInicio.Dispose();
                //    if (FormInicio.DialogResult != DialogResult.OK)
                //    {
                //        Application.Exit();
                //    }
                //}
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void IniciarSistema()
        {
            try
            {
                Comun.MACAddress = this.GetMACAddress();
                Comun.HostName = this.GetHostName();
                if (string.IsNullOrEmpty(Comun.HostName))
                    Comun.HostName = string.Empty;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Ingresar(Usuario Datos)
        {
            try
            {
                Login_Negocio LN = new Login_Negocio();
                LN.ValidarUsuario(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Mensaje(string msj)
        {
            try
            {
                this.txtMensajeError.Text = msj;
                this.txtMensajeError.Visible = true;
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

        private Usuario ObtenerDatosUsuario()
        {
            try
            {
                Usuario DatosAux = new Usuario();
                DatosAux.CuentaUsuario = this.txtUsuario.Text.Trim();
                DatosAux.Password = this.txtContraseña.Text.Trim();
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Error> ValidarDatosEntrada()
        {
            try
            {
                List<Error> Errores = new List<Error>();
                if (string.IsNullOrEmpty(this.txtUsuario.Text.Trim()))
                    Errores.Add(new Error { Numero = 1, Descripcion = "Debe ingresar un usuario.", ControlSender= this.txtUsuario });
                if(string.IsNullOrEmpty(this.txtContraseña.Text.Trim()))
                    Errores.Add(new Error { Numero = 2, Descripcion = "Debe ingresar una contraseña.", ControlSender = this.txtContraseña });
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
