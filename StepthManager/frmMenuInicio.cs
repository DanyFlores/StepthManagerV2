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
using System.Configuration;
using System.IO;
using CreativaSL.LibControls.WinForms;

namespace StephManager
{
    public partial class frmMenuInicio : Form
    {

        #region Contructor

        public frmMenuInicio()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ frmMenuInicio()");
            }
        }

        #endregion

        #region Eventos

        private void btnProductos_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Creativa btn = (Button_Creativa)sender;
                MenuStripProductos.Show(btn, btn.Width / 2, btn.Height);
                MenuStripProductos.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnProductos_Click");
            }
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmCatServicios Servicio = new frmCatServicios();
                Servicio.ShowDialog();
                Servicio.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnServicios_Click");
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmCatClientes cliente = new frmCatClientes();
                cliente.ShowDialog();
                cliente.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnClientes_Click");
            }
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Creativa btn = (Button_Creativa)sender;
                MenuStripPersonal.Show(btn, btn.Width / 2, btn.Height);
                MenuStripPersonal.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnEmpleados_Click");
            }
        }

        private void btnNomina_Click(object sender, EventArgs e)
        {
            try
            {
                frmNomina Nomina = new frmNomina();
                this.Visible = false;
                Nomina.ShowDialog();
                Nomina.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnNomina_Click");
            }
        }

        private void btnComisiones_Click(object sender, EventArgs e)
        {
            try
            {
                frmComisiones Comisiones = new frmComisiones();
                this.Visible = false;
                Comisiones.ShowDialog();
                Comisiones.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnComisiones_Click");
            }
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            try
            {
                frmPedidos Pedidos = new frmPedidos();
                this.Visible = false;
                Pedidos.ShowDialog();
                Pedidos.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnPedidos_Click");
            }
        }

        private void btnInventarios_Click(object sender, EventArgs e)
        {
            try
            {
                frmInventario Inventarios = new frmInventario();
                this.Visible = false;
                Inventarios.ShowDialog();
                Inventarios.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnInventarios_Click");
            }
        }

        private void btnCatalogos_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmCatalogos catalogos = new frmCatalogos();
                catalogos.ShowDialog();
                catalogos.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnCatalogos_Click");
            }
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            try
            {
                frmConfiguracion Configurar = new frmConfiguracion();
                this.Visible = false;
                Configurar.ShowDialog();
                this.Visible = true;
                Configurar.Dispose();
                if (Configurar.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show("Algunos datos de configuración han cambiado. El sistema se reiniciará.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnConfiguracion_Click");
            }
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            try
            {
                frmCitas Citas = new frmCitas();
                this.Visible = false;
                Citas.ShowDialog();
                Citas.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnCitas_Click");
            }
        }

        private void btnEncuestas_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmEncuestas Encuesta = new frmEncuestas();
                Encuesta.ShowDialog();
                Encuesta.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnEncuestas_Click");
            }
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmCapacitacionesCursos CapacitacionesCurso = new frmCapacitacionesCursos();
                CapacitacionesCurso.ShowDialog();
                CapacitacionesCurso.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnCursos_Click");
            }
        }

        private void btnVales_Click(object sender, EventArgs e)
        {
            try
            {
                frmVales Vales = new frmVales();
                this.Visible = false;
                Vales.ShowDialog();
                Vales.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnVales_Click");
            }
        }

        private void btnMobiliarios_Click(object sender, EventArgs e)
        {
            try
            {
                frmMobiliario Mobiliario = new frmMobiliario();
                this.Visible = false;
                Mobiliario.ShowDialog();
                Mobiliario.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnMobiliarios_Click");
            }
        }

        private void btnChecador_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmChecador Checador = new frmChecador();
                Checador.ShowDialog();
                Checador.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnChecador_Click");
            }
        }

        private void btnNotificaciones_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmNotificaciones Notificacion = new frmNotificaciones();
                Notificacion.ShowDialog();
                Notificacion.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnNotificaciones_Click");
            }
        }

        private void btnTarjetas_Click(object sender, EventArgs e)
        {
            try
            {
                frmCatTarjetas Tarjetas = new frmCatTarjetas();
                this.Visible = false;
                Tarjetas.ShowDialog();
                this.Visible = true;
                Tarjetas.Dispose();
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnTarjetas_Click");
            }
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            try
            {
                frmGastosXSucursal Compras = new frmGastosXSucursal();
                this.Visible = false;
                Compras.ShowDialog();
                Compras.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnGastos_Click");
            }
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            try
            {
                frmCompras Compras = new frmCompras();
                this.Visible = false;
                Compras.ShowDialog();                
                Compras.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnCompras_Click");
            }
        }

        private void btnCatalogoWeb_Click(object sender, EventArgs e)
        {
            try
            {
                frmCatalogoWeb Compras = new frmCatalogoWeb();
                this.Visible = false;
                Compras.ShowDialog();
                Compras.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnCatalogoWeb_Click");
            }
        }

        private void btnCheckList_Click(object sender, EventArgs e)
        {
            try
            {
                frmCheckList checkList = new frmCheckList();
                this.Visible = false;
                checkList.ShowDialog();
                checkList.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnCheckList_Click");
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
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnSalir_Click");
            }
        }

        private void frmMenuInicio_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
                this.IniciarForm();
            }

            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ frmMenuInicio_Load");
            }
        }

        #endregion

        private void IniciarForm()
        {
            try
            {
                this.PermisosUsuario();
                this.LlenarComboSucursal();
                if (!this.bgwProductos.IsBusy)
                    this.bgwProductos.RunWorkerAsync();
                if (!this.bgwIncidencias.IsBusy)
                    this.bgwIncidencias.RunWorkerAsync();
                if (!this.bgwVentas.IsBusy)
                    this.bgwVentas.RunWorkerAsync();
                //if (!string.IsNullOrEmpty(this.ObtenerSucursalCombo().IDSucursal))
                //{
                    if (!this.bgwOcupacion.IsBusy)
                        this.bgwOcupacion.RunWorkerAsync(this.ObtenerSucursalCombo().IDSucursal);
                //}
                Configuracion DatosAux = new Configuracion { Conexion = Comun.Conexion };
                Configuracion_Negocio CN = new Configuracion_Negocio();
                CN.EsFechaCorte(DatosAux);
                if (DatosAux.EsFechaCorte)
                {
                    this.lblMensajes.Text = "Ejecutando corte en tarjetas de monedero... No cierre el programa. Un cierre inesperado puede desencadenar inestabilidad en el sistema.";
                    this.bgwCorteTarjetas.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Permisos Usuario
        private void PermisosUsuario()
        {
            foreach (Control item in this.PanelMenu.Controls)
            {
                if (item is Button)
                {
                    Button Aux = (Button)item;
                    DataTable table = Comun.TablaPermisos;
                    DataRow[] PermisoUs;
                    string expression;
                    expression = "IDModulo=" + Aux.Tag;
                    PermisoUs = table.Select(expression);
                    if (PermisoUs.Length == 1)
                    {
                        bool Band;
                        DataRow Fila = PermisoUs[0];
                        bool.TryParse(Fila["Lectura"].ToString(), out Band);
                        if (Band)
                        {
                            Aux.Enabled = true;
                        }
                        else
                        {
                            Aux.Enabled = false;
                        }
                    }
                    else
                    {
                        if (!item.Name.Equals(btnSalir.Name))
                        {
                            Aux.Enabled = false;
                        }
                    }
                }
            }
        }
        #endregion

        //private void CargarGridProductosServicios()
        //{
        //    try
        //    {
        //        Home DatosAux = new Home { Conexion = Comun.Conexion };
        //        Home_Negocio HN = new Home_Negocio();
        //        HN.HomeGridProductosServicios(DatosAux);
        //        if (DatosAux.Completado)
        //        {
        //            this.dgvProductosServicios.AutoGenerateColumns = false;
        //            BindingSource Binding = new BindingSource();
        //            Binding.DataSource = DatosAux.TablaDatos;
        //            this.dgvProductosServicios.DataSource = Binding;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private void CargarGridIncidencias()
        //{
        //    try
        //    {
        //        Home DatosAux = new Home { Conexion = Comun.Conexion };
        //        Home_Negocio HN = new Home_Negocio();
        //        HN.HomeGridIncidencias(DatosAux);
        //        if (DatosAux.Completado)
        //        {
        //            this.dgvIncidencias.AutoGenerateColumns = false;
        //            BindingSource Binding = new BindingSource();
        //            Binding.DataSource = DatosAux.TablaDatos;
        //            this.dgvIncidencias.DataSource = Binding;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private void LlenarComboSucursal()
        {
            try
            {
                Sucursal DatosSuc = new Sucursal { Conexion = Comun.Conexion, Opcion = 1  };
                Sucursal_Negocio SN = new Sucursal_Negocio();
                this.cmbSucursales.DataSource = SN.LlenarComboCatSucursalesPuntoDeVenta(DatosSuc);
                this.cmbSucursales.DisplayMember = "NombreSucursal";
                this.cmbSucursales.ValueMember = "IDSucursal";
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
                    if (this.cmbSucursales.SelectedIndex != -1)
                        DatosAux = (Sucursal)this.cmbSucursales.SelectedItem;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cmbSucursales_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string IDSucursal = this.ObtenerSucursalCombo().IDSucursal;
                Home DatosAux = new Home { Conexion = Comun.Conexion, IDSucursal = IDSucursal };
                Home_Negocio HN = new Home_Negocio();
                HN.HomeGridOcupacion(DatosAux);
                this.dgvOcupacion.AutoGenerateColumns = false;
                BindingSource Binding = new BindingSource();
                Binding.DataSource = DatosAux.TablaDatos;
                this.dgvOcupacion.DataSource = Binding;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ cmbSucursales_SelectedValueChanged");
            }
        }

        private void TimerResumen_Tick(object sender, EventArgs e)
        {
            try
            {
                if(!this.bgwProductos.IsBusy)
                    this.bgwProductos.RunWorkerAsync();
                if(!this.bgwIncidencias.IsBusy)
                    this.bgwIncidencias.RunWorkerAsync();
                if (!this.bgwVentas.IsBusy)
                    this.bgwVentas.RunWorkerAsync();                
                if (!this.bgwOcupacion.IsBusy)
                    this.bgwOcupacion.RunWorkerAsync(this.ObtenerSucursalCombo().IDSucursal);
               
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ TimerResumen_Tick");
            }
        }

        #region Procesos en segundo plano

        private void bgwCorteTarjetas_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Configuracion DatosAux = new Configuracion { Conexion = Comun.Conexion };
                Configuracion_Negocio CN = new Configuracion_Negocio();
                DatosAux.IDUsuario = Comun.IDUsuario;
                CN.EjecutarCorte(DatosAux);
                if (!DatosAux.Completado)
                {
                    LogError.AddExcFileTxt(new Exception("Error al Ejecutar corte"), "frmMenuInicio ~ backgroundWorker1_DoWork");
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ backgroundWorker1_DoWork");
            }
        }

        private void bgwCorteTarjetas_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.lblMensajes.Text = "";
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ backgroundWorker1_RunWorkerCompleted");
            }
        }


        private void bgwProductos_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Home DatosAux = new Home { Conexion = Comun.Conexion };
                Home_Negocio HN = new Home_Negocio();
                HN.HomeGridProductosServicios(DatosAux);
                e.Result = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ bgwProductos_DoWork");
            }
        }

        private void bgwProductos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.dgvProductosServicios.AutoGenerateColumns = false;
                BindingSource Binding = new BindingSource();
                Binding.DataSource = (DataTable)e.Result;
                this.dgvProductosServicios.DataSource = Binding;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ bgwProductos_RunWorkerCompleted");
            }
        }

        private void bgwIncidencias_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Home DatosAux = new Home { Conexion = Comun.Conexion };
                Home_Negocio HN = new Home_Negocio();
                HN.HomeGridIncidencias(DatosAux);
                e.Result = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ bgwIncidencias_DoWork");
            }
        }

        private void bgwIncidencias_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.dgvIncidencias.AutoGenerateColumns = false;
                BindingSource Binding = new BindingSource();
                Binding.DataSource = (DataTable)e.Result;
                this.dgvIncidencias.DataSource = Binding;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ bgwIncidencias_RunWorkerCompleted");
            }
        }

        private void bgwOcupacion_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string IDSucursal = e.Argument.ToString();
                Home DatosAux = new Home { Conexion = Comun.Conexion,IDSucursal = IDSucursal };
                Home_Negocio HN = new Home_Negocio();
                HN.HomeGridOcupacion(DatosAux);
                e.Result = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ bgwOcupacion_DoWork");
            }
        }

        private void bgwOcupacion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    this.dgvOcupacion.AutoGenerateColumns = false;
                    BindingSource Binding = new BindingSource();
                    Binding.DataSource = (DataTable)e.Result;
                    this.dgvOcupacion.DataSource = Binding;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ bgwOcupacion_RunWorkerCompleted");
            }
        }

        private void bgwVentas_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Home DatosAux = new Home { Conexion = Comun.Conexion };
                Home_Negocio HN = new Home_Negocio();
                HN.HomeGridResumenVentas(DatosAux);
                e.Result = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ bgwVentas_DoWork");
            }
        }

        private void bgwVentas_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.dgvResumenVentas.AutoGenerateColumns = false;
                BindingSource Binding = new BindingSource();
                Binding.DataSource = (DataTable)e.Result;
                this.dgvResumenVentas.DataSource = Binding;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ bgwVentas_RunWorkerCompleted");
            }
        }


        private void cmbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    string IDSucursal = this.ObtenerSucursalCombo().IDSucursal;
            //    Home DatosAux = new Home { Conexion = Comun.Conexion };
            //    Home_Negocio HN = new Home_Negocio();
            //    HN.HomeGridOcupacion(DatosAux);
            //    this.dgvOcupacion.AutoGenerateColumns = false;
            //    BindingSource Binding = new BindingSource();
            //    Binding.DataSource = DatosAux.TablaDatos;
            //    this.dgvOcupacion.DataSource = Binding;
            //}
            //catch (Exception ex)
            //{
            //    LogError.AddExcFileTxt(ex, "frmMenuInicio ~ cmbSucursales_SelectedValueChanged");
            //}
        }

        private void NotificacionMinima_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmNotificacionesProdStockMinimo NPSMinimo = new frmNotificacionesProdStockMinimo();
                NPSMinimo.ShowDialog();
                NPSMinimo.Dispose();
                this.NotificacionMinima.Visible = false;
                this.Visible = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ NotificacionMinima_Click");
            }
        }

        private void NotificacionMaxima_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmNotificacionesProdStockMaximo NPSMaximo = new frmNotificacionesProdStockMaximo();
                NPSMaximo.ShowDialog();
                NPSMaximo.Dispose();
                this.NotificacionMaxima.Visible = false;
                this.Visible = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ NotificacionMaxima_Click");
            }
        }

        private void bgwNotificaciones_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                NotificacionesSistemas NS = new NotificacionesSistemas();
                NS.Conexion = Comun.Conexion;
                NS.IDSucursal = Comun.IDSucursalCaja;
                NotificacionesSistemas_Negocio NSN = new NotificacionesSistemas_Negocio();
                NSN.ObtenerNotificaciones(NS);
                Comun.TablaNotificaciones = NS.TablaNotificaciones;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ bgwNotificaciones_DoWork");
            }
        }

        private void bgwNotificaciones_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (Comun.TablaNotificaciones != null)
                {
                    foreach (DataRow auxNotificacion in Comun.TablaNotificaciones.Rows)
                    {
                        if (Convert.ToInt32(auxNotificacion["IDTipoNotificacion"]) == 1)
                        {
                            this.NotificacionMinima.Visible = true;
                        }
                        else if (Convert.ToInt32(auxNotificacion["IDTipoNotificacion"]) == 2)
                        {
                            this.NotificacionMaxima.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ bgwNotificaciones_RunWorkerCompleted");
            }
        }

        private void TimerNotificaciones_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!this.bgwNotificaciones.IsBusy)
                    this.bgwNotificaciones.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ TimerNotificaciones_Tick");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmVerListados Reporte = new frmVerListados(5, string.Empty);
            Reporte.ShowDialog();
            Reporte.Dispose();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                if (Comun.CajaAbierta)
                {
                    Button_Creativa btn = (Button_Creativa)sender;
                    MenuStripReportes.Show(btn, btn.Width / 2, btn.Height);
                    MenuStripReportes.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ btnReporte_Click");
            }
        }

        #endregion

        #region Eventos Clic Reportes

        private void toolsm_TrabajosRealizados_Click(object sender, EventArgs e)
        {
            try
            {
                frmReporteTrabajosRealizados tr = new frmReporteTrabajosRealizados();
                tr.ShowDialog();
                tr.Dispose();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsm_TrabajosRealizados_Click");
            }
        }

        private void toolsm_ConsumoMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportesConsumoMaterial VerReporte = new frmReportesConsumoMaterial();
                VerReporte.ShowDialog();
                VerReporte.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsm_ConsumoMaterial_Click");
            }
        }

        private void toolsm_Garantias_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportesGarantias VerReporte = new frmReportesGarantias();
                VerReporte.ShowDialog();
                VerReporte.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsm_Garantias_Click");
            }
        }

        private void toolsm_Mobiliario_Click(object sender, EventArgs e)
        {
            try
            {
                frmVerReporteMobiliarioXSucursal Reporte = new frmVerReporteMobiliarioXSucursal();
                Reporte.ShowDialog();
                Reporte.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsm_Mobiliario_Click");
            }
        }

        private void toolsm_Clientes_Click(object sender, EventArgs e)
        {
            try
            {
                frmReporteComprasCliente VerReporte = new frmReporteComprasCliente();
                VerReporte.ShowDialog();
                VerReporte.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsm_Clientes_Click");
            }
        }

        private void toolsm_ProductosVendidos_Click(object sender, EventArgs e)
        {
            try
            {
                frmReportesProductosVendidos GenerarReporte = new frmReportesProductosVendidos();
                GenerarReporte.ShowDialog();
                GenerarReporte.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsm_ProductosVendidos_Click");
            }
        }

        private void toolsm_TiempoServicios_Click(object sender, EventArgs e)
        {
            try
            {
                frmVerReporteTiempoServicio GenerarReporte = new frmVerReporteTiempoServicio();
                GenerarReporte.ShowDialog();
                GenerarReporte.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsm_TiempoServicios_Click");
            }
        }

        private void toolsm_ComprasProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                //....
                this.Visible = false;
                frmReportesComprasPorProveedor Reporte = new frmReportesComprasPorProveedor();
                Reporte.ShowDialog();
                Reporte.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsm_ComprasProveedor_Click");
            }
        }

        private void toolsm_Faltas_Click(object sender, EventArgs e)
        {
            try
            {
                //Aqui se abre el formulario de Faltas grid
                this.Visible = false;
                frmReportesFaltas Reporte = new frmReportesFaltas();
                Reporte.ShowDialog();
                Reporte.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsm_Faltas_Click");
            }
        }

        private void toolsm_Monedero_Click(object sender, EventArgs e)
        {
            try
            {
                frmReporteMonedero tr = new frmReporteMonedero();
                tr.ShowDialog();
                tr.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsm_Monedero_Click");
            }
        }


        private void toolsm_EstadoResultados_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmReporteEstadoResultados EstadoResult = new frmReporteEstadoResultados();
                EstadoResult.ShowDialog();
                EstadoResult.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsm_EstadoResultados_Click");
            }
        }

        #endregion

        private void ventasPorSucursalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmReporteVentasXSucursal Reporte = new frmReporteVentasXSucursal();
                Reporte.ShowDialog();
                Reporte.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ ventasPorSucursalToolStripMenuItem_Click");
            }
        }
        

        private void transferenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Aqui se abre el formulario de Transferencia
                this.Visible = false;
                frmTransferenciaMateriales TM = new frmTransferenciaMateriales();
                TM.ShowDialog();
                TM.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ transferenciaToolStripMenuItem_Click");
            }
        }


        #region Menú Productos

        private void toolsmProductos_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmCatProductos producto = new frmCatProductos();
                producto.ShowDialog();
                producto.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsmProductos_Click");
            }
        }

        private void toolsmServicios_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmCatServicios Servicio = new frmCatServicios();
                Servicio.ShowDialog();
                Servicio.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsmServicios_Click");
            }
        }

        private void toolsmTarjetasRegalo_Click(object sender, EventArgs e)
        {
            try
            {
                frmCatTarjetas Tarjetas = new frmCatTarjetas();
                this.Visible = false;
                Tarjetas.ShowDialog();
                this.Visible = true;
                Tarjetas.Dispose();
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsmTarjetasRegalo_Click");
            }
        }

        private void toolsmPromociones_Click(object sender, EventArgs e)
        {
            try
            {
                frmPromociones Promociones = new frmPromociones();
                this.Visible = false;
                Promociones.ShowDialog();
                this.Visible = true;
                Promociones.Dispose();
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsmPromociones_Click");
            }
        }

        #endregion

        #region Menú Personal

        private void toolsmEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmCatEmpleado Empleado = new frmCatEmpleado();
                Empleado.ShowDialog();
                Empleado.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsmEmpleados_Click");
            }
        }

        private void toolsmChecador_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmChecador Checador = new frmChecador();
                Checador.ShowDialog();
                Checador.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsmChecador_Click");
            }
        }

        private void toolsmComisiones_Click(object sender, EventArgs e)
        {
            try
            {
                frmComisiones Comisiones = new frmComisiones();
                this.Visible = false;
                Comisiones.ShowDialog();
                Comisiones.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsmComisiones_Click");
            }
        }

        private void toolsmCapacitacion_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmCapacitacionesCursos CapacitacionesCurso = new frmCapacitacionesCursos();
                CapacitacionesCurso.ShowDialog();
                CapacitacionesCurso.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMenuInicio ~ toolsmCapacitacion_Click");
            }
        }

        #endregion

    }
}
