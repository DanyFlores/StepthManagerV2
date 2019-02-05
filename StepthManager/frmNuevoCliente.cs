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
using System.Configuration;

namespace StephManager
{
    public partial class frmNuevoCliente : Form
    {
        #region Propiedades / Variables
        private int TipoForm = 0;
        private Cliente _DatosCliente;
        public Cliente DatosCliente
        {
            get { return _DatosCliente; }
            set { _DatosCliente = value; }
        }
        private TarjetaMonedero DatosTarjeta = new TarjetaMonedero { IDTarjeta = string.Empty, Folio = string.Empty };
        #endregion

        #region Constructor

        public frmNuevoCliente()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCliente ~ frmNuevoCliente()");
            }
        }

        public frmNuevoCliente(Cliente Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosCliente = Datos;
                this.TipoForm = 2;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCliente ~ frmNuevoCliente(Cliente Datos)");
            }
        }

        #endregion

        #region Métodos

        private void CargarDatosAModificar(Cliente Datos)
        {
            try
            {
                this.txtNombre.Text = Datos.Nombre;
                this.txtApellidoPat.Text = Datos.ApellidoPat;
                this.txtApellidoMat.Text = Datos.ApellidoMat;
                this.txtCorreo.Text = Datos.Correo;
                this.txtTelefono.Text = Datos.Telefono;
                this.dtpFechaNac.Value = Datos.FechaNac;
                this.txtObservaciones.Text = Datos.Observaciones;
                this.txtRecomendaciones.Text = Datos.Recomendaciones;
                this.LlenarListaTagsInteres(Datos.IDCliente);
                this.LlenarListaPadecimientos(Datos.IDCliente);
                if (ExisteItemEnCombo(Datos.IDGenero))
                    this.cmbGenero.SelectedValue = Datos.IDGenero;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExisteItemEnCombo(int ID)
        {
            try
            {
                int Aux = 0;
                foreach (DataRowView fila in this.cmbGenero.Items)
                {
                    int.TryParse(fila["IDGenero"].ToString(), out Aux);
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

        private DataTable GenerarTablaPadecimientos()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla.Columns.Add("IDPadecimiento", typeof(string));
                Tabla.Columns.Add("IDPadecimientoXCliente", typeof(string));
                if (this.chkListBoxPadecimientos.CheckedItems.Count > 0)
                {
                    foreach (Padecimiento item in this.chkListBoxPadecimientos.CheckedItems)
                    {
                        Tabla.Rows.Add(new object[] {item.IDPadecimiento, item.IDPadecimientoXCliente });
                    }
                }
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
                if (this.chkListBoxTags.CheckedItems.Count > 0)
                {
                    foreach (TagInteres item in this.chkListBoxTags.CheckedItems)
                    {
                        Tabla.Rows.Add(item.IDTagInteres);
                    }
                }
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
                this.LlenarComboGenero();
                if (TipoForm == 1)
                    this.InicializarCampos();
                else
                    this.CargarDatosAModificar(_DatosCliente);
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
                //this.txtTarjeta.Text = string.Empty;
                //this.txtMonedero.Text = string.Format("{0:C}", 0);
                this.txtNombre.Text = string.Empty;
                this.txtApellidoPat.Text = string.Empty;
                this.txtApellidoMat.Text = string.Empty;
                this.txtCorreo.Text = string.Empty;
                this.txtTelefono.Text = string.Empty;
                this.txtObservaciones.Text = string.Empty;
                this.txtRecomendaciones.Text = string.Empty;
                this.dtpFechaNac.Value = DateTime.Today;
                this.LlenarListaTagsInteres(string.Empty);
                this.LlenarListaPadecimientos(string.Empty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarComboGenero()
        {
            try
            {
                Genero DatosAux = new Genero { Opcion = 2, Conexion = Comun.Conexion };
                Catalogo_Negocio CN = new Catalogo_Negocio();
                CN.ObtenerCatGeneros(DatosAux);
                this.cmbGenero.DisplayMember = "Descripcion";
                this.cmbGenero.ValueMember = "IDGenero";
                this.cmbGenero.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarListaPadecimientos(string IDCliente)
        {
            try
            {
                Padecimiento Datos = new Padecimiento { Conexion = Comun.Conexion, IDCliente = IDCliente };
                Cliente_Negocio cn = new Cliente_Negocio();
                List<Padecimiento> Lista = cn.ObtenerCatPadecimientosXIDCliente(Datos);
                foreach (Padecimiento Item in Lista)
                {
                    this.chkListBoxPadecimientos.Items.Add(Item, Item.Seleccionado);
                }
                this.chkListBoxPadecimientos.ValueMember = "IDPadecimiento";
                this.chkListBoxPadecimientos.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarListaTagsInteres(string IDCliente)
        {
            try
            {
                TagInteres Datos = new TagInteres { Conexion = Comun.Conexion, IDCliente = IDCliente};
                Cliente_Negocio cn = new Cliente_Negocio();
                List<TagInteres> Lista = cn.ObtenerCatTagInteresXIDCliente(Datos);
                foreach (TagInteres Item in Lista)
                {
                    this.chkListBoxTags.Items.Add(Item, Item.Seleccionado);
                }
                this.chkListBoxTags.ValueMember = "IDTagInteres";
                this.chkListBoxTags.DisplayMember = "Descripcion";
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

        private Cliente ObtenerDatos()
        {
            try
            {
                Cliente DatosAux = new Cliente();
                int IDGenero = 0;
                DataRowView Fila = (DataRowView)this.cmbGenero.SelectedItem;
                int.TryParse(this.cmbGenero.SelectedValue.ToString(), out IDGenero);
                DatosAux.IDCliente = TipoForm == 2 ? this._DatosCliente.IDCliente : string.Empty;
                DatosAux.Nombre = this.txtNombre.Text.Trim();
                DatosAux.ApellidoPat = this.txtApellidoPat.Text.Trim();
                DatosAux.ApellidoMat = this.txtApellidoMat.Text.Trim();
                DatosAux.IDGenero = IDGenero;
                DatosAux.GenereoDesc = Fila["Descripcion"].ToString();
                DatosAux.Correo = this.txtCorreo.Text.Trim();
                DatosAux.Telefono = this.txtTelefono.Text.Trim();
                DatosAux.FechaNac = this.dtpFechaNac.Value;
                DatosAux.TablaPadecimientos = GenerarTablaPadecimientos();
                DatosAux.TablaTagsInteres = GenerarTablaTagsInteres();
                DatosAux.Opcion = this.TipoForm;
                DatosAux.Observaciones = this.txtObservaciones.Text.Trim();
                DatosAux.Recomendaciones = this.txtRecomendaciones.Text.Trim();
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
                if (string.IsNullOrEmpty(this.txtNombre.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un nombre de cliente.", ControlSender = this.txtNombre });
                else
                {
                    if (!Validar.IsValidName(this.txtNombre.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un nombre de cliente válido.", ControlSender = this.txtNombre });
                }
                if (string.IsNullOrEmpty(this.txtApellidoPat.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar el apellido paterno de cliente.", ControlSender = this.txtApellidoPat });
                else
                {
                    if (!Validar.IsValidName(this.txtApellidoPat.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un apellido paterno válido.", ControlSender = this.txtApellidoPat });
                }
                if (!string.IsNullOrEmpty(this.txtApellidoMat.Text.Trim()))
                {
                    if (!Validar.IsValidName(this.txtApellidoMat.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un apellido materno válido.", ControlSender = this.txtApellidoMat });
                }
                if (this.cmbGenero.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar un género de la lista.", ControlSender = this.cmbGenero });
                else
                {
                    int IDGenero = 0;
                    int.TryParse(this.cmbGenero.SelectedValue.ToString(), out IDGenero);
                    if(IDGenero == 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar un género de la lista.", ControlSender = this.cmbGenero });
                }

                if (string.IsNullOrEmpty(this.txtCorreo.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar el correo electrónico del cliente.", ControlSender = this.txtCorreo });
                else
                {
                    if (!Validar.IsValidMail(this.txtCorreo.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar una dirección de correo electrónico válida.", ControlSender = this.txtCorreo });
                }
                if (!string.IsNullOrEmpty(this.txtTelefono.Text.Trim()))
                {
                    if (!Validar.IsValidPhoneNumber(this.txtTelefono.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar un número telefónico válido.", ControlSender = this.txtTelefono });
                }
                if(this.dtpFechaNac.Value > DateTime.Today.AddYears(-15))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese una fecha de nacimiento válida.", ControlSender = this.dtpFechaNac });
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
                LogError.AddExcFileTxt(ex, "frmNuevoCliente ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClaveTarjeta_Click(object sender, EventArgs e)
        {
            try
            {
                //frmElegirTarjetaMonedero Tarjetas = new frmElegirTarjetaMonedero();
                //Tarjetas.ShowDialog();
                //Tarjetas.Dispose();
                //if (Tarjetas.DialogResult == DialogResult.OK)
                //{
                //    this.DatosTarjeta = Tarjetas.Seleccionado;
                //    this.txtTarjeta.Text = this.DatosTarjeta.Folio;
                //    this.txtMonedero.Text = string.Format("{0:C}", 0);
                //    this.txtNombre.Focus();
                //}
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCliente ~ btnClaveTarjeta_Click");
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
                    Cliente Datos = this.ObtenerDatos();
                    Cliente_Negocio CN = new Cliente_Negocio();
                    CN.ABCCatClientes(Datos);
                    if (Datos.Completado)
                    {
                        if (!string.IsNullOrEmpty(Datos.Correo))
                        {
                            EnvioCorreo.EnviarCorreo(
                                ConfigurationManager.AppSettings.Get("CorreoTxt")
                                , ConfigurationManager.AppSettings.Get("PasswordTxt")
                                , Datos.Correo
                                , "Contraseña para acceso a nuestros servicios"
                                , EnvioCorreo.GenerarHtmlRegistoUsuario(Datos.Correo, Datos.Password)
                                , false
                                , ""
                                , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("HtmlTxt"))
                                , ConfigurationManager.AppSettings.Get("HostTxt")
                                , Convert.ToInt32(ConfigurationManager.AppSettings.Get("PortTxt"))
                                , Convert.ToBoolean(ConfigurationManager.AppSettings.Get("EnableSslTxt")));
                        }
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosCliente = Datos;
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
                LogError.AddExcFileTxt(ex, "frmNuevoCliente ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevoCliente_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevoCliente ~ frmNuevoCliente_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void button_Creativa1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.Size.ToString());
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
