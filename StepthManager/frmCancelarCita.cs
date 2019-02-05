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
    public partial class frmCancelarCita : Form
    {
        #region Variables

        private string IDCita = string.Empty;

        #endregion

        #region Constructor

        public frmCancelarCita(string ID)
        {
            try
            {
                InitializeComponent();
                IDCita = ID;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCancelarCita ~ frmCancelarCita()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
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

        private Cita ObtenerDatos()
        {
            try
            {
                Cita DatosAux = new Cita();
                DatosAux.IDCita = this.IDCita;
                DatosAux.MotivoCancelacion = this.txtDescripcion.Text;
                DatosAux.IDUsuario = Comun.IDUsuario;
                DatosAux.Conexion = Comun.Conexion;
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
                List<Error> Lista = new List<Error>();
                int Aux = 0;
                if (string.IsNullOrEmpty(this.txtDescripcion.Text.Trim()))
                    Lista.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un motivo de cancelación.", ControlSender = this.txtDescripcion });
                return Lista;
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
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelarCita ~ btnCancelar_Click");
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
                    Cita DatosAux = this.ObtenerDatos();
                    Cita_Negocio CN = new Cita_Negocio();
                    CN.CancelarCita(DatosAux);
                    if (DatosAux.Completado)
                    {
                        switch (DatosAux.Opcion)
                        {
                            case 1:
                                MessageBox.Show("La cita ha sido cancelada.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                                break;
                            case -1:
                                MessageBox.Show("El estatus de la cita no permite su cancelación.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            default:
                                MessageBox.Show("Ocurrió un error al cancelar la cita.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                        }
                    }
                    else
                        MessageBox.Show("Ocurrió un error al cancelar la cita.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelarCita ~ btnGuardar_Click");
            }
        }

        private void frmCancelarCita_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelarCita ~ frmCancelarCita_Load");
            }
        }

        #endregion

    }
}
