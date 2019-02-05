using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using CreativaSL.Dll.Validaciones;
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
    public partial class frmNuevoReporteProductosVendidos : Form
    {
        #region Propiedades / Variables
        #endregion

        #region Constructor

        public frmNuevoReporteProductosVendidos()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoReporteProductosVendidos ~ frmNuevoReporteProductosVendidos()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                this.dtpFechaInicio.Value = DateTime.Today;
                this.dtpFechaFin.Value = DateTime.Today;
                this.ActiveControl = this.dtpFechaInicio;
                this.dtpFechaInicio.Focus();
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

        private void MostrarMensajeError(List<Error> Errores)
        {
            try
            {
                string cadenaErrores = string.Empty;
                cadenaErrores = "No se pudo guardar la información. Se presentaron los siguientes errores: \r\n";
                foreach (Error item in Errores)
                {
                    cadenaErrores += item.Numero + "\t" + item.Descripcion + "\r\n";
                }
                this.txtMensajeError.Visible = true;
                this.txtMensajeError.Text = cadenaErrores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ReporteProductosVendidos ObtenerDatos()
        {
            try
            {
                ReporteProductosVendidos DatosAux = new ReporteProductosVendidos();
                DatosAux.FechaInicio = dtpFechaInicio.Value;
                DatosAux.FechaFin = dtpFechaFin.Value;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Error> ValidarDatos()
        {
            try
            {
                List<Error> Errores = new List<Error>();
                if(dtpFechaFin.Value < dtpFechaInicio.Value)
                {
                    Errores.Add(new Error { Numero = 1, Descripcion = "Fecha de término debe ser mayor a la fecha de Inicio", ControlSender = dtpFechaFin });
                }
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoReporteProductosVendidos ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtMensajeError.Visible = false;
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                    ReporteProductosVendidos Datos = this.ObtenerDatos();
                    Reporte_Negocio Neg = new Reporte_Negocio();
                    int IDReporte = Neg.GenerarReporteProductosVendidos(Comun.Conexion, Datos.FechaInicio, Datos.FechaFin, Comun.IDUsuario);
                    if(IDReporte > 0)
                    {
                        //Generar el reporte
                        frmVerReporteProductosVendidos VerReporte = new frmVerReporteProductosVendidos(IDReporte);
                        VerReporte.ShowDialog();
                        VerReporte.Dispose();
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al generar el reporte.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoReporteProductosVendidos ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoReporteProductosVendidos_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoReporteProductosVendidos ~ frmNuevoReporteProductosVendidos_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
