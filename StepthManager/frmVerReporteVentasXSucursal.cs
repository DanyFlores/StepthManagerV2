using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using Microsoft.Reporting.WinForms;
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
    public partial class frmVerReporteVentasXSucursal : Form
    {
        #region Propiedades / Variables
        public int IDReporte = -1;
        #endregion

        #region Constructores
        public frmVerReporteVentasXSucursal(int _IDReporte)
        {
            try
            {
                InitializeComponent();
                IDReporte = _IDReporte;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVerReporteVentasXSucursal ~ frmVerReporteVentasXSucursal()");
            }
        }
        #endregion

        #region Métodos
        private void IniciarForm()
        {
            try
            {
                CargarReporte();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarReporte()
        {
            try
            {
                this.GenerarReporteVentasXSucursal();
                this.lblTitulo.Text = "REPORTE DE VENTAS POR SUCURSAL";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerarReporteVentasXSucursal()
        {
            try
            {
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.LocalReport.DataSources.Clear();
                ReporteVentasXSucursal_Negocio  Neg1 = new ReporteVentasXSucursal_Negocio();
                ReportesVentaXSucursal DatosReporte = Neg1.ObtenerDetalleReporteVentasXSucursal(Comun.Conexion, IDReporte);
                reportViewer1.LocalReport.EnableExternalImages = true;
                ReportParameter[] Parametros = new ReportParameter[8];
                Parametros[0] = new ReportParameter("Empresa", Comun.NombreComercial);
                Parametros[1] = new ReportParameter("Eslogan", Comun.Eslogan);
                Parametros[2] = new ReportParameter("Direccion", Comun.Direccion);
                Parametros[3] = new ReportParameter("TituloReporte", "REPORTE DE VENTAS POR SUCURSAL");
                if (File.Exists(@"Resources\Documents\" + Comun.UrlLogo.ToLower()))
                {
                    string Aux = new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri;
                    Parametros[4] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri);
                }
                else
                    Parametros[4] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\Default.jpg")).AbsoluteUri);
               Parametros[5] = new ReportParameter("FechaInicio", DatosReporte.FechaInicio.ToShortDateString());
               Parametros[6] = new ReportParameter("FechaFin", DatosReporte.FechaFin.ToShortDateString());
                Parametros[7] = new ReportParameter("Sucursal", DatosReporte.NombreSucursal);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "StephManager.Informes.Reportes.VentasXSucursal.rdlc";
                reportViewer1.LocalReport.SetParameters(Parametros);
               reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DatosReporte.Detalle2));
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", DatosReporte.Detalle1));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Eventos
        private void frmVerReporteVentasXSucursal_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVerReporteVentasXSucursal ~ frmVerReporteVentasXSucursal_Load");
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
                LogError.AddExcFileTxt(ex, "frmVerReporteVentasXSucursal ~ btnSalir_Click");
            }
        }
        #endregion
    }
}

