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
    public partial class frmVacacionesFechas : Form
    {

        #region Variables
        private Usuario _DatosUsuario;
        public Usuario DatosUsuario
        {
            get { return _DatosUsuario; }
            set { _DatosUsuario = value; }
        }

        public DateTime FechaInicio;
        public DateTime FechaFin;
        #endregion
       
        #region Constructor

        public frmVacacionesFechas(Usuario Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosUsuario = Datos;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVacacionesFechas ~ frmVacacionesFechas(Usuario Datos)");
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
                this.txtEmpleado.Text = this._DatosUsuario.Nombre + " " + _DatosUsuario.ApellidoMat + " " + _DatosUsuario.ApellidoPat;
                this.ActiveControl = this.dtpFechaInicio;
                this.dtpFechaInicio.Focus();
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

        private List<Error> ValidarDatos()
        {
            try
            {
                List<Error> Errores = new List<Error>();
                int Aux = 0;
                if (this.dtpFechaInicio.Value < DateTime.Today)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La Fecha tiene que ser mayor o igual a la fecha actual.", ControlSender = this.dtpFechaInicio });
                if(this.dtpFechaInicio.Value > this.dtpFechaFin.Value) 
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La Fecha inicio no puede ser mayor a la fecha fin.", ControlSender = this.dtpFechaInicio});
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
                LogError.AddExcFileTxt(ex, "frmVacacionesFechas ~ btnCancelar_Click");
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
                    Usuario DatosAux = new Usuario();
                    DatosAux.FechaInicio = this.dtpFechaInicio.Value;
                    DatosAux.FechaFin = this.dtpFechaFin.Value;
                    DatosAux.IDEmpleado = _DatosUsuario.IDEmpleado;
                    DatosAux.IDVacaciones = string.Empty;
                    DatosAux.Conexion = Comun.Conexion;
                    DatosAux.IDUsuario = Comun.IDUsuario;
                    DatosAux.Opcion = 1;
                    Usuario_Negocio GN = new Usuario_Negocio();
                    GN.ABNominaVaciones(DatosAux);
                    if (DatosAux.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (DatosAux.Resultado == 51000)
                        {
                            MessageBox.Show("El empleado ya cuenta con esa fecha asignado. Selecciones un nuevo rango de fechas", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        MessageBox.Show("Ocurrió un error al guardar los datos. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVacacionesFechas ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmVacacionesFechas_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmVacacionesFechas ~ frmVacacionesFechas_Load");
            }
        }

        #endregion
    }
}
