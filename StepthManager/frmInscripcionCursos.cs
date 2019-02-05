using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using StephManager.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreativaSL.Dll.Validaciones;
using System.IO;

namespace StephManager
{
    public partial class frmInscripcionCursos : Form
    {
        private string IDCompra = string.Empty;
        #region Propiedades / Variables
        private int TipoForm = 0;
        private CapacitacionCurso _DatosCapacitacionCurso;
        public CapacitacionCurso DatosCapacitacionCurso
        {
            get { return _DatosCapacitacionCurso; }
            set { _DatosCapacitacionCurso = value; }
        }
        #endregion
        public frmInscripcionCursos(CapacitacionCurso Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosCapacitacionCurso = Datos;
                this.TipoForm = 2;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmComprasDetalle ~ frmComprasDetalle()");
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.LlenarComboCursos();
                this.LlenarComboIntructores();
                this.LlenarComboEmpleado();
                if (TipoForm == 2)
                    this.CargarDatosAModificar(_DatosCapacitacionCurso);

                this.ActiveControl = this.cmbEmpleados;
                this.cmbEmpleados.Focus();
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
                this.TipoForm = 1;
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

        private void LlenarComboEmpleado()
        {
            try
            {
                Usuario DatosAux = new Usuario { Conexion = Comun.Conexion, IncluirSelect = true };
                Empleado_Negocio PN = new Empleado_Negocio();
                this.cmbEmpleados.DataSource = PN.LlenarComboEmpleado(DatosAux);
                this.cmbEmpleados.DisplayMember = "Nombre";
                this.cmbEmpleados.ValueMember = "IDEmpleado";
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
                DatosAux.IDInscripcion = TipoForm == 2 ? this._DatosCapacitacionCurso.IDInscripcion : string.Empty;
                DatosAux.IDCapacitacion = this._DatosCapacitacionCurso.IDCapacitacion;
                Curso CursoAux = (Curso)this.cmbCursos.SelectedItem;
                DatosAux.IDCurso = CursoAux.IDCurso;
                Instructor IntructorAux = (Instructor)this.cmbInstructor.SelectedItem;
                DatosAux.IDInstructor = IntructorAux.IDInstructor;
                DatosAux.Lugar = this.txtLugarCurso.Text.Trim();
                DatosAux.FechaInicioCurso = this.dtpFechaInicioCurso.Value;
                DatosAux.FechaFinCurso = this.dtpFechaFinCurso.Value;
                Usuario EmpleadoAux = (Usuario)this.cmbEmpleados.SelectedItem;
                DatosAux.IDEmpleado = EmpleadoAux.IDEmpleado;
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

       
        private void frmComprasDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmComprasDetalle ~ frmComprasDetalle_Load");
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
                LogError.AddExcFileTxt(ex, "frmComprasDetalle ~ btnRegresar_Click");
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
                    cn.AbcInscripcionCurso(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosCapacitacionCurso = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("El empleado ya existe en el Curso", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private List<Error> ValidarDatos()
        {
            try
            {
                List<Error> Errores = new List<Error>();
                int Aux = 0;
                if (this.cmbEmpleados.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar un empleado de la lista.", ControlSender = this.cmbEmpleados });
                else
                {
                    Usuario EmpleadoAux = (Usuario)this.cmbEmpleados.SelectedItem;
                    if(string.IsNullOrEmpty(EmpleadoAux.IDEmpleado))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar un empleado de la lista.", ControlSender = this.cmbEmpleados });
                }
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
