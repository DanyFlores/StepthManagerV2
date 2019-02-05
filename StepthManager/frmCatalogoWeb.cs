using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using StephManager.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephManager
{
    public partial class frmCatalogoWeb : Form
    {
        #region Variables

        private bool Busqueda = false;
        private string TextoBusq = string.Empty;

        #endregion

        #region Constructor

        public frmCatalogoWeb()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogoWeb ~ frmCatalogoWeb()");
            }
        }

        #endregion

        #region Métodos

        private void CargarGridCatalogo()
        {
            try
            {
                CatalogoWeb Aux = new CatalogoWeb { Conexion = Comun.Conexion};
                CatalogoWeb_Negocio CWN = new CatalogoWeb_Negocio();
                List<CatalogoWeb> Lista = CWN.ObtenerCatalogoWeb(Aux);
                foreach (CatalogoWeb Item in Lista)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(Item.BufferImagen);
                    Item.ImagenMin = Image.FromStream(ms);
                    Item.ImagenDGV = ComprimirImagen.ResizeImage(Item.ImagenMin, 40, 40);
                }
                this.dgvCatalogoWeb.DataSource = null;
                this.dgvCatalogoWeb.AutoGenerateColumns = false;
                this.dgvCatalogoWeb.DataSource = Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridCatalogoBusq(string TextoBusqueda)
        {
            try
            {
                CatalogoWeb Aux = new CatalogoWeb { Conexion = Comun.Conexion,  Tag = TextoBusqueda };
                CatalogoWeb_Negocio CWN = new CatalogoWeb_Negocio();
                List<CatalogoWeb> Lista = CWN.ObtenerCatalogoWebBusq(Aux);
                foreach (CatalogoWeb Item in Lista)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(Item.BufferImagen);
                    Item.ImagenMin = Image.FromStream(ms);
                    Item.ImagenDGV = ComprimirImagen.ResizeImage(Item.ImagenMin, 40, 40);
                }
                this.dgvCatalogoWeb.DataSource = null;
                this.dgvCatalogoWeb.AutoGenerateColumns = false;
                this.dgvCatalogoWeb.DataSource = Lista;
                this.TextoBusq = TextoBusqueda;
                this.Busqueda = true;
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
                this.CargarGridCatalogo();
                this.ActiveControl = this.txtTagBusqueda;
                this.txtTagBusqueda.Focus();
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

        private CatalogoWeb ObtenerDatosGrid(int RowIndex)
        {
            try
            {
                CatalogoWeb DatosAux = new CatalogoWeb();
                List<CatalogoWeb> Lista = (List<CatalogoWeb>)this.dgvCatalogoWeb.DataSource;
                DatosAux = Lista[RowIndex];
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtTagBusqueda.Text.Trim()))
                {
                    this.CargarGridCatalogoBusq(this.txtTagBusqueda.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogoWeb ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCatalogoWeb.SelectedRows.Count == 1)
                {
                    int RowIndex = this.dgvCatalogoWeb.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    CatalogoWeb Datos = this.ObtenerDatosGrid(RowIndex);
                    Datos.Conexion = Comun.Conexion;
                    Datos.IDUsuario = Comun.IDUsuario;
                    CatalogoWeb_Negocio CWN = new CatalogoWeb_Negocio();
                    CWN.EliminarCatalogoWeb(Datos);
                    if (Datos.Completado)
                    {
                        if (Busqueda)
                            CargarGridCatalogoBusq(TextoBusq);
                        else
                            CargarGridCatalogo();
                    }
                    else
                        MessageBox.Show("Ocurrió un error al eliminar el registro. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogoWeb ~ btnEliminar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvCatalogoWeb.SelectedRows.Count == 1)
                {
                    int RowIndex = this.dgvCatalogoWeb.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    CatalogoWeb Datos = this.ObtenerDatosGrid(RowIndex);
                    frmNuevaImagenCatWeb NImagenWeb = new frmNuevaImagenCatWeb(Datos);
                    NImagenWeb.ShowDialog();
                    NImagenWeb.Dispose();
                    if (NImagenWeb.DialogResult == DialogResult.OK)
                    {
                         if (Busqueda)
                             CargarGridCatalogoBusq(TextoBusq);
                         else
                             CargarGridCatalogo();
                        //Datos.Tag = NImagenWeb.DatosCatWeb.Tag;
                        //Datos.Descripcion = NImagenWeb.DatosCatWeb.Descripcion;
                        //Datos.Alt = NImagenWeb.DatosCatWeb.Alt;
                        //Datos.Title = NImagenWeb.DatosCatWeb.Title;
                        //Datos.NombreArchivo = NImagenWeb.DatosCatWeb.NombreArchivo;
                        //Datos.NombrePagina = NImagenWeb.DatosCatWeb.NombrePagina;
                        //Datos.TipoArchivo = NImagenWeb.DatosCatWeb.TipoArchivo;
                        ////Datos.PublicarImagen = NImagenWeb.DatosCatWeb.PublicarImagen;
                        //if (Datos.ModificarImagen)
                        //{
                        //    Datos.ImagenMin = NImagenWeb.DatosCatWeb.ImagenMin;
                        //    Datos.ImagenDGV = ComprimirImagen.ResizeImage(Datos.ImagenMin, 40, 40);
                        //}
                        //List<CatalogoWeb> Lista = (List<CatalogoWeb>)this.dgvCatalogoWeb.DataSource;
                        //this.dgvCatalogoWeb.DataSource = null;
                        //this.dgvCatalogoWeb.DataSource = Lista;
                        //this.dgvCatalogoWeb.Rows[RowIndex].Selected = true;
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogoWeb ~ btnModificar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void btnNuevo_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        frmNuevaImagenCatWeb NImagenWeb = new frmNuevaImagenCatWeb();
        //        NImagenWeb.ShowDialog();
        //        NImagenWeb.Dispose();
        //        if (NImagenWeb.DialogResult == DialogResult.OK)
        //        {
        //            if (Busqueda)
        //                CargarGridCatalogoBusq(TextoBusq);
        //            else
        //                CargarGridCatalogo();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError.AddExcFileTxt(ex, "frmCatalogoWeb ~ btnNuevo_Click");
        //        MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogoWeb ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarBusq_Click(object sender, EventArgs e)
        {
            try
            {
                if (Busqueda)
                {
                    this.CargarGridCatalogo();
                    this.Busqueda = false;
                    this.txtTagBusqueda.Text = string.Empty;
                    this.txtTagBusqueda.Focus();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogoWeb ~ btnCancelarBusq_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCatalogoWeb_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogoWeb ~ frmCatalogoWeb_Load");
            }
        }

        private void txtTagBusqueda_KeyPress(object sender, KeyPressEventArgs e)
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
                LogError.AddExcFileTxt(ex, "frmCatalogoWeb ~ txtTagBusqueda_KeyPress");
            }
        }

        #endregion

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro que desea publicar la imagen?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (this.dgvCatalogoWeb.SelectedRows.Count == 1)
                    {
                        int RowIndex = this.dgvCatalogoWeb.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                        CatalogoWeb Datos = this.ObtenerDatosGrid(RowIndex);
                        Datos.Conexion = Comun.Conexion;
                        Datos.IDUsuario = Comun.IDUsuario;
                        Datos.UrlImagen = string.Empty;
                        if (Datos.PublicarImagen == true)
                        {
                            MessageBox.Show("La imagen ya fue publicada", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            CatalogoWeb_Negocio CWN = new CatalogoWeb_Negocio();
                            CWN.AprobarImagenCatalogoWeb(Datos);
                            if (Datos.Completado)
                            {
                                this.ObtenerImagen().Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\CatalogoWeb\" + Datos.NombreArchivo.ToLower() + "." + Datos.TipoArchivo));
                                UtilFtp.UploadFTP(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\CatalogoWeb\" + Datos.NombreArchivo + "." + Datos.TipoArchivo), ConfigurationManager.AppSettings.Get("ServerFtpTxt") + @"~/Images/Galeria/", ConfigurationManager.AppSettings.Get("UsuarioFtpTxt"), ConfigurationManager.AppSettings.Get("ContraseñaFtpTxt"));
                                if (Busqueda)
                                    CargarGridCatalogoBusq(TextoBusq);
                                else
                                    CargarGridCatalogo();
                            }
                            else
                            {
                                MessageBox.Show("Ocurrió un error al Aprobar la Imagen. Intente nuevamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                        MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCatalogoWeb ~ btnEliminar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image ObtenerImagen()
        {
            try
            {

                int RowIndex = this.dgvCatalogoWeb.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                CatalogoWeb Datos = this.ObtenerDatosGrid(RowIndex);
                ImageFormat Formato = ImageFormat.Jpeg;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(Datos.BufferImagen);
                Datos.Imagen = Image.FromStream(ms);
                return ComprimirImagen.ResizeImage(Datos.Imagen, 500, 500, Formato);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}