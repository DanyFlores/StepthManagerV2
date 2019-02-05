using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
namespace StephManager.ClasesAux
{
    public class LectorHuella : DPFP.Capture.EventHandler
    {
        #region Variables

        public DPFP.Template Template;
        delegate void Function();
        private DPFP.Processing.Enrollment Enroller = new DPFP.Processing.Enrollment();
        private DPFP.Capture.Capture Capturer;
        private DPFP.Verification.Verification Verificator = new DPFP.Verification.Verification();
        public frmCatEmpleadoHuella FrmCapturaHuella;
        public frmChecarEntradaSalida FrmChecar;
        public DataTable DatosHuellas;
        List<Usuario> Lista = new List<Usuario>();
        public string IDUsuario = "";
        public bool acceso = false;
        public int TipoForm = 0;

        #endregion

        #region Metodos Generales

        public void Load()
        {
            try
            {
                Init();
                Start();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ Load()");
                if (TipoForm == 1)
                {
                    this.FrmChecar.Invoke(new Function(delegate()
                    {
                        FrmChecar.lblInstrucciones.Text = "No se puede iniciar la captura!";
                        FrmChecar.lblInstrucciones.BackColor = Color.Red;
                    }));
                }
                else if (TipoForm == 2)
                {
                    this.FrmCapturaHuella.Invoke(new Function(delegate()
                    {
                        FrmCapturaHuella.lblInstrucciones.Text = "No se puede iniciar la captura!";
                        FrmCapturaHuella.lblInstrucciones.BackColor = Color.Red;
                    }));
                }
            }
        }

