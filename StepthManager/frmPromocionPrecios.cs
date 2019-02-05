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
    public partial class frmPromocionPrecios : Form
    {
        private int IDPromocion = 0;

        #region Constructores

        public frmPromocionPrecios(int _IDPromocion)
        {
            try
            {
                InitializeComponent();
                IDPromocion = _IDPromocion;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPromocionPrecios ~ frmPromocionPrecios(int _IDPromocion)");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
                this.LlenarGridSucursales();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridSucursales()
        {
            try
            {
                Promocion_Negocio PromNeg = new Promocion_Negocio();
                this.dgvSucursalesPromo.AutoGenerateColumns = false;
                this.dgvSucursalesPromo.DataSource = PromNeg.ObtenerPreciosXSucursalPromocion(Comun.Conexion, IDPromocion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Sucursal ObtenerDatosGrid(int RowData)
        {
            try
            {
                Sucursal DatosAux = new Sucursal();
                if (RowData > -1)
                {
                    DataGridViewRow FilaDatos = this.dgvSucursalesPromo.Rows[RowData];
                    DatosAux.IDSucursal = FilaDatos.Cells["IDSucursal"].Value.ToString();
                    DatosAux.NombreSucursal = FilaDatos.Cells["NombreSucursal"].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Abort;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPromocionPrecios ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPromocionPrecios_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPromocionPrecios ~ frmPromocionPrecios_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        
        private void btnCambiarPrecio_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvSucursalesPromo.SelectedRows.Count == 1)
                {
                    Int32 RowData = this.dgvSucursalesPromo.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Sucursal _Sucursal = this.ObtenerDatosGrid(RowData);
                    PromocionXSucursal _Datos = new PromocionXSucursal { IDSucursal = _Sucursal.IDSucursal, NombreSucursal = _Sucursal.NombreSucursal, IDPromocion = IDPromocion};
                    frmPromocionPreciosModificar ModificarPrecio = new frmPromocionPreciosModificar(_Datos);
                    ModificarPrecio.ShowDialog();
                    ModificarPrecio.Dispose();
                    if(ModificarPrecio.DialogResult == DialogResult.OK)
                    {
                        this.LlenarGridSucursales();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una fila.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPromocionPrecios ~ btnCambiarPrecio_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
