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
    public partial class frmHistCita : Form
    {
        #region Propiedades / Variables
        private Cliente _DatosClientes;
        public Cliente DatosClientes
        {
            get { return _DatosClientes; }
            set { _DatosClientes = value; }
        }
        private string IDClientesHist= string.Empty;
        private List<Cliente> ListadeCitasXClientes = new List<Cliente>();
        #endregion

        #region Constructor(es)

        public frmHistCita(Cliente Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosClientes = Datos;
                this.IDClientesHist = Datos.IDCliente;

            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmHistCita ~ frmHistCita(Cliente Datos)");
            }
        }

        #endregion

        #region Métodos

        private void CargarGridPedidoDetalle()
        {
            try
            {
                this.dgvHistorialCitas.AutoGenerateColumns = false;
                this.dgvHistorialCitas.DataSource = null;
                this.dgvHistorialCitas.DataSource = this.ListadeCitasXClientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void CargarDatosAModificar(Cliente Datos)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.IDClientesHist.Trim()))
                {
                    this.ListadeCitasXClientes = Datos.ListaHistClientes;
                    this.CargarGridPedidoDetalle();
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
                Cliente DatosAux = this.CargarGribMobiliarioDetalle();
                this.CargarDatosAModificar(DatosAux);
                this.ActiveControl = this.btnCancelar;
                this.btnCancelar.Focus();
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

        private Cliente CargarGribMobiliarioDetalle()
        {
            try
            {
                Cliente DatosAux = new Cliente { Conexion = Comun.Conexion, IDCliente = this.IDClientesHist };
                Cliente_Negocio CNNeg = new Cliente_Negocio();
                return CNNeg.ObtenerHistoriaCliente(DatosAux);
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
                LogError.AddExcFileTxt(ex, "frmHistCita ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmHistCita_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmHistCita ~ frmHistCita_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
