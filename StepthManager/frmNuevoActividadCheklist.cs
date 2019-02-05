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
using CreativaSL.Dll.Validaciones;
using System.IO;

namespace StephManager
{
    public partial class frmNuevoActividadCheklist : Form
    {

        #region Propiedades / Variables
        private int TipoForm = 0;
        private ActividadesCheckList _DatosActividad;
        public ActividadesCheckList DatosActividad
        {
            get { return _DatosActividad; }
            set { _DatosActividad = value; }
        }        
        #endregion

        #region Constructor

        public frmNuevoActividadCheklist()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoActividadCheklist ~ frmNuevoActividadCheklist()");
            }
        }

        public frmNuevoActividadCheklist(ActividadesCheckList Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosActividad = Datos;
                this.TipoForm = 2;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoActividadCheklist ~ frmNuevoActividadCheklist(CategoriaCheckList Datos)");
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
                this.LlenarComboCategoria();
                if (TipoForm == 1)
                    this.InicializarCampos();
                else
                    this.CargarDatosAModificar(_DatosActividad);
                this.ActiveControl = this.txtOrden;
                this.txtOrden.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDatosAModificar(ActividadesCheckList Datos)
        {
            try
            {
                this.txtDescripcion.Text = Datos.Descripcion;
                if (ExisteItemEnComboCategoria(Datos.IDCategoriaChe))
                    this.cmbCategoriaCheck.SelectedValue = Datos.IDCategoriaChe;
                this.txtOrden.Text = Convert.ToString(Datos.Orden);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        private void InicializarCampos()
        {
            try
            {
                this.txtOrden.Text = string.Empty;
                this.txtDescripcion.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LlenarComboCategoria()
        {
            try
            {
                CategoriaCheckList DatosAux = new CategoriaCheckList { Conexion = Comun.Conexion, IncluirSelect = true };
                Catalogo_Negocio CN = new Catalogo_Negocio();
                this.cmbCategoriaCheck.DataSource = CN.ObtenerComboCategoriaChe(DatosAux);
                this.cmbCategoriaCheck.DisplayMember = "Descripcion";
                this.cmbCategoriaCheck.ValueMember = "IDCategoriaChe";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExisteItemEnComboCategoria(int ID)
        {
            try
            {
                foreach (CategoriaCheckList Item in this.cmbCategoriaCheck.Items)
                {
                    if (Item.IDCategoriaChe == ID)
                        return true;
                }
                return false;
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

        private ActividadesCheckList ObtenerDatos()
        {
            try
            {
                ActividadesCheckList DatosAux = new ActividadesCheckList();
                DatosAux.IDActividades = TipoForm == 2 ? this._DatosActividad.IDActividades : 0;
                DatosAux.Descripcion = this.txtDescripcion.Text.Trim();
                CategoriaCheckList CatAux = new CategoriaCheckList();
                CatAux = (CategoriaCheckList)this.cmbCategoriaCheck.SelectedItem;
                DatosAux.IDCategoriaChe = CatAux.IDCategoriaChe;
                DatosAux.NombreCategoria = CatAux.Descripcion;
                DatosAux.Orden = Convert.ToInt32(this.txtOrden.Text.Trim());
                DatosAux.Opcion = this.TipoForm;
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                return DatosAux;
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
                int Aux = 0, ID = 0;
                if (string.IsNullOrEmpty(this.txtOrden.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un orden de actividad", ControlSender = this.txtDescripcion });
                else
                {
                    if (!Validar.IsValidOnlyNumber(this.txtOrden.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un orden de actividad válido.", ControlSender = this.txtDescripcion });
                }
                if (string.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la descripción de actividad", ControlSender = this.txtDescripcion });
                else
                {
                    if (!Validar.IsValidDescripcion(this.txtDescripcion.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la descripción de actividad válido.", ControlSender = this.txtDescripcion });
                }
                if (this.cmbCategoriaCheck.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una categoria", ControlSender = this.cmbCategoriaCheck });
                else
                {
                    int.TryParse(this.cmbCategoriaCheck.SelectedValue.ToString(), out ID);
                    if (ID == 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una categoria.", ControlSender = this.cmbCategoriaCheck });
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
                LogError.AddExcFileTxt(ex, "frmNuevoActividadCheklist ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtMensajeError.Visible = false;
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                    ActividadesCheckList Datos = this.ObtenerDatos();
                    Catalogo_Negocio cn = new Catalogo_Negocio();
                    cn.ABCActividadesCheck(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosActividad = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (Datos.Resultado == 0)
                        {
                            MessageBox.Show("El numero de orden de la actividad ya existe.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        MessageBox.Show("Ocurrió un error al guardar los datos.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoActividadCheklist ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoActividadCheklist_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoActividadCheklist ~ frmNuevoActividadCheklist_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
