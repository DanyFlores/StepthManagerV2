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
    public partial class frmJustificaciones : Form
    {
        #region Contructor

        public frmJustificaciones()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmJustificaciones ~ frmJustificaciones");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                this.LlenarComboEmpleadosXIDSucursal();
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

        private void LlenarGridRegistros()
        {
            try
            {
                DataTable TablaAux = new DataTable();
                if (this.cmbEmpleados.SelectedIndex != -1)
                {
                    Usuario Aux = (Usuario)this.cmbEmpleados.SelectedItem;
                    Checador DatosAux = new Checador { Conexion = Comun.Conexion, FechaChecador = this.dtpFecha.Value, IDEmpleado = Aux.IDEmpleado };
                    if (!string.IsNullOrEmpty(DatosAux.IDEmpleado))
                    {
                        Checador_Negocio CN = new Checador_Negocio();
                        CN.ObtenerRegistrosXIDEmpleado(DatosAux);
                        if (DatosAux.Completado)
                            TablaAux = DatosAux.TablaDatos;
                    }
                }
                this.dgvResumenChecado.AutoGenerateColumns = false;
                this.dgvResumenChecado.DataSource = TablaAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Checador ObtenerDatosRegistroSeleccionado(int RowSelected)
        {
            try
            {
                Checador DatosAux = new Checador();
                DataGridViewRow Fila = this.dgvResumenChecado.Rows[RowSelected];
                DatosAux.IDRegistro = Fila.Cells["IDRegistro"].Value.ToString();
                int IDStatusRegistro = 0;
                int.TryParse(Fila.Cells["IDStatusRegistro"].Value.ToString(), out IDStatusRegistro);
                DatosAux.IDStatusRegistro = IDStatusRegistro;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnJustificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvResumenChecado.SelectedRows.Count == 1)
                {
                    Int32 RowSelected = this.dgvResumenChecado.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowSelected > -1)
                    {
                        Checador DatosAux = this.ObtenerDatosRegistroSeleccionado(RowSelected);
                        if (!string.IsNullOrEmpty(DatosAux.IDRegistro))
                        {
                            if (DatosAux.IDStatusRegistro == 1)
                            {
                                MessageBox.Show("El registro seleccionado está en un Estatus Normal. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                DatosAux.IDUsuario = Comun.IDUsuario;
                                DatosAux.Conexion = Comun.Conexion;
                                Checador_Negocio CN = new Checador_Negocio();
                                CN.JustificarRegistroAsistencia(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    switch (DatosAux.Opcion)
                                    {
                                        case 1: MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            btnMostrarResultados_Click(this.btnMostrarResultados, new EventArgs());
                                            break;
                                        case -1: MessageBox.Show("El registro no se puede justificar. El tipo de registro no es justificable.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            break;
                                        case -2: MessageBox.Show("El registro no se puede justificar. El empleado no tiene horario asignado para la fecha de checado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            break;
                                    }
                                }
                                else
                                    MessageBox.Show("Ocurrió un error al procesar los datos. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            MessageBox.Show("No se pueden obtener los datos del registro seleccionado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione el registro que desea justificar", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmJustificaciones ~ btnJustificar_Click");
            }
        }

        private void btnMostrarResultados_Click(object sender, EventArgs e)
        {
            try
            {
                this.LlenarGridRegistros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmJustificaciones ~ btnMostrarResultados_Click");
            }
        }

        private void btnNuevoRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoRegistroAsistencia Registro = new frmNuevoRegistroAsistencia();
                Registro.ShowDialog();
                Registro.Dispose();
                if (Registro.DialogResult == DialogResult.OK)
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmJustificaciones ~ btnNuevoRegistro_Click");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmJustificaciones ~ btnSalir_Click");
            }
        }

        private void frmJustificaciones_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmJustificaciones ~ frmJustificaciones");
            }
        }

        #endregion

    }
}
