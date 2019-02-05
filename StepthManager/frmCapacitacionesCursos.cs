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
    public partial class frmCapacitacionesCursos : Form
    {
        #region Variables

        private bool CursosCreados = false;
        private bool CursosActivos = false;
        private bool CursosConcluidos = false;
        private bool Busqueda = false;
        private CapacitacionCurso DatosBusq = new CapacitacionCurso();

        #endregion

        #region Constructor

        public frmCapacitacionesCursos()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCapacitacionesCursos ~ frmCapacitacionesCursos()");
            }
        }

        #endregion

        #region Métodos

        private void BusquedaCursos()
        {
            try
            {
                CapacitacionCurso DatosAux = new CapacitacionCurso();
                DatosAux.BusqFecha = this.rbFecha.Checked;
                DatosAux.BusqProveedor = this.rbCursos.Checked;
                if (DatosAux.BusqFecha)
                    DatosAux.FechaBus = this.dtpFecha.Value;
                if (DatosAux.BusqProveedor)
                {
                    Curso ProvAux = this.ObtenerCursosSeleccionado();
                    if (!string.IsNullOrEmpty(ProvAux.IDCurso))
                        DatosAux.IDCurso = ProvAux.IDCurso;
                    else
                    {
                        MessageBox.Show("Seleccione un Curso de la lista.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                this.DatosBusq = DatosAux;
                switch (this.tcCursos.SelectedIndex)
                {
                    case 0: this.CargarCursosCreadosBusq(DatosAux);
                        break;
                    case 1: this.CargarCursosActivosBusq(DatosAux);
                        break;
                    case 2: this.CargarCursosConcluidosBusq(DatosAux);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarCursosCreados()
        {
            try
            {
                if (!CursosCreados)
                {
                    CapacitacionCurso DatosAux = new CapacitacionCurso { Conexion = Comun.Conexion, Todos = false, IDStatusCursos = 1};
                    CapacitacionCurso_Negocio CN = new CapacitacionCurso_Negocio();
                    CN.ObtenerCursosCreados(DatosAux);
                    this.dgvCursosCreados.AutoGenerateColumns = false;
                    this.dgvCursosCreados.DataSource = DatosAux.TablaDatos;
                    this.CursosCreados = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarCursosActivos()
        {
            try
            {
                if (!CursosActivos)
                {
                    CapacitacionCurso DatosAux = new CapacitacionCurso { Conexion = Comun.Conexion, Todos = false, IDStatusCursos = 2 };
                    CapacitacionCurso_Negocio CN = new CapacitacionCurso_Negocio();
                    CN.ObtenerCursosCreados(DatosAux);
                    this.dgvCursosActivos.AutoGenerateColumns = false;
                    this.dgvCursosActivos.DataSource = DatosAux.TablaDatos;
                    this.CursosActivos = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarCursosConcluidos()
        {
            try
            {
                if (!CursosConcluidos)
                {
                    CapacitacionCurso DatosAux = new CapacitacionCurso { Conexion = Comun.Conexion, Todos = false, IDStatusCursos = 3 };
                    CapacitacionCurso_Negocio CN = new CapacitacionCurso_Negocio();
                    CN.ObtenerCursosCreados(DatosAux);
                    this.dgvCursosConcluidos.AutoGenerateColumns = false;
                    this.dgvCursosConcluidos.DataSource = DatosAux.TablaDatos;
                    this.CursosConcluidos = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarCursosCreadosBusq(CapacitacionCurso DatosBusq)
        {
            try
            {
                if (!CursosCreados)
                {
                    DatosBusq.Conexion = Comun.Conexion;
                    DatosBusq.IDStatusCursos = 1;
                    CapacitacionCurso_Negocio CN = new CapacitacionCurso_Negocio();
                    CN.ObtenerCursosCreadoBusq(DatosBusq);
                    this.dgvCursosCreados.AutoGenerateColumns = false;
                    this.dgvCursosCreados.DataSource = DatosBusq.TablaDatos;
                    this.Busqueda = true;
                    this.CursosCreados = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarCursosActivosBusq(CapacitacionCurso DatosBusq)
        {
            try
            {
                if (!CursosActivos)
                {
                    DatosBusq.Conexion = Comun.Conexion;
                    DatosBusq.IDStatusCursos = 2;
                    CapacitacionCurso_Negocio CN = new CapacitacionCurso_Negocio();
                    CN.ObtenerCursosCreadoBusq(DatosBusq);
                    this.dgvCursosActivos.AutoGenerateColumns = false;
                    this.dgvCursosActivos.DataSource = DatosBusq.TablaDatos;
                    this.Busqueda = true;
                    this.CursosActivos = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarCursosConcluidosBusq(CapacitacionCurso DatosBusq)
        {
            try
            {
                if (!CursosConcluidos)
                {
                    DatosBusq.Conexion = Comun.Conexion;
                    DatosBusq.IDStatusCursos = 3;
                    CapacitacionCurso_Negocio CN = new CapacitacionCurso_Negocio();
                    CN.ObtenerCursosCreadoBusq(DatosBusq);
                    this.dgvCursosConcluidos.AutoGenerateColumns = false;
                    this.dgvCursosConcluidos.DataSource = DatosBusq.TablaDatos;
                    this.Busqueda = true;
                    this.CursosConcluidos = true;
                }
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
                this.cmbCursos.Enter -= new System.EventHandler(this.cmbCursos_Enter);
                this.LlenarComboCursos();
                this.CargarCursosCreados();
                this.rbCursos.Checked = false;
                this.ActiveControl = this.btnBuscar;
                this.btnBuscar.Focus();
                this.cmbCursos.Enter += new System.EventHandler(this.cmbCursos_Enter);
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

        private Curso ObtenerCursosSeleccionado()
        {
            try
            {
                Curso DatosAux = new Curso();
                if (this.cmbCursos.SelectedIndex != -1)
                {
                    DatosAux = (Curso)this.cmbCursos.SelectedItem;
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private CapacitacionCurso ObtenerDatosGrid()
        {
            try
            {
                CapacitacionCurso DatosAux = new CapacitacionCurso();
                int TabIndex = this.tcCursos.SelectedIndex;
                switch (TabIndex)
                {
                    case 0: DatosAux = this.ObtenerDatos(this.dgvCursosCreados, TabIndex);
                        break;
                    case 1: DatosAux = this.ObtenerDatos(this.dgvCursosActivos, TabIndex);
                        break;
                    case 2: DatosAux = this.ObtenerDatos(this.dgvCursosConcluidos, TabIndex);
                        break;
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private CapacitacionCurso ObtenerDatos(DataGridView DGV, int TabIndex)
        {
            try
            {
                CapacitacionCurso DatosAux = new CapacitacionCurso();
                Int32 RowData = DGV.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (DGV.SelectedRows.Count == 1)
                {
                    DataGridViewRow FilaDatos = DGV.Rows[RowData];
                    int IDEstatus = 0;
                    DatosAux.IDCapacitacion = FilaDatos.Cells["IDCapacitacion" + TabIndex].Value.ToString();
                    DatosAux.IDCurso = FilaDatos.Cells["IDCurso" + TabIndex].Value.ToString();
                    DatosAux.IDInstructor = FilaDatos.Cells["IDInstructor" + TabIndex].Value.ToString();
                    int.TryParse(FilaDatos.Cells["IDStatusCursos" + TabIndex].Value.ToString(), out IDEstatus);
                    DatosAux.IDStatusCursos = IDEstatus;
                    DatosAux.Lugar = FilaDatos.Cells["Lugar" + TabIndex].Value.ToString();
                    DatosAux.FechaInicioCurso = Convert.ToDateTime(FilaDatos.Cells["FechaInicioCurso" + TabIndex].Value.ToString());
                    DatosAux.FechaFinCurso = Convert.ToDateTime(FilaDatos.Cells["FechaFinCurso" + TabIndex].Value.ToString());
                    DatosAux.NombreCapacitacion = FilaDatos.Cells["NombreCurso" + TabIndex].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoCapacitacionCurso NCompra = new frmNuevoCapacitacionCurso();
                NCompra.ShowDialog();
                NCompra.Dispose();
                this.Visible = true;
                if (NCompra.DialogResult == DialogResult.OK)
                {
                    if (Busqueda)
                    {
                        this.CursosCreados= false;
                        this.CargarCursosCreadosBusq(this.DatosBusq);
                    }
                    else
                    {
                        this.CursosCreados = false;
                        this.CargarCursosCreados();
                    }

                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmCapacitacionesCursos ~ btnNuevo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarBusq_Click(object sender, EventArgs e)
        {
            try
            {
                if (Busqueda)
                {
                    this.CursosCreados = false;
                    this.CursosActivos = false;
                    this.CursosConcluidos = false;
                    this.CargarCursosCreados();
                    this.CargarCursosActivos();
                    this.CargarCursosConcluidos();
                    if (this.cmbCursos.Items.Count > 0)
                        this.cmbCursos.SelectedIndex = 0;
                    this.dtpFecha.Value = DateTime.Today;
                    this.rbFecha.Checked = false;
                    this.rbCursos.Checked = false;
                    Busqueda = false;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCapacitacionesCursos ~ btnCancelarBusq_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCapacitacionesCursos_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCapacitacionesCursos ~ frmCapacitacionesCursos_Load");
            }
        }

        private void tcCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                switch (tcCursos.SelectedIndex)
                {
                    case 0:
                        if (Busqueda)
                            this.CargarCursosActivosBusq(this.DatosBusq);
                        else
                            this.CargarCursosCreados();
                        break;
                    case 1:
                        if (Busqueda)
                            this.CargarCursosActivosBusq(this.DatosBusq);
                        else
                            this.CargarCursosActivos();
                        break;
                   case 2:
                        if (Busqueda)
                            this.CargarCursosActivosBusq(this.DatosBusq);
                        else
                            this.CargarCursosConcluidos();
                        break;
                    default: break;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCapacitacionesCursos ~ tcCursos_SelectedIndexChanged");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CursosCreados = false;
                this.CursosActivos = false;
                this.CursosConcluidos = false;
                this.BusquedaCursos();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCapacitacionesCursos ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCursos_Enter(object sender, EventArgs e)
        {
            try
            {
                this.rbCursos.Checked = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCapacitacionesCursos ~ cmbCursos_Enter");
            }
        }


        private void dtpFecha_Enter(object sender, EventArgs e)
        {
            try
            {
                this.rbFecha.Checked = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCapacitacionesCursos ~ dtpFecha_Enter");
            }
        }

        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCapacitacionesCursos ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                CapacitacionCurso DatosAux = this.ObtenerDatosGrid();
                if (!string.IsNullOrEmpty(DatosAux.IDCapacitacion))
                {
                    if (MessageBox.Show("¿Está seguro de cancelar el curso " + DatosAux.NombreCapacitacion + "?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (DatosAux.IDStatusCursos == 1)
                        {
                            DatosAux.Conexion = Comun.Conexion;
                            DatosAux.IDUsuario = Comun.IDUsuario;
                            DatosAux.Opcion = 3;
                            CapacitacionCurso_Negocio CN = new CapacitacionCurso_Negocio();
                            CN.AbcCapacitacionCurso(DatosAux);
                            if (DatosAux.Completado)
                            {
                                this.CursosCreados = false;
                                this.tcCursos_SelectedIndexChanged(this.tcCursos, new EventArgs());
                                MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se puede cancelar el curso. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("La curso debe estar en estatus Creada.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCapacitacionesCursos ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                CapacitacionCurso DatosAux = this.ObtenerDatosGrid();
                if (!string.IsNullOrEmpty(DatosAux.IDCapacitacion))
                {

                    if (DatosAux.IDStatusCursos == 1)
                    {
                        frmNuevoCapacitacionCurso NCompra = new frmNuevoCapacitacionCurso(DatosAux);
                        NCompra.ShowDialog();
                        NCompra.Dispose();
                        this.Visible = true;
                        if (NCompra.DialogResult == DialogResult.OK)
                        {
                            if (Busqueda)
                            {
                                this.CursosCreados = false;
                                this.CargarCursosCreadosBusq(this.DatosBusq);
                            }
                            else
                            {
                                this.CursosCreados = false;
                                this.CargarCursosCreados();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El curso tiene que estar en un status Creado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmCapacitacionesCursos ~ btnModificar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActivarCurso_Click(object sender, EventArgs e)
        {
            try
            {
                CapacitacionCurso DatosAux = this.ObtenerDatosGrid();
                if (!string.IsNullOrEmpty(DatosAux.IDCapacitacion))
                {
                    if (DatosAux.IDStatusCursos == 1)
                    {
                        if (MessageBox.Show("¿Está seguro de activar el curso " + DatosAux.NombreCapacitacion + "? Recuerde que este proceso No es reversible.", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DatosAux.Conexion = Comun.Conexion;
                            DatosAux.IDUsuario = Comun.IDUsuario;
                            CapacitacionCurso_Negocio CN = new CapacitacionCurso_Negocio();
                            CN.ActivarCursos(DatosAux);
                            if (DatosAux.Completado)
                            {
                                this.CursosCreados = false;
                                this.CursosActivos = false;
                                this.tcCursos_SelectedIndexChanged(this.tcCursos, new EventArgs());
                                MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se puede activar el curso. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("La curso debe estar en estatus Creada.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCapacitacionesCursos ~ btnActivarCurso_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEvaluarCurso_Click(object sender, EventArgs e)
        {
            try
            {
                CapacitacionCurso DatosAux = this.ObtenerDatosGrid();
                if (!string.IsNullOrEmpty(DatosAux.IDCapacitacion))
                {
                    if (DatosAux.IDStatusCursos == 2)
                    {
                        frmCapacitacionCursoEvaluar DetalleCompra = new frmCapacitacionCursoEvaluar(DatosAux);
                        this.Visible = false;
                        DetalleCompra.ShowDialog();
                        DetalleCompra.Dispose();
                        this.Visible = true;
                    }
                    else
                    {
                         MessageBox.Show("El curso tiene que estar en un status Activo.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmCapacitacionesCursos ~ btnDetalleCompra_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConcluirCurso_Click(object sender, EventArgs e)
        {
            try
            {
                CapacitacionCurso DatosAux = this.ObtenerDatosGrid();
                if (!string.IsNullOrEmpty(DatosAux.IDCapacitacion))
                {
                    if (DatosAux.IDStatusCursos == 2)
                    {
                        if (MessageBox.Show("¿Está seguro de concluir el curso " + DatosAux.NombreCapacitacion + "? Recuerde que este proceso No es reversible.", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DatosAux.Conexion = Comun.Conexion;
                            DatosAux.IDUsuario = Comun.IDUsuario;
                            CapacitacionCurso_Negocio CN = new CapacitacionCurso_Negocio();
                            CN.ConcluirCursos(DatosAux);
                            if (DatosAux.Completado)
                            {
                                this.CursosActivos = false;
                                this.CursosConcluidos = false;
                                this.tcCursos_SelectedIndexChanged(this.tcCursos, new EventArgs());
                                MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se puede concluir el curso. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("La curso debe estar en estatus activado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCapacitacionesCursos ~ btnConcluirCurso_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            try
            {
                CapacitacionCurso DatosAux = this.ObtenerDatosGrid();
                if (!string.IsNullOrEmpty(DatosAux.IDCapacitacion))
                {
                    if (DatosAux.IDStatusCursos == 1)
                    {
                        frmInscripcionCursos InscripcionesCursos = new frmInscripcionCursos(DatosAux);
                        InscripcionesCursos.ShowDialog();
                        InscripcionesCursos.Dispose();
                        this.Visible = true;
                        if (InscripcionesCursos.DialogResult == DialogResult.OK)
                        {
                            if (Busqueda)
                            {
                                this.CursosCreados = false;
                                this.CargarCursosCreadosBusq(this.DatosBusq);
                            }
                            else
                            {
                                this.CursosCreados = false;
                                this.CargarCursosCreados();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El curso tiene que estar en un status Creado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmCapacitacionesCursos ~ btnDetalleCompra_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetalleCurso_Click(object sender, EventArgs e)
        {
            try
            {
                CapacitacionCurso DatosAux = this.ObtenerDatosGrid();
                if (!string.IsNullOrEmpty(DatosAux.IDCapacitacion))
                {
                    if (DatosAux.IDStatusCursos ==1 || DatosAux.IDStatusCursos == 2 || DatosAux.IDStatusCursos ==3)
                    {
                        frmCapacitacionCursoDetalle DetalleCompra = new frmCapacitacionCursoDetalle(DatosAux);
                        this.Visible = false;
                        DetalleCompra.ShowDialog();
                        DetalleCompra.Dispose();
                        this.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmCapacitacionesCursos ~ btnDetalleCompra_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMateriales_Click(object sender, EventArgs e)
        {
            try
            {
                frmMaterialesCapacitacion Materiales = new frmMaterialesCapacitacion();
                this.Visible = false;
                Materiales.ShowDialog();
                Materiales.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmCapacitacionesCursos ~ btnDetalleCompra_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
