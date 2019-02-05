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
    public partial class frmBajaNominal : Form
    {
        private Usuario Empleado = new Usuario();

        public frmBajaNominal(Usuario DatosAux)
        {
            try
            {
                InitializeComponent();
                Empleado = DatosAux;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmBajaNominal ~ frmBajaNominal()");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                    Usuario Datos = this.ObtenerDatos();
                    Usuario_Negocio UN = new Usuario_Negocio();
                    UN.BajaNominal(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                LogError.AddExcFileTxt(ex, "frmBajaNominal ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmBajaNominal ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBajaNominal_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmBajaNominal ~ frmBajaNominal_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.LlenarComboMotivoBaja();
                this.txtEmpleado.Text = this.Empleado.Nombre + " " + this.Empleado.ApellidoPat + " " + this.Empleado.ApellidoMat;
                this.txtComentarios.Text = string.Empty;
                this.ActiveControl = this.cmbMotivoBaja;
                this.cmbMotivoBaja.Focus();
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

        private void LlenarComboMotivoBaja()
        {
            try
            {
                MotivoBaja DatosAux = new MotivoBaja { Conexion = Comun.Conexion, IncluirSelect = true };
                Usuario_Negocio UN = new Usuario_Negocio();
                this.cmbMotivoBaja.DataSource = UN.LlenarComboMotivoBaja(DatosAux);
                this.cmbMotivoBaja.ValueMember = "IDMotivoBaja";
                this.cmbMotivoBaja.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private MotivoBaja ObtenerMotivoSeleccionado()
        {
            try
            {
                MotivoBaja Motivo = new MotivoBaja();
                if (this.cmbMotivoBaja.Items.Count > 0)
                    if (this.cmbMotivoBaja.SelectedIndex != -1)
                        Motivo = (MotivoBaja)this.cmbMotivoBaja.SelectedItem;
                return Motivo;
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

        private Usuario ObtenerDatos()
        {
            try
            {
                Usuario DatosAux = new Usuario();
                MotivoBaja Baja = this.ObtenerMotivoSeleccionado();
                DatosAux.IDEmpleado = this.Empleado.IDEmpleado;
                DatosAux.IDMotivoBaja = Baja.IDMotivoBaja;
                DatosAux.ComentariosBaja = this.txtComentarios.Text;
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
                MotivoBaja AuxMB = this.ObtenerMotivoSeleccionado();
                if(AuxMB.IDMotivoBaja == 0)
                    Errores.Add(new Error { Numero = (aux += 1), Descripcion = "Seleccione un motivo de baja.", ControlSender = this.cmbMotivoBaja });
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
