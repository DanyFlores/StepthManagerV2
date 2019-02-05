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
    public partial class frmTransferenciaMateriales : Form
    {
        #region Constructores

        public frmTransferenciaMateriales()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmTransferenciaMateriales ~ frmTransferenciaMateriales()");
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
                TransferenciaMateriales_Negocio Neg = new TransferenciaMateriales_Negocio();
                List<TransferenciaMateriales> Lista = Neg.ObtenerTransferenciaMateriales(Comun.Conexion);
                this.dgvTransferencia.AutoGenerateColumns = false;
                this.dgvTransferencia.DataSource = Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Este metodo llena el grid principal de los reportes de acuerdo a el filtro de busqueda
        /// muestra los resultados que son iguales.
        /// </summary>
        /// <param name="fechaBuscar"> Es el valor de la fecha que se eligio en la interfaz</param>
        private void LlenarGridBusqueda(DateTime fechaBuscar)
        {
            try
            {

                DateTime fecha = DateTime.MinValue;
                fecha=fecha.AddDays((double)fechaBuscar.Day-1);
                fecha=fecha.AddMonths(fechaBuscar.Month-1);
                fecha=fecha.AddYears(fechaBuscar.Year-1);
                TransferenciaMateriales_Negocio a = new TransferenciaMateriales_Negocio();
                List<TransferenciaMateriales> Lista = a.ObtenerTransferenciaMaterialesBusqueda(Comun.Conexion,fecha);
                this.dgvTransferencia.AutoGenerateColumns = false;
                this.dgvTransferencia.DataSource = Lista;
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
        private TransferenciaMaterialesGeneral ObtenerDatosReporte()
        {
            try
            {
                TransferenciaMaterialesGeneral DatosAux = new TransferenciaMaterialesGeneral();
                Int32 RowData = this.dgvTransferencia.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowData > -1)
                {
                    int ID = 0;
                    DataGridViewRow FilaDatos = this.dgvTransferencia.Rows[RowData];
                    int.TryParse(FilaDatos.Cells["IDTransferencia"].Value.ToString(), out ID);

                    DatosAux.IDTransferencia = ID;
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
                frmNuevaTransferenciaMateriales GenerarReporte = new frmNuevaTransferenciaMateriales();
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
                LogError.AddExcFileTxt(ex, "frmTransferenciaMateriales ~ btnNuevo_Click");
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
                LogError.AddExcFileTxt(ex, "frmTransferenciaMateriales ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnImpresion_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.dgvTransferencia.SelectedRows.Count == 1)
                {
                    this.Visible = false;
                    TransferenciaMaterialesGeneral Datos = this.ObtenerDatosReporte();
                    frmVerReporteTransferenciaMateriales VerReporte = new frmVerReporteTransferenciaMateriales(Datos.IDTransferencia);
                    VerReporte.ShowDialog();
                    VerReporte.Dispose();
                    
                    this.Visible = true;
                }
                else
                {
                    MessageBox.Show("Seleccione una fila.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmTransferenciaMateriales ~ btnImpresion_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTransferenciaMateriales_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmTransferenciaMateriales ~ frmTransferenciaMateriales_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void label42_Click(object sender, EventArgs e)
        {

        }

        

        

        private void dgvTransferencia_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
