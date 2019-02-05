using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using StephManager.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreativaSL.Dll.Validaciones;
using System.Globalization;

namespace StephManager
{
    public partial class frmMobiliaro_Resguardo_Nuevo : Form
    {
        #region Propiedades / Variables
        private MobiliarioResguardo _DatosMoviliarioReguardos;
        public MobiliarioResguardo DatosMoviliarioReguardos
        {
            get { return _DatosMoviliarioReguardos; }
            set { _DatosMoviliarioReguardos = value; }
        }
        Mobiliario AsiganarMobiliario = new Mobiliario();

        #endregion
        public frmMobiliaro_Resguardo_Nuevo()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliaro_Resguardo_Nuevo ~ frmMobiliaro_Resguardo_Nuevo()");
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.ActiveControl = this.btnElegirMobiliario;
                this.btnElegirMobiliario.Focus();
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

        private MobiliarioResguardo ObtenerDatos()
        {
            try
            {
                MobiliarioResguardo DatosAux = new MobiliarioResguardo();
                DatosAux.Descripcion = this.AsiganarMobiliario.Descripcion;
                DatosAux.IDMobiliario = this.AsiganarMobiliario.IDMobiliario;
                DatosAux.Codigo = this.AsiganarMobiliario.Codigo;
                DatosAux.Marca = this.AsiganarMobiliario.Marca;
                DatosAux.Modelo = this.AsiganarMobiliario.Modelo;
                DatosAux.Existencia = this.ObtenerCantidadExistencia();
                DatosAux.Cantidad = this.ObtenerCantidad();
                DatosAux.IDSucursal = Comun.IDSucursalCaja;
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void frmMobiliaro_Resguardo_Nuevo_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliaro_Resguardo_Nuevo ~ frmMobiliaro_Resguardo_Nuevo_Load");
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
                LogError.AddExcFileTxt(ex, "frmMobiliaro_Resguardo_Nuevo ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Error> ValidarDatos()
        {
            try
            {
                List<Error> Errores = new List<Error>();
                int Aux = 0;

                //Validar Nombre Comercial del Proveedor
                if (string.IsNullOrEmpty(this.txtMobiliario.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un mobiliario.", ControlSender = this.btnElegirMobiliario });
                else
                {
                    if (string.IsNullOrEmpty(this.AsiganarMobiliario.IDMobiliario))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un mobiliario.", ControlSender = this.btnElegirMobiliario });
                }
                if(this.ObtenerCantidad() <= 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La cantidad tiene que se mayor a cero", ControlSender = this.txtCantidadExistencia });
                if (this.ObtenerCantidadExistencia() < this.ObtenerCantidad())
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "No tiene suficiente mobiliario en existencia", ControlSender = this.txtCantidadExistencia });
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private int ObtenerCantidadExistencia()
        {
            try
            {
                int CantidadExistencia = 0;
                int.TryParse(this.txtCantidadExistencia.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out CantidadExistencia);
                return CantidadExistencia;
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
                int Cantidad = 0;
                int.TryParse(this.txtCantidad.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Cantidad);
                return Cantidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnElegirCliente_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeleccionarMobiliario_Res ElegirMobiliario = new frmSeleccionarMobiliario_Res();
                ElegirMobiliario.Location = this.txtMobiliario.PointToScreen(new Point());
                ElegirMobiliario.Location = new Point(ElegirMobiliario.Location.X - 1, ElegirMobiliario.Location.Y - 2);
                ElegirMobiliario.ShowDialog();
                ElegirMobiliario.Dispose();
                if (ElegirMobiliario.DialogResult == DialogResult.OK)
                {
                    this.AsiganarMobiliario = ElegirMobiliario.Datos;
                    this.txtMobiliario.Text = this.AsiganarMobiliario.Descripcion;
                    this.ExistenciasMobiliario(Comun.IDSucursalCaja, AsiganarMobiliario.IDMobiliario);
                    this.txtCantidadExistencia.Text = this._DatosMoviliarioReguardos.Existencia.ToString();
                    this.txtCantidad.Focus();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliaro_Resguardo_Nuevo ~ btnElegirCliente_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExistenciasMobiliario(string IDSucursal, string IDMoviliario)
        {
            try
            {
                MobiliarioResguardo DatosAux = new MobiliarioResguardo { Conexion = Comun.Conexion, IDSucursal = IDSucursal, IDMobiliario = IDMoviliario };
                MobiliarioResguardo_Negocio MN = new MobiliarioResguardo_Negocio();
                this._DatosMoviliarioReguardos = MN.ObtenerExistentes(DatosAux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnGuardarMobiliaria_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    List<Error> ListaErrores = this.ValidarDatos();
                    if (ListaErrores.Count == 0)
                    {
                        this._DatosMoviliarioReguardos = this.ObtenerDatos();
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        this.MostrarMensajeError(ListaErrores);
                }
                catch (Exception ex)
                {
                    LogError.AddExcFileTxt(ex, "frmMobiliaro_Resguardo_Nuevo ~ btnGuardarMobiliaria_Click");
                    MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliaro_Resguardo_Nuevo ~ btnGuardarMobiliaria_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCantidad_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                decimal Aux = 0;
                decimal.TryParse(this.txtCantidad.Text, out Aux);
                this.txtCantidad.Text = ((int)Aux).ToString();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliario_Resguardo_Nuevo ~ txtCantidad_Validating");
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    this.btnGuardarMobiliaria_Click(this.btnGuardarMobiliaria, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliario_Resguardo_Nuevo ~ txtCantidad_KeyPress");
            }
        }
    }
}
