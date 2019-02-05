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
    public partial class frmReportesComprasPorProveedor : Form
    {
        #region Constructores

        public frmReportesComprasPorProveedor()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReportesComprasPorProveedor ~ frmReportesComprasPorProveedor()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                this.LlenarGrid();
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

        /// <summary>
        /// Metodo que llena el grid principal de los reportes generados
        /// </summary>
        private void LlenarGrid()
        {
            try
            {
                ReporteComprasPorProveedor_Negocio Neg = new ReporteComprasPorProveedor_Negocio();
                List<ReporteComprasPorProveedor> Lista = Neg.ObtenerReportesComprasPorProveedor(Comun.Conexion);
                this.dgvComprasPorProveedor.AutoGenerateColumns = false;
                this.dgvComprasPorProveedor.DataSource = Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Este metodo llena el grid principal de los reportes de acuerdo a la fecha que se introduce
        /// muestra los resultados que son iguales o si se encuentran en el rango del reporte.
        /// </summary>
        /// <param name="fechaBuscar"> Es el valor de la fecha que se eligio en la interfaz</param>
        private void LlenarGridBusqueda(DateTime fechaBuscar)
        {
            try
            {
                ReporteComprasPorProveedor_Negocio a = new ReporteComprasPorProveedor_Negocio();
                List<ReporteComprasPorProveedor> Lista = a.ObtenerReporteComprasPorProveedorBusqueda(Comun.Conexion,fechaBuscar);
                this.dgvComprasPorProveedor.AutoGenerateColumns = false;
                this.dgvComprasPorProveedor.DataSource = Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene los datos del reporte
        /// </summary>
        /// <returns></returns>
        private ReporteComprasPorProveedor ObtenerDatosReporte()
        {
            try
            {
                ReporteComprasPorProveedor DatosAux = new ReporteComprasPorProveedor();
                Int32 RowData = this.dgvComprasPorProveedor.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowData > -1)
                {
                    int ID = 0;
                    DataGridViewRow FilaDatos = this.dgvComprasPorProveedor.Rows[RowData];
                    int.TryParse(FilaDatos.Cells["IDReporte"].Value.ToString(), out ID);
                    DatosAux.IDReporte = ID;
                    
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

        /// <summary>
        /// Abre el frame para generar un nuevo reporte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmNuevoReporteComprasPorProveedor GenerarReporte = new frmNuevoReporteComprasPorProveedor();
                GenerarReporte.ShowDialog();
                if(GenerarReporte.DialogResult == DialogResult.OK)
                {
                    LlenarGrid();
                }
                GenerarReporte.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReportesComprasPorProveedor ~ btnNuevo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Abort;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReportesComprasPorProveedor ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnImpresion_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.dgvComprasPorProveedor.SelectedRows.Count == 1)
                {
                    this.Visible = false;
                    ReporteComprasPorProveedor Datos = this.ObtenerDatosReporte();
                    frmVerReporteComprasPorProveedor VerReporte = new frmVerReporteComprasPorProveedor(Datos.IDReporte);
                    VerReporte.ShowDialog();
                    VerReporte.Dispose();
                    //this.DialogResult = DialogResult.OK;
                    this.Visible = true;
                }
                else
                {
                    MessageBox.Show("Seleccione una fila.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReportesComprasPorProveedor ~ btnImpresion_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmReportesComprasPorProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReportesComprasPorProveedor ~ frmReportesComprasPorProveedor_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void label42_Click(object sender, EventArgs e)
        {

        }
        
        
        private void dtpFechaBuscar_ValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Evento del clic cuando presiona buscar por fecha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Creativa1_Click(object sender, EventArgs e)
        {
            //BOTON BUSCAR POR FECHA
            DateTime fechaBuscar = dtpFechaBuscar.Value;
            LlenarGridBusqueda(fechaBuscar);
            if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
            {
                this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
            }
        }

        /// <summary>
        /// Evento de click cuando preciona el boton "Quitar busqueda" solo manda a llamar el grid de llenado normal 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelarBusq_Click(object sender, EventArgs e)
        {
            //BOTON QUITAR BUSQUEDA
            this.LlenarGrid();
            if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
            {
                this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
            }
        }

        
    }
}
