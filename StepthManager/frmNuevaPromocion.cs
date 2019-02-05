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
    public partial class frmNuevaPromocion : Form
    {
        private bool NuevoRegistro = true;
        private int IDPromocion = 0;
        private List<Servicio> Servicios = new List<Servicio>();

        #region Constructor(es)

        public frmNuevaPromocion()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaPromocion ~ frmNuevaPromocion()");
            }
        }

        public frmNuevaPromocion(int _IDPromocion)
        {
            try
            {
                InitializeComponent();
                NuevoRegistro = false;
                IDPromocion = _IDPromocion;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaPromocion ~ frmNuevaPromocion(int _IDPromocion)");
            }
        }

        #endregion

        #region Métodos
        
        private void CargarDatosAModificar(Promocion Datos)
        {
            try
            {
                this.txtNombrePromocion.Text = Datos.NombrePromocion;
                chkL.Checked = Datos.Lunes;
                chkM.Checked = Datos.Martes;
                chkX.Checked = Datos.Miercoles;
                chkJ.Checked = Datos.Jueves;
                chkV.Checked = Datos.Viernes;
                chkS.Checked = Datos.Sabado;
                chkD.Checked = Datos.Domingo;
                LlenarListaPadecimientos(Datos.ListaSucursales);
                LlenarGridServicios();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GenerarTablaServicios()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla.Columns.Add("IDServicio", typeof(string));
                Tabla.Columns.Add("Cantidad", typeof(int));
                foreach (DataGridViewRow Fila in this.dgvServicios.Rows)
                {
                    string IDServicio = Fila.Cells["IDServicio"].Value.ToString();
                    int Cantidad = 1;
                    Tabla.Rows.Add(new object[] { IDServicio, Cantidad });
                }
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GenerarTablaSucursales()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla.Columns.Add("IDSucursal", typeof(string));
                foreach (Sucursal Item in this.chkListBoxSucursales.CheckedItems)
                {
                    Tabla.Rows.Add(new object[] { Item.IDSucursal});
                }
                return Tabla;
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
                Promocion_Negocio PromNeg = new Promocion_Negocio();
                List<Sucursal> Datos = PromNeg.ObtenerSucursalesPromocion(Comun.Conexion);
                txtNombrePromocion.Text = string.Empty;
                chkL.Checked = false;
                chkM.Checked = false;
                chkX.Checked = false;
                chkJ.Checked = false;
                chkV.Checked = false;
                chkS.Checked = false;
                chkD.Checked = false;
                LlenarListaPadecimientos(Datos);
                LlenarGridServicios();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarListaPadecimientos(List<Sucursal> _Datos)
        {
            try
            {
                foreach (Sucursal Item in _Datos)
                {
                    this.chkListBoxSucursales.Items.Add(Item, Item.Seleccionado);
                }
                this.chkListBoxSucursales.ValueMember = "IDSucursal";
                this.chkListBoxSucursales.DisplayMember = "NombreSucursal";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarGridServicios()
        {
            try
            {
                BindingSource Source = new BindingSource();
                Source.DataSource = Servicios;
                dgvServicios.AutoGenerateColumns = false;
                dgvServicios.DataSource = Source;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void IniciarDatosModificar()
        {
            try
            {
                dgvServicios.Visible = false;
                btnAgregarServicio.Visible = false;
                btnEliminarServicio.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                Promocion_Negocio PromNeg = new Promocion_Negocio();
                Promocion Datos = PromNeg.ObtenerDetallePromocion(Comun.Conexion, IDPromocion);
                CargarDatosAModificar(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private bool AgregarServicioLista(Servicio _Datos)
        {
            try
            {
                if(!ExisteServicio(_Datos.IDServicio))
                {
                    Servicios.Add(_Datos);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private bool ExisteServicio(string _IDServicio)
        {
            try
            {
                foreach(Servicio Item in Servicios)
                {
                    if(Item.IDServicio == _IDServicio)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.ActiveControl = this.txtNombrePromocion;
                this.txtNombrePromocion.Focus();
                if (NuevoRegistro)
                    IniciarDatos();
                else
                    IniciarDatosModificar();
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

        private Promocion ObtenerDatos()
        {
            try
            {
                Promocion _Datos = new Promocion();
                _Datos.IDPromocion = NuevoRegistro ? 0 : IDPromocion;
                _Datos.NombrePromocion = this.txtNombrePromocion.Text.Trim();
                _Datos.Lunes = chkL.Checked;
                _Datos.Martes = chkM.Checked;
                _Datos.Miercoles = chkX.Checked;
                _Datos.Jueves = chkJ.Checked;
                _Datos.Viernes = chkV.Checked;
                _Datos.Sabado = chkS.Checked;
                _Datos.Domingo = chkD.Checked;
                _Datos.TablaSucursales = GenerarTablaSucursales();
                if (NuevoRegistro) _Datos.TablaServicios = GenerarTablaServicios();
                return _Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private Servicio ObtenerServicioGrid(int Row)
        {
            try
            {
                Servicio _Datos = new Servicio();
                DataGridViewRow Fila = dgvServicios.Rows[Row];
                _Datos.IDServicio = Fila.Cells["IDServicio"].Value.ToString();
                return _Datos;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private Producto ObtenerDetalleProductoXID(string IDProducto)
        {
            try
            {
                Producto_Negocio ProdNeg = new Producto_Negocio();
                return ProdNeg.ObtenerDatosProductoXID(new Producto { IDProducto = IDProducto, Conexion = Comun.Conexion });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool RemoverServicio(string _IDServicio)
        {
            try
            {
                Servicio ItemToDelete = null;
                foreach(Servicio Item in Servicios)
                {
                    if (Item.IDServicio.Equals(_IDServicio))
                    {
                        ItemToDelete = Item;
                        break;
                    }
                }
                if (ItemToDelete != null)
                {
                    Servicios.Remove(ItemToDelete);
                    return true;
                }
                return false;
            }
            catch(Exception ex)
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
                
                if(string.IsNullOrEmpty(this.txtNombrePromocion.Text.Trim()))
                {
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese un nombre de promoción.", ControlSender = this.txtNombrePromocion });
                }
                if(!ValidarDiasSemana())
                {
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione al menos un día de la semana.", ControlSender = this.chkL });
                }
                if(!ValidarSucursales())
                {
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione al menos una sucursal.", ControlSender = this.chkL });
                }
                if(NuevoRegistro)
                {
                    if(Servicios.Count == 0)
                    {
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione al menos un servicio.", ControlSender = this.dgvServicios });
                    }
                }
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidarDiasSemana()
        {
            try
            {
                if (chkL.Checked)
                    return true;
                if (chkM.Checked)
                    return true;
                if (chkX.Checked)
                    return true;
                if (chkJ.Checked)
                    return true;
                if (chkV.Checked)
                    return true;
                if (chkS.Checked)
                    return true;
                if (chkD.Checked)
                    return true;
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidarSucursales()
        {
            try
            {
                return (this.chkListBoxSucursales.CheckedItems.Count > 0);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos    

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                frmSeleccionarProducto ElegirServicio = new frmSeleccionarProducto(2);
                ElegirServicio.Location = this.btnAgregarServicio.PointToScreen(new Point());
                ElegirServicio.Location = new Point(ElegirServicio.Location.X - 1, ElegirServicio.Location.Y - 2);
                ElegirServicio.ShowDialog();
                ElegirServicio.Dispose();
                if (ElegirServicio.DialogResult == DialogResult.OK)
                {
                    Producto _Datos = ElegirServicio.Datos;
                    Servicio _DatosServicio = new Servicio { IDServicio = _Datos.IDProducto, NombreServicio = _Datos.NombreProducto };
                    if(AgregarServicioLista(_DatosServicio))
                        this.LlenarGridServicios();
                    else
                    {
                        MessageBox.Show("El servicio ya está en la lista.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaPromocion ~ btnbEliminarProveedor_Click");
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
                LogError.AddExcFileTxt(ex, "frmNuevaPromocion ~ btnCancelar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvServicios.SelectedRows.Count > 0)
                {
                    Int32 RowToDelete = this.dgvServicios.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    if (RowToDelete > -1)
                    {
                        Servicio _Datos = this.ObtenerServicioGrid(RowToDelete);
                        if(ExisteServicio(_Datos.IDServicio))
                        {
                            if(RemoverServicio(_Datos.IDServicio))
                            {
                                MessageBox.Show("Servicio eliminado.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.LlenarGridServicios();
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Seleccione la fila del registro a eliminar.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaPromocion ~ btnbEliminarProveedor_Click");
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
                    Promocion_Negocio PromNeg = new Promocion_Negocio();
                    Promocion Datos = this.ObtenerDatos();
                    int Resultado = 0;
                    if (NuevoRegistro)
                    {
                        Resultado = PromNeg.AgregarPromocion(Comun.Conexion, Datos, Comun.IDUsuario);
                        if(Resultado == 1)
                        {
                            MessageBox.Show("Promoción registrada existosamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Error al guardar los datos.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        Resultado = PromNeg.ModificarPromocion(Comun.Conexion, Datos, Comun.IDUsuario);
                        if (Resultado == 1)
                        {
                            MessageBox.Show("Datos guardados existosamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Error al guardar los datos.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                    this.MostrarMensajeError(Errores);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaPromocion ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void frmNuevaPromocion_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmNuevaPromocion ~ frmNuevaPromocion_Load");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        
    }
}
