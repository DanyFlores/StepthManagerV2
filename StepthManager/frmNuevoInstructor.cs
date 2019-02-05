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
    public partial class frmNuevoInstructor : Form
    {
        #region Propiedades / Variables
        private int TipoForm = 0;
        private Instructor _DatosInstructor;
        public Instructor DatosInstructor
        {
            get { return _DatosInstructor; }
            set { _DatosInstructor = value; }
        }        
        #endregion

        #region Constructor

        public frmNuevoInstructor()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProveedor ~ frmNuevoProveedor()");
            }
        }

        public frmNuevoInstructor(Instructor Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosInstructor = Datos;
                this.TipoForm = 2;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProveedor ~ frmNuevoProveedor(Proveedor Datos)");
            }
        }

        #endregion

        #region Métodos


        private void CargarDatosAModificar(Instructor Datos)
        {
            try
            {
                this.txtNombre.Text = Datos.Nombre;
                this.txtApellidoPat.Text = Datos.ApellidoPat;
                this.txtApellidoMat.Text = Datos.ApellidoMat;
                this.txtCorreo.Text = Datos.Correo;
                this.txtTelefono.Text = Datos.Telefono;
                this.dtpFechaNac.Value = Datos.FechaNac;
                if (ExisteItemEnCombo(Datos.IDGenero))
                    this.cmbGenero.SelectedValue = Datos.IDGenero;
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
                int Aux = 0;
                foreach (DataRowView fila in this.cmbGenero.Items)
                {
                    int.TryParse(fila["IDGenero"].ToString(), out Aux);
                    if (Aux == ID)
                        return true;
                }
                return false;
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
                this.LlenarComboGenero();
                if(TipoForm == 2)
                    this.CargarDatosAModificar(_DatosInstructor);
                this.ActiveControl = this.txtNombre;
                this.txtNombre.Focus();
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

        private void LlenarComboGenero()
        {
            try
            {
                Genero DatosAux = new Genero { Opcion = 2, Conexion = Comun.Conexion };
                Catalogo_Negocio CN = new Catalogo_Negocio();
                CN.ObtenerCatGeneros(DatosAux);
                this.cmbGenero.DisplayMember = "Descripcion";
                this.cmbGenero.ValueMember = "IDGenero";
                this.cmbGenero.DataSource = DatosAux.TablaDatos;
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

        private Instructor ObtenerDatos()
        {
            try
            {
                Instructor DatosAux = new Instructor();
                DatosAux.IDInstructor = TipoForm == 2 ? this._DatosInstructor.IDInstructor : string.Empty;
                int IDGenero = 0;
                DataRowView Fila = (DataRowView)this.cmbGenero.SelectedItem;
                int.TryParse(this.cmbGenero.SelectedValue.ToString(), out IDGenero);
                DatosAux.Nombre = this.txtNombre.Text.Trim();
                DatosAux.ApellidoPat = this.txtApellidoPat.Text.Trim();
                DatosAux.ApellidoMat = this.txtApellidoMat.Text.Trim();
                DatosAux.Correo = this.txtCorreo.Text.Trim();
                DatosAux.Telefono = this.txtTelefono.Text.Trim();
                DatosAux.FechaNac = this.dtpFechaNac.Value;
                DatosAux.IDGenero = IDGenero;
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
                //Validar Razon Social del Proveedor
                if (string.IsNullOrEmpty(this.txtNombre.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el nombre del instructor.", ControlSender = this.txtNombre });
                else
                {
                    if(!Validar.IsValidDescripcion(this.txtNombre.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un nombre del instructor válido.", ControlSender = this.txtNombre });
                }
                //Validar Nombre Comercial del Proveedor
                if (string.IsNullOrEmpty(this.txtApellidoPat.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el apellido paterno.", ControlSender = this.txtApellidoPat });
                else
                {
                    if (!Validar.IsValidDescripcion(this.txtApellidoPat.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el apellido paterno válido.", ControlSender = this.txtApellidoPat });
                }
                //Validar Regimen Fiscal del Proveedor
                if (string.IsNullOrEmpty(this.txtApellidoMat.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el apellido materno.", ControlSender = this.txtApellidoMat });
                else
                {
                    if (!Validar.IsValidDescripcion(this.txtApellidoMat.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el apellido materno válido.", ControlSender = this.txtApellidoMat });
                }
             
                //Validar Correo del Proveedor
                if(!string.IsNullOrEmpty(this.txtCorreo.Text.Trim()))
                    if (!Validar.IsValidMail(this.txtCorreo.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un correo válido.", ControlSender = this.txtCorreo });

                //Validar Numero Telefono del Proveedor
                if (!string.IsNullOrEmpty(this.txtTelefono.Text.Trim()))
                    if (!Validar.IsValidPhoneNumber(this.txtTelefono.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un número telefónico válido.", ControlSender = this.txtTelefono });
                if (this.cmbGenero.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción del genero", ControlSender = this.cmbGenero });
                else
                {
                    int.TryParse(this.cmbGenero.SelectedValue.ToString(), out ID);
                    if (ID == 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción de genero.", ControlSender = this.cmbGenero });
                }
                if (this.dtpFechaNac.Value > DateTime.Today.AddYears(-15))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese una fecha de nacimiento válida.", ControlSender = this.dtpFechaNac });
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
                LogError.AddExcFileTxt(ex, "frmNuevoProveedor ~ btnCancelar_Click");
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
                    Instructor Datos = this.ObtenerDatos();
                    Catalogo_Negocio cn = new Catalogo_Negocio();
                    cn.ABCInstructoress(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosInstructor = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al guardar los datos.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProveedor ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProveedor ~ frmNuevoProveedor_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
       
        #endregion

    }
}
