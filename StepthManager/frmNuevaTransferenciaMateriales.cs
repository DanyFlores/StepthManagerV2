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
    public partial class frmNuevaTransferenciaMateriales : Form
    {
        #region Propiedades / Variables
        #endregion

        #region Constructor

        public frmNuevaTransferenciaMateriales()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaTransferenciaMateriales ~ frmNuevaTransferenciaMateriales()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {

                //Llenar combos de empleado origen y destino
                this.LlenarCombos();
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
        /// <summary>
        /// Llena los combos de los empleados para transferencia de sus materiales
        /// </summary>
        private void LlenarCombos()
        {
            try
            {
                
                TransferenciaMateriales Datos = new TransferenciaMateriales { Conexion = Comun.Conexion, Opcion = 1 };
                TransferenciaMateriales_Negocio SN = new TransferenciaMateriales_Negocio();
                this.cmbEOrigen.DataSource = SN.LlenarComboEmpleado(Datos);
                this.cmbEOrigen.DisplayMember = "Empleado";
                this.cmbEOrigen.ValueMember = "IDEmpleado";
                //otro combo
                this.cmbEDestino.DataSource = SN.LlenarComboEmpleado(Datos);
                this.cmbEDestino.DisplayMember = "Empleado";
                this.cmbEDestino.ValueMember = "IDEmpleado";
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// obtiene los datos de la interfaz
        /// </summary>
        /// <returns></returns>
        private TransferenciaMateriales ObtenerDatos()
        {
            try
            {
                TransferenciaMateriales DatosAux = new TransferenciaMateriales();
                object origen = cmbEOrigen.SelectedItem;
                object destino = cmbEDestino.SelectedItem;
                string empleadoOrigen = ((TransferenciaMateriales)origen).IDEmpleado;
                string empleadoDestino = ((TransferenciaMateriales)destino).IDEmpleado;
                string observaciones = txtbObservaciones.Text;
                if (string.IsNullOrEmpty(observaciones))
                {
                    DatosAux.Observaciones = "Sin observaciones";
                }
                else
                {
                    DatosAux.Observaciones = observaciones;
                }

                DatosAux.IDEmpleado = empleadoOrigen;
                DatosAux.IDEmpleadoDestino = empleadoDestino;
                
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Valida que los empleados se hayan seleccionado
        /// </summary>
        /// <returns></returns>
        private List<Error> ValidarDatos()
        {
            try
            {
                List<Error> Errores = new List<Error>();
                string empleadoOrigen = ((TransferenciaMateriales)cmbEOrigen.SelectedItem).IDEmpleado;
                string empleadoDestino = ((TransferenciaMateriales)cmbEDestino.SelectedItem).IDEmpleado;
                
                if(string.IsNullOrEmpty(empleadoOrigen) || string.IsNullOrEmpty(empleadoDestino))
                {
                    Errores.Add(new Error { Numero = 1, Descripcion = "Debe seleccionar el Empleado origen y el Empleado destino.", ControlSender = cmbEDestino });
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
                LogError.AddExcFileTxt(ex, "frmNuevaTransferenciaMateriales ~ btnCancelar_Click");
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
                    this.Visible = false;
                    TransferenciaMateriales Datos = this.ObtenerDatos();
                    TransferenciaMateriales_Negocio Neg = new TransferenciaMateriales_Negocio();
                    
                    int IDTransferencia = Neg.GenerarTransferencia(Comun.Conexion, Datos.IDEmpleado, Datos.IDEmpleadoDestino, Datos.Observaciones, Comun.IDUsuario);
                    if(IDTransferencia > 0)
                    {
                        //Generar el reporte 
                        frmVerReporteTransferenciaMateriales VerReporte = new frmVerReporteTransferenciaMateriales(IDTransferencia);
                        VerReporte.ShowDialog();
                        VerReporte.Dispose();
                        this.DialogResult = DialogResult.OK; 
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al generar el reporte.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    this.Visible = true;
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaTransferenciaMateriales ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoReporteFaltas_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaTransferenciaMateriales ~ frmNuevoReporteFaltas_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
