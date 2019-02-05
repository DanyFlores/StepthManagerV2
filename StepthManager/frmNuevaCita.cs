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
using System.Globalization;
using CreativaSL.LibControls.WinForms;
using System.IO;

namespace StephManager
{
    public partial class frmNuevaCita : Form
    {

        #region Variables

        private string IDSucursal = string.Empty;
        private string IDEmpleado = string.Empty;
        private DateTime FechaCita = DateTime.Today;
        private List<Cita> Resultados = new List<Cita>();
        #endregion

        #region Constructor

        public frmNuevaCita()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaCita ~ frmNuevaCita()");
            }
        }

        #endregion

        #region Métodos

        private void AbrirFormularioConfirmacion(int IDHorario)
        {
            try
            {
                Servicio DatosAux = new Servicio();
                Cliente DatosCl = new Cliente();
                frmElegirServicioCita FrmServicio = new frmElegirServicioCita();
                FrmServicio.ShowDialog();
                FrmServicio.Dispose();
                if (FrmServicio.DialogResult == DialogResult.OK)
                {
                    DatosAux = FrmServicio.ServicioElegido;
                    DatosCl  = FrmServicio.ClienteSeleccionado;
                    int Periodos = (int)DatosAux.TiempoMinutos / 30;
                    int Residuo = DatosAux.TiempoMinutos % 30;
                    if (Residuo > 0)
                        Periodos += 1;
                    if (this.ValidarServicioTiempo(DatosAux, IDHorario))
                    {
                        Cita DatosCita = new Cita { Conexion = Comun.Conexion, IDEmpleado = this.IDEmpleado, IDCliente = DatosCl.IDCliente,
                                                    IDServicio = DatosAux.IDServicio, IDSucursal = this.IDSucursal, FechaCita = this.FechaCita,
                                                    Observaciones = string.Empty, IDHorario = IDHorario, Periodos = Periodos, IDUsuario = Comun.IDUsuario };
                        Cita_Negocio CN = new Cita_Negocio();
                        CN.InsertarNuevaCitaNotificacion(DatosCita);
                        if (DatosCita.Completado)
                        {
                            switch (DatosCita.Opcion)
                            {
                                case 1:
                                    foreach (DataRow notificacion in DatosCita.tablaNotificaciones.Rows)
                                    {
                                        int IDTipoCelular = 0, Badge = 0;
                                        IDTipoCelular = Convert.ToInt32(notificacion["id_tipoCelular"].ToString());
                                        Badge = Convert.ToInt32(notificacion["Badge"].ToString());
                                        EnviaNotificaciones.EnviarMensaje(notificacion["tokenCelular"].ToString(), notificacion["nombre"].ToString(), notificacion["descripcion"].ToString(), Badge, IDTipoCelular);
                                    }
                                    MessageBox.Show("Cita agendada correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.DialogResult = DialogResult.OK;
                                    break;
                                case 51000: MessageBox.Show("No se puede agendar la cita. La hora ya está apartada.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    this.ConsultarCitas();
                                    break;
                            }
                        }
                        else
                            MessageBox.Show("Ocurrió un error. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("No hay tiempo libre suficiente para realizar el servicio deseado. El tiempo de servicio es de " + DatosAux.TiempoMinutos + " minutos.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ConsultarCitas()
        {
            try
            {
                Cita Datos = new Cita { Conexion = Comun.Conexion, IDSucursal = this.IDSucursal, IDEmpleado = this.IDEmpleado, FechaCita = this.FechaCita };
                Cita_Negocio CN = new Cita_Negocio();
                List<Cita> ListaHorario = CN.ObtenerHorarioEmpleado(Datos);
                this.Resultados = ListaHorario;
                this.GenerarHorarios(ListaHorario);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void GenerarHorarios(List<Cita> DatosAux)
        {
            try
            {
                string HoraInicio = string.Empty, HoraFin = string.Empty;
                bool Inicio = false;
                int PosX = 50, PosY = 25, Separacion = 50, SizeX = 200, SizeY = 60;
                this.LimpiarBotonesPanel();
                foreach (Cita Aux in DatosAux)
                {
                    if (!Inicio)
                    {
                        HoraInicio = Aux.HoraInicio.ToString();
                        Inicio = true;
                    }
                    TimeSpan TS = new TimeSpan(0, 1, 0);
                    TS = Aux.HoraFin.Add(TS);
                    HoraFin = TS.ToString(); 
                    //Aux.HoraFin.ToString();

                    if ((PosX + SizeX + Separacion) > this.PanelHorarios.Width)
                    {
                        PosY = PosY + Separacion + SizeY;
                        PosX = 50;
                    }
                    

                    Button_Creativa Btn = new Button_Creativa();
                    Btn.Location = new Point(PosX, PosY);
                    Btn.Size = new Size(SizeX, SizeY);
                    Btn.Tag = Aux.IDHorario;
                    Btn.Text = Aux.HoraInicio.ToString() + " - " + Aux.HoraFin.ToString();
                    Btn.KeyButtonView = false;
                    if (Aux.HoraInicio < DateTime.Now.TimeOfDay && FechaCita == DateTime.Today)
                    {
                        Btn.BackColor = Color.OrangeRed;
                        Btn.BorderColor = Color.DarkOrange;
                        Btn.MouseOverColor = Color.Orange;
                        Btn.BorderMouseOverColor = Color.Peru;
                        Btn.BorderNoFocusColor = Color.OrangeRed;
                        Btn.BorderFocusColor = Color.OrangeRed;
                    }
                    else
                    {
                        if (Aux.HorarioLibre)
                        {
                            Btn.BackColor = Color.MediumTurquoise;
                            Btn.BorderColor = Color.DarkTurquoise;
                            Btn.MouseOverColor = Color.PaleTurquoise;
                            Btn.BorderMouseOverColor = Color.Turquoise;
                            Btn.BorderNoFocusColor = Color.MediumTurquoise;
                            Btn.BorderFocusColor = Color.MediumTurquoise;
                            Btn.Click += new System.EventHandler(this.btnHorario_Click);
                        }
                        else
                        {
                            Btn.BackColor = Color.PaleVioletRed;
                            Btn.BorderColor = Color.Brown;
                            Btn.MouseOverColor = Color.Maroon;
                            Btn.BorderMouseOverColor = Color.DarkRed;
                            Btn.BorderNoFocusColor = Color.PaleVioletRed;
                            Btn.BorderFocusColor = Color.PaleVioletRed;
                        }
                    }
                    this.PanelHorarios.Controls.Add(Btn);
                    PosX = PosX + Separacion + SizeX;
                }
                this.txtHoraEntrada.Text = HoraInicio;
                this.txtHoraSalida.Text = HoraFin;
                //this.dataGridView1.AutoGenerateColumns = false;
                //this.dataGridView1.DataSource = DatosAux;
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
                this.LlenarComboSucursales();
                this.dtpFecha.Value = DateTime.Today;
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

        private void LimpiarBotonesPanel()
        {
            try
            {
                for (int i = 0; i < this.PanelHorarios.Controls.Count; i++)
                {
                    this.PanelHorarios.Controls[i].Dispose();
                }
                this.PanelHorarios.Controls.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboEmpleados(string IDSucursal)
        {
            try
            {
                Usuario DatosAux = new Usuario { Conexion = Comun.Conexion, IDSucursalActual = IDSucursal, IncluirSelect = true };
                Usuario_Negocio UN = new Usuario_Negocio();
                this.cmbEmpleados.DataSource = UN.LlenarComboCatEmpleadosCita(DatosAux);
                this.cmbEmpleados.ValueMember = "IDEmpleado";
                this.cmbEmpleados.DisplayMember = "Nombre";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboSucursales()
        {
            try
            {
                Sucursal DatosAux = new Sucursal { Conexion = Comun.Conexion, Opcion = 1 };
                Sucursal_Negocio SN = new Sucursal_Negocio();
                this.cmbSucursal.DataSource = SN.LlenarComboCatSucursalesPuntoDeVenta(DatosAux);
                this.cmbSucursal.ValueMember = "IDSucursal";
                this.cmbSucursal.DisplayMember = "NombreSucursal";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MostrarMensajeErrorBusqueda(List<Error> Errores)
        {
            try
            {
                string cadenaErrores = string.Empty;
                cadenaErrores = "";
                foreach (Error item in Errores)
                {
                    cadenaErrores += item.Numero + "\t" + item.Descripcion + "\r\n";
                }
                MessageBox.Show(cadenaErrores, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Cita ObtenerDatosBusqueda()
        {
            try
            {
                Cita Datos = new Cita();
                Sucursal DatosSuc = this.ObtenerDatosSucursal();
                Usuario DatosUser = this.ObtenerDatosEmpleado();
                Datos.IDSucursal = DatosSuc.IDSucursal;
                Datos.IDEmpleado = DatosUser.IDEmpleado;
                Datos.FechaCita = this.dtpFecha.Value;
                Datos.Conexion = Comun.Conexion;
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Usuario ObtenerDatosEmpleado()
        {
            try
            {
                Usuario Aux = new Usuario();
                if (this.cmbEmpleados.SelectedIndex != -1)
                {
                    Aux = (Usuario)this.cmbEmpleados.SelectedItem;
                }
                return Aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Sucursal ObtenerDatosSucursal()
        {
            try
            {
                Sucursal Aux = new Sucursal();
                if (this.cmbSucursal.SelectedIndex != -1)
                {
                    Aux = (Sucursal)this.cmbSucursal.SelectedItem;
                }
                return Aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Cita ObtenerHorarioXIDHorario(int IDHorario)
        {
            try
            {
                Cita Aux = new Cita();
                foreach (Cita Item in Resultados)
                {
                    if (Item.IDHorario == IDHorario)
                    {
                        Aux = Item;
                        break;
                    }
                }
                return Aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Error> ValidarDatosBusqueda()
        {
            try
            {
                List<Error> Lista = new List<Error>();
                int Aux = 0;
                if (string.IsNullOrEmpty(this.ObtenerDatosSucursal().IDSucursal.Trim()))
                    Lista.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una sucursal.", ControlSender = this.cmbSucursal });
                if (string.IsNullOrEmpty(this.ObtenerDatosEmpleado().IDEmpleado.Trim()))
                    Lista.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un empleado.", ControlSender = this.cmbEmpleados });
                if(this.dtpFecha.Value < DateTime.Today)
                    Lista.Add(new Error { Numero = (Aux += 1), Descripcion = "La fecha no puede ser menor a la fecha actual.", ControlSender = this.dtpFecha });
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidarServicioTiempo(Servicio Datos, int IDHorario)
        {
            try
            {
                bool Band = false;
                decimal Periodos = Datos.TiempoMinutos / 30;
                int Residuo = Datos.TiempoMinutos % 30;
                if(Residuo > 0)
                    Periodos += 1;
                int ContadorPeriodos = 0;
                bool Horario = false;
                foreach (Cita Item in Resultados)
                {
                    if (Item.IDHorario == IDHorario)
                        Horario = true;
                    if (Horario && Item.HorarioLibre)
                        ContadorPeriodos += 1;
                }
                if (ContadorPeriodos >= Periodos)
                    Band = true;
                return Band;
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
                LogError.AddExcFileTxt(ex, "frmNuevaCita ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHorario_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Creativa Btn = (Button_Creativa)sender;
                int IDHorario = 0;
                int.TryParse(Btn.Tag.ToString(), out IDHorario);
                Cita DatosAux = this.ObtenerHorarioXIDHorario(IDHorario);
                if (DatosAux.IDHorario > 0)
                {
                    if (DatosAux.HoraInicio < DateTime.Now.TimeOfDay && FechaCita == DateTime.Today)
                    {
                        MessageBox.Show("La hora ya no está disponible.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.ConsultarCitas();
                    }
                    else
                        this.AbrirFormularioConfirmacion(IDHorario);
                }
                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaCita ~ btnConsultar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Error> Errores = this.ValidarDatosBusqueda();
                if (Errores.Count == 0)
                {
                    Cita Datos = this.ObtenerDatosBusqueda();
                    this.IDSucursal = Datos.IDSucursal;
                    this.IDEmpleado = Datos.IDEmpleado;
                    this.FechaCita = Datos.FechaCita;
                    this.ConsultarCitas();
                    //Cita_Negocio CN = new Cita_Negocio();
                    //List<Cita> ListaHorario = CN.ObtenerHorarioEmpleado(Datos);
                    //this.Resultados = ListaHorario;
                    //this.GenerarHorarios(ListaHorario);
                }
                else
                    this.MostrarMensajeErrorBusqueda(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaCita ~ btnConsultar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSucursal_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbSucursal.SelectedIndex != -1)
                {
                    Sucursal Datos = (Sucursal)this.cmbSucursal.SelectedItem;
                    this.LlenarComboEmpleados(Datos.IDSucursal);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaCita ~ cmbSucursal_SelectedValueChanged");
            }
        }

        private void cmbSucursal_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.cmbSucursal.SelectedIndex == -1)
                {
                    this.LlenarComboEmpleados(string.Empty);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaCita ~ cmbSucursal_SelectedValueChanged");
            }
        }

        private void frmNuevaCita_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaCita ~ frmNuevaCita_Load");
            }
        }

        #endregion
    }
}
