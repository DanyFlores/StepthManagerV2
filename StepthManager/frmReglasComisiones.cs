using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using StephManager.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephManager
{
    public partial class frmReglasComisiones : Form
    {
        public frmReglasComisiones()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReglasComisiones ~ frmReglasComisiones()");
            }
        }

        private void IniciarDatosBusqueda()
        {
            try
            {
                this.tcCompras.SelectedIndex = 0;
                if (this.cmbCatPuesto.Items.Count > 0)
                    this.cmbCatPuesto.SelectedIndex = 0;
                if (this.cmbCategoriaPuesto.Items.Count > 0)
                    this.cmbCategoriaPuesto.SelectedIndex = 0;
                this.txtNumFactura.Text = string.Empty;
                //this.dgvReglasCategoria.DataSource = null;
                //this.dgvReglasCategoria.AutoGenerateColumns = false;
                //this.dgvReglasCategoria.DataSource = new List<Comision>();
                this.LLenarGridComisionXIDCategoria();
                this.dgvReglasEmpleado.DataSource = null;
                this.dgvReglasEmpleado.AutoGenerateColumns = false;
                this.dgvReglasEmpleado.DataSource = new List<Comision>();
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

        private void LLenarGridComisionXIDCategoria()
        {
            try
            {
                CategoriasPuesto Aux = this.ObtenerCategoriaSeleccionada();
                //if (!string.IsNullOrEmpty(Aux.IDCategoria))
                //{
                    Comision Datos = new Comision { Conexion = Comun.Conexion, IDCategoria = Aux.IDCategoria };
                    Comision_Negocio CN = new Comision_Negocio();
                    List<Comision> Lista = CN.ObtenerComisionesXIDCategoria(Datos);
                    BindingSource DatosGrid = new BindingSource();
                    DatosGrid.DataSource = Lista;
                    this.dgvReglasCategoria.AutoGenerateColumns = false;
                    this.dgvReglasCategoria.DataSource = DatosGrid;
                //}
                //else
                //{
                //    MessageBox.Show("Debe seleccionar una categoría. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LLenarGridComisionXEmpleado()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtNumFactura.Text.Trim()))
                {
                    Comision Datos = new Comision { Conexion = Comun.Conexion, NombreEmpleado = this.txtNumFactura.Text.Trim() };
                    Comision_Negocio CN = new Comision_Negocio();
                    List<Comision> Lista = CN.ObtenerComisionesXEmpleado(Datos);
                    BindingSource DatosGrid = new BindingSource();
                    DatosGrid.DataSource = Lista;
                    this.dgvReglasEmpleado.AutoGenerateColumns = false;
                    this.dgvReglasEmpleado.DataSource = DatosGrid;
                }
                else
                {
                    MessageBox.Show("Ingrese un nombre. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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

        private Comision ObtenerDatosGridCategoria(int Row)
        {
            try
            {

                int Tab = this.tcCompras.SelectedIndex;
                Comision Datos = new Comision();
                if (Row != -1)
                {
                    DataGridViewRow Fila;
                    if(Tab == 0)
                        Fila = this.dgvReglasCategoria.Rows[Row];
                    else
                        Fila = this.dgvReglasEmpleado.Rows[Row];
                    int IDPuesto = 0, IDTipoComision = 0;
                    bool EsPorcentaje = false;
                    decimal Monto = 0, Porcentaje = 0;
                    int.TryParse(Fila.Cells["IDPuesto" + Tab].Value.ToString(), out IDPuesto);
                    int.TryParse(Fila.Cells["IDTipoComision" + Tab].Value.ToString(), out IDTipoComision);
                    bool.TryParse(Fila.Cells["EsPorcentaje" + Tab].Value.ToString(), out EsPorcentaje);
                    decimal.TryParse(Fila.Cells["Porcentaje" + Tab].Value.ToString(), out Porcentaje);
                    decimal.TryParse(Fila.Cells["Monto" + Tab].Value.ToString(), out Monto);
                    Datos.IDComisionXCategoria = Fila.Cells["IDComisionXCategoria" + Tab].Value.ToString();
                    Datos.IDProducto = Fila.Cells["IDProducto" + Tab].Value.ToString();
                    Datos.ProductoDesc = Fila.Cells["NombreProducto" + Tab].Value.ToString();
                    Datos.IDCategoria = Fila.Cells["IDCategoria" + Tab].Value.ToString();
                    Datos.IDPuesto = IDPuesto;
                    Datos.IDTipoComision = IDTipoComision;
                    Datos.EsPorcentaje = EsPorcentaje;
                    Datos.Porcentaje = Porcentaje;
                    Datos.Monto = Monto;
                }
                return Datos;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                this.LLenarGridComisionXIDCategoria();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReglasComisiones ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                this.LLenarGridComisionXEmpleado();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReglasComisiones ~ btnCancelar_Click");
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

        private void frmReglasComisiones_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReglasComisiones ~ frmReglasComisiones_Load");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevaReglaComision Regla = new frmNuevaReglaComision();
                Regla.ShowDialog();
                Regla.Dispose();
                if (Regla.DialogResult == DialogResult.OK)
                {
                    this.IniciarDatosBusqueda();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReglasComisiones ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int Row = -1;
                if (this.tcCompras.SelectedIndex == 0)
                {
                    if (this.dgvReglasCategoria.SelectedRows.Count == 1)
                        Row = this.dgvReglasCategoria.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                }
                else
                {
                    if (this.dgvReglasEmpleado.SelectedRows.Count == 1)
                        Row = this.dgvReglasEmpleado.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                }
                if (Row != -1)
                {
                    Comision Datos = this.ObtenerDatosGridCategoria(Row);
                    frmNuevaReglaComision Regla = new frmNuevaReglaComision(Datos);
                    Regla.ShowDialog();
                    Regla.Dispose();
                    if(Regla.DialogResult == DialogResult.OK)
                        this.IniciarDatosBusqueda();
                }
                else
                {
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReglasComisiones ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int Row = -1;
                if (this.tcCompras.SelectedIndex == 0)
                {
                    if (this.dgvReglasCategoria.SelectedRows.Count == 1)
                        Row = this.dgvReglasCategoria.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                }
                else
                {
                    if (this.dgvReglasEmpleado.SelectedRows.Count == 1)
                        Row = this.dgvReglasEmpleado.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                }
                if (Row != -1)
                {
                    DialogResult Resultado;
                    if(this.tcCompras.SelectedIndex == 0) 
                        Resultado = MessageBox.Show("¿Está seguro de eliminar la regla?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    else
                        Resultado = MessageBox.Show("¿Está seguro de eliminar la regla? Tenga en cuenta que la regla no le pertenece al empleado.", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Resultado == DialogResult.Yes)
                    {
                        Comision Datos = this.ObtenerDatosGridCategoria(Row);
                        Datos.Conexion = Comun.Conexion;
                        Datos.IDUsuario = Comun.IDUsuario;
                        Comision_Negocio CN = new Comision_Negocio();
                        CN.EliminarReglasComision(Datos);
                        if (Datos.Completado)
                        {
                            MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.IniciarDatosBusqueda();
                        }
                        else
                        {
                            MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReglasComisiones ~ btnCancelar_Click");
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
                LogError.AddExcFileTxt(ex, "frmReglasComisiones ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tpCategoria_Click(object sender, EventArgs e)
        {

        }
    }
}
