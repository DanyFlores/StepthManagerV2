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
using CreativaSL.LibControls.WinForms;
using StephManager.ClasesAux;
using CreativaSL.Dll.Validaciones;
using System.IO;

namespace StephManager
{
    public partial class frmNuevoProveedor : Form
    {
        #region Propiedades / Variables
        private int TipoForm = 0;
        private Proveedor _DatosProveedor;
        public Proveedor DatosProveedor
        {
            get { return _DatosProveedor; }
            set { _DatosProveedor = value; }
        }        
        #endregion

        #region Constructor

        public frmNuevoProveedor()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProveedor ~ frmNuevoProveedor()");
            }
        }

        public frmNuevoProveedor(Proveedor Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosProveedor = Datos;
                this.TipoForm = 2;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProveedor ~ frmNuevoProveedor(Proveedor Datos)");
            }
        }

        #endregion

        #region Métodos

        private void CargarCombos()
        {
            try
            {
                Catalogo_Negocio Catalogos_negocio = new Catalogo_Negocio();
                CatPais pais = new CatPais();
                pais.Conexion = Comun.Conexion;
                Catalogos_negocio.ObtenerComboCatPais(pais);
                this.cmbPais.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbPais.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmbPais.DataSource = pais.TablaDatos;
                this.cmbPais.DisplayMember = "descripcion";
                this.cmbPais.ValueMember = "id_pais";
                if (this.ExisteItemEnComboPais(143))
                    this.cmbPais.SelectedValue = 143;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LlenarComboCatEstadoXIDPais(int IDPais)
        {
            try
            {
                CatEstado Estado = new CatEstado();
                Estado.Conexion = Comun.Conexion;
                Estado.IDPais = IDPais;
                //Comun.IDPais = Estado.IDPais;
                Catalogo_Negocio Catalogos_negocio = new Catalogo_Negocio();
                Catalogos_negocio.ObtenerComboCatEstados(Estado);

                this.cmbEstado.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbEstado.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmbEstado.DataSource = Estado.TablaDatos;
                this.cmbEstado.DisplayMember = "descripcion";
                this.cmbEstado.ValueMember = "id_estado";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LlenarComboCatMunicipioXIDEstado(int IDPais, int IDEstado)
        {
            try
            {
                CatMunicipio Municipio = new CatMunicipio();
                Municipio.Conexion = Comun.Conexion;
                Municipio.IDPais = IDPais;
                Municipio.IDEstado = IDEstado;
                Catalogo_Negocio Catalogos_negocio = new Catalogo_Negocio();
                Catalogos_negocio.ObtenerComboCatMunicipio(Municipio);

                this.cmbMunicipio.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbMunicipio.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmbMunicipio.DataSource = Municipio.TablaDatos;
                this.cmbMunicipio.DisplayMember = "descripcion";
                this.cmbMunicipio.ValueMember = "id_municipio";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool ExisteItemEnComboPais(int ID)
        {
            try
            {
                int Aux = 0;
                foreach (DataRowView fila in this.cmbPais.Items)
                {
                    int.TryParse(fila["id_pais"].ToString(), out Aux);
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
        private bool ExisteItemEnComboEstado(int ID)
        {
            try
            {
                int Aux = 0;
                foreach (DataRowView fila in this.cmbEstado.Items)
                {
                    int.TryParse(fila["id_estado"].ToString(), out Aux);
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
        private bool ExisteItemEnComboMunicipio(int ID)
        {
            try
            {
                int Aux = 0;
                foreach (DataRowView fila in this.cmbMunicipio.Items)
                {
                    int.TryParse(fila["id_municipio"].ToString(), out Aux);
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

        private void CargarDatosAModificar(Proveedor Datos)
        {
            try
            {
                this.txtRazonSocial.Text = Datos.RazonSocial;
                this.txtNombreComercial.Text = Datos.NombreComercial;
                this.txtRegimenFiscal.Text = Datos.RegimenFiscal;
                this.txtRFC.Text = Datos.RFC;
                this.txtRepresentante.Text = Datos.Representante;
                this.txtCorreo.Text = Datos.Correo;
                this.txtTelefono.Text = Datos.Telefono;
                this.txtCalle.Text = Datos.DirCalle;
                this.txtColonia.Text = Datos.DirColonia;
                this.txtNumeroCasa.Text = Datos.DirNumero;
                this.chkMobiliario.Checked = Datos.Mobiliario;
                this.txtCodigoPostal.Text = Datos.CodigoPostal;
                if (ExisteItemEnComboPais(Datos.IDPais))
                    this.cmbPais.SelectedValue = Datos.IDPais;
                if (ExisteItemEnComboEstado(Datos.IDEstado))
                    this.cmbEstado.SelectedValue = Datos.IDEstado;
                if (ExisteItemEnComboMunicipio(Datos.IDMunicipio))
                    this.cmbMunicipio.SelectedValue = Datos.IDMunicipio;
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
                this.CargarCombos();
                if(TipoForm == 2)
                    this.CargarDatosAModificar(_DatosProveedor);
                this.ActiveControl = this.txtRazonSocial;
                this.txtRazonSocial.Focus();
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

        private Proveedor ObtenerDatos()
        {
            try
            {
                Proveedor DatosAux = new Proveedor();
                DatosAux.IDProveedor = TipoForm == 2 ? this._DatosProveedor.IDProveedor : string.Empty;
                DatosAux.RazonSocial = this.txtRazonSocial.Text.Trim();
                DatosAux.NombreComercial = this.txtNombreComercial.Text.Trim();
                DatosAux.RegimenFiscal = this.txtRegimenFiscal.Text.Trim();
                DatosAux.RFC = this.txtRFC.Text.Trim();
                DatosAux.Representante = this.txtRepresentante.Text.Trim();
                DatosAux.Correo = this.txtCorreo.Text.Trim();
                DatosAux.Telefono = this.txtTelefono.Text.Trim();
                DatosAux.DirCalle = this.txtCalle.Text.Trim();
                DatosAux.DirColonia = this.txtColonia.Text.Trim();
                DatosAux.DirNumero = this.txtNumeroCasa.Text.Trim();
                DatosAux.IDEstado = Convert.ToInt32(this.cmbEstado.SelectedValue);
                DatosAux.IDMunicipio = Convert.ToInt32(this.cmbMunicipio.SelectedValue);
                DatosAux.IDPais = Convert.ToInt32(this.cmbPais.SelectedValue);
                DatosAux.CodigoPostal = this.txtCodigoPostal.Text.Trim();
                DatosAux.Mobiliario = this.chkMobiliario.Checked;
                DatosAux.Opcion = this.TipoForm;
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
                int Aux = 0;
                //Validar Razon Social del Proveedor
                if (string.IsNullOrEmpty(this.txtRazonSocial.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la razón social del proveedor.", ControlSender = this.txtRazonSocial });
                else
                {
                    if(!Validar.IsValidDescripcion(this.txtRazonSocial.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese una razón social válida.", ControlSender = this.txtRazonSocial });
                }
                //Validar Nombre Comercial del Proveedor
                if (string.IsNullOrEmpty(this.txtNombreComercial.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el nombre comercial del proveedor.", ControlSender = this.txtNombreComercial });
                else
                {
                    if (!Validar.IsValidDescripcion(this.txtNombreComercial.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un nombre comercial válido.", ControlSender = this.txtNombreComercial });
                }
                //Validar Regimen Fiscal del Proveedor
                if (string.IsNullOrEmpty(this.txtRegimenFiscal.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el regimen fiscal del proveedor.", ControlSender = this.txtRegimenFiscal });
                else
                {
                    if (!Validar.IsValidDescripcion(this.txtRegimenFiscal.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un regimen fiscal válido.", ControlSender = this.txtRegimenFiscal });
                }
                //Validar RFC del Proveedor
                if (string.IsNullOrEmpty(this.txtRFC.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el RFC del proveedor.", ControlSender = this.txtRFC });
                else
                {
                    if (!Validar.IsValidRFC(this.txtRFC.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un RFC válido.", ControlSender = this.txtRFC });
                }
                //if (string.IsNullOrEmpty(this.txtRepresentante.Text.Trim()))
                //    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el nombre del agente de ventas.", ControlSender = this.txtRepresentante });
                //Validar Representante del Proveedor
                if (!string.IsNullOrEmpty(this.txtRepresentante.Text.Trim()))
                    if (!Validar.IsValidName(this.txtRepresentante.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un nombre válido.", ControlSender = this.txtRepresentante });

                //Validar Correo del Proveedor
                if(!string.IsNullOrEmpty(this.txtCorreo.Text.Trim()))
                    if (!Validar.IsValidMail(this.txtCorreo.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un correo válido.", ControlSender = this.txtCorreo });

                //Validar Numero Telefono del Proveedor
                if (!string.IsNullOrEmpty(this.txtTelefono.Text.Trim()))
                    if (!Validar.IsValidPhoneNumber(this.txtTelefono.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un número telefónico válido.", ControlSender = this.txtTelefono });

                //Validar Calle del Proveedor
                if (!string.IsNullOrEmpty(this.txtCalle.Text.Trim()))
                    if (!Validar.IsValidDescripcion(this.txtCalle.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la calle válida.", ControlSender = this.txtCalle });

                //Validar Colonia del Proveedor
                if (!string.IsNullOrEmpty(this.txtColonia.Text.Trim()))
                    if (!Validar.IsValidDescripcion(this.txtColonia.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la Colonia válida.", ControlSender = this.txtColonia });

                //Validar Numero de Casa del Proveedor
                if (!string.IsNullOrEmpty(this.txtNumeroCasa.Text.Trim()))
                    if (!Validar.IsValidOnlyNumber(this.txtNumeroCasa.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la Colonia válida.", ControlSender = this.txtNumeroCasa });

                //Validar Codigo Postal del Proveedor
                if (!string.IsNullOrEmpty(this.txtCodigoPostal.Text.Trim()))
                    if (!Validar.IsValidZipCode(this.txtCodigoPostal.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el código postal válida.", ControlSender = this.txtCodigoPostal });

                //Validar Combo Pais del Proveedor
                if (this.cmbPais.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar el Pais de la lista.", ControlSender = this.cmbPais });
                else
                {
                    int IDPais = 0;
                    int.TryParse(this.cmbPais.SelectedValue.ToString(), out IDPais);
                    if (IDPais == 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar el Pais de la lista.", ControlSender = this.cmbPais });
                }
                //Validar Combo Estados del Proveedor
                if (this.cmbEstado.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar el Estado de la lista.", ControlSender = this.cmbEstado });
                else
                {
                    int IDEstado = 0;
                    int.TryParse(this.cmbEstado.SelectedValue.ToString(), out IDEstado);
                    if (IDEstado == 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar el Estado de la lista.", ControlSender = this.cmbEstado });
                }
                //Validar Combo Municipio del Proveedor
                if (this.cmbMunicipio.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar el Municipio de la lista.", ControlSender = this.cmbMunicipio });
                else
                {
                    int IDMunicipio = 0;
                    int.TryParse(this.cmbMunicipio.SelectedValue.ToString(), out IDMunicipio);
                    if (IDMunicipio == 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar el Municipio de la lista.", ControlSender = this.cmbMunicipio });
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
                LogError.AddExcFileTxt(ex, "frmNuevoProveedor ~ btnCancelar_Click");
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
                    Proveedor Datos = this.ObtenerDatos();
                    Catalogo_Negocio cn = new Catalogo_Negocio();
                    cn.ABCCatProveedores(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosProveedor = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al guardar los datos.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProveedor ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoProveedor_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoProveedor ~ frmNuevoProveedor_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbPais.SelectedIndex != -1) //para saber que el usuario no escribió cualquier cosa en lugar de seleccionar un elemento de la lista
                {
                    string Value = this.cmbPais.SelectedValue.ToString();
                    int IDPais = 0;
                    int.TryParse(Value, out IDPais);
                    this.LlenarComboCatEstadoXIDPais(IDPais);
                }
                else
                {
                    MessageBox.Show("Seleccione un elemento de la lista.", "CSL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaSucursal ~ cmbPais_SelectedIndexChanged(");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbEstado.SelectedIndex != -1) //para saber que el usuario no escribió cualquier cosa en lugar de seleccionar un elemento de la lista
                {
                    string Value = this.cmbEstado.SelectedValue.ToString();
                    int IDEstado = 0;
                    int.TryParse(Value, out IDEstado);
                    Value = this.cmbPais.SelectedValue.ToString();
                    int IDPais = 0;
                    int.TryParse(Value, out IDPais);
                    this.LlenarComboCatMunicipioXIDEstado(IDPais, IDEstado);
                }
                else
                {
                    MessageBox.Show("Seleccione un elemento de la lista.", "CSL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaSucursal ~ cmbPais_SelectedIndexChanged(");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
