using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using StephManager.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephManager
{
    public partial class frmCapacitacionCursoEvaluar : Form
    {
       
        #region Propiedades / Variables
        private int TipoForm = 0;
        private CapacitacionCurso _DatosCapacitacionCurso;
        public CapacitacionCurso DatosCapacitacionCurso
        {
            get { return _DatosCapacitacionCurso; }
            set { _DatosCapacitacionCurso = value; }
        }
        private string IDCursos = string.Empty;
        #endregion

        public frmCapacitacionCursoEvaluar(CapacitacionCurso Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosCapacitacionCurso = Datos;
                if (Datos.IDStatusCursos == 1 || Datos.IDStatusCursos == 3)
                {
                    this.dgvParticipantes.CellDoubleClick -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParticipantes_CellDoubleClick);
                }
                this.TipoForm = 2;
                this.IDCursos = this._DatosCapacitacionCurso.IDCurso;
                //IDCompra = Datos;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCapacitacionCursoEvaluar ~ frmCapacitacionCursoEvaluar()");
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.LlenarComboCursos();
                this.LlenarComboIntructores();
                if (TipoForm == 2)
                    this.CargarDatosAModificar(_DatosCapacitacionCurso);
                this.CargarLlenarGridPArticipantes();
                this.ActiveControl = this.btnRegresar;
                this.btnRegresar.Focus();
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

        private void CargarLlenarGridPArticipantes()
        {
            try
            {
                CapacitacionCurso DatosAux = new CapacitacionCurso();
                CapacitacionCurso_Negocio CN = new CapacitacionCurso_Negocio();
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDCapacitacion = this._DatosCapacitacionCurso.IDCapacitacion;
                CN.ObtenerParticipante(DatosAux);
                this.dgvParticipantes.DataSource = null;
                this.dgvParticipantes.AutoGenerateColumns = false;
                this.dgvParticipantes.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmCapacitacionCurso_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCapacitacionCursoEvaluar ~ frmCapacitacionCurso_Load");
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCapacitacionCursoEvaluar ~ btnRegresar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvParticipantes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (dgvParticipantes.Columns[e.ColumnIndex] == dgvParticipantes.Columns["Calificacion"])
                    {
                        CapacitacionCurso DatosAux = new CapacitacionCurso();                       
                        DatosAux.IDCurso = this.dgvParticipantes.Rows[e.RowIndex].Cells["IDCurso"].Value.ToString();
                        DatosAux.IDInscripcion = this.dgvParticipantes.Rows[e.RowIndex].Cells["IDInscripcion"].Value.ToString();
                        DatosAux.IDEmpleado = this.dgvParticipantes.Rows[e.RowIndex].Cells["IDEmpleado"].Value.ToString();
                        DatosAux.IDCapacitacion = this.dgvParticipantes.Rows[e.RowIndex].Cells["IDCapacitacion"].Value.ToString();
                        if (!string.IsNullOrEmpty(DatosAux.IDCurso))
                        {
                            frmCursoTemasSubTemasCapacitacion NCompra = new frmCursoTemasSubTemasCapacitacion(DatosAux);
                            NCompra.ShowDialog();
                            NCompra.Dispose();
                            this.Visible = true;
                            this.CargarLlenarGridPArticipantes();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCapacitacionCursoEvaluar ~ dgvParticipantes_CellDoubleClick");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
