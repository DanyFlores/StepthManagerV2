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
    public partial class frmNuevoReporteVentasXSucursal : Form
    {
        #region Propiedades / Variables
        private string IDCliente = string.Empty;
        #endregion

        #region Constructor

        public frmNuevoReporteVentasXSucursal()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoReporteVentasXSucursal ~ frmNuevoReporteVentasXSucursal()");
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
                this.cmbSucursal.Focus();
                this.LlenarComboSucursales(this.ObtenerComboSucursales());
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

        //Camiar hdtptm
        private ReportesVentaXSucursal ObtenerDatos()
        {
            try
            {
                Sucursal DtsCliente = this.ObtenerElementoComboSuc();
                this.IDCliente = DtsCliente.IDSucursal;
                ReportesVentaXSucursal DatosAux = new ReportesVentaXSucursal();
                DatosAux.FechaInicio = dtpFechaInicio.Value;
                DatosAux.FechaFin = dtpFechaFin.Value;
                DatosAux.IDSucursal = this.IDCliente;
                return DatosAux;
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

        private List<Error> ValidarDatos()
        {
            try
            {
                List<Error> Errores = new List<Error>();
                if (dtpFechaFin.Value < dtpFechaInicio.Value)
                {
                    Errores.Add(new Error { Numero = 1, Descripcion = "Fecha de término debe ser mayor a la fecha de Inicio", ControlSender = dtpFechaFin });
                }
                else
                {

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
                LogError.AddExcFileTxt(ex, "frmNuevoReporteVentasXSucursal ~ btnCancelar_Click");
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

                    ReportesVentaXSucursal Datos = this.ObtenerDatos();
                    ReporteVentasXSucursal_Negocio Neg = new ReporteVentasXSucursal_Negocio();
                    
                    int IDReporte = Neg.GenerarReporteVentasXSucursal(Comun.Conexion, Datos.FechaInicio, Datos.FechaFin, Comun.IDUsuario, Datos.IDSucursal);
                    //IDReporte = Neg.GenerarReporteVentasXSucursalXFormasPago (Comun.Conexion, Datos.FechaInicio, Datos.FechaFin, IDReporte , Datos.IDSucursal);

                    if (IDReporte > 0)
                    {
                        frmVerReporteVentasXSucursal VerReporte = new frmVerReporteVentasXSucursal(IDReporte);
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
                LogError.AddExcFileTxt(ex, "frmNuevoReporteVentasXSucursal ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoReporteVentasXSucursal_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoReporteVentasXSucursal ~ frmNuevoReporteVentasXSucursal_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}

