using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using CreativaSL.Dll.Validaciones;
using StephManager.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephManager
{
    public partial class frmConfiguracion : Form
    {

        private string Urllogo = string.Empty;
        private bool BandLogo = false;
        private Configuracion DatosAux = new Configuracion();

        #region Constructor

        public frmConfiguracion()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmConfiguracion ~ frmConfiguracion()");
            }
        }

        #endregion

        #region Métodos

        private void CargarDatos(Configuracion Datos)
        {
            try
            {
                this.txtRazonSocial.Text = Datos.RazonSocial;
                this.txtNombreComercial.Text = Datos.NombreComercial;
                this.txtEslogan.Text = Datos.Eslogan;
                this.txtRFC.Text = Datos.RFC;
                this.txtRepresentante.Text = Datos.Representante;
                this.txtRegimenFiscal.Text = Datos.RegimenFiscal;
                this.txtDomicilioFiscal.Text = Datos.DomicilioFiscal;
                if (!string.IsNullOrEmpty(Datos.UrlLogo))
                {
                    if (!File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Datos.UrlLogo)))
                    {
                        Configuracion_Negocio CN = new Configuracion_Negocio();
                        Configuracion Aux = CN.ObtenerLogoImagen(Comun.Conexion);
                        if (Aux.BufferImagen.Length > 0)
                        {
                            System.IO.MemoryStream ms = new System.IO.MemoryStream(Aux.BufferImagen);
                            Image.FromStream(ms).Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Datos.UrlLogo));
                        }
                    }
                    this.pbLogo.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Datos.UrlLogo));
                }
                this.txtPorcentajeIva.Text = string.Format("{0:F2}", Datos.PorcentajeIva);
                this.chkFechaCorte1.Checked = Datos.BandFecha01;
                this.chkFechaCorte2.Checked = Datos.BandFecha02;
                this.chkFechaCorte3.Checked = Datos.BandFecha03;
                if (Datos.BandFecha01)
                    this.dtpFechaCorte1.Value = Datos.Fecha01;
                else
                    this.dtpFechaCorte1.Value = DateTime.Today;
                if (Datos.BandFecha02)
                    this.dtpFechaCorte2.Value = Datos.Fecha02;
                else
                    this.dtpFechaCorte2.Value = DateTime.Today;
                if (Datos.BandFecha03)
                    this.dtpFechaCorte3.Value = Datos.Fecha03;
                else
                    this.dtpFechaCorte3.Value = DateTime.Today;
                this.txtGarantia.Text = Datos.TextoGarantia;
                this.txtPagoDiasFestivos.Text = string.Format("{0:F2}", Datos.PagoDiasFestivos);
                this.txtPagoDiasVaciones.Text = string.Format("{0:F2}", Datos.PagoDiasVacaciones);
                this.txtPagosDiaDomingo.Text = string.Format("{0:F2}", Datos.PagoDiasDomingo);
                this.txtFaltasRetrasos.Text = Datos.FaltasRetardos.ToString();
                this.txtTextoTicket.Text = Datos.TextoTicket;
                this.txtPorcDesc.Text = string.Format("{0:F2}", Datos.DescCumpleaños);
                DatosAux = Datos;
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
                this.txtRazonSocial.Text = string.Empty;
                this.txtNombreComercial.Text = string.Empty;
                this.txtEslogan.Text = string.Empty;
                this.txtRFC.Text = string.Empty;
                this.txtRepresentante.Text = string.Empty;
                this.txtDomicilioFiscal.Text = string.Empty;
                this.txtRegimenFiscal.Text = string.Empty;
                this.txtPorcentajeIva.Text = string.Format("{0:F2}", 0);
                this.chkFechaCorte1.Checked = false;
                this.chkFechaCorte2.Checked = false;
                this.chkFechaCorte3.Checked = false;
                this.dtpFechaCorte1.Value = DateTime.Today;
                this.dtpFechaCorte2.Value = DateTime.Today;
                this.dtpFechaCorte3.Value = DateTime.Today;
                this.txtPagosDiaDomingo.Text = string.Format("{0:F2}", 0);
                this.txtPagoDiasVaciones.Text = string.Format("{0:F2}", 0);
                this.txtPagoDiasFestivos.Text = string.Format("{0:F2}", 0);
                this.txtPorcDesc.Text = string.Format("{0:F2}", 0);
                this.txtGarantia.Text = string.Empty;
                this.txtTextoTicket.Text = string.Empty;
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
                Configuracion_Negocio CN = new Configuracion_Negocio();
                Configuracion Datos = CN.ObtenerDatosConfiguracion(Comun.Conexion);
                if (Datos.Completado)
                    this.CargarDatos(Datos);
                else
                    this.IniciarDatos();
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

        private void ObtenerImagen()
        {
            try
            {
                OpenFileDialog BuscarImagen = new OpenFileDialog();
                BuscarImagen.Filter = "Archivos de Imagen |*.jpg;*.png";
                BuscarImagen.FileName = "";
                BuscarImagen.Title = "Seleccione Logo";
                if (BuscarImagen.ShowDialog() == DialogResult.OK)
                {
                    this.BandLogo = true;
                    this.Urllogo = BuscarImagen.SafeFileName;
                    this.pbLogo.ImageLocation = BuscarImagen.FileName;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ObtenerImagen" + ex.Message);
            }
        }

        private decimal ObtenerPorcIva()
        {
            try
            {
                decimal Porc = 0;
                decimal.TryParse(this.txtPorcentajeIva.Text, out Porc);
                return Porc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private decimal ObtenerPagoDiaFestivo()
        {
            try
            {
                decimal Festivo = 0;
                decimal.TryParse(this.txtPagoDiasFestivos.Text, out Festivo);
                return Festivo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private decimal ObtenerPagoDiaVacaciones()
        {
            try
            {
                decimal Vacaciones = 0;
                decimal.TryParse(this.txtPagoDiasVaciones.Text, out Vacaciones);
                return Vacaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private decimal ObtenerPagoDiaDomingo()
        {
            try
            {
                decimal Domingo = 0;
                decimal.TryParse(this.txtPagosDiaDomingo.Text, out Domingo);
                return Domingo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private byte[] ObtenerImagenByte(Image ImagenComp)
        {
            try
            {

                ImageFormat Formato = ImageFormat.Jpeg;
                //Image ImagenComp = ComprimirImagen.ResizeImage(this.pbLogo.Image, 150, 150);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ImagenComp.Save(ms, Formato);
                return ms.GetBuffer();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private byte[] ObtenerImagenByte(string Url)
        {
            try
            {
                FileStream foto = new FileStream(Url, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                Byte[] arreglo = new Byte[foto.Length];
                BinaryReader reader = new BinaryReader(foto);
                arreglo = reader.ReadBytes(Convert.ToInt32(foto.Length));
                return arreglo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Configuracion ObtenerDatos()
        {
            try
            {
                Configuracion Datos = new Configuracion();
                Datos.RazonSocial = this.txtRazonSocial.Text.Trim();
                Datos.NombreComercial = this.txtNombreComercial.Text.Trim();
                Datos.RFC = this.txtRFC.Text.Trim();
                Datos.Representante = this.txtRepresentante.Text.Trim();
                Datos.Eslogan = this.txtEslogan.Text.Trim();
                Datos.RegimenFiscal = this.txtRegimenFiscal.Text.Trim();
                Datos.DomicilioFiscal = this.txtDomicilioFiscal.Text.Trim();
                Datos.PorcentajeIva = this.ObtenerPorcIva();
                Datos.BandFecha01 = this.chkFechaCorte1.Checked;
                Datos.BandFecha02 = this.chkFechaCorte2.Checked;
                Datos.BandFecha03 = this.chkFechaCorte3.Checked;
                Datos.Fecha01 = this.dtpFechaCorte1.Value;
                Datos.Fecha02 = this.dtpFechaCorte2.Value;
                Datos.Fecha03 = this.dtpFechaCorte3.Value;
                if (BandLogo)
                {
                    Datos.UrlLogo = this.Urllogo;
                    ImageFormat Formato = ImageFormat.Jpeg;
                    string URl = Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Urllogo.ToLower());
                    Image Imagen = ComprimirImagen.ResizeImage2(this.pbLogo.Image, 220, 150);
                    Imagen.Save(URl);
                    Datos.BufferImagen = this.ObtenerImagenByte(URl);
                }
                Datos.BandLogo = this.BandLogo;
                Datos.TextoGarantia = this.txtGarantia.Text.Trim();
                Datos.PagoDiasFestivos = this.ObtenerPagoDiaFestivo();
                Datos.PagoDiasVacaciones = this.ObtenerPagoDiaVacaciones();
                Datos.PagoDiasDomingo = this.ObtenerPagoDiaDomingo();
                Datos.FaltasRetardos = Convert.ToInt32(this.txtFaltasRetrasos.Text.Trim());
                Datos.TextoTicket = this.txtTextoTicket.Text.Trim();
                Datos.DescCumpleaños = this.ObtenerPorcDesc();
                Datos.IDUsuario = Comun.IDUsuario;
                Datos.Conexion = Comun.Conexion;
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerPorcDesc()
        {
            try
            {
                decimal Porcentaje = 0;
                decimal.TryParse(txtPorcDesc.Text.Trim(), out Porcentaje);
                return Porcentaje;
            }
            catch(Exception ex)
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

        private List<Error> ValidarDatos()
        {
            try
            {
                List<Error> Errores = new List<Error>();
                int Aux = 0;
                if (string.IsNullOrEmpty(this.txtRazonSocial.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la razón social.", ControlSender = this.txtRazonSocial });
                if (string.IsNullOrEmpty(txtNombreComercial.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el nombre comercial.", ControlSender = this.txtNombreComercial });
                if (string.IsNullOrEmpty(txtRFC.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el RFC.", ControlSender = this.txtRFC });
                else
                {
                    if (!Validar.IsValidRFC(this.txtRFC.Text))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un RFC válido.", ControlSender = this.txtRFC });
                }
                if (string.IsNullOrEmpty(this.txtPorcentajeIva.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el porcentaje de IVA.", ControlSender = this.txtPorcentajeIva });
                if (string.IsNullOrEmpty(this.txtPagoDiasFestivos.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el porcentaje de pagos dias festivos.", ControlSender = this.txtPagoDiasFestivos });
                if (string.IsNullOrEmpty(this.txtPagoDiasVaciones.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el porcentaje de pagos dias vacaciones.", ControlSender = this.txtPagoDiasVaciones });
                if (string.IsNullOrEmpty(this.txtPagosDiaDomingo.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el porcentaje de pago dias domingo.", ControlSender = this.txtPagosDiaDomingo });
                if (string.IsNullOrEmpty(txtFaltasRetrasos.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un numero dia válido", ControlSender = this.txtFaltasRetrasos });
                else
                {
                    if (!Validar.IsValidOnlyNumber(this.txtFaltasRetrasos.Text))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un numero dia válido.", ControlSender = this.txtFaltasRetrasos });
                }

                if (string.IsNullOrEmpty(this.txtPorcDesc.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el porcentaje de descuento por cumpleaños.", ControlSender = this.txtPorcDesc });
                else
                {
                    decimal Porc = 0;
                    if(!decimal.TryParse(this.txtPorcDesc.Text.Trim(), out Porc))
                    {
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un dato válido para porcentaje de descuento por cumpleaños.", ControlSender = this.txtPorcDesc });
                    }
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Error> Lista = this.ValidarDatos();
                if (Lista.Count == 0)
                {
                    Configuracion Datos = this.ObtenerDatos();
                    Configuracion_Negocio CN = new Configuracion_Negocio();
                    CN.GuardarDatosConfiguracion(Datos);
                    if (Datos.Completado)
                        this.DialogResult = DialogResult.OK;
                    else
                        MessageBox.Show("Ocurrió un error al guardar los datos. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    this.MostrarMensajeError(Lista);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmConfiguracion ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                LogError.AddExcFileTxt(ex, "frmConfiguracion ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElegirLogo_Click(object sender, EventArgs e)
        {
            try
            {
                this.ObtenerImagen();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmConfiguracion ~ btnElegirLogo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmConfiguracion ~ frmConfiguracion_Load");
            }
        }

        private void txtPorcentajeIva_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                this.txtPorcentajeIva.Text = string.Format("{0:F2}", this.ObtenerPorcIva());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmConfiguracion ~ txtPorcentajeIva_Validating");
            }
        }

        #endregion

        private void txtPagoDiasFestivos_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                this.txtPagoDiasFestivos.Text = string.Format("{0:F2}", this.ObtenerPagoDiaFestivo());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmConfiguracion ~ txtPagoDiasFestivos_Validating");
            }
        }

        private void txtPagoDiasVaciones_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                this.txtPagoDiasVaciones.Text = string.Format("{0:F2}", this.ObtenerPagoDiaVacaciones());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmConfiguracion ~ txtPagoDiasVaciones_Validating");
            }
        }

        private void txtPagosDiaDomingo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                this.txtPagosDiaDomingo.Text = string.Format("{0:F2}", this.ObtenerPagoDiaDomingo());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmConfiguracion ~ txtPagosDiaDomingo_Validating");
            }
        }

    }
}
