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
    public partial class frmNuevoPuesto : Form
    {
        #region Propiedades / Variables
        private int TipoForm = 0;
        private Puestos _DatosPuesto;
        public Puestos DatosPuesto
        {
            get { return _DatosPuesto; }
            set { _DatosPuesto = value; }
        }

        private List<CategoriasPuesto> CategoriasPuestos = new List<CategoriasPuesto>();
        #endregion

        #region Constructor

        public frmNuevoPuesto()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
                //this.CargarCombos();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPuesto ~ frmNuevoPuesto()");
            }
        }

        public frmNuevoPuesto(Puestos Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosPuesto = Datos;
                this.TipoForm = 2;
               // this.CargarCombos();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPuesto ~ frmNuevoPuesto(Puestos Datos)");
            }
        }

        #endregion

        #region Métodos

        private void SeleccionarFilaSubTema(int Index)
        {
            try
            {
                this.dgvSubPuesto.Rows[Index].Selected = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridCategoriaPuesto()
        {
            try
            {
                BindingSource Datos = new BindingSource();
                Datos.DataSource = this.CategoriasPuestos;
                this.dgvSubPuesto.AutoGenerateColumns = false;
                this.dgvSubPuesto.DataSource = Datos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDatosAModificar(Puestos Datos)
        {
            try
            {
                this.txtNombrePuesto.Text = Datos.Descripcion;

                CategoriasPuesto categoriaPuesto = new CategoriasPuesto();
                categoriaPuesto.Conexion = Comun.Conexion;
                categoriaPuesto.IDPuesto = Convert.ToInt32(Datos.IDPuesto);
                Catalogo_Negocio cn = new Catalogo_Negocio();
                CategoriasPuestos = cn.LlenarGridCategoriaPuesto(categoriaPuesto);
                this.CargarGridCategoriaPuesto();
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
                    this.CargarDatosAModificar(_DatosPuesto);
                this.ActiveControl = this.txtNombrePuesto;
                this.txtNombrePuesto.Focus();
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
                this.txtNombrePuesto.Text = string.Empty;
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

        private CategoriasPuesto ObtenerDatosCategoria()
        {
            CategoriasPuesto DatosAux = new CategoriasPuesto();
            DataTable TablaCategoria = new DataTable();
            TablaCategoria.Columns.Add("IDCategoria", typeof(string));
            TablaCategoria.Columns.Add("IDPuesto", typeof(int));
            TablaCategoria.Columns.Add("Descripcion", typeof(string));
            TablaCategoria.Columns.Add("SueldoBase", typeof(decimal));
            foreach (CategoriasPuesto Item in this.CategoriasPuestos)
            {
                TablaCategoria.Rows.Add(new object[] { Item.IDCategoria, Item.IDPuesto, Item.Descripcion, Item.SueldoBase });
            }
            DatosAux.TablaCategoria = TablaCategoria;
            return DatosAux;
        }
        private Puestos ObtenerDatos()
        {
            try
            {
                Puestos DatosAux = new Puestos();
                DataTable TablaCategoria = new DataTable();
                TablaCategoria.Columns.Add("IDCategoria", typeof(string));
                TablaCategoria.Columns.Add("IDPuesto", typeof(int));
                TablaCategoria.Columns.Add("Descripcion", typeof(string));
                TablaCategoria.Columns.Add("SueldoBase", typeof(decimal));
                foreach (CategoriasPuesto Item in this.CategoriasPuestos)
                {
                    TablaCategoria.Rows.Add(new object[] { Item.IDCategoria, Item.IDPuesto, Item.Descripcion, Item.SueldoBase });
                }
                DatosAux.IDPuesto = TipoForm == 2 ? this._DatosPuesto.IDPuesto : 0;
                DatosAux.Descripcion = this.txtNombrePuesto.Text.Trim();
                DatosAux.TablaCategoriaPuesto = TablaCategoria;
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
                if (string.IsNullOrEmpty(this.txtNombrePuesto.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el Nombre del Tema.", ControlSender = this.txtNombrePuesto });
                else
                {
                    if (!Validar.IsValidDescripcion(this.txtNombrePuesto.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el Nombre del Tema válida.", ControlSender = this.txtNombrePuesto });
                }
                if (this.dgvSubPuesto.Rows.Count == 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Al menos tiene que tener un subpuesto.", ControlSender = this.dgvSubPuesto });
                
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
                    Puestos Datos = this.ObtenerDatos();
                    Catalogo_Negocio cn = new Catalogo_Negocio();
                    cn.ABCCatPuesto(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosPuesto = Datos;
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
                frmNuevoCategoriaPuesto NuevaCategoriaPuesto = new frmNuevoCategoriaPuesto();
                NuevaCategoriaPuesto.ShowDialog();
                NuevaCategoriaPuesto.Dispose();
                if (NuevaCategoriaPuesto.DialogResult == DialogResult.OK)
                {
                    CategoriasPuesto Aux = NuevaCategoriaPuesto.DatosCategoriaPuesto;
                    // Aux.ListaSubTema = new List<SubTemas>();
                    this.CategoriasPuestos.Add(Aux);
                    this.CargarGridCategoriaPuesto();
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
                if (this.dgvSubPuesto.SelectedRows.Count == 1)
                {
                    int RowToDelete = this.dgvSubPuesto.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    this.CategoriasPuestos.RemoveAt(RowToDelete);
                    this.CargarGridCategoriaPuesto();
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
                if (this.dgvSubPuesto.SelectedRows.Count == 1)
                {
                    int RowToMove = this.dgvSubPuesto.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowToMove > 0)
                    {

                        CategoriasPuesto Aux = CategoriasPuestos[RowToMove - 1];
                        CategoriasPuestos[RowToMove - 1] = CategoriasPuestos[RowToMove];
                        CategoriasPuestos[RowToMove] = Aux;

                        this.CargarGridCategoriaPuesto();
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
                if (this.dgvSubPuesto.SelectedRows.Count == 1)
                {
                    int RowToMove = this.dgvSubPuesto.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowToMove < this.dgvSubPuesto.Rows.Count - 1)
                    {
                        List<CategoriasPuesto> PreguntasAux = this.CategoriasPuestos;
                        CategoriasPuesto Aux = PreguntasAux[RowToMove + 1];
                        PreguntasAux[RowToMove + 1] = PreguntasAux[RowToMove];
                        PreguntasAux[RowToMove] = Aux;
                        this.CategoriasPuestos = PreguntasAux;
                        this.CargarGridCategoriaPuesto();
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
