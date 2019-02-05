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
    public partial class frmNuevoResumenComision : Form
    {

        private DateTime FechaInicio = DateTime.Today;
        private DateTime FechaFin = DateTime.Today;
        private string IDSucursal = string.Empty;

        #region Constructor

        public frmNuevoResumenComision()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoResumenComision ~ frmNuevoResumenComision()");
            }
        }

        #endregion

        #region Métodos

        private void CargarGridComisiones()
        {
            try
            {
                
                    Sucursal DatosSuc = this.ObtenerSucursalCombo();
                    if (this.dtpFechaInicio.Value <= this.dtpFechaFin.Value && !string.IsNullOrEmpty(DatosSuc.IDSucursal))
                    {
                        Comision Datos = new Comision { FechaInicio = this.dtpFechaInicio.Value, FechaFin = this.dtpFechaFin.Value, Conexion = Comun.Conexion, IDSucursal = DatosSuc.IDSucursal };
                        Comision_Negocio CN = new Comision_Negocio();
                        CN.ObtenerComisionesXRango(Datos);
                        this.dgvComisionesXEmpleado.AutoGenerateColumns = false;
                        this.dgvComisionesXEmpleado.DataSource = Datos.TablaDatos;
                    }
                    else
                    {
                        this.dgvComisionesXEmpleado.DataSource = new DataTable();

                    }
                    FechaInicio = this.dtpFechaInicio.Value;
                    FechaFin = this.dtpFechaFin.Value;
                    IDSucursal = DatosSuc.IDSucursal;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GenerarTabla()
        {
            try
            {
                DataTable TablaAux = new DataTable();
                TablaAux.Columns.Add("IDComision", typeof(string));
                TablaAux.Columns.Add("Aprobar", typeof(bool));
                foreach (DataGridViewRow Fila in this.dgvComisionesXEmpleado.Rows)
                {
                    string IDComision = Fila.Cells["IDComision"].Value.ToString();
                    bool Aprobada = false;
                    bool.TryParse(Fila.Cells["Aprobar"].Value.ToString(), out Aprobada);
                    object[] DatosFila = { IDComision, Aprobada };
                    TablaAux.Rows.Add(DatosFila);
                }
                return TablaAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void IniciarDatos()
        {
            try
            {
                this.cmbSucursal.SelectedIndexChanged -= new System.EventHandler(this.cmbSucursal_SelectedIndexChanged);
                this.dtpFechaInicio.ValueChanged -= new System.EventHandler(this.dtpFechaInicio_ValueChanged);
                this.dtpFechaFin.ValueChanged -= new System.EventHandler(this.dtpFechaFin_ValueChanged);
                this.LlenarComboSucursales();
                this.dtpFechaInicio.Value = DateTime.Today;
                this.dtpFechaFin.Value = DateTime.Today;
                this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
                this.dtpFechaFin.ValueChanged += new System.EventHandler(this.dtpFechaFin_ValueChanged);
                this.cmbSucursal.SelectedIndexChanged += new System.EventHandler(this.cmbSucursal_SelectedIndexChanged);
                this.CargarGridComisiones();
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
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
                this.IniciarDatos();
                this.ActiveControl = this.cmbSucursal;
                this.cmbSucursal.Focus();
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
                this.cmbSucursal.DataSource = SN.LlenarComboCatSucursales(DatosAux);
                this.cmbSucursal.ValueMember = "IDSucursal";
                this.cmbSucursal.DisplayMember = "NombreSucursal";
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

        private Comision ObtenerDatos()
        {
            try
            {
                Comision Datos = new Comision();
                Datos.FechaInicio = this.FechaInicio;
                Datos.FechaFin = this.FechaFin;
                Datos.TablaDatos = this.GenerarTabla();
                Datos.IDSucursal = this.IDSucursal;
                Datos.IDUsuario = Comun.IDUsuario;
                Datos.Conexion = Comun.Conexion;
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Sucursal ObtenerSucursalCombo()
        {
            try
            {
                Sucursal Datos = new Sucursal();
                if (this.cmbSucursal.Items.Count > 0)
                {
                    if (this.cmbSucursal.SelectedIndex != -1)
                    {
                        Datos = (Sucursal)this.cmbSucursal.SelectedItem;
                    }
                }
                return Datos;
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
                //if (string.IsNullOrEmpty(this.ObtenerSucursalCombo().IDSucursal))
                if (string.IsNullOrEmpty(this.IDSucursal))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una sucursal.", ControlSender = this.cmbSucursal });
                //if (this.dtpFechaInicio.Value > this.dtpFechaFin.Value)
                if (FechaInicio > FechaFin)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La fecha de inicio no puede ser mayor a la fecha fin.", ControlSender = this.dtpFechaInicio });
                if (this.dgvComisionesXEmpleado.Rows.Count == 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "No hay comisiones en el periodo seleccionado.", ControlSender = this.dtpFechaInicio });
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private List<Error> ValidarBuscador()
        {
            try
            {
                List<Error> Errores = new List<Error>();
                int Aux = 0;
                //if (string.IsNullOrEmpty(this.ObtenerSucursalCombo().IDSucursal))
                if (this.cmbSucursal.SelectedIndex == -1 || this.cmbSucursal.SelectedIndex == 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una sucursal.", ControlSender = this.cmbSucursal });
                else
                {
                    Sucursal SucAux = (Sucursal)this.cmbSucursal.SelectedItem;
                    if (string.IsNullOrEmpty(SucAux.IDSucursal))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una sucursal.", ControlSender = this.cmbSucursal });
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
                LogError.AddExcFileTxt(ex, "frmNuevoResumenComision ~ btnCancelar_Click");
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
                    Comision Datos = this.ObtenerDatos();
                    Comision_Negocio CN = new Comision_Negocio();
                    CN.AResumenComision(Datos);
                    if (Datos.Completado)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error. Intente nuevamente. Si el problema persiste, contacte a Soporte Técnico. Código del Error: " + Datos.Resultado, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoResumenComision ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //this.CargarGridComisiones();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoResumenComision ~ cmbSucursal_SelectedIndexChanged");
            }
        }

        private void cmbSucursal_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                //if (this.cmbSucursal.SelectedIndex == -1)
                //    this.CargarGridComisiones();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoResumenComision ~ cmbSucursal_Validating");
            }
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //this.CargarGridComisiones();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoResumenComision ~ dtpFechaFin_ValueChanged");
            }
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //this.CargarGridComisiones();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoResumenComision ~ dtpFechaInicio_ValueChanged");
            }
        }

        private void frmNuevoResumenComision_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoResumenComision ~ frmNuevoResumenComision_Load");
            }
        }

        #endregion

        private void btnBuscarComisiones_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtMensajeError.Visible = false;
                List<Error> Errores = this.ValidarBuscador();
                if (Errores.Count == 0)
                {
                    this.CargarGridComisiones();
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoResumenComision ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

