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
    public partial class frmNominaConceptos : Form
    {
        #region Variables

        string IDEmpleado = string.Empty;
        int IDTipoNomina = 0;

        #endregion

        #region Constructor

        public frmNominaConceptos(string ID, int TipoNomina)
        {
            try
            {
                InitializeComponent();
                this.IDEmpleado = ID;
                this.IDTipoNomina = TipoNomina;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNominaConceptos ~ frmNominaConceptos()");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
                {
                    this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                }
                this.CargarGridsConceptos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridConceptosFijos()
        {
            try
            {
                Nomina Datos = new Nomina { Conexion = Comun.Conexion, IDEmpleado = this.IDEmpleado, IDTipoNomina = this.IDTipoNomina };
                Nomina_Negocio NN = new Nomina_Negocio();
                NN.ObtenerConceptosFijosXIDEmpleado(Datos);
                this.dgvConceptosFijos.AutoGenerateColumns = false;
                this.dgvConceptosFijos.DataSource = Datos.TablaConceptosFijos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridConceptosVariables()
        {
            try
            {
                Nomina Datos = new Nomina { Conexion = Comun.Conexion, IDEmpleado = this.IDEmpleado, IDTipoNomina = this.IDTipoNomina };
                Nomina_Negocio NN = new Nomina_Negocio();
                NN.ObtenerConceptosVariablesXIDEmpleado(Datos);
                this.dgvConceptosVariables.AutoGenerateColumns = false;
                this.dgvConceptosVariables.DataSource = Datos.TablaConceptosVariables;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarGridsConceptos()
        {
            try
            {
                Nomina Datos = new Nomina { Conexion = Comun.Conexion, IDEmpleado = this.IDEmpleado, IDTipoNomina = this.IDTipoNomina };
                Nomina_Negocio NN = new Nomina_Negocio();
                NN.ObtenerConceptosNominaXIDEmpleado(Datos);
                this.dgvConceptosFijos.AutoGenerateColumns = false;
                this.dgvConceptosVariables.AutoGenerateColumns = false;
                this.dgvConceptosFijos.DataSource = Datos.TablaConceptosFijos;
                this.dgvConceptosVariables.DataSource = Datos.TablaConceptosVariables;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNominaConceptos ~ frmNominaConceptos_Resize");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNominaConceptos_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNominaConceptos ~ frmNominaConceptos_Load");
            }
        }

        private void frmNominaConceptos_Resize(object sender, EventArgs e)
        {
            try
            {
                this.panelIzquierda.Size = new Size(this.panelBase.Width / 2, this.panelIzquierda.Height);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNominaConceptos ~ frmNominaConceptos_Resize");
            }
        }

        #endregion

        private void btnAgregarCF_Click(object sender, EventArgs e)
        {
            try
            {
                Nomina DatosAux = new Nomina { IDEmpleado = this.IDEmpleado, IDTipoNomina = this.IDTipoNomina, EsFijo = true }; 
                frmNominaAgregarConcepto AgregarConcepto = new frmNominaAgregarConcepto(DatosAux);
                AgregarConcepto.ShowDialog();
                AgregarConcepto.Dispose();
                if (AgregarConcepto.DialogResult == DialogResult.OK)
                {
                    this.CargarGridConceptosFijos();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNominaConceptos ~ btnAgregarCF_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarCV_Click(object sender, EventArgs e)
        {
            try
            {
                Nomina DatosAux = new Nomina { IDEmpleado = this.IDEmpleado, IDTipoNomina = this.IDTipoNomina, EsFijo = false };
                frmNominaAgregarConcepto AgregarConcepto = new frmNominaAgregarConcepto(DatosAux);
                AgregarConcepto.ShowDialog();
                AgregarConcepto.Dispose();
                if (AgregarConcepto.DialogResult == DialogResult.OK)
                {
                    this.CargarGridConceptosVariables();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNominaConceptos ~ btnAgregarCV_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitarCF_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.dgvConceptosFijos.SelectedRows.Count == 1)
                {
                    Nomina DatosAux = this.ObtenerCFSeleccionado();
                    if (!string.IsNullOrEmpty(DatosAux.IDConceptoNomina))
                    {
                        if (MessageBox.Show("¿Está seguro de quitar el concepto?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Nomina_Negocio NN = new Nomina_Negocio();
                            NN.QuitarConceptoNomina(DatosAux);
                            if (DatosAux.Completado)
                            {
                                this.CargarGridConceptosFijos();
                            }
                            else
                                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNominaConceptos ~ btnQuitarCF_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Nomina ObtenerCFSeleccionado()
        {
            try
            {
                Nomina DatosAux = new Nomina();
                int RowSelected = this.dgvConceptosFijos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if(RowSelected >= 0)
                {
                    DataGridViewRow Fila = this.dgvConceptosFijos.Rows[RowSelected];
                    DatosAux.IDConceptoNomina = Fila.Cells["IDConceptoFijo"].Value.ToString();
                    DatosAux.EsFijo = true;
                    DatosAux.IDUsuario = Comun.IDUsuario;
                    DatosAux.Conexion = Comun.Conexion;
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Nomina ObtenerCVSeleccionado()
        {
            try
            {
                Nomina DatosAux = new Nomina();
                int RowSelected = this.dgvConceptosVariables.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowSelected >= 0)
                {
                    DataGridViewRow Fila = this.dgvConceptosVariables.Rows[RowSelected];
                    DatosAux.IDConceptoNomina = Fila.Cells["IDConceptoVariable"].Value.ToString();
                    DatosAux.EsFijo = false;
                    DatosAux.IDUsuario = Comun.IDUsuario;
                    DatosAux.Conexion = Comun.Conexion;
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnQuitarCV_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvConceptosVariables.SelectedRows.Count == 1)
                {
                    Nomina DatosAux = this.ObtenerCVSeleccionado();
                    if (!string.IsNullOrEmpty(DatosAux.IDConceptoNomina))
                    {
                        if (MessageBox.Show("¿Está seguro de quitar el concepto?", Comun.Sistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Nomina_Negocio NN = new Nomina_Negocio();
                            NN.QuitarConceptoNomina(DatosAux);
                            if (DatosAux.Completado)
                            {
                                this.CargarGridConceptosVariables();
                            }
                            else
                                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione un registro.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNominaConceptos ~ btnQuitarCV_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
