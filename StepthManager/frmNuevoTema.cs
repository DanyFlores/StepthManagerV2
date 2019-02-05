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
    public partial class frmNuevoTema : Form
    {
        #region Propiedades / Variables
        private int TipoForm = 0;
        private TemasCurso _DatosTemasCurso;
        public TemasCurso DatosTemasCurso
        {
            get { return _DatosTemasCurso; }
            set { _DatosTemasCurso = value; }
        }

        private List<SubTemas> SubTemas = new List<SubTemas>();
        #endregion

        #region Constructor

        public frmNuevoTema()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
                //this.CargarCombos();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTema ~ frmNuevoTema()");
            }
        }

        public frmNuevoTema(TemasCurso Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosTemasCurso = Datos;
                this.TipoForm = 2;
               // this.CargarCombos();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTema ~ frmNuevoTema(TemasCurso Datos)");
            }
        }

        #endregion


        #region Métodos

        private void SeleccionarFilaSubTema(int Index)
        {
            try
            {
                this.dgvSubTemas.Rows[Index].Selected = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridSubTemas()
        {
            try
            {
                BindingSource Datos = new BindingSource();
                Datos.DataSource = this.SubTemas;
                this.dgvSubTemas.AutoGenerateColumns = false;
                this.dgvSubTemas.DataSource = Datos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDatosAModificar(TemasCurso Datos)
        {
            try
            {
                this.txtNombreTema.Text = Datos.Descripcion;

                SubTemas SubTemass = new SubTemas();
                SubTemass.Conexion = Comun.Conexion;
                SubTemass.IDTemaCurso = Datos.IDTemaCurso;
                Catalogo_Negocio cn = new Catalogo_Negocio();
                SubTemas = cn.LlenarGridSubTemas(SubTemass);
                this.CargarGridSubTemas();
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
                    this.CargarDatosAModificar(_DatosTemasCurso);
                this.ActiveControl = this.txtNombreTema;
                this.txtNombreTema.Focus();
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
                this.txtNombreTema.Text = string.Empty;
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

        private TemasCurso ObtenerDatos()
        {
            try
            {
                TemasCurso DatosAux = new TemasCurso();
                DataTable TablaSubTema = new DataTable();
                TablaSubTema.Columns.Add("IDSubTema", typeof(string));
                TablaSubTema.Columns.Add("IDServicio", typeof(string));
                TablaSubTema.Columns.Add("Descripcion", typeof(string));
                TablaSubTema.Columns.Add("PracticasSugerida", typeof(int));
                foreach (SubTemas Item in this.SubTemas)
                {
                    TablaSubTema.Rows.Add(new object[] { Item.IDSubTemas, Item.IDServicio, Item.Descripcion, Item.PracticasSugeridas });
                }
                DatosAux.IDTemaCurso = TipoForm == 2 ? this._DatosTemasCurso.IDTemaCurso : string.Empty;
                DatosAux.Descripcion = this.txtNombreTema.Text.Trim();
                DatosAux.TablaSubTemas = TablaSubTema;
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
                if (string.IsNullOrEmpty(this.txtNombreTema.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el Nombre del Tema.", ControlSender = this.txtNombreTema });
                else
                {
                    if (!Validar.IsValidDescripcion(this.txtNombreTema.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el Nombre del Tema válida.", ControlSender = this.txtNombreTema });
                }
                if(this.dgvSubTemas.Rows.Count == 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe de ingresar al menos un subtema para el tema", ControlSender = this.btnAgregarSubTema });
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
                LogError.AddExcFileTxt(ex, "frmNuevoTema ~ btnCancelar_Click");
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
                    TemasCurso Datos = this.ObtenerDatos();
                    Catalogo_Negocio cn = new Catalogo_Negocio();
                    cn.ABCCatTemasCursos(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosTemasCurso = Datos;
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
                LogError.AddExcFileTxt(ex, "frmNuevoTema ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoTema_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTema ~ frmNuevoTema_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnAgregarSubTema_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoSubTema frmSubTema = new frmNuevoSubTema();
                frmSubTema.ShowDialog();
                frmSubTema.Dispose();
                if (frmSubTema.DialogResult == DialogResult.OK)
                {
                    SubTemas Aux = frmSubTema.DatosSubTemas;
                   // Aux.ListaSubTema = new List<SubTemas>();
                    this.SubTemas.Add(Aux);
                    this.CargarGridSubTemas();
                    //this.SeleccionarFilaPreguntas(this.dgvPreguntas.Rows.Count - 1);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTema ~ btnAgregarSubTema_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnbEliminarSubTema_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvSubTemas.SelectedRows.Count == 1)
                {
                    int RowToDelete = this.dgvSubTemas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    this.SubTemas.RemoveAt(RowToDelete);
                    this.CargarGridSubTemas();
                }
                else
                    MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTema ~ btnbEliminarSubTema_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubirSubTema_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvSubTemas.SelectedRows.Count == 1)
                {
                    int RowToMove = this.dgvSubTemas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowToMove > 0)
                    {

                        SubTemas Aux = SubTemas[RowToMove - 1];
                        SubTemas[RowToMove - 1] = SubTemas[RowToMove];
                        SubTemas[RowToMove] = Aux;

                        this.CargarGridSubTemas();
                        this.SeleccionarFilaSubTema(RowToMove - 1);

                    }
                }
                else
                    MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTema ~ btnSubirSubTema_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBajarSubTema_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvSubTemas.SelectedRows.Count == 1)
                {
                    int RowToMove = this.dgvSubTemas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowToMove < this.dgvSubTemas.Rows.Count - 1)
                    {
                        List<SubTemas> PreguntasAux = this.SubTemas;
                        SubTemas Aux = PreguntasAux[RowToMove + 1];
                        PreguntasAux[RowToMove + 1] = PreguntasAux[RowToMove];
                        PreguntasAux[RowToMove] = Aux;
                        this.SubTemas = PreguntasAux;
                        this.CargarGridSubTemas();
                        this.SeleccionarFilaSubTema(RowToMove + 1);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTema ~ btnBajarSubTema_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
