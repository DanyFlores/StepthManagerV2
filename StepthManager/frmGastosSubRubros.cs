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
    public partial class frmGastosSubRubros : Form
    {
        #region Propiedades / Variables
        private int TipoForm = 0;
        private Subrubro _DatosSubRubro;
        public Subrubro DatosSubRubro
        {
            get { return _DatosSubRubro; }
            set { _DatosSubRubro = value; }
        }        
        #endregion

        #region Constructor

        public frmGastosSubRubros()
        {
            try
            {
                InitializeComponent();
                this.TipoForm = 1;
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaTarjeta ~ frmNuevaTarjeta()");
            }
        }

        public frmGastosSubRubros(Subrubro Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosSubRubro = Datos;
                this.TipoForm = 2;
                this.IniciarForm();
                this.CargarDatosAModificar(Datos);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaTarjeta ~ frmNuevaTarjeta(TarjetaMonedero Datos)");
            }
        }

        #endregion

        #region Métodos

        private void CargarDatosAModificar(Subrubro Datos)
        {
            try
            {
                this.txtSubRubro.Text = Datos.Descripcion;
                if(this.ExisteItemEnComboRubro(Datos.IDRubro))
                    this.cmbRubro.SelectedValue = Datos.IDRubro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ExisteItemEnComboRubro(int ID)
        {
            try
            {
                bool Band = false;
                foreach (Rubro Item in this.cmbRubro.Items)
                {
                    if (Item.IDRubro == ID)
                    {
                        Band = true;
                        break;
                    }
                }
                return Band;
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
                this.CargarComboRubro();
                this.ActiveControl = this.cmbRubro;
                this.cmbRubro.Focus();
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

        private void CargarComboRubro()
        {
            try
            {
                Rubro Datos = new Rubro { Conexion = Comun.Conexion, IncluirSelect = true };
                Gastos_Negocio GN = new Gastos_Negocio();
                this.cmbRubro.DataSource = GN.ObtenerComboRubros(Datos);
                this.cmbRubro.DisplayMember = "Descripcion";
                this.cmbRubro.ValueMember = "IDRubro";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private Rubro ObtenerRubroCombo()
        {
            try
            {
                Rubro DatosAux = new Rubro();
                if (this.cmbRubro.Items.Count > 0)
                {
                    if (this.cmbRubro.SelectedIndex != -1)
                    {
                        DatosAux = (Rubro)this.cmbRubro.SelectedItem;
                    }
                }
                return DatosAux;
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

        private Subrubro ObtenerDatos()
        {
            try
            {
                Subrubro DatosAux = new Subrubro();
                DatosAux.IDSubrubro = TipoForm == 2 ? this._DatosSubRubro.IDSubrubro : string.Empty;
                Rubro DatosSuc = this.ObtenerRubroCombo();
                DatosAux.Descripcion = this.txtSubRubro.Text.Trim();
                DatosAux.IDRubro = DatosSuc.IDRubro;
                DatosAux.Rubro = DatosSuc.Descripcion;
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
                if (this.cmbRubro.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción válida.", ControlSender = this.cmbRubro });
                else
                {
                    int IDTipoMonedero = 0;
                    int.TryParse(this.cmbRubro.SelectedValue.ToString().Trim(), out IDTipoMonedero);
                    if (IDTipoMonedero == 0)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción válida.", ControlSender = this.cmbRubro });
                }
                if (string.IsNullOrEmpty(this.txtSubRubro.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un SubRubro Valido.", ControlSender = this.txtSubRubro });
                else
                    if(!Validar.IsValidDescripcion(this.txtSubRubro.Text))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un SubRubro Valido.", ControlSender = this.txtSubRubro });
                
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
                LogError.AddExcFileTxt(ex, "frmNuevaTarjeta ~ btnCancelar_Click");
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
                    Subrubro Datos = this.ObtenerDatos();
                    Catalogo_Negocio cn = new Catalogo_Negocio();
                    cn.ABCGastosSubRubros(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosSubRubro = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        List<Error> LstError = new List<Error>();
                        LstError.Add(new Error { Numero = 1, Descripcion = "El número de tarjeta ingresado ya existe. ", ControlSender = this.txtSubRubro });
                        this.MostrarMensajeError(LstError);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaTarjeta ~ btnGuardar_Click");
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
                LogError.AddExcFileTxt(ex, "frmNuevaTarjeta ~ txtDescripcion_KeyPress");
            }
        }

        #endregion

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
