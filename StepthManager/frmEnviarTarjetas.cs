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
    public partial class frmEnviarTarjetas : Form
    {
        #region Variables

        private Producto Datos = new Producto();

        #endregion

        #region Constructor

        public frmEnviarTarjetas(Producto DatosAux)
        {
            try
            {
                InitializeComponent();
                Datos = DatosAux;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEnviarTarjetas ~ frmEnviarTarjetas()");
            }
        }

        #endregion

        #region Métodos

        private void CargarDatos()
        {
            try
            {
                this.txtDescripcion.Text = this.Datos.NombreProducto;
                this.txtCantidad.Text = "0";
                this.LlenarComboSucursales();
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
                this.CargarDatos();
                this.ActiveControl = this.txtDescripcion;
                this.txtDescripcion.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboSucursales()
        {
            try
            {
                Sucursal DatosAux = new Sucursal { Conexion = Comun.Conexion, Opcion = 1 };
                Sucursal_Negocio SN = new Sucursal_Negocio();
                this.cmbSucursal.DataSource = SN.LlenarComboCatSucursalesPuntoDeVenta(DatosAux);
                this.cmbSucursal.ValueMember = "IDSucursal";
                this.cmbSucursal.DisplayMember = "NombreSucursal";
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

        private Producto ObtenerDatos()
        {
            try
            {
                Producto DatosAux = new Producto();
                DatosAux.IDProducto = this.Datos.IDProducto;
                DatosAux.Cantidad = this.ObtenerCantidad();
                DatosAux.IDSucursal = this.ObtenerDatosSucursal().IDSucursal;
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Sucursal ObtenerDatosSucursal()
        {
            try
            {
                Sucursal Aux = new Sucursal();
                if (this.cmbSucursal.SelectedIndex != -1)
                {
                    Aux = (Sucursal)this.cmbSucursal.SelectedItem;
                }
                return Aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int ObtenerCantidad()
        {
            try
            {
                decimal Monto = 0;
                decimal.TryParse(this.txtCantidad.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Monto);
                return (int)Monto;
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

                Sucursal DatosSuc = this.ObtenerDatosSucursal();
                if (string.IsNullOrEmpty(DatosSuc.IDSucursal))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una sucursal.", ControlSender = this.txtCantidad });
                int Cantidad = this.ObtenerCantidad();
                if (Cantidad <= 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La cantidad debe ser mayor a 0.", ControlSender = this.txtCantidad });
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
                LogError.AddExcFileTxt(ex, "frmEnviarTarjetas ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                    Producto Datos = this.ObtenerDatos();
                    Producto_Negocio ProdNeg = new Producto_Negocio();
                    ProdNeg.EnviarTarjetasRegalo(Datos, Comun.IDSucursalCaja);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEnviarTarjetas ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmEnviarTarjetas_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEnviarTarjetas ~ frmEnviarTarjetas_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCantidad_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                this.txtCantidad.Text = this.ObtenerCantidad().ToString();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmEnviarTarjetas ~ btnCancelar_Click");
            }
        }

        #endregion

    }
}