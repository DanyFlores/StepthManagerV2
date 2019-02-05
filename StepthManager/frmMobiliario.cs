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
    public partial class frmMobiliario : Form
    {
        #region Variables
        private string IDSucBusq = string.Empty;
        #endregion

        #region Constructor

        public frmMobiliario()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliario ~ frmMobiliario()");
            }
        }

        #endregion

        #region Métodos

        private void CargarComboSucursales()
        {
            try
            {
                Sucursal DatosSuc = new Sucursal { Conexion = Comun.Conexion, Opcion = 2 };
                Sucursal_Negocio SucNeg = new Sucursal_Negocio();
                this.cmbSucursales.DataSource = SucNeg.LlenarComboCatSucursales(DatosSuc);
                this.cmbSucursales.ValueMember = "IDSucursal";
                this.cmbSucursales.DisplayMember = "NombreSucursal";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGrid()
        {
            try
            {
                Sucursal SucDatos = this.ObtenerSucursalCombo();
                this.IDSucBusq = SucDatos.IDSucursal;
                Mobiliario Datos = new Mobiliario { Conexion = Comun.Conexion, IDSucursal = SucDatos.IDSucursal };
                Mobiliario_Negocio MN = new Mobiliario_Negocio();
                MN.ObtenerMobiliarioAsignadoXIDSuc(Datos);
                if (Datos.Completado)
                {
                    this.dgvPedidos.AutoGenerateColumns = false;
                    this.dgvPedidos.DataSource = Datos.TablaDatos;
                }
                else
                {
                    this.dgvPedidos.AutoGenerateColumns = false;
                    this.dgvPedidos.DataSource = null;
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
                this.CargarComboSucursales();
                this.ActiveControl = this.cmbSucursales;
                this.cmbSucursales.Focus();
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

        private Sucursal ObtenerSucursalCombo()
        {
            try
            {
                Sucursal DatosAux = new Sucursal();
                if (this.cmbSucursales.Items.Count > 0)
                {
                    if (this.cmbSucursales.SelectedIndex != -1)
                    {
                        DatosAux = (Sucursal)this.cmbSucursales.SelectedItem;
                    }
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Mobiliario ObtenerDatosGrid(int Row)
        {
            try
            {
                Mobiliario Datos = new Mobiliario();
                DataGridViewRow Fila = this.dgvPedidos.Rows[Row];
                Datos.IDMobiliarioXSucursal = Fila.Cells["IDMobiliarioXSucursal"].Value.ToString();
                Datos.IDSucursal = Fila.Cells["IDSucursal"].Value.ToString();
                Datos.Codigo = Fila.Cells["Codigo"].Value.ToString();
                Datos.NombreSucursal = Fila.Cells["NombreSucursal"].Value.ToString();
                Datos.Descripcion = Fila.Cells["MobiliarioDesc"].Value.ToString();
                Datos.Conexion = Comun.Conexion;
                Datos.IDUsuario = Comun.IDUsuario;
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnBajaMobiliario_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPedidos.SelectedRows.Count == 1)
                {
                    int Row = this.dgvPedidos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Mobiliario Datos = this.ObtenerDatosGrid(Row);
                    Mobiliario_Negocio MN = new Mobiliario_Negocio();
                    if(MessageBox.Show("¿Está seguro de dar de baja el mobiliario seleccionado? Recuerde que éste proceso no es reversible.", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    MN.BajaMobiliario(Datos);
                    if (Datos.Completado)
                    {
                        this.cmbSucursales.SelectedValue = this.IDSucBusq;
                        this.CargarGrid();
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliario ~ btnBajaMobiliario_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarGrid();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliario ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            try
            {
                frmComprasMobiliario Compras = new frmComprasMobiliario();
                this.Visible = false;
                Compras.ShowDialog();
                Compras.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmMobiliario ~ btnCompras_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTranferencia_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPedidos.SelectedRows.Count == 1)
                {
                    int Row = this.dgvPedidos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Mobiliario Datos = this.ObtenerDatosGrid(Row);
                    frmMobiliarioTransferencia Transferir = new frmMobiliarioTransferencia(Datos);
                    Transferir.ShowDialog();
                    Transferir.Dispose();
                    if (Transferir.DialogResult == DialogResult.OK)
                    {
                        this.cmbSucursales.SelectedValue = this.IDSucBusq;
                        this.CargarGrid();
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliario ~ btnTranferencia_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResguardoMobiliario_Click(object sender, EventArgs e)
        {
            try
            {
                frmMobiliario_Resguardo MobiliarioResguardo = new frmMobiliario_Resguardo();
                this.Visible = false;
                MobiliarioResguardo.ShowDialog();
                MobiliarioResguardo.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmMobiliario ~ btnResguardoMobiliario_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCatMobiliario_Click(object sender, EventArgs e)
        {
            try
            {
                frmCatMobiliario CatMob = new frmCatMobiliario();
                this.Visible = false;
                CatMob.ShowDialog();
                this.Visible = true;
                CatMob.Dispose();
            }
            catch (Exception ex)
            {
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "frmMobiliario ~ btnCatMobiliario_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliario ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMobiliario_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMobiliario ~ frmMobiliario_Load");
            }
        }

        #endregion

    }
}
