using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using CreativaSL.Dll.Validaciones;
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
    public partial class frmNuevaNomina : Form
    {

        private int IDTipoNomina = 0;
        private bool AllowClick = true;

        #region Constructores

        public frmNuevaNomina(int TipoNomina)
        {
            try
            {
                InitializeComponent();
                IDTipoNomina = TipoNomina;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaNomina ~ frmNuevaNomina()");
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
                this.LlenarGridUsuario(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridUsuario(bool Band)
        {
            try
            {
                Nomina DatosAux = new Nomina { Conexion = Comun.Conexion, IDTipoNomina = this.IDTipoNomina };
                Nomina_Negocio CN = new Nomina_Negocio();
                CN.ObtenerEmpleadosNomina(DatosAux);
                this.dgvUsuario.AutoGenerateColumns = false;
                this.dgvUsuario.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Usuario ObtenerDatosUsuario(int RowData)
        {
            try
            {
                Usuario DatosAux = new Usuario();
                if (RowData > -1) 
                {
                    DataGridViewRow FilaDatos = this.dgvUsuario.Rows[RowData];
                    DatosAux.IDEmpleado = FilaDatos.Cells["IDEmpleado"].Value.ToString();                    
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Abort;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaNomina ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevaNomina_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaNomina ~ frmNuevaNomina_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void dgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (this.dgvUsuario.Columns[e.ColumnIndex].Name == "Conceptos")
                    {
                        Usuario Datos = this.ObtenerDatosUsuario(e.RowIndex);
                        frmNominaConceptos Conceptos = new frmNominaConceptos(Datos.IDEmpleado, this.IDTipoNomina);
                        this.Visible = false;
                        Conceptos.ShowDialog();
                        Conceptos.Dispose();
                        this.Visible = true;
                        if (Conceptos.DialogResult == DialogResult.OK)
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmNuevaNomina ~ dgvUsuario_CellContentClick");
            }
        }

        private void btnGenerarNomina_Click(object sender, EventArgs e)
        {
            try
            {
                if (AllowClick)
                {
                    frmNominaFechas EstablecerFechas = new frmNominaFechas();
                    EstablecerFechas.ShowDialog();
                    EstablecerFechas.Dispose();
                    if (EstablecerFechas.DialogResult == DialogResult.OK)
                    {
                        DateTime FI = EstablecerFechas.FechaInicio;
                        DateTime FF = EstablecerFechas.FechaFin;
                        Nomina Datos = new Nomina { Conexion = Comun.Conexion, IDUsuario = Comun.IDUsuario, FechaInicio = FI, FechaFin = FF, IDTipoNomina = this.IDTipoNomina };
                        AllowClick = false;
                        lblMessage.Visible = true;
                        Cursor = Cursors.WaitCursor;
                        bgwGenerarNomina.RunWorkerAsync(Datos);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaNomina ~ btnGenerarNomina_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgwGenerarNomina_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (e.Argument != null)
                {
                    Nomina Datos = null;
                    try
                    {
                        Datos = (Nomina)e.Argument;
                    }
                    catch (Exception) { }
                    if (Datos != null)
                    {
                        Nomina_Negocio NN = new Nomina_Negocio();
                        NN.GenerarNomina(Datos);
                        if (Datos.Completado)
                        {
                            e.Result = Datos;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaNomina ~ bgwGenerarNomina_DoWork");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgwGenerarNomina_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    Nomina Datos = null;
                    try
                    {
                        Datos = (Nomina)e.Result;
                    }
                    catch (Exception) { }
                    if (Datos != null)
                    {
                        if (Datos.Completado)
                        {
                            frmVerListados Reporte = new frmVerListados(3, Datos.IDNomina);
                            this.Visible = false;
                            Reporte.ShowDialog();
                            Reporte.Dispose();
                            this.Visible = true;
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo generar el reporte. (1)", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo generar el reporte. (2)", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo generar el reporte. (3)", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exe)
            {
                LogError.AddExcFileTxt(exe, "frmNuevaNomina ~ btnGenerarNomina_Click ~ bgwGenerarNomina_RunWorkerCompleted");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
            finally
            {
                AllowClick = true;
                lblMessage.Visible = false;
                Cursor = Cursors.Default;
            }
        }
    }
}
