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
    public partial class frmNuevoCheckList : Form
    {

        #region Propiedades / Variables 
        
        private int TipoForm = 0;
        private ChechkList _DatosCheckList;
        public ChechkList DatosCheckList
        {
            get { return _DatosCheckList; }
            set { _DatosCheckList = value; }
        }

        #endregion

        #region Constructores

        public frmNuevoCheckList()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
            }
            catch(Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCheckList ~ frmNuevoCheckList()");
            }
        }

        public frmNuevoCheckList(ChechkList DatosAux)
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 2;
                this._DatosCheckList = DatosAux;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCheckList ~ frmNuevoCheckList()");
            }
        }

        #endregion

        #region Métodos

        private void CargarDatosAModificar(ChechkList DatosAux)
        {
            try
            {
                if (this.ExisteItemEnCombo(DatosAux.IDTipoCheckList))
                    this.cmbTipoCheckList.SelectedValue = DatosAux.IDTipoCheckList;
                this.txtTitulo.Text = DatosAux.Titulo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExisteItemEnCombo(int ID)
        {
            try
            {
                bool Band = false;
                if (this.cmbTipoCheckList.Items.Count > 0)
                {
                    foreach (TipoChechkList Aux in this.cmbTipoCheckList.Items)
                    {
                        if (Aux.IDTipoCheckList == ID)
                        {
                            Band = true;
                            break;
                        }
                    }
                }
                return Band;
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
                this.LlenarComboTipoCheck();
                if (this.TipoForm ==1)
                    this.IniciarDatos();
                else
                    this.CargarDatosAModificar(this._DatosCheckList);
                this.ActiveControl = this.txtTitulo;
                this.txtTitulo.Focus();
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
                this.txtTitulo.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboTipoCheck()
        {
            try
            {
                TipoChechkList Datos = new TipoChechkList { IncluirSelect = true, Conexion = Comun.Conexion };
                CheckList_Negocio CN= new CheckList_Negocio();
                this.cmbTipoCheckList.DataSource = CN.LlenarComboTipoCheck(Datos);
                this.cmbTipoCheckList.DisplayMember = "Descripcion";
                this.cmbTipoCheckList.ValueMember = "IDTipoCheckList";
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

        private TipoChechkList ObtenerItemSeleccionado()
        {
            try
            {
                TipoChechkList DatosAux = new TipoChechkList();
                if (this.cmbTipoCheckList.SelectedIndex != -1)
                {
                    DatosAux = (TipoChechkList)this.cmbTipoCheckList.SelectedItem;
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ChechkList ObtenerDatos()
        {
            try
            {
                ChechkList Datos = new ChechkList();
                TipoChechkList TPAux = this.ObtenerItemSeleccionado();
                Datos.IDCheckList = this.TipoForm == 2 ? this._DatosCheckList.IDCheckList : string.Empty;
                Datos.Conexion = Comun.Conexion;
                Datos.IDTipoCheckList = TPAux.IDTipoCheckList;
                Datos.TipoCheck = TPAux.Descripcion;
                Datos.Opcion = this.TipoForm;
                Datos.Titulo = this.txtTitulo.Text;
                Datos.IDUsuario = Comun.IDUsuario;
                return Datos;
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
                List<Error> Errores = new List<Error>();
                int Aux = 0;
                if (string.IsNullOrEmpty(this.txtTitulo.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un título.", ControlSender = this.txtTitulo });
                TipoChechkList TPAux = this.ObtenerItemSeleccionado();
                if (TPAux.IDTipoCheckList <= 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un tipo", ControlSender = this.cmbTipoCheckList });
                
                return Errores;
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
                LogError.AddExcFileTxt(ex, "frmNuevoCheckList ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Error> ListaErrores = this.ValidarDatos();
                if (ListaErrores.Count == 0)
                {
                    ChechkList Datos = this.ObtenerDatos();
                    CheckList_Negocio cn = new CheckList_Negocio();
                    cn.ABCChecKList(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosCheckList = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al guardar los datos.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(ListaErrores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCheckList ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoCheckList_Load(object sender, EventArgs e)
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
    }
}