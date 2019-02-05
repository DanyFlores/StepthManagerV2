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
using StephManager.ClasesAux;
using CreativaSL.LibControls.WinForms;
using System.IO;

namespace StephManager
{
    public partial class frmNuevoRegistroAsistencia : Form
    {
        #region Constructor

        public frmNuevoRegistroAsistencia()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoRegistroAsistencia ~ frmNuevoRegistroAsistencia");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                this.LlenarComboEmpleadosXIDSucursal();
                this.LlenarComboTipoRegistro();
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

        private void LlenarComboEmpleadosXIDSucursal()
        {
            try
            {
                Usuario DatosAux = new Usuario { Conexion = Comun.Conexion, IncluirSelect = true, IDSucursalActual = Comun.IDSucursalCaja };
                Usuario_Negocio UN = new Usuario_Negocio();
                this.cmbEmpleados.DataSource = UN.LlenarComboCatEmpleados(DatosAux);
                this.cmbEmpleados.ValueMember = "IDEmpleado";
                this.cmbEmpleados.DisplayMember = "Nombre";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboTipoRegistro()
        {
            try
            {
                TipoRegistro TRAux = new TipoRegistro { Conexion = Comun.Conexion, IncluirSelect = true };
                Catalogo_Negocio CN = new Catalogo_Negocio();
                List<TipoRegistro> Lista = CN.ObtenerCatTipoRegistro(TRAux);
                this.cmbTipoRegistro.DataSource = Lista;
                this.cmbTipoRegistro.DisplayMember = "Descripcion";
                this.cmbTipoRegistro.ValueMember = "IDTipoRegistro";
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

        private Checador ObtenerDatos()
        {
            try
            {
                Checador DatosAux = new Checador();
                Usuario UserAux = (Usuario)this.cmbEmpleados.SelectedItem;
                TipoRegistro TRAux = (TipoRegistro)this.cmbTipoRegistro.SelectedItem;
                DatosAux.IDEmpleado = UserAux.IDEmpleado;
                DatosAux.IDTipoRegistro = TRAux.IDTipoRegistro;
                DatosAux.FechaChecador = this.dtpFecha.Value;
                DatosAux.Motivo = this.txtMotivo.Text.Trim();
                DatosAux.DispChecador = false;
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
                List<Error> Errores = new List<Error>();
                int Aux = 0;
                if(this.cmbEmpleados.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un empleado de la lista.", ControlSender = this.cmbEmpleados });
                else
                {
                    Usuario AuxEmp = (Usuario)this.cmbEmpleados.SelectedItem;
                    if (string.IsNullOrEmpty(AuxEmp.IDEmpleado.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un empleado de la lista.", ControlSender = this.cmbEmpleados });
                }
                if (this.cmbTipoRegistro.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un tipo de registro de la lista.", ControlSender = this.cmbTipoRegistro });
                else
                {
                    TipoRegistro AuxTReg = (TipoRegistro)this.cmbTipoRegistro.SelectedItem;
                    if (AuxTReg.IDTipoRegistro == 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un tipo de registro de la lista.", ControlSender = this.cmbTipoRegistro });
                }
                if(DateTime.Today.AddDays(1) <= this.dtpFecha.Value)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La fecha del registro no puede ser mayor a la fecha Actual.", ControlSender = this.dtpFecha });
                if (DateTime.Today > this.dtpFecha.Value.AddDays(5))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Solo se pueden agregar registros con fecha mayor a " + DateTime.Today.AddDays(-5).ToShortDateString(), ControlSender = this.dtpFecha });
                if(string.IsNullOrEmpty(this.txtMotivo.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el motivo por el cual se realiza el registro manual.", ControlSender = this.txtMotivo});
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
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmNuevoRegistroAsistencia ~ btnSalir_Click");
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
                    Checador DatosAux = this.ObtenerDatos();
                    Checador_Negocio CN = new Checador_Negocio();
                    CN.Checar(DatosAux);
                    if (DatosAux.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Ocurrió un error al guardar los datos.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmNuevoRegistroAsistencia ~ btnSalir_Click");
            }
        }

        private void frmNuevoRegistroAsistencia_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmNuevoRegistroAsistencia ~ frmNuevoRegistroAsistencia_Load");
            }
        }

        #endregion

    }
}
