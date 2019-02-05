using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using Microsoft.Office.Interop.Excel;
using StephManager.ClasesAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StephManager
{
    public partial class frmExcelER : Form
    {
        public frmExcelER()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reporte_Negocio Neg = new Reporte_Negocio();
            EstadoResultados Datos = Neg.ObtenerDetalleEstadoResultados(Comun.Conexion, 4);
            GenerarEstadoDeResultados(Datos.Detalle, Datos.IngresoMensual, Datos.IngresoAnual, Datos.CostoVentasMensual, Datos.CostoVentasAnual, 
                Datos.ComisionMensual, Datos.ComisionAnual, Datos.ImpuestoMensual, Datos.ImpuestoAnual, Datos.Anio, Datos.MesDesc, Datos.Sucursal);
        }


        private bool GenerarEstadoDeResultados(List<EstadoResultadosDetalle> Detalle, decimal IngresosM, decimal IngresosA, decimal CostoVM, decimal CostoVA, decimal ComisionM, decimal ComisionA, decimal ImpuestoMensual, decimal ImpuestoAnual, int Año, string Mes, string Sucursal)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application xlsApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlsApp == null)
                {
                    MessageBox.Show("EXCEL could not be started. Check that your office installation and project references are correct.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                Workbook xlsBook = xlsApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Worksheet wsEstadoResultados = (Worksheet)xlsBook.Worksheets[1];
                wsEstadoResultados.Name = "Estado de Resultados";
                if (wsEstadoResultados == null)
                {
                    MessageBox.Show("Worksheet could not be created. Check that your office installation and project references are correct.", Comun.Sistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    xlsApp.DisplayAlerts = false;
                    xlsApp.Visible = false;
                    int FilaInicio = 9;
                    int ColumnaDatos = 1;
                    int Contador = 4;

                    // *********** Inicializar ancho de columnas **************
                    //wsEstadoResultados.Columns["A"].ColumnWidth = 8.43;
                    //wsEstadoResultados.Columns["B"].ColumnWidth = 27.86;
                    //wsEstadoResultados.Columns["C"].ColumnWidth = 13.71;
                    //wsEstadoResultados.Columns["D"].ColumnWidth = 13.71;
                    //wsEstadoResultados.Columns["E"].ColumnWidth = 12.14;

                    // ********************************************************
                    wsEstadoResultados.Cells[2, 1] = "ESTADO DE RESULTADOS " + Mes.ToUpper() + " - " + Año.ToString();
                    wsEstadoResultados.Cells[3, 1] = string.Format("SUCURSAL {0}", Sucursal.ToUpper());
                    Range Encabezado = wsEstadoResultados.get_Range("A2", "E3");
                    Encabezado.Font.Bold = true;
                    Encabezado.Font.Name = "Tahoma";
                    Encabezado.Font.Size = 10;
                    //Encabezado.Interior.Pattern = XlPattern.xlPatternSolid;
                    //Encabezado.Interior.PatternColor = XlColorIndex.xlColorIndexAutomatic;
                    //Encabezado.Interior.Color = 10092543;

                    Encabezado.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
                    Encabezado.Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = XlColorIndex.xlColorIndexAutomatic;
                    Encabezado.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThick;

                    Encabezado.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    Encabezado.Borders[XlBordersIndex.xlEdgeTop].ColorIndex = XlColorIndex.xlColorIndexNone;
                    Encabezado.Borders[XlBordersIndex.xlEdgeTop].Weight = XlBorderWeight.xlThin;


                    this.EstablecerFormatoXColumna(wsEstadoResultados);
                    Range Titulos = wsEstadoResultados.get_Range("A5", "E5");
                    Titulos.Font.Bold = true;
                    //Alineación
                    Titulos.VerticalAlignment = XlVAlign.xlVAlignCenter;
                    Titulos.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    // ********************** ENCABEZADO **********************
                    wsEstadoResultados.Cells[5, 1] = "No";
                    wsEstadoResultados.Cells[5, 2] = "Concepto";
                    wsEstadoResultados.Cells[5, 3] = "$ / Mes";
                    wsEstadoResultados.Cells[5, 4] = "$ / Anual";
                    wsEstadoResultados.Cells[5, 5] = "% Ventas";
                    // *************** SECCIÓN PRINCIPAL **********************

                    //Formatos Encabezados
                    wsEstadoResultados.get_Range("C6", "C9").NumberFormat = "$#,##0;[Red]$#,##0";
                    wsEstadoResultados.get_Range("D6", "D9").NumberFormat = "$#,##0;[Red]$#,##0";
                    wsEstadoResultados.get_Range("E6", "E9").NumberFormat = "0.00%";


                    wsEstadoResultados.get_Range("C6", string.Format("E{0}", 17 + Detalle.Count)).HorizontalAlignment = XlHAlign.xlHAlignRight;
                    wsEstadoResultados.get_Range("A6", string.Format("A{0}", 17 + Detalle.Count)).HorizontalAlignment = XlHAlign.xlHAlignRight;
                    // No.
                    wsEstadoResultados.Cells[6, 1] = 1;
                    wsEstadoResultados.Cells[7, 1] = 2;
                    wsEstadoResultados.Cells[8, 1] = 3;
                    wsEstadoResultados.Cells[9, 1] = 3;
                    // Concepto
                    wsEstadoResultados.Cells[6, 2] = "INGRESOS";
                    wsEstadoResultados.Cells[7, 2] = "COSTO DE VENTAS";
                    wsEstadoResultados.Cells[8, 2] = "COMISIONES S/VENTAS";
                    wsEstadoResultados.Cells[9, 2] = "UTILIDAD BRUTA";
                    // Mes
                    wsEstadoResultados.Cells[6, 3] = IngresosM;
                    wsEstadoResultados.Cells[7, 3] = CostoVM;
                    wsEstadoResultados.Cells[8, 3] = ComisionM;
                    Range Utilidad = (Range)wsEstadoResultados.Cells[9, 3];
                    Utilidad.Formula = "=C6-C7-C8";
                    // Anual
                    wsEstadoResultados.Cells[6, 4] = IngresosA;
                    wsEstadoResultados.Cells[7, 4] = CostoVA;
                    wsEstadoResultados.Cells[8, 4] = ComisionA;
                    // % Ventas
                    Range UtilidadA = (Range)wsEstadoResultados.Cells[9, 4];
                    UtilidadA.Formula = "= D6-D7-D8";
                    wsEstadoResultados.get_Range("E6", "E9").FormulaR1C1 = "=RC3/R6C3";

                    wsEstadoResultados.get_Range("A9", "E9").Font.Bold = true;
                    // ********************************************************

                    IEnumerable<EstadoResultadosDetalle> filteredList = Detalle
                      .GroupBy(Rubro => Rubro.IDRubro)
                      .Select(group => group.First());


                    string FormulaTG = string.Empty;
                    string FormulaTGA = string.Empty;
                    if (filteredList.Count() > 0)
                    {
                        FormulaTG += "=SUM(";
                        FormulaTGA += "=SUM(";
                    }
                    int NumCat = 1;
                    foreach (EstadoResultadosDetalle Item in filteredList)
                    {
                        FilaInicio++;
                        IEnumerable<EstadoResultadosDetalle> ListaGrupo = Detalle.Where(x => x.IDRubro == Item.IDRubro);
                        if (ListaGrupo.Count() > 0)
                        {
                            FilaInicio++;
                            Range formatRange = (Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 1];
                            formatRange.Font.Bold = true;
                            wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 1] = Item.TipoGasto;
                        }
                        foreach (EstadoResultadosDetalle Det in ListaGrupo)
                        {
                            FilaInicio++;
                            wsEstadoResultados.Cells[FilaInicio, ColumnaDatos] = Contador;
                            //Nombre de Categoría
                            wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 1] = Det.Categoria;
                            //Formato de celda Monto mensual
                            Range formatRange;
                            formatRange = (Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 2];
                            formatRange.NumberFormat = "$#,##0;[Red]$#,##0";
                            //Valor de celda Monto mensual
                            wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 2] = Det.MontoMensual;
                            //Formato de celda Monto anual              
                            formatRange = (Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 3];
                            formatRange.NumberFormat = "$#,##0;[Red]$#,##0";
                            //Valor de celda Monto anual
                            wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 3] = Det.MontoAnual;
                            //Valor de celda Porcentaje
                            //decimal Porcentaje = 0.1m;
                            //wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 4] = Porcentaje;

                            Contador++;

                        }
                        //Al terminar el recorrido por categoría, imprimir el total
                        FilaInicio++;
                        //wsEstadoResultados.Cells[FilaInicio, ColumnaDatos] = Contador;
                        Contador++;

                        //Porcentajes

                        wsEstadoResultados.get_Range("E" + (FilaInicio - ListaGrupo.Count()), "E" + FilaInicio).FormulaR1C1 = "=RC3/R9C3";
                        wsEstadoResultados.get_Range("E" + (FilaInicio - ListaGrupo.Count()), "E" + FilaInicio).NumberFormat = "0.00%";

                        //((Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 1]).Font.Bold = true;
                        wsEstadoResultados.get_Range("A" + FilaInicio, "E" + FilaInicio).Font.Bold = true;
                        wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 1] = "TOTAL " + Item.TipoGasto;
                        //Total Gastos Mensuales
                        string SumGM = string.Format("=SUM(C{0}:C{1})", (FilaInicio - ListaGrupo.Count()), (FilaInicio - 1));
                        ((Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 2]).NumberFormat = "$#,##0;[Red]$#,##0";
                        ((Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 2]).Formula = SumGM;
                        //Total Gastos Anuales
                        string SumGA = string.Format("=SUM(D{0}:D{1})", (FilaInicio - ListaGrupo.Count()), (FilaInicio - 1));
                        ((Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 3]).NumberFormat = "$#,##0;[Red]$#,##0";
                        ((Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 3]).Formula = SumGA;
                        if (NumCat > 1)
                        {
                            FormulaTG += ",";
                            FormulaTGA += ",";
                        }
                        FormulaTG += string.Format("C{0}", FilaInicio);
                        FormulaTGA += string.Format("D{0}", FilaInicio);
                        NumCat++;
                    }
                    FormulaTG += ")";
                    FormulaTGA += ")";
                    // Al terminar el recorrido de las categorias, imprimir el total de gastos
                    FilaInicio++;
                    wsEstadoResultados.get_Range("A" + FilaInicio, "E" + FilaInicio).Font.Bold = true;
                    //wsEstadoResultados.Cells[FilaInicio, ColumnaDatos] = Contador;
                    wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 1] = "TOTAL GASTOS";
                    ((Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 2]).NumberFormat = "$#,##0;[Red]$#,##0";
                    ((Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 2]).Formula = FormulaTG;
                    ((Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 3]).NumberFormat = "$#,##0;[Red]$#,##0";
                    ((Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 3]).Formula = FormulaTGA;
                    ((Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 4]).FormulaR1C1 = "=RC3/R9C3";
                    ((Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 4]).NumberFormat = "0.00%";

                    string FormulaUtilidad = string.Format("=(R9C - R{0}C)", FilaInicio);
                    FilaInicio += 2;

                    wsEstadoResultados.get_Range("C" + FilaInicio, "E" + FilaInicio).HorizontalAlignment = XlHAlign.xlHAlignRight;
                    Range RangoUtilidad = wsEstadoResultados.get_Range("C" + FilaInicio, "D" + FilaInicio);
                    wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 1] = "UTILIDAD DE OPERACIÓN";
                    wsEstadoResultados.get_Range("A" + FilaInicio, "E" + FilaInicio).Font.Bold = true;
                    RangoUtilidad.NumberFormat = "$#,##0;[Red]$#,##0";
                    RangoUtilidad.FormulaR1C1 = FormulaUtilidad;
                    ((Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 4]).FormulaR1C1 = "=RC3/R9C3";
                    ((Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 4]).NumberFormat = "0.00%";

                    //Comisiones
                    FilaInicio += 1;
                    wsEstadoResultados.get_Range("C" + FilaInicio, "E" + FilaInicio).HorizontalAlignment = XlHAlign.xlHAlignRight;
                    Range RangoImpuestos = wsEstadoResultados.get_Range("C" + FilaInicio, "D" + FilaInicio);
                    wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 1] = "IMPUESTOS Y DERECHOS";
                    wsEstadoResultados.get_Range("A" + FilaInicio, "E" + FilaInicio).Font.Bold = true;
                    RangoImpuestos.NumberFormat = "$#,##0;[Red]$#,##0";
                    wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 2] = ImpuestoMensual;
                    wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 3] = ImpuestoAnual;
                    //RangoImpuestos.FormulaR1C1 = FormulaUtilidad;
                    ((Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 4]).FormulaR1C1 = "=RC3/R9C3";
                    ((Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 4]).NumberFormat = "0.00%";

                    string FormulaUtilidadNeta = string.Format("=(R{0}C - R{1}C)", FilaInicio - 1, FilaInicio);
                    FilaInicio += 2;                    
                    //Utilidad Neta
                    wsEstadoResultados.get_Range("C" + FilaInicio, "E" + FilaInicio).HorizontalAlignment = XlHAlign.xlHAlignRight;
                    Range RangoUtilidadNeta = wsEstadoResultados.get_Range("B" + FilaInicio, "E" + FilaInicio);
                    wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 1] = "UTILIDAD NETA";
                    RangoUtilidadNeta.Font.Bold = true;
                    wsEstadoResultados.get_Range("C" + FilaInicio, "D" + FilaInicio).NumberFormat = "$#,##0;[Red]$#,##0";
                    wsEstadoResultados.get_Range("C" + FilaInicio, "D" + FilaInicio).FormulaR1C1 = FormulaUtilidadNeta;
                    ((Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 4]).FormulaR1C1 = "=RC3/R9C3";
                    ((Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 4]).NumberFormat = "0.00%";
                    RangoUtilidadNeta.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlDouble;
                    RangoUtilidadNeta.Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = XlColorIndex.xlColorIndexAutomatic;
                    RangoUtilidadNeta.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThick;
                    RangoUtilidadNeta.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    RangoUtilidadNeta.Borders[XlBordersIndex.xlEdgeTop].ColorIndex = XlColorIndex.xlColorIndexNone;
                    RangoUtilidadNeta.Borders[XlBordersIndex.xlEdgeTop].Weight = XlBorderWeight.xlThin;

                    FilaInicio += 3;
                    wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 1] = "ELABORÓ";
                    wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 3] = "REVISÓ";

                    Range Elabora = wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 1];
                    Range Revisa = wsEstadoResultados.get_Range("D" + FilaInicio, "E" + FilaInicio);

                    Elabora.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    Elabora.Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = XlColorIndex.xlColorIndexAutomatic;
                    Elabora.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;

                    Revisa.Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    Revisa.Borders[XlBordersIndex.xlEdgeBottom].ColorIndex = XlColorIndex.xlColorIndexAutomatic;
                    Revisa.Borders[XlBordersIndex.xlEdgeBottom].Weight = XlBorderWeight.xlThin;
                    // Pie de página (Firmas)

                }
                catch (Exception ex)
                {
                    LogError.AddExcFileTxt(ex, "Generar Reporte Excel");
                    return false;
                }
                finally
                {
                    xlsBook.SaveAs(@"C:\CUBOX\Prueba.xlsx");
                    xlsBook.Close();
                    xlsApp.Quit();
                }
                return true;


                //int IDRubro = 0;
                //int ContadorRegistros = 0;
                //int aux = 0;
                //foreach (EstadoResultadosDetalle Item in Detalle)
                //{
                //    if(IDRubro != Item.IDRubro)
                //    {
                //        if(IDRubro != 0)
                //        {
                //            //Si no es el principal, calcular el total
                //            wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 1] = "Total " + Item.TipoGasto;
                //            string Formula = string.Format("=SUMA(B{0}: B{1})", aux - 1 - )
                //            wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 2].Formula ="=SUMA(B{0}, )"; //SUM
                //            wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 3] = 0; //SUM
                //            wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 4] = 0; //FORMULA
                //            FilaInicio++;
                //        }
                //        FilaInicio++;
                //        wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 1] = Item.TipoGasto;
                //        IDRubro = Item.IDRubro;
                //        ContadorRegistros = 0;
                //    }
                //    //Contador 1, 2, 3, ..., n
                //    wsEstadoResultados.Cells[FilaInicio, ColumnaDatos] = Contador;
                //    //Nombre de Categoría
                //    wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 1] = Item.Categoria;
                //    //Formato de celda Monto mensual
                //    Range formatRange;
                //    formatRange = (Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 2];
                //    formatRange.NumberFormat = "$#,##0;[Red]$#,##0";
                //    //Valor de celda Monto mensual
                //    wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 2] = Item.MontoMensual;
                //    //Formato de celda Monto anual              
                //    formatRange = (Range)wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 3];
                //    formatRange.NumberFormat = "$#,##0;[Red]$#,##0";
                //    //Valor de celda Monto anual
                //    wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 3] = Item.MontoAnual;
                //    //Valor de celda Porcentaje
                //    decimal Porcentaje = 0.1m;
                //    wsEstadoResultados.Cells[FilaInicio, ColumnaDatos + 4] = Porcentaje;
                //    FilaInicio += 1;
                //    aux++;
                //    Contador++;
                //    ContadorRegistros++;
                //    //if (IDRubro == 0 || IDRubro != Item.IDRubro)
                //    //    IDRubro = Item.IDRubro;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EstablecerFormatoXColumna(Worksheet wsEstadoResultados)
        {
            try
            {
                // *********** Inicializar ancho de columnas **************
                wsEstadoResultados.Columns["A"].ColumnWidth = 8.43;
                wsEstadoResultados.Columns["B"].ColumnWidth = 27.86;
                wsEstadoResultados.Columns["C"].ColumnWidth = 13.71;
                wsEstadoResultados.Columns["D"].ColumnWidth = 13.71;
                wsEstadoResultados.Columns["E"].ColumnWidth = 12.14;


                Range A = (Range)wsEstadoResultados.Columns["A"];
                //Fuente
                A.Font.Name = "Tahoma";
                A.Font.Size = 10;
                A.Font.Strikethrough = false;
                A.Font.Superscript = false;
                A.Font.Subscript = false;
                A.Font.OutlineFont = false;
                A.Font.Shadow = false;
                A.Font.Underline = XlUnderlineStyle.xlUnderlineStyleNone;
                A.Font.ThemeColor = XlThemeColor.xlThemeColorLight1;
                A.Font.TintAndShade = 0;
                A.Font.ThemeFont = XlThemeFont.xlThemeFontNone;
                //Alineación
                A.HorizontalAlignment = HorizontalAlignment.Center;
                //Titulos.VerticalAlignment = Alig
                A.WrapText = false;
                A.Orientation = 0;
                A.AddIndent = false;
                A.IndentLevel = 0;
                A.ShrinkToFit = false;
                A.MergeCells = false;
                //
                Range B = (Range)wsEstadoResultados.Columns["B"];
                //Fuente
                B.Font.Name = "Tahoma";
                B.Font.Size = 10;
                B.Font.Strikethrough = false;
                B.Font.Superscript = false;
                B.Font.Subscript = false;
                B.Font.OutlineFont = false;
                B.Font.Shadow = false;
                B.Font.Underline = XlUnderlineStyle.xlUnderlineStyleNone;
                B.Font.ThemeColor = XlThemeColor.xlThemeColorLight1;
                B.Font.TintAndShade = 0;
                B.Font.ThemeFont = XlThemeFont.xlThemeFontNone;
                //Alineación
                B.HorizontalAlignment = HorizontalAlignment.Center;
                //Titulos.VerticalAlignment = Alig
                B.WrapText = false;
                B.Orientation = 0;
                B.AddIndent = false;
                B.IndentLevel = 0;
                B.ShrinkToFit = false;
                B.MergeCells = false;
                //
                Range C = (Range)wsEstadoResultados.Columns["C"];
                //Fuente
                C.Font.Name = "Tahoma";
                C.Font.Size = 10;
                C.Font.Strikethrough = false;
                C.Font.Superscript = false;
                C.Font.Subscript = false;
                C.Font.OutlineFont = false;
                C.Font.Shadow = false;
                C.Font.Underline = XlUnderlineStyle.xlUnderlineStyleNone;
                C.Font.ThemeColor = XlThemeColor.xlThemeColorLight1;
                C.Font.TintAndShade = 0;
                C.Font.ThemeFont = XlThemeFont.xlThemeFontNone;
                //Alineación
                C.HorizontalAlignment = HorizontalAlignment.Center;
                //Titulos.VerticalAlignment = Alig
                C.WrapText = false;
                C.Orientation = 0;
                C.AddIndent = false;
                C.IndentLevel = 0;
                C.ShrinkToFit = false;
                C.MergeCells = false;
                //
                Range D = (Range)wsEstadoResultados.Columns["D"];
                //Fuente
                D.Font.Name = "Tahoma";
                D.Font.Size = 10;
                D.Font.Strikethrough = false;
                D.Font.Superscript = false;
                D.Font.Subscript = false;
                D.Font.OutlineFont = false;
                D.Font.Shadow = false;
                D.Font.Underline = XlUnderlineStyle.xlUnderlineStyleNone;
                D.Font.ThemeColor = XlThemeColor.xlThemeColorLight1;
                D.Font.TintAndShade = 0;
                D.Font.ThemeFont = XlThemeFont.xlThemeFontNone;
                //Alineación
                D.HorizontalAlignment = HorizontalAlignment.Center;
                //Titulos.VerticalAlignment = Alig
                D.WrapText = false;
                D.Orientation = 0;
                D.AddIndent = false;
                D.IndentLevel = 0;
                D.ShrinkToFit = false;
                D.MergeCells = false;
                //
                Range E = (Range)wsEstadoResultados.Columns["E"];
                //Fuente
                E.Font.Name = "Tahoma";
                E.Font.Size = 10;
                E.Font.Strikethrough = false;
                E.Font.Superscript = false;
                E.Font.Subscript = false;
                E.Font.OutlineFont = false;
                E.Font.Shadow = false;
                E.Font.Underline = XlUnderlineStyle.xlUnderlineStyleNone;
                E.Font.ThemeColor = XlThemeColor.xlThemeColorLight1;
                E.Font.TintAndShade = 0;
                E.Font.ThemeFont = XlThemeFont.xlThemeFontNone;
                //Alineación
                E.HorizontalAlignment = HorizontalAlignment.Center;
                //Titulos.VerticalAlignment = Alig
                E.WrapText = false;
                E.Orientation = 0;
                E.AddIndent = false;
                E.IndentLevel = 0;
                E.ShrinkToFit = false;
                E.MergeCells = false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
