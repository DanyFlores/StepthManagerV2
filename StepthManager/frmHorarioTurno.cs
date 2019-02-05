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
    public partial class frmHorarioTurno : Form
    {
        #region Propiedades / Variables
        private int TipoForm = 0;
        private Horario _DatosHorario;
        public Horario DatosHorario
        {
            get { return _DatosHorario; }
            set { _DatosHorario = value; }
        }
        private List<Sucursal> HorarioSucursal = new List<Sucursal>();
        #endregion

        #region Constructor

        public frmHorarioTurno()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaSucursal ~ frmNuevaSucursal()");
            }
        }

        public frmHorarioTurno(Horario Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosHorario = Datos;
                this.TipoForm = 2;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaSucursal ~ frmNuevaSucursal(CatSucursales Datos)");
            }
        }

        #endregion

        #region Métodos

        private void CargarDatosAModificar(Horario Datos)
        {
            try
            {
              
                this.txtNombreTurno.Text = Datos.NombreTurno;
                this.dtpHoraEntrada.Value = Convert.ToDateTime(Datos.HoraEntrada.ToString());
                this.dtpHoraSalida.Value = Convert.ToDateTime(Datos.HoraSalida.ToString());
                this.dtpInicioValidarEntrada.Value = Convert.ToDateTime(Datos.InicioValidezEntrada.ToString());
                this.dtpFinValidarEntrada.Value = Convert.ToDateTime(Datos.FinValidezEntrada.ToString());
                this.dtpInicioValidarSalida.Value = Convert.ToDateTime(Datos.InicioValidezSalida.ToString());
                this.dtpFinValidarSalida.Value = Convert.ToDateTime(Datos.FinValidezSalida.ToString());
                this.txtToleraciaLlegadaTarde.Text = Datos.ToleraciaLlegadaTarde.ToString();
                this.txtToleranciaLlegadaTemprano.Text = Datos.ToleranciaSalidaTemprano.ToString();
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
                if (TipoForm == 1)
                    this.InicializarCampos();
                else
                    this.CargarDatosAModificar(_DatosHorario);
                this.ActiveControl = this.txtNombreTurno;
                this.txtNombreTurno.Focus();
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

        private void InicializarCampos()
        {
            try
            {
                this.txtNombreTurno.Text = string.Empty;
                this.txtToleraciaLlegadaTarde.Text = string.Empty;
                this.txtToleranciaLlegadaTemprano.Text = string.Empty;
                DateTime Fecha = DateTime.Now;
                TimeSpan Ts = new TimeSpan(Fecha.Hour, Fecha.Minute, Fecha.Second);
                Fecha = DateTime.Today;
                Fecha = Fecha.AddHours(Ts.Hours);
                Fecha = Fecha.AddMinutes(Ts.Minutes);
                Fecha = Fecha.AddSeconds(Ts.Seconds);
                this.dtpFinValidarEntrada.Value = Fecha;
                this.dtpFinValidarSalida.Value = Fecha;
                this.dtpHoraEntrada.Value = Fecha;
                this.dtpHoraSalida.Value = Fecha;
                this.dtpInicioValidarEntrada.Value = Fecha;
                this.dtpInicioValidarSalida.Value = Fecha;
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

        private Horario ObtenerDatos()
        {
            try
            {
                Horario DatosAux = new Horario();
                DatosAux.IDTurno = TipoForm == 2 ? this._DatosHorario.IDTurno : 0;
                DatosAux.NombreTurno = this.txtNombreTurno.Text.Trim();
                DatosAux.HoraEntrada = this.dtpHoraEntrada.Value.TimeOfDay;
                DatosAux.HoraSalida = this.dtpHoraSalida.Value.TimeOfDay;
                DatosAux.InicioValidezEntrada = this.dtpInicioValidarEntrada.Value.TimeOfDay;
                DatosAux.FinValidezEntrada = this.dtpFinValidarEntrada.Value.TimeOfDay;
                DatosAux.InicioValidezSalida = this.dtpInicioValidarSalida.Value.TimeOfDay;
                DatosAux.FinValidezSalida = this.dtpFinValidarSalida.Value.TimeOfDay;
                DatosAux.ToleraciaLlegadaTarde = Convert.ToInt32(this.txtToleraciaLlegadaTarde.Text.Trim());
                DatosAux.ToleranciaSalidaTemprano = Convert.ToInt32(this.txtToleranciaLlegadaTemprano.Text.Trim());
                DatosAux.DiasDeTrabajo = 0;
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
                if (string.IsNullOrEmpty(this.txtNombreTurno.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el turnos correcto.", ControlSender = this.txtNombreTurno });
                else
                {
                    if(!Validar.IsValidDescripcion(this.txtNombreTurno.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un turno válida.", ControlSender = this.txtNombreTurno });
                }
                if (string.IsNullOrEmpty(this.txtToleraciaLlegadaTarde.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese Tolerancia llegar tarde.", ControlSender = this.txtToleraciaLlegadaTarde });
                else
                {
                    if (!Validar.IsValidOnlyNumber(this.txtToleraciaLlegadaTarde.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese toleracia llegar tarde válida.", ControlSender = this.txtToleraciaLlegadaTarde });
                }
                if (string.IsNullOrEmpty(this.txtToleranciaLlegadaTemprano.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese Tolerancia llegar temprano.", ControlSender = this.txtToleranciaLlegadaTemprano });
                else
                {
                    if (!Validar.IsValidOnlyNumber(this.txtToleranciaLlegadaTemprano.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese toleracia llegar temprano válida.", ControlSender = this.txtToleranciaLlegadaTemprano });
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
                LogError.AddExcFileTxt(ex, "frmNuevaSucursal ~ btnCancelar_Click");
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
                    Horario Datos = this.ObtenerDatos();
                    Catalogo_Negocio cn = new Catalogo_Negocio();
                    cn.ABCHorariosTurnos(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosHorario = Datos;
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
                LogError.AddExcFileTxt(ex, "frmNuevaSucursal ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevaSucursal_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaSucursal ~ frmNuevaSucursal_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
