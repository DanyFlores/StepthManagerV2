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
    public partial class frmPedidoSurtir : Form
    {
        #region Propiedades / Variables
        private Pedido _DatosPedido;
        public Pedido DatosPedido
        {
            get { return _DatosPedido; }
            set { _DatosPedido = value; }
        }
        #endregion

        #region Constructor(es)

        public frmPedidoSurtir(Pedido Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosPedido = Datos;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidoSurtir ~ frmPedidoSurtir(Pedido Datos)");
            }
        }

        #endregion

        #region Métodos

        private void CargarGridPedidoDetalle()
        {
            try
            {
                this.dgvPedidoDetalle.AutoGenerateColumns = false;
                this.dgvPedidoDetalle.DataSource = null;
                this.dgvPedidoDetalle.DataSource = this._DatosPedido.DetallePedido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void CargarDatosAModificar(Pedido Datos)
        {
            try
            {
                if (!string.IsNullOrEmpty(Datos.IDPedido.Trim()))
                {
                    this.txtFolioPedido.Text = this._DatosPedido.FolioPedido;
                    this.txtEstatus.Text = this._DatosPedido.Estatus;
                    this.CargarGridPedidoDetalle();
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
                this._DatosPedido.DetallePedido = this.ObtenerDetallePedidoXID(this._DatosPedido.IDPedido);
                this.CargarDatosAModificar(this._DatosPedido);
                this.ActiveControl = this.btnCancelar;
                this.btnCancelar.Focus();
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

        private List<PedidoDetalle> ObtenerDetallePedidoXID(string IDPedido)
        {
            try
            {
                Pedido_Negocio PedNeg = new Pedido_Negocio();
                return PedNeg.ObtenerDetallePedido(new Pedido { IDPedido = IDPedido, Conexion = Comun.Conexion });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Pedido ObtenerDatosPedido()
        {
            try
            {
                Pedido DatosAux = new Pedido();
                DatosAux.IDPedido = this._DatosPedido.IDPedido;
                DatosAux.IDUsuario = Comun.IDUsuario;
                DatosAux.IDSucursal = Comun.IDSucursalCaja;
                DatosAux.TablaDatos = this.ObtenerTablaDatos();
                DatosAux.Conexion = Comun.Conexion;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable ObtenerTablaDatos()
        {
            try
            {
                DataTable Datos = new DataTable();
                Datos.Columns.Add("IDPedidoDetalle", typeof(string));
                Datos.Columns.Add("CantidadASurtir", typeof(decimal));
                List<PedidoDetalle> Lista = (List<PedidoDetalle>)this.dgvPedidoDetalle.DataSource;
                foreach (PedidoDetalle Item in Lista)
                {
                    if (Item.CantidadASurtir > 0)
                    {
                        object[] Fila = { Item.IDPedidoDetalle, Item.CantidadASurtir };
                        Datos.Rows.Add(Fila);
                    }
                }
                return Datos;
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
                int Aux = 0, Cont = 0;
                List<PedidoDetalle> Lista = (List<PedidoDetalle>)this.dgvPedidoDetalle.DataSource;
                foreach (PedidoDetalle Item in Lista)
                {
                    if (Item.CantidadASurtir > 0)
                    {
                        Cont ++;
                    }
                }
                if(Cont == 0)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe surtir al menos un producto.", ControlSender = this.dgvPedidoDetalle});
                return Errores;
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
                LogError.AddExcFileTxt(ex, "frmPedidoSurtir ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSurtir_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtMensajeError.Visible = false;
                List<Error> Errores = this.ValidarDatos();
                if (Errores.Count == 0)
                {
                    Pedido Datos = this.ObtenerDatosPedido();
                    Pedido_Negocio PedNeg = new Pedido_Negocio();
                    PedNeg.SurtirPedido(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (Datos.Resultado != -1)
                            MessageBox.Show("Ocurrió un error al guardar los datos.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            string Cadena = "Existencia insuficiente para los productos: ";
                            bool Band = true;
                            foreach (DataRow Fila in Datos.TablaDatos.Rows)
                            {
                                if (Band)
                                {
                                    Cadena += Fila["NombreProducto"].ToString();
                                    Band = false;
                                }
                                else
                                {
                                    Cadena += ", " + Fila["NombreProducto"].ToString();
                                }
                            }
                            List<Error> ProductosSinExistencia = new List<Error>();
                            ProductosSinExistencia.Add(new Error { Numero = 1, Descripcion = Cadena, ControlSender = this.dgvPedidoDetalle });
                            this.MostrarMensajeError(ProductosSinExistencia);
                        }
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidoSurtir ~ btnSurtir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPedidoDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (this.dgvPedidoDetalle.Columns["CantidadASurtir"] == this.dgvPedidoDetalle.Columns[e.ColumnIndex])
                    {
                        if (this.dgvPedidoDetalle.Rows[e.RowIndex].IsNewRow) { return; }
                        decimal CantidadAux = 0;
                        if (!decimal.TryParse(e.FormattedValue.ToString(), out CantidadAux))
                        {
                            e.Cancel = true;
                            this.dgvPedidoDetalle.Rows[e.RowIndex].ErrorText = "Ingrese un dato válido.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidoSurtir ~ dgvPedidoDetalle_CellValidating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPedidoDetalle_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (this.dgvPedidoDetalle.Columns["CantidadASurtir"] == this.dgvPedidoDetalle.Columns[e.ColumnIndex])
                    {
                        this.dgvPedidoDetalle.Rows[e.RowIndex].ErrorText = "";
                        decimal CantidadAux = 0, CantidadPendiente, CantidadPedido;
                        decimal.TryParse(this.dgvPedidoDetalle.Rows[e.RowIndex].Cells["CantidadASurtir"].Value.ToString(), out CantidadAux);
                        decimal.TryParse(this.dgvPedidoDetalle.Rows[e.RowIndex].Cells["CantidadPendiente"].Value.ToString(), out CantidadPendiente);
                        decimal.TryParse(this.dgvPedidoDetalle.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString(), out CantidadPedido);
                        if (!string.IsNullOrEmpty(this.dgvPedidoDetalle.Rows[e.RowIndex].Cells["IDAsignacion"].Value.ToString()))
                        {
                            if (CantidadAux > 0 && CantidadPendiente > 0)
                            {
                                this.dgvPedidoDetalle.Rows[e.RowIndex].Cells["CantidadASurtir"].Value = CantidadPedido;
                            }
                            else
                            {
                                CantidadAux = 0;
                                this.dgvPedidoDetalle.Rows[e.RowIndex].Cells["CantidadASurtir"].Value = CantidadAux;
                            }
                        }
                        else
                        {
                            if (CantidadAux > CantidadPendiente)
                            {
                                this.dgvPedidoDetalle.Rows[e.RowIndex].Cells["CantidadASurtir"].Value = CantidadPendiente;
                            }
                            else
                            {
                                if (CantidadAux < 0)
                                    CantidadAux = 0;
                                this.dgvPedidoDetalle.Rows[e.RowIndex].Cells["CantidadASurtir"].Value = (decimal)((int)CantidadAux);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidoSurtir ~ dgvPedidoDetalle_CellValidating");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPedidoSurtir_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmPedidoSurtir ~ frmPedidoSurtir_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


    }
}
