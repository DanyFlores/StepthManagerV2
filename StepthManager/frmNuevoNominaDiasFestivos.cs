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
    public partial class frmNuevoNominaDiasFestivos : Form
    {
        #region Propiedades / Variables
        private int TipoForm = 0;
        private DiasFestivos _DatosDiasFestivos;
        public DiasFestivos DatosDiasFestivos
        {
            get { return _DatosDiasFestivos; }
            set { _DatosDiasFestivos = value; }
        }        
        #endregion

        #region Constructor

        public frmNuevoNominaDiasFestivos()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoNominaDiasFestivos ~ frmNuevoNominaDiasFestivos()");
            }
        }

        public frmNuevoNominaDiasFestivos(DiasFestivos Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosDiasFestivos = Datos;
                this.TipoForm = 2;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoNominaDiasFestivos ~ frmNuevoNominaDiasFestivos(DiasFestivos Datos)");
            }
        }

        #endregion

        #region Métodos

        private void CargarDatosAModificar(DiasFestivos Datos)
        {
            try
            {
                this.txtDescripcion.Text = Datos.Descripcion;
                this.dtpFecha.Value = Datos.Fecha;
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
                    this.CargarDatosAModificar(_DatosDiasFestivos);
                this.ActiveControl = this.txtDescripcion;
                this.txtDescripcion.Focus();
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

        private DiasFestivos ObtenerDatos()
        {
            try
            {
                DiasFestivos DatosAux = new DiasFestivos();
                DatosAux.IDDiasFestivos = TipoForm == 2 ? this._DatosDiasFestivos.IDDiasFestivos : string.Empty;
                DatosAux.Descripcion = this.txtDescripcion.Text.Trim();
                DatosAux.Fecha = Convert.ToDateTime(this.dtpFecha.Value.ToShortDateString());
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
                //Validar Razon Social del Proveedor
                if (string.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un nombre válido.", ControlSender = this.txtDescripcion });
                else
                {
                    if(!Validar.IsValidDescripcion(this.txtDescripcion.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un nombre válido", ControlSender = this.txtDescripcion });
                }
                if (this.dtpFecha.Value < DateTime.Today)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La fecha no puede ser menor a la fecha actual.", ControlSender = this.dtpFecha });
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
                LogError.AddExcFileTxt(ex, "frmNuevoNominaDiasFestivos ~ btnCancelar_Click");
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
                    DiasFestivos Datos = this.ObtenerDatos();
                    Catalogo_Negocio cn = new Catalogo_Negocio();
                    cn.ABCDiasFestivos(Datos);
                    if (Datos.Completado == true)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosDiasFestivos = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (Datos.Resultado == 51000)
                        {
                            MessageBox.Show("La fecha ya esta registrada", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoNominaDiasFestivos ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoNominaDiasFestivos_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoNominaDiasFestivos ~ frmNuevoNominaDiasFestivos_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
