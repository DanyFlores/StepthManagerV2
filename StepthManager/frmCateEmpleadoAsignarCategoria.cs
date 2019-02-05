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
    public partial class frmCateEmpleadoAsignarCategoria : Form
    {
        private Usuario Empleado = new Usuario();

        public frmCateEmpleadoAsignarCategoria(Usuario DatosAux)
        {
            try
            {
                InitializeComponent();
                Empleado = DatosAux;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCateEmpleadoAsignarCategoria ~ frmCateEmpleadoAsignarCategoria()");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                    Usuario Datos = this.ObtenerDatos();
                    Usuario_Negocio UN = new Usuario_Negocio();
                    UN.AsignarCategoria(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCateEmpleadoAsignarCategoria ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                LogError.AddExcFileTxt(ex, "frmCateEmpleadoAsignarCategoria ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAltaNominal_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCateEmpleadoAsignarCategoria ~ frmAltaNominal_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatos()
        {
            try
            {
                this.txtEmpleado.Text = this.Empleado.Nombre + " " + this.Empleado.ApellidoPat + " " + this.Empleado.ApellidoMat;
                if (this.ExisteItemEnComboPuestos(this.Empleado.IDPuesto))
                    this.cmbCatPuesto.SelectedValue = this.Empleado.IDPuesto;
                if (this.ExisteItemEnComboCategoriaPuesto(this.Empleado.IDCategoriaPuesto))
                    this.cmbCategoriaPuesto.SelectedValue = this.Empleado.IDCategoriaPuesto;
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

        private void IniciarForm()
        {
            try
            {
                this.LlenarComboCatPuestos();
                this.CargarDatos();
                this.ActiveControl = this.cmbCatPuesto;
                this.cmbCatPuesto.Focus();
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

        private decimal ObtenerSueldo()
        {
            try
            {
                decimal Sueldo = 0;
                decimal.TryParse(this.txtSueldoBase.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Sueldo);
                return Sueldo;
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

        private Usuario ObtenerDatos()
        {
            try
            {
                Usuario DatosAux = new Usuario();
                Puestos PT = this.ObtenerPuestoSeleccionado();
                CategoriasPuesto CP = this.ObtenerCategoriaSeleccionada();
                DatosAux.IDEmpleado = this.Empleado.IDEmpleado;
                DatosAux.IDPuesto = PT.IDPuesto;
                DatosAux.IDCategoriaPuesto = CP.IDCategoria;
                DatosAux.SueldoBase = this.ObtenerSueldo();
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

        private void cmbCategoriaPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                decimal SueldoBase = 0;
                if (this.cmbCategoriaPuesto.Items.Count > 0)
                {
                    if (this.cmbCategoriaPuesto.SelectedIndex != -1)
                    {
                        CategoriasPuesto Item = (CategoriasPuesto)this.cmbCategoriaPuesto.SelectedItem;
                        SueldoBase = Item.SueldoBase;
                    }
                }
                this.txtSueldoBase.Text = string.Format("{0:c}", SueldoBase);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmAltaNominal ~ cmbCategoriaPuesto_SelectedIndexChanged");
            }
        }
    }
}