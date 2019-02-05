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
    public partial class frmNuevaActividadOpcionesCheckList : Form
    {

        #region Propiedades / Variables 
        private int TipoForm = 0;
        private ChechkList _DatosChechkList;
        public ChechkList DatosChechkList
        {
            get { return _DatosChechkList; }
            set { _DatosChechkList = value; }
        }
        #endregion

        #region Constructores

        public frmNuevaActividadOpcionesCheckList()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
            }
            catch(Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaActividadCheckList ~ frmNuevaActividadCheckList()");
            }
        }

        public frmNuevaActividadOpcionesCheckList(ChechkList DatosAux)
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 2;
                this._DatosChechkList = DatosAux;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaActividadCheckList ~ frmNuevaActividadCheckList(ChechkList DatosAux)");
            }
        }
        #endregion

        #region Métodos

        private void CargarDatosAModificar(ChechkList DatosAux)
        {
            try
            {
                this.txtTipoCheck.Text = DatosAux.TipoCheck;
                this.txtTitulo.Text = DatosAux.Titulo;
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
                this.LlenarGridChecListActividadOp(false, this._DatosChechkList.IDCheckList);
                if (this.TipoForm ==1)
                    this.IniciarDatos();
                else
                    this.CargarDatosAModificar(this._DatosChechkList);
                    this.ActiveControl = this.btnAgregarActividad;
                this.btnAgregarActividad.Focus();
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

        private void IniciarDatos()
        {
            try
            {
                this.txtTipoCheck.Text = string.Empty;
                this.txtTitulo.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridChecListActividadOp(bool Band, string IDCheckList)
        {
            try
            {
                ActividadOpcionesCheckList DatosAux = new ActividadOpcionesCheckList { Conexion = Comun.Conexion, BuscarTodos = Band, IDCheckList = IDCheckList };
                ActividadOpcionesCheckList_Negocio CN = new ActividadOpcionesCheckList_Negocio();
                CN.ObtenerCatActividadOpcionesCheck(DatosAux);
                this.dgvActividadesOpcionesCheckList.AutoGenerateColumns = false;
                this.dgvActividadesOpcionesCheckList.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ActividadOpcionesCheckList ObtenerDatosAvtividadCheckList()
        {
            try
            {
                ActividadOpcionesCheckList DatosAux = new ActividadOpcionesCheckList();
                Int32 RowData = this.dgvActividadesOpcionesCheckList.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowData > -1)
                {
                    DataGridViewRow FilaDatos = this.dgvActividadesOpcionesCheckList.Rows[RowData];
                    DatosAux.IDActividadOpciones = Convert.ToInt32(FilaDatos.Cells["IDActividadOpciones"].Value.ToString());
                    DatosAux.Valor = Convert.ToInt32(FilaDatos.Cells["Valor"].Value.ToString());
                    DatosAux.Descripcion = FilaDatos.Cells["NombreOpciones"].Value.ToString();
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ModificarDatos(ActividadOpcionesCheckList Datos)
        {
            try
            {
                Int32 RowToUpdate = this.dgvActividadesOpcionesCheckList.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowToUpdate > -1)
                {
                    this.dgvActividadesOpcionesCheckList.Rows[RowToUpdate].Cells["IDActividadOpciones"].Value = Datos.IDActividadOpciones;
                    this.dgvActividadesOpcionesCheckList.Rows[RowToUpdate].Cells["Valor"].Value = Datos.Valor;
                    this.dgvActividadesOpcionesCheckList.Rows[RowToUpdate].Cells["NombreOpciones"].Value = Datos.Descripcion;
                }
                else
                    this.LlenarGridChecListActividadOp(false, _DatosChechkList.IDCheckList);
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
                LogError.AddExcFileTxt(ex, "frmNuevaActividadCheckList ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmNuevaActividadCheckList_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    #endregion

        private void btnAgregarActividad_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoOpcionesCheklist Check = new frmNuevoOpcionesCheklist(this._DatosChechkList.IDCheckList);
                Check.ShowDialog();
                Check.Dispose();
                this.Visible = true;
                if (Check.DialogResult == DialogResult.OK)
                {
                    this.LlenarGridChecListActividadOp(false, Check.DatosActividadOp.IDCheckList);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaActividadCheckList ~ btnAgregarActividad_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnQuitarActividad_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvActividadesOpcionesCheckList.SelectedRows.Count == 1)
                {
                    ActividadOpcionesCheckList DatosAux = this.ObtenerDatosAvtividadCheckList();
                    if (DatosAux.IDActividadOpciones != 0)
                    {
                        DatosAux.Conexion = Comun.Conexion;
                        DatosAux.IDUsuario = Comun.IDUsuario;
                        DatosAux.Opcion = 3;
                        ActividadOpcionesCheckList_Negocio ACLN = new ActividadOpcionesCheckList_Negocio();
                        ACLN.ABCActividadOpcinesChecKList(DatosAux);
                        if (DatosAux.Completado)
                        {
                            MessageBox.Show("Registro Eliminado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Int32 RowToDelete = this.dgvActividadesOpcionesCheckList.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                            if (RowToDelete > -1)
                                this.dgvActividadesOpcionesCheckList.Rows.RemoveAt(RowToDelete);
                            else
                                this.LlenarGridChecListActividadOp(false, DatosChechkList.IDCheckList);
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar los datos. Contacte a Soporte Técnico.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaActividadCheckList ~ btnQuitarActividad_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnModificarActividad_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvActividadesOpcionesCheckList.SelectedRows.Count == 1)
                {
                    ActividadOpcionesCheckList DatosAux = this.ObtenerDatosAvtividadCheckList();
                    if (DatosAux.IDActividadOpciones != 0)
                    {
                        this.Visible = true;
                        frmNuevoOpcionesCheklist CheckLsis = new frmNuevoOpcionesCheklist(DatosAux, this._DatosChechkList.IDCheckList);
                        CheckLsis.ShowDialog();
                        CheckLsis.Dispose();
                        if (CheckLsis.DialogResult == DialogResult.OK)
                        {
                            if (CheckLsis.DatosActividadOp.Completado)
                            {
                                this.ModificarDatos(CheckLsis.DatosActividadOp);
                            }
                        }
                        this.Visible = true;
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaActividadCheckList ~ btnModificarActividad_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }
    }
}