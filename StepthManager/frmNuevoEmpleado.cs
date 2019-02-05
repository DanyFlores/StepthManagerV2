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
    public partial class frmNuevoEmpleado : Form
    {
        #region Propiedades / Variables
        private int TipoForm = 0;
        private Usuario _DatosUsuario;
        public Usuario DatosUsuario
        {
            get { return _DatosUsuario; }
            set { _DatosUsuario = value; }
        }
        private List<Sucursal> ListaSucursales = new List<Sucursal>();
        private List<Sucursal> SucursalesXUsuario = new List<Sucursal>();

       // private TarjetaMonedero DatosTarjeta = new TarjetaMonedero { IDTarjeta = string.Empty, Folio = string.Empty };
        #endregion

        #region Constructor

        public frmNuevoEmpleado()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoEmpleado ~ frmNuevoEmpleado()");
            }
        }

        public frmNuevoEmpleado(Usuario Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosUsuario = Datos;
                this.TipoForm = 2;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoEmpleado ~ frmNuevoEmpleado(Usuario Datos)");
            }
        }

        #endregion

        private void AgregarItemAListaSucursal(Sucursal Item)
        {
            try
            {
                this.ListaSucursales.Add(Item);
                this.ListaSucursales = this.ListaSucursales.OrderBy(x => x.NombreSucursal).ToList<Sucursal>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AgregarItemAListaSucursalSeleccionada(Sucursal Item)
        {
            try
            {
                this.SucursalesXUsuario.Add(Item);
                this.SucursalesXUsuario = this.SucursalesXUsuario.OrderBy(x => x.NombreSucursal).ToList<Sucursal>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Métodos

        private void CargarDatosAModificar(Usuario Datos)
        {
            try
            {
                this.txtNombre.Text = Datos.Nombre;
                this.txtApellidoPat.Text = Datos.ApellidoPat;
                this.txtApellidoMat.Text = Datos.ApellidoMat;
                this.txtCalle.Text = Datos.DirCalle;
                this.txtColonia.Text = Datos.DirColonia;
                this.txtNumero.Text = Datos.DirNumero;
                if (ExisteItemEnComboTipoUsuario(Datos.IDTipoUsuario))
                    this.cmbTipoUsuario.SelectedValue = Datos.IDTipoUsuario;
                if (ExisteItemEnComboPuestos(Datos.IDPuesto))
                    this.cmbCatPuesto.SelectedValue = Datos.IDPuesto;
                if (ExisteItemEnComboCategoriaPuesto(Datos.IDCategoriaPuesto))
                    this.cmbCategoriaPuesto.SelectedValue = Datos.IDCategoriaPuesto;
                this.ObtenerListaEmpleado(this._DatosUsuario.IDEmpleado);
                this.ObtenerTablaEmpleadosSucursal(this._DatosUsuario.IDEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GenerarTablaSucursales()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla.Columns.Add("IDSucursal", typeof(string));
               //Tabla.Columns.Add("NombreSucu", typeof(string));
                foreach (DataGridViewRow Fila in this.dgvSucursal.Rows)
                {
                   // string IDUsuario = Fila.Cells["IDUsuario"].Value.ToString();
                    string IDSucursal = Fila.Cells["IDSucursal"].Value.ToString();
                    Tabla.Rows.Add(new object[] { IDSucursal });
                }
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExisteItemEnComboCategoriaPuesto(string ID)
        {
            try
            {
                foreach (CategoriasPuesto Item in this.cmbCategoriaPuesto.Items)
                {
                    if (Item.IDCategoria == ID)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExisteItemEnComboTipoUsuario(int ID)
        {
            try
            {
                int Aux = 0;
                foreach (DataRowView fila in this.cmbTipoUsuario.Items)
                {
                    int.TryParse(fila["id_tipoUsuario"].ToString(), out Aux);
                    if (Aux == ID)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExisteItemEnComboPuestos(int ID)
        {
            try
            {
                foreach (Puestos Item in this.cmbCatPuesto.Items)
                {
                    if (Item.IDPuesto == ID)
                        return true;
                }
                return false;
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
                this.LlenarComboCatTipoUsuario();
                this.LlenarComboCatPuestos();
                if (TipoForm == 1)
                    this.InicializarCampos();
                else
                    this.CargarDatosAModificar(_DatosUsuario);
                this.LlenarTablaSucursales();
                this.ActiveControl = this.txtNombre;
                this.txtNombre.Focus();
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

        private void InicializarCampos()
        {
            try
            {
                
                this.txtNombre.Text = string.Empty;
                this.txtApellidoPat.Text = string.Empty;
                this.txtApellidoMat.Text = string.Empty;
                this.txtCalle.Text = string.Empty;
                this.txtColonia.Text = string.Empty;
                this.txtNumero.Text = string.Empty;
                this.ObtenerListaEmpleado(string.Empty);
                this.ObtenerTablaEmpleadosSucursal(string.Empty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboCatCategoriasPuesto(int IDPuesto)
        {
            try
            {
                CategoriasPuesto DatosAux = new CategoriasPuesto { Conexion = Comun.Conexion, IDPuesto = IDPuesto, IncluirSelect = true };
                Catalogo_Negocio CN = new Catalogo_Negocio();
                this.cmbCategoriaPuesto.DataSource = CN.ObtenerComboCatCategorias(DatosAux);
                this.cmbCategoriaPuesto.DisplayMember = "Descripcion";
                this.cmbCategoriaPuesto.ValueMember = "IDCategoria";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboCatPuestos()
        {
            try
            {
                Puestos DatosAux = new Puestos { Conexion = Comun.Conexion, IncluirSelect = true };
                Catalogo_Negocio CN = new Catalogo_Negocio();
                this.cmbCatPuesto.DataSource = CN.ObtenerComboCatPuestos(DatosAux);
                this.cmbCatPuesto.DisplayMember = "Descripcion";
                this.cmbCatPuesto.ValueMember = "IDPuesto";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboCatTipoUsuario()
        {
            try
            {
                TipoUsuario DatosAux = new TipoUsuario();//{ Opcion = 2, Conexion = Comun.Conexion };
                Usuario_Negocio UN = new Usuario_Negocio();
                DatosAux.Conexion = Comun.Conexion;
                UN.ObtenerComboCatTipoUsuario(DatosAux);
                this.cmbTipoUsuario.DisplayMember = "descripcion";
                this.cmbTipoUsuario.ValueMember = "id_tipoUsuario";
                this.cmbTipoUsuario.DataSource = DatosAux.TablaDatos;
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
                DatosAux.IDEmpleado = TipoForm == 2 ? this._DatosUsuario.IDEmpleado : string.Empty;
                DatosAux.IDTipoUsuario = Convert.ToInt32(this.cmbTipoUsuario.SelectedValue);
                DatosAux.IDPuesto = Convert.ToInt32(this.cmbCatPuesto.SelectedValue);
                DatosAux.IDCategoriaPuesto = this.cmbCategoriaPuesto.SelectedValue.ToString();
                DatosAux.Nombre = this.txtNombre.Text.Trim();
                DatosAux.ApellidoPat = this.txtApellidoPat.Text.Trim();
                DatosAux.ApellidoMat = this.txtApellidoMat.Text.Trim();
                DatosAux.DirCalle = this.txtCalle.Text.Trim();
                DatosAux.DirColonia = this.txtColonia.Text.Trim();
                DatosAux.DirNumero = this.txtNumero.Text.Trim();
                DatosAux.Opcion = this.TipoForm;
                DatosAux.TablaUsuarioSucursal = this.GenerarTablaSucursales();
                DatosAux.IDSucursalActual = this.ObtenerDatosSucursalesSeleccionado(this.dgvSucursal.Rows.GetFirstRow(DataGridViewElementStates.Selected)).IDSucursal;
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
                int Aux = 0, ID = 0;
                if (string.IsNullOrEmpty(this.txtNombre.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un nombre del usuario.", ControlSender = this.txtNombre });
                else
                {
                    if (!Validar.IsValidName(this.txtNombre.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un nombre del usuario válido.", ControlSender = this.txtNombre });
                }
                if (string.IsNullOrEmpty(this.txtApellidoPat.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar el apellido paterno del usuario.", ControlSender = this.txtApellidoPat });
                else
                {
                    if (!Validar.IsValidName(this.txtApellidoPat.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un apellido paterno del usuario válido.", ControlSender = this.txtApellidoPat });
                }
                if (string.IsNullOrEmpty(this.txtApellidoMat.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar el apellido materno del usuario.", ControlSender = this.txtApellidoMat });
                else
                {
                    if (!Validar.IsValidName(this.txtApellidoMat.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un apellido materno del usuario válido.", ControlSender = this.txtApellidoMat });
                }
                //Validar Combo Tipo Usuario
                if (this.cmbTipoUsuario.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción en Tipo de Usuario", ControlSender = this.cmbTipoUsuario });
                else
                {
                    int.TryParse(this.cmbTipoUsuario.SelectedValue.ToString(), out ID);
                    if (ID == 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción en Tipo de Usuario.", ControlSender = this.cmbTipoUsuario });
                }
                //Validar Combo Puestos
                if (this.cmbCatPuesto.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción en Puesto", ControlSender = this.cmbCatPuesto });
                else
                {
                    int.TryParse(this.cmbCatPuesto.SelectedValue.ToString(), out ID);
                    if (ID == 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción en Puesto.", ControlSender = this.cmbCatPuesto });
                }
                //Validar Combo Categorias
                if (this.cmbCategoriaPuesto.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción en Categoría del puesto", ControlSender = this.cmbCategoriaPuesto });
                else
                {
                    CategoriasPuesto AuxCat = (CategoriasPuesto)this.cmbCategoriaPuesto.SelectedItem;
                    if(string.IsNullOrEmpty(AuxCat.IDCategoria.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción en Categoría del puesto", ControlSender = this.cmbCategoriaPuesto });
                }
                if (!string.IsNullOrEmpty(this.txtCalle.Text.Trim()))                    
                {
                    if (!Validar.IsValidDescripcion(this.txtCalle.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un dato válido para <<Calle>>.", ControlSender = this.txtCalle });
                }
                if (!string.IsNullOrEmpty(this.txtColonia.Text.Trim()))
                {
                    if (!Validar.IsValidDescripcion(this.txtColonia.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un dato válido para <<Colonia>>.", ControlSender = this.txtColonia });
                }
                if (!string.IsNullOrEmpty(this.txtNumero.Text.Trim()))
                {
                    if (!Validar.IsValidOnlyNumber(this.txtNumero.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un dato válido para <<Número>>.", ControlSender = this.txtNumero });
                }
                if (this.dgvSucursal.SelectedRows.Count != 1)
                {
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione la sucursal actual del usuario.", ControlSender = this.txtNumero });
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
                LogError.AddExcFileTxt(ex, "frmNuevoEmpleado ~ btnCancelar_Click");
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
                    Usuario Datos = this.ObtenerDatos();
                    Usuario_Negocio CN = new Usuario_Negocio();
                    CN.ABCUsuario(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosUsuario = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (Datos.Resultado > 0)
                        {
                            List<Error> LstError = new List<Error>();
                            LstError.Add(new Error { Numero = 1, Descripcion = Datos.MensajeError, ControlSender = this });
                            this.MostrarMensajeError(LstError);
                        }
                        else
                            MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoEmpleado ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCategoriaPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                decimal SueldoBase = 0;
                if (this.cmbCategoriaPuesto.Items.Count > 0)
                {
                    if (this.cmbCategoriaPuesto.SelectedIndex != -1)
                    {
                        CategoriasPuesto Item = (CategoriasPuesto)this.cmbCategoriaPuesto.SelectedItem;
                        SueldoBase = Item.SueldoBase;
                    }
                }
                this.txtSueldoBase.Text = string.Format("{0:c}", SueldoBase);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoEmpleado ~ cmbCategoriaPuesto_SelectedIndexChanged");
            }
        }

        private void cmbCategoriaPuesto_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.cmbCategoriaPuesto.SelectedIndex == -1)
                    this.txtSueldoBase.Text = string.Format("{0:c}", 0);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoEmpleado ~ cmbCategoriaPuesto_Validating");
            }
        }

        private void cmbCatPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbCatPuesto.Items.Count > 0)
                {
                    if (this.cmbCatPuesto.SelectedIndex != -1)
                    {
                        Puestos Aux = (Puestos)this.cmbCatPuesto.SelectedItem;
                        this.LlenarComboCatCategoriasPuesto(Aux.IDPuesto);
                    }
                    else
                        this.LlenarComboCatCategoriasPuesto(0);
                }
                else
                    this.LlenarComboCatCategoriasPuesto(0);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoEmpleado ~ cmbCatPuesto_SelectedIndexChanged");
            }
        }

        private void cmbCatPuesto_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.cmbCatPuesto.SelectedIndex == -1)
                    this.LlenarComboCatCategoriasPuesto(0);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoEmpleado ~ cmbCatPuesto_Validating");
            }
        }

        private void frmNuevoUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoEmpleado ~ frmNuevoUsuario_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnAgregarSucursal_Click(object sender, EventArgs e)
        {
            try
            {
                frmElegirSucursal ElegirSucursal = new frmElegirSucursal();
                ElegirSucursal.DatosActuales = this.ListaSucursales;
                ElegirSucursal.ShowDialog();
                ElegirSucursal.Dispose();
                if (ElegirSucursal.DialogResult == DialogResult.OK)
                {
                    Sucursal ProvElegido = ElegirSucursal.Seleccionado;
                    this.QuitarItemAListaSucursal(ProvElegido.IDSucursal);
                    //ProvElegido.CostoUltimo = 0;
                    //ProvElegido.IDProductoXProveedor = string.Empty;
                    this.AgregarItemAListaSucursalSeleccionada(ProvElegido);
                    this.LlenarTablaSucursales();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoEmpleado ~ btnAgregarSucursal_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerListaEmpleado(string IDEmpleado)
        {
            try
            {
                Usuario DatosAux = new Usuario { Conexion = Comun.Conexion, IDEmpleado = IDEmpleado };
                Usuario_Negocio ProdNeg = new Usuario_Negocio();
                this.ListaSucursales = ProdNeg.ObtenerSucursales(DatosAux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void QuitarItemAListaSucursal(string IDEmpleado)
        {
            try
            {
                Sucursal Seleccionado = new Sucursal();
                foreach (Sucursal ItemAux in this.ListaSucursales)
                {
                    if (ItemAux.IDSucursal == IDEmpleado)
                    {
                        Seleccionado = ItemAux;
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(Seleccionado.IDSucursal))
                    this.ListaSucursales.Remove(Seleccionado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void QuitarItemAListaSucursalesSeleccionado(string IDEmplado)
        {
            try
            {
                Sucursal Seleccionado = new Sucursal();
                foreach (Sucursal ItemAux in this.SucursalesXUsuario)
                {
                    if (ItemAux.IDSucursal == IDEmplado)
                    {
                        Seleccionado = ItemAux;
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(Seleccionado.IDSucursal))
                    this.SucursalesXUsuario.Remove(Seleccionado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarTablaSucursales()
        {
            try
            {
                this.dgvSucursal.DataSource = null;
                this.dgvSucursal.AutoGenerateColumns = false;
                this.dgvSucursal.DataSource = SucursalesXUsuario;
                for (int i = 0; i < this.dgvSucursal.Rows.Count; i++)
                {
                    Sucursal Aux = this.ObtenerDatosSucursalesSeleccionado(i);
                    if (this.TipoForm == 2)
                    {
                        if (Aux.IDSucursal == this._DatosUsuario.IDSucursalActual)
                        {
                            this.dgvSucursal.Rows[i].Selected = true;
                        }
                        else
                            this.dgvSucursal.Rows[i].Selected = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Sucursal ObtenerDatosSucursalesSeleccionado(int Row)
        {
            try
            {
                Sucursal DatosAux = new Sucursal();
                DatosAux.IDSucursal = this.dgvSucursal.Rows[Row].Cells["IDSucursal"].Value.ToString();
                DatosAux.NombreSucursal = this.dgvSucursal.Rows[Row].Cells["NombreSucursal"].Value.ToString();
              //  DatosAux.IDProductoXProveedor = this.dgvProveedor.Rows[Row].Cells["IDProductoXProveedor"].Value.ToString();
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnEliminarSucursal_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvSucursal.SelectedRows.Count > 0)
                {
                    Int32 RowToDelete = this.dgvSucursal.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowToDelete > -1)
                    {
                        Sucursal ItemSeleccionado = this.ObtenerDatosSucursalesSeleccionado(RowToDelete);
                        this.QuitarItemAListaSucursalesSeleccionado(ItemSeleccionado.IDSucursal);
                        this.AgregarItemAListaSucursal(ItemSeleccionado);
                        this.LlenarTablaSucursales();
                        //this.dgvProveedor.Rows.RemoveAt(RowToDelete);
                    }
                }
                else
                    MessageBox.Show("Seleccione la fila del registro a eliminar.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoEmpleado ~ btnbEliminarProveedor_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerTablaEmpleadosSucursal(string IDEmpleado)
        {
            try
            {
                Usuario DatosAux = new Usuario { Conexion = Comun.Conexion, IDEmpleado = IDEmpleado };
                Usuario_Negocio ProdNeg = new Usuario_Negocio();
                this.SucursalesXUsuario = ProdNeg.ObtenerSucursalXIDEmpleado(DatosAux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
