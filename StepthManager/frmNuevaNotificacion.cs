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
    public partial class frmNuevaNotificacion : Form
    {
        #region Propiedades / Variables
        private int TipoForm = 0;
        private Notificaciones _DatosNotificaciones;
        public Notificaciones DatosNotificaciones
        {
            get { return _DatosNotificaciones; }
            set { _DatosNotificaciones = value; }
        }
        private Cliente CatalogoActual = new Cliente();
        #endregion

        #region Constructor

        public frmNuevaNotificacion()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaNotificacion ~ frmNuevaNotificacion()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                this.ActiveControl = this.btnElegirCliente;
                this.btnElegirCliente.Focus();
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

        private Notificaciones ObtenerDatos()
        {
            try
            {
                Notificaciones DatosAux = new Notificaciones();
                DatosAux.IDNotificaciones = TipoForm == 2 ? this._DatosNotificaciones.IDNotificaciones : string.Empty;
                DatosAux.NombreNotificaciones = this.txtNombreNotificacion.Text.Trim();
                DatosAux.DescripcionNotificacion = this.txtDescripcionNotificaciones.Text.Trim();
                DatosAux.IDTipoNotificaciones = 5;
                DatosAux.IndividualGrupo = this.checkIndividual.Checked;
                if (DatosAux.IndividualGrupo == true)
                {
                    DatosAux.IDCliente = this.CatalogoActual.IDCliente.ToString();
                }
                else
                {
                    DatosAux.IDCliente = string.Empty;
                }
                DatosAux.EnviarNotificacion = true;
                DatosAux.Descripcion = this.txtComentarios.GetHTML(true, true);
                DatosAux.IDNivelEntrega = Convert.ToString(1);
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
               
                if (string.IsNullOrEmpty(this.txtNombreNotificacion.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un Nombre válido.", ControlSender = this.txtNombreNotificacion });
                //else
                //    if(!Validar.IsValidDescripcion(this.txtNombreNotificacion.Text))
                //        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un Nombre válido.", ControlSender = this.txtNombreNotificacion });
                if (string.IsNullOrEmpty(this.txtDescripcionNotificaciones.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese una descripción válido.", ControlSender = this.txtDescripcionNotificaciones });
                //else
                //    if (!Validar.IsValidDescripcion(this.txtDescripcionNotificaciones.Text))
                //        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese una descripción válido.", ControlSender = this.txtDescripcionNotificaciones });
                if (this.checkIndividual.Checked == true)
                {
                    if (string.IsNullOrEmpty(this.txtCliente.Text.Trim()))
                    {
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione un cliente.", ControlSender = this.btnElegirCliente });
                    }
                }
                if (string.IsNullOrEmpty(this.txtComentarios.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese una descripción general valido.", ControlSender = this.txtComentarios });
                //else
                //    if (!Validar.IsValidDescripcion(this.txtComentarios.Text))
                //        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese una descripción general valido.", ControlSender = this.txtComentarios });
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void tb_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripButton btn = (ToolStripButton)sender;
                switch (btn.ToolTipText)
                {
                    case "Bold":
                        {
                            if (this.txtComentarios.SelectionFont != null)
                            {
                                this.txtComentarios.SelectionFont = new Font(this.txtComentarios.SelectionFont, this.txtComentarios.SelectionFont.Style ^ FontStyle.Bold);
                            }
                        }
                        break;
                    case "Italic":
                        {
                            if (this.txtComentarios.SelectionFont != null)
                            {
                                this.txtComentarios.SelectionFont = new Font(this.txtComentarios.SelectionFont, this.txtComentarios.SelectionFont.Style ^ FontStyle.Italic);
                            }
                        }
                        break;
                    case "Underline":
                        {
                            if (this.txtComentarios.SelectionFont != null)
                            {
                                this.txtComentarios.SelectionFont = new Font(this.txtComentarios.SelectionFont, this.txtComentarios.SelectionFont.Style ^ FontStyle.Underline);
                            }
                        }
                        break;
                    case "Strikeout":
                        {
                            if (this.txtComentarios.SelectionFont != null)
                            {
                                this.txtComentarios.SelectionFont = new Font(this.txtComentarios.SelectionFont, this.txtComentarios.SelectionFont.Style ^ FontStyle.Strikeout);
                            }
                        }
                        break;
                    case "Super":
                        {
                            this.tbbSuperScript.Checked = !this.tbbSuperScript.Checked;
                            if (tbbSuperScript.Checked)
                            {
                                this.txtComentarios.SetSuperScript(true);
                                this.txtComentarios.SetSubScript(false);
                            }
                            else
                            {
                                this.txtComentarios.SetSuperScript(false);
                            }
                        }
                        break;

                    case "Sub":
                        {
                            this.tbbSubScript.Checked = !this.tbbSubScript.Checked;
                            if (tbbSubScript.Checked)
                            {
                                this.txtComentarios.SetSubScript(true);
                                this.txtComentarios.SetSuperScript(false);
                            }
                            else
                            {
                                this.txtComentarios.SetSubScript(false);
                            }
                        }
                        break;
                    case "Left":
                        {
                            //change horizontal alignment to left
                            this.txtComentarios.SelectionAlignment = HorizontalAlignment.Left;
                        }
                        break;
                    case "Right":
                        {
                            //change horizontal alignment to right
                            this.txtComentarios.SelectionAlignment = HorizontalAlignment.Right;
                        }
                        break;
                    case "Center":
                        {
                            //change horizontal alignment to center
                            this.txtComentarios.SelectionAlignment = HorizontalAlignment.Center;
                        }
                        break;
                    case "Font":
                        {
                            if (this.txtComentarios.SelectionFont != null)
                                fontDialog1.Font = this.txtComentarios.SelectionFont;
                            else
                                fontDialog1.Font = this.txtComentarios.Font;

                            if (fontDialog1.ShowDialog() == DialogResult.OK)
                            {
                                if (this.txtComentarios.SelectionFont != null)
                                    this.txtComentarios.SelectionFont = fontDialog1.Font;
                                else
                                    this.txtComentarios.Font = fontDialog1.Font;
                            }
                        }
                        break;
                    case "Color":
                        {
                            colorDialog1.Color = this.txtComentarios.SelectionColor;

                            if (colorDialog1.ShowDialog() == DialogResult.OK)
                            {
                                this.txtComentarios.SelectionColor = colorDialog1.Color;
                            }
                        }
                        break;
                }
                UpdateToolbar();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaNotificacion ~ tb_Click");
            }
        }
        private void UpdateToolbar()
        {
            try
            {
                Font fnt;
                if (this.txtComentarios.SelectionFont != null)
                    fnt = this.txtComentarios.SelectionFont;
                else
                    fnt = this.txtComentarios.Font;

                //Do all the toolbar button checks
                tbbBold.Checked = fnt.Bold; //bold button
                tbbItalic.Checked = fnt.Italic; //italic button
                tbbUnderline.Checked = fnt.Underline; //underline button
                tbbStrikeout.Checked = fnt.Strikeout; //strikeout button
                tbbLeft.Checked = (this.txtComentarios.SelectionAlignment == HorizontalAlignment.Left); //justify left
                tbbCenter.Checked = (this.txtComentarios.SelectionAlignment == HorizontalAlignment.Center); //justify center
                tbbRight.Checked = (this.txtComentarios.SelectionAlignment == HorizontalAlignment.Right); //justify right

                tbbSuperScript.Checked = this.txtComentarios.IsSuperScript();
                tbbSubScript.Checked = this.txtComentarios.IsSubScript();
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
                LogError.AddExcFileTxt(ex, "frmNuevaNotificacion ~ btnCancelar_Click");
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
                    Notificaciones DatosAux = this.ObtenerDatos();
                    Notificaciones_Negocio NN = new Notificaciones_Negocio();
                    NN.Notificaciones(DatosAux);
                    if (DatosAux.Completado)
                    {
                        foreach (DataRow notificacion in DatosAux.tablaNotificaciones.Rows)
                        {
                            int IDTipoCelular = 0, Badge = 0;
                            IDTipoCelular = Convert.ToInt32(notificacion["id_tipoCelular"].ToString());
                            Badge = Convert.ToInt32(notificacion["Badge"].ToString());
                            EnviaNotificaciones.EnviarMensaje(notificacion["tokenCelular"].ToString(), notificacion["nombre"].ToString(), notificacion["descripcion"].ToString(), Badge, IDTipoCelular);
                        }
                        MessageBox.Show("Notificacion enviada correctamente", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al enviar la notificación. Contacte a Soporte Técnico.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaNotificacion ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)Keys.Enter)
                    this.btnGuardar_Click(this.btnGuardar, new EventArgs());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaNotificacion ~ txtDescripcion_KeyPress");
            }
        }

        private void btnElegirCliente_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeleccionarCliente ElegirProducto = new frmSeleccionarCliente();
                ElegirProducto.Location = this.txtCliente.PointToScreen(new Point());
                ElegirProducto.Location = new Point(ElegirProducto.Location.X - 1, ElegirProducto.Location.Y - 2);
                ElegirProducto.ShowDialog();
                ElegirProducto.Dispose();
                if (ElegirProducto.DialogResult == DialogResult.OK)
                {
                    Cliente Aux = ElegirProducto.Datos;
                    this.CatalogoActual = Aux;
                    this.txtCliente.Text = Aux.Nombre;
                    this.txtNombreNotificacion.Focus();
                }
                else
                {
                    this.CatalogoActual = new Cliente();
                    this.txtCliente.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaNotificacion ~ btnElegirCliente_Click");
            }
        }
        #endregion
    }
}
