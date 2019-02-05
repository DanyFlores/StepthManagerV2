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
    public partial class frmPromocionPreciosModificar : Form
    {
        private PromocionXSucursal Datos = null;
        public frmPromocionPreciosModificar(PromocionXSucursal _Datos)
        {
            InitializeComponent();
            Datos = _Datos;
        }

        #region Métodos

        private void CargarDatos()
        {
            try
            {
                this.lblSucursal.Text = Datos.NombreSucursal;
                Promocion_Negocio PromNeg = new Promocion_Negocio();
                dgvServicios.AutoGenerateColumns = false;
                dgvServicios.DataSource = PromNeg.ObtenerPreciosServicioXIDSucIDPromocion(Comun.Conexion, Datos.IDPromocion, Datos.IDSucursal);
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
                this.CargarDatos();
                this.ActiveControl = this.btnGuardar;
                this.btnGuardar.Focus();
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

        private DataTable ObtenerTablaPrecios()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla.Columns.Add("IDPromocionDetalle", typeof(int));
                Tabla.Columns.Add("Precio", typeof(decimal));
                List<PromocionServicios> Lista = (List<PromocionServicios>)this.dgvServicios.DataSource;
                foreach(PromocionServicios Item in Lista)
                {
                    Tabla.Rows.Add(new object[] { Item.IDPromocionDetalle, Item.Precio });
                }
                return Tabla;
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
                if (!ValidarPrecios())
                    Errores.Add(new Error { Numero = (aux += 1), Descripcion = "El precio de los productos debe ser mayor a 0.", ControlSender = this.dgvServicios });
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidarPrecios()
        {
            try
            {
                List<PromocionServicios> Lista = (List<PromocionServicios>)dgvServicios.DataSource;
                foreach(PromocionServicios Item in Lista)
                {
                    if(Item.Precio <= 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch(Exception ex)
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
                LogError.AddExcFileTxt(ex, "frmPromocionPreciosModificar ~ btnCancelar_Click");
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

                    Promocion_Negocio PromNeg = new Promocion_Negocio();
                    Datos.TablaPrecios = this.ObtenerTablaPrecios();
                    int Resultado = PromNeg.ActualizarPreciosXIDPromocionXIDSucursal(Comun.Conexion, Datos, Comun.IDUsuario);
                    if (Resultado == 1)
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
                LogError.AddExcFileTxt(ex, "frmPromocionPreciosModificar ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void frmPromocionPreciosModificar_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPromocionPreciosModificar ~ frmPromocionPreciosModificar_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void dgvServicios_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (dgvServicios.Columns[e.ColumnIndex].Name.Equals("Precio"))
                {
                    decimal _Precio = 0;
                    if (!decimal.TryParse(e.FormattedValue.ToString().Replace("$", ""), NumberStyles.Currency, CultureInfo.CurrentCulture, out _Precio))
                    {
                        e.Cancel = true;
                        dgvServicios.Rows[e.RowIndex].ErrorText = "Debe ingresar un precio válido (No ingresar símbolo).";
                    }
                    else
                    {
                        if (_Precio < 0)
                        {
                            e.Cancel = true;
                            dgvServicios.Rows[e.RowIndex].ErrorText = "El precio debe ser mayor a 0.";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPromocionPreciosModificar ~ dgvServicios_CellValidating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvServicios_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                DataGridView DgvSender = (DataGridView)sender;
                e.Cancel = true;
                DgvSender.Rows[e.RowIndex].ErrorText = "Debe ingresar un precio válido (No ingresar símbolo).";
            }
            catch(Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPromocionPreciosModificar ~ dgvServicios_DataError");
            }
        }

        private void dgvServicios_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvServicios.Columns[e.ColumnIndex].Name.Equals("Precio"))
                {
                    dgvServicios.Rows[e.RowIndex].ErrorText = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPromocionPreciosModificar ~ dgvServicios_CellValidated");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}