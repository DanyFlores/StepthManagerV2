using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using CreativaSL.Dll.Validaciones;
using StephManager.ClasesAux;
using System.IO;

namespace StephManager
{
    public partial class frmElegirServicioCita : Form
    {
        #region Propiedades

        private Servicio _ServicioElegido;
        public Servicio ServicioElegido
        {
            get { return _ServicioElegido; }
            set { _ServicioElegido = value; }
        }

        private Cliente _ClienteSeleccionado;
        public Cliente ClienteSeleccionado
        {
            get { return _ClienteSeleccionado; }
            set { _ClienteSeleccionado = value; }
        }
        
        #endregion

        #region Constructor

        public frmElegirServicioCita()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirServicioCita ~ frmElegirServicioCita()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                this.ActiveControl = this.btnElegirServicio;
                this.btnElegirServicio.Focus();
                //this.LlenarComboClientes();
                //this.LlenarComboServicios();
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

        private void LlenarComboClientes()
        {
            try
            {
                Cliente DatosAux = new Cliente { Conexion = Comun.Conexion, IncluirSelect = true };
                Cliente_Negocio CN = new Cliente_Negocio();
                //this.cmbCliente.DataSource = CN.ObtenerComboClientes(DatosAux);
                //this.cmbCliente.DisplayMember = "Nombre";
                //this.cmbCliente.ValueMember = "IDCliente";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboServicios()
        {
            try
            {
                Servicio DatosAux = new Servicio { Conexion = Comun.Conexion, IncluirSelect = true };
                Servicio_Negocio SN = new Servicio_Negocio();
                //this.cmbServicio.DataSource = SN.LlenarComboCatServicios(DatosAux);
                //this.cmbServicio.DisplayMember = "NombreServicio";
                //this.cmbServicio.ValueMember = "IDServicio";
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

        private Cliente ObtenerClienteSeleccionado()
        {
            try
            {
                Cliente DatosCl = new Cliente();
                //if (this.cmbCliente.SelectedIndex != -1)
                //{
                //    DatosCl = (Cliente)this.cmbCliente.SelectedItem;
                //}
                return DatosCl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Servicio ObtenerServicioSeleccionado()
        {
            try
            {
                Servicio Servicio = new Servicio();
                //if(this.cmbServicio.SelectedIndex != -1)
                //    Servicio = (Servicio)this.cmbServicio.SelectedItem;
                return Servicio;
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
                List<Error> ListaErrores = new List<Error>();
                int Aux = 0;
                if (string.IsNullOrEmpty(this.txtServicio.Text.Trim()))
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un servicio.", ControlSender = this.btnElegirServicio });
                else
                {
                    if (string.IsNullOrEmpty(this._ServicioElegido.IDServicio))
                        ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un servicio.", ControlSender = this.txtServicio });
                }
                if (string.IsNullOrEmpty(this.txtCliente.Text.Trim()))
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un cliente.", ControlSender = this.btnElegirCliente });
                else
                {
                    if (string.IsNullOrEmpty(this._ClienteSeleccionado.IDCliente))
                        ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un cliente.", ControlSender = this.txtCliente });
                }
                return ListaErrores;
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
                LogError.AddExcFileTxt(ex, "frmElegirServicioCita ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElegirCliente_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeleccionarCliente ElegirCliente = new frmSeleccionarCliente();
                ElegirCliente.Location = this.txtCliente.PointToScreen(new Point());
                ElegirCliente.Location = new Point(ElegirCliente.Location.X - 1, ElegirCliente.Location.Y - 2);
                ElegirCliente.ShowDialog();
                ElegirCliente.Dispose();
                if (ElegirCliente.DialogResult == DialogResult.OK)
                {
                    Cliente Aux = ElegirCliente.Datos;
                    this._ClienteSeleccionado = new Cliente { IDCliente = Aux.IDCliente, Nombre = Aux.Nombre };
                    this.btnGuardar.Focus();
                }
                else
                {
                    this.ClienteSeleccionado = new Cliente { IDCliente = string.Empty, Nombre = string.Empty };
                }
                this.txtCliente.Text = this.ClienteSeleccionado.Nombre;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirServicioCita ~ btnElegirCliente_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElegirServicio_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeleccionarProducto ElegirServicio = new frmSeleccionarProducto(2);
                ElegirServicio.Location = this.txtServicio.PointToScreen(new Point());
                ElegirServicio.Location = new Point(ElegirServicio.Location.X - 1, ElegirServicio.Location.Y - 2);
                ElegirServicio.ShowDialog();
                ElegirServicio.Dispose();
                if (ElegirServicio.DialogResult == DialogResult.OK)
                {
                    Producto Aux = ElegirServicio.Datos;
                    this._ServicioElegido = new Servicio { IDServicio = Aux.IDProducto, NombreServicio = Aux.NombreProducto, TiempoMinutos = Aux.TiempoMinutos };
                    this.btnElegirCliente.Focus();
                }
                else
                {
                    this._ServicioElegido = new Servicio { IDServicio = string.Empty, NombreServicio = string.Empty, TiempoMinutos = 0 };
                }
                this.txtServicio.Text = this._ServicioElegido.NombreServicio;
                this.txtTiempoServicio.Text = this._ServicioElegido.TiempoMinutos.ToString();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirServicioCita ~ btnElegirServicio_Click");
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
                    //this._ServicioElegido = this.ObtenerServicioSeleccionado();
                    //this._ClienteSeleccionado = this.ObtenerClienteSeleccionado();
                    this.DialogResult = DialogResult.OK;
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirServicioCita ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbServicio_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                Servicio DatosAux = this.ObtenerServicioSeleccionado();
                if (!string.IsNullOrEmpty(DatosAux.IDServicio))
                {
                    this.txtTiempoServicio.Text = DatosAux.TiempoMinutos.ToString();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirServicioCita ~ cmbServicio_SelectedValueChanged");
            }
        }

        private void frmElegirServicioCita_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirServicioCita ~ frmElegirServicioCita_Load");
            }
        }

        #endregion

    }
}
