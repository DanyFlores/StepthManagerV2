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
    public partial class frmNuevoCategoriaCheklist : Form
    {

        #region Propiedades / Variables
        private int TipoForm = 0;
        private CategoriaCheckList _DatosCategoria;
        public CategoriaCheckList DatosCategoria
        {
            get { return _DatosCategoria; }
            set { _DatosCategoria = value; }
        }        
        #endregion

        #region Constructor

        public frmNuevoCategoriaCheklist()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCategoriaCheklist ~ frmNuevoCategoriaCheklist()");
            }
        }

        public frmNuevoCategoriaCheklist(CategoriaCheckList Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosCategoria = Datos;
                this.TipoForm = 2;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCategoriaCheklist ~ frmNuevoCategoriaCheklist(CategoriaCheckList Datos)");
            }
        }

        #endregion

        #region Métodos


        private void CargarDatosAModificar(CategoriaCheckList Datos)
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
                
                if(TipoForm == 2)
                    this.CargarDatosAModificar(_DatosCategoria);
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

        private CategoriaCheckList ObtenerDatos()
        {
            try
            {
                CategoriaCheckList DatosAux = new CategoriaCheckList();
                DatosAux.IDCategoriaChe = TipoForm == 2 ? this._DatosCategoria.IDCategoriaChe : 0;
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
                int Aux = 0;
                if (string.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la categoria de la actividad", ControlSender = this.txtDescripcion });
                else
                {
                    if (!Validar.IsValidDescripcion(this.txtDescripcion.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la categoria de la actividad válido.", ControlSender = this.txtDescripcion });
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCategoriaCheklist ~ btnCancelar_Click");
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
                    CategoriaCheckList Datos = this.ObtenerDatos();
                    Catalogo_Negocio cn = new Catalogo_Negocio();
                    cn.ABCCategoriaActividades(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosCategoria = Datos;
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
                LogError.AddExcFileTxt(ex, "frmNuevoCategoriaCheklist ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoCategoriaCheklist_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCategoriaCheklist ~ frmNuevoCategoriaCheklist_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
