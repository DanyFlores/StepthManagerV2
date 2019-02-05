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
    public partial class frmVerReporteConsumoMaterial : Form
    {
        public int IDReporte = -1;
        public frmVerReporteConsumoMaterial(int _IDReporte)
        {
            try
            {
                InitializeComponent();
                IDReporte = _IDReporte;
            }
            catch (Exception ex)
            {

                LogError.AddExcFileTxt(ex, "frmVerReporteConsumoMaterial ~ frmVerReporteConsumoMaterial()");
            }
        }
        #region Eventos
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVerReporteConsumoMaterial ~ btnSalir_Click");
            }
        }
        #endregion
        #region Metodos
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
                this.GenerarGarantias();
                this.lblTitulo.Text = "CONSUMO DE MATERIAL";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void GenerarGarantias()
        {
            try
            {
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.LocalReport.DataSources.Clear();
                
                ReporteConsumoMaterial_Negocio repNeg = new ReporteConsumoMaterial_Negocio();
                ReporteConsumoMaterial Lista = repNeg.ObtenerDetalleReporteConsumoMaterial(Comun.Conexion.ToString(),IDReporte);
                foreach (ReporteConsumoMaterialDetalle Item in Lista.Detalle)
                {
                    Item.ImagenMetrica = Item.CumpleMetrica ? new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Apply.png")).AbsoluteUri : new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\descarga.png")).AbsoluteUri;
                }
                reportViewer1.LocalReport.EnableExternalImages = true;
                ReportParameter[] Parametros = new ReportParameter[8];
                Parametros[0] = new ReportParameter("Empresa", Comun.NombreComercial);
                Parametros[1] = new ReportParameter("Eslogan", Comun.Eslogan);
                Parametros[2] = new ReportParameter("Direccion", Comun.Direccion);
                Parametros[3] = new ReportParameter("TituloReporte", "REPORTE DE CONSUMO DE MATERIAL POR PERIODO");
                if (File.Exists(@"Resources\Documents\" + Comun.UrlLogo.ToLower()))
                {
                    string Aux = new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri;
                    Parametros[4] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri);
                }
                else
                    Parametros[4] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\Default.jpg")).AbsoluteUri);
                Parametros[5] = new ReportParameter("FechaInicio", Lista.FechaInicio.ToShortDateString());
                Parametros[6] = new ReportParameter("FechaFin", Lista.FechaFin.ToShortDateString());
                Parametros[7] = new ReportParameter("Sucursal", Lista.Sucursal);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "StephManager.Informes.Reportes.ConsumoMaterial.rdlc";
                reportViewer1.LocalReport.SetParameters(Parametros);
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ConsumoMaterial", Lista.Detalle));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void frmVerReporteConsumoMaterial_Load(object sender, EventArgs e)
        {
            try
            {
                IniciarForm();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
