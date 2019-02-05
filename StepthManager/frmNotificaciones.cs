using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using CreativaSL.Dll.Validaciones;
using StephManager.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephManager
{
    public partial class frmNotificaciones : Form
    {
        #region Variables

        private bool Busqueda = false;
        private string TextoBusq = string.Empty;
        private frmWait Espere = new frmWait();
        #endregion

        #region Constructor

        public frmNotificaciones()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNotificaciones ~ frmNotificaciones()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
                this.CargarGridNotificaciones(false);
                this.ActiveControl = this.txtTagBusqueda;
                this.txtTagBusqueda.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridNotificaciones(bool Band)
        {
            try
            {
                Notificaciones DatosAux = new Notificaciones { Conexion = Comun.Conexion, Todos = Band };
                Notificaciones_Negocio NN = new Notificaciones_Negocio();
                NN.ObtenerNotificaciones(DatosAux);
                this.dgvNotificaciones.AutoGenerateColumns = false;
                this.dgvNotificaciones.DataSource = DatosAux.TablaDatos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private CatalogoWeb ObtenerDatosGrid(int RowIndex)
        {
            try
            {
                CatalogoWeb DatosAux = new CatalogoWeb();
                List<CatalogoWeb> Lista = (List<CatalogoWeb>)this.dgvNotificaciones.DataSource;
                DatosAux = Lista[RowIndex];
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BusquedaNotificaciones()
        {
            try
            {
                if (!this.chkBuscarXFecha.Checked && !this.chkBuscarXNotificacion.Checked)
                {
                    MessageBox.Show("Debe seleccionar al menos un criterio de Búsqueda.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Notificaciones DatosAux = new Notificaciones
                    {
                        Conexion = Comun.Conexion,
                        BusqNotificaciones = chkBuscarXNotificacion.Checked,
                        BusqFechas = chkBuscarXFecha.Checked,
                        Descripcion = string.Empty
                    };
                    if (this.chkBuscarXNotificacion.Checked)
                    {
                        if (string.IsNullOrEmpty(this.txtTagBusqueda.Text.Trim()))
                        {
                            MessageBox.Show("Ingrese el nombre de la notificación. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        DatosAux.Descripcion = this.txtTagBusqueda.Text.Trim();
                    }
                    if (this.chkBuscarXFecha.Checked)
                    {
                        if (this.dtpFecha.Value > this.dtpFecha2.Value)
                        {
                            MessageBox.Show("La fecha tiene que se mayor a la actual", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        DatosAux.FechaBusq = this.dtpFecha.Value;
                        DatosAux.FechaBusq2 = this.dtpFecha2.Value;
                    }
                    Notificaciones_Negocio MN = new Notificaciones_Negocio();
                    MN.ObtenerNotificacionesBusqueda(DatosAux);
                    this.dgvNotificaciones.AutoGenerateColumns = false;
                    this.dgvNotificaciones.DataSource = DatosAux.TablaDatos;
                    Busqueda = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Notificaciones ObtenerDatosNotificaciones()
        {
            try
            {
                Notificaciones DatosAux = new Notificaciones();
                Int32 RowData = this.dgvNotificaciones.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowData > -1)
                {
                    DataGridViewRow FilaDatos = this.dgvNotificaciones.Rows[RowData];
                    DatosAux.IDNotificaciones = FilaDatos.Cells["IDNotificacion"].Value.ToString();
                    int IDTipo = 0;
                    int.TryParse(FilaDatos.Cells["IDTipoNotificacion"].Value.ToString(), out IDTipo);
                    DatosAux.IDTipoNotificaciones = IDTipo;
                    DatosAux.IDNivelEntrega = FilaDatos.Cells["IDNivelEntrega"].Value.ToString();
                    DatosAux.NombreNotificaciones = FilaDatos.Cells["NombreNotificacion"].Value.ToString();
                    DatosAux.DescripcionNotificacion = FilaDatos.Cells["DecripcionNotificacion"].Value.ToString();
                    DatosAux.Descripcion = FilaDatos.Cells["TipoNotificacion"].Value.ToString();
                    DatosAux.IDCliente = FilaDatos.Cells["IDCliente"].Value.ToString();
                    bool Enviada = false;
                    bool.TryParse(FilaDatos.Cells["EnviarNotificacion"].Value.ToString(), out Enviada);
                    DatosAux.EnviarNotificacion = Enviada;
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
                this.BusquedaNotificaciones();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNotificaciones ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void btnCancelarBusq_Click(object sender, EventArgs e)
        {
            try
            {
                if (Busqueda)
                {
                    this.Busqueda = false;
                    this.txtTagBusqueda.Text = string.Empty;
                    this.chkBuscarXNotificacion.Checked = false;
                    this.chkBuscarXFecha.Checked = false;
                    this.CargarGridNotificaciones(false);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNotificaciones ~ btnCancelarBusq_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCatalogoWeb_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNotificaciones ~ frmCatalogoWeb_Load");
            }
        }

        private void txtTagBusqueda_KeyPress(object sender, KeyPressEventArgs e)
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
                LogError.AddExcFileTxt(ex, "frmNotificaciones ~ txtTagBusqueda_KeyPress");
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevos_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevaNotificacion NNotificacion = new frmNuevaNotificacion();
                NNotificacion.ShowDialog();
                NNotificacion.Dispose();
                this.Visible = true;
                if (NNotificacion.DialogResult == DialogResult.OK)
                {
                    this.CargarGridNotificaciones(false);
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmNotificaciones ~ btnNuevos_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarr_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarr_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvNotificaciones.SelectedRows.Count == 1)
                {
                    Notificaciones DatosAux = this.ObtenerDatosNotificaciones();
                    if (!string.IsNullOrEmpty(DatosAux.IDNotificaciones))
                    {
                        DatosAux.Conexion = Comun.Conexion;
                        DatosAux.IDUsuario = Comun.IDUsuario;
                        Notificaciones_Negocio NN = new Notificaciones_Negocio();
                        NN.EliminarNotificaciones(DatosAux);
                        if (DatosAux.Completado)
                        {
                            MessageBox.Show("Notificacion eliminada correctamente", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Int32 RowToDelete = this.dgvNotificaciones.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                            if (RowToDelete > -1)
                                this.dgvNotificaciones.Rows.RemoveAt(RowToDelete);
                            else
                                this.CargarGridNotificaciones(false);
                        }
                        else
                        {
                            MessageBox.Show("Error al guardar los datos. Contacte a Soporte Técnico.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNotificaciones ~ btnEliminar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalirr_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNotificaciones ~ btnSalirr_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarGridNotificaciones(true);
                this.Busqueda = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNotificaciones ~ btnTodos_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReenvio_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvNotificaciones.SelectedRows.Count == 1)
                {
                    try
                    {
                        Notificaciones DatosAux = this.ObtenerDatosNotificaciones();
                        if (!string.IsNullOrEmpty(DatosAux.IDNotificaciones))
                        {
                            if (MessageBox.Show("¿Está seguro de reenviar las notificaciones?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Notificaciones_Negocio NN = new Notificaciones_Negocio();
                                DatosAux.Conexion = Comun.Conexion;
                                if (DatosAux.EnviarNotificacion == true)
                                {
                                    try
                                    {
                                        Espere = new frmWait();
                                        this.bgwEnvioNotificaciones.RunWorkerAsync(DatosAux);
                                        Espere.ShowDialog();
                                    }
                                    catch (Exception ex)
                                    {
                                        LogError.AddExcFileTxt(ex, "frmNotificaciones ~  btnReenvio_Click ~ if (DatosAux.EnviarNotificacion == true)");
                                        MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                        else
                            MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNotificaciones ~ btnReenvio_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgwEnvioNotificaciones_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Notificaciones DatosAux = this.ObtenerDatosNotificaciones();
                Notificaciones_Negocio NN = new Notificaciones_Negocio();
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                NN.ObtenerReenvioNotificacion(DatosAux);
                int total = DatosAux.tablaNotificaciones.Rows.Count;
                int cont = 0;
                foreach (DataRow notificacion in DatosAux.tablaNotificaciones.Rows)
                {
                    int IDTipoCelular = 0, Badge = 0;
                    IDTipoCelular = Convert.ToInt32(notificacion["id_tipoCelular"].ToString());
                    Badge = Convert.ToInt32(notificacion["Badge"].ToString());
                    EnviaNotificaciones.EnviarMensaje(notificacion["tokenCelular"].ToString(), notificacion["nombre"].ToString(), notificacion["descripcion"].ToString(), Badge, IDTipoCelular);
                    cont++;
                    this.bgwEnvioNotificaciones.ReportProgress((cont * 100) / total);
                    if (cont == total)
                        System.Threading.Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNotificaciones ~ bgwEnvioNotificaciones_DoWork");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgwEnvioNotificaciones_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                this.Espere.ActualizarProgreso(e.ProgressPercentage);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNotificaciones ~ bgwEnvioNotificaciones_ProgressChanged");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgwEnvioNotificaciones_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.Espere.DialogResult = DialogResult.OK;
                this.Espere.Dispose();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNotificaciones ~ bgwEnvioNotificaciones_RunWorkerCompleted");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}