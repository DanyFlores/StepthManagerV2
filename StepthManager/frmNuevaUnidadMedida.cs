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
    public partial class frmNuevaUnidadMedida : Form
    {
       
        #region Propiedades / Variables
        private int TipoForm = 0;
        private UnidadMedida _DatosUnidad;
        public UnidadMedida DatosUnidad
        {
            get { return _DatosUnidad; }
            set { _DatosUnidad = value; }
        }        
        #endregion

        #region Constructor

        public frmNuevaUnidadMedida()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaUnidadMedida ~ frmNuevaUnidadMedida()");
            }
        }

        public frmNuevaUnidadMedida(UnidadMedida Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosUnidad = Datos;
                this.TipoForm = 2;
                this.CargarDatosAModificar(Datos);
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaUnidadMedida ~ frmNuevaUnidadMedida(UnidadMedida Datos)");
            }
        }

        #endregion

        #region Métodos

        private void CargarDatosAModificar(UnidadMedida Datos)
        {
            try
            {
                this.txtDescripcion.Text = Datos.Descripcion;
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

        private UnidadMedida ObtenerDatos()
        {
            try
            {
                UnidadMedida DatosAux = new UnidadMedida();
                DatosAux.IDUnidadMedida = TipoForm == 2 ? _DatosUnidad.IDUnidadMedida : 0;
                DatosAux.Descripcion = this.txtDescripcion.Text.Trim();
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
                int aux = 0;
                if (string.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
                    Errores.Add(new Error { Numero = (aux += 1), Descripcion = "Ingrese una descripción válida.", ControlSender = this.txtDescripcion });
                //else
                    //if(!Validar.IsValidName(this.txtDescripcion.Text))
                    //    Errores.Add(new Error { Numero = (aux += 1), Descripcion = "Ingrese una descripción válida.", ControlSender = this.txtDescripcion });
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
                LogError.AddExcFileTxt(ex, "frmNuevaUnidadMedida ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                    UnidadMedida Datos = this.ObtenerDatos();
                    Catalogo_Negocio cn = new Catalogo_Negocio();
                    cn.ABCCatUnidadMedida(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosUnidad = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaUnidadMedida ~ btnGuardar_Click");
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
                LogError.AddExcFileTxt(ex, "frmNuevaUnidadMedida ~ txtDescripcion_KeyPress");
            }
        }
        #endregion
    }
}
