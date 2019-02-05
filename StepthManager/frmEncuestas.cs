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
    public partial class frmEncuestas : Form
    {
        #region Variables
        private bool SoloVigentes = true;
        DataTable DatosActuales = new DataTable();
        private bool BandCreadas = false, BandActivas = false, BandSuspendidas = false, BandVencidas = false;
        #endregion

        #region Constructores

        public frmEncuestas()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEncuestas ~ frmEncuestas()");
            }
        }

        #endregion

        #region Métodos

        private void BusquedaEncuestas(string TextoBusqueda)
        {
            try
            {
                if (!string.IsNullOrEmpty(TextoBusqueda.Trim()))
                {
                    DataTable TablaResultados = new DataTable();
                    DataRow[] ResultadosBusqueda = DatosActuales.Select("Titulo like '%" + TextoBusqueda + "%'");
                    if (ResultadosBusqueda.Count() > 0)
                        TablaResultados = ResultadosBusqueda.CopyToDataTable();
                    this.dgvEncuestasCreadas.DataSource = TablaResultados;
                }
                else
                    this.dgvEncuestasCreadas.DataSource = DatosActuales;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EliminarEncuesta(Encuesta Datos)
        {
            try
            {
                Datos.Conexion = Comun.Conexion;
                Datos.IDUsuario = Comun.IDUsuario;
                Encuesta_Negocio EN = new Encuesta_Negocio();
                EN.EliminarEncuesta(Datos);
                if (Datos.Completado)
                {
                    MessageBox.Show("Registro Eliminado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridView Aux = this.ObtenerDgvTabSeleccionado();
                    Int32 RowToDelete = Aux.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowToDelete > -1)
                        Aux.Rows.RemoveAt(RowToDelete);
                    else
                    {
                        switch (this.tcEncuestas.SelectedIndex)
                        {
                            case 0: BandCreadas = false; break;
                            case 1: BandActivas = false; break;
                            case 2: BandSuspendidas = false; break;
                            case 3: BandVencidas = false; break;
                        }
                        this.LlenarGridEncuestas(false, this.tcEncuestas.SelectedIndex, this.ObtenerDgvTabSeleccionado());
                    }
                }
                else
                {
                    MessageBox.Show("Error al guardar los datos. Contacte a Soporte Técnico.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogError.AddExcFileTxt(new Exception(Datos.MensajeError), "frmEncuestas ~ EliminarEncuesta -> Método");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ModificarDatos(Encuesta Datos)
        {
            try
            {
                switch(this.tcEncuestas.SelectedIndex)
                {
                    case 0: BandCreadas = false; break;
                    case 1: break;
                    case 2: break;
                    case 3: break;
                }
                this.LlenarGridEncuestas(false, this.tcEncuestas.SelectedIndex, this.ObtenerDgvTabSeleccionado());
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
                this.LlenarGridEncuestas(this.chkTodosLosRegistros.Checked, 0,this.dgvEncuestasCreadas);
                this.txtBusqueda.Focus();
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

        private void LlenarGridCatEncuestas(bool TodosRegistros, bool EncuestasVigentes)
        {
            try
            {
                Encuesta DatosAux = new Encuesta { Conexion = Comun.Conexion, BuscarTodos = TodosRegistros, SoloVigentes = EncuestasVigentes };
                Encuesta_Negocio EN = new Encuesta_Negocio();
                EN.ObtenerEncuestas(DatosAux);
                this.dgvEncuestasCreadas.AutoGenerateColumns = false;
                this.dgvEncuestasCreadas.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
                this.txtBusqueda.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridEncuestas(bool TodosRegistros, int IndexTab, DataGridView Dgv)
        {
            try
            {
                Encuesta DatosAux = new Encuesta { Conexion = Comun.Conexion, BuscarTodos = TodosRegistros, Opcion = IndexTab + 1};
                Encuesta_Negocio EN = new Encuesta_Negocio();
                EN.ObtenerEncuestasTab(DatosAux);
                Dgv.AutoGenerateColumns = false;
                Dgv.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
                this.txtBusqueda.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridEncuestasBusqueda(bool TodosRegistros, int IndexTab, DataGridView Dgv)
        {
            try
            {
                Encuesta DatosAux = new Encuesta { Conexion = Comun.Conexion, BuscarTodos = TodosRegistros, Opcion = IndexTab + 1, Titulo = this.txtBusqueda.Text.Trim() };
                Encuesta_Negocio EN = new Encuesta_Negocio();
                EN.ObtenerEncuestasTabBusqueda(DatosAux);
                Dgv.AutoGenerateColumns = false;
                Dgv.DataSource = DatosAux.TablaDatos;
                DatosActuales = DatosAux.TablaDatos;
                this.txtBusqueda.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataGridView ObtenerDgvTabSeleccionado()
        {
            try
            {
                DataGridView Aux = new DataGridView();
                switch (this.tcEncuestas.SelectedIndex)
                {
                    case 0: Aux = this.dgvEncuestasCreadas; BandCreadas = false; break;
                    case 1: Aux = this.dgvEncuestasActivas; BandActivas = false; break;
                    case 2: Aux = this.dgvEncuestasSuspendidas; BandSuspendidas = false; break;
                    case 3: Aux = this.dgvEncuestasVencidas; BandVencidas = false; break;
                }
                return Aux;
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
                DataGridView Selected = this.ObtenerDgvTabSeleccionado();
                Encuesta DatosAux = new Encuesta();
                Int32 RowData = Selected.Rows.GetFirstRow(DataGridViewElementStates.Selected); 
                if (RowData > -1) 
                {
                    DataGridViewRow FilaDatos = Selected.Rows[RowData];
                    int EstatusEncuesta = 0, TabIndex = 0;
                    TabIndex = this.tcEncuestas.SelectedIndex + 1;
                    int.TryParse(FilaDatos.Cells["IDEstatusEncuesta" + TabIndex].Value.ToString(), out EstatusEncuesta);
                    DatosAux.IDEncuesta = FilaDatos.Cells["IDEncuesta" + TabIndex].Value.ToString();
                    DatosAux.Titulo = FilaDatos.Cells["Titulo" + TabIndex].Value.ToString();
                    DatosAux.IDEstatusEncuesta = EstatusEncuesta;
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtBusqueda.Text.Trim()))
                {
                    this.LlenarGridEncuestasBusqueda(this.chkTodosLosRegistros.Checked, 0, this.dgvEncuestasCreadas);
                    this.LlenarGridEncuestasBusqueda(this.chkTodosLosRegistros.Checked, 1, this.dgvEncuestasActivas);
                    this.LlenarGridEncuestasBusqueda(this.chkTodosLosRegistros.Checked, 2, this.dgvEncuestasSuspendidas);
                    this.LlenarGridEncuestasBusqueda(this.chkTodosLosRegistros.Checked, 3, this.dgvEncuestasVencidas);
                }
                else
                {
                    this.BandCreadas = false;
                    this.BandActivas = false;
                    this.BandSuspendidas = false;
                    this.BandVencidas = false;
                    this.LlenarGridEncuestas(this.chkTodosLosRegistros.Checked, this.tcEncuestas.SelectedIndex, this.ObtenerDgvTabSeleccionado());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEncuestas ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView Selected = this.ObtenerDgvTabSeleccionado();
                if (Selected.SelectedRows.Count == 1)
                {
                    Encuesta DatosAux = this.ObtenerDatosEncuesta();
                    if (!string.IsNullOrEmpty(DatosAux.IDEncuesta))
                    {
                        if(MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            this.EliminarEncuesta(DatosAux);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEncuestas ~ btnEliminar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView Selected = this.ObtenerDgvTabSeleccionado();
                if (Selected.SelectedRows.Count == 1)
                {
                    Encuesta DatosAux = this.ObtenerDatosEncuesta();
                    if (!string.IsNullOrEmpty(DatosAux.IDEncuesta))
                    {
                        if (DatosAux.IDEstatusEncuesta == 1 && this.tcEncuestas.SelectedIndex == 0)
                        {
                            Encuesta_Negocio EN = new Encuesta_Negocio();
                            DatosAux.Conexion = Comun.Conexion;
                            DatosAux = EN.ObtenerDetalleEncuestaXID(DatosAux);
                            this.Visible = false;
                            frmNuevaEncuesta Encuesta = new frmNuevaEncuesta(DatosAux);
                            Encuesta.ShowDialog();
                            Encuesta.Dispose();
                            if (Encuesta.DialogResult == DialogResult.OK)
                            {
                                if (Encuesta.DatosEncuesta.Completado)
                                {
                                    this.ModificarDatos(Encuesta.DatosEncuesta);
                                }
                            }
                            this.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("La encuesta debe estar en Estatus: Creada, y no debe estar vencida.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEncuestas ~ btnModificar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmNuevaEncuesta Encuesta = new frmNuevaEncuesta();
                Encuesta.ShowDialog();
                Encuesta.Dispose();
                if (Encuesta.DialogResult == DialogResult.OK)
                {
                    switch (this.tcEncuestas.SelectedIndex)
                    {
                        case 0: BandCreadas = false; break;
                        case 1: break;
                        case 2: break;
                        case 3: break;
                    }
                    this.LlenarGridEncuestas(false, 0, this.dgvEncuestasCreadas);
                }
                this.Visible = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEncuestas ~ btnNuevo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEncuestas ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.LlenarGridCatEncuestas(this.chkTodosLosRegistros.Checked, this.SoloVigentes);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEncuestas ~ btnTodos_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkTodosLosRegistros_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtBusqueda.Text.Trim()))
                {
                    this.LlenarGridEncuestasBusqueda(this.chkTodosLosRegistros.Checked, 0, this.dgvEncuestasCreadas);
                    this.LlenarGridEncuestasBusqueda(this.chkTodosLosRegistros.Checked, 1, this.dgvEncuestasActivas);
                    this.LlenarGridEncuestasBusqueda(this.chkTodosLosRegistros.Checked, 2, this.dgvEncuestasSuspendidas);
                    this.LlenarGridEncuestasBusqueda(this.chkTodosLosRegistros.Checked, 3, this.dgvEncuestasVencidas);
                }
                else
                {
                    this.BandCreadas = false;
                    this.BandActivas = false;
                    this.BandSuspendidas = false;
                    this.BandVencidas = false;
                    this.LlenarGridEncuestas(this.chkTodosLosRegistros.Checked, this.tcEncuestas.SelectedIndex, this.ObtenerDgvTabSeleccionado());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEncuestas ~ chkTodosLosRegistros_CheckedChanged");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmEncuestas_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEncuestas ~ frmEncuestas_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tcEncuestas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Tab = this.tcEncuestas.SelectedIndex;
                switch (Tab)
                {
                    case 0:
                        if (!BandCreadas)
                        {
                            this.LlenarGridEncuestas(this.chkTodosLosRegistros.Checked, Tab, this.dgvEncuestasCreadas);
                            this.BandCreadas = true;
                        }
                        break;
                    case 1:
                        if (!BandActivas)
                        {
                            this.LlenarGridEncuestas(this.chkTodosLosRegistros.Checked, Tab, this.dgvEncuestasActivas);
                            this.BandActivas = true;
                        }
                        break;
                    case 2:
                        if (!BandSuspendidas)
                        {
                            this.LlenarGridEncuestas(this.chkTodosLosRegistros.Checked, Tab, this.dgvEncuestasSuspendidas);
                            this.BandSuspendidas = true;
                        }
                        break;
                    case 3:
                        if (!BandVencidas)
                        {
                            this.LlenarGridEncuestas(this.chkTodosLosRegistros.Checked, Tab, this.dgvEncuestasVencidas);
                            this.BandVencidas = true;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEncuestas ~ tcEncuestas_SelectedIndexChanged");
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)Keys.Enter)
                {
                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEncuestas ~ txtBusqueda_KeyPress");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView Selected = this.ObtenerDgvTabSeleccionado();
                if (Selected.SelectedRows.Count == 1)
                {
                    Encuesta DatosAux = this.ObtenerDatosEncuesta();
                    if (!string.IsNullOrEmpty(DatosAux.IDEncuesta))
                    {
                        if (DatosAux.IDEstatusEncuesta == 1 && this.tcEncuestas.SelectedIndex == 0)
                        {
                            if (MessageBox.Show("¿Está seguro de activar la encuesta " + DatosAux.Titulo + "?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                DatosAux.Conexion = Comun.Conexion;
                                DatosAux.IDUsuario = Comun.IDUsuario;
                                Encuesta_Negocio EN = new Encuesta_Negocio();
                                EN.NotificacionesEncuestas(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    foreach (DataRow notificacion in DatosAux.tablaNotificaciones.Rows)
                                    {
                                        int IDTipoCelular = 0, Badge = 0;
                                        IDTipoCelular = Convert.ToInt32(notificacion["id_tipoCelular"].ToString());
                                        Badge = Convert.ToInt32(notificacion["Badge"].ToString());
                                        EnviaNotificaciones.EnviarMensaje(notificacion["tokenCelular"].ToString(), notificacion["nombre"].ToString(), notificacion["descripcion"].ToString(), Badge, IDTipoCelular);
                                    }
                                    this.BandActivas = false;
                                    this.BandCreadas = false;
                                    this.LlenarGridEncuestas(this.chkTodosLosRegistros.Checked, 0, this.dgvEncuestasCreadas);
                                    this.LlenarGridEncuestas(this.chkTodosLosRegistros.Checked, 1, this.dgvEncuestasActivas);
                                    MessageBox.Show("Datos actualizados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Ocurrió un error al activar la encuesta. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("La encuesta debe estar en Estatus: Creada, y no debe estar vencida.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEncuestas ~ btnActivar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuspender_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView Selected = this.ObtenerDgvTabSeleccionado();
                if (Selected.SelectedRows.Count == 1)
                {
                    Encuesta DatosAux = this.ObtenerDatosEncuesta();
                    if (!string.IsNullOrEmpty(DatosAux.IDEncuesta))
                    {
                        if (DatosAux.IDEstatusEncuesta == 2 && this.tcEncuestas.SelectedIndex == 1)
                        {
                            if (MessageBox.Show("¿Está seguro de suspender la encuesta " + DatosAux.Titulo + "?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                DatosAux.Conexion = Comun.Conexion;
                                DatosAux.IDUsuario = Comun.IDUsuario;
                                Encuesta_Negocio EN = new Encuesta_Negocio();
                                EN.SuspenderEncuesta(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.BandActivas = false;
                                    this.BandSuspendidas = false;
                                    this.LlenarGridEncuestas(this.chkTodosLosRegistros.Checked, 2, this.dgvEncuestasSuspendidas);
                                    this.LlenarGridEncuestas(this.chkTodosLosRegistros.Checked, 1, this.dgvEncuestasActivas);
                                    MessageBox.Show("Datos actualizados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Ocurrió un error al activar la encuesta. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("La encuesta debe estar en Estatus: Activa, y no debe estar vencida.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEncuestas ~ btnActivar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
