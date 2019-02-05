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
    public partial class frmVerReporteMobiliarioXSucursal : Form
    {
        public frmVerReporteMobiliarioXSucursal()
        {   
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVerReporteMobiliarioXSucursal ~ frmVerReporteMobiliarioXSucursal()");
            }
        }

        private void frmVerReporteMobiliarioXSucursal_Load(object sender, EventArgs e)
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
                LogError.AddExcFileTxt(ex, "frmVerReporteMobiliarioXSucursal ~ frmVerReporteMobiliarioXSucursal_Load");
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Sucursal ObtenerElementoComboSuc()
        {
            try
            {
                Sucursal _value = new Sucursal();
                if (this.cmbSucursal.Items.Count > 0)
                {
                    if (this.cmbSucursal.SelectedIndex != -1)
                    {
                        _value = (Sucursal)this.cmbSucursal.SelectedItem;
                    }
                }
                return _value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.LlenarComboSucursales(this.ObtenerComboSucursales());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void GenerarReporteMobiliarioXSucursal()
        {
            try
            {
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.LocalReport.DataSources.Clear();
                Sucursal Datos = this.ObtenerElementoComboSuc();
                Datos.Conexion = Comun.Conexion;
                ReporteMobiliarioXSucursal Detalle = new ReporteMobiliarioXSucursal();
                Reporte_Negocio Negocio = new Reporte_Negocio();
                Detalle.Detalle = Negocio.ObtenerReporteMobiliarioAsignadoPorSucursal(Datos.Conexion, Datos.IDSucursal);
                reportViewer1.LocalReport.EnableExternalImages = true;
                ReportParameter[] Parametros = new ReportParameter[6];
                Parametros[0] = new ReportParameter("Empresa", Comun.NombreComercial);
                Parametros[1] = new ReportParameter("Eslogan", Comun.Eslogan);
                Parametros[2] = new ReportParameter("Direccion", Comun.Direccion);
                Parametros[3] = new ReportParameter("TituloReporte", "REPORTE DE MOBILIARIO ASIGNADO POR SUCURSAL");
                if (File.Exists(@"Resources\Documents\" + Comun.UrlLogo.ToLower()))
                {
                    string Aux = new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri;
                    Parametros[4] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri);
                }
                else
                    Parametros[4] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\Default.jpg")).AbsoluteUri);
                Parametros[5] = new ReportParameter("Sucursal", Datos.NombreSucursal);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "StephManager.Informes.Reportes.MobiliarioXSucursal.rdlc";
                reportViewer1.LocalReport.SetParameters(Parametros);
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Detalles", Detalle.Detalle));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.GenerarReporteMobiliarioXSucursal();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVerReporteMobiliarioXSucursal ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                LogError.AddExcFileTxt(ex, "frmVerReporteMobiliarioXSucursal ~ btnSalir_Click()");
            }
        }
    }
}
