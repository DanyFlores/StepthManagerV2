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
    public partial class frmNuevoCurso : Form
    {
        #region Propiedades / Variables
        private int TipoForm = 0;
        private Curso _DatosCursos;
        public Curso DatosCursos
        {
            get { return _DatosCursos; }
            set { _DatosCursos = value; }
        }

        private List<TemasCurso> ListaTemasCursos = new List<TemasCurso>();
        private List<TemasCurso> ListaTemaSeleccionado = new List<TemasCurso>();

        #endregion

        #region Constructor

        public frmNuevoCurso()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCurso ~ frmNuevoCurso()");
            }
        }

        public frmNuevoCurso(Curso Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosCursos = Datos;
                this.TipoForm = 2;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCurso ~ frmNuevoCurso(Curso Datos)");
            }
        }

        #endregion

        #region Métodos

        private void CargarDatosAModificar(Curso Datos)
        {
            try
            {
                this.txtNombreCurso.Text = Datos.Nombre;
                this.txtDescripcion.Text = Datos.Descripcion;
                this.txtObejetivoGeneral.Text = Datos.ObjetivoGeneral;
                this.txtCalicacionMinAprovatoria.Text = Convert.ToString(Datos.CalificacionMinAprobatoria);
                this.txtHoras.Text = Convert.ToString(Datos.Horas);
               
                TemasCurso temasCursos = new TemasCurso();
                temasCursos.Conexion = Comun.Conexion;
                temasCursos.IDTemaCurso = Datos.IDCurso;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                ListaTemaSeleccionado = cn.LlenarGridTemasxCursos(temasCursos);
                this.ObtenerListaTemas(this._DatosCursos.IDCurso);
                this.CargarGridTemas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridTemas()
        {
            try
            {
                BindingSource Datos = new BindingSource();
                Datos.DataSource = this.ListaTemaSeleccionado;
                this.dgvTemasCursos.AutoGenerateColumns = false;
                this.dgvTemasCursos.DataSource = Datos;

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
                    this.CargarDatosAModificar(_DatosCursos);
                
                this.ActiveControl = this.txtNombreCurso;
                this.txtNombreCurso.Focus();
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
                
                this.txtNombreCurso.Text = string.Empty;
                this.txtDescripcion.Text = string.Empty;
                this.txtObejetivoGeneral.Text = string.Empty;
                this.txtCalicacionMinAprovatoria.Text = string.Empty;
                this.txtHoras.Text = string.Empty;
                this.ObtenerListaTemas(string.Empty);
               // this.LlenarTablaTemasCursos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ObtenerListaTemas(string IDTemaCurso)
        {
            try
            {
                TemasCurso temaCursos = new TemasCurso { Conexion = Comun.Conexion, IDTemaCurso = IDTemaCurso};
                Catalogo_Negocio CN = new Catalogo_Negocio();
                this.ListaTemasCursos = CN.LlenarGridTemasCursos(temaCursos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarTablaTemasCursos()
        {
            try
            {
                this.dgvTemasCursos.DataSource = null;
                this.dgvTemasCursos.AutoGenerateColumns = false;
                this.dgvTemasCursos.DataSource = ListaTemaSeleccionado;
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

        private Curso ObtenerDatos()
        {
            try
            {
                Curso DatosAux = new Curso();
                DataTable TablaTema = new DataTable();
                //TablaSubTema.Columns.Add("IDTemaXCurso", typeof(string));
                //TablaSubTema.Columns.Add("IDCurso", typeof(string));
                TablaTema.Columns.Add("IDTema", typeof(string));
                foreach (TemasCurso Item in this.ListaTemaSeleccionado)
                {
                    TablaTema.Rows.Add(new object[] { Item.IDTemaCurso });
                }
                DatosAux.IDCurso = TipoForm == 2 ? this._DatosCursos.IDCurso : string.Empty;
              
                DatosAux.Nombre = this.txtNombreCurso.Text.Trim();
                DatosAux.Descripcion = this.txtDescripcion.Text.Trim();
                DatosAux.ObjetivoGeneral = this.txtObejetivoGeneral.Text.Trim();
                DatosAux.CalificacionMinAprobatoria = Convert.ToDecimal(this.txtCalicacionMinAprovatoria.Text.Trim());
                DatosAux.Horas = Convert.ToInt32(this.txtHoras.Text.Trim());
                DatosAux.TablaTema = TablaTema;
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
                if (string.IsNullOrEmpty(this.txtNombreCurso.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un nombre del curso.", ControlSender = this.txtNombreCurso });
                if (string.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar la descripción del curso.", ControlSender = this.txtDescripcion });
                if (string.IsNullOrEmpty(this.txtObejetivoGeneral.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar el Objetivo General.", ControlSender = this.txtObejetivoGeneral });
                if (string.IsNullOrEmpty(this.txtCalicacionMinAprovatoria.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un dato válido para <<Calificación Aprobatoria>>.", ControlSender = this.txtCalicacionMinAprovatoria });
                else
                {
                    if (!Validar.IsValidDecimal(this.txtCalicacionMinAprovatoria.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un dato válido para <<Calificación Aprobatoria>>.", ControlSender = this.txtCalicacionMinAprovatoria });
                }
                if (string.IsNullOrEmpty(this.txtHoras.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un dato válido para <<Hora>>.", ControlSender = this.txtHoras });
                else
                {
                    if (!Validar.IsValidOnlyNumber(this.txtHoras.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un dato válido para <<Hora>>.", ControlSender = this.txtHoras });
                }
                if(this.dgvTemasCursos.Rows.Count == 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe de seleccionar al menos un tema del curso", ControlSender = this.btnAgregarTemaCurso });
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
                LogError.AddExcFileTxt(ex, "frmNuevoCurso ~ btnCancelar_Click");
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
                    Curso Datos = this.ObtenerDatos();
                    Catalogo_Negocio CN = new Catalogo_Negocio();
                    CN.ABCCatCursos(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosCursos = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (Datos.Resultado > 0)
                        {
                            List<Error> LstError = new List<Error>();
                            LstError.Add(new Error { Numero = 1, Descripcion = Datos.MensajeError, ControlSender = this });
                            this.MostrarMensajeError(LstError);
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
                LogError.AddExcFileTxt(ex, "frmNuevoCurso ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCurso ~ frmNuevoUsuario_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarTemaCurso_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeleccionaTemaCurso SeleccionarTema = new frmSeleccionaTemaCurso();
                SeleccionarTema.DatosActuales = this.ListaTemasCursos;
                SeleccionarTema.ShowDialog();
                SeleccionarTema.Dispose();
                if (SeleccionarTema.DialogResult == DialogResult.OK)
                {
                    ListaTemaSeleccionado = SeleccionarTema.Seleccionado;
                    this.LlenarTablaTemasCursos();////Verficar mañana
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCurso ~ btnAgregarTemaCurso_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void txtCalicacionMinAprovatoria_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                this.txtCalicacionMinAprovatoria.Text = string.Format("{0:F2}", this.ObtenerCalificacion());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCurso ~ txtCalicacionMinAprovatoria_Validating");
            }
        }

        private decimal ObtenerCalificacion()
        {
            try
            {
                decimal Calificacion = 0;
                decimal.TryParse(this.txtCalicacionMinAprovatoria.Text, out Calificacion);
                return Calificacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
