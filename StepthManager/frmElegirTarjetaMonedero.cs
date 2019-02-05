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
using CreativaSL.LibControls.WinForms;
using StephManager.ClasesAux;
using System.IO;

namespace StephManager
{
    public partial class frmElegirTarjetaMonedero : Form
    {
        #region Propiedades / Variables
        private string IDCliente = string.Empty;
        //private decimal Saldo = 0;
        private List<TarjetaMonedero> DatosActuales = new List<TarjetaMonedero>();
        private TarjetaMonedero _Seleccionado;
        public TarjetaMonedero Seleccionado
        {
            get { return _Seleccionado; }
            set { _Seleccionado = value; }
        }
        
        #endregion

        #region Constructor

        public frmElegirTarjetaMonedero(string IDClienteParam)
        {
            try
            {
                InitializeComponent();
                IDCliente = IDClienteParam;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTarjetaMonedero ~ frmElegirTarjetaMonedero()");

            }
        }

        #endregion

        #region Métodos

        private Cliente AsignarTarjetaCliente(string IDTarjeta)
        {
            try
            {
                Cliente Datos = new Cliente();
                Cliente_Negocio CN = new Cliente_Negocio();
                Datos.IDCliente = IDCliente;
                Datos.Conexion = Comun.Conexion;
                Datos.IDUsuario = Comun.IDUsuario;
                Datos.IDTarjeta = IDTarjeta;
                CN.AsignarMonederoCliente(Datos);
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Busqueda(string TextoBusqueda)
        {
            try
            {
                if (!string.IsNullOrEmpty(TextoBusqueda.Trim()))
                {
                    List<TarjetaMonedero> Resultados = this.DatosActuales.FindAll(x => x.Folio.ToUpper().Contains(TextoBusqueda.ToUpper()));
                    this.dgvTarjetas.DataSource = Resultados;
                }
                else
                {
                    this.dgvTarjetas.DataSource = this.DatosActuales;
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
                this.txtBusqueda.Text = string.Empty;
                this.txtBusqueda.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridTarjetas()
        {
            try
            {
                TarjetaMonedero Datos = new TarjetaMonedero { Conexion = Comun.Conexion};
                Cliente_Negocio CN = new Cliente_Negocio();
                List<TarjetaMonedero> ListaDatos = CN.ObtenerCatTarjetasDisponibles(Datos);
                this.DatosActuales = ListaDatos;
                this.dgvTarjetas.AutoGenerateColumns = false;
                this.dgvTarjetas.DataSource = ListaDatos;
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

        private void MostrarMensaje(int Resultado)
        {
            try
            {
                List<Error> ListaErrores = new List<Error>();
                switch (Resultado)
                {
                    case -1: ListaErrores.Add(new Error { Numero = 1, Descripcion ="La tarjeta ya no está disponible. Por favor, seleccione otra.", ControlSender = this.dgvTarjetas });
                        break;
                    case -2: ListaErrores.Add(new Error { Numero = 1, Descripcion = "La tarjeta ya no está disponible. Por favor, seleccione otra.", ControlSender = this.dgvTarjetas });
                        break;
                }
                this.MostrarMensajeError(ListaErrores);
                Int32 RowSelected = this.dgvTarjetas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                this.dgvTarjetas.Rows.RemoveAt(RowSelected);
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

        private TarjetaMonedero ObtenerDatos(int Index)
        {
            try
            {
                DataGridViewRow Fila = this.dgvTarjetas.Rows[Index];
                TarjetaMonedero Datos = new TarjetaMonedero();
                int IDTipoMonedero = 0;
                int.TryParse(Fila.Cells["IDTipoMonedero"].Value.ToString(), out IDTipoMonedero);
                Datos.IDTarjeta = Fila.Cells["IDTarjeta"].Value.ToString();
                Datos.Folio = Fila.Cells["Folio"].Value.ToString();
                Datos.TipoMonederoDesc = Fila.Cells["TipoMonederoDesc"].Value.ToString();
                Datos.IDTipoMonedero = IDTipoMonedero;
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Busqueda(this.txtBusqueda.Text);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTarjetaMonedero ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                LogError.AddExcFileTxt(ex, "frmElegirTarjetaMonedero ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarBusqueda_Click(object sender, EventArgs e)
        {
            try
            {
                this.dgvTarjetas.DataSource = DatosActuales;
                this.txtBusqueda.Text = string.Empty;
                this.txtBusqueda.Focus();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTarjetaMonedero ~ btnCancelarBusqueda_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTarjetas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {                
                if (e.RowIndex >= 0)
                {
                    this.txtMensajeError.Visible = false;
                    this._Seleccionado = this.ObtenerDatos(e.RowIndex);
                    Cliente Aux = this.AsignarTarjetaCliente(this.Seleccionado.IDTarjeta);
                    if (Aux.Completado)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        this.MostrarMensaje(Aux.Resultado);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTarjetaMonedero ~ dgv_Tarjetas_CellDoubleClick");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTarjetas_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.txtMensajeError.Visible = false;
                    if (this.dgvTarjetas.SelectedRows.Count == 1)
                    {
                        Int32 RowSelected = this.dgvTarjetas.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                        this._Seleccionado = this.ObtenerDatos(RowSelected);
                        Cliente Aux = this.AsignarTarjetaCliente(this.Seleccionado.IDTarjeta);
                        if (Aux.Completado)
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            this.MostrarMensaje(Aux.Resultado);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTarjetaMonedero ~ txtBusqueda_KeyUp");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmElegirTarjetaMonedero_Load(object sender, EventArgs e)
        {
            try
            {
                this.LlenarGridTarjetas();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTarjetaMonedero ~ frmElegirTarjetaMonedero_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Busqueda(this.txtBusqueda.Text);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmElegirTarjetaMonedero ~ txtBusqueda_KeyUp");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
