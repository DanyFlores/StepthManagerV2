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
    public partial class frmNuevoSubTema : Form
    {
        #region Propiedades / Variables
        private int TipoForm = 0;
        private SubTemas _DatosSubTemas;
        public SubTemas DatosSubTemas
        {
            get { return _DatosSubTemas; }
            set { _DatosSubTemas = value; }
        }
        #endregion

        #region Constructor

        public frmNuevoSubTema()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoSubTema ~ frmNuevoSubTema()");
            }
        }

        public frmNuevoSubTema(SubTemas Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosSubTemas = Datos;
                this.TipoForm = 2;
                this.CargarDatosAModificar(Datos);
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoSubTema ~ frmNuevoSubTema(SubTemas Datos)");
            }
        }

        #endregion

        private void CargarCombos()
        {
            try
            {
                Producto Datos = new Producto { IncluirSelect = true, Conexion = Comun.Conexion };
                Catalogo_Negocio Catalogos_negocio = new Catalogo_Negocio();
                this.cmbServicio.DataSource = Catalogos_negocio.ObtenerComboCatServicio(Datos);
                this.cmbServicio.DisplayMember = "NombreServicio";
                this.cmbServicio.ValueMember = "IDProducto";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Métodos

        private void CargarDatosAModificar(SubTemas Datos)
        {
            try
            {
                this.txtDescripcion.Text = Datos.Descripcion;
                this.cmbServicio.SelectedValue = Datos.IDServicio;
                this.txtPracticasSugerida.Text = Convert.ToInt32(Datos.PracticasSugeridas).ToString();
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
                this.CargarCombos();
                this.ActiveControl = this.txtDescripcion;
                this.txtDescripcion.Focus();
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
        private Producto ObtenerItemSeleccionado()
        {
            try
            {
                Producto DatosAux = new Producto();
                if (this.cmbServicio.SelectedIndex != -1)
                {
                    DatosAux = (Producto)this.cmbServicio.SelectedItem;
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private SubTemas ObtenerDatos()
        {
            try
            {
                SubTemas DatosAux = new SubTemas();
                Producto ServicioAux = this.ObtenerItemSeleccionado();
                DatosAux.IDSubTemas = TipoForm == 2 ? _DatosSubTemas.IDSubTemas : string.Empty;
                DatosAux.IDServicio = ServicioAux.IDProducto;
                DatosAux.Descripcion = this.txtDescripcion.Text.ToUpper().Trim();
                DatosAux.PracticasSugeridas = Convert.ToInt32(this.txtPracticasSugerida.Text.Trim());
                DatosAux.IDServicio = this.cmbServicio.SelectedValue.ToString();
                DatosAux.NombreServicio = ServicioAux.NombreServicio;
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
                int aux = 0;
                if (Convert.ToInt32(this.cmbServicio.SelectedIndex.ToString()) == 0 || Convert.ToInt32(this.cmbServicio.SelectedIndex.ToString()) == -1)
                    Errores.Add(new Error { Numero = (aux += 1), Descripcion = "Seleccionar un Servicio.", ControlSender = this.cmbServicio });
                if (string.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
                    Errores.Add(new Error { Numero = (aux += 1), Descripcion = "Ingrese una descripción válida.", ControlSender = this.txtDescripcion });
                else
                    if(!Validar.IsValidDescripcion(this.txtDescripcion.Text))
                        Errores.Add(new Error { Numero = (aux += 1), Descripcion = "Ingrese una descripción válida.", ControlSender = this.txtDescripcion });
                if (string.IsNullOrEmpty(this.txtPracticasSugerida.Text.Trim()))
                    Errores.Add(new Error { Numero = (aux += 1), Descripcion = "Ingrese un numero de practicas", ControlSender = this.txtPracticasSugerida });
                else
                {
                    if (!Validar.IsValidOnlyNumber(this.txtPracticasSugerida.Text))
                        Errores.Add(new Error { Numero = (aux += 1), Descripcion = "Ingrese un numero de practicas válida.", ControlSender = this.txtPracticasSugerida });
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
                LogError.AddExcFileTxt(ex, "frmNuevoSubTema ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                    this._DatosSubTemas = this.ObtenerDatos();
                    this.DialogResult = DialogResult.OK;
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoSubTema ~ btnGuardar_Click");
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
                LogError.AddExcFileTxt(ex, "frmNuevoSubTema ~ txtDescripcion_KeyPress");
            }
        }
        #endregion

        private void frmNuevoSubTema_Load(object sender, EventArgs e)
        {

        }
    }
}
