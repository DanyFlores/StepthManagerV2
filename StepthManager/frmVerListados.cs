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
    public partial class frmVerListados : Form
    {
        private int TipoListado = 0;
        private string ID = string.Empty;

        public frmVerListados(int Tipo, string AuxID)
        {
            try
            {
                InitializeComponent();
                this.ID = AuxID;
                this.TipoListado = Tipo;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVerListados ~ frmVerListados()");
            }
        }

        private void frmVerReporte_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
                this.CargarReporte();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVerListados ~ frmVerReporte_Load");
            }
        }

        private void CargarReporte()
        {
            try
            {
                switch (TipoListado)
                {
                    case 1: this.GenerarReporteReguardo();
                        this.lblTitulo.Text = "CARTA DE RESGUARDO";
                        break;
                    case 2: this.GenerarReporteComisiones();
                        this.lblTitulo.Text = "HOJA DE COMISIONES";
                        break;
                    case 3: this.GenerarReporteNominaSaldos();
                        this.lblTitulo.Text = "RESUMEN DE PERCEPCIONES Y DEDUCCIONES DE NÓMINA";
                        break;
                    case 4: this.GenerarReporteNominaDetalle();
                        this.lblTitulo.Text = "DETALLE DE DÍAS LABORADOS";
                        break;
                    case 5: this.GenerarReporteAux();
                        this.lblTitulo.Text = "Esto es una prueba";
                        break;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerarReporteReguardo()
        {
            try
            {
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.LocalReport.DataSources.Clear();
                MobiliarioResguardo Datos = new MobiliarioResguardo { IDMobiliarioResguardo = this.ID, Conexion = Comun.Conexion };
                MobiliarioResguardo_Negocio MRN = new MobiliarioResguardo_Negocio();
                List<Mobiliario> Lista = MRN.ObtenerMobiliarioResguardoDetalle(Datos);
                reportViewer1.LocalReport.EnableExternalImages = true;
                ReportParameter[] Parametros = new ReportParameter[3];
                Parametros[0] = new ReportParameter("Empresa", Comun.NombreComercial);
                Parametros[1] = new ReportParameter("Eslogan", Comun.Eslogan);
                if (File.Exists(@"Resources\Documents\" + Comun.UrlLogo.ToLower()))
                {
                    string Aux = new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri;
                    Parametros[2] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri);
                }
                else
                    Parametros[2] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\Default.jpg")).AbsoluteUri);

                this.reportViewer1.LocalReport.ReportEmbeddedResource = "StephManager.Informes.CartaResguardo.rdlc";
                reportViewer1.LocalReport.SetParameters(Parametros);
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Mobiliario", Lista));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerarReporteComisiones()
        {
            try
            {
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.LocalReport.DataSources.Clear();
                Comision Datos = new Comision { IDResumenComision = this.ID, Conexion = Comun.Conexion };
                Comision_Negocio CN = new Comision_Negocio();
                CN.ObtenerReporteComisiones(Datos);
                if (Datos.Completado)
                {
                    List<Comision> Lista01 = Datos.ListaComisiones;
                    List<Comision> Lista02 = Datos.ListaTiposComision;
                    reportViewer1.LocalReport.EnableExternalImages = true;
                    ReportParameter[] Parametros = new ReportParameter[8];
                    Parametros[0] = new ReportParameter("Empresa", Comun.NombreComercial);
                    Parametros[1] = new ReportParameter("Eslogan", Comun.Eslogan);
                    if (File.Exists(@"Resources\Documents\" + Comun.UrlLogo.ToLower()))
                    {
                        string Aux = new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri;
                        Parametros[2] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri);
                    }
                    else
                        Parametros[2] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\Default.jpg")).AbsoluteUri);
                    Parametros[3] = new ReportParameter("Direccion", Comun.DomicilioFiscal);
                    Parametros[4] = new ReportParameter("TituloReporte", "HOJA DE COMISIONES SEMANALES");
                    Parametros[5] = new ReportParameter("FechaInicio", Datos.FechaInicio.ToShortDateString());
                    Parametros[6] = new ReportParameter("FechaFin", Datos.FechaFin.ToShortDateString());
                    Parametros[7] = new ReportParameter("Sucursal", Datos.IDSucursal);

                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "StephManager.Informes.HojaComisiones.rdlc";
                    reportViewer1.LocalReport.SetParameters(Parametros);
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Comisiones", Lista01));
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("TiposComisiones", Lista02));
                    this.reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerarReporteNominaSaldos()
        {
            try
            {
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.LocalReport.DataSources.Clear();
                Nomina Datos = new Nomina { IDNomina = this.ID, Conexion = Comun.Conexion };
                Nomina_Negocio NN = new Nomina_Negocio();
                NN.ObtenerReporteNominaSaldos(Datos);
                if (Datos.Completado)
                {
                    List<Nomina> Lista01 = Datos.ListaNomina;
                    List<Nomina> Lista02 = Datos.ListaConceptos;
                    reportViewer1.LocalReport.EnableExternalImages = true;
                    ReportParameter[] Parametros = new ReportParameter[8];
                    Parametros[0] = new ReportParameter("Empresa", Comun.NombreComercial);
                    Parametros[1] = new ReportParameter("Eslogan", Comun.Eslogan);
                    if (File.Exists(@"Resources\Documents\" + Comun.UrlLogo.ToLower()))
                    {
                        string Aux = new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri;
                        Parametros[2] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri);
                    }
                    else
                        Parametros[2] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\Default.jpg")).AbsoluteUri);
                    Parametros[3] = new ReportParameter("Direccion", Comun.DomicilioFiscal);
                    Parametros[4] = new ReportParameter("TituloReporte", "RESUMEN DE PERCEPCIONES Y DEDUCCIONES DE NÓMINA");
                    Parametros[5] = new ReportParameter("Periodo", Datos.PeriodoFechas);
                    Parametros[6] = new ReportParameter("ClaveNomina", Datos.ClaveNomina);
                    Parametros[7] = new ReportParameter("Dias", Datos.DiasPeriodo.ToString());

                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "StephManager.Informes.ResumenNomina.rdlc";
                    reportViewer1.LocalReport.SetParameters(Parametros);
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Nomina", Lista01));
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DetalleNomina", Lista02));
                    this.reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerarReporteNominaDetalle()
        {
            try
            {
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.LocalReport.DataSources.Clear();
                Nomina Datos = new Nomina { IDNomina = this.ID, Conexion = Comun.Conexion };
                Nomina_Negocio NN = new Nomina_Negocio();
                NN.ObtenerReporteNominaDetalle(Datos);
                if (Datos.Completado)
                {
                    List<Nomina> Lista01 = Datos.ListaNomina;
                    reportViewer1.LocalReport.EnableExternalImages = true;
                    ReportParameter[] Parametros = new ReportParameter[8];
                    Parametros[0] = new ReportParameter("Empresa", Comun.NombreComercial);
                    Parametros[1] = new ReportParameter("Eslogan", Comun.Eslogan);
                    if (File.Exists(@"Resources\Documents\" + Comun.UrlLogo.ToLower()))
                    {
                        string Aux = new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri;
                        Parametros[2] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri);
                    }
                    else
                        Parametros[2] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\Default.jpg")).AbsoluteUri);
                    Parametros[3] = new ReportParameter("Direccion", Comun.DomicilioFiscal);
                    Parametros[4] = new ReportParameter("TituloReporte", "DETALLE DE DÍAS LABORADOS");
                    Parametros[5] = new ReportParameter("Periodo", Datos.PeriodoFechas);
                    Parametros[6] = new ReportParameter("ClaveNomina", Datos.ClaveNomina);
                    Parametros[7] = new ReportParameter("Dias", Datos.DiasPeriodo.ToString());

                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "StephManager.Informes.DetalleNomina.rdlc";
                    reportViewer1.LocalReport.SetParameters(Parametros);
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DetalleNomina", Lista01));
                    this.reportViewer1.RefreshReport();
                }
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
                LogError.AddExcFileTxt(ex, "frmVerListados ~ btnSalir_Click");
            }
        }

        List<PedidoDetalle> Lista0 = new List<PedidoDetalle>();
        List<Producto> Lista1 = new List<Producto>();
        List<Producto> Lista2 = new List<Producto>();
        private void GenerarReporteAux()
        {
            try
            {   
                //List<Producto> Lista1 = new List<Producto>();
                //List<Producto> Lista2 = new List<Producto>();
                this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
                Producto Item11 = new Producto { NombreProducto = "Servicio 01", Cantidad = 10 };
                Producto Item12 = new Producto { NombreProducto = "Servicio 02", Cantidad = 8 };
                Producto Item13 = new Producto { NombreProducto = "Servicio 03", Cantidad = 5 };
                Producto Item21 = new Producto { NombreProducto = "Servicio 04", Cantidad = 7 };
                Producto Item22 = new Producto { NombreProducto = "Servicio 05", Cantidad = 6 };
                Producto Item23 = new Producto { NombreProducto = "Servicio 06", Cantidad = 2 };
                Lista1.Add(Item11);
                Lista1.Add(Item12);
                Lista1.Add(Item13);
                Lista2.Add(Item21);
                Lista2.Add(Item22);
                Lista2.Add(Item23);
                PedidoDetalle Item01 = new PedidoDetalle { IDAsignacion = "0001", NombreProducto = "Producto01", ClaveProduccion = "A", ListaServiciosXClave = Lista1 };
                PedidoDetalle Item02 = new PedidoDetalle { IDAsignacion = "0002", NombreProducto = "Producto01", ClaveProduccion = "B", ListaServiciosXClave = Lista1 };
                PedidoDetalle Item03 = new PedidoDetalle { IDAsignacion = "0003", NombreProducto = "Producto01", ClaveProduccion = "C", ListaServiciosXClave = Lista2 };
                PedidoDetalle Item04 = new PedidoDetalle { IDAsignacion = "0004", NombreProducto = "Producto01", ClaveProduccion = "D", ListaServiciosXClave = Lista1 };
                PedidoDetalle Item05 = new PedidoDetalle { IDAsignacion = "0005", NombreProducto = "Producto01", ClaveProduccion = "E", ListaServiciosXClave = Lista1 };
                PedidoDetalle Item06 = new PedidoDetalle { IDAsignacion = "0006", NombreProducto = "Producto01", ClaveProduccion = "F", ListaServiciosXClave = Lista2 };
                Lista0.Add(Item01);
                Lista0.Add(Item02);
                Lista0.Add(Item03);
                Lista0.Add(Item04);
                Lista0.Add(Item05);
                Lista0.Add(Item06);

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.EnableExternalImages = true;
                ReportParameter[] Parametros = new ReportParameter[5];
                Parametros[0] = new ReportParameter("Empresa", Comun.NombreComercial);
                Parametros[1] = new ReportParameter("Eslogan", Comun.Eslogan);
                if (File.Exists(@"Resources\Documents\" + Comun.UrlLogo.ToLower()))
                {
                    string Aux = new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri;
                    Parametros[2] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri);
                }
                else
                    Parametros[2] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\Default.jpg")).AbsoluteUri);
                Parametros[3] = new ReportParameter("Direccion", Comun.DomicilioFiscal);
                Parametros[4] = new ReportParameter("TituloReporte", "ESTO ES UNA PRUEBA");
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "StephManager.Informes.UsosClaves.rdlc";
                reportViewer1.LocalReport.SetParameters(Parametros);
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Claves", Lista0));
                
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            try
            {
                ReportParameterInfoCollection Aux = e.Parameters;
                if (Aux != null)
                {
                    if (Aux.Count > 0)
                    {
                        IList<string> Lista = Aux[0].Values;
                        string Valor = Lista[0].ToString();
                        PedidoDetalle Source = Lista0.Find(x => x.IDAsignacion == Valor);
                        if (Source != null)
                            e.DataSources.Add(new ReportDataSource("Producto", Source.ListaServiciosXClave));
                        else
                            e.DataSources.Add(new ReportDataSource("Producto", new List<Producto>()));
                    }
                    else
                        e.DataSources.Add(new ReportDataSource("Producto", new List<Producto>()));
                }
                else
                    e.DataSources.Add(new ReportDataSource("Producto", new List<Producto>()));
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVerListados ~ SubreportProcessingEventHandler");
            }
        }

    }
}
