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
    public partial class frmCatClientes : Form
    {

        #region Constructores

        public frmCatClientes()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatClientes ~ frmCatClientes()");
            }
        }

        #endregion

        #region Métodos

        private void BusquedaClientes(string TextoCliente)
        {
            try
            {
                Cliente DatosAux = new Cliente{ Conexion = Comun.Conexion, Nombre = TextoCliente, BuscarTodos = false  };
                Cliente_Negocio CN = new Cliente_Negocio();
                CN.ObtenerCatClientesBusqueda(DatosAux);
                this.dgvClientes.AutoGenerateColumns = false;
                this.dgvClientes.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EliminarCliente(Cliente Datos)
        {
            try
            {
                Datos.Conexion = Comun.Conexion;
                Datos.IDUsuario = Comun.IDUsuario;
                Datos.Opcion = 3;
                Datos.TablaPadecimientos = this.GenerarTablaPadecimientos();
                Datos.TablaTagsInteres = this.GenerarTablaTagsInteres();
                Cliente_Negocio CN = new Cliente_Negocio();
                CN.ABCCatClientes(Datos);
                if (Datos.Completado)
                {
                    MessageBox.Show("Registro Eliminado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Int32 RowToDelete = this.dgvClientes.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowToDelete > -1)
                        this.dgvClientes.Rows.RemoveAt(RowToDelete);
                    else
                        this.LlenarGridCatClientes(false);
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

        private void ModificarDatos(Cliente Datos)
        {
            try
            {
                Int32 RowToUpdate = this.dgvClientes.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowToUpdate > -1)
                {
                    this.dgvClientes.Rows[RowToUpdate].Cells["Nombre"].Value = Datos.Nombre;
                    this.dgvClientes.Rows[RowToUpdate].Cells["ApellidoPat"].Value = Datos.ApellidoPat;
                    this.dgvClientes.Rows[RowToUpdate].Cells["ApellidoMat"].Value = Datos.ApellidoMat;
                    this.dgvClientes.Rows[RowToUpdate].Cells["IDGenero"].Value = Datos.IDGenero;
                    this.dgvClientes.Rows[RowToUpdate].Cells["Genero"].Value = Datos.GenereoDesc;
                    this.dgvClientes.Rows[RowToUpdate].Cells["FechaNac"].Value = Datos.FechaNac;
                    this.dgvClientes.Rows[RowToUpdate].Cells["Correo"].Value = Datos.Correo;
                    this.dgvClientes.Rows[RowToUpdate].Cells["Telefono"].Value = Datos.Telefono;
                    this.dgvClientes.Rows[RowToUpdate].Cells["Observaciones"].Value = Datos.Observaciones;
                    this.dgvClientes.Rows[RowToUpdate].Cells["Recomendaciones"].Value = Datos.Recomendaciones;
                }
                else
                    this.LlenarGridCatClientes(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ModificarDatosTarjeta(TarjetaMonedero Datos)
        {
            try
            {
                Int32 RowToUpdate = this.dgvClientes.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowToUpdate > -1)
                {
                    //this.dgvClientes.Rows[RowToUpdate].Cells["IDTarjeta"].Value = Datos.IDTarjeta;
                    //this.dgvClientes.Rows[RowToUpdate].Cells["IDTipoMonedero"].Value = Datos.IDTipoMonedero;
                    //this.dgvClientes.Rows[RowToUpdate].Cells["TipoMonedero"].Value = Datos.TipoMonederoDesc;
                    this.dgvClientes.Rows[RowToUpdate].Cells["Folio"].Value = Datos.Folio;
                }
                else
                    this.LlenarGridCatClientes(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GenerarTablaPadecimientos()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla.Columns.Add("IDPadecimiento", typeof(string));
                Tabla.Columns.Add("IDPadecimientoXCliente", typeof(string));
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GenerarTablaTagsInteres()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla.Columns.Add("IDTagInteres", typeof(string));
                return Tabla;
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
                //this.IniciarGrid(this.dgvClientes, 13, this.ObtenerPropiedadesGridClientes());
                this.LlenarGridCatClientes(false);
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

        private void LlenarGridCatClientes(bool Band)
        {
            try
            {
                Cliente DatosAux = new Cliente { Conexion = Comun.Conexion, BuscarTodos = Band };
                Cliente_Negocio CN = new Cliente_Negocio();
                CN.ObtenerCatClientes(DatosAux);
                this.dgvClientes.AutoGenerateColumns = false;
                this.dgvClientes.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Cliente ObtenerDatosCliente()
        {
            try
            {
                Cliente DatosAux = new Cliente();
                Int32 RowData = this.dgvClientes.Rows.GetFirstRow(DataGridViewElementStates.Selected); 
                if (RowData > -1) 
                {
                    DataGridViewRow FilaDatos = this.dgvClientes.Rows[RowData];
                    int IDGenero = 0;
                    DateTime FechaNac = DateTime.Today;
                    int.TryParse(FilaDatos.Cells["IDGenero"].Value.ToString(), out IDGenero);
                    DateTime.TryParse(FilaDatos.Cells["FechaNac"].Value.ToString(), CultureInfo.CurrentCulture, DateTimeStyles.None, out FechaNac);
                    DatosAux.IDCliente = FilaDatos.Cells["IDCliente"].Value.ToString();
                    DatosAux.Nombre = FilaDatos.Cells["Nombre"].Value.ToString();
                    DatosAux.ApellidoPat = FilaDatos.Cells["ApellidoPat"].Value.ToString();
                    DatosAux.IDTarjeta = FilaDatos.Cells["IDTarjeta"].Value.ToString();
                    DatosAux.ApellidoMat = FilaDatos.Cells["ApellidoMat"].Value.ToString();
                    DatosAux.GenereoDesc = FilaDatos.Cells["Genero"].Value.ToString();
                    DatosAux.Correo = FilaDatos.Cells["Correo"].Value.ToString();
                    DatosAux.Telefono = FilaDatos.Cells["Telefono"].Value.ToString();
                    DatosAux.Observaciones = FilaDatos.Cells["Observaciones"].Value.ToString();
                    DatosAux.Recomendaciones = FilaDatos.Cells["Recomendaciones"].Value.ToString();
                    DatosAux.IDGenero = IDGenero;
                    DatosAux.FechaNac = FechaNac;
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private object[,] ObtenerPropiedadesGridClientes()
        {
            try
            {
                object[,] Propiedades = new object[,] 
                { 
                    //Encabezado            //DataProperty          //Name                  //TipoCol   //Visibilidad   //Ancho     //Alignment                                     //Format    ReadOnly
                    {"IDCliente",           "IDCliente",            "IDCliente",            1,          false,          125,        DataGridViewContentAlignment.MiddleCenter,      "",         true},
                    {"Nombre",              "Nombre",               "Nombre",               1,          true,           125,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Apellido Paterno",    "ApellidoPat",          "ApellidoPat",          1,          true,           125,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Apellido Materno",    "ApellidoMat",          "ApellidoMat",          1,          true,           125,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"IDGenero",            "IDGenero",             "IDGenero",             1,          false,          100,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Genero",              "Genero",               "Genero",               1,          true,           100,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Fecha de Nacimiento", "FechaNac",             "FechaNac",             1,          true,           110,        DataGridViewContentAlignment.MiddleLeft,        "dd/MM/yyyy",        true},
                    {"Correo Electrónico",  "Correo",               "Correo",               1,          true,           250,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Número Telefónico",   "Telefono",             "Telefono",             1,          true,           100,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Ver Monedero",        "Monedero",             "Monedero",             4,          true,           100,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Hist. Citas",         "",                "Citas",                4,          true,           100,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Hist. Sucursales",    "",           "Sucursales",           4,          true,           100,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                    {"Hist. Compras",       "",              "Compras",              4,          true,           100,        DataGridViewContentAlignment.MiddleLeft,        "",         true},
                };
                return Propiedades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ModificarDatosTarjetaSaldo(TarjetaMonedero Datos)
        {
            try
            {
                Int32 RowToUpdate = this.dgvClientes.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowToUpdate > -1)
                {
                    this.dgvClientes.Rows[RowToUpdate].Cells["Saldo"].Value = Datos.Saldo;
                }
                else
                    this.LlenarGridCatClientes(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Cliente ObtenerDatosMonederoGrid()
        {
            try
            {
                Cliente DatosAux = new Cliente();
                Int32 RowData = this.dgvClientes.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowData > -1)
                {
                    decimal saldoMonedero;
                    DataGridViewRow FilaDatos = this.dgvClientes.Rows[RowData];
                    DatosAux.IDCliente = FilaDatos.Cells["IDCliente"].Value.ToString();
                    DatosAux.IDTarjeta = FilaDatos.Cells["IDTarjeta"].Value.ToString();
                    decimal.TryParse(FilaDatos.Cells["Saldo"].Value.ToString(), out saldoMonedero);
                    DatosAux.SaldoMonedero = saldoMonedero;
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

        private void btnAsignarTarjeta_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvClientes.SelectedRows.Count == 1)
                {
                    Cliente DatosAux = this.ObtenerDatosCliente();
                    if (!string.IsNullOrEmpty(DatosAux.IDCliente))
                    {
                        bool BandConfirmacion = true;
                        if (!string.IsNullOrEmpty(DatosAux.FolioTarjeta))
                        {
                            BandConfirmacion = MessageBox.Show("El cliente seleccionado ya tiene una tarjeta asignada. Si continúa con el proceso, la tarjeta se reemplazará y ya no podrá ser usada. El saldo actual pasará a la nueva tarjeta. ¿Está seguro de continuar?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
                        }
                        if (BandConfirmacion)
                        {
                            frmNumeroTarjeta Tarjetas = new frmNumeroTarjeta(DatosAux);
                            Tarjetas.ShowDialog();
                            Tarjetas.Dispose();
                            if (Tarjetas.DialogResult == DialogResult.OK)
                            {
                                this.ModificarDatosTarjeta(Tarjetas.DatosAux);
                                MessageBox.Show("Datos actualizados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            //frmElegirTarjetaMonedero Tarjetas = new frmElegirTarjetaMonedero(DatosAux.IDCliente);
                            //Tarjetas.ShowDialog();
                            //Tarjetas.Dispose();
                            //if (Tarjetas.DialogResult == DialogResult.OK)
                            //{
                            //    this.ModificarDatosTarjeta(Tarjetas.Seleccionado);
                            //    MessageBox.Show("Datos actualizados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatClientes ~ btnEliminar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtBusqueda.Text.Trim()))
                {
                    if (Validar.IsValidName(txtBusqueda.Text.Trim()))
                        this.BusquedaClientes(this.txtBusqueda.Text.Trim());
                    else
                        this.txtBusqueda.Text = string.Empty;
                }
                else
                    this.LlenarGridCatClientes(false);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatClientes ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvClientes.SelectedRows.Count == 1)
                {
                    Cliente DatosAux = this.ObtenerDatosCliente();
                    if (!string.IsNullOrEmpty(DatosAux.IDCliente))
                    {
                        if(MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            this.EliminarCliente(DatosAux);
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatClientes ~ btnEliminar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvClientes.SelectedRows.Count == 1)
                {
                    Cliente DatosAux = this.ObtenerDatosCliente();
                    if (!string.IsNullOrEmpty(DatosAux.IDCliente))
                    {
                        this.Visible = false;
                        frmNuevoCliente Cliente = new frmNuevoCliente(DatosAux);
                        Cliente.ShowDialog();
                        Cliente.Dispose();
                        if (Cliente.DialogResult == DialogResult.OK)
                        {
                            if (Cliente.DatosCliente.Completado)
                            {
                                this.ModificarDatos(Cliente.DatosCliente);
                            }
                        }
                        this.Visible = true;
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatClientes ~ btnModificar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmNuevoCliente Cliente = new frmNuevoCliente();
                Cliente.ShowDialog();
                Cliente.Dispose();
                if (Cliente.DialogResult == DialogResult.OK)
                {
                    this.BusquedaClientes(Cliente.DatosCliente.Nombre + " " + Cliente.DatosCliente.ApellidoPat + " " + Cliente.DatosCliente.ApellidoMat);
                }
                this.Visible = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatClientes ~ btnNuevo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
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
                LogError.AddExcFileTxt(ex, "frmCatClientes ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            try
            {
                this.LlenarGridCatClientes(true);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatClientes ~ btnTodos_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCatClientes_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatClientes ~ frmCatClientes_Load");
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
                LogError.AddExcFileTxt(ex, "frmCatClientes ~ txtBusqueda_KeyPress");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaldoMonedero_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvClientes.SelectedRows.Count == 1)
                {
                    Cliente DatosAux = this.ObtenerDatosMonederoGrid();
                    if (!string.IsNullOrEmpty(DatosAux.IDCliente))
                    {
                        frmSaldoMonedero Cliente = new frmSaldoMonedero(DatosAux);
                        Cliente.ShowDialog();
                        Cliente.Dispose();
                        if (Cliente.DialogResult == DialogResult.OK)
                        {
                            if (Cliente.DatosAux.Completado)
                            {
                                this.ModificarDatosTarjetaSaldo(Cliente.DatosAux);
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatClientes ~ btnModificar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Cliente DatosAux = this.ObtenerDatosCliente();
                if (!string.IsNullOrEmpty(DatosAux.IDCliente))
                {
                    if (e.ColumnIndex == dgvClientes.Columns["Citas"].Index && e.RowIndex >= 0)
                    {
                        this.Visible = false;
                        frmHistCita Cliente = new frmHistCita(DatosAux);
                        Cliente.ShowDialog();
                        Cliente.Dispose();
                        if (Cliente.DialogResult == DialogResult.OK)
                        {
                            if (Cliente.DatosClientes.Completado)
                            {
                                this.ModificarDatos(Cliente.DatosClientes);
                            }
                        }
                        this.Visible = true;
                    }
                    else if (e.ColumnIndex == dgvClientes.Columns["Sucursales"].Index && e.RowIndex >= 0)
                    {
                        this.Visible = false;
                        frmHistSucursales Cliente = new frmHistSucursales(DatosAux);
                        Cliente.ShowDialog();
                        Cliente.Dispose();
                        if (Cliente.DialogResult == DialogResult.OK)
                        {
                            if (Cliente.DatosClientes.Completado)
                            {
                                this.ModificarDatos(Cliente.DatosClientes);
                            }
                        }
                        this.Visible = true;
                    }
                    else if (e.ColumnIndex == dgvClientes.Columns["Compras"].Index && e.RowIndex >= 0)
                    {
                        this.Visible = false;
                        frmHistCompras Cliente = new frmHistCompras(DatosAux);
                        Cliente.ShowDialog();
                        Cliente.Dispose();
                        if (Cliente.DialogResult == DialogResult.OK)
                        {
                            if (Cliente.DatosClientes.Completado)
                            {
                                this.ModificarDatos(Cliente.DatosClientes);
                            }
                        }
                        this.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatClientes ~ dgvClientes_CellContentClick");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
