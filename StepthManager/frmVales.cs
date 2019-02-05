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
using System.Configuration;
using System.IO;

namespace StephManager
{
    public partial class frmVales : Form
    {
        #region Variables        
        private bool TabTramite = false;
        private bool TabSuspend = false;
        private bool TabConcluidos = false;
        private bool TabEnviados = false;
        private bool EsBusqueda = false;
        private string TextoBusqueda = string.Empty;
        DataTable DatosActuales = new DataTable();
        List<Vales> lstClientes = new List<Vales>();
        #endregion

        #region Constructores

        public frmVales()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVales ~ frmVales()");
            }
        }

        #endregion

        #region Métodos

        private void CargarGridTramite(bool TodosRegistros)
        {
            try
            {
                if (!this.TabTramite)
                {
                    Vales DatosAux = new Vales { Conexion = Comun.Conexion, BuscarTodos = TodosRegistros, TabVales = 0 };
                    Vales_Negocio VN = new Vales_Negocio();
                    VN.ObtenerVales(DatosAux);
                    this.dgvValesTramite.AutoGenerateColumns = false;
                    this.dgvValesTramite.DataSource = DatosAux.TablaDatos;
                    this.TabTramite = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridTramiteBusq(bool TodosRegistros)
        {
            try
            {
                if (!this.TabTramite)
                {
                    Vales DatosAux = new Vales { Conexion = Comun.Conexion, BuscarTodos = TodosRegistros, TabVales = 0, Nombre = this.TextoBusqueda };
                    Vales_Negocio VN = new Vales_Negocio();
                    VN.ObtenerValesBusqueda(DatosAux);
                    this.dgvValesTramite.AutoGenerateColumns = false;
                    this.dgvValesTramite.DataSource = DatosAux.TablaDatos;
                    this.TabTramite = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridSuspendidos(bool TodosRegistros)
        {
            try
            {
                if (!this.TabSuspend)
                {
                    Vales DatosAux = new Vales { Conexion = Comun.Conexion, BuscarTodos = TodosRegistros, TabVales = 1 };
                    Vales_Negocio VN = new Vales_Negocio();
                    VN.ObtenerVales(DatosAux);
                    this.dgvValesSuspendidos.AutoGenerateColumns = false;
                    this.dgvValesSuspendidos.DataSource = DatosAux.TablaDatos;
                    this.TabSuspend = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridSuspendidosBusq(bool TodosRegistros)
        {
            try
            {
                if (!this.TabSuspend)
                {
                    Vales DatosAux = new Vales { Conexion = Comun.Conexion, BuscarTodos = TodosRegistros, TabVales = 1, Nombre = this.TextoBusqueda };
                    Vales_Negocio VN = new Vales_Negocio();
                    VN.ObtenerValesBusqueda(DatosAux);
                    this.dgvValesSuspendidos.AutoGenerateColumns = false;
                    this.dgvValesSuspendidos.DataSource = DatosAux.TablaDatos;
                    this.TabSuspend = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridConcluidos(bool TodosRegistros)
        {
            try
            {
                if (!this.TabConcluidos)
                {
                    Vales DatosAux = new Vales { Conexion = Comun.Conexion, BuscarTodos = TodosRegistros, TabVales = 2 };
                    Vales_Negocio VN = new Vales_Negocio();
                    VN.ObtenerVales(DatosAux);
                    this.dgvValesConcluidos.AutoGenerateColumns = false;
                    this.dgvValesConcluidos.DataSource = DatosAux.TablaDatos;
                    this.TabConcluidos = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridConcluidosBusq(bool TodosRegistros)
        {
            try
            {
                if (!this.TabConcluidos)
                {
                    Vales DatosAux = new Vales { Conexion = Comun.Conexion, BuscarTodos = TodosRegistros, TabVales = 2, Nombre = this.TextoBusqueda };
                    Vales_Negocio VN = new Vales_Negocio();
                    VN.ObtenerValesBusqueda(DatosAux);
                    this.dgvValesConcluidos.AutoGenerateColumns = false;
                    this.dgvValesConcluidos.DataSource = DatosAux.TablaDatos;
                    this.TabConcluidos = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridEnviados(bool TodosRegistros)
        {
            try
            {
                if (!this.TabEnviados)
                {
                    Vales DatosAux = new Vales { Conexion = Comun.Conexion, BuscarTodos = TodosRegistros, TabVales = 3 };
                    Vales_Negocio VN = new Vales_Negocio();
                    VN.ObtenerVales(DatosAux);
                    this.dgvValesEnviados.AutoGenerateColumns = false;
                    this.dgvValesEnviados.DataSource = DatosAux.TablaDatos;
                    this.TabEnviados = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridEnviadosBusq(bool TodosRegistros)
        {
            try
            {
                if (!this.TabEnviados)
                {
                    Vales DatosAux = new Vales { Conexion = Comun.Conexion, BuscarTodos = TodosRegistros, TabVales = 3, Nombre = this.TextoBusqueda };
                    Vales_Negocio VN = new Vales_Negocio();
                    VN.ObtenerValesBusqueda(DatosAux);
                    this.dgvValesEnviados.AutoGenerateColumns = false;
                    this.dgvValesEnviados.DataSource = DatosAux.TablaDatos;
                    this.TabEnviados = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EliminarEncuesta(Vales Datos)
        {
            try
            {
                Datos.Conexion = Comun.Conexion;
                Datos.IDUsuario = Comun.IDUsuario;
                Vales_Negocio EN = new Vales_Negocio();
                //EN.eliminarVale(Datos);
                if (Datos.Completado)
                {
                    MessageBox.Show("Registro Eliminado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Int32 RowToDelete = this.dgvValesTramite.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowToDelete > -1)
                        this.dgvValesTramite.Rows.RemoveAt(RowToDelete);
                    else
                    {
                        //Falta algoi
                    }
                }
                else
                {
                    MessageBox.Show("Error al guardar los datos. Contacte a Soporte Técnico.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogError.AddExcFileTxt(new Exception(Datos.MensajeError), "frmVales ~ EliminarEncuesta -> Método");
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
                this.tcVales_SelectedIndexChanged(this.tcVales, new EventArgs());
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

        private DataGridView ObtenerGridSeleccionado()
        {
            try
            {
                DataGridView DGV;
                switch (this.tcVales.SelectedIndex)
                {
                    case 0: DGV = this.dgvValesTramite;
                        break;
                    case 1: DGV = this.dgvValesSuspendidos;
                        break;
                    case 2: DGV = this.dgvValesConcluidos;
                        break;
                    case 3: DGV = this.dgvValesEnviados;
                        break;
                    default: DGV = this.dgvValesTramite;
                        break;
                }
                return DGV;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Vales ObtenerDatosVale()
        {
            try
            {
                Vales DatosAux = new Vales();
                int TabIndex = this.tcVales.SelectedIndex;
                DataGridView DGV = this.ObtenerGridSeleccionado();
                Int32 RowData = DGV.Rows.GetFirstRow(DataGridViewElementStates.Selected); 
                if (RowData > -1) 
                {
                    DataGridViewRow FilaDatos = DGV.Rows[RowData];
                    DatosAux.IDVale = FilaDatos.Cells["IDVale" + TabIndex].Value.ToString();
                    int IDTipoVale = 0, IDEstatusVale = 0, CantidadLimite = 0;
                    bool AbiertoPublico = false;
                    int.TryParse(FilaDatos.Cells["IDTipoVale" + TabIndex].Value.ToString(), out IDTipoVale);
                    int.TryParse(FilaDatos.Cells["IDEstatusVale" + TabIndex].Value.ToString(), out IDEstatusVale);
                    int.TryParse(FilaDatos.Cells["CantLimite" + TabIndex].Value.ToString(), out CantidadLimite);
                    bool.TryParse(FilaDatos.Cells["Abierto" + TabIndex].Value.ToString(), out AbiertoPublico);
                    DatosAux.Nombre = FilaDatos.Cells["Nombre" + TabIndex].Value.ToString();
                    DatosAux.Folio = FilaDatos.Cells["Folio" + TabIndex].Value.ToString();
                    DatosAux.NombreTipoVale = FilaDatos.Cells["NombreTipoVale" + TabIndex].Value.ToString();
                    DatosAux.CantLimite = CantidadLimite;
                    DatosAux.Abierto = AbiertoPublico;
                    DatosAux.IDTipoVale = IDTipoVale;
                    DatosAux.IDEstatusVale = IDEstatusVale;
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Vales ObtenerDetalleVale(string IDValePar)
        {
            try
            {
                Vales DatosAux = new Vales { IDVale = IDValePar, Conexion = Comun.Conexion };
                Vales_Negocio VN = new Vales_Negocio();
                return VN.ObtenerValeDetalle(DatosAux);
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
                    this.TabTramite = false;
                    this.TabSuspend = false;
                    this.TabConcluidos = false;
                    this.TabEnviados = false;
                    this.EsBusqueda = true;
                    this.TextoBusqueda = this.txtBusqueda.Text.Trim();
                    this.tcVales_SelectedIndexChanged(this.tcVales, e);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVales ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancBusqueda_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.EsBusqueda)
                {
                    this.TabTramite = false;
                    this.TabSuspend = false;
                    this.TabConcluidos = false;
                    this.TabEnviados = false;
                    this.EsBusqueda = false;
                    this.txtBusqueda.Text = string.Empty;
                    this.txtBusqueda.Focus();
                    this.tcVales_SelectedIndexChanged(this.tcVales, e);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVales ~ btnCancBusqueda_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ObtenerGridSeleccionado().SelectedRows.Count == 1)
                {
                    Vales DatosAux = this.ObtenerDatosVale();
                    if (!string.IsNullOrEmpty(DatosAux.IDVale))
                    {
                        if (MessageBox.Show("¿Está seguro de eliminar el vale " + DatosAux.Folio + "?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DatosAux.IDUsuario = Comun.IDUsuario;
                            DatosAux.Conexion = Comun.Conexion;
                            Vales_Negocio VN = new Vales_Negocio();
                            VN.EliminarVale(DatosAux);
                            if (DatosAux.Completado)
                            {
                                switch (this.tcVales.SelectedIndex)
                                {
                                    case 0: this.TabTramite = false;
                                        break;
                                    case 1: this.TabSuspend = false;
                                        break;
                                    case 2: this.TabConcluidos = false;
                                        break;
                                    case 3: this.TabEnviados = false;
                                        break;
                                }
                                this.tcVales_SelectedIndexChanged(this.tcVales, e);
                            }
                            else
                            {
                                MessageBox.Show("Ocurrió un error al guardar los datos. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVales ~ btnEliminar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ObtenerGridSeleccionado().SelectedRows.Count == 1)
                {
                    Vales DatosAux = this.ObtenerDatosVale();
                    if (!string.IsNullOrEmpty(DatosAux.IDVale))
                    {
                        if (DatosAux.IDEstatusVale == 1)
                        {
                            DatosAux = this.ObtenerDetalleVale(DatosAux.IDVale);
                            if (!string.IsNullOrEmpty(DatosAux.IDVale))
                            {
                                frmNuevoVale ModificarVale = new frmNuevoVale(DatosAux);
                                this.Visible = false;
                                ModificarVale.ShowDialog();
                                ModificarVale.Dispose();
                                if (ModificarVale.DialogResult == DialogResult.OK)
                                {
                                    this.TabTramite = false;
                                    this.TabConcluidos = false;
                                    this.tcVales_SelectedIndexChanged(this.tcVales, e);
                                }
                                this.Visible = true;
                            }
                            else
                            {
                                MessageBox.Show("Ocurrió un error. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El estatus del vale no permite su modificación.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVales ~ btnModificar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmNuevoVale Vale = new frmNuevoVale();
                Vale.ShowDialog();
                Vale.Dispose();
                if (Vale.DialogResult == DialogResult.OK)
                {
                    this.TabTramite = false;
                    this.CargarGridTramite(this.chkTodosLosRegistros.Checked);
                }
                this.Visible = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVales ~ btnNuevo_Click");
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
                LogError.AddExcFileTxt(ex, "frmVales ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkTodosLosRegistros_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.TabTramite = false;
                this.TabSuspend = false;
                this.TabConcluidos = false;
                this.TabEnviados = false;
                this.tcVales_SelectedIndexChanged(this.tcVales, e);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVales ~ chkTodosLosRegistros_CheckedChanged");
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
                LogError.AddExcFileTxt(ex, "frmVales ~ frmEncuestas_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tcVales_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (this.tcVales.SelectedIndex)
                {
                    case 0:
                        if (this.EsBusqueda)
                            this.CargarGridTramiteBusq(this.chkTodosLosRegistros.Checked);
                        else
                            this.CargarGridTramite(this.chkTodosLosRegistros.Checked);
                        break;
                    case 1: 
                        if(this.EsBusqueda)
                            this.CargarGridSuspendidosBusq(this.chkTodosLosRegistros.Checked);
                        else
                            this.CargarGridSuspendidos(this.chkTodosLosRegistros.Checked);
                        break;
                    case 2: 
                        if(this.EsBusqueda)
                            this.CargarGridConcluidosBusq(this.chkTodosLosRegistros.Checked);
                        else
                            this.CargarGridConcluidos(this.chkTodosLosRegistros.Checked);
                        break;
                    case 3: 
                        if(this.EsBusqueda)
                            this.CargarGridEnviadosBusq(this.chkTodosLosRegistros.Checked);
                        else
                            this.CargarGridEnviados(this.chkTodosLosRegistros.Checked);
                        break;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVales ~ tcVales_SelectedIndexChanged");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                LogError.AddExcFileTxt(ex, "frmVales ~ txtBusqueda_KeyPress");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ObtenerGridSeleccionado().SelectedRows.Count == 1)
                {
                    Vales DatosAux = this.ObtenerDatosVale();
                    if (!string.IsNullOrEmpty(DatosAux.IDVale))
                    {
                        if (DatosAux.Abierto == true)
                        {
                            if (DatosAux.IDEstatusVale == 1 && this.tcVales.SelectedIndex == 0)
                            {
                                if (MessageBox.Show("¿Está seguro de activar el vale " + DatosAux.Folio + "?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    DatosAux.Conexion = Comun.Conexion;
                                    DatosAux.IDUsuario = Comun.IDUsuario;
                                    Vales_Negocio VN = new Vales_Negocio();
                                    VN.ActivarVale(DatosAux);
                                    if (DatosAux.Completado)
                                    {
                                        foreach (DataRow notificacion in DatosAux.tablaNotificaciones.Rows)
                                        {
                                            int IDTipoCelular = 0, Badge = 0;
                                            IDTipoCelular = Convert.ToInt32(notificacion["id_tipoCelular"].ToString());
                                            Badge = Convert.ToInt32(notificacion["Badge"].ToString());
                                            EnviaNotificaciones.EnviarMensaje(notificacion["tokenCelular"].ToString(), notificacion["nombre"].ToString(), notificacion["descripcion"].ToString(), Badge, IDTipoCelular);
                                        }
                                        this.TabTramite = false;
                                        this.tcVales_SelectedIndexChanged(this.tcVales, e);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ocurrió un error al guardar los datos. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Este vale ya ha sido activado previamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Este vale no requiere activación. Es restringido.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVales ~ btnActivar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnSuspender_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ObtenerGridSeleccionado().SelectedRows.Count == 1)
                {
                    Vales DatosAux = this.ObtenerDatosVale();
                    if (!string.IsNullOrEmpty(DatosAux.IDVale))
                    {
                        if (DatosAux.IDEstatusVale == 2)
                        {
                            if (MessageBox.Show("¿Está seguro de suspender el vale " + DatosAux.Folio + "?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                DatosAux.Conexion = Comun.Conexion;
                                DatosAux.IDUsuario = Comun.IDUsuario;
                                Vales_Negocio VN = new Vales_Negocio();
                                VN.SuspenderVale(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    this.TabTramite = false;
                                    this.TabSuspend = false;
                                    this.TabConcluidos = false;
                                    this.tcVales_SelectedIndexChanged(this.tcVales, e);
                                }
                                else
                                {
                                    MessageBox.Show("Ocurrió un error al guardar los datos. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se puede suspender el vale. El estatus actual no lo permite.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVales ~ btnActivar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ObtenerGridSeleccionado().SelectedRows.Count == 1)
                {
                    Vales DatosAux = this.ObtenerDatosVale();
                    if (!string.IsNullOrEmpty(DatosAux.IDVale))
                    {
                        if ((DatosAux.IDEstatusVale == 1 || DatosAux.IDEstatusVale == 2) && this.tcVales.SelectedIndex == 2)
                        {
                            if (MessageBox.Show("¿Está seguro de reactivar el vale " + DatosAux.Folio + "?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                frmValesFechas ValesFechas = new frmValesFechas(DatosAux);
                                ValesFechas.ShowDialog();
                                ValesFechas.Dispose();
                                this.Visible = true;
                                if (ValesFechas.DialogResult == DialogResult.OK)
                                {
                                    this.TabTramite = false;
                                    this.TabSuspend = false;
                                    this.TabConcluidos = false;
                                    this.tcVales_SelectedIndexChanged(this.tcVales, e);
                                }
                                this.Visible = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se puede reactivar el vale. El estatus actual no lo permite.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVales ~ btnActivar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAsignarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ObtenerGridSeleccionado().SelectedRows.Count == 1)
                {
                    Vales DatosAux = this.ObtenerDatosVale();
                    if (!string.IsNullOrEmpty(DatosAux.IDVale))
                    {
                        if (DatosAux.Abierto == false)
                        {
                            if (DatosAux.IDEstatusVale == 1 && this.tcVales.SelectedIndex == 0)
                            {

                                if (!string.IsNullOrEmpty(DatosAux.IDVale))
                                {
                                    frmValesXClientes ValesXClientes = new frmValesXClientes(DatosAux);
                                    ValesXClientes.ShowDialog();
                                    ValesXClientes.Dispose();
                                    this.Visible = true;
                                    if (ValesXClientes.DialogResult == DialogResult.OK)
                                    {
                                        this.TabTramite = false;
                                        this.tcVales_SelectedIndexChanged(this.tcVales, e);
                                    }
                                    this.Visible = true;
                                }

                            }
                            else
                            {
                                MessageBox.Show("El estatus del vale no permite asignar Clientes.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El Vale es para el publico general", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmVales ~ btnAsignarCliente_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ObtenerGridSeleccionado().SelectedRows.Count == 1)
                {
                    Vales DatosAux = this.ObtenerDatosVale();
                    if (!string.IsNullOrEmpty(DatosAux.IDVale))
                    {
                        if (DatosAux.Abierto == false)
                        {
                            if (!string.IsNullOrEmpty(DatosAux.IDVale))
                            {
                                frmDetalleValesXClientes ValesXClientes = new frmDetalleValesXClientes(DatosAux);
                                ValesXClientes.ShowDialog();
                                ValesXClientes.Dispose();
                                this.Visible = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("El Vale es para el publico general", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmVales ~ btnAsignarCliente_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ObtenerGridSeleccionado().SelectedRows.Count == 1)
                {
                    Vales DatosAux = this.ObtenerDatosVale();
                    if (!string.IsNullOrEmpty(DatosAux.IDVale))
                    {
                        if (DatosAux.IDEstatusVale == 1 && this.tcVales.SelectedIndex == 0)
                        {
                            if (DatosAux.Abierto == false)
                            {
                                DatosAux.Conexion = Comun.Conexion;
                                DatosAux.IDUsuario = Comun.IDUsuario;
                                Vales_Negocio VNX = new Vales_Negocio();
                                this.lstClientes = VNX.ObternerCorreosClientes(DatosAux);
                                if (this.lstClientes.Count() == 0)
                                {
                                    MessageBox.Show("El vale tiene que tener asiganado al menos un cliente", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    if (MessageBox.Show("¿Está seguro que desae enviar correo a los clientes del vale " + DatosAux.Folio + "?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        DatosAux.Conexion = Comun.Conexion;
                                        DatosAux.IDUsuario = Comun.IDUsuario;
                                        Vales_Negocio VN = new Vales_Negocio();
                                        VN.EnviarValeNotificacion(DatosAux);
                                        if (DatosAux.Completado)
                                        {
                                            foreach (DataRow notificacion in DatosAux.tablaNotificaciones.Rows)
                                            {
                                                int IDTipoCelular = 0, Badge = 0;
                                                IDTipoCelular = Convert.ToInt32(notificacion["id_tipoCelular"].ToString());
                                                Badge = Convert.ToInt32(notificacion["Badge"].ToString());
                                                EnviaNotificaciones.EnviarMensaje(notificacion["tokenCelular"].ToString(), notificacion["nombre"].ToString(), notificacion["descripcion"].ToString(), Badge, IDTipoCelular);
                                            }
                                            this.EnviarCorreo();
                                            this.TabTramite = false;
                                            this.tcVales_SelectedIndexChanged(this.tcVales, e);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Ocurrió un error al guardar los datos. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("El estatus del vale no permite enviarlo.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El vale no esta abierto al publico general.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVales ~ btnActivar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EnviarCorreo()
        {
            try
            {
                Vales DatosAux = this.ObtenerDatosVale();
                string Contenido = string.Empty;
                DatosAux = this.ObtenerDetalleValecORREO(DatosAux.IDVale);
                switch (DatosAux.IDTipoVale)
                {
                    case 1: Contenido = EnvioCorreo.GenerarHtmlPorcentajeDeDescuento(DatosAux);
                        break;
                    case 2: Contenido = EnvioCorreo.GenerarHtmlMontoEfectivo(DatosAux);
                        break;
                    case 3: Contenido = EnvioCorreo.GenerarHtmlNxN(DatosAux);
                        break;
                    case 4: Contenido = EnvioCorreo.GenerarHtmlMxN(DatosAux);
                        break;
                }
                foreach (var item in this.lstClientes)
                {
                    if (!string.IsNullOrEmpty(item.Correo))
                    {
                        EnvioCorreo.EnviarCorreo(
                            ConfigurationManager.AppSettings.Get("CorreoTxt")
                            , ConfigurationManager.AppSettings.Get("PasswordTxt")
                            , item.Correo
                            , item.AsusntoVales
                            , Contenido
                            , false
                            , ""
                            , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                            , ConfigurationManager.AppSettings.Get("HostTxt")
                            , Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                            , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Vales ObtenerDetalleValecORREO(string IDValeParE)
        {
            try
            {
                Vales DatosAux = new Vales { IDVale = IDValeParE, Conexion = Comun.Conexion };
                Vales_Negocio VN = new Vales_Negocio();
                return VN.ObtenerValeDetallecORREO(DatosAux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
