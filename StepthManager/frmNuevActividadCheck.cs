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
    public partial class frmNuevActividadCheck : Form
    {

        #region Propiedades / Variables 
        
        private int TipoForm = 0;
        private ChechkList _DatosCheckList;
        public ChechkList DatosCheckList
        {
            get { return _DatosCheckList; }
            set { _DatosCheckList = value; }
        }

        private ActividadesCheckList _DatosActividadCheckList;
        public ActividadesCheckList DatosActividadCheckList
        {
            get { return _DatosActividadCheckList; }
            set { _DatosActividadCheckList = value; }
        }
        #endregion

        #region Constructores

        public frmNuevActividadCheck(ChechkList DatosAux)
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
                this._DatosCheckList = DatosAux;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevActividadCheck ~ frmNuevActividadCheck()");
            }
        }
        public frmNuevActividadCheck(ActividadesCheckList DatosAux, ChechkList DatosAux1)
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 2;
                this._DatosActividadCheckList = DatosAux;
                this._DatosCheckList = DatosAux1;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevActividadCheck ~ frmNuevActividadCheck()");
            }
        }
        #endregion

        #region Métodos

        private void CargarDatosAModificar(ActividadesCheckList DatosAux)
        {
            try
            {
                if (this.ExisteItemEnCombo(DatosAux.IDCategoriaChe))
                    this.cmbCategoria.SelectedValue = DatosAux.IDCategoriaChe;
                this.txtTitulo.Text = DatosAux.Descripcion;
                this.txtOrden.Text = Convert.ToString(DatosAux.Orden);
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
                if (this.cmbCategoria.Items.Count > 0)
                {
                    foreach (CategoriaCheckList Aux in this.cmbCategoria.Items)
                    {
                        if (Aux.IDCategoriaChe == ID)
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
                this.LlenarComboCategoriaCheck(_DatosCheckList.IDCheckList);
                if (this.TipoForm ==1)
                    this.IniciarDatos();
                else
                    this.CargarDatosAModificar(this._DatosActividadCheckList);
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
                this.txtOrden.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboCategoriaCheck(string IDCheckList)
        {
            try
            {
                CategoriaCheckList Datos = new CategoriaCheckList { IncluirSelect = true, Conexion = Comun.Conexion, IDCheckList = IDCheckList};
                CategoriaCheckList_Negocio CN= new CategoriaCheckList_Negocio();
                this.cmbCategoria.DataSource = CN.LlenarComboCategoriaCheck(Datos);
                this.cmbCategoria.DisplayMember = "Descripcion";
                this.cmbCategoria.ValueMember = "IDCategoriaChe";
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

        private CategoriaCheckList ObtenerItemSeleccionado()
        {
            try
            {
                CategoriaCheckList DatosAux = new CategoriaCheckList();
                if (this.cmbCategoria.SelectedIndex != -1)
                {
                    DatosAux = (CategoriaCheckList)this.cmbCategoria.SelectedItem;
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ActividadesCheckList ObtenerDatos()
        {
            try
            {
                ActividadesCheckList Datos = new ActividadesCheckList();
                CategoriaCheckList TPAux = this.ObtenerItemSeleccionado();
                Datos.IDActividades = TipoForm == 2 ? this._DatosActividadCheckList.IDActividades : 0;
                Datos.Conexion = Comun.Conexion;
                Datos.IDCategoriaChe = TPAux.IDCategoriaChe;
                Datos.NombreCategoria = TPAux.Descripcion;
                Datos.Opcion = this.TipoForm;
                Datos.Descripcion = this.txtTitulo.Text;
                Datos.Orden = Convert.ToInt32(this.txtOrden.Text);
                Datos.IDCheckList = this._DatosCheckList.IDCheckList;
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
                CategoriaCheckList TPAux = this.ObtenerItemSeleccionado();
                if (TPAux.IDCategoriaChe <= 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una categoria", ControlSender = this.cmbCategoria });
                if (string.IsNullOrEmpty(this.txtTitulo.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un título.", ControlSender = this.txtTitulo });
                if (string.IsNullOrEmpty(this.txtOrden.Text.Trim()))
                {
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un orden.", ControlSender = this.txtTitulo });
                }
                else
                {
                    if (!Validar.IsValidOnlyNumber(this.txtOrden.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar numero de orden válido.", ControlSender = this.txtOrden });
                }
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
                LogError.AddExcFileTxt(ex, "frmNuevActividadCheck ~ btnCancelar_Click");
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
                    ActividadesCheckList Datos = this.ObtenerDatos();
                    ActividadCheckList_Negocio ACN = new ActividadCheckList_Negocio();
                    ACN.ABCActividadChecKList(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosActividadCheckList = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (Datos.Resultado == -2)
                        {
                            MessageBox.Show("El orden ya existe para esa categoria", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al guardar los datos.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    this.MostrarMensajeError(ListaErrores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevActividadCheck ~ btnGuardar_Click");
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

        private void btnAgregarCat_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoCategoriaActividadCheklist Check = new frmNuevoCategoriaActividadCheklist(this._DatosCheckList.IDCheckList);
                Check.ShowDialog();
                Check.Dispose();
                this.Visible = true;
                if (Check.DialogResult == DialogResult.OK)
                {
                    this.LlenarComboCategoriaCheck(Check.IDCheckList);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevActividadCheck ~ frmNuevActividadCheck");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }
    }
}