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
    public partial class frmVerReporteComprasPorProveedor : Form
    {

        public int IDReporte = -1;

        public frmVerReporteComprasPorProveedor(int _IDReporte)
        {
            try
            {
                InitializeComponent();
                IDReporte = _IDReporte;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVerReporteComprasPorProveedor ~ frmVerReporteComprasPorProveedor()");
            }
        }

        private void frmVerReporteComprasPorProveedor_Load(object sender, EventArgs e)
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
                LogError.AddExcFileTxt(ex, "frmVerReporteComprasPorProveedor ~ frmVerReporteComprasPorProveedor_Load");
            }
        }
        
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
                this.GenerarReporteComprasPorProveedor();
                this.lblTitulo.Text = "REPORTE DE COMPRAS POR PROVEEDOR";           
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerarReporteComprasPorProveedor()
        {
            try
            {
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.LocalReport.DataSources.Clear();
                ReporteComprasPorProveedor_Negocio Neg = new ReporteComprasPorProveedor_Negocio();
                ReporteComprasPorProveedor DatosReporte = Neg.ObtenerDetalleReporteComprasPorProveedor(Comun.Conexion, IDReporte);
                reportViewer1.LocalReport.EnableExternalImages = true;
                ReportParameter[] Parametros = new ReportParameter[7];
                Parametros[0] = new ReportParameter("Empresa", Comun.NombreComercial);
                Parametros[1] = new ReportParameter("Eslogan", Comun.Eslogan);
                Parametros[2] = new ReportParameter("Direccion", Comun.Direccion);
                Parametros[3] = new ReportParameter("TituloReporte", "REPORTE DE COMPRAS POR PROVEEDOR");
                if (File.Exists(@"Resources\Documents\" + Comun.UrlLogo.ToLower()))
                {
                    string Aux = new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri;
                    Parametros[4] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri);
                }
                else
                    Parametros[4] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\Default.jpg")).AbsoluteUri);
                Parametros[5] = new ReportParameter("FechaInicio", DatosReporte.FechaInicio.ToShortDateString());
                Parametros[6] = new ReportParameter("FechaFin", DatosReporte.FechaFin.ToShortDateString());
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "StephManager.Informes.Reportes.ComprasPorProveedor.rdlc";
                reportViewer1.LocalReport.SetParameters(Parametros);
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ComprasPorProveedor", DatosReporte.Detalle));
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ComprasPorProveedorMobiliario", DatosReporte.DetalleMob));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                throw ex;
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
                LogError.AddExcFileTxt(ex, "frmVerReporteComprasPorProveedor ~ btnSalir_Click");
            }
        }
    }
}
