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
using System.IO;

namespace StephManager
{
    public partial class frmValesXClientes : Form
    {
        #region Propiedades / Variables

        private Vales _DatosVales;
        public Vales DatosVales
        {
            get { return _DatosVales; }
            set { _DatosVales = value; }
        }
        Cliente AsignarCliente = new Cliente();

        #endregion

        public frmValesXClientes(Vales Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosVales = Datos;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmValesXClientes ~ frmValesXClientes()");
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
                this.CargarDatosAModificar(_DatosVales);
                this.CargarLlenarGridClientesXVales();
                this.ActiveControl = this.btnElegirCliente;
                this.btnElegirCliente.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDatosAModificar(Vales Datos)
        {
            try
            {
                this.txtNombreVale.Text = this._DatosVales.Nombre;
                this.txtFolioVale.Text = this._DatosVales.Folio;
                this.txtCantidadLimite.Text = this._DatosVales.CantLimite.ToString();
                this.txtTipoVale.Text = this._DatosVales.NombreTipoVale;
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

        private Vales ObtenerDatos()
        {
            try
            {
                Vales DatosAux = new Vales();
                DatosAux.IDValesXClientes = this._DatosVales.IDValesXClientes;
                DatosAux.IDCliente = this.AsignarCliente.IDCliente;
                DatosAux.NombreCliente = this.AsignarCliente.Nombre;
                DatosAux.IDVale = this._DatosVales.IDVale;
                DatosAux.Opcion = 1;
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarLlenarGridClientesXVales()
        {
            try
            {
                Vales DatosAux = new Vales();
                Vales_Negocio CN = new Vales_Negocio();
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDVale = this._DatosVales.IDVale;
                CN.ObternerValesXClientes(DatosAux);
                this.dgvClientes.DataSource = null;
                this.dgvClientes.AutoGenerateColumns = false;
                this.dgvClientes.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Vales ObtenerDatosGridClientes()
        {
            try
            {
                Vales DatosAux = new Vales();
                Int32 RowData = this.dgvClientes.Rows.GetFirstRow(DataGridViewElementStates.Selected);

                if (RowData > -1)
                {
                    DataGridViewRow Fila = dgvClientes.Rows[RowData];
                    DatosAux.IDValesXClientes = Fila.Cells["IDValeXCliente"].Value.ToString();
                    DatosAux.IDVale = Fila.Cells["IDVale"].Value.ToString();
                    DatosAux.IDCliente = Fila.Cells["IDCliente"].Value.ToString();
                    DatosAux.NombreCliente = Fila.Cells["NombreCliente"].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmValesXClientes_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmValesXClientes ~ frmValesXClientes_Load");
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
                LogError.AddExcFileTxt(ex, "frmValesXClientes ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Error> ValidarDatos()
        {
            try
            {
                List<Error> Errores = new List<Error>();
                int Aux = 0;
                if (string.IsNullOrEmpty(AsignarCliente.IDCliente))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un cliente.", ControlSender = this.btnElegirCliente });
                return Errores;
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
                frmSeleccionarCliente ElegirCliente = new frmSeleccionarCliente();
                ElegirCliente.Location = this.txtClientes.PointToScreen(new Point());
                ElegirCliente.Location = new Point(ElegirCliente.Location.X - 1, ElegirCliente.Location.Y - 2);
                ElegirCliente.ShowDialog();
                ElegirCliente.Dispose();
                if (ElegirCliente.DialogResult == DialogResult.OK)
                {
                    this.AsignarCliente = ElegirCliente.Datos;
                    this.txtClientes.Text = this.AsignarCliente.Nombre;
                    this.btnGuardarCliente.Focus();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmValesXClientes ~ btnElegirCliente_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtMensajeError.Visible = false;
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                    Vales Datos = this.ObtenerDatos();
                    Vales_Negocio cn = new Vales_Negocio();
                    cn.ABCClientesXVales(Datos);
                    if (Datos.Completado)
                    {
                        this.CargarLlenarGridClientesXVales();
                        //this._DatosVales = Datos;
                    }
                    else
                    {
                        MessageBox.Show("El cliente ya existe para este vale.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmValesXClientes ~ btnGuardarCliente_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
             try
            {
                Vales DatosAux = this.ObtenerDatosGridClientes();
                if (!string.IsNullOrEmpty(DatosAux.IDCliente))
                {
                    if (MessageBox.Show("¿Está seguro de eliminar el cliente " + DatosAux.NombreCliente + "?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DatosAux.IDUsuario = Comun.IDUsuario;
                        DatosAux.Conexion = Comun.Conexion;
                        Vales_Negocio VN = new Vales_Negocio();
                        VN.EliminarValesXClientes(DatosAux);
                        if (DatosAux.Completado)
                        {
                            this.CargarLlenarGridClientesXVales();
                            //this._DatosVales = DatosAux;
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al guardar los datos. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
             catch (Exception ex)
             {
                 LogError.AddExcFileTxt(ex, "frmVales ~ btnEliminarCliente_Click");
                 MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }
    }
}
