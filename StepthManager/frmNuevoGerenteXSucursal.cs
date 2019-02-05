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
    public partial class frmNuevoGerenteXSucursal : Form
    {
        #region Propiedades / Variables
        private Sucursal _DatosSucursal;
        public Sucursal DatosSucursal
        {
            get { return _DatosSucursal; }
            set { _DatosSucursal = value; }
        }  
        #endregion

        #region Constructor

        public frmNuevoGerenteXSucursal()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoGerenteXSucursal ~ frmNuevoGerenteXSucursal()");
            }
        }

        public frmNuevoGerenteXSucursal(Sucursal Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosSucursal = Datos;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoGerenteXSucursal ~ frmNuevoGerenteXSucursal(Sucursal Datos)");
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
                this.LlenarComboEmpleado();
                this.CargarDatosAModificar(_DatosSucursal);
                this.ActiveControl = this.cmbEmpleadoSucursal;
                this.cmbEmpleadoSucursal.Focus();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDatosAModificar(Sucursal Datos)
        {
            try
            {
                this.txtNombreSucursal.Text = Datos.NombreSucursal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboEmpleado()
        {
            try
            {
                Usuario Datos = new Usuario() { Conexion = Comun.Conexion, IDSucursalActual = this._DatosSucursal.IDSucursal, IncluirSelect = true };
                Catalogo_Negocio cn = new Catalogo_Negocio();
                this.cmbEmpleadoSucursal.DataSource = cn.ObtenerComboCatEmpleado(Datos);
                this.cmbEmpleadoSucursal.ValueMember = "IDEmpleado";
                this.cmbEmpleadoSucursal.DisplayMember = "Nombre";
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

        private Sucursal ObtenerDatos()
        {
            try
            {
                Sucursal DatosAux = new Sucursal();
                DatosAux.IDSucursal = this._DatosSucursal.IDSucursal;
                Usuario UsuarioAux = (Usuario)this.cmbEmpleadoSucursal.SelectedItem;
                DatosAux.IDEmpleado = UsuarioAux.IDEmpleado;
                DatosAux.NombreSucursal = this.txtNombreSucursal.Text;
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
                int Aux = 0;
                if (this.cmbEmpleadoSucursal.SelectedIndex == -1 || this.cmbEmpleadoSucursal.SelectedIndex == 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un empleado", ControlSender = this.cmbEmpleadoSucursal });
                else
                {
                    Usuario UsuarioAux = (Usuario)this.cmbEmpleadoSucursal.SelectedItem;
                    if (string.IsNullOrEmpty(UsuarioAux.IDEmpleado))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un empleado.", ControlSender = this.cmbEmpleadoSucursal });
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
                LogError.AddExcFileTxt(ex, "frmNuevoGerenteXSucursal ~ btnCancelar_Click");
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
                    Sucursal Datos = this.ObtenerDatos();
                    Catalogo_Negocio cn = new Catalogo_Negocio();
                    cn.ASucursaleEmpleado(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosSucursal = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoGerenteXSucursal ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)Keys.Enter)
                    this.btnGuardar_Click(this.btnGuardar, new EventArgs());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoGerenteXSucursal ~ txtDescripcion_KeyPress");
            }
        }


        #endregion

        private void frmNuevoGerenteXSucursal_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoGerenteXSucursal ~ frmNuevoGerenteXSucursal_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
