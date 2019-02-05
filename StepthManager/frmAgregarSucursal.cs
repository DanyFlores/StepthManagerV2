using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using CreativaSL.Dll.Validaciones;
using StephManager.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephManager
{
    public partial class frmAgregarSucursal : Form
    {
        #region Propiedades / Variables

        #endregion

        #region Constructor

        public frmAgregarSucursal()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaSucursal ~ frmNuevaSucursal()");
            }
        }

        public frmAgregarSucursal(string IDSucursal)
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaSucursal ~ frmNuevaSucursal(CatSucursales Datos)");
            }
        }

        #endregion

        #region Métodos

        private void CargarCombos()
        {
            try
            {
                Catalogo_Negocio Catalogos_negocio = new Catalogo_Negocio();
                CatEmpresa Empresa = new CatEmpresa();
                Empresa.Conexion = Comun.Conexion;
                TipoSucursal TipoSucursal = new TipoSucursal();
                TipoSucursal.Conexion = Comun.Conexion;
                CatPais pais = new CatPais();
                pais.Conexion = Comun.Conexion;

                Catalogos_negocio.ObtenerComboCatEmpresa(Empresa);
                Catalogos_negocio.ObtenerComboCatTipoSucursal(TipoSucursal);
                Catalogos_negocio.ObtenerComboCatPais(pais);

                this.cmbEmpresa.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbEmpresa.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmbEmpresa.DataSource = Empresa.TablaDatos;
                this.cmbEmpresa.DisplayMember = "razonSocial";
                this.cmbEmpresa.ValueMember = "id_empresa";

                this.cmbTipoSucursal.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbTipoSucursal.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmbTipoSucursal.DataSource = TipoSucursal.TablaDatos;
                this.cmbTipoSucursal.DisplayMember = "descripcion";
                this.cmbTipoSucursal.ValueMember = "id_tipoSucursal";

                this.cmbPais.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbPais.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmbPais.DataSource = pais.TablaDatos;
                this.cmbPais.DisplayMember = "descripcion";
                this.cmbPais.ValueMember = "id_pais";
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

        private void CargarDatosAModificar(Sucursal Datos)
        {
            try
            {
                this.cmbEmpresa.Enabled = false;
                this.txtNombreSucursal.Text = Datos.NombreSucursal;
                this.txtCodigoPostal.Text = Datos.CodigoPostal;
                if (ExisteItemEnComboEmpresa(Datos.IDEmpresa))
                    this.cmbEmpresa.SelectedValue = Datos.IDEmpresa;
                if (ExisteItemEnComboTipoSucursal(Datos.IDTipoSucursal))
                    this.cmbTipoSucursal.SelectedValue = Datos.IDTipoSucursal;
                //this.txtPrcentajeMonedero.Text = Convert.ToString(Datos.PorcentajeMonedero.ToString());
                this.txtTelefono.Text = Datos.Telefono;
                this.txtRFC.Text = Datos.rfc;
                this.txtRepresentante.Text = Datos.Representante;
                this.txtDireccion.Text = Datos.Direccion;
                if (ExisteItemEnComboPais(Datos.IDPais))
                    this.cmbPais.SelectedValue = Datos.IDPais;
                if (ExisteItemEnComboEstado(Datos.IDEstado))
                    this.cmbEstado.SelectedValue = Datos.IDEstado;
                if (ExisteItemEnComboMunicipio(Datos.IDMunicipio))
                    this.cmbMunicipio.SelectedValue = Datos.IDMunicipio;
                //this.LlenarHorario(this._DatosSucursal.IDSucursal);
                //this.ListaSucursalHorario(this._DatosSucursal.IDSucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ListaSucursalHorario(string IDSucursal)
        {
            try
            {
                //foreach (Sucursal ItemAux in this.HorarioSucursal)
                //{
                //    switch (ItemAux.Dia)
                //    {
                //        case 1:
                //            this.chkAplicaLunes.Checked = true;
                //            this.dtpHoraInicioLunes.Value = Convert.ToDateTime(ItemAux.HoraEntrada.ToString());
                //            this.dtpHoraFinLunes.Value = Convert.ToDateTime(ItemAux.HoraSalida.ToString());
                //            break;
                //        case 2:
                //            this.chkAplicaMartes.Checked = true;
                //            this.dtpHoraInicioMartes.Value = Convert.ToDateTime(ItemAux.HoraEntrada.ToString());
                //            this.dtpHoraFinMartes.Value = Convert.ToDateTime(ItemAux.HoraSalida.ToString());
                //            break;
                //        case 3:
                //            this.chkAplicaMiercoles.Checked = true;
                //            this.dtpHoraInicioMiercoles.Value = Convert.ToDateTime(ItemAux.HoraEntrada.ToString());
                //            this.dtpHoraFinMiercoles.Value = Convert.ToDateTime(ItemAux.HoraSalida.ToString());
                //            break;
                //        case 4:
                //            this.chkAplicaJueves.Checked = true;
                //            this.dtpHoraInicioJueves.Value = Convert.ToDateTime(ItemAux.HoraEntrada.ToString());
                //            this.dtpHoraFinJueves.Value = Convert.ToDateTime(ItemAux.HoraSalida.ToString());
                //            break;
                //        case 5:
                //            this.chkAplicaViernes.Checked = true;
                //            this.dtpHoraInicioViernes.Value = Convert.ToDateTime(ItemAux.HoraEntrada.ToString());
                //            this.dtpHoraFinViernes.Value = Convert.ToDateTime(ItemAux.HoraSalida.ToString());
                //            break;
                //        case 6:
                //            this.chkAplicaSabado.Checked = true;
                //            this.dtpHoraInicioSabado.Value = Convert.ToDateTime(ItemAux.HoraEntrada.ToString());
                //            this.dtpHoraFinSabado.Value = Convert.ToDateTime(ItemAux.HoraSalida.ToString());
                //            break;
                //        case 7:
                //            this.chkAplicaDomingo.Checked = true;
                //            this.dtpHoraInicioDomingo.Value = Convert.ToDateTime(ItemAux.HoraEntrada.ToString());
                //            this.dtpHoraFinDomingo.Value = Convert.ToDateTime(ItemAux.HoraSalida.ToString());
                //            break;
                //        default:
                //            break;
                //    }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarHorario(string IDSucursal)
        {
            try
            {
                //Sucursal DatosAux = new Sucursal { Conexion = Comun.Conexion, IDSucursal = IDSucursal };
                //Catalogo_Negocio CatlogoNeg = new Catalogo_Negocio();
                //this.HorarioSucursal = CatlogoNeg.ObtenerSucursalHorarioXIDSucursal(DatosAux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExisteItemEnComboEmpresa(int ID)
        {
            try
            {
                int Aux = 0;
                foreach (DataRowView fila in this.cmbEmpresa.Items)
                {
                    int.TryParse(fila["id_empresa"].ToString(), out Aux);
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
        private bool ExisteItemEnComboTipoSucursal(int ID)
        {
            try
            {
                int Aux = 0;
                foreach (DataRowView fila in this.cmbTipoSucursal.Items)
                {
                    int.TryParse(fila["id_tipoSucursal"].ToString(), out Aux);
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

        private TipoSucursal ObtenerTipoSucursalSeleccionado()
        {
            try
            {
                TipoSucursal DatosAux = new TipoSucursal();
                if (this.cmbTipoSucursal.SelectedIndex != -1)
                {
                    DataRowView Fila = (DataRowView)this.cmbTipoSucursal.SelectedItem;
                    int IDTipoSucursal = 0;
                    int.TryParse(Fila["id_tipoSucursal"].ToString(), out IDTipoSucursal);
                    DatosAux.IDTipoSucursal = IDTipoSucursal;
                    DatosAux.Descripcion = Fila["descripcion"].ToString();
                }
                return DatosAux;
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
                //this.CargarCombos();
                //if (TipoForm == 1)
                //    this.InicializarCampos();
                //else
                //    this.CargarDatosAModificar(_DatosSucursal);
                //this.ActiveControl = this.txtNombreSucursal;
                //this.txtNombreSucursal.Focus();
                //if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                //{
                //    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                //}
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
                this.txtNombreSucursal.Text = string.Empty;
                this.txtDireccion.Text = string.Empty;
                this.txtCodigoPostal.Text = string.Empty;
                this.txtTelefono.Text = string.Empty;
                this.txtRFC.Text = string.Empty;
                this.txtRepresentante.Text = string.Empty;
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

        private Sucursal ObtenerDatos()
        {
            try
            {
                Sucursal DatosAux = new Sucursal();
                TipoSucursal TipoAux = this.ObtenerTipoSucursalSeleccionado();
                //DatosAux.IDSucursal = TipoForm == 2 ? this._DatosSucursal.IDSucursal : string.Empty;
                DatosAux.IDEmpresa = Convert.ToInt32(this.cmbEmpresa.SelectedValue);
                DatosAux.IDTipoSucursal = Convert.ToInt32(this.cmbTipoSucursal.SelectedValue);
                DatosAux.IDEstado = Convert.ToInt32(this.cmbEstado.SelectedValue);
                DatosAux.IDMunicipio = Convert.ToInt32(this.cmbMunicipio.SelectedValue);
                DatosAux.IDPais = Convert.ToInt32(this.cmbPais.SelectedValue);
                DatosAux.NombreTipoSucursal = TipoAux.Descripcion;
                DatosAux.NombreSucursal = this.txtNombreSucursal.Text.Trim();
                DatosAux.CodigoPostal = this.txtCodigoPostal.Text.Trim();
                DatosAux.rfc = this.txtRFC.Text.Trim();
                DatosAux.Representante = this.txtRepresentante.Text.Trim();
                //DatosAux.PorcentajeMonedero = float.Parse(this.txtPrcentajeMonedero.Text.Trim());
                DatosAux.Telefono = this.txtTelefono.Text.Trim();
                DatosAux.Direccion = this.txtDireccion.Text.Trim();
                //TimeSpan Aux = DateTime.Now.TimeOfDay;
                //MessageBox.Show(Aux.ToString());
                DataTable TablaDiasSemanas = new DataTable();
                TablaDiasSemanas.Columns.Add("Dia", typeof(int));
                TablaDiasSemanas.Columns.Add("HoraEntrada", typeof(TimeSpan));
                TablaDiasSemanas.Columns.Add("HoraSalida", typeof(TimeSpan));
                if (chkAplicaLunes.Checked)
                {
                    TablaDiasSemanas.Rows.Add(1, dtpHoraInicioLunes.Value.TimeOfDay, dtpHoraFinLunes.Value.TimeOfDay);
                }
                if (chkAplicaMartes.Checked)
                {
                    TablaDiasSemanas.Rows.Add(2, dtpHoraInicioMartes.Value.TimeOfDay, dtpHoraFinMartes.Value.TimeOfDay);
                }
                if (chkAplicaMiercoles.Checked)
                {
                    TablaDiasSemanas.Rows.Add(3, dtpHoraInicioMiercoles.Value.TimeOfDay, dtpHoraFinMiercoles.Value.TimeOfDay);
                }
                if (chkAplicaJueves.Checked)
                {
                    TablaDiasSemanas.Rows.Add(4, dtpHoraInicioJueves.Value.TimeOfDay, dtpHoraFinJueves.Value.TimeOfDay);
                }
                if (chkAplicaViernes.Checked)
                {
                    TablaDiasSemanas.Rows.Add(5, dtpHoraInicioViernes.Value.TimeOfDay, dtpHoraFinViernes.Value.TimeOfDay);
                }
                if (chkAplicaSabado.Checked)
                {
                    TablaDiasSemanas.Rows.Add(6, dtpHoraInicioSabado.Value.TimeOfDay, dtpHoraFinSabado.Value.TimeOfDay);
                }
                if (chkAplicaDomingo.Checked)
                {
                    TablaDiasSemanas.Rows.Add(7, dtpHoraInicioDomingo.Value.TimeOfDay, dtpHoraFinDomingo.Value.TimeOfDay);
                }
                DatosAux.TablaSucursalesHorario = TablaDiasSemanas;
                //DatosAux.Opcion = this.TipoForm;
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
                if (string.IsNullOrEmpty(this.txtNombreSucursal.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el nombre de la sucursal.", ControlSender = this.txtNombreSucursal });
                else
                {
                    //if (!Validar.IsValidDescripcion(this.txtNombreSucursal.Text.Trim()))
                      //  Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un nombre de sucursal válido.", ControlSender = this.txtNombreSucursal });
                }
                if (this.cmbEmpresa.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar la empresa de la lista.", ControlSender = this.cmbEmpresa });
                else
                {
                    int IDEmpresa = 0;
                    int.TryParse(this.cmbEmpresa.SelectedValue.ToString(), out IDEmpresa);
                    if (IDEmpresa == 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar la empresa de la lista.", ControlSender = this.cmbEmpresa });
                }
                if (this.cmbTipoSucursal.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar el tipo de sucursal de la lista.", ControlSender = this.cmbTipoSucursal });
                else
                {
                    int IDTipoSucursal = 0;
                    int.TryParse(this.cmbTipoSucursal.SelectedValue.ToString(), out IDTipoSucursal);
                    if (IDTipoSucursal == 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar el tipo de sucursal de la lista.", ControlSender = this.cmbTipoSucursal });
                }
                if (this.cmbPais.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar un país de la lista.", ControlSender = this.cmbPais });
                else
                {
                    int IDPais = 0;
                    int.TryParse(this.cmbPais.SelectedValue.ToString(), out IDPais);
                    if (IDPais == 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar un país de la lista.", ControlSender = this.cmbPais });
                }
                if (this.cmbEstado.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar un estado de la lista.", ControlSender = this.cmbEstado });
                else
                {
                    int IDEstado = 0;
                    int.TryParse(this.cmbEstado.SelectedValue.ToString(), out IDEstado);
                    if (IDEstado == 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar un estado de la lista.", ControlSender = this.cmbEstado });
                }
                if (this.cmbMunicipio.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar un municipio de la lista.", ControlSender = this.cmbMunicipio });
                else
                {
                    int IDMunicipio = 0;
                    int.TryParse(this.cmbMunicipio.SelectedValue.ToString(), out IDMunicipio);
                    if (IDMunicipio == 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar un municipio de la lista.", ControlSender = this.cmbMunicipio });
                }
                if (!string.IsNullOrEmpty(this.txtCodigoPostal.Text.Trim()))
                    //Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el Código Postal.", ControlSender = this.txtCodigoPostal });
                    //else
                    //{
                    if (!Validar.IsValidZipCode(this.txtCodigoPostal.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un código postal válido.", ControlSender = this.txtCodigoPostal });
                //}
                if (string.IsNullOrEmpty(this.txtRFC.Text.Trim()))
                    if (!Validar.IsValidRFC(this.txtRFC.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un RFC válido.", ControlSender = this.txtNombreSucursal });
                if (!string.IsNullOrEmpty(this.txtTelefono.Text.Trim()))
                    //    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el Número de Telefono", ControlSender = this.txtTelefono });
                    //else
                    //{
                    if (!Validar.IsValidPhoneNumber(this.txtTelefono.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un número telefónico válido.", ControlSender = this.txtTelefono });
                //}
                if (!string.IsNullOrEmpty(this.txtDireccion.Text.Trim()))
                    //    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la Dirección", ControlSender = this.txtDireccion });
                    //else
                    //{
                    if (!Validar.IsValidDescripcion(this.txtDireccion.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese una dirección válida.", ControlSender = this.txtDireccion });
                //}

                if (!ValidarHorario())
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione al menos un horario.", ControlSender = this.txtDireccion });
                if (string.IsNullOrEmpty(this.txtRepresentante.Text.Trim()))
                    if (!Validar.IsValidName(this.txtRepresentante.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un nombre de representate válido.", ControlSender = this.txtNombreSucursal });

                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private bool ValidarHorario()
        {
            try
            {
                if (this.chkAplicaLunes.Checked)
                    return true;
                if (this.chkAplicaMartes.Checked)
                    return true;
                if (this.chkAplicaMiercoles.Checked)
                    return true;
                if (this.chkAplicaJueves.Checked)
                    return true;
                if (this.chkAplicaViernes.Checked)
                    return true;
                if (this.chkAplicaSabado.Checked)
                    return true;
                if (this.chkAplicaDomingo.Checked)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaSucursal ~ btnCancelar_Click");
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
                    Sucursal Datos = this.ObtenerDatos();
                    Catalogo_Negocio cn = new Catalogo_Negocio();
                    cn.ABCCatSucursales(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this._DatosSucursal = Datos;
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
                LogError.AddExcFileTxt(ex, "frmNuevaSucursal ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevaSucursal_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaSucursal ~ frmNuevaSucursal_Load");
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
