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
    public partial class frmInventarioTransferencia : Form
    {
        #region Variables

        private Producto ProductoSeleccionado = new Producto();

        #endregion

        #region Constructor

        public frmInventarioTransferencia()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventarioTransferencia ~ frmInventarioTransferencia()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                this.CargarComboSucursales();
                this.LlenarDatos();
                this.ActiveControl = this.cmbSucursalOrigen;
                this.cmbSucursalOrigen.Focus();
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

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarComboDestino(List<Sucursal> Lista)
        {
            try
            {
                List<Sucursal> NuevaLista = new List<Sucursal>();
                foreach (Sucursal Item in Lista)
                {
                    NuevaLista.Add(Item);
                }
                this.cmbSucursalDestino.DataSource = NuevaLista;
                this.cmbSucursalDestino.ValueMember = "IDSucursal";
                this.cmbSucursalDestino.DisplayMember = "NombreSucursal";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarComboOrigen(List<Sucursal> Lista)
        {
            try
            {
                List<Sucursal> NuevaLista = new List<Sucursal>();
                foreach (Sucursal Item in Lista)
                {
                    NuevaLista.Add(Item);
                }
                this.cmbSucursalOrigen.DataSource = NuevaLista;
                this.cmbSucursalOrigen.ValueMember = "IDSucursal";
                this.cmbSucursalOrigen.DisplayMember = "NombreSucursal";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarComboSucursales()
        {
            try
            {
                Sucursal DatosSuc = new Sucursal { Conexion = Comun.Conexion, Opcion = 1 };
                Sucursal_Negocio SucNeg = new Sucursal_Negocio();
                List<Sucursal> Lista = SucNeg.LlenarComboCatSucursales(DatosSuc);
                this.CargarComboOrigen(Lista);
                this.CargarComboDestino(Lista);
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

        private Transferencia ObtenerDatos()
        {
            try
            {
                Transferencia DatosAux = new Transferencia();
                DatosAux.IDProducto = this.ProductoSeleccionado.IDProducto;
                DatosAux.IDSucursalOrigen = this.ObtenerSucursalSeleccionada(this.cmbSucursalOrigen).IDSucursal;
                DatosAux.IDSucursalDestino = this.ObtenerSucursalSeleccionada(this.cmbSucursalDestino).IDSucursal;
                DatosAux.Cantidad = this.ObtenerCantidad(this.txtCantidad);
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerCantidad(TextBox TxtCantidad)
        {
            try
            {
                decimal Stock = 0;
                decimal.TryParse(TxtCantidad.Text, out Stock);
                return Stock;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Sucursal ObtenerSucursalSeleccionada(ComboBox CmbSuc)
        {
            try
            {
                Sucursal DatosSuc = new Sucursal();
                if (CmbSuc.Items.Count > 0)
                {
                    if (CmbSuc.SelectedIndex != -1)
                    {
                        DatosSuc = (Sucursal)CmbSuc.SelectedItem;
                    }
                }
                return DatosSuc;
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
                decimal Cantidad = this.ObtenerCantidad(this.txtCantidad);
                if(string.IsNullOrEmpty(this.ObtenerSucursalSeleccionada(this.cmbSucursalOrigen).IDSucursal))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione la sucursal de origen.", ControlSender = this.cmbSucursalOrigen });
                if (string.IsNullOrEmpty(this.ObtenerSucursalSeleccionada(this.cmbSucursalDestino).IDSucursal))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione la sucursal de destino.", ControlSender = this.cmbSucursalDestino});
                if(string.IsNullOrEmpty(this.ProductoSeleccionado.IDProducto))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un producto.", ControlSender = this.txtProducto});
                if(Cantidad <= 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La cantidad debe ser mayor a 0.", ControlSender = this.txtCantidad });
                if (!string.IsNullOrEmpty(this.ProductoSeleccionado.IDProducto))
                {
                    if(Cantidad > this.ProductoSeleccionado.Existencia)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La cantidad no puede ser mayor a la existencia (" + string.Format("{0:F2}", this.ProductoSeleccionado.Existencia) + ")", ControlSender = this.txtCantidad });
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
                LogError.AddExcFileTxt(ex, "frmInventarioTransferencia ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElegirProducto_Click(object sender, EventArgs e)
        {
            try
            {
                Sucursal Origen = this.ObtenerSucursalSeleccionada(this.cmbSucursalOrigen);
                if (!string.IsNullOrEmpty(Origen.IDSucursal))
                {
                    frmSeleccionarProducto ElegirProducto = new frmSeleccionarProducto(14);
                    ElegirProducto.Datos.IDSucursal = Origen.IDSucursal;
                    ElegirProducto.Location = this.txtProducto.PointToScreen(new Point());
                    ElegirProducto.Location = new Point(ElegirProducto.Location.X - 1, ElegirProducto.Location.Y - 2);
                    ElegirProducto.ShowDialog();
                    ElegirProducto.Dispose();
                    if (ElegirProducto.DialogResult == DialogResult.OK)
                    {
                        this.ProductoSeleccionado = ElegirProducto.Datos;
                        this.txtProducto.Text = this.ProductoSeleccionado.NombreProducto;
                        this.txtCantidad.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar la sucursal de origen.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventarioTransferencia ~ btnElegirProducto_Click");
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
                    Transferencia Datos = this.ObtenerDatos();
                    Inventario_Negocio IN = new Inventario_Negocio();
                    IN.TransferenciaInventario(Datos);
                    if (Datos.Completado)
                    {
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
                LogError.AddExcFileTxt(ex, "frmInventarioTransferencia ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSucursalOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.ProductoSeleccionado = new Producto();
                this.txtProducto.Text = string.Empty;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventarioTransferencia ~ cmbSucursalOrigen_SelectedIndexChanged");

            }
        }

        private void cmbSucursalOrigen_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.cmbSucursalOrigen.SelectedIndex == -1)
                {
                    this.ProductoSeleccionado = new Producto();
                    this.txtProducto.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventarioTransferencia ~ cmbSucursalOrigen_Validating");

            }
        }

        private void frmInventarioTransferencia_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventarioTransferencia ~ frmInventarioTransferencia_Load");
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
                LogError.AddExcFileTxt(ex, "frmInventarioTransferencia ~ txtStock_Validating");
            }
        }

        #endregion

    }
}
