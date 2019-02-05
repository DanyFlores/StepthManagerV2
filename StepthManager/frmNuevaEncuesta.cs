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
using System.Globalization;
using System.IO;

namespace StephManager
{
    public partial class frmNuevaEncuesta : Form
    {
        #region Propiedades / Variables

        private Encuesta _DatosEncuesta;
        public Encuesta DatosEncuesta
        {
            get { return _DatosEncuesta; }
            set { _DatosEncuesta = value; }
        }
        private List<Pregunta> PreguntasEncuesta = new List<Pregunta>();
        private bool NuevoRegistro = true;

        #endregion

        #region Constructor

        public frmNuevaEncuesta()
        {
            try
            {
                InitializeComponent();
                NuevoRegistro = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaEncuesta ~ frmNuevaEncuesta()");
            }
        }

        public frmNuevaEncuesta(Encuesta Aux)
        {
            try
            {
                InitializeComponent();
                NuevoRegistro = false;
                this._DatosEncuesta = Aux;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaEncuesta ~ frmNuevaEncuesta(Encuesta Aux)");
            }
        }

        #endregion

        #region Métodos

        private void CargarGridPreguntas()
        {
            try
            {
                BindingSource Datos = new BindingSource();
                Datos.DataSource = this.PreguntasEncuesta;
                this.dgvPreguntas.AutoGenerateColumns = false;
                this.dgvPreguntas.DataSource = Datos;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridRespuestas(List<Respuesta> Respuestas)
        {
            try
            {
                BindingSource Source = new BindingSource();
                Source.DataSource = Respuestas;
                this.dgvRespuestas.AutoGenerateColumns = false;
                this.dgvRespuestas.DataSource = Source;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDatosAModificar(Encuesta DatosAux)
        {
            try
            {
                this.txtTitulo.Text = DatosAux.Titulo;
                if (this.cmbTipoEncuesta.Items.Count > 0)
                    this.cmbTipoEncuesta.SelectedValue = DatosAux.IDTipoEncuesta;
                if (DatosAux.RequierePeriodo)
                {
                    this.dtpFechaInicio.Value = DatosAux.FechaInicio;
                    this.dtpFechaTermino.Value = DatosAux.FechaFin;
                    this.txtIncentivo.Text = string.Format("{0:c}", DatosAux.Incentivo);
                }
                this.PreguntasEncuesta = DatosAux.ListaPreguntas;
                this.CargarGridPreguntas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Encuesta ObtenerDatosEncuesta()
        {
            try
            {
                Encuesta DatosAux = new Encuesta();
                DataTable TablaPreguntas = new DataTable();
                TablaPreguntas.Columns.Add("IDPregunta", typeof(string));
                TablaPreguntas.Columns.Add("Orden", typeof(int));
                TablaPreguntas.Columns.Add("Descripcion", typeof(string));
                TablaPreguntas.Columns.Add("IDTipoPregunta", typeof(int));
                TablaPreguntas.Columns.Add("EsRequerida", typeof(bool));
                DataTable TablaRespuestas = new DataTable();
                TablaRespuestas.Columns.Add("IDRespuesta", typeof(string));
                TablaRespuestas.Columns.Add("OrdenPregunta", typeof(int));
                TablaRespuestas.Columns.Add("OrdenRespuesta", typeof(int));
                TablaRespuestas.Columns.Add("Descripcion", typeof(string));

                int OrdenPregunta = 0;
                foreach (Pregunta Item in this.PreguntasEncuesta)
                {
                    OrdenPregunta += 1;
                    TablaPreguntas.Rows.Add(new object[]{ Item.IDPregunta, OrdenPregunta, Item.Titulo, Item.IDTipoPregunta, Item.EsRequerida });
                    int OrdenRespuesta = 0;
                    foreach (Respuesta ItemRespuesta in Item.ListaRespuestas)
                    {
                        OrdenRespuesta += 1;
                        TablaRespuestas.Rows.Add(new object[] { ItemRespuesta.IDRespuesta, OrdenPregunta, OrdenRespuesta, ItemRespuesta.Titulo });
                    }
                }

                TipoEncuesta TEAux = new TipoEncuesta();
                if (this.cmbTipoEncuesta.SelectedIndex != -1)
                    TEAux = (TipoEncuesta)this.cmbTipoEncuesta.SelectedItem;

                decimal Incentivo = 0;
                decimal.TryParse(this.txtIncentivo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Incentivo);

                DatosAux.IDEncuesta = NuevoRegistro ? string.Empty : this._DatosEncuesta.IDEncuesta;
                DatosAux.NuevoRegistro = NuevoRegistro;
                DatosAux.Titulo = this.txtTitulo.Text.Trim();                
                DatosAux.IDTipoEncuesta = TEAux.IDTipoEncuesta;
                DatosAux.TipoEncuestaDesc = TEAux.Descripcion;
                DatosAux.RequierePeriodo = TEAux.RequierePeriodo;
                DatosAux.FechaInicio = this.dtpFechaInicio.Value;
                DatosAux.FechaFin = this.dtpFechaTermino.Value;
                DatosAux.Incentivo = Incentivo;
                DatosAux.TablaPreguntas = TablaPreguntas;
                DatosAux.TablaRespuestas = TablaRespuestas;
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                return DatosAux;
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
                this.LLenarComboTipoEncuesta();
                if (NuevoRegistro)
                    this.IniciarDatos();
                else
                    this.CargarDatosAModificar(this._DatosEncuesta);
                this.ActiveControl = this.txtTitulo;
                this.txtTitulo.Focus();
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

        private void IniciarDatos()
        {
            try
            {
                this.txtTitulo.Text = string.Empty;
                this.dtpFechaInicio.Value = DateTime.Today;
                this.dtpFechaTermino.Value = DateTime.Today;
                this.txtIncentivo.Text = string.Format("{0:c}", 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LLenarComboTipoEncuesta()
        {
            try
            {
                TipoEncuesta TEAux = new TipoEncuesta { Conexion = Comun.Conexion, IncluirSelect =true };
                Encuesta_Negocio EN = new Encuesta_Negocio();
                this.cmbTipoEncuesta.DataSource = EN.LlenarComboTipoEncuesta(TEAux);
                this.cmbTipoEncuesta.DisplayMember = "Descripcion";
                this.cmbTipoEncuesta.ValueMember = "IDTipoEncuesta";
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
                string CadenaErrores = string.Empty;
                CadenaErrores = "No se pudo guardar la información. Se presentaron los siguientes errores: \r\n";
                foreach (Error item in Errores)
                {
                    CadenaErrores += item.Numero + "\t" + item.Descripcion + "\r\n";
                }
                this.txtMensajeError.Visible = true;
                this.txtMensajeError.Text = CadenaErrores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Pregunta ObtenerPreguntaSeleccionada()
        {
            try
            {
                Pregunta Aux = new Pregunta();
                if (this.dgvPreguntas.SelectedRows.Count == 1)
                {
                    int RowSelected = this.dgvPreguntas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Aux = PreguntasEncuesta[RowSelected];
                }
                return Aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SeleccionarFilaPreguntas(int Index)
        {
            try
            {
                this.dgvPreguntas.Rows[Index].Selected = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SeleccionarFilaRespuestas(int Index)
        {
            try
            {
                this.dgvRespuestas.Rows[Index].Selected = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Error> ValidarDatosEncuesta()
        {
            try
            {
                List<Error> ListaErrores = new List<Error>();
                int Aux = 0;
                if (string.IsNullOrEmpty(this.txtTitulo.Text.Trim()))
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar el título de la encuesta.", ControlSender = this.txtTitulo });
                if (this.cmbTipoEncuesta.SelectedIndex == -1)
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un tipo de encuesta.", ControlSender = this.cmbTipoEncuesta });
                else
                {
                    TipoEncuesta Seleccionada = (TipoEncuesta)this.cmbTipoEncuesta.SelectedItem;
                    if (Seleccionada.IDTipoEncuesta == 0)
                        ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un tipo de encuesta.", ControlSender = this.cmbTipoEncuesta });
                    else
                    {
                        if (Seleccionada.RequierePeriodo)
                        {
                            DateTime FechaInicio = this.dtpFechaInicio.Value;
                            DateTime FechaTermino = this.dtpFechaTermino.Value;
                            if (FechaTermino < FechaInicio)
                                ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "La fecha de término debe ser mayor a la fecha de inicio.", ControlSender = this.dtpFechaTermino });
                        }
                    }
                }
                decimal Incentivo = 0;
                decimal.TryParse(this.txtIncentivo.Text.Trim(), NumberStyles.Currency, CultureInfo.CurrentCulture, out Incentivo);
                if (Incentivo < 0)
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "El incentivo debe ser mayor o igual a 0.", ControlSender = this.txtIncentivo });
                //Validar que las preguntas tengan respuestas y que las respuestas no sean vacías
                if(this.PreguntasEncuesta.Count == 0)
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "No hay preguntas para la encuesta.", ControlSender = this.txtIncentivo });
                foreach (Pregunta ItemPregunta in PreguntasEncuesta)
                {
                    if (ItemPregunta.RequiereRespuestas)
                    {
                        if (ItemPregunta.ListaRespuestas.Count <= 0)
                            ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Faltan respuestas para la pregunta : " + ItemPregunta.Titulo, ControlSender = this.dgvPreguntas });
                        else
                        {
                            int Cont = 0;
                            foreach (Respuesta ItemRespuesta in ItemPregunta.ListaRespuestas)
                            {
                                if (ItemRespuesta.Titulo.Trim() == string.Empty)
                                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "La respuesta " + (Cont += 1) + " no puede estar vacía.", ControlSender = this.dgvRespuestas });
                            }
                        }
                    }
                }
                return ListaErrores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnAgregarPregunta_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevaPregunta frmPregunta = new frmNuevaPregunta();
                frmPregunta.ShowDialog();
                frmPregunta.Dispose();
                if (frmPregunta.DialogResult == DialogResult.OK)
                {
                    Pregunta Aux = frmPregunta.DatosPregunta;
                    Aux.ListaRespuestas = new List<Respuesta>();
                    this.PreguntasEncuesta.Add(Aux);
                    this.CargarGridPreguntas();
                    this.SeleccionarFilaPreguntas(this.dgvPreguntas.Rows.Count - 1);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaEncuesta ~ btnAgregarPregunta_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarRespuesta_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPreguntas.SelectedRows.Count == 1)
                {
                    Pregunta DatosAux = this.ObtenerPreguntaSeleccionada();
                    if (DatosAux.RequiereRespuestas)
                    {
                        int RowSelected = this.dgvPreguntas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                        this.PreguntasEncuesta[RowSelected].ListaRespuestas.Add(new Respuesta { IDRespuesta = string.Empty, Titulo = string.Empty });
                        this.CargarGridRespuestas(this.PreguntasEncuesta[RowSelected].ListaRespuestas);
                        this.SeleccionarFilaRespuestas(this.dgvRespuestas.Rows.Count - 1);
                    }
                }
                else
                    MessageBox.Show("Seleccione una pregunta", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaEncuesta ~ btnAgregarRespuesta_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBajarPregunta_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPreguntas.SelectedRows.Count == 1)
                {
                    int RowToMove = this.dgvPreguntas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowToMove < this.dgvPreguntas.Rows.Count - 1)
                    {
                        List<Pregunta> PreguntasAux = this.PreguntasEncuesta;
                        Pregunta Aux = PreguntasAux[RowToMove + 1];
                        PreguntasAux[RowToMove + 1] = PreguntasAux[RowToMove];
                        PreguntasAux[RowToMove] = Aux;
                        this.PreguntasEncuesta = PreguntasAux;
                        this.CargarGridPreguntas();
                        this.SeleccionarFilaPreguntas(RowToMove + 1);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaEncuesta ~ btnBajarPregunta_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBajarRespuesta_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvRespuestas.Rows.Count > 0)
                {
                    if (this.dgvPreguntas.SelectedRows.Count == 1)
                    {
                        int RowToMove = this.dgvRespuestas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                        if (RowToMove < this.dgvRespuestas.Rows.Count - 1)
                        {
                            int RowSelected = this.dgvPreguntas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                            List<Respuesta> ListaAux = PreguntasEncuesta[RowSelected].ListaRespuestas;
                            Respuesta Aux = ListaAux[RowToMove + 1];
                            ListaAux[RowToMove + 1] = ListaAux[RowToMove];
                            ListaAux[RowToMove] = Aux;
                            this.PreguntasEncuesta[RowSelected].ListaRespuestas = ListaAux;
                            this.CargarGridRespuestas(this.PreguntasEncuesta[RowSelected].ListaRespuestas);
                            this.SeleccionarFilaRespuestas(RowToMove + 1);

                        }
                    }
                    else
                        MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaEncuesta ~ btnSubirRespuesta_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaEncuesta ~ btnCancelar_Click");
            }
        }

        private void btnbEliminarPregunta_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPreguntas.SelectedRows.Count == 1)
                {
                    int RowToDelete = this.dgvPreguntas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    this.PreguntasEncuesta.RemoveAt(RowToDelete);
                    this.CargarGridPreguntas();
                }
                else
                    MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaEncuesta ~ btnAgregarPregunta_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarRespuesta_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPreguntas.SelectedRows.Count == 1)
                {
                    int RowPSelected = this.dgvPreguntas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (this.dgvRespuestas.SelectedRows.Count == 1)
                    {
                        int RowSelected = this.dgvRespuestas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                        this.PreguntasEncuesta[RowPSelected].ListaRespuestas.RemoveAt(RowSelected);
                        this.CargarGridRespuestas(this.PreguntasEncuesta[RowPSelected].ListaRespuestas);
                    }
                    else
                        MessageBox.Show("Seleccione la respuesta a eliminar.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaEncuesta ~ btnEliminarRespuesta_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Error> ListaErrores = this.ValidarDatosEncuesta();
                if (ListaErrores.Count == 0)
                {
                    Encuesta Datos = this.ObtenerDatosEncuesta();
                    Encuesta_Negocio EN = new Encuesta_Negocio();
                    EN.ACEncuestas(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosEncuesta = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                    this.MostrarMensajeError(ListaErrores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaEncuesta ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubirPregunta_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPreguntas.SelectedRows.Count == 1)
                {
                    int RowToMove = this.dgvPreguntas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowToMove > 0)
                    {

                        Pregunta Aux = PreguntasEncuesta[RowToMove - 1];
                        PreguntasEncuesta[RowToMove - 1] = PreguntasEncuesta[RowToMove];
                        PreguntasEncuesta[RowToMove] = Aux;

                        this.CargarGridPreguntas();
                        this.SeleccionarFilaPreguntas(RowToMove - 1);

                    }
                }
                else
                    MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaEncuesta ~ btnSubirPregunta_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubirRespuesta_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvRespuestas.Rows.Count > 0)
                {
                    if (this.dgvPreguntas.SelectedRows.Count == 1)
                    {
                        int RowToMove = this.dgvRespuestas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                        if (RowToMove > 0)
                        {
                            int RowSelected = this.dgvPreguntas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                            List<Respuesta> ListaAux = PreguntasEncuesta[RowSelected].ListaRespuestas;
                            Respuesta Aux = ListaAux[RowToMove - 1];
                            ListaAux[RowToMove - 1] = ListaAux[RowToMove];
                            ListaAux[RowToMove] = Aux;
                            this.PreguntasEncuesta[RowSelected].ListaRespuestas = ListaAux;
                            this.CargarGridRespuestas(this.PreguntasEncuesta[RowSelected].ListaRespuestas);
                            this.SeleccionarFilaRespuestas(RowToMove - 1);

                        }
                    }
                    else
                        MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaEncuesta ~ btnSubirRespuesta_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTipoEncuesta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbTipoEncuesta.SelectedIndex != -1)
                {
                    TipoEncuesta Seleccionada = (TipoEncuesta)this.cmbTipoEncuesta.SelectedItem;
                    if (Seleccionada.RequierePeriodo)
                    {
                        this.dtpFechaInicio.Enabled = true;
                        this.dtpFechaTermino.Enabled = true;
                        this.txtIncentivo.Enabled = true;
                    }
                    else
                    {
                        this.dtpFechaInicio.Enabled = false;
                        this.dtpFechaTermino.Enabled = false;
                        this.txtIncentivo.Enabled = false;
                    }
                    this.dtpFechaInicio.Value = DateTime.Today;
                    this.dtpFechaTermino.Value = DateTime.Today;
                    this.txtIncentivo.Text = string.Format("{0:c}", 0);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaEncuesta ~ cmbTipoEncuesta_SelectedIndexChanged");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPreguntas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPreguntas.SelectedRows.Count == 1)
                {
                    int RowSelected = this.dgvPreguntas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    this.CargarGridRespuestas(this.PreguntasEncuesta[RowSelected].ListaRespuestas);
                }
                else
                {
                    this.CargarGridRespuestas(new List<Respuesta>());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaEncuesta ~ dgvPreguntas_SelectionChanged");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevaEncuesta_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaEncuesta ~ frmNuevaEncuesta_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtIncentivo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                decimal Incentivo = 0;
                decimal.TryParse(this.txtIncentivo.Text.Trim(), NumberStyles.Currency, CultureInfo.CurrentCulture, out Incentivo);
                txtIncentivo.Text = string.Format("{0:c}", Incentivo);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaEncuesta ~ txtIncentivo_Validating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
