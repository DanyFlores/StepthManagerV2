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
    public partial class frmComprasDetalle : Form
    {
        private string IDCompra = string.Empty;

        public frmComprasDetalle(string ID)
        {
            try
            {
                InitializeComponent();
                IDCompra = ID;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmComprasDetalle ~ frmComprasDetalle()");
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.LlenarDatos(this.ObtenerDetalleCompra());
                this.ActiveControl = this.btnRegresar;
                this.btnRegresar.Focus();
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

        private Compra ObtenerDetalleCompra()
        {
            try
            {
                Compra DatosAux = new Compra { Conexion = Comun.Conexion, IDCompra = IDCompra };
                Compra_Negocio CN = new Compra_Negocio();
                return CN.ObtenerDatosCompraDetalle(DatosAux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarDatos(Compra Aux)
        {
            try
            {
                this.txtNumFactura.Text = Aux.NumFactura;
                this.txtProveedor.Text = Aux.IDProveedor;
                this.txtProvRazonSocial.Text = Aux.RazonSocial;
                this.txtProvRFC.Text = Aux.RFC;
                this.txtProvDomicilio.Text = Aux.DomicilioFiscal;
                this.txtProvRegimen.Text = Aux.RegimenFiscal;
                this.txtFechaEmision.Text = Aux.FechaEmision.ToShortDateString();
                this.txtFechaHoraCert.Text = Aux.FechaHoraCertificacion.ToString("dd/MM/yyyy HH:mm:ss");
                this.txtLugarExpedicion.Text = Aux.LugarExpedicion;
                this.txtFolioFiscal.Text = Aux.FolioFiscal;
                this.txtNoSerieCertificadoSat.Text = Aux.NoSerieCertSAT;
                this.txtNoSerieCertificadoEmisor.Text = Aux.NoSerieCertEmisor;
                this.dgvProductos.AutoGenerateColumns = false;
                this.dgvProductos.ReadOnly = true;
                this.dgvProductos.DataSource = Aux.TablaProductos;
                this.txtSubtotal.Text = string.Format("{0:c}", Aux.Subtotal);
                this.txtDescuento.Text = string.Format("{0:c}", Aux.Descuento);
                this.txtIva.Text = string.Format("{0:c}", Aux.Iva);
                this.txtTotal.Text = string.Format("{0:c}", Aux.Total);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmComprasDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmComprasDetalle ~ frmComprasDetalle_Load");
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmComprasDetalle ~ btnRegresar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
