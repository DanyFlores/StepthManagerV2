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
    public partial class frmInventarioCambiar : Form
    {
        #region Variables

        private Producto _DatosActuales;

        public Producto DatosActuales
        {
            get { return _DatosActuales; }
            set { _DatosActuales = value; }
        }
        
        #endregion

        #region Constructor

        public frmInventarioCambiar(Producto Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosActuales = Datos;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventarioCambiar ~ frmInventarioCambiar()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                this.LlenarDatos();
                this.ActiveControl = this.chkRequiereStock;
                this.chkRequiereStock.Focus();
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

        private void LlenarDatos()
        {
            try
            {
                this.txtNombreProducto.Text = this._DatosActuales.NombreProducto;
                this.txtNombreSucursal.Text = this._DatosActuales.NombreSucursal;
                this.chkRequiereStock.Checked = this._DatosActuales.RequiereStock;
                this.txtStockMinimo.Text = string.Format("{0:F0}", this._DatosActuales.StockMinimo);
                this.txtStockMaximo.Text = string.Format("{0:F0}", this._DatosActuales.StockMaximo);
                if (this._DatosActuales.RequiereStock)
                {
                    this.txtStockMinimo.ReadOnly = false;
                    this.txtStockMaximo.ReadOnly = false;
                }
                else
                {
                    this.txtStockMinimo.ReadOnly = true;
                    this.txtStockMaximo.ReadOnly = true;
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
                string CadenaErrores = string.Empty;
                CadenaErrores = "No se pudo guardar la información. Se presentaron los siguientes errores: \r\n";
                foreach (Error item in Errores)
                {
                    CadenaErrores += item.Numero + "\t" + item.Descripcion + "\r\n";
                }
                this.txtMensajeError.Visible = true;
                this.txtMensajeError.Text = CadenaErrores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Producto ObtenerDatos()
        {
            try
            {
                Producto DatosAux = new Producto();
                DatosAux.IDProducto = this._DatosActuales.IDProducto;
                DatosAux.IDSucursal = this._DatosActuales.IDSucursal;
                DatosAux.RequiereStock = this.chkRequiereStock.Checked;
                DatosAux.StockMinimo = this.ObtenerStock(this.txtStockMinimo);
                DatosAux.StockMaximo = this.ObtenerStock(this.txtStockMaximo);
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerStock(TextBox TxtStock)
        {
            try
            {
                decimal Stock = 0;
                decimal.TryParse(TxtStock.Text, out Stock);
                return Stock;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Error> ValidarErrores()
        {
            try
            {
                List<Error> Errores = new List<Error>();
                int Aux = 0;
                if (this.chkRequiereStock.Checked)
                {
                    decimal StockMinimo = ObtenerStock(this.txtStockMinimo);
                    decimal StockMaximo = ObtenerStock(this.txtStockMaximo);
                    if ( StockMinimo < 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "El stock mínimo no puede ser menor a 0.", ControlSender = this.txtStockMinimo });
                    if (StockMaximo <= 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "El stock Máximo debe ser mayor a 0.", ControlSender = this.txtStockMaximo });
                    if(StockMinimo > StockMaximo)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "El stock Mínimo no puede ser mayor al Stock Máximo.", ControlSender = this.txtStockMaximo });
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
                LogError.AddExcFileTxt(ex, "frmInventarioCambiar ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtMensajeError.Visible = false;
                List<Error> Errores = this.ValidarErrores();
                if (Errores.Count == 0)
                {
                    Producto Datos = this.ObtenerDatos();
                    Inventario_Negocio IN = new Inventario_Negocio();
                    IN.ActualizarDatosInventario(Datos);
                    if (Datos.Completado)
                    {
                        this._DatosActuales = Datos;
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al guardar los datos. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventarioCambiar ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkRequiereStock_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkRequiereStock.Checked)
                {
                    this.txtStockMinimo.ReadOnly = false;
                    this.txtStockMaximo.ReadOnly = false;
                }
                else
                {
                    this.txtStockMinimo.ReadOnly = true;
                    this.txtStockMaximo.ReadOnly = true;
                }
                this.txtStockMinimo.Text = string.Format("{0:F0}", 0);
                this.txtStockMaximo.Text = string.Format("{0:F0}", 0);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventarioCambiar ~ chkRequiereStock_CheckedChanged");
            }
        }

        private void frmInventarioCambiar_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventarioCambiar ~ frmInventarioCambiar_Load");
            }
        }

        private void txtStock_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                TextBox Stock = (TextBox)sender;
                decimal StockDec = 0;
                decimal.TryParse(Stock.Text, out StockDec);
                Stock.Text = string.Format("{0:F0}", StockDec);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventarioCambiar ~ txtStock_Validating");
            }
        }

        #endregion
    }
}
