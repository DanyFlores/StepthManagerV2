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
    public partial class frmNuevoCategoriaPuesto : Form
    {
        #region Propiedades / Variables
        private int TipoForm = 0;
        private CategoriasPuesto _DatosCategoriaPuesto;
        public CategoriasPuesto DatosCategoriaPuesto
        {
            get { return _DatosCategoriaPuesto; }
            set { _DatosCategoriaPuesto = value; }
        }
        #endregion

        #region Constructor

        public frmNuevoCategoriaPuesto()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCategoriaPuesto ~ frmNuevoCategoriaPuesto()");
            }
        }

        public frmNuevoCategoriaPuesto(CategoriasPuesto Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosCategoriaPuesto = Datos;
                this.TipoForm = 2;
                this.CargarDatosAModificar(Datos);
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCategoriaPuesto ~ frmNuevoCategoriaPuesto(CategoriasPuesto Datos)");
            }
        }

        #endregion

     

        #region Métodos

        private void CargarDatosAModificar(CategoriasPuesto Datos)
        {
            try
            {
                this.txtDescripcion.Text = Datos.Descripcion;
                this.txtSueldoBase.Text = Convert.ToDecimal(Datos.SueldoBase).ToString();
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
      
        private CategoriasPuesto ObtenerDatos()
        {
            try
            {
                CategoriasPuesto DatosAux = new CategoriasPuesto();
                DatosAux.IDCategoria = TipoForm == 2 ? _DatosCategoriaPuesto.IDCategoria : string.Empty;
                DatosAux.Descripcion = this.txtDescripcion.Text.ToUpper().Trim();
                DatosAux.SueldoBase = Convert.ToDecimal(this.txtSueldoBase.Text.Trim());
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
                else
                    if(!Validar.IsValidDescripcion(this.txtDescripcion.Text))
                        Errores.Add(new Error { Numero = (aux += 1), Descripcion = "Ingrese una descripción válida.", ControlSender = this.txtDescripcion });
                if (string.IsNullOrEmpty(this.txtSueldoBase.Text.Trim()))
                    Errores.Add(new Error { Numero = (aux += 1), Descripcion = "Ingrese un sueldo válido.", ControlSender = this.txtSueldoBase });
                else
                    if (!Validar.IsValidDecimal(this.txtSueldoBase.Text))
                        Errores.Add(new Error { Numero = (aux += 1), Descripcion = "Ingrese un sueldo válido.", ControlSender = this.txtSueldoBase });
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
                LogError.AddExcFileTxt(ex, "frmNuevoCategoriaPuesto ~ btnCancelar_Click");
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
                    this._DatosCategoriaPuesto = this.ObtenerDatos();
                    this.DialogResult = DialogResult.OK;
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCategoriaPuesto ~ btnGuardar_Click");
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
                LogError.AddExcFileTxt(ex, "frmNuevoCategoriaPuesto ~ txtDescripcion_KeyPress");
            }
        }
        #endregion

        private void txtSueldoBase_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                this.txtSueldoBase.Text = string.Format("{0:F2}", this.ObtenerCalificacion());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCategoriaPuesto ~ txtSueldoBase_Validating");
            }
        }
        private decimal ObtenerCalificacion()
        {
            try
            {
                decimal Sueldo = 0;
                decimal.TryParse(this.txtSueldoBase.Text, out Sueldo);
                return Sueldo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
