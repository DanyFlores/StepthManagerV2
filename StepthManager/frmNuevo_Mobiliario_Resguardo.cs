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
    public partial class frmNuevo_Mobiliario_Resguardo : Form
    {
        #region Variables
        
        private string IDSucursales = string.Empty;
        private MobiliarioResguardo _DatosMobiliarioResguardo;
        public MobiliarioResguardo DatosMobiliarioReguardo
        {
            get { return _DatosMobiliarioResguardo; }
            set { _DatosMobiliarioResguardo = value; }
        }
        private List<MobiliarioResguardo> ListadeReguardo = new List<MobiliarioResguardo>();

        private string IDMobiliarioResguardos = string.Empty;

        private bool NuevoRegistro = true;

        #endregion
        

        #region Constructores

        public frmNuevo_Mobiliario_Resguardo()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevo_Mobiliario_Resguardo ~ frmNuevo_Mobiliario_Resguardo()");
            }
        }
        public frmNuevo_Mobiliario_Resguardo(String IDResguardoMobiliario)
        {
            try
            {
                InitializeComponent();
                this.NuevoRegistro = false;
                this.IDMobiliarioResguardos = IDResguardoMobiliario;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevo_Mobiliario_Resguardo ~ frmNuevo_Mobiliario_Resguardo(MobiliarioResguardo Datos)");
            }
        }

        #endregion

        #region Métodos

        private void BusquedaMobiliario(string TextoMobiliario)
        {
            try
            {
                Mobiliario DatosAux = new Mobiliario { Conexion = Comun.Conexion, Descripcion = TextoMobiliario, BuscarTodos = false };
                Mobiliario_Negocio MN = new Mobiliario_Negocio();
                MN.ObtenerCatMobiliarioBusqueda(DatosAux);
                this.dgvMobiliario.AutoGenerateColumns = false;
                this.dgvMobiliario.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ModificarDatos(MobiliarioResguardo Datos)
        {
            try
            {
                Int32 RowToUpdate = this.dgvMobiliario.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowToUpdate > -1)
                {
                    this.dgvMobiliario.Rows[RowToUpdate].Cells["IDTipoMobiliario"].Value = Datos.IDMobiliarioResguardo;
                    this.dgvMobiliario.Rows[RowToUpdate].Cells["Codigo"].Value = Datos.FolioResguardo;
                    this.dgvMobiliario.Rows[RowToUpdate].Cells["Descripcion"].Value = Datos.Descripcion;
                    this.dgvMobiliario.Rows[RowToUpdate].Cells["Marca"].Value = Datos.Marca;
                    this.dgvMobiliario.Rows[RowToUpdate].Cells["Modelo"].Value = Datos.Modelo;
                }
                else
                    this.LlenarGridCatMobiliario(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        private void CargarGridMoviliario()
        {
            try
            {
                BindingSource Datos = new BindingSource();
                Datos.DataSource = this.ListadeReguardo;
                this.dgvMobiliario.AutoGenerateColumns = false;
                this.dgvMobiliario.DataSource = Datos;
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
                this.CargarComboSucursales();
                if (!NuevoRegistro)
                {
                    MobiliarioResguardo DatosAux = this.CargarGribMobiliarioDetalle();
                    this.LlenarDatosResguardoModificar(DatosAux);
                }
                this.cmbSucursales.Focus();
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

        private void CargarComboSucursales()
        {
            try
            {
                Sucursal DatosSuc = new Sucursal { Conexion = Comun.Conexion, Opcion = 2 };
                Sucursal_Negocio SucNeg = new Sucursal_Negocio();
                this.cmbSucursales.DataSource = SucNeg.LlenarComboCatSucursales(DatosSuc);
                this.cmbSucursales.ValueMember = "IDSucursal";
                this.cmbSucursales.DisplayMember = "NombreSucursal";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private MobiliarioResguardo CargarGribMobiliarioDetalle()
        {
            try
            {
                MobiliarioResguardo DatosAux = new MobiliarioResguardo { Conexion = Comun.Conexion, IDMobiliarioResguardo = this.IDMobiliarioResguardos };
                MobiliarioResguardo_Negocio MBNeg = new MobiliarioResguardo_Negocio();
                return MBNeg.ObtenerDatosDetalleMobiliario(DatosAux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarDatosResguardoModificar(MobiliarioResguardo Aux)
        {
            try
            {
                this.cmbSucursales.SelectedValueChanged -= new System.EventHandler(this.cmbSucursales_SelectedValueChanged);
                if (ExisteItemEnComboSucursal(Aux.IDSucursal))
                    this.cmbSucursales.SelectedValue = Aux.IDSucursal;
                this.ListadeReguardo = Aux.ListaMobiliarioDetalle;
                this.IDSucursales = Aux.IDSucursal;
                this.CargarGridMoviliario();
                this.cmbSucursales.SelectedValueChanged += new System.EventHandler(this.cmbSucursales_SelectedValueChanged);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExisteItemEnComboSucursal(string ID)
        {
            try
            {
                bool Band = false;
                foreach (Sucursal Item in this.cmbSucursales.Items)
                {
                    if (Item.IDSucursal == ID)
                    {
                        Band = true;
                        break;
                    }
                }
                return Band;
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
                Sucursal DatosAux = new Sucursal();
                if (this.cmbSucursales.Items.Count > 0)
                {
                    if (this.cmbSucursales.SelectedIndex != -1)
                    {
                        DatosAux = (Sucursal)this.cmbSucursales.SelectedItem;
                    }
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridCatMobiliario(bool Band)
        {
            try
            {
                Mobiliario DatosAux = new Mobiliario { Conexion = Comun.Conexion, BuscarTodos = Band };
                Mobiliario_Negocio MN = new Mobiliario_Negocio();
                MN.ObtenerCatMobiliario(DatosAux);
                this.dgvMobiliario.AutoGenerateColumns = false;
                this.dgvMobiliario.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private MobiliarioResguardo ObtenerDatosMobiliario()
        {
            try
            {
                MobiliarioResguardo DatosAux = new MobiliarioResguardo();
                DataTable TablaMobiliarioResguardo = new DataTable();
                TablaMobiliarioResguardo.Columns.Add("IDMobiliario", typeof(string));
                TablaMobiliarioResguardo.Columns.Add("Codigo", typeof(string));
                TablaMobiliarioResguardo.Columns.Add("Descripcion", typeof(string));
                TablaMobiliarioResguardo.Columns.Add("Marca", typeof(string));
                TablaMobiliarioResguardo.Columns.Add("Modelo", typeof(string));
                TablaMobiliarioResguardo.Columns.Add("Cantidad", typeof(int));
                foreach (MobiliarioResguardo Item in this.ListadeReguardo)
                {
                    TablaMobiliarioResguardo.Rows.Add(new object[] { Item.IDMobiliario, Item.Codigo, Item.Descripcion, Item.Marca, Item.Modelo, Item.Cantidad });
                }
                Sucursal SAux = new Sucursal();
                if (this.cmbSucursales.SelectedIndex != -1)
                    SAux = (Sucursal)this.cmbSucursales.SelectedItem;

                DatosAux.IDMobiliarioResguardo = NuevoRegistro ? string.Empty : this.IDMobiliarioResguardos;
                DatosAux.NuevoRegistro = NuevoRegistro;            
                DatosAux.IDSucursal = SAux.IDSucursal;
                DatosAux.IDSucursalEquipo = Comun.IDSucursalCaja;         
                DatosAux.TablaMobiliarioResguardo = TablaMobiliarioResguardo;
                DatosAux.Conexion = Comun.Conexion;
                DatosAux.IDUsuario = Comun.IDUsuario;
                return DatosAux;
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

        private List<Error> ValidarDatos()
        {
            try
            {
                List<Error> ListaErrores = new List<Error>();
                int Aux = 0;
               
                if (this.cmbSucursales.SelectedIndex == -1)
                    ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una sucursal.", ControlSender = this.cmbSucursales });
                else
                {
                    Sucursal SucursalAux = (Sucursal)this.cmbSucursales.SelectedItem;
                    if (string.IsNullOrEmpty(SucursalAux.IDSucursal))
                        ListaErrores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una sucursal.", ControlSender = this.cmbSucursales });
                }
              
                
                return ListaErrores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private bool ExisteMobiliarioEnLista(MobiliarioResguardo Datos)
        {
            try
            {
                bool Band = false;
                foreach (MobiliarioResguardo Item in this.ListadeReguardo)
                {
                    if (Item.IDMobiliario == Datos.IDMobiliario)
                    {
                        Band = true;
                        break;
                    }
                }
                return Band;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int CandiadExistenciaRegistro(MobiliarioResguardo Datos)
        {
            try
            {
                int CantidadExistencia = 0;
                foreach (MobiliarioResguardo Item in this.ListadeReguardo)
                {
                    if (Item.IDMobiliario == Datos.IDMobiliario)
                    {
                         CantidadExistencia = Item.Cantidad;
                        break;
                    }
                }
                return CantidadExistencia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnAgregarMobiario_Click(object sender, EventArgs e)
        {
            try
            {
                frmMobiliaro_Resguardo_Nuevo Mobiliario = new frmMobiliaro_Resguardo_Nuevo();
                Mobiliario.ShowDialog();
                Mobiliario.Dispose();
                if (Mobiliario.DialogResult == DialogResult.OK)
                {
                    MobiliarioResguardo Aux = Mobiliario.DatosMoviliarioReguardos;
                    
                    if (!string.IsNullOrEmpty(Aux.IDMobiliario.Trim()))
                    {
                        if (!ExisteMobiliarioEnLista(Aux))
                        {
                            MobiliarioResguardo NuevoMobiliario = new MobiliarioResguardo { IDMobiliario = Aux.IDMobiliario, IDSucursal = Aux.IDSucursal, Codigo = Aux.Codigo, Descripcion = Aux.Descripcion, Marca = Aux.Marca, Modelo = Aux.Modelo, Cantidad = Aux.Cantidad };
                            this.ListadeReguardo.Add(NuevoMobiliario);
                            this.CargarGridMoviliario();
                        }
                        else
                        {
                            int Cantidad = Aux.Cantidad;
                            int CantidadExisten = Cantidad + CandiadExistenciaRegistro(Aux);
                            if (CantidadExisten <= Aux.Existencia)
                            {
                                foreach (MobiliarioResguardo item in ListadeReguardo)
                                {
                                    if (item.IDMobiliario == Aux.IDMobiliario)
                                    {
                                        item.Cantidad = CantidadExisten;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("No tienes suficente Mobiliario", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            this.CargarGridMoviliario();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevo_Mobiliario_Resguardo ~ btnAgregarMobiario_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitarMobiliario_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvMobiliario.SelectedRows.Count == 1)
                {
                    int RowToDelete = this.dgvMobiliario.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    this.ListadeReguardo.RemoveAt(RowToDelete);
                    this.CargarGridMoviliario();
                }
                else
                    MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevo_Mobiliario_Resguardo ~ btnQuitarMobiliario_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarResguardo_Click(object sender, EventArgs e)
        {
            try
            {
                List<Error> ListaErrores = this.ValidarDatos();
                if (ListaErrores.Count == 0)
                {
                    MobiliarioResguardo Datos = this.ObtenerDatosMobiliario();
                    MobiliarioResguardo_Negocio MRN = new MobiliarioResguardo_Negocio();
                    MRN.ACMobiliarioResguardo(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosMobiliarioResguardo = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                    this.MostrarMensajeError(ListaErrores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevo_Mobiliario_Resguardo ~ btnGuardarResguardo_Click");
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
                LogError.AddExcFileTxt(ex, "frmNuevo_Mobiliario_Resguardo ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevo_Mobiliario_Resguardo_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevo_Mobiliario_Resguardo ~ frmNuevo_Mobiliario_Resguardo_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSucursales_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbSucursales.SelectedIndex != -1)
                {
                    Sucursal DatosAux = this.ObtenerSucursalCombo();
                    if (!string.IsNullOrEmpty(DatosAux.IDSucursal))
                    {
                        this.IDSucursales = DatosAux.IDSucursal;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevo_Mobiliario_Resguardo ~ cmbSucursales_SelectedValueChanged");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
