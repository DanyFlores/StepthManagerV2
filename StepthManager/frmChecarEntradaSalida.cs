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
using System.Drawing.Imaging;
using System.IO;

namespace StephManager
{
    public partial class frmChecarEntradaSalida : Form
    {
        #region Propiedades/Variables

        private TipoRegistro DatosTipoRegistro = new TipoRegistro();
        public LectorHuella Lector = new LectorHuella();
        private DateTime FechaChecador = new DateTime();

        #endregion

        #region Constructor

        public frmChecarEntradaSalida(TipoRegistro TipoRegistro)
        {
            try
            {
                InitializeComponent();
                DatosTipoRegistro = TipoRegistro;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmChecarEntradaSalida ~ frmChecarEntradaSalida");
            }
        }

        #endregion

        #region Métodos

        public bool Checar(string IDEmpleado)
        {
            try
            {
                if (!string.IsNullOrEmpty(IDEmpleado))
                {
                    Checador Registro = new Checador();
                    Registro.FechaChecador = this.FechaChecador;
                    Registro.IDTipoRegistro = this.DatosTipoRegistro.IDTipoRegistro;
                    Registro.IDEmpleado = IDEmpleado;
                    Registro.IDUsuario = IDEmpleado;
                    Registro.Motivo = "Registro Automático";
                    Registro.DispChecador = true;
                    Registro.Conexion = Comun.Conexion;
                    Checador_Negocio CN = new Checador_Negocio();
                    CN.Checar(Registro);
                    if (Registro.Completado)
                    {
                        if (Registro.Opcion == 1)
                        {
                            return true;
                        }
                    }
                    this.lblInstrucciones.Text = "Ocurrió un error. Intente nuevamente.";
                    return false;
                }
                else
                {
                    this.lblInstrucciones.Text = "Checado Incorrecto";
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "Checar(string IDEmpleado)");
                return false;
                //this.Lector.Close();
            }
        }

        private void DibujarHora()
        {
            try
            {
                this.lblHora.Text = this.FechaChecador.ToString("HH:mm:ss");
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
                this.ObtenerHoraServidor();
                this.lblTitulo.Text = "Registrar " + DatosTipoRegistro.Descripcion;
                Lector.TipoForm = 1;
                Lector.FrmChecar = this;
                Lector.Close();
                Lector.Init();
                Lector.Start();
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

        private void ObtenerHoraServidor()
        {
            try
            {
                Catalogo_Negocio CN = new Catalogo_Negocio();
                FechaChecador = CN.ObtenerFechaSistema(Comun.Conexion);
                this.tmrHoraChecador.Enabled = true;
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
                this.Lector.Stop();
                Lector.Template = null;
                Lector = new LectorHuella();
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmChecarEntradaSalida ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmChecarEntradaSalida_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Lector.Stop();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmChecarEntradaSalida ~ frmCatEmpleadoHuella_FormClosing");
            }
        }

        public void frmChecarEntradaSalida_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmChecarEntradaSalida ~ frmChecarEntradaSalida_Load");
            }
        }

        private void HoraChecador_Tick(object sender, EventArgs e)
        {
            try
            {
                tmrHoraChecador.Stop();
                this.FechaChecador = this.FechaChecador.AddSeconds(1);
                this.DibujarHora();
                tmrHoraChecador.Start();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmChecarEntradaSalida ~ HoraChecador_Tick");
                tmrHoraChecador.Start();
            }

        }

        #endregion

    }
}
