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
using CreativaSL.LibControls.WinForms;
using System.IO;

namespace StephManager
{
    public partial class frmChecador : Form
    {
        #region Constructor

        public frmChecador()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmChecarEntradaSalida ~ frmChecarEntradaSalida");
            }
        }

        #endregion

        #region Métodos

        private void IniciarForm()
        {
            try
            {
                this.LlenarComboSucursales();
                this.LlenarMenuStripChecado();
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

        private void LlenarComboSucursales()
        {
            try
            {
                Sucursal DatosAux = new Sucursal { Conexion = Comun.Conexion, Opcion = 1 };
                Sucursal_Negocio SN = new Sucursal_Negocio();
                this.cmbSucursal.DataSource = SN.LlenarComboCatSucursales(DatosAux);
                this.cmbSucursal.ValueMember = "IDSucursal";
                this.cmbSucursal.DisplayMember = "NombreSucursal";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridResumen(DataTable Datos)
        {
            try
            {
                this.dgvResumenChecado.AutoGenerateColumns = false;
                this.dgvResumenChecado.DataSource = Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarMenuStripChecado()
        {
            try
            {
                TipoRegistro TRAux = new TipoRegistro { Conexion = Comun.Conexion, IncluirSelect = false };
                Catalogo_Negocio CN = new Catalogo_Negocio();
                List<TipoRegistro> Lista = CN.ObtenerCatTipoRegistro(TRAux);
                foreach (TipoRegistro Item in Lista)
                {
                    ToolStripMenuItem ItemMenu = new ToolStripMenuItem();
                    ItemMenu.Tag = Item.IDTipoRegistro;
                    ItemMenu.Text = Item.Descripcion;
                    ItemMenu.Image = global::StephManager.Properties.Resources.checar;
                    ItemMenu.ForeColor = Color.FromArgb(64, 64, 64);
                    ItemMenu.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
                    this.MenuStripChecado.Items.Add(ItemMenu);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnChecar_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Creativa btn = (Button_Creativa)sender;
                this.MenuStripChecado.Show(btn, btn.Width / 2, btn.Location.Y + btn.Height);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmChecador ~ btnChecar_Click");
            }
        }

        private void btnJustificaciones_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmJustificaciones Justificar = new frmJustificaciones();
                Justificar.ShowDialog();
                Justificar.Dispose();
                this.Visible = true;
                if (Justificar.DialogResult == DialogResult.OK)
                {
                    btnMostrarResultados_Click(this.btnMostrarResultados, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                this.Visible = true;
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmChecador ~ btnJustificaciones_Click");
            }
        }

        private void btnMostrarResultados_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbSucursal.Items.Count > 0)
                {
                    if (this.cmbSucursal.SelectedIndex != -1)
                    {
                        Sucursal SucAux = (Sucursal)this.cmbSucursal.SelectedItem;
                        if (!string.IsNullOrEmpty(SucAux.IDSucursal))
                        {
                            Checador DatosAux = new Checador { Conexion = Comun.Conexion, FechaChecador = this.dtpFecha.Value, IDSucursal = SucAux.IDSucursal };
                            Checador_Negocio CN = new Checador_Negocio();
                            CN.ObtenerResumenChecador(DatosAux);
                            this.LlenarGridResumen(DatosAux.TablaDatos);
                        }
                        else
                            this.LlenarGridResumen(null);
                    }
                    else
                        this.LlenarGridResumen(null);
                }
                else
                    this.LlenarGridResumen(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmChecador ~ btnMostrarResultados_Click");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmChecador ~ btnSalir_Click");
            }

        }

        private void frmChecador_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmChecarEntradaSalida ~ frmChecarEntradaSalida");
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem Item = (ToolStripMenuItem)sender;
                int IDTipoRegistro = 0;
                int.TryParse(Item.Tag.ToString(), out IDTipoRegistro);
                if (IDTipoRegistro > 0)
                {
                    TipoRegistro DatosAux = new TipoRegistro { IDTipoRegistro = IDTipoRegistro, Descripcion = Item.Text };
                    frmChecarEntradaSalida EntradaSalida = new frmChecarEntradaSalida(DatosAux);
                    EntradaSalida.ShowDialog();
                    EntradaSalida.Dispose();
                    if (EntradaSalida.DialogResult == DialogResult.OK)
                    {
                        btnMostrarResultados_Click(this.btnMostrarResultados, new EventArgs());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
