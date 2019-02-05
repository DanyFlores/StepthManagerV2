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
using System.Globalization;
using System.IO;

namespace StephManager
{
    public partial class frmCheckListRespuesta : Form
    {
        private ChechkList _DatosCheckList;
        public ChechkList DatosCheckList
        {
            get { return _DatosCheckList; }
            set { _DatosCheckList = value; }
        }

        #region Constructores

        public frmCheckListRespuesta()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCheckListRespuesta ~ frmCheckListRespuesta()");
            }
        }

        public frmCheckListRespuesta(ChechkList DatosAux)
        {
            try
            {
                InitializeComponent();
                this._DatosCheckList = DatosAux;
                this.txtTitulo.Text = this._DatosCheckList.Titulo;
                this.txtTipo.Text = this._DatosCheckList.TipoCheck;
                if (this._DatosCheckList.IDTipoCheckList == 2)
                {
                    this.dgvCheckListRespuesta.Columns["NombreEmpleado"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCheckListRespuesta ~ frmCheckListRespuesta()");
            }
        }
        #endregion

        #region Métodos
        private void IniciarForm()
        {
            try
            {
                this.LlenarGridChecListResultado(false, this._DatosCheckList.IDCheckList);
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

        private void LlenarGridChecListResultado(bool Band, string ID)
        {
            try
            {
                ChechkListResultado DatosAux = new ChechkListResultado { Conexion = Comun.Conexion, BuscarTodos = Band, IDCheckList = ID };
                CheckListResultado_Negocio CN = new CheckListResultado_Negocio();
                CN.ObtenerCatCheckResultado(DatosAux);
                this.dgvCheckListRespuesta.AutoGenerateColumns = false;
                this.dgvCheckListRespuesta.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BusquedaCheck(string TextoCheck)
        {
            try
            {
                ChechkList DatosAux = new ChechkList { Conexion = Comun.Conexion, Titulo = TextoCheck, BuscarTodos = false };
                CheckList_Negocio CN = new CheckList_Negocio();
                CN.ObtenercheckBusqueda(DatosAux);
                this.dgvCheckListRespuesta.AutoGenerateColumns = false;
                this.dgvCheckListRespuesta.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ChechkListResultado ObtenerDatosCheckListResul()
        {
            try
            {
                ChechkListResultado DatosAux = new ChechkListResultado();
                Int32 RowData = this.dgvCheckListRespuesta.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowData > -1)
                {
                    DataGridViewRow FilaDatos = this.dgvCheckListRespuesta.Rows[RowData];
                    DatosAux.IDCheckList = FilaDatos.Cells["IDCheckList"].Value.ToString();
                    DatosAux.IDResultado = FilaDatos.Cells["IDResultado"].Value.ToString();
                    DatosAux.IDSucursal = FilaDatos.Cells["IDSucursal"].Value.ToString();
                    DatosAux.IDEmpleado = FilaDatos.Cells["IDEmpleado"].Value.ToString();
                    DatosAux.FechaAplicacion = Convert.ToDateTime(FilaDatos.Cells["Fecha"].Value.ToString());
                    DatosAux.NombreEmpleado = FilaDatos.Cells["NombreEmpleado"].Value.ToString();
                    DatosAux.NombreSucursal = FilaDatos.Cells["NombreSucursal"].Value.ToString();
                    DatosAux.HoraAplicacion = FilaDatos.Cells["Hora"].Value.ToString();
                    DatosAux.Responsable = FilaDatos.Cells["Responsable"].Value.ToString();
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
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCheckListRespuesta ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCheckList_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCheckListRespuesta ~ frmEncuestas_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
      
        private void btnResultado_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCheckListRespuesta.SelectedRows.Count == 1)
                {
                    ChechkListResultado DatosAux = this.ObtenerDatosCheckListResul();
                    if (!string.IsNullOrEmpty(DatosAux.IDResultado))
                    {
                        this.Visible = true;
                        frmVerRespuestaCheckList Opiniones = new frmVerRespuestaCheckList(1, this._DatosCheckList, DatosAux);
                        Opiniones.ShowDialog();
                        Opiniones.Dispose();
                        this.Visible = true;
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCheckListRespuesta ~ btnResultado_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

    }
}
