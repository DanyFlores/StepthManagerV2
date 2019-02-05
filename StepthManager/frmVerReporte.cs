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
    public partial class frmVerReporte : Form
    {
        private int TipoListado = 0;

        public frmVerReporte(int Tipo)
        {
            try
            {
                InitializeComponent();
                this.TipoListado = Tipo;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVerReporte ~ frmVerReporte()");
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
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVerReporte ~ frmVerReporte_Load");
            }
        }

        private List<Sucursal> ObtenerComboSucursales()
        {
            try
            {
                Sucursal _datos = new Sucursal { Conexion = Comun.Conexion, Opcion = 2 };
                Sucursal_Negocio sucNeg = new Sucursal_Negocio();
                List<Sucursal> Lista = sucNeg.LlenarComboCatSucursales(_datos);
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboSucursales(List<Sucursal> _lista)
        {
            try
            {
                this.cmbSucursal.DataSource = _lista;
                this.cmbSucursal.ValueMember = "IDSucursal";
                this.cmbSucursal.DisplayMember = "NombreSucursal";
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private Sucursal ObtenerElementoComboSuc()
        {
            try
            {
                Sucursal _value = new Sucursal();
                if(this.cmbSucursal.Items.Count > 0)
                {
                    if(this.cmbSucursal.SelectedIndex != -1)
                    {
                        _value = (Sucursal)this.cmbSucursal.SelectedItem;
                    }
                }
                return _value;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void IniciarForm()
        {
            try
            {
                switch (TipoListado)
                {
                    case 1:
                        lblCombo01.Visible = true;
                        cmbSucursal.Visible = true;
                        lblFechaInicio.Visible = false;
                        dtpFechaInicio.Visible = false;
                        lblFechaFinal.Visible = false;
                        dtpFechaFinal.Visible = false;
                        this.LlenarComboSucursales(this.ObtenerComboSucursales());
                        break;
                    case 2:
                        lblCombo01.Visible = false;
                        cmbSucursal.Visible = false;
                        lblFechaInicio.Visible = true;
                        dtpFechaInicio.Visible = true;
                        lblFechaFinal.Visible = true;
                        dtpFechaFinal.Visible = true;
                        break;
                    case 3:
                        lblCombo01.Visible = true;
                        cmbSucursal.Visible = true;
                        lblFechaInicio.Visible = true;
                        dtpFechaInicio.Visible = true;
                        lblFechaFinal.Visible = true;
                        dtpFechaFinal.Visible = true;
                        this.LlenarComboSucursales(this.ObtenerComboSucursales());
                        break;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void CargarReporte()
        {
            try
            {
                switch (TipoListado)
                {
                    case 1:
                        this.GenerarReporteReguardo();
                        this.lblTitulo.Text = "REPORTE DE MATERIALES EN PRODUCCIÓN";
                        break;
                    case 2:
                        this.GenerarReporteServiciosRealizados();
                        this.lblTitulo.Text = "REPORTE DE SERVICIOS REALIZADOS";
                        break;
                    case 3:
                        this.GenerarReporteConsumoMaterial();
                        this.lblTitulo.Text = "REPORTE DE CONSUMO DE MATERIAL";
                        break;
                        //case 4:
                        //    this.GenerarReporteNominaDetalle();
                        //    this.lblTitulo.Text = "DETALLE DE DÍAS LABORADOS";
                        //    break;
                        //case 5:
                        //    this.GenerarReporteAux();
                        //    this.lblTitulo.Text = "Esto es una prueba";
                        //    break;
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
                Sucursal Datos = this.ObtenerElementoComboSuc();
                Datos.Conexion = Comun.Conexion;
                Reporte_Negocio repNeg = new Reporte_Negocio();
                object[] Listas = repNeg.ObtenerReporteMaterialesProduccion(Datos);
                reportViewer1.LocalReport.EnableExternalImages = true;
                ReportParameter[] Parametros = new ReportParameter[6];
                Parametros[0] = new ReportParameter("Empresa", Comun.NombreComercial);
                Parametros[1] = new ReportParameter("Eslogan", Comun.Eslogan);
                Parametros[2] = new ReportParameter("Direccion", Comun.Direccion);
                Parametros[3] = new ReportParameter("TituloReporte", "REPORTE DE MATERIALES EN PRODUCCIÓN");
                if (File.Exists(@"Resources\Documents\" + Comun.UrlLogo.ToLower()))
                {
                    string Aux = new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri;
                    Parametros[4] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri);
                }
                else
                    Parametros[4] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\Default.jpg")).AbsoluteUri);
                Parametros[5] = new ReportParameter("Sucursal", Datos.NombreSucursal);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "StephManager.Informes.MaterialesProduccion.rdlc";
                reportViewer1.LocalReport.SetParameters(Parametros);
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Lista01", (List<ReporteMaterialesProduccion>)Listas[0]));
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Lista02", (List<ReporteMaterialesProduccion>)Listas[1]));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerarReporteServiciosRealizados()
        {
            try
            {
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.LocalReport.DataSources.Clear();
                string Conexion = Comun.Conexion;
                DateTime FechaInicio = dtpFechaInicio.Value;
                DateTime FechaFin = dtpFechaFinal.Value;
                Reporte_Negocio repNeg = new Reporte_Negocio();
                List<ReporteServiciosRealizados> Lista = repNeg.ObtenerReporteServiciosRealizados(Conexion, FechaInicio, FechaFin);
                reportViewer1.LocalReport.EnableExternalImages = true;
                ReportParameter[] Parametros = new ReportParameter[7];
                Parametros[0] = new ReportParameter("Empresa", Comun.NombreComercial);
                Parametros[1] = new ReportParameter("Eslogan", Comun.Eslogan);
                Parametros[2] = new ReportParameter("Direccion", Comun.Direccion);
                Parametros[3] = new ReportParameter("TituloReporte", "REPORTE DE SERVICIOS REALIZADOS POR PERÍODO");
                if (File.Exists(@"Resources\Documents\" + Comun.UrlLogo.ToLower()))
                {
                    string Aux = new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri;
                    Parametros[4] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri);
                }
                else
                    Parametros[4] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\Default.jpg")).AbsoluteUri);
                Parametros[5] = new ReportParameter("FechaInicio", FechaInicio.ToShortDateString());
                Parametros[6] = new ReportParameter("FechaFin", FechaFin.ToShortDateString());
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "StephManager.Informes.Reportes.ServiciosRealizados.rdlc";
                reportViewer1.LocalReport.SetParameters(Parametros);
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ServiciosRealizados", Lista));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerarReporteConsumoMaterial()
        {
            try
            {
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.LocalReport.DataSources.Clear();
                string Conexion = Comun.Conexion;
                DateTime FechaInicio = dtpFechaInicio.Value;
                DateTime FechaFin = dtpFechaFinal.Value;
                Sucursal Datos = this.ObtenerElementoComboSuc();
                Reporte_Negocio repNeg = new Reporte_Negocio();
                /*List<ReporteConsumoMaterial> Lista = repNeg.ObtenerReporteConsumoMaterial(Conexion, Datos.IDSucursal, FechaInicio, FechaFin);
                foreach(ReporteConsumoMaterial Item in Lista)
                {
                    Item.ImagenMetrica = Item.CumpleMetrica ? new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Apply.png")).AbsoluteUri : new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\descarga.png")).AbsoluteUri;
                }*/

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
                Parametros[5] = new ReportParameter("FechaInicio", FechaInicio.ToShortDateString());
                Parametros[6] = new ReportParameter("FechaFin", FechaFin.ToShortDateString());
                Parametros[7] = new ReportParameter("Sucursal", Datos.NombreSucursal);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "StephManager.Informes.Reportes.ConsumoMaterial.rdlc";
                reportViewer1.LocalReport.SetParameters(Parametros);
                //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ConsumoMaterial", Lista));
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
                LogError.AddExcFileTxt(ex, "frmVerListados ~ btnSalir_Click");
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarReporte();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVerListados ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
