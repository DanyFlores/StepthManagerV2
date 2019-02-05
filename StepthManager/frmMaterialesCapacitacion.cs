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
    public partial class frmMaterialesCapacitacion : Form
    {
        #region Propiedades / Variables
        private bool EsBusqueda = false;
        #endregion

        #region Constructor(es)

        public frmMaterialesCapacitacion()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMaterialesCapacitacion ~ frmMaterialesCapacitacion(Pedido Datos)");
            }
        }

        #endregion

        #region Métodos

        private void CargarGridMateriales()
        {
            try
            {
                Pedido DatosAux = new Pedido {Conexion = Comun.Conexion, BuscarTodos = this.chkTodos.Checked, IDSucursal = Comun.IDSucursalCaja };
                Pedido_Negocio PedNeg = new Pedido_Negocio();
                PedNeg.ObtenerMaterialesCapacitacion(DatosAux);
                this.dgvPedidoDetalle.AutoGenerateColumns = false;
                BindingSource Binding = new BindingSource();
                Binding.DataSource = DatosAux.TablaDatos;
                this.dgvPedidoDetalle.DataSource = Binding;
                this.DibujarColoresGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridMaterialesBusq()
        {
            try
            {
                Pedido DatosAux = new Pedido { Conexion = Comun.Conexion, BuscarTodos = this.chkTodos.Checked, TextoBusqueda = this.txtBusqueda.Text.Trim(), IDSucursal = Comun.IDSucursalCaja };
                Pedido_Negocio PedNeg = new Pedido_Negocio();
                PedNeg.ObtenerMaterialesCapacitacionBusq(DatosAux);
                this.dgvPedidoDetalle.AutoGenerateColumns = false;
                BindingSource Binding = new BindingSource();
                Binding.DataSource = DatosAux.TablaDatos;
                this.dgvPedidoDetalle.DataSource = Binding;
                this.DibujarColoresGrid();
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
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
                this.CargarGridMateriales();
                this.ActiveControl = this.txtBusqueda;
                this.txtBusqueda.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void DibujarColoresGrid()
        {
            try
            {
                foreach (DataGridViewRow Fila in this.dgvPedidoDetalle.Rows)
                {
                    int CantMetrica = 0, MargenError = 0, Usos = 0;
                    int.TryParse(Fila.Cells["CantidadMetrica"].Value.ToString(), out CantMetrica);
                    int.TryParse(Fila.Cells["MargenError"].Value.ToString(), out MargenError);
                    int.TryParse(Fila.Cells["CantidadUsos"].Value.ToString(), out Usos);
                    if ((CantMetrica - MargenError) <= Usos)
                    {
                        //Fila.DefaultCellStyle.BackColor = Color.Green;
                        Fila.Cells["CantidadUsos"].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        //Fila.DefaultCellStyle.BackColor = Color.Red;
                        Fila.Cells["CantidadUsos"].Style.BackColor = Color.Red;
                    }
                    Fila.Selected = false;
                }
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
                this.CargarGridMaterialesBusq();
                this.EsBusqueda = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMaterialesCapacitacion ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarBusq_Click(object sender, EventArgs e)
        {
            try
            {
                if (EsBusqueda)
                {
                    this.CargarGridMateriales();
                    this.txtBusqueda.Text = string.Empty;
                    this.EsBusqueda = false;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMaterialesCapacitacion ~ btnCancelarBusq_Click");
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
                LogError.AddExcFileTxt(ex, "frmMaterialesCapacitacion ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMaterialesCapacitacion_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMaterialesCapacitacion ~ frmMaterialesCapacitacion_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnAgregarMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoPedidoProducto NuevoMaterial = new frmNuevoPedidoProducto();
                NuevoMaterial.ShowDialog();
                NuevoMaterial.Dispose();
                if (NuevoMaterial.DialogResult == DialogResult.OK)
                {
                    if (this.EsBusqueda)
                        this.CargarGridMaterialesBusq();
                    else
                        this.CargarGridMateriales();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMaterialesCapacitacion ~ btnAgregarMaterial_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemplazar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPedidoDetalle.SelectedRows.Count == 1)
                {
                    int Row = this.dgvPedidoDetalle.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    PedidoDetalle DatosAux = this.ObtenerDatosGrid(Row);
                }
                else
                {
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMaterialesCapacitacion ~ btnRemplazar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)Keys.Enter)
                {
                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMaterialesCapacitacion ~ txtBusqueda_KeyPress");
            }
        }

        private PedidoDetalle ObtenerDatosGrid(int Row)
        {
            try
            {
                PedidoDetalle DatosAux = new PedidoDetalle();
                DataGridViewRow Fila = this.dgvPedidoDetalle.Rows[Row];
                DatosAux.IDAsignacion = Fila.Cells["IDAsignacion"].Value.ToString();
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