        public void Close()
        {
            try
            {
                Stop();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region EventHandler Members
        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            try
            {
                if (TipoForm == 1)
                    this.CapturarChecado(Sample);
                else if (TipoForm == 2)
                    ProcesarPersonal(Sample);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ OnComplete");
            }
        }
        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
        }
        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
        }
        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
        }
        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
        }
        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            try
            {
                if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                {
                    if (TipoForm == 1)
                    {
                        this.FrmChecar.Invoke(new Function(delegate()
                        {
                            FrmChecar.lblInstrucciones.Text = "The quality of the fingerprint sample is good.";
                            FrmChecar.lblInstrucciones.BackColor = Color.GreenYellow;
                        }));
                    }
                    else if (TipoForm == 2)
                    {
                        this.FrmCapturaHuella.Invoke(new Function(delegate()
                        {
                            FrmCapturaHuella.lblInstrucciones.Text = "The quality of the fingerprint sample is good.";
                            FrmCapturaHuella.lblInstrucciones.BackColor = Color.GreenYellow;
                        }));
                    }
                }
                else
                {


                    if (TipoForm == 1)
                    {
                        this.FrmChecar.Invoke(new Function(delegate()
                        {
                            FrmChecar.lblInstrucciones.Text = "The quality of the fingerprint sample is poor.";
                            FrmChecar.lblInstrucciones.BackColor = Color.Red;
                        }));
                    }
                    else if (TipoForm == 2)
                    {
                        this.FrmCapturaHuella.Invoke(new Function(delegate()
                        {
                            FrmCapturaHuella.lblInstrucciones.Text = "The quality of the fingerprint sample is poor.";
                            FrmCapturaHuella.lblInstrucciones.BackColor = Color.Red;
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ OnSampleQuality");
            }
        }
        #endregion

        #region Lector Huella

        public bool Init()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();
                if (null != Capturer)
                {
                    Capturer.EventHandler = this;
                    return true;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ Init");
                return false;
            }
        }

        public void Start()
        {
            try
            {
                if (null != Capturer)
                {
                    Capturer.StartCapture();
                    if (TipoForm == 1)
                    {
                        this.FrmChecar.Invoke(new Function(delegate()
                        {
                            FrmChecar.lblInstrucciones.Text = "Use el lector para escanear su huella digital.";
                            FrmChecar.lblInstrucciones.BackColor = Color.GreenYellow;
                        }));
                    }
                    else if (TipoForm == 2)
                    {
                        this.FrmCapturaHuella.Invoke(new Function(delegate()
                        {
                            FrmCapturaHuella.lblInstrucciones.Text = "Use el lector para escanear su huella digital.";
                            FrmCapturaHuella.lblInstrucciones.BackColor = Color.GreenYellow;
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ Start");
            }
        }

        public void Stop()
        {
            try
            {
                if (null != Capturer)
                {
                    Capturer.StopCapture();
                    Capturer.Dispose();
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ Stop");
            }
        }

        #endregion

        #region frmLogin
        public void CapturarChecado(DPFP.Sample Sample)
        {
            try
            {
                if (DatosHuellas == null)
                {
                    Usuario_Negocio UN = new Usuario_Negocio();
                    Usuario DatosAux = new Usuario { Conexion = Comun.Conexion };
                    UN.ObtenerHuellasDigitales(DatosAux);
                    DatosHuellas = DatosAux.TablaDatos;
                }
                VerificarChecado(FrmChecar, Sample, DatosHuellas, ref acceso, ref IDUsuario);
                if (acceso == true)
                {
                    bool Concluido = false;
                    this.FrmChecar.Invoke(new Function(delegate()
                     {
                         Concluido = FrmChecar.Checar(IDUsuario);
                     }));
                    if (Concluido)
                    {
                        FrmChecar.DialogResult = DialogResult.OK;
                        Template = null;
                        FrmChecar.Lector.Stop();
                        FrmChecar.Lector = new LectorHuella();
                    }
                    else
                    {
                        FrmChecar.Lector.Stop();
                        FrmChecar.Invoke(new Function(delegate()
                        {
                            FrmChecar.lblInstrucciones.Text = "Error al procesar la huella.";
                            FrmChecar.lblInstrucciones.BackColor = Color.Red;
                        }));
                        Thread.Sleep(2400);
                        Template = null;
                        FrmChecar.Lector = new LectorHuella();
                        FrmChecar.frmChecarEntradaSalida_Load(new object(), new EventArgs());
                    }
                }
                else
                {
                    FrmChecar.Invoke(new Function(delegate()
                    {
                        FrmChecar.lblInstrucciones.Text = "Huella no registrada.";
                        FrmChecar.lblInstrucciones.BackColor = Color.Red;
                    }));
                    Thread.Sleep(2400);
                    FrmChecar.Invoke(new Function(delegate()
                    {
                        FrmChecar.lblInstrucciones.Text = "Use el lector para escanear su huella digital.";
                        FrmChecar.lblInstrucciones.BackColor = Color.GreenYellow;
                    }));
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ CapturarChecado");
            }
        }
        public bool ProcesarChecado(DPFP.Sample Sample, DPFP.Template templateGuardado, frmChecarEntradaSalida FrmChecar)
        {
            try
            {
                DrawPictureChecar(ConvertSampleToBitmapLogin(Sample), FrmChecar);
                DPFP.FeatureSet features = ExtractFeaturesChecar(Sample, DPFP.Processing.DataPurpose.Verification);
                if (features != null)
                {
                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                    Verificator.Verify(features, templateGuardado, ref result);

                    if (result.Verified)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ ProcesarChecado");
                return false;
            }
        }
        public DPFP.FeatureSet ExtractFeaturesChecar(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            try
            {
                DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();
                DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
                DPFP.FeatureSet features = new DPFP.FeatureSet();
                Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);
                if (feedback == DPFP.Capture.CaptureFeedback.Good)
                    return features;
                else
                    return null;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ ExtractFeaturesChecar");
                return null;
            }
        }
        private void OnTemplate(DPFP.Template template)
        {
            try
            {
                Template = template;
                if (Template != null)
                {
                    this.FrmCapturaHuella.Invoke(new Function(delegate()
                    {
                        FrmCapturaHuella.lblInstrucciones.Text = "La plantilla de huellas dactilares está preparado para la verificación de huellas dactilares.";
                        FrmCapturaHuella.lblInstrucciones.BackColor = Color.GreenYellow;
                    }));
                }
                else
                {
                    this.FrmCapturaHuella.Invoke(new Function(delegate()
                    {
                        FrmCapturaHuella.lblInstrucciones.Text = "La plantilla de huella digital no es válida. Repita el registro de huellas dactilares.";
                        FrmCapturaHuella.lblInstrucciones.BackColor = Color.Red;
                    }));
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ OnTemplate");
            }

        }
        public Bitmap ConvertSampleToBitmapLogin(DPFP.Sample Sample)
        {
            try
            {
                DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();
                Bitmap bitmap = null;
                Convertor.ConvertToPicture(Sample, ref bitmap);
                return bitmap;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ OnTemplate");
                return null;
            }
        }
        public void DrawPictureChecar(Bitmap bitmap, frmChecarEntradaSalida FrmChecar)
        {
            try
            {
                FrmChecar.ImgHuella.Image = new Bitmap(bitmap, FrmChecar.ImgHuella.Size);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ DrawPictureChecar");
            }
        }
        public void VerificarChecado(frmChecarEntradaSalida FrmChecar, DPFP.Sample Sample, DataTable datosHuellas, ref bool acceso, ref string id_usuario)
        {
            try
            {
                foreach (DataRow usuario in datosHuellas.Rows)
                {
                    DPFP.Template templateGuardado = new DPFP.Template();
                    templateGuardado.DeSerialize(ConvertirStringToBytes.StringToBytes(usuario["HuellaDigital"].ToString()));
                    if (ProcesarChecado(Sample, templateGuardado, FrmChecar))
                    {
                        id_usuario = usuario["IDEmpleado"].ToString();
                        acceso = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuell ~ VerificarChecado");
            }
        }
        #endregion

        #region FrmCatEmpleadoHuella

        public void ProcesarPersonal(DPFP.Sample Sample)
        {
            try
            {
                bool banRegistrado = true;
                DrawPicturePersonal(ConvertSampleToBitmapPersonal(Sample));
                DPFP.FeatureSet features = ExtractFeaturesPersonal(Sample, DPFP.Processing.DataPurpose.Enrollment);
                if (features != null)
                    try
                    {
                        Enroller.AddFeatures(features);
                    }
                    catch (Exception)
                    {
                        //LogError.AddExcFileTxt(ex, "LectorHuella ~ ProcesarPersonal");
                        this.FrmCapturaHuella.Invoke(new Function(delegate()
                        {
                            FrmCapturaHuella.lblInstrucciones.Text = "Error al procesar las huellas.";
                            FrmCapturaHuella.lblInstrucciones.BackColor = Color.Red;
                        }));
                        Thread.Sleep(2400);
                    }
                    finally
                    {
                        UpdateStatusPersonal();
                        switch (Enroller.TemplateStatus)
                        {
                            case DPFP.Processing.Enrollment.Status.Ready:
                                Template = Enroller.Template;
                                if (DatosHuellas == null)
                                {
                                    Usuario_Negocio UN = new Usuario_Negocio();
                                    Usuario DatosAux = new Usuario { Conexion = Comun.Conexion };
                                    UN.ObtenerHuellasDigitales(DatosAux);
                                    DatosHuellas = DatosAux.TablaDatos;
                                }
                                foreach (DataRow usuario in DatosHuellas.Rows)
                                {
                                    DPFP.Template templateGuardado = new DPFP.Template();
                                    templateGuardado.DeSerialize(ConvertirStringToBytes.StringToBytes(usuario["HuellaDigital"].ToString()));
                                    if (procesarPersonal(Sample, templateGuardado))
                                    {
                                        banRegistrado = false;
                                        break;
                                    }
                                }
                                if (banRegistrado)
                                {
                                    FrmCapturaHuella.Lector.Stop();
                                    activaBtnPersonal();
                                }
                                else
                                {
                                    Enroller.Clear();
                                    FrmCapturaHuella.Lector.Stop();
                                    FrmCapturaHuella.Invoke(new Function(delegate()
                                    {
                                        FrmCapturaHuella.lblInstrucciones.Text = "La huella ya está registrada.";
                                        FrmCapturaHuella.lblInstrucciones.BackColor = Color.Red;
                                        //System.Windows.Forms.MessageBox.Show("La huella ya está registrada.", "Sistema Administrador CSL", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                                        //FrmCapturaHuella.DialogResult = System.Windows.Forms.DialogResult.Abort;
                                    }));
                                    Thread.Sleep(2400);
                                    Template = null;
                                    FrmCapturaHuella.Lector = new LectorHuella();
                                    FrmCapturaHuella.frmCatEmpleadoHuella_Load(new object(), new EventArgs());
                                    UpdateStatusPersonal();
                                }
                                break;

                            case DPFP.Processing.Enrollment.Status.Failed:
                                Enroller.Clear();
                                FrmCapturaHuella.Lector.Stop();
                                UpdateStatusPersonal();
                                Template = null;
                                FrmCapturaHuella.Lector.Start();
                                break;
                        }
                    }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ ProcesarPersonal");
            }
        }
        public DPFP.FeatureSet ExtractFeaturesPersonal(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            try
            {
                DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();
                DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
                DPFP.FeatureSet features = new DPFP.FeatureSet();
                Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);
                if (feedback == DPFP.Capture.CaptureFeedback.Good)

                    return features;
                else
                    return null;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ ExtractFeaturesPersonal");
                return null;
            }
        }
        public Bitmap ConvertSampleToBitmapPersonal(DPFP.Sample Sample)
        {
            try
            {
                DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();
                Bitmap bitmap = null;
                Convertor.ConvertToPicture(Sample, ref bitmap);
                return bitmap;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ ConvertSampleToBitmapPersonal");
                return null;
            }
        }
        public void DrawPicturePersonal(Bitmap bitmap)
        {
            try
            {
                FrmCapturaHuella.ImgHuella.Image = new Bitmap(bitmap, FrmCapturaHuella.ImgHuella.Size);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ DrawPicturePersonal");
            }
        }
        private void UpdateStatusPersonal()
        {
            try
            {
                SetStatus(String.Format("Muestras requeridas: {0}", Enroller.FeaturesNeeded), (int)Enroller.FeaturesNeeded);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ UpdateStatusPersonal");
            }
        }
        public void activaBtnPersonal()
        {
            try
            {
                EnableBtnPersonal(true);
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ activaBtnPersonal");
            }
        }
        protected void EnableBtnPersonal(bool opcion)
        {
            try
            {
                this.FrmCapturaHuella.Invoke(new Function(delegate()
                {
                    FrmCapturaHuella.btnGuardar.Enabled = opcion;
                    if (Template != null)
                    {
                        FrmCapturaHuella.lblInstrucciones.Text = "La muestra es válida";
                        FrmCapturaHuella.lblInstrucciones.BackColor = Color.GreenYellow;
                        FrmCapturaHuella.btnGuardar.Enabled = true;
                        //FrmCapturaHuella.ModificarHuella = true;
                    }
                    else
                    {
                        FrmCapturaHuella.lblInstrucciones.Text = "La muestra no es válida";
                        FrmCapturaHuella.lblInstrucciones.BackColor = Color.Red;
                    }
                }));
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ EnableBtnPersonal");
            }
        }
        protected void SetStatus(string status, int faltantes)
        {
            try
            {
                this.FrmCapturaHuella.Invoke(new Function(delegate()
                {
                    FrmCapturaHuella.lblInstrucciones.Text = status;
                    if (faltantes != 0)
                    {
                        FrmCapturaHuella.btnGuardar.Enabled = false;
                    }
                }));
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ SetStatus");
            }
        }
        public bool procesarPersonal(DPFP.Sample Sample, DPFP.Template templateGuardado)
        {
            try
            {
                DPFP.FeatureSet features = ExtractFeaturesPersonal(Sample, DPFP.Processing.DataPurpose.Verification);
                if (features != null)
                {
                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                    Verificator.Verify(features, templateGuardado, ref result);

                    if (result.Verified)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "LectorHuella ~ procesarPersonal");
                return false;
            }
        }
        #endregion

    }
}
