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
    public partial class frmNuevoCapacitacionCurso : Form
    {
        #region Propiedades / Variables
        private int TipoForm = 0;
        private CapacitacionCurso _DatosCapacitacionCurso;
        public CapacitacionCurso DatosCapacitacionCurso
        {
            get { return _DatosCapacitacionCurso; }
            set { _DatosCapacitacionCurso = value; }
        }        
        #endregion

        #region Constructor

        public frmNuevoCapacitacionCurso()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProveedor ~ frmNuevoProveedor()");
            }
        }

        public frmNuevoCapacitacionCurso(CapacitacionCurso Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosCapacitacionCurso = Datos;
                this.TipoForm = 2;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProveedor ~ frmNuevoProveedor(Proveedor Datos)");
            }
        }

        #endregion

        #region Métodos


        private void CargarDatosAModificar(CapacitacionCurso Datos)
        {
            try
            {
                this.txtLugarCurso.Text = Datos.Lugar;
                this.dtpFechaInicioCurso.Value = Datos.FechaInicioCurso;
                this.dtpFechaFinCurso.Value = Datos.FechaFinCurso;
                if (ExisteItemEnComboCurso(Datos.IDCurso))
                    this.cmbCursos.SelectedValue = Datos.IDCurso;
                if (ExisteItemEnComboInstructor(Datos.IDInstructor))
                    this.cmbInstructor.SelectedValue = Datos.IDInstructor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private bool ExisteItemEnComboCurso(string IDCurso)
        {
            try
            {
                bool Band = false;
                foreach (Curso Item in this.cmbCursos.Items)
                {
                    if (Item.IDCurso == IDCurso)
                    {
                        Band = true;
                        break;
                    }
                }
                return Band;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExisteItemEnComboInstructor(string IDInstructor)
        {
            try
            {
                bool Band = false;
                foreach (Instructor Item in this.cmbInstructor.Items)
                {
                    if (Item.IDInstructor == IDInstructor)
                    {
                        Band = true;
                        break;
                    }
                }
                return Band;
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
                this.LlenarComboCursos();
                this.LlenarComboIntructores();
                if(TipoForm == 2)
                    this.CargarDatosAModificar(_DatosCapacitacionCurso);
                this.ActiveControl = this.txtLugarCurso;
                this.txtLugarCurso.Focus();
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

        private void LlenarComboCursos()
        {
            try
            {
                Curso DatosAux = new Curso { Conexion = Comun.Conexion, IncluirSelect = true };
                Cursos_Negocio PN = new Cursos_Negocio();
                this.cmbCursos.DataSource = PN.LlenarComboCursos(DatosAux);
                this.cmbCursos.DisplayMember = "Nombre";
                this.cmbCursos.ValueMember = "IDCurso";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LlenarComboIntructores()
        {
            try
            {
                Instructor DatosAux = new Instructor { Conexion = Comun.Conexion, IncluirSelect = true };
                Instructores_Negocio PN = new Instructores_Negocio();
                this.cmbInstructor.DataSource = PN.LlenarComboInstructores(DatosAux);
                this.cmbInstructor.DisplayMember = "Nombre";
                this.cmbInstructor.ValueMember = "IDInstructor";
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

        private CapacitacionCurso ObtenerDatos()
        {
            try
            {
                CapacitacionCurso DatosAux = new CapacitacionCurso();
                DatosAux.IDCapacitacion = TipoForm == 2 ? this._DatosCapacitacionCurso.IDCapacitacion : string.Empty;
                Curso CursoAux = (Curso)this.cmbCursos.SelectedItem;
                DatosAux.IDCurso = CursoAux.IDCurso;
                Instructor IntructorAux = (Instructor)this.cmbInstructor.SelectedItem;
                DatosAux.IDInstructor = IntructorAux.IDInstructor;
                DatosAux.Lugar = this.txtLugarCurso.Text.Trim();
                DatosAux.FechaInicioCurso = this.dtpFechaInicioCurso.Value;
                DatosAux.FechaFinCurso = this.dtpFechaFinCurso.Value;
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
                if (string.IsNullOrEmpty(this.txtLugarCurso.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el lugar de la capacitación del curso.", ControlSender = this.txtLugarCurso });
                else
                {
                    if (!Validar.IsValidDescripcion(this.txtLugarCurso.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el lugar de la capacitación del curso válido.", ControlSender = this.txtLugarCurso });
                }
                if (this.cmbCursos.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un curso", ControlSender = this.cmbCursos });
                else
                {
                    Curso CursoAux = (Curso)this.cmbCursos.SelectedItem;
                    if (string.IsNullOrEmpty(CursoAux.IDCurso))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un curso.", ControlSender = this.cmbCursos });
                }
                if (this.cmbInstructor.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un instructor del curso", ControlSender = this.cmbInstructor });
                else
                {
                    Instructor IntructorAux = (Instructor)this.cmbInstructor.SelectedItem;
                    if (string.IsNullOrEmpty(IntructorAux.IDInstructor))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un instructor del curso.", ControlSender = this.cmbInstructor });
                }
                if (this.dtpFechaInicioCurso.Value < DateTime.Today)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La fecha tiene que ser mayor o igual a la fecha actual", ControlSender = this.dtpFechaInicioCurso });
                if (this.dtpFechaInicioCurso.Value > this.dtpFechaFinCurso.Value)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La fecha tiene que ser mayor a la actual", ControlSender = this.dtpFechaFinCurso });
              
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
                LogError.AddExcFileTxt(ex, "frmNuevoProveedor ~ btnCancelar_Click");
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
                    CapacitacionCurso Datos = this.ObtenerDatos();
                    CapacitacionCurso_Negocio cn = new CapacitacionCurso_Negocio();
                    cn.AbcCapacitacionCurso(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosCapacitacionCurso = Datos;
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
                LogError.AddExcFileTxt(ex, "frmNuevoProveedor ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProveedor ~ frmNuevoProveedor_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
       
        #endregion

    }
}
