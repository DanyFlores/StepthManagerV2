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
    public partial class frmNuevoPedidoProducto : Form
    {
        private PedidoDetalle _Datos;
        public PedidoDetalle Datos
        {
            get { return _Datos; }
            set { _Datos = value; }
        }
        private Producto Actual = new Producto();

        public frmNuevoPedidoProducto()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedidoProducto ~ frmNuevoPedidoProducto()");
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
                LogError.AddExcFileTxt(ex, "frmNuevoPedidoProducto ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElegirProducto_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeleccionarProducto ElegirProducto = new frmSeleccionarProducto(6);
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
                LogError.AddExcFileTxt(ex, "frmNuevoPedidoProducto ~ btnElegirProducto_Click");
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
                    this._Datos = this.ObtenerDatos();
                    Pedido_Negocio PedNeg = new Pedido_Negocio();
                    PedNeg.AgregarMaterialCapacitacion(this._Datos);
                    if (this._Datos.Completado)
                    {
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Claves generadas correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (this._Datos.Resultado == -1)
                        {
                            Error ErrorAux = new Error { Numero = 1, ControlSender = this.numericUpDown1, Descripcion = "No hay existencia suficiente." };
                            List<Error> Lista = new List<Error>();
                            Lista.Add(ErrorAux);
                            this.MostrarMensajeError(Lista);
                        }
                        else
                        {
                            MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedidoProducto ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoPedidoProducto_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoPedidoProducto ~ frmNuevoPedidoProducto_Load");
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.txtProducto.Text = string.Empty;
                this.Actual = new Producto();
                this.numericUpDown1.Value = 1;
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

        private decimal ObtenerCantidad()
        {
            try
            {
                return this.numericUpDown1.Value;
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
                Datos.IDProducto = Actual.IDProducto;
                Datos.Cantidad = this.ObtenerCantidad();
                Datos.IDSucursal = Comun.IDSucursalCaja;
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
                if (this.ObtenerCantidad() <= 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La cantidad debe ser mayor que 0.", ControlSender = this.numericUpDown1 });
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
