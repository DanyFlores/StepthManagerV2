using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using CreativaSL.Dll.Validaciones;
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
    public partial class frmNuevoTipoUsuarioPermisos : Form
    {
        private TipoUsuario _DatosUsuario;
        public TipoUsuario DatosUsuario
        {
            get { return _DatosUsuario; }
            set { _DatosUsuario = value; }
        }
        int IDTipoUsuario = 0;
        private int TipoForm = 0;
        public frmNuevoTipoUsuarioPermisos()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
                this.IDTipoUsuario = 0;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTipoUsuarioPermisos ~ frmNuevoTipoUsuarioPermisos()");
            }
        }

        public frmNuevoTipoUsuarioPermisos(TipoUsuario Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosUsuario = Datos;
                this.IDTipoUsuario = Datos.IDTipoUsuario;
                this.TipoForm = 2;
                this.CargarDatosAModificar(Datos);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTipoUsuarioPermisos ~ frmNuevoTipoUsuarioPermisos()");
            }
        }
        private void frmNuevoTipoUsuarioPermisos_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTipoUsuarioPermisos ~ frmNuevoTipoUsuarioPermisos_Load");
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.CargarGridPermisos();
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

        private void CargarDatosAModificar(TipoUsuario Datos)
        {
            try
            {
                this.txtTipoUsuario.Text = Datos.Descripcion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridPermisos()
        {
            try
            {
                TipoUsuario Datos = new TipoUsuario { Conexion = Comun.Conexion, IDTipoUsuario = this.IDTipoUsuario};
                TipoUsuario_Negocio UN = new TipoUsuario_Negocio();
                UN.ObtenerPermisosXIDUsuario(Datos);
                this.dgvPermisos.AutoGenerateColumns = false;
                this.dgvPermisos.DataSource = Datos.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GenerarTablaPermisos()
        {
            try
            {
                DataTable TablaPermisos = new DataTable();
                TablaPermisos.Columns.Add("IDPermiso", typeof(string));
                TablaPermisos.Columns.Add("IDProyecto", typeof(int));
                TablaPermisos.Columns.Add("IDModulo", typeof(int));
                TablaPermisos.Columns.Add("Lectura", typeof(bool));
                TablaPermisos.Columns.Add("Escritura", typeof(bool));
                foreach (DataGridViewRow Fila in this.dgvPermisos.Rows)
                {
                    int IDProyectoAux = 0, IDModuloAux = 0;
                    bool BandLectura = false, BandEscritura = false;
                    string IDPermisoAux = Fila.Cells["IDPermiso"].Value.ToString();
                    int.TryParse(Fila.Cells["IDProyecto"].Value.ToString(), out IDProyectoAux);
                    int.TryParse(Fila.Cells["IDModulo"].Value.ToString(), out IDModuloAux);
                    bool.TryParse(Fila.Cells["Escritura"].Value.ToString(), out BandEscritura);
                    bool.TryParse(Fila.Cells["Lectura"].Value.ToString(), out BandLectura);
                    TablaPermisos.Rows.Add(new object[] { IDPermisoAux, IDProyectoAux, IDModuloAux, BandLectura, BandEscritura });
                }
                return TablaPermisos;
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

        private TipoUsuario ObtenerDatos()
        {
            try
            {
                TipoUsuario DatosAux = new TipoUsuario();
                DatosAux.IDTipoUsuario = TipoForm == 2 ? _DatosUsuario.IDTipoUsuario : 0;
                DatosAux.Descripcion = this.txtTipoUsuario.Text.Trim();
                DatosAux.TablaDatos = this.GenerarTablaPermisos();
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
                int Aux = 0;
                if (string.IsNullOrEmpty(this.txtTipoUsuario.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un tipo usuario válida.", ControlSender = this.txtTipoUsuario });
                else
                    if (!Validar.IsValidName(this.txtTipoUsuario.Text))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un tipo usuario válida.", ControlSender = this.txtTipoUsuario });
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Abort;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTipoUsuarioPermisos ~ btnSalir_Click");
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
                    TipoUsuario Datos = this.ObtenerDatos();
                    TipoUsuario_Negocio CN = new TipoUsuario_Negocio();
                    CN.ActualizarPermisosXIDUsuario(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosUsuario = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (Datos.Resultado != 1)
                        {
                            List<Error> LstError = new List<Error>();
                            LstError.Add(new Error { Numero = 1, Descripcion = "Ocurrió un error al actualizar los permisos. Intente nuevamente.", ControlSender = this });
                            this.MostrarMensajeError(LstError);
                        }
                        else
                            MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoTipoUsuarioPermisos ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
