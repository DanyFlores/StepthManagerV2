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
using System.Drawing.Imaging;
using System.IO;


namespace StephManager
{
    public partial class frmCatEmpleadoHuella : Form
    {
        #region Variables
        public LectorHuella Lector = new LectorHuella();
        public bool ModificarHuella = false;
        private Usuario DatosEmpleado = new Usuario();
        #endregion

        #region Constructor

        public frmCatEmpleadoHuella(Usuario DatosAux)
        {
            try
            {
                InitializeComponent();
                DatosEmpleado = DatosAux;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleadoHuella ~ frmCatEmpleadoHuella(Usuario DatosAux)");
            }
        }

        #endregion

        #region Métodos

        private void CargarDatos()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.DatosEmpleado.IDEmpleado))
                {
                    if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Huella\" + this.DatosEmpleado.IDEmpleado + ".png")))
                        this.ImgHuella.ImageLocation = Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Huella\" + this.DatosEmpleado.IDEmpleado + ".png");
                    else
                        this.CrearImagenEmpleado(this.DatosEmpleado.IDEmpleado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CrearImagenEmpleado(string ID)
        {
            try
            {
                Usuario DatosAux = new Usuario { IDEmpleado = ID, Conexion = Comun.Conexion };
                Usuario_Negocio UN = new Usuario_Negocio();
                UN.ObtenerHuellaDigitalXIDEmpleado(DatosAux);
                if (DatosAux.Completado)
                {
                    if (DatosAux.BufferHuella.Length > 0)
                    {
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(DatosAux.BufferHuella);
                        Image.FromStream(ms).Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Huella\" + this.DatosEmpleado.IDEmpleado + ".png"));
                    }
                    if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Huella\" + this.DatosEmpleado.IDEmpleado + ".png")))
                        this.ImgHuella.ImageLocation = Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Huella\" + this.DatosEmpleado.IDEmpleado + ".png");
                }
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
                //this.CargarDatos();
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

        #endregion

        #region Eventos

        private void bgwHuella_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
               Lector.FrmCapturaHuella = this;
               Lector.TipoForm = 2;
               if (!Lector.Init())
               {
                   this.lblInstrucciones.Text = "No se puede iniciar la operación de captura.";
                   this.lblInstrucciones.BackColor = Color.Red;
               }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleadoHuella ~ bgwHuella_DoWork");
            }
        }

        private void bgwHuella_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Lector.Start();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleadoHuella ~ bgwHuella_RunWorkerCompleted");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleadoHuella ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Comprimir la imagen
                Image ImagenHuella = ComprimirImagen.ResizeImage(this.ImgHuella.Image, 250, 250, ImageFormat.Png);
                //Guardarla en una ruta especifica
                ImagenHuella.Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Huella\" + this.DatosEmpleado.IDEmpleado + ".png"));
                //Obtener la imagen en bytes
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ImagenHuella.Save(ms, ImageFormat.Png);
                this.DatosEmpleado.BufferHuella = ms.GetBuffer();
                this.DatosEmpleado.IDUsuario = Comun.IDUsuario;
                this.DatosEmpleado.Conexion = Comun.Conexion;

                MemoryStream fingerprintData = new MemoryStream();
                Lector.Template.Serialize(fingerprintData);
                fingerprintData.Position = 0;
                BinaryReader br = new BinaryReader(fingerprintData);
                byte[] bytes = br.ReadBytes((Int32)fingerprintData.Length);
                this.DatosEmpleado.HuellaString = ConvertirStringToBytes.getString(bytes);               
                Usuario_Negocio UN = new Usuario_Negocio();
                UN.AsignarHuellaXIDEmpleado(DatosEmpleado);
                if (this.DatosEmpleado.Completado)
                {
                    MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al guardar los datos. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleadoHuella ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCatEmpleadoHuella_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Lector.Stop();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleadoHuella ~ frmCatEmpleadoHuella_FormClosing");
            }
        }

        public void frmCatEmpleadoHuella_Load(object sender, EventArgs e)
        {
            try
            {
                this.bgwHuella.RunWorkerAsync();
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatEmpleadoHuella ~ frmCatEmpleadoHuella_Load");
            }
        }

        #endregion
    }
}
