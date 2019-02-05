using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using Microsoft.Office.Interop.Excel;
using StephManager.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace StephManager
{
    public partial class frmInventario : Form
    {
        private bool AllowClick = true;
        Producto infoProducto = new Producto();
        #region Constructor

        public frmInventario()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ frmInventario()");
            }
        }

        #endregion

        #region Métodos

        private System.Data.DataTable BusquedaResultados(Producto Datos)
        {
            try
            {
                Producto_Negocio ProdNeg = new Producto_Negocio();
                ProdNeg.ObtenerProductosInventario(Datos);
                return Datos.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarComboSucursales()
        {
            try
            {
                Sucursal DatosSuc = new Sucursal { Conexion = Comun.Conexion, Opcion = 1 };
                Sucursal_Negocio SucNeg = new Sucursal_Negocio();
                this.cmbSucursales.DataSource = SucNeg.LlenarComboCatSucursales(DatosSuc);
                this.cmbSucursales.ValueMember = "IDSucursal";
                this.cmbSucursales.DisplayMember = "NombreSucursal";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Producto> GenerarLista()
        {
            try
            {
                List<Producto> Lista = new List<Producto>();
                Producto Item;
                foreach (DataGridViewRow Fila in this.dgvProductos.Rows)
                {
                    Item = new Producto();
                    Item.Clave = Fila.Cells["Clave"].Value.ToString();
                    Item.NombreProducto = Fila.Cells["NombreProducto"].Value.ToString();
                    Item.NombreSucursal = Fila.Cells["NombreSucursal"].Value.ToString();
                    Item.Existencia = Convert.ToDecimal(Fila.Cells["Existencia"].Value.ToString());
                    Item.StockMinimo = Convert.ToDecimal(Fila.Cells["StockMinimo"].Value.ToString());
                    Item.StockMaximo = Convert.ToDecimal(Fila.Cells["StockMaximo"].Value.ToString());
                    Item.RequiereStock = Convert.ToBoolean(Fila.Cells["RequiereStock"].Value.ToString());
                    Lista.Add(Item);
                }
                return Lista;
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
                this.CargarComboSucursales();
                this.ActiveControl = this.cmbSucursales;
                this.cmbSucursales.Focus();
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

        private void LlenarTablaProductos(System.Data.DataTable Datos)
        {
            try
            {
                this.dgvProductos.AutoGenerateColumns = false;
                this.dgvProductos.DataSource = Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ModificarDatos(int Row, Producto Datos)
        {
            try
            {
                //this.dgvProductos.Rows[Row].Cells["Existencia"].Value = Datos.Existencia;
                this.dgvProductos.Rows[Row].Cells["RequiereStock"].Value = Datos.RequiereStock;
                this.dgvProductos.Rows[Row].Cells["StockMaximo"].Value = Datos.StockMaximo;
                this.dgvProductos.Rows[Row].Cells["StockMinimo"].Value = Datos.StockMinimo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ModificarExistencia(int Row, Producto Datos)
        {
            try
            {
                this.dgvProductos.Rows[Row].Cells["Existencia"].Value = Datos.Existencia;
                this.dgvProductos.Rows[Row].Cells["ExistenciaAlmacen"].Value = Datos.Existencia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Producto ObtenerDatosProducto(int Row)
        {
            try
            {
                Producto DatosAux = new Producto();
                decimal Existencia = 0, StockMinimo = 0, StockMaximo = 0;
                bool RequiereStock = false;
                if (this.dgvProductos.Rows.Count > 0 && Row < this.dgvProductos.Rows.Count)
                {
                    DataGridViewRow Fila = this.dgvProductos.Rows[Row];
                    DatosAux.IDProducto = Fila.Cells["IDProducto"].Value.ToString();
                    DatosAux.IDSucursal = Fila.Cells["IDSucursal"].Value.ToString();
                    DatosAux.NombreProducto = Fila.Cells["NombreProducto"].Value.ToString();
                    DatosAux.NombreSucursal = Fila.Cells["NombreSucursal"].Value.ToString();
                    bool.TryParse(Fila.Cells["RequiereStock"].Value.ToString(), out RequiereStock);
                    decimal.TryParse(Fila.Cells["Existencia"].Value.ToString(), out Existencia);
                    decimal.TryParse(Fila.Cells["StockMinimo"].Value.ToString(), out StockMinimo);
                    decimal.TryParse(Fila.Cells["StockMaximo"].Value.ToString(), out StockMaximo);
                    DatosAux.RequiereStock = RequiereStock;
                    DatosAux.Existencia = Existencia;
                    DatosAux.StockMinimo = StockMinimo;
                    DatosAux.StockMaximo = StockMaximo;
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Sucursal ObtenerSucursalCombo()
        {
            try
            {
                Sucursal DatosAux = new Sucursal();
                if (this.cmbSucursales.Items.Count > 0)
                {
                    if (this.cmbSucursales.SelectedIndex != -1)
                    {
                        DatosAux = (Sucursal)this.cmbSucursales.SelectedItem;
                    }
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Eventos

        private void btnAjuste_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductos.SelectedRows.Count == 1)
                {
                    int RowSelected = this.dgvProductos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Producto DatosAux = this.ObtenerDatosProducto(RowSelected);
                    if (!string.IsNullOrEmpty(DatosAux.IDSucursal))
                    {
                        if (!string.IsNullOrEmpty(DatosAux.IDProducto))
                        {
                            if (DatosAux.IDTipoProducto == 1)
                            {
                                frmInventarioAjuste Ajuste = new frmInventarioAjuste(DatosAux);
                                Ajuste.ShowDialog();
                                Ajuste.Dispose();
                                if (Ajuste.DialogResult == DialogResult.OK)
                                {
                                    this.ModificarExistencia(RowSelected, Ajuste.DatosActuales);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No es un tipo de producto válido para ajuste.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione una sucursal", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ btnAjuste_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbSucursales.SelectedIndex != -1)
                {
                    Sucursal DatosSuc = this.ObtenerSucursalCombo();
                    if (!string.IsNullOrEmpty(DatosSuc.IDSucursal))
                    {
                        Producto DatosProd = new Producto { Conexion = Comun.Conexion, IDSucursal = DatosSuc.IDSucursal, NombreProducto = this.txtBusqueda.Text.Trim() };
                        this.LlenarTablaProductos(this.BusquedaResultados(DatosProd));
                    }
                    else
                    {
                        MessageBox.Show("Seleccione una sucursal", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una sucursal", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ btnBuscar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductos.Rows.Count > 0)
                {
                    PrintDialog Aux = new PrintDialog();
                    if (Aux.ShowDialog(this) == DialogResult.OK)
                    {
                        ImpresionReporte ImpRep = new ImpresionReporte();
                        ImpRep.Run(@"..\..\Informes\ExistenciaProductos.rdlc", this.GenerarLista(), Aux.PrinterSettings);
                    }
                }
                else
                {
                    MessageBox.Show("No hay registros para impresión.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ btnImprimir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProductos.SelectedRows.Count == 1)
                {
                    int RowSelected = this.dgvProductos.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                    Producto DatosAux = this.ObtenerDatosProducto(RowSelected);
                    if (!string.IsNullOrEmpty(DatosAux.IDSucursal))
                    {
                        if (!string.IsNullOrEmpty(DatosAux.IDProducto))
                        {
                            frmInventarioCambiar Modificar = new frmInventarioCambiar(DatosAux);
                            Modificar.ShowDialog();
                            Modificar.Dispose();
                            if (Modificar.DialogResult == DialogResult.OK)
                            {
                                this.ModificarDatos(RowSelected, Modificar.DatosActuales);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione una sucursal", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ btnModificarDatos_Click");
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
                LogError.AddExcFileTxt(ex, "frmInventario ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTranferencia_Click(object sender, EventArgs e)
        {
            try
            {
                frmInventarioTransferencia Transfer = new frmInventarioTransferencia();
                Transfer.ShowDialog();
                Transfer.Dispose();
                if (Transfer.DialogResult == DialogResult.OK)
                {
                    this.btnBuscar_Click(this.btnBuscar, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ btnAjuste_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    Producto DatosAux = this.ObtenerDatosProducto(e.RowIndex);
                    if (!string.IsNullOrEmpty(DatosAux.IDSucursal))
                    {
                        if (!string.IsNullOrEmpty(DatosAux.IDProducto))
                        {
                            frmInventarioCambiar Modificar = new frmInventarioCambiar(DatosAux);
                            Modificar.ShowDialog();
                            Modificar.Dispose();
                            if (Modificar.DialogResult == DialogResult.OK)
                            {
                                this.ModificarDatos(e.RowIndex, Modificar.DatosActuales);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un registro", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ dgvProductos_CellDoubleClick");
            }
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ frmInventario_Load");
            }
        }

        #endregion

        private void btnLeerInventario_Click(object sender, EventArgs e)
        {
            try
            {
                if (AllowClick)
                {
                    //this.ImportarExcel();
                    OpenFileDialog openFileDialogExcel = new OpenFileDialog();
                    openFileDialogExcel.Filter = "Excel Files|*.xlsx";
                    openFileDialogExcel.FileName = "";
                    openFileDialogExcel.Title = "Seleccione el archivo excel";
                    openFileDialogExcel.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString();
                    if (openFileDialogExcel.ShowDialog() == DialogResult.OK)
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Registrando información... Espere un momento...";
                        this.Cursor = Cursors.WaitCursor;
                        bgwActualizarExistencias.RunWorkerAsync(openFileDialogExcel.FileName);
                        AllowClick = false;
                    }
                }
                else
                {
                    MessageBox.Show("El proceso está en ejecución. Espere un momento...", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ btnLeerInventario_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDescargarArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarExcel())
                {
                    this.ExportarExcel();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ btnDescargarArchivo_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<Producto> GenerarListaMatriz()
        {
            try
            {
                Producto_Negocio ProdNeg = new Producto_Negocio();
                Producto Datos = new Producto { Conexion = Comun.Conexion, IDSucursal = Comun.IDSucursalCaja };
                ProdNeg.ObtenerProductosInventarioMatriz(Datos);
                List<Producto> Lista = new List<Producto>();
                Producto Item;
                foreach (DataRow Fila in Datos.TablaDatos.Rows)
                {
                    Item = new Producto();
                    Item.Clave = Fila["Clave"].ToString();
                    Item.NombreProducto = Fila["NombreProducto"].ToString();
                    Item.Existencia = Convert.ToDecimal(Fila["Existencia"].ToString());
                    Item.IDProducto = Fila["IDProducto"].ToString();
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private System.Data.DataTable GenerarTablaAux()
        {
            Producto_Negocio ProdNeg = new Producto_Negocio();
            Producto Datos = new Producto { Conexion = Comun.Conexion, IDSucursal = Comun.IDSucursalCaja };
            ProdNeg.ObtenerProductosInventarioMatriz(Datos);
            return Datos.TablaDatos;
        }             
        private void ExportarExcel()
        {
            try
            {
                this.btnDescargarArchivo.Enabled = false;
                this.lblMessage.Visible = true;
                this.lblMessage.Text = "Generando Formato. Espere un momento...." + Environment.NewLine;
                bgwFormato.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                this.lblMessage.Visible = false;
                this.lblMessage.Text = string.Empty;
                throw ex;
            }            
        }
        private void ImportarExcel()
        {
            try
            {
                OpenFileDialog openFileDialogExcel = new OpenFileDialog();
                openFileDialogExcel.Filter = "Excel Files|*.xlsx";
                openFileDialogExcel.FileName = "";
                openFileDialogExcel.Title = "Seleccione el archivo excel";
                openFileDialogExcel.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString();
                if (openFileDialogExcel.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application xlsApp = new Microsoft.Office.Interop.Excel.Application();

                    Workbook xlsBook;
                    Worksheet Inventario;
                    Sheets xlHojas;

                    xlsApp.DisplayAlerts = false;
                    xlsApp.Visible = false;
                    string PathAr = openFileDialogExcel.FileName;
                    xlsBook = xlsApp.Workbooks.Open(PathAr);

                    xlHojas = xlsBook.Sheets;
                    Inventario = (Worksheet)xlHojas["Inventario"];
                    int FilaInicio = 4;

                    infoProducto.ImportarExcel = new System.Data.DataTable();
                    infoProducto.ImportarExcel.Columns.Add("IDProducto", typeof(string));
                    infoProducto.ImportarExcel.Columns.Add("Clave", typeof(string));
                    infoProducto.ImportarExcel.Columns.Add("ConteoFisico", typeof(decimal));

                    while ((Inventario.Cells[FilaInicio, 1] as Microsoft.Office.Interop.Excel.Range).Value2 != null)
                    {
                        string Codigo = "", IDProducto = "";
                        decimal ConteoFisico = 0;
                        IDProducto = (Inventario.Cells[FilaInicio, 6] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                        Codigo = (Inventario.Cells[FilaInicio, 1] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                        decimal.TryParse((Inventario.Cells[FilaInicio, 4] as Microsoft.Office.Interop.Excel.Range).Value2.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out ConteoFisico);
                        infoProducto.ImportarExcel.Rows.Add(new Object[] { IDProducto, Codigo, ConteoFisico });
                        FilaInicio++;
                    }

                    Producto AuxProducto = new Producto();
                    Producto_Negocio ProdNeg = new Producto_Negocio();
                    AuxProducto.Conexion = Comun.Conexion;
                    AuxProducto.IDSucursal = Comun.IDSucursalCaja;
                    AuxProducto.IDUsuario = Comun.IDUsuario;
                    AuxProducto.ImportarExcel = infoProducto.ImportarExcel;
                    ProdNeg.AInventarioEXCEL(AuxProducto);
                    if (AuxProducto.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Datos no se guardaron correctamente. Intente mas tarde", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    xlsBook.Close();
                    xlsApp.Quit();
                    releaseObject(xlHojas);
                    releaseObject(xlsBook);
                    releaseObject(Inventario);
                    releaseObject(xlsApp);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                
            }
        }
        private bool ValidarExcel()
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application xlsApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook xlsBook;
                Sheets xlHojas;

                xlsApp.DisplayAlerts = false;
                xlsApp.Visible = false;
                string PathAr = Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Excel\StepthManager.xlsx");
                xlsBook = xlsApp.Workbooks.Open(PathAr);
                xlHojas = xlsBook.Sheets;
                xlsBook.Close(true);
                xlsApp.Quit();
                releaseObject(xlHojas);
                releaseObject(xlsBook);
                releaseObject(xlsApp);
                return true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ ValidarExcel");
                return false;
            }            
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ releaseObject");
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        #region Proceso descarga de formato

        private void bgwFormato_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                List<Producto> ListaProductos = this.GenerarListaMatriz();
                e.Result = ListaProductos;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ bgwFormato_DoWork");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgwFormato_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                int Avance = e.ProgressPercentage;
                this.lblMessage.Text =  "Generando Formato. Espere un momento....";                
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmInventario ~ bgwFormato_ProgressChanged");
            }
        }

        private void bgwFormato_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    List<Producto> ListaProductos = (List<Producto>)e.Result;
                    Microsoft.Office.Interop.Excel.Application xlsApp = new Microsoft.Office.Interop.Excel.Application();
                    Workbook xlsBook;
                    Worksheet Inventario;
                    Sheets xlHojas;
                    xlsApp.DisplayAlerts = false;
                    xlsApp.Visible = false;
                    string PathAr = Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Excel\StepthManager.xlsx");
                    xlsBook = xlsApp.Workbooks.Open(PathAr);
                    xlHojas = xlsBook.Sheets;
                    Inventario = (Worksheet)xlHojas["Inventario"];

                    int FilaInicio = 4;
                    if (ListaProductos.Count != 0)
                    {
                        int Items = ListaProductos.Count;
                        foreach (Producto Item in ListaProductos)
                        {
                            Inventario.Cells[FilaInicio, 1] = Item.Clave;
                            Inventario.Cells[FilaInicio, 2] = Item.NombreProducto;
                            Inventario.Cells[FilaInicio, 3] = Item.Existencia;
                            Inventario.Cells[FilaInicio, 4] = 0;
                            Inventario.Cells[FilaInicio, 6] = Item.IDProducto;
                            FilaInicio++;
                        }
                    }

                    SaveFileDialog saveFileDialogExcel = new SaveFileDialog();
                    saveFileDialogExcel.Filter = "Excel Files|*.xlsx";
                    saveFileDialogExcel.FileName = "";
                    saveFileDialogExcel.Title = "Seleccione donde guardar el excel";
                    saveFileDialogExcel.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString();
                    if (saveFileDialogExcel.ShowDialog() == DialogResult.OK)
                    {
                        xlsBook.SaveAs(saveFileDialogExcel.FileName);
                    }

                    xlsBook.Close();
                    xlsApp.Quit();
                    releaseObject(xlHojas);
                    releaseObject(xlsBook);
                    releaseObject(Inventario);
                    releaseObject(xlsApp);
                }
                lblMessage.Visible = false;
                lblMessage.Text = string.Empty;
                this.btnDescargarArchivo.Enabled = true;
            }
            catch (Exception ex)
            {
                lblMessage.Visible = false;
                lblMessage.Text = string.Empty;
                this.btnDescargarArchivo.Enabled = true;
                LogError.AddExcFileTxt(ex, "frmInventario ~ bgwFormato_RunWorkerCompleted");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void bgwActualizarExistencias_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ActualizarExistenciasExcel(e.Argument.ToString());
            }
            catch(Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReporteEstadoResultados ~ bgwActualizarExistencias_DoWork");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgwActualizarExistencias_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //if (e.Result != null)
                //{
                //}
                //else
                //{
                //    MessageBox.Show("Error al generar el reporte. ", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmReporteEstadoResultados ~ bgwGenerarReporte_RunWorkerCompleted");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lblMessage.Visible = false;
                lblMessage.Text = string.Empty;
                this.Cursor = Cursors.Default;
                AllowClick = true;
            }
        }

        private bool ActualizarExistenciasExcel(string FileName)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application xlsApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlsApp == null)
                {
                    MessageBox.Show("EXCEL could not be started. Check that your office installation and project references are correct.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                Workbook xlsBook;
                Worksheet Inventario;
                Sheets xlHojas;
                string PathAr = FileName;
                xlsBook = xlsApp.Workbooks.Open(PathAr);
                xlHojas = xlsBook.Sheets;
                Inventario = (Worksheet)xlHojas["Inventario"];
                try
                {
                    xlsApp.DisplayAlerts = false;
                    xlsApp.Visible = false;                    
                    int FilaInicio = 4;
                    infoProducto.ImportarExcel = new System.Data.DataTable();
                    infoProducto.ImportarExcel.Columns.Add("IDProducto", typeof(string));
                    infoProducto.ImportarExcel.Columns.Add("Clave", typeof(string));
                    infoProducto.ImportarExcel.Columns.Add("ConteoFisico", typeof(decimal));
                    while ((Inventario.Cells[FilaInicio, 1] as Microsoft.Office.Interop.Excel.Range).Value2 != null)
                    {
                        string Codigo = "", IDProducto = "";
                        decimal ConteoFisico = 0;
                        IDProducto = (Inventario.Cells[FilaInicio, 6] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                        Codigo = (Inventario.Cells[FilaInicio, 1] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                        decimal.TryParse((Inventario.Cells[FilaInicio, 4] as Microsoft.Office.Interop.Excel.Range).Value2.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out ConteoFisico);
                        infoProducto.ImportarExcel.Rows.Add(new Object[] { IDProducto, Codigo, ConteoFisico });
                        FilaInicio++;
                    }

                    Producto AuxProducto = new Producto();
                    Producto_Negocio ProdNeg = new Producto_Negocio();
                    AuxProducto.Conexion = Comun.Conexion;
                    AuxProducto.IDSucursal = Comun.IDSucursalCaja;
                    AuxProducto.IDUsuario = Comun.IDUsuario;
                    AuxProducto.ImportarExcel = infoProducto.ImportarExcel;
                    ProdNeg.AInventarioEXCEL(AuxProducto);
                    if (AuxProducto.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Datos no se guardaron correctamente. Intente mas tarde", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    LogError.AddExcFileTxt(ex, "Generar Reporte Excel");
                    return false;
                }
                finally
                {
                    xlsBook.Close();
                    xlsApp.Quit();
                    releaseObject(xlHojas);
                    releaseObject(xlsBook);
                    releaseObject(Inventario);
                    releaseObject(xlsApp);
                }
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
