using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using StephManager.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephManager
{
    public partial class frmNuevaReglaComision : Form
    {
        #region Variables

        private Comision Datos = new Comision();
        private bool NuevoRegistro = false;
        private Producto DatosProducto = new Producto();

        #endregion

        #region Constructor

        public frmNuevaReglaComision()
        {
            try
            {
                InitializeComponent();
                NuevoRegistro = true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaReglaComision ~ frmNuevaReglaComision()");
            }
        }

        public frmNuevaReglaComision(Comision DatosAux)
        {
            try
            {
                InitializeComponent();
                Datos = DatosAux;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaReglaComision ~ frmNuevaReglaComision()");
            }
        }

        #endregion

        #region Métodos

        private void CargarDatos()
        {
            try
            {
                if (this.ExisteItemEnComboTipoComision(this.Datos.IDTipoComision))
                    this.cmbTipoComision.SelectedValue = Datos.IDTipoComision;
                if (this.ExisteItemEnComboPuestos(this.Datos.IDPuesto))
                    this.cmbCatPuesto.SelectedValue = this.Datos.IDPuesto;
                if (this.ExisteItemEnComboCategoriaPuesto(this.Datos.IDCategoria))
                    this.cmbCategoriaPuesto.SelectedValue = this.Datos.IDCategoria;
                this.DatosProducto = new Producto { IDProducto = this.Datos.IDProducto, NombreProducto = this.Datos.ProductoDesc };
                this.txtProducto.Text = this.DatosProducto.NombreProducto;
                if (this.Datos.EsPorcentaje)
                {
                    this.rbPorcentaje.Checked = true;
                    this.txtPorcentaje.ReadOnly = false;
                    this.txtPorcentaje.Text = string.Format("{0:P}", this.Datos.Porcentaje);
                    this.rbMonto.Checked = false;
                    this.txtMonto.ReadOnly = true;
                    this.txtMonto.Text = string.Format("{0:c}", 0);
                }
                else
                {
                    this.rbPorcentaje.Checked = false;
                    this.txtPorcentaje.ReadOnly = true;
                    this.txtPorcentaje.Text = string.Format("{0:P}", 0);
                    this.rbMonto.Checked = true;
                    this.txtMonto.ReadOnly = false;
                    this.txtMonto.Text = string.Format("{0:c}", this.Datos.Monto);
                }
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

        private bool ExisteItemEnComboTipoComision(int ID)
        {
            try
            {
                foreach (Comision Item in this.cmbTipoComision.Items)
                {
                    if (Item.IDTipoComision == ID)
                        return true;
                }
                return false;
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
                this.txtPorcentaje.ReadOnly = true;
                this.txtMonto.ReadOnly = true;
                this.txtPorcentaje.Text = string.Format("{0:P}", 0);
                this.txtMonto.Text = string.Format("{0:c}", 0);
                this.rbPorcentaje.Checked = true;
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
                this.LlenarComboCatPuestos();
                this.LlenarComboCatTipoComision();
                if (this.NuevoRegistro)
                    this.IniciarDatos();
                else
                    this.CargarDatos();
                this.ActiveControl = this.cmbTipoComision;
                this.cmbTipoComision.Focus();
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

        private void LlenarComboCatTipoComision()
        {
            try
            {
                Comision DatosAux = new Comision { Conexion = Comun.Conexion, IncluirSelect = true };
                Comision_Negocio CN = new Comision_Negocio();
                this.cmbTipoComision.DataSource = CN.ObtenerComboTipoComision(DatosAux);
                this.cmbTipoComision.DisplayMember = "TipoComisionDesc";
                this.cmbTipoComision.ValueMember = "IDTipoComision";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Puestos ObtenerPuestoSeleccionado()
        {
            try
            {
                Puestos Puesto = new Puestos();
                if (this.cmbCatPuesto.Items.Count > 0)
                    if (this.cmbCatPuesto.SelectedIndex != -1)
                        Puesto = (Puestos)this.cmbCatPuesto.SelectedItem;
                return Puesto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private CategoriasPuesto ObtenerCategoriaSeleccionada()
        {
            try
            {
                CategoriasPuesto Categoria = new CategoriasPuesto();
                if (this.cmbCategoriaPuesto.Items.Count > 0)
                    if (this.cmbCategoriaPuesto.SelectedIndex != -1)
                        Categoria = (CategoriasPuesto)this.cmbCategoriaPuesto.SelectedItem;
                return Categoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Comision ObtenerTipoComisionSeleccionada()
        {
            try
            {
                Comision ComisionTipo = new Comision();
                if (this.cmbTipoComision.Items.Count > 0)
                    if (this.cmbTipoComision.SelectedIndex != -1)
                        ComisionTipo = (Comision)this.cmbTipoComision.SelectedItem;
                return ComisionTipo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerMontoComision()
        {
            try
            {
                decimal Monto = 0;
                decimal.TryParse(this.txtMonto.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Monto);
                return Monto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal ObtenerMontoPorcentaje()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (char c in this.txtPorcentaje.Text) 
                {
                    if (c != '%')
                    {
                        sb.Append(c);
                    }
                }
                decimal Porcentaje = 0;
                decimal.TryParse(sb.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out Porcentaje);
                return Porcentaje;
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

        private Comision ObtenerDatos()
        {
            try
            {
                Comision DatosAux = new Comision();                
                Puestos PT = this.ObtenerPuestoSeleccionado();
                CategoriasPuesto CP = this.ObtenerCategoriaSeleccionada();
                Comision TC = this.ObtenerTipoComisionSeleccionada();
                DatosAux.NuevoRegistro = this.NuevoRegistro;
                DatosAux.IDComisionXCategoria = this.NuevoRegistro ? string.Empty : this.Datos.IDComisionXCategoria;
                DatosAux.IDPuesto = PT.IDPuesto;
                DatosAux.IDCategoria = CP.IDCategoria;
                DatosAux.IDTipoComision = TC.IDTipoComision;
                DatosAux.IDProducto = string.IsNullOrEmpty(this.DatosProducto.IDProducto) ? string.Empty : this.DatosProducto.IDProducto;
                DatosAux.EsPorcentaje = this.rbPorcentaje.Checked;
                DatosAux.Monto = this.ObtenerMontoComision();
                DatosAux.Porcentaje = this.ObtenerMontoPorcentaje() / 100;
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
                int aux = 0;
                
                Puestos AuxPT = this.ObtenerPuestoSeleccionado();
                CategoriasPuesto AuxCP = this.ObtenerCategoriaSeleccionada();                
                if (AuxPT.IDPuesto == 0)
                    Errores.Add(new Error { Numero = (aux += 1), Descripcion = "Seleccione un puesto.", ControlSender = this.cmbCatPuesto });
                if (string.IsNullOrEmpty(AuxCP.IDCategoria))
                    Errores.Add(new Error { Numero = (aux += 1), Descripcion = "Seleccione una categoría.", ControlSender = this.cmbCategoriaPuesto });
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
                LogError.AddExcFileTxt(ex, "frmNuevaReglaComision ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElegirProducto_Click(object sender, EventArgs e)
        {
            try
            {
                Comision Aux = this.ObtenerTipoComisionSeleccionada();
                if (Aux.IDTipoComision != 0)
                {
                    int TipoForm = 0;

                    switch (Aux.IDTipoComision)
                    {
                        case 1:
                        case 4: TipoForm = 10; //Productos
                            break;
                        case 2:
                        case 5: TipoForm = 2; //Productos
                            break;
                    }
                    if (TipoForm > 0)
                    {
                        frmSeleccionarProducto ElegirProducto = new frmSeleccionarProducto(TipoForm);
                        ElegirProducto.Location = this.txtProducto.PointToScreen(new Point());
                        ElegirProducto.Location = new Point(ElegirProducto.Location.X - 1, ElegirProducto.Location.Y - 2);
                        ElegirProducto.ShowDialog();
                        ElegirProducto.Dispose();
                        if (ElegirProducto.DialogResult == DialogResult.OK)
                        {
                            this.DatosProducto = ElegirProducto.Datos;
                            this.txtProducto.Text = this.DatosProducto.NombreProducto;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaReglaComision ~ btnElegirProducto_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                    Comision Datos = this.ObtenerDatos();
                    Comision_Negocio UN = new Comision_Negocio();
                    UN.ACReglasComision(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (Datos.Resultado == 0)
                        {
                            MessageBox.Show("La regla de comisiones ya existe", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                LogError.AddExcFileTxt(ex, "frmNuevaReglaComision ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                LogError.AddExcFileTxt(ex, "frmAltaNominal ~ cmbCatPuesto_SelectedIndexChanged");
            }
        }

        private void cmbTipoComision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.DatosProducto = new Producto();
                this.txtProducto.Text = string.Empty;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaReglaComision ~ cmbTipoComision_SelectedIndexChanged");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTipoComision_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.cmbTipoComision.SelectedIndex == -1)
                {
                    this.DatosProducto = new Producto();
                    this.txtProducto.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaReglaComision ~ cmbTipoComision_Validating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNuevaReglaComision_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaReglaComision ~ frmNuevaReglaComision_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbPorcentaje_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rbPorcentaje.Checked == true)
                {
                    this.txtPorcentaje.ReadOnly = false;
                    this.txtMonto.Text = string.Format("{0:c}", 0);
                    this.txtMonto.ReadOnly = true;
                    this.txtPorcentaje.Focus();
                }
                else
                {
                    this.txtPorcentaje.ReadOnly = true;
                    this.txtPorcentaje.Text = string.Format("{0:P}", 0);
                    this.txtMonto.ReadOnly = false;
                    this.txtMonto.Focus();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaReglaComision ~ cmbTipoComision_Validating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMonto_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                this.txtMonto.Text = string.Format("{0:c}", this.ObtenerMontoComision());
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaReglaComision ~ txtPorcentaje_Validating");
            }
        }

        private void txtPorcentaje_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                decimal Porcentaje = this.ObtenerMontoPorcentaje();
                Porcentaje = Porcentaje / 100;
                this.txtPorcentaje.Text = string.Format("{0:P}", Porcentaje);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaReglaComision ~ txtPorcentaje_Validating");
            }
        }

        #endregion

    }
}