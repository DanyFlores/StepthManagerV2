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
    public partial class frmPromociones : Form
    {
        #region Constructores

        public frmPromociones()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPromociones ~ frmPromociones()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                this.LlenarGrid();
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

        private void LlenarGrid()
        {
            try
            {
                Promocion_Negocio PromNeg = new Promocion_Negocio();
                List<Promocion> Lista = PromNeg.ObtenerPromociones(Comun.Conexion, string.Empty);
                this.dgvPromociones.AutoGenerateColumns = false;
                this.dgvPromociones.DataSource = Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private Promocion ObtenerDatosPromocion()
        {
            try
            {
                Promocion DatosAux = new Promocion();
                Int32 RowData = this.dgvPromociones.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowData > -1)
                {
                    int ID = 0, IDEstatus = 0;
                    DataGridViewRow FilaDatos = this.dgvPromociones.Rows[RowData];
                    int.TryParse(FilaDatos.Cells["IDPromocion"].Value.ToString(), out ID);
                    int.TryParse(FilaDatos.Cells["IDEstatus"].Value.ToString(), out IDEstatus);
                    DatosAux.IDPromocion = ID;
                    DatosAux.IDEstatus = IDEstatus;
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmNuevaPromocion AgregarPromocion = new frmNuevaPromocion();
                AgregarPromocion.ShowDialog();
                if (AgregarPromocion.DialogResult == DialogResult.OK)
                {
                    LlenarGrid();
                }
                AgregarPromocion.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPromociones ~ btnNuevo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Abort;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPromociones ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPromociones.SelectedRows.Count == 1)
                {
                    Promocion Datos = this.ObtenerDatosPromocion();
                    Promocion_Negocio PromNeg = new Promocion_Negocio();
                    bool Complete = PromNeg.EliminarPromocion(Comun.Conexion, Datos.IDPromocion, Comun.IDUsuario);
                    if(Complete)
                    {
                        MessageBox.Show("Registro eliminado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LlenarGrid();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al eliminar el registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una fila.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPromociones ~ btnImpresion_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPromociones.SelectedRows.Count == 1)
                {
                    Promocion Datos = this.ObtenerDatosPromocion();
                    Promocion_Negocio PromNeg = new Promocion_Negocio();
                    bool Complete = PromNeg.CambiarEstatusPromocion(Comun.Conexion,Datos.IDPromocion, Comun.IDUsuario);
                    if (Complete)
                    {
                        if (Datos.IDEstatus == 1)
                        {
                            MessageBox.Show("Promoción desactivada.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if(Datos.IDEstatus == 2)
                        {
                            MessageBox.Show("Promoción activada.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        LlenarGrid();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al eliminar el registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una fila.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPromociones ~ btnActivar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void frmPromociones_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPromociones ~ frmPromociones_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPromociones.SelectedRows.Count == 1)
                {
                    Promocion Datos = this.ObtenerDatosPromocion();
                    this.Visible = false;
                    frmNuevaPromocion ModificarPromocion = new frmNuevaPromocion(Datos.IDPromocion);
                    ModificarPromocion.ShowDialog();
                    if (ModificarPromocion.DialogResult == DialogResult.OK)
                    {
                        LlenarGrid();
                    }
                    ModificarPromocion.Dispose();
                    this.Visible = true;
                }
                else
                {
                    MessageBox.Show("Seleccione una fila.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPromociones ~ btnModificar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }
        
        private void btnPrecios_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvPromociones.SelectedRows.Count == 1)
                {
                    Promocion Datos = this.ObtenerDatosPromocion();
                    this.Visible = false;
                    frmPromocionPrecios PreciosPromocion = new frmPromocionPrecios(Datos.IDPromocion);
                    PreciosPromocion.ShowDialog();
                    PreciosPromocion.Dispose();
                    this.Visible = true;
                }
                else
                {
                    MessageBox.Show("Seleccione una fila.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPromociones ~ btnPrecios_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        #endregion

    }
}
