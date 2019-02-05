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
    public partial class frmCursoTemasSubTemasCapacitacion : Form
    {
        private int TipoForm = 0;
        private CapacitacionCurso _DatosCapacitacionCurso;
        public CapacitacionCurso DatosCapacitacionCurso
        {
            get { return _DatosCapacitacionCurso; }
            set { _DatosCapacitacionCurso = value; }
        }

        private string IDCurso = string.Empty;
        private string IDEmpleado = string.Empty;
        private string IDCapacitacion = string.Empty;

        public frmCursoTemasSubTemasCapacitacion(CapacitacionCurso Datos)
        {
            try
            {
                InitializeComponent();
                this.IDCurso = Datos.IDCurso;
                this.IDEmpleado = Datos.IDEmpleado;
                this.IDCapacitacion = Datos.IDCapacitacion;
                this.TipoForm = 1;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCursoTemasSubTemasCapacitacion ~ frmCursoTemasSubTemasCapacitacion()");
            }
        }

        private void IniciarForm()
        {
            try
            {
                this.CargarGridTemasSubTemas();
                //this.dtpFechaInicio.Value = DateTime.Today;
                //this.dateTimePicker1.Value = DateTime.Today;
                //this.dtpFechaInicio.Focus();
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

        private void CargarGridTemasSubTemas()
        {
            try
            {
                CapacitacionCurso DatosAux = new CapacitacionCurso();
                CapacitacionCurso_Negocio CN = new CapacitacionCurso_Negocio();
                DatosAux.IDCapacitacion = this.IDCapacitacion;
                DatosAux.IDEmpleado = this.IDEmpleado;
               // DatosAux.IDCurso = this.IDCurso;
                DatosAux.Conexion = Comun.Conexion;
                CN.ObtenerTemasSubTemas(DatosAux);
                this.dgvTemasSubTemas.DataSource = null;
                this.dgvTemasSubTemas.AutoGenerateColumns = false;
                this.dgvTemasSubTemas.DataSource = DatosAux.TablaDatos;
            }
            catch (Exception ex)
            {
                throw ex;
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
                LogError.AddExcFileTxt(ex, "frmCursoTemasSubTemasCapacitacion ~ btnSalir_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmHorarioEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                this.IniciarForm();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmCursoTemasSubTemasCapacitacion ~ frmHorarioEmpleado_Load");
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
                    CapacitacionCurso Datos = this.ObtenerDatos();
                    CapacitacionCurso_Negocio CN = new CapacitacionCurso_Negocio();
                    CN.AbcCalificaciones(Datos);
                    if (Datos.Completado)
                    {
                        MessageBox.Show("Datos guardados correctamente.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this._DatosCapacitacionCurso = Datos;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        if (Datos.Resultado > 0)
                        {
                            List<Error> LstError = new List<Error>();
                            LstError.Add(new Error { Numero = 1, Descripcion = Datos.MensajeError, ControlSender = this });
                            this.MostrarMensajeError(LstError);
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
                LogError.AddExcFileTxt(ex, "frmNuevoCurso ~ btnGuardar_Click");
                MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private CapacitacionCurso ObtenerDatos()
        {
            try
            {
                CapacitacionCurso DatosAux = new CapacitacionCurso();
                CapacitacionCurso Aux = this.ObtenerDatosCalificacion(this.dgvTemasSubTemas);
                DatosAux.IDCalificacion = TipoForm == 2 ? this._DatosCapacitacionCurso.IDCalificacion : string.Empty;
                DatosAux.IDEmpleado = this.IDEmpleado;
                DatosAux.IDCapacitacion = this.IDCapacitacion;
                DatosAux.IDCalificacion = Aux.IDCalificacion;
                DatosAux.IDVenta = "";
                DatosAux.TablaCalificaciones = this.GenerarCalificaciones();
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

        private DataTable GenerarCalificaciones()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla.Columns.Add("IDSubTema", typeof(string));
                Tabla.Columns.Add("Calificacion", typeof(decimal));
                foreach (DataGridViewRow Fila in this.dgvTemasSubTemas.Rows)
                {
                    decimal Calificacion = 0;
                    decimal.TryParse(Fila.Cells["Calificacion"].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out Calificacion);
                    string IDSubTemas = Fila.Cells["IDSubTema"].Value.ToString();
                    Tabla.Rows.Add(new object[] { IDSubTemas, Calificacion });
                }
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private CapacitacionCurso ObtenerDatosCalificacion(DataGridView DGV)
        {
            try
            {
                CapacitacionCurso DatosAux = new CapacitacionCurso();
                Int32 RowData = DGV.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (DGV.SelectedRows.Count == 1)
                {
                    DataGridViewRow FilaDatos = DGV.Rows[RowData];
                    DatosAux.IDCalificacion = FilaDatos.Cells["IDCalificacion"].Value.ToString();
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
        private List<Error> ValidarDatos()
        {
            try
            {
                List<Error> Errores = new List<Error>();
          
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PanelMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
