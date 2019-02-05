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
    public partial class frmInventarioAjuste : Form
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

        public frmInventarioAjuste(Producto Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosActuales = Datos;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventarioAjuste ~ frmInventarioAjuste()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                this.LlenarDatos();
                this.ActiveControl = this.rbPositivo;
                this.rbPositivo.Focus();
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
                this.txtExistenciaActual.Text = string.Format("{0:F0}", this._DatosActuales.Existencia);
                this.txtCantidad.Text = string.Format("{0:F0}", 0);
                this.txtMotivo.Text = string.Empty;
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

        private decimal ObtenerCantidad(TextBox TxtStock)
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

        private Producto ObtenerDatos()
        {
            try
            {
                Producto DatosAux = new Producto();
                DatosAux.IDProducto = this._DatosActuales.IDProducto;
                DatosAux.IDSucursal = this._DatosActuales.IDSucursal;
                DatosAux.EsPositivo = this.rbPositivo.Checked;
                DatosAux.CantidadAjuste = this.ObtenerCantidad(this.txtCantidad);
                DatosAux.MotivoAjuste = this.txtMotivo.Text.Trim();
                DatosAux.Existencia = DatosAux.EsPositivo ? this._DatosActuales.Existencia + DatosAux.CantidadAjuste : this._DatosActuales.Existencia - DatosAux.CantidadAjuste;
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                return DatosAux;
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
                decimal Cantidad = ObtenerCantidad(this.txtCantidad);
                if (Cantidad <= 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La cantidad debe ser mayor a 0.", ControlSender = this.txtCantidad });
                if (string.IsNullOrEmpty(this.txtMotivo.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el motivo del ajuste.", ControlSender = this.txtMotivo });
                if (this.rbNegativo.Checked)
                {
                    if (Cantidad > this._DatosActuales.Existencia)
                    {
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La cantidad para ajuste negativo debe ser menor a la existencia actual.", ControlSender = this.txtCantidad });
                    }
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
                LogError.AddExcFileTxt(ex, "frmInventarioAjuste ~ btnCancelar_Click");
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
                    IN.NuevoAjusteInventario(Datos);
                    if (Datos.Completado)
                    {
                        this._DatosActuales = Datos;
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if(Datos.Resultado == -1)
                            MessageBox.Show("La existencia no permite realizar el ajuste.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (Datos.Resultado == -2)
                            MessageBox.Show("No es un producto válido para ajustes.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                            MessageBox.Show("Ocurrió un error al guardar los datos. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventarioAjuste ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmInventarioAjuste_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventarioAjuste ~ frmInventarioCambiar_Load");
            }
        }

        private void txtCantidad_Validating(object sender, CancelEventArgs e)
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
                LogError.AddExcFileTxt(ex, "frmInventarioAjuste ~ txtStock_Validating");
            }
        }

        #endregion
    }
}
