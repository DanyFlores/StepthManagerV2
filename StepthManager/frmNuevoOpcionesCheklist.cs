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
    public partial class frmNuevoOpcionesCheklist : Form
    {

        #region Propiedades / Variables
        private int TipoForm = 0;
        private ActividadOpcionesCheckList _DatosActividadOp;
        public ActividadOpcionesCheckList DatosActividadOp
        {
            get { return _DatosActividadOp; }
            set { _DatosActividadOp = value; }
        }
        public string IDCheckList { get; set; }
        #endregion

        #region Constructor

        public frmNuevoOpcionesCheklist(string IDCheckList)
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
                this.IDCheckList = IDCheckList;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoOpcionesCheklist ~ frmNuevoOpcionesCheklist()");
            }
        }

        public frmNuevoOpcionesCheklist(ActividadOpcionesCheckList Datos, string ID)
        {
            try
            {
                InitializeComponent();
                this._DatosActividadOp = Datos;
                this.IDCheckList = ID;
                this.TipoForm = 2;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoOpcionesCheklist ~ frmNuevoOpcionesCheklist(ActividadOpcionesCheckList Datos)");
            }
        }

        #endregion

        #region Métodos


        private void CargarDatosAModificar(ActividadOpcionesCheckList Datos)
        {
            try
            {
                this.txtDescripcion.Text = Datos.Descripcion;
                this.txtValor.Text = Convert.ToString(Datos.Valor);
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
                    this.CargarDatosAModificar(_DatosActividadOp);
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

        private ActividadOpcionesCheckList ObtenerDatos()
        {
            try
            {
                ActividadOpcionesCheckList DatosAux = new ActividadOpcionesCheckList();
                DatosAux.IDActividadOpciones = TipoForm == 2 ? this._DatosActividadOp.IDActividadOpciones : 0;
                DatosAux.Descripcion = this.txtDescripcion.Text.Trim();
                DatosAux.Opcion = this.TipoForm;
                DatosAux.Valor = Convert.ToInt32(this.txtValor.Text.Trim());
                DatosAux.IDCheckList = this.IDCheckList;
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
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese una opción", ControlSender = this.txtDescripcion });
                if(string.IsNullOrEmpty(this.txtValor.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un valor", ControlSender = this.txtValor });
                else
                {
                    if (!Validar.IsValidOnlyNumber(this.txtValor.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un número de valor válido.", ControlSender = this.txtValor });
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
                LogError.AddExcFileTxt(ex, "frmNuevoOpcionesCheklist ~ btnCancelar_Click");
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
                    ActividadOpcionesCheckList Datos = this.ObtenerDatos();
                    ActividadOpcionesCheckList_Negocio AOCN = new ActividadOpcionesCheckList_Negocio();
                    AOCN.ABCActividadOpcinesChecKList(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosActividadOp = Datos;
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
                LogError.AddExcFileTxt(ex, "frmNuevoOpcionesCheklist ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoOpcionesCheklist_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoOpcionesCheklist ~ frmNuevoOpcionesCheklist_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
