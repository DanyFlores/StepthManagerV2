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
    public partial class frmVerReporteComprasCliente : Form
    {
        #region Propiedades / Variables
        public int IDReporte = -1;
        #endregion

        #region Constructores
        public frmVerReporteComprasCliente(int _IDReporte)
        {
            try
            {
                InitializeComponent();
                IDReporte = _IDReporte;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVerReporteComprasCliente ~ frmVerReporteComprasCliente()");
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
                this.GenerarReporteComprasCliente();
                this.lblTitulo.Text = "REPORTE DE VISITAS DE CLIENTE";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private List<Error> ValidarDatos(ReporteComprasCliente DatosReporte)
        {
            try
            {
                List<Error> Errores = new List<Error>();
                foreach (var a in DatosReporte.Detalle)
                {
                    if (a.Total <= 0)
                    {
                        Errores.Add(new Error { Numero = 2, Descripcion = "El Cliente no cuenta con Registros de Venta" });
                    }
                    else { }
                }
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerarReporteComprasCliente()
        {
            try
            {
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.LocalReport.DataSources.Clear();
                Reporte_NegocioComprasCliente Neg = new Reporte_NegocioComprasCliente();
                ReporteComprasCliente DatosReporte = Neg.ObtenerDetalleReporteComprasCliente(Comun.Conexion, IDReporte);
                
                    reportViewer1.LocalReport.EnableExternalImages = true;
                    ReportParameter[] Parametros = new ReportParameter[9];
                    Parametros[0] = new ReportParameter("Empresa", Comun.NombreComercial);
                    Parametros[1] = new ReportParameter("Eslogan", Comun.Eslogan);
                    Parametros[2] = new ReportParameter("Direccion", Comun.Direccion);
                    Parametros[3] = new ReportParameter("TituloReporte", "REPORTE DE VISITAS DE CLIENTE");
                    if (File.Exists(@"Resources\Documents\" + Comun.UrlLogo.ToLower()))
                    {
                        string Aux = new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri;
                        Parametros[4] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri);
                    }
                    else
                        Parametros[4] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\Default.jpg")).AbsoluteUri);
                    Parametros[5] = new ReportParameter("FechaInicio", DatosReporte.FechaInicio.ToShortDateString());
                    Parametros[6] = new ReportParameter("FechaFin", DatosReporte.FechaFin.ToShortDateString());
                    Parametros[7] = new ReportParameter("IDCliente", DatosReporte.IDCliente);
                   
                    Parametros[8] = new ReportParameter("NombreCliente", DatosReporte.Nombre);
                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "StephManager.Informes.Reportes.ComprasCliente.rdlc";
                    reportViewer1.LocalReport.SetParameters(Parametros);
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ReporteComprasCliente", DatosReporte.Detalle));
                    this.reportViewer1.RefreshReport();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Eventos
        private void frmVerReporteComprasCliente_Load(object sender, EventArgs e)
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
                LogError.AddExcFileTxt(ex, "frmVerReporteComprasCliente ~ frmVerReporteComprasCliente_Load");
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
                LogError.AddExcFileTxt(ex, "frmVerReporteComprasCliente ~ btnSalir_Click");
            }
        }
        #endregion
    }
}
