﻿using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using StephManager.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephManager
{
    public partial class frmComprasPagos : Form
    {
        #region Variables

        private Compra DatosCompra = new Compra();

        #endregion

        #region Constructor

        public frmComprasPagos(Compra IDCompraMob)
        {
            try
            {
                InitializeComponent();
                DatosCompra = IDCompraMob;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmComprasPagos ~ frmComprasPagos()");
            }
        }

        #endregion

        #region Métodos

        private void CargarGrid()
        {
            try
            {
                Compra Datos = new Compra { Conexion = Comun.Conexion, IDCompra = this.DatosCompra.IDCompra };
                Compra_Negocio CN = new Compra_Negocio();
                CN.ObtenerPagosCompra(Datos);
                if (Datos.Completado)
                {
                    this.dgvPedidos.AutoGenerateColumns = false;
                    this.dgvPedidos.DataSource = Datos.TablaDatos;
                }
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
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
                this.lblFolio.Text = "Factura: " + DatosCompra.NumFactura;
                this.CargarGrid();
                this.ActiveControl = this.btnSalir;
                this.btnSalir.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private PagoCompra ObtenerDatosGrid(int Row)
        {
            try
            {
                PagoCompra Datos = new PagoCompra();
                DataGridViewRow Fila = this.dgvPedidos.Rows[Row];
                decimal MontoPago = 0;
                decimal.TryParse(Fila.Cells["Monto"].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out MontoPago);
                Datos.IDPagoCompra = Fila.Cells["IDPagoCompra"].Value.ToString();
                Datos.MontoPago = MontoPago;
                Datos.IDCajaXSucursal = Comun.IDCaja;
                Datos.Conexion = Comun.Conexion;
                Datos.IDUsuario = Comun.IDUsuario;
                return Datos;
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
                if (this.dgvPedidos.SelectedRows.Count == 1)
                {
                    int Row = this.dgvPedidos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    PagoCompra Datos = this.ObtenerDatosGrid(Row);
                    if (MessageBox.Show("¿Está seguro de cancelar el pago al proveedor?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Compra_Negocio CN = new Compra_Negocio();
                        CN.CancelarPagoCompra(Datos);
                        if (Datos.Completado)
                        {
                            this.DatosCompra.MontoPendiente = this.DatosCompra.MontoPendiente + Datos.MontoPago;
                            this.CargarGrid();
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmComprasPagos ~ btnCompras_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoPago_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoPagoCompra NuevoPago = new frmNuevoPagoCompra(this.DatosCompra.IDCompra, this.DatosCompra.MontoPendiente);
                NuevoPago.ShowDialog();
                NuevoPago.Dispose();
                if (NuevoPago.DialogResult == DialogResult.OK)
                {
                    this.DatosCompra.MontoPendiente = this.DatosCompra.MontoPendiente - NuevoPago.MontoPago;
                    this.CargarGrid();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmComprasPagos ~ btnSalir_Click");
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
                LogError.AddExcFileTxt(ex, "frmMobiliario ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmComprasPagos_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmComprasPagos ~ frmComprasPagos_Load");
            }
        }

        #endregion
    }
}
