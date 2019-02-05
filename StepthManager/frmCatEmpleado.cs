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
using System.IO;

namespace StephManager
{
    public partial class frmCatEmpleado : Form
    {

        #region Constructores

        public frmCatEmpleado()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ frmCatEmpleado()");
            }
        }

        #endregion

        #region Métodos

        private DataTable GenerarTablaSucursales()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla.Columns.Add("IDSucursal", typeof(string));
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        private void BusquedaUsuario(string TextoEmpleado)
        {
            try
            {
                Usuario DatosAux = new Usuario{ Conexion = Comun.Conexion, Nombre = TextoEmpleado, BuscarTodos = false  };
                Usuario_Negocio CN = new Usuario_Negocio();
                CN.ObtenerUsuarioBusqueda(DatosAux);
                this.dgvUsuario.AutoGenerateColumns = false;
                this.dgvUsuario.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EliminarUsuario(Usuario Datos)
        {
            try
            {
                Datos.Conexion = Comun.Conexion;
                Datos.IDUsuario = Comun.IDUsuario;
                Datos.TablaUsuarioSucursal = this.GenerarTablaSucursales();
                Datos.Opcion = 3;
                Usuario_Negocio CN = new Usuario_Negocio();
                CN.ABCUsuario(Datos);
                if (Datos.Completado)
                {
                    MessageBox.Show("Registro Eliminado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Int32 RowToDelete = this.dgvUsuario.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowToDelete > -1)
                        this.dgvUsuario.Rows.RemoveAt(RowToDelete);
                    else
                        this.LlenarGridUsuario(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar los datos. Contacte a Soporte Técnico.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogError.AddExcFileTxt(new Exception(Datos.MensajeError), "frmCatClientes ~ EliminarCliente -> Método");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ModificarDatos(Usuario Datos)
        {
            try
            {
                Int32 RowToUpdate = this.dgvUsuario.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowToUpdate > -1)
                {
                    this.dgvUsuario.Rows[RowToUpdate].Cells["Nombre"].Value = Datos.Nombre;
                    this.dgvUsuario.Rows[RowToUpdate].Cells["ApellidoPat"].Value = Datos.ApellidoPat;
                    this.dgvUsuario.Rows[RowToUpdate].Cells["ApellidoMat"].Value = Datos.ApellidoMat;
                    this.dgvUsuario.Rows[RowToUpdate].Cells["DirCalle"].Value = Datos.DirCalle;
                    this.dgvUsuario.Rows[RowToUpdate].Cells["DirColonia"].Value = Datos.DirColonia;
                    this.dgvUsuario.Rows[RowToUpdate].Cells["DirNumero"].Value = Datos.DirNumero;
                }
                else
                    this.LlenarGridUsuario(false);
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
                //this.IniciarGrid(this.dgvUsuario, 10, this.ObtenerPropiedadesGridUsuario());
                this.LlenarGridUsuario(false);
                this.txtBusqueda.Focus();
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

        private void IniciarGrid(DataGridView actual, int numColumns, object[,] propiedades)
        {
            try
            {
                ConfiguracionDataGridView dgvConf = new ConfiguracionDataGridView();
                foreach (DataGridViewColumn columna in actual.Columns)
                {
                    columna.Dispose();
                }
                actual.Columns.Clear();
                actual.DataSource = null;
                dgvConf.AddColumnsDataGridViewReadOnly(actual, numColumns, propiedades);
                actual.AutoSize = true;
                actual.AutoGenerateColumns = false;
                actual.AllowUserToAddRows = false;
                actual.AllowUserToDeleteRows = false;
                actual.AllowUserToOrderColumns = false;
                actual.AllowUserToResizeColumns = false;
                actual.MultiSelect = false;
                actual.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                actual.ReadOnly = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridUsuario(bool Band)
        {
            try
            {
                Usuario DatosAux = new Usuario { Conexion = Comun.Conexion, BuscarTodos = Band };
                Usuario_Negocio CN = new Usuario_Negocio();
                CN.ObtenerUsuario(DatosAux);
                this.dgvUsuario.AutoGenerateColumns = false;
                this.dgvUsuario.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Usuario ObtenerDatosUsuario()
        {
            try
            {
                Usuario DatosAux = new Usuario();
                Int32 RowData = this.dgvUsuario.Rows.GetFirstRow(DataGridViewElementStates.Selected); 
                if (RowData > -1) 
                {
                    int ID = 0;
                    DataGridViewRow FilaDatos = this.dgvUsuario.Rows[RowData];
                    DatosAux.IDEmpleado = FilaDatos.Cells["IDEmpleado"].Value.ToString();
                    int.TryParse(FilaDatos.Cells["IDTipoUsuario"].Value.ToString(), out ID);
                    DatosAux.IDTipoUsuario = ID;
                    int.TryParse(FilaDatos.Cells["IDPuesto"].Value.ToString(), out ID);
                    DatosAux.IDPuesto = ID;
                    DatosAux.IDCategoriaPuesto = FilaDatos.Cells["IDCategoria"].Value.ToString();
                    DatosAux.IDSucursalActual = FilaDatos.Cells["IDSucursal"].Value.ToString();
                    DatosAux.AbrirCaja = Convert.ToBoolean(FilaDatos.Cells["AbrirCaja"].Value.ToString());
                    DatosAux.Nombre = FilaDatos.Cells["Nombre"].Value.ToString();
                    DatosAux.ApellidoPat = FilaDatos.Cells["ApellidoPat"].Value.ToString();
                    DatosAux.ApellidoMat = FilaDatos.Cells["ApellidoMat"].Value.ToString();
                    DatosAux.DirCalle = FilaDatos.Cells["DirCalle"].Value.ToString();
                    DatosAux.DirColonia = FilaDatos.Cells["DirColonia"].Value.ToString();
                    DatosAux.DirNumero = FilaDatos.Cells["DirNumero"].Value.ToString();
                    DatosAux.CuentaUsuario = FilaDatos.Cells["CuentaUsuario"].Value.ToString();
                    DatosAux.Password = FilaDatos.Cells["Contraseña"].Value.ToString();
                    DatosAux.AltaNominal = Convert.ToBoolean(FilaDatos.Cells["AltaNominal"].Value.ToString());
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtBusqueda.Text.Trim()))
                {
                    if (Validar.IsValidName(txtBusqueda.Text.Trim()))
                        this.BusquedaUsuario(this.txtBusqueda.Text.Trim());
                    else
                        this.txtBusqueda.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUsuario.SelectedRows.Count == 1)
                {
                    Usuario DatosAux = this.ObtenerDatosUsuario();
                    if (!string.IsNullOrEmpty(DatosAux.IDEmpleado))
                    {
                        if(MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            this.EliminarUsuario(DatosAux);
                            this.LlenarGridUsuario(false);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnEliminar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUsuario.SelectedRows.Count == 1)
                {
                    Usuario DatosAux = this.ObtenerDatosUsuario();
                    if (!string.IsNullOrEmpty(DatosAux.IDEmpleado))
                    {
                        this.Visible = false;
                        frmNuevoEmpleado Empleado = new frmNuevoEmpleado(DatosAux);
                        Empleado.ShowDialog();
                        Empleado.Dispose();
                        if (Empleado.DialogResult == DialogResult.OK)
                        {
                            if (Empleado.DatosUsuario.Completado)
                            {
                                this.ModificarDatos(Empleado.DatosUsuario);
                            }
                        }
                        this.Visible = true;
                        this.LlenarGridUsuario(false);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnModificar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmNuevoEmpleado Empleado = new frmNuevoEmpleado();
                Empleado.ShowDialog();
                Empleado.Dispose();
                if (Empleado.DialogResult == DialogResult.OK)
                {
                    this.BusquedaUsuario(Empleado.DatosUsuario.Nombre + " " + Empleado.DatosUsuario.ApellidoPat + " " + Empleado.DatosUsuario.ApellidoMat);
                }
                this.Visible = true;
                this.LlenarGridUsuario(false);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnNuevo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnCuentaUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUsuario.SelectedRows.Count == 1)
                {
                    Usuario DatosAux = this.ObtenerDatosUsuario();
                    if (!string.IsNullOrEmpty(DatosAux.IDEmpleado))
                    {
                        Int32 RowData = this.dgvUsuario.Rows.GetFirstRow(DataGridViewElementStates.Selected); 
                        frmCuentaEmpleado Empleado = new frmCuentaEmpleado(DatosAux);
                        Empleado.ShowDialog();
                        Empleado.Dispose();
                        if (Empleado.DialogResult == DialogResult.OK)
                        {
                            this.dgvUsuario.Rows[RowData].Cells["CuentaUsuario"].Value = Empleado.DatosUsuario.CuentaUsuario;
                        }
                        //this.LlenarGridUsuario(false);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnCuentaUser_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnHuellaDigital_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUsuario.SelectedRows.Count == 1)
                {
                    Usuario DatosAux = this.ObtenerDatosUsuario();
                    if (!string.IsNullOrEmpty(DatosAux.IDEmpleado))
                    {
                        frmCatEmpleadoHuella Huella = new frmCatEmpleadoHuella(DatosAux);
                        Huella.ShowDialog();
                        Huella.Dispose();
                        if (Huella.DialogResult == DialogResult.OK)
                        {
                            this.LlenarGridUsuario(false);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnHuellaDigital_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Abort;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.LlenarGridUsuario(true);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnTodos_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCatEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ frmCatEmpleado_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)Keys.Enter)
                {
                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ txtBusqueda_KeyPress");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnAltaNominal_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUsuario.SelectedRows.Count == 1)
                {
                    Usuario DatosAux = this.ObtenerDatosUsuario();
                    if (!string.IsNullOrEmpty(DatosAux.IDEmpleado))
                    {
                        if (!DatosAux.AltaNominal)
                        {
                            frmAltaNominal AltaN = new frmAltaNominal(DatosAux);
                            AltaN.ShowDialog();
                            AltaN.Dispose();
                            if (AltaN.DialogResult == DialogResult.OK)
                            {
                                this.LlenarGridUsuario(false);
                            }
                        }
                        else
                            MessageBox.Show("El empleado ya está dado de alta.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnAltaNominal_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBajaNominal_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUsuario.SelectedRows.Count == 1)
                {
                    Usuario DatosAux = this.ObtenerDatosUsuario();
                    if (!string.IsNullOrEmpty(DatosAux.IDEmpleado))
                    {
                        if (DatosAux.AltaNominal)
                        {
                            frmBajaNominal BajaN = new frmBajaNominal(DatosAux);
                            BajaN.ShowDialog();
                            BajaN.Dispose();
                            if (BajaN.DialogResult == DialogResult.OK)
                            {
                                this.LlenarGridUsuario(false);
                            }
                        }
                        else
                            MessageBox.Show("El empleado no está dado de alta.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnBajaNominal_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHorario_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUsuario.SelectedRows.Count == 1)
                {
                    Usuario DatosAux = this.ObtenerDatosUsuario();
                    if (!string.IsNullOrEmpty(DatosAux.IDEmpleado))
                    {
                        frmHorarioEmpleado Horario = new frmHorarioEmpleado(DatosAux.IDEmpleado);
                        Horario.ShowDialog();
                        Horario.Dispose();
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnHorario_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHistorialLaboral_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUsuario.SelectedRows.Count == 1)
                {
                    Usuario DatosAux = this.ObtenerDatosUsuario();
                    if (!string.IsNullOrEmpty(DatosAux.IDEmpleado))
                    {
                        frmHistorialLaboral HistLaboral = new frmHistorialLaboral(DatosAux);
                        HistLaboral.ShowDialog();
                        HistLaboral.Dispose();
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnHistorialLaboral_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAsignarPermisos_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUsuario.SelectedRows.Count == 1)
                {
                    Usuario DatosAux = this.ObtenerDatosUsuario();
                    if (!string.IsNullOrEmpty(DatosAux.IDEmpleado))
                    {
                        frmCatEmpleadoPermisos EmpleadoPermisos = new frmCatEmpleadoPermisos(DatosAux);
                        EmpleadoPermisos.ShowDialog();
                        EmpleadoPermisos.Dispose();
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnAsignarPermisos_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAsignarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUsuario.SelectedRows.Count == 1)
                {
                    Usuario DatosAux = this.ObtenerDatosUsuario();
                    if (!string.IsNullOrEmpty(DatosAux.IDEmpleado))
                    {
                        if (DatosAux.AltaNominal)
                        {
                            frmCateEmpleadoAsignarCategoria CambiarCategoria = new frmCateEmpleadoAsignarCategoria(DatosAux);
                            CambiarCategoria.ShowDialog();
                            CambiarCategoria.Dispose();
                            if (CambiarCategoria.DialogResult == DialogResult.OK)
                            {
                                this.LlenarGridUsuario(false);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El empleado tiene que estar dado de alta nominal.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnAsignarCategoria_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVacaciones_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUsuario.SelectedRows.Count == 1)
                {
                    Usuario DatosAux = this.ObtenerDatosUsuario();
                    if (!string.IsNullOrEmpty(DatosAux.IDEmpleado))
                    {
                        frmVacaciones NominaVacaciones = new frmVacaciones(DatosAux);
                        NominaVacaciones.ShowDialog();
                        NominaVacaciones.Dispose();
                        if (NominaVacaciones.DialogResult == DialogResult.OK)
                        {
                            this.LlenarGridUsuario(false);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleado ~ btnVacaciones_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
