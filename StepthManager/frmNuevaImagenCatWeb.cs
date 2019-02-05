using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
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
using CreativaSL.Dll.Validaciones;

namespace StephManager
{
    public partial class frmNuevaImagenCatWeb : Form
    {
        #region Propiedades / Variables

        private bool NuevoRegistro = true;
        private CatalogoWeb _DatosCatWeb;
        public CatalogoWeb DatosCatWeb
        {
            get { return _DatosCatWeb; } 
            set { _DatosCatWeb = value; }
        }
        string FileName = string.Empty;
        string FileUrl = string.Empty;
        private bool ModificarImagen = false;

        private Producto CatalogoActual = new Producto();
        #endregion

        #region Constructor

        public frmNuevaImagenCatWeb()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaImagenCatWeb ~ frmNuevaImagenCatWeb()");
            }
        }

        public frmNuevaImagenCatWeb(CatalogoWeb Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosCatWeb = Datos;
                this.NuevoRegistro = false;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaImagenCatWeb ~ frmNuevaImagenCatWeb(CatalogoWeb Datos)");
            }
        }

        #endregion

        #region Métodos

        private void CargarDatosAModificar(CatalogoWeb Datos)
        {
            try
            {
                this.txtTagImagen.Enabled = false;
                this.txtTagImagen.Text = Datos.Tag;
                this.txtImagenDesc.Text = Datos.Descripcion;
                this.pbImagen.Image = Datos.ImagenMin;
                this.txtAlt.Text = Datos.Alt;
                this.txtTitle.Text = Datos.Title;
                this.txtNombreImagen.Text = Datos.NombreArchivo;
                this.txtProducto.Text = Datos.NombreServicio;
                this.CatalogoActual.IDProducto = Datos.IDProducto;
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
                if (NuevoRegistro)
                    this.InicializarCampos();
                else
                    this.CargarDatosAModificar(_DatosCatWeb);
                this.ActiveControl = this.txtTagImagen;
                this.txtTagImagen.Focus();
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
                this.txtTagImagen.Text = string.Empty;
                this.txtImagenDesc.Text = string.Empty;
                this.txtAlt.Text = string.Empty;
                this.txtTitle.Text = string.Empty;
                this.txtNombreImagen.Text = string.Empty;
                this.txtProducto.Text = string.Empty;
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

        private CatalogoWeb ObtenerDatos()
        {
            try
            {
                CatalogoWeb DatosAux = new CatalogoWeb();
                DatosAux.NuevoRegistro = NuevoRegistro;
                DatosAux.IDImagen = NuevoRegistro ? string.Empty : this._DatosCatWeb.IDImagen;
                DatosAux.Tag = this.txtTagImagen.Text.Trim();
                DatosAux.Alt = this.txtAlt.Text.Trim();
                DatosAux.Title = this.txtTitle.Text.Trim();
                DatosAux.NombreArchivo = Comun.RemoverAcentos(this.txtNombreImagen.Text.Trim());
                DatosAux.Descripcion = this.txtImagenDesc.Text.Trim();
                DatosAux.NombrePagina = Comun.RemoverSignosAcentos(this.txtTagImagen.Text.Trim());
                if (ModificarImagen)
                {
                    string Extension = Path.GetExtension(this.FileName);
                    ImageFormat Formato;
                    switch (Extension)
                    {
                        case ".jpg":
                        case ".jpeg": Formato = ImageFormat.Jpeg;
                            break;
                        case ".gif": Formato = ImageFormat.Gif;
                            break;
                        case ".png": Formato = ImageFormat.Png;
                            break;
                        default: Formato = ImageFormat.Jpeg;
                            break;
                    }
                    Image ImagenNormal = Image.FromFile(this.FileUrl);
                    Image ImagenMin = ClasesAux.ComprimirImagen.ResizeImage(ImagenNormal, 200, 150, Formato);
                    Image ImagenDGV = ClasesAux.ComprimirImagen.ResizeImage(ImagenNormal, 40, 40);
                    System.IO.MemoryStream MSNormal = new System.IO.MemoryStream();
                    System.IO.MemoryStream MSMin = new System.IO.MemoryStream();
                    ImagenNormal.Save(MSNormal, Formato);
                    ImagenMin.Save(MSMin, Formato);
                    DatosAux.Imagen = ImagenNormal;
                    DatosAux.ImagenMin = ImagenMin;
                    DatosAux.BufferImagen = MSNormal.GetBuffer();
                    DatosAux.BufferImagenMin = MSMin.GetBuffer();
                    DatosAux.TipoArchivo = Convert.ToString(Formato);
                }
                if (NuevoRegistro == false)
                {
                    DatosAux.TipoArchivo = this._DatosCatWeb.TipoArchivo;
                }
                DatosAux.ModificarImagen = this.ModificarImagen;
                DatosAux.IDProducto = this.CatalogoActual.IDProducto;
                DatosAux.IDSucursal = Comun.IDSucursalCaja;
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
                if(string.IsNullOrEmpty(this.txtTagImagen.Text))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el nombre de la imagen.", ControlSender = this.txtTagImagen });
                else
                {
                    if (!Validar.IsValidName(this.txtTagImagen.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el nombre de la imagen válido.", ControlSender = this.txtTagImagen });
                }
                if (string.IsNullOrEmpty(this.txtAlt.Text))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la etiqueta Alt.", ControlSender = this.txtAlt });
                else
                {
                    if (!Validar.IsValidDescripcion(this.txtAlt.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la etiqueta Alt válido.", ControlSender = this.txtAlt });
                }
                if (string.IsNullOrEmpty(this.txtTitle.Text))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la etiqueta Title.", ControlSender = this.txtTitle });
                else
                {
                    if (!Validar.IsValidDescripcion(this.txtTitle.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la etiqueta Title válido.", ControlSender = this.txtTitle });
                }
                if (string.IsNullOrEmpty(this.txtNombreImagen.Text))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el nombre de la imagen web.", ControlSender = this.txtNombreImagen });
                else
                {
                    if (!Validar.IsValidDescripcion(this.txtNombreImagen.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el nombre de la imagen web válido.", ControlSender = this.txtNombreImagen });
                }
                if(this.pbImagen.Image == null)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una imagen.", ControlSender = this.pbImagen });
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
                LogError.AddExcFileTxt(ex, "frmNuevaImagenCatWeb ~ btnCancelar_Click");
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
                    CatalogoWeb Datos = this.ObtenerDatos();
                    CatalogoWeb_Negocio CWN = new CatalogoWeb_Negocio();
                    CWN.ACCatalogoWeb(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosCatWeb = Datos;
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
                LogError.AddExcFileTxt(ex, "frmNuevaImagenCatWeb ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog BuscarImagen = new OpenFileDialog();
                BuscarImagen.Filter = "Archivos de Imagen |*.jpg;*.jpeg;";
                BuscarImagen.FileName = "";
                BuscarImagen.Title = "Subir Imagen Productos";
                if (BuscarImagen.ShowDialog() == DialogResult.OK)
                {
                    this.pbImagen.ImageLocation = BuscarImagen.FileName;
                    this.FileUrl = BuscarImagen.FileName;
                    this.FileName = BuscarImagen.SafeFileName;
                    this.ModificarImagen = true;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaImagenCatWeb ~ btnAgregar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevaImagenCatWeb_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaImagenCatWeb ~ frmNuevaImagenCatWeb_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnElegirProducto_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeleccionarProducto ElegirProducto = new frmSeleccionarProducto(2);
                ElegirProducto.Location = this.txtProducto.PointToScreen(new Point());
                ElegirProducto.Location = new Point(ElegirProducto.Location.X - 1, ElegirProducto.Location.Y - 2);
                ElegirProducto.ShowDialog();
                ElegirProducto.Dispose();
                if (ElegirProducto.DialogResult == DialogResult.OK)
                {
                    Producto Aux = ElegirProducto.Datos;
                    this.CatalogoActual = Aux;
                    this.txtProducto.Text = Aux.NombreProducto;
                    //this.txtClave.Text = Aux.Clave;
                    this.txtImagenDesc.Focus();
                }
                else
                {
                    this.CatalogoActual = new Producto();
                    this.txtProducto.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaImagenCatWeb ~ btnElegirProducto_Click");
            }
        }

    }
}
