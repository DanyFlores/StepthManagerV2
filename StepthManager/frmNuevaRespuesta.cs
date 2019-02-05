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
using CreativaSL.Dll.Validaciones;
using StephManager.ClasesAux;
using System.IO;

namespace StephManager
{
    public partial class frmNuevaRespuesta : Form
    {
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //#region Propiedades / Variables 

        //private bool NuevoRegistro;
        //private Respuesta _DatosRespuesta;
        //public Respuesta DatosPregunta
        //{
        //    get { return _DatosRespuesta; }
        //    set { _DatosRespuesta = value; }
        //}

        //#endregion

        //#region Constructores

        //public frmNuevaRespuesta()
        //{
        //    try
        //    {
        //        InitializeComponent();
        //        NuevoRegistro = true;
        //        this._DatosRespuesta = new Pregunta();
        //    }
        //    catch(Exception ex)
        //    {
        //        LogError.AddExcFileTxt(ex, "frmNuevaRespuesta ~ frmNuevaRespuesta()");
        //    }
        //}

        //public frmNuevaRespuesta(Respuesta DatosAux)
        //{
        //    try
        //    {
        //        InitializeComponent();
        //        NuevoRegistro = false;
        //        this._DatosRespuesta = DatosAux;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError.AddExcFileTxt(ex, "frmNuevaRespuesta ~ frmNuevaRespuesta()");
        //    }
        //}

        //#endregion

        //#region Métodos

        //private void CargarDatosAModificar(Pregunta DatosAux)
        //{
        //    try
        //    {
        //        if (this.ExisteItemEnCombo(DatosAux.IDTipoPregunta))
        //            this.cmbTipoPregunta.SelectedValue = DatosAux.IDTipoPregunta;
        //        this.txtPregunta.Text = DatosAux.Titulo;
        //        this.chkRequerida.Checked = DatosAux.EsRequerida;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private bool ExisteItemEnCombo(int ID)
        //{
        //    try
        //    {
        //        bool Band = false;
        //        if (this.cmbTipoPregunta.Items.Count > 0)
        //        {
        //            foreach (TipoProducto Aux in this.cmbTipoPregunta.Items)
        //            {
        //                if (Aux.IDTipoProducto == ID)
        //                {
        //                    Band = true;
        //                    break;
        //                }
        //            }
        //        }
        //        return Band;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private void IniciarForm()
        //{
        //    try
        //    {
        //        this.LlenarComboTipoPregunta();
        //        if (NuevoRegistro)
        //            this.IniciarDatos();
        //        else
        //            this.CargarDatosAModificar(this._DatosRespuesta);
        //        this.ActiveControl = this.cmbTipoPregunta;
        //        this.cmbTipoPregunta.Focus();
          //        if (File.Exists(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo)))
            //    {
              //      this.pictureBox1.Image = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Documents\" + Comun.UrlLogo));
                //}
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    //private void IniciarDatos()
    //{
    //    try
    //    {
    //        this.txtPregunta.Text = string.Empty;
    //        this.chkRequerida.Checked = false;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    //private void LlenarComboTipoPregunta()
    //{
    //    try
    //    {
    //        TipoPregunta Datos = new TipoPregunta { IncluirSelect = true, Conexion = Comun.Conexion };
    //        Encuesta_Negocio EN = new Encuesta_Negocio();
    //        this.cmbTipoPregunta.DataSource = EN.LlenarComboTipoPregunta(Datos);
    //        this.cmbTipoPregunta.DisplayMember = "Descripcion";
    //        this.cmbTipoPregunta.ValueMember = "IDTipoPregunta";
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    //private void MostrarMensajeError(List<Error> Errores)
    //{
    //    try
    //    {
    //        string CadenaErrores = string.Empty;
    //        CadenaErrores = "No se pudo guardar la información. Se presentaron los siguientes errores: \r\n";
    //        foreach (Error item in Errores)
    //        {
    //            CadenaErrores += item.Numero + "\t" + item.Descripcion + "\r\n";
    //        }
    //        this.txtMensajeError.Visible = true;
    //        this.txtMensajeError.Text = CadenaErrores;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    //private TipoPregunta ObtenerItemSeleccionado()
    //{
    //    try
    //    {
    //        TipoPregunta DatosAux = new TipoPregunta();
    //        if (this.cmbTipoPregunta.SelectedIndex != -1)
    //        {
    //            DatosAux = (TipoPregunta)this.cmbTipoPregunta.SelectedItem;
    //        }
    //        return DatosAux;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    //private Pregunta ObtenerDatos()
    //{
    //    try
    //    {
    //        Pregunta Datos = new Pregunta();
    //        TipoPregunta TPAux = this.ObtenerItemSeleccionado();
    //        Datos.IDPregunta = NuevoRegistro ? string.Empty : this._DatosRespuesta.IDPregunta;
    //        Datos.IDTipoPregunta = TPAux.IDTipoPregunta;
    //        if (TPAux.OpcionMultiple)
    //            Datos.RequiereRespuestas = true;
    //        else
    //            Datos.RequiereRespuestas = false;
    //        Datos.TipoPreguntaDesc = TPAux.Descripcion;
    //        Datos.EsRequerida = this.chkRequerida.Checked;
    //        Datos.Titulo = this.txtPregunta.Text;
    //        return Datos;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    //private List<Error> ValidarDatos()
    //{
    //    try
    //    {
    //        List<Error> Errores = new List<Error>();
    //        int Aux = 0;
    //        TipoPregunta TPAux = this.ObtenerItemSeleccionado();
    //        if(TPAux.IDTipoPregunta <= 0)
    //            Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción para tipo de pregunta.", ControlSender = this.cmbTipoPregunta });
    //        if(string.IsNullOrEmpty(this.txtPregunta.Text.Trim()))
    //            Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la pregunta.", ControlSender = this.txtPregunta});
    //        return Errores;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    //#endregion

    //#region Eventos

    //private void btnCancelar_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        this.DialogResult = DialogResult.Cancel;
    //    }
    //    catch (Exception ex)
    //    {
    //        LogError.AddExcFileTxt(ex, "frmNuevaPregunta ~ btnCancelar_Click");
    //        MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
    //    }
    //}

    //private void btnGuardar_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        List<Error> ListaErrores = this.ValidarDatos();
    //        if (ListaErrores.Count == 0)
    //        {
    //            this._DatosRespuesta = this.ObtenerDatos();
    //            this.DialogResult = DialogResult.OK;
    //        }
    //        else
    //            this.MostrarMensajeError(ListaErrores);
    //    }
    //    catch (Exception ex)
    //    {
    //        LogError.AddExcFileTxt(ex, "frmNuevaPregunta ~ btnGuardar_Click");
    //        MessageBox.Show(Comun.MensajeError, Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
    //    }
    //}

    //private void frmNuevaPregunta_Load(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        this.IniciarForm();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    //#endregion
}
}
