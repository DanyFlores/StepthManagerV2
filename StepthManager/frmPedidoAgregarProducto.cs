using CreativaSL.Dll.StephManager.Global;
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
    public partial class frmPedidoAgregarProducto : Form
    {
        private Producto Actual = new Producto();
        string IDPedido = string.Empty;
        List<PedidoDetalle> ProductosEnPedido = new List<PedidoDetalle>();
        public PedidoDetalle ProductoAgregado = new PedidoDetalle();
        public frmPedidoAgregarProducto(string _IDPedido, List<PedidoDetalle> _Lista)
        {
            try
            {
                InitializeComponent();
                IDPedido = _IDPedido;
                ProductosEnPedido = _Lista;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidoAgregarProducto ~ frmNuevoPedidoReemplazoProducto()");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidoAgregarProducto ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElegirProducto_Click(object sender, EventArgs e)
        {
            try
            {
                int TipoForm = 6;
                frmSeleccionarProducto ElegirProducto = new frmSeleccionarProducto(TipoForm);
                ElegirProducto.Location = this.txtProducto.PointToScreen(new Point());
                ElegirProducto.Location = new Point(ElegirProducto.Location.X - 1, ElegirProducto.Location.Y - 2);
                ElegirProducto.ShowDialog();
                ElegirProducto.Dispose();
                if (ElegirProducto.DialogResult == DialogResult.OK)
                {
                    Producto Aux = ElegirProducto.Datos;
                    Actual = Aux;
                    this.txtProducto.Text = Aux.NombreProducto;
                    this.btnGuardar.Focus();
                }
                else
                {
                    this.Actual = new Producto();
                    this.txtProducto.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidoAgregarProducto ~ btnElegirProducto_Click");
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
                    ProductoAgregado = this.ObtenerDatos();
                    //this.DialogResult = DialogResult.OK;
                    Pedido_Negocio PedNeg = new Pedido_Negocio();
                    PedNeg.AgregarProducto(ProductoAgregado);
                    if (ProductoAgregado.Completado)
                    {
                        MessageBox.Show("Producto agregado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (ProductoAgregado.Resultado == -1)
                            MessageBox.Show("El estatus del pedido no permite agregar productos.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else if (ProductoAgregado.Resultado == -2)
                            MessageBox.Show("El producto ya está en el pedido.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                            MessageBox.Show("Error al guardar los datos.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidoAgregarProducto ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void frmPedidoAgregarProducto_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidoAgregarProducto ~ frmPedidoAgregarProducto_Load");
            }
        }
        
        private void IniciarForm()
        {
            try
            {
                this.txtProducto.Text = string.Empty;
                this.Actual = new Producto();
                this.ActiveControl = this.btnElegirProducto;
                this.btnElegirProducto.Focus();
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
        
        private PedidoDetalle ObtenerDatos()
        {
            try
            {
                PedidoDetalle Datos = new PedidoDetalle();
                Datos.IDPedidoDetalle = string.Empty;
                Datos.IDPedido = IDPedido;
                Datos.IDProducto = Actual.IDProducto;
                Datos.Cantidad = 0;
                Datos.CantidadSurtida = 0;
                Datos.CantidadASurtir = 0;
                Datos.CantidadPendiente = 0;
                Datos.Completo = true;
                Datos.ClaveProducto = Actual.Clave;
                Datos.NombreProducto = Actual.NombreProducto;
                Datos.IDUsuario = Comun.IDUsuario;
                Datos.Conexion = Comun.Conexion;
                return Datos;
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
                int Aux = 0;
                if (string.IsNullOrEmpty(this.Actual.IDProducto))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un producto.", ControlSender = this.btnElegirProducto });
                
                foreach(PedidoDetalle Item in ProductosEnPedido)
                {
                    if(Item.IDProducto == Actual.IDProducto)
                    {
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "El producto ya se encuentra en el pedido.", ControlSender = this.btnElegirProducto });
                        break;
                    }
                }
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
