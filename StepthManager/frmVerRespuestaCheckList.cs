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
    public partial class frmVerRespuestaCheckList : Form
    {
        private int TipoListado = 0;
        private string ID = string.Empty;
        private ChechkListResultado _DatosCheckListResultado;
        public ChechkListResultado DatosCheckListResultado
        {
            get { return _DatosCheckListResultado; }
            set { _DatosCheckListResultado = value; }
        }

        private ChechkList _DatosCheckList;
        public ChechkList DatosCheckList
        {
            get { return _DatosCheckList; }
            set { _DatosCheckList = value; }
        }
        public frmVerRespuestaCheckList(int Tipo, ChechkList Datos, ChechkListResultado DatosAux)
        {
            try
            {
                InitializeComponent();
                this.TipoListado = Tipo;
                this._DatosCheckListResultado = DatosAux;
                this._DatosCheckList = Datos;
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
                    case 1: this.GenerarReporteRespuesta();
                        this.lblTitulo.Text = "RESPUESTA DEL CHECKLIST";
                        break;
                    case 2: this.GenerarReporteActivadaDetalle();
                        this.lblTitulo.Text = "CHECKLIST ACTIVIDADES";
                        break;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerarReporteRespuesta()
        {
            try
            {
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.LocalReport.DataSources.Clear();
                ChechkListResultado Datos = new ChechkListResultado { IDCheckList = this._DatosCheckList.IDCheckList, IDResultado = this._DatosCheckListResultado.IDResultado, Conexion = Comun.Conexion };
                CheckListResultado_Negocio MRN = new CheckListResultado_Negocio();
                List<ChechkListResultado> Lista = MRN.ObtenerCheckListRespuestaDetalle(Datos);
                reportViewer1.LocalReport.EnableExternalImages = true;
                ReportParameter[] Parametros = new ReportParameter[8];
                Parametros[0] = new ReportParameter("Empresa", Comun.NombreComercial);
                Parametros[1] = new ReportParameter("Eslogan", Comun.Eslogan);
                Parametros[2] = new ReportParameter("TituloReporte", this._DatosCheckList.Titulo);
                if (File.Exists(@"Resources\Documents\" + Comun.UrlLogo.ToLower()))
                {
                    string Aux = new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri;
                    Parametros[3] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri);
                }
                else
                {
                    Parametros[3] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\Default.jpg")).AbsoluteUri);
                }
                Parametros[4] = new ReportParameter("FechaHora", this._DatosCheckListResultado.FechaAplicacion.ToShortDateString() + " - " + this._DatosCheckListResultado.HoraAplicacion);
                Parametros[5] = new ReportParameter("Sucursal", this._DatosCheckListResultado.NombreSucursal.ToUpper());
                Parametros[6] = new ReportParameter("ResponsableChek", this._DatosCheckListResultado.Responsable.ToUpper());
                Parametros[7] = new ReportParameter("Empleado", this._DatosCheckListResultado.NombreEmpleado.ToUpper());
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "StephManager.Informes.CheckListRespuesta.rdlc";
                reportViewer1.LocalReport.SetParameters(Parametros);
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("TablaRespuesta", Lista));
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerarReporteActivadaDetalle()
        {
            try
            {
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.LocalReport.DataSources.Clear();
                ChechkListResultado Datos = new ChechkListResultado { IDCheckList = this._DatosCheckList.IDCheckList, Conexion = Comun.Conexion };
                CheckListResultado_Negocio MRN = new CheckListResultado_Negocio();
                List<ChechkListResultado> Lista = MRN.ObtenerCheckListActividadDetalle(Datos);
                reportViewer1.LocalReport.EnableExternalImages = true;
                ReportParameter[] Parametros = new ReportParameter[8];
                Parametros[0] = new ReportParameter("Empresa", Comun.NombreComercial);
                Parametros[1] = new ReportParameter("Eslogan", Comun.Eslogan);
                Parametros[2] = new ReportParameter("TituloReporte", this._DatosCheckList.Titulo);
                if (File.Exists(@"Resources\Documents\" + Comun.UrlLogo.ToLower()))
                {
                    string Aux = new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri;
                    Parametros[3] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo.ToLower())).AbsoluteUri);
                }
                else
                {
                    Parametros[3] = new ReportParameter("UrlLogo", new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\Default.jpg")).AbsoluteUri);
                }
                Parametros[4] = new ReportParameter("FechaHora", " ");
                Parametros[5] = new ReportParameter("Sucursal", " ");
                Parametros[6] = new ReportParameter("ResponsableChek", " ");
                if (this._DatosCheckList.IDTipoCheckList == 1)
                {
                    Parametros[7] = new ReportParameter("Empleado", " ");
                }
                else
                {
                    Parametros[7] = new ReportParameter("Empleado", "");
                }
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "StephManager.Informes.CheckListActividad.rdlc";
                reportViewer1.LocalReport.SetParameters(Parametros);
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("TablaRespuesta", Lista));
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
       
    }
}
