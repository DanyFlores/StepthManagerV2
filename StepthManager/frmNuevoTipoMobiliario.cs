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
    public partial class frmNuevoTipoMobiliario : Form
    {
        #region Propiedades / Variables
        private int TipoForm = 0;
        private TipoMobiliario _DatosMobiliario;
        public TipoMobiliario DatosMobiliario
        {
            get { return _DatosMobiliario; }
            set { _DatosMobiliario = value; }
        }        
        #endregion

        #region Constructor

        public frmNuevoTipoMobiliario()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTipoMobiliario ~ frmNuevoTipoMobiliario()");
            }
        }

        public frmNuevoTipoMobiliario(TipoMobiliario Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosMobiliario = Datos;
                this.TipoForm = 2;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTipoMobiliario ~ frmNuevoTipoMobiliario(Proveedor Datos)");
            }
        }

        #endregion

        #region Métodos


        private void CargarDatosAModificar(TipoMobiliario Datos)
        {
            try
            {
                this.txtDescripcionTipo.Text = Datos.Descripcion;
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
                
                if(TipoForm == 2)
                    this.CargarDatosAModificar(_DatosMobiliario);
                this.ActiveControl = this.txtDescripcionTipo;
                this.txtDescripcionTipo.Focus();
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

        private TipoMobiliario ObtenerDatos()
        {
            try
            {
                TipoMobiliario DatosAux = new TipoMobiliario();
                DatosAux.IDTipoMobiliario = TipoForm == 2 ? this._DatosMobiliario.IDTipoMobiliario : string.Empty;
                
               
                DatosAux.Descripcion = this.txtDescripcionTipo.Text.Trim();
               
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
                if (string.IsNullOrEmpty(this.txtDescripcionTipo.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el Tipo Mobiliario", ControlSender = this.txtDescripcionTipo });
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
                LogError.AddExcFileTxt(ex, "frmNuevoTipoMobiliario ~ btnCancelar_Click");
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
                    TipoMobiliario Datos = this.ObtenerDatos();
                    Catalogo_Negocio cn = new Catalogo_Negocio();
                    cn.ABCTipoMobiliario(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosMobiliario = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al guardar los datos.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTipoMobiliario ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoTipoMobiliario_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTipoMobiliario ~ frmNuevoTipoMobiliario_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
