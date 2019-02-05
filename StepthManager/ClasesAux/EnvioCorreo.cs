using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreativaSL.Dll.StephManager.Global;
using CreativaSL.Dll.StephManager.Negocio;
using System.Data;
using System.Net;
using System.Globalization;

namespace StephManager.ClasesAux
{
    public class EnvioCorreo
    {
        //static string _dominio = Comun.Dominio;
        public static bool EnviarCorreo(string De, string Contraseña, string Para, string Asunto, string Mensaje, bool banArchivo, string Archivo, bool Html, string Host, int Port, bool Ssl)
        {
            try
            {

                //GMAIL
                //Habilitar las siguientes opciones en correo de gmail
                //https://www.google.com/settings/security/lesssecureapps
                //https://accounts.google.com/DisplayUnlockCaptcha
                //HOTMAIL
                //Enviara las primeras veces despues nos llegara un correo para reconocer el inicio de sesion 
                //ya que depende del servidor donde esta alojado y se tiene que reconocer el inicio de sesion   
                //Para = "lackke.141727@gmail.com";
                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                mailMessage.From = new System.Net.Mail.MailAddress(De);
                mailMessage.To.Add(Para);
                mailMessage.Subject = Asunto;
                if (banArchivo)
                    mailMessage.Attachments.Add(new System.Net.Mail.Attachment(Archivo));
                mailMessage.Body = Mensaje;
                mailMessage.IsBodyHtml = Html;
                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient(Host);
                smtpClient.Port = Port;
                smtpClient.EnableSsl = Ssl;
                smtpClient.Credentials = new NetworkCredential(De, Contraseña);
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Comun_Negocio.AddExcFileTxt(ex, "EnvioCorreo.EnviarCorreo");
                return false;
            }
        }
       
        public static string Cadena(bool Lunes, bool Martes, bool Miercoles, bool Jueves, bool Viernes, bool Sabado, bool Domingo)
        {
            bool Band = false;
            string Cadena = "Válido los días:";
            if (Lunes)
            {
                Cadena += " Lunes";
                Band = true;
            }
            if (Martes)
            {
                if (Band == true)
                {
                    Cadena += ", Martes";
                }
                else
                {
                    Cadena += " Martes";
                    Band = true;
                }
            }
            if (Miercoles)
            {
                if (Band == true)
                {
                    Cadena += ", Miércoles";
                }
                else
                {
                    Cadena += " Miércoles";
                    Band = true;
                }
            }
            if (Jueves)
            {
                if (Band == true)
                {
                    Cadena += ", Jueves";
                }
                else
                {
                    Cadena += " Jueves";
                    Band = true;
                }
            }
            if (Viernes)
            {
                if (Band == true)
                {
                    Cadena += ", Viernes";
                }
                else
                {
                    Cadena += " Viernes";
                    Band = true;
                }
            }
            if (Sabado)
            {
                if (Band == true)
                {
                    Cadena += ", Sábado";
                }
                else
                {
                    Cadena += " Sábado";
                    Band = true;
                }
            }
            if (Domingo)
            {
                if (Band == true)
                {
                    Cadena += ", Domingo";
                }
                else
                {
                    Cadena += " Domingo";
                    Band = true;
                }
            }
            Cadena += ".";
            return Cadena;
        }

        public static string GenerarHtmlPorcentajeDeDescuento(Vales Datos)
        {
            try
            {
                string dominio = "http://www.steph.com.mx/"; //"http://www.creativasoftlineapps.com/ofelianarvaezmanual/";
                string html = "";
                List<Producto> ListaProducto = new List<Producto>();
                ListaProducto = Datos.ListaProductos;
                string NombreVale = Datos.Nombre;
                string FolioVale = Datos.Folio;
                int CantidadLimite = Datos.CantLimite;
                string PorcentajeVale = string.Format("{0:p0}", Datos.Porcentaje / 100);
                bool RequierePeriodo = Datos.RequierePeriodo;
                string FechaInicio = Datos.FechaInicio.ToShortDateString();
                string FechaFin = Datos.FechaFin.ToShortDateString();
                string DiasSemana = Cadena(Datos.Lunes, Datos.Martes, Datos.Miercoles, Datos.Jueves, Datos.Viernes, Datos.Sabado, Datos.Domingo);
                string Imagen = Comun.UrlLogo;
               
                html = @"<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">
<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,700,600' rel='stylesheet' type='text/css'>
<head>
<!--[if gte mso 12]>
> <style type=""text/css"">
> [a.btn {
	padding:15px 22px !important;
	display:inline-block !important;
}]
> </style>
> <![endif]-->
<title>kreative</title>
<style type=""text/css"">
div, p, a, li, td {
	-webkit-text-size-adjust:none;
}
.ReadMsgBody {
	width: 100%;
	background-color: #d1d1d1;
}
.ExternalClass {
	width: 100%;
	background-color: #d1d1d1;
	line-height:100%;
}
body {
	width: 100%;
	height: 100%;
	background-color: #d1d1d1;
	margin:0;
	padding:0;
	-webkit-font-smoothing: antialiased;
	-webkit-text-size-adjust:100%;
}
html {
	width: 100%;
}
img {
	-ms-interpolation-mode:bicubic;
}
table[class=full] {
	padding:0 !important;
	border:none !important;
}
table td img[class=imgresponsive] {
	width:100% !important;
	height:auto !important;
	display:block !important;
}
@media only screen and (max-width: 800px) {
body {
 width:auto!important;
}
table[class=full] {
 width:100%!important;
}
table[class=devicewidth] {
 width:100% !important;
 padding-left:20px !important;
 padding-right: 20px!important;
}
table td img.responsiveimg {
 width:100% !important;
 height:auto !important;
 display:block !important;
}
}
@media only screen and (max-width: 640px) {
table[class=devicewidth] {
 width:100% !important;
}
table[class=inner] {
 width:100%!important;
 text-align: center!important;
 clear: both;
}
table td a[class=top-button] {
 width:160px !important;
  font-size:14px !important;
 line-height:37px !important;
}
table td[class=readmore-button] {
 text-align:center !important;
}
table td[class=readmore-button] a {
 float:none !important;
 display:inline-block !important;
}
.hide {
 display:none !important;
}
table td[class=smallfont] {
 border:none !important;
 font-size:26px !important;
}
table td[class=sidespace] {
 width:10px !important;
}
}
 @media only screen and (max-width: 520px) {
}
@media only screen and (max-width: 480px) {

 table {
 border-collapse: collapse;
}
table td[class=template-img] img {
 width:100% !important;
 display:block !important;
}
}
@media only screen and (max-width: 320px) {
}
</style>
</head>
<body>
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"">
  <tr>
    <td height=""54"">&nbsp;</td>
  </tr>
</table>
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""full"">
  <tr>
    <td align=""center""><table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""devicewidth"">
        <tr>
          <td><table width=""100%"" bgcolor=""#ffffff"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"" style=""border-radius:5px 5px 0 0; background-color:#ffffff;"">
              <tr>
                <td height=""29"">&nbsp;</td>
              </tr>
              <tr>
                <td><table border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"" class=""inner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                    <tr>
                      <td width=""23"" class=""hide"">&nbsp;</td>
                      <td height=""75"" class=""inner"" valign=""middle""><a href=""#""><img class=""logo"" src=""" + dominio + @"upload/light-logo-2.png"" width=""180"" height=""61"" alt=""Logo""></a></td>
                    </tr>
                  </table>
                  <table width=""150"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""right"" class=""inner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                    <tr>
                      <td height=""15"">&nbsp;</td>
                    </tr>
                  </table></td>
              </tr>
              <tr>
                <td style=""border-bottom:1px solid #dbdbdb;"">&nbsp;</td>
              </tr>
            </table></td>
        </tr>
      </table></td>
  </tr>
</table>
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""full"">
  <tr>
    <td align=""center""><table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""devicewidth"">
        <tr>
          <td><table width=""100%"" bgcolor=""#ffffff"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"" style=""background-color:#ffffff;"">
              <tr>
                <td height=""23"">&nbsp;</td>
              </tr>
              <tr>
                <td>
                  <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                    <tr>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                      <td><table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""inner"" id=""banner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                          <tr>
                            <td style=""font:bold 27px Arial, Helvetica, sans-serif;"" class=""smallfont"">" + NombreVale + @"</td>
                          </tr>
                          <tr>
                            <td height=""20"">&nbsp;</td>
                          </tr>
                        </table>
                        <table width=""22%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""right"" class=""inner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                            <td height=""20"">&nbsp;</td>
                            <td height=""20"">&nbsp;</td>
                            <td height=""20"">&nbsp;</td>
                          </tr>
                        </table></td>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                    </tr>
                  </table>
                  <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                    <tr>
                      <td width=""3.33%"" class=""sidespace"">&nbsp;</td>
                      <td width=""93.33%""><img class=""imgresponsive"" src=""" + dominio + @"upload/FZK_7266%2002.jpg"" width=""554"" height=""atuo"" alt=""Banner"" /></td>
                      <td width=""3.33%"" class=""sidespace"">&nbsp;</td>
                    </tr>
                    <tr>
                      <td height=""20"">&nbsp;</td>
                      <td height=""20"">&nbsp;</td>
                      <td height=""20"">&nbsp;</td>
                    </tr>
                  </table>
                  <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                    <tr>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                      <td>
                        <table width=""48%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"" class=""inner"">
                          <tr>
                            <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont"">Folio: " + FolioVale + @"</td>
                          </tr>
                        </table>";
                if (CantidadLimite == 0)
                {
                    html = html + @"
                           <table width=""48%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"" class=""inner"">
                          <tr>
                            <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont"">Válido hasta agotar existencia</td>
                          </tr>
                        </table>";
                }
                else
                {
                    html = html + @"
                           <table width=""48%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"" class=""inner"">
                          <tr>
                            <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont"">Válido a los primeros " + CantidadLimite + @" clientes</td>
                          </tr>
                        </table>";
                }
                html = html + @"
                    </tr>
                    <tr>
                      <td height=""16"">&nbsp;</td>
                      <td height=""16"">&nbsp;</td>
                      <td height=""16"">&nbsp;</td>
                    </tr>
                  </table>
                     <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                    <tr>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                      <td>
                        <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"" class=""inner"">
                          <tr>
                            <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont"">Porcentaje: " + PorcentajeVale + @"</td>
                          </tr>
                        </table>
                    </tr>
                    <tr>
                      <td height=""16"">&nbsp;</td>
                      <td height=""16"">&nbsp;</td>
                      <td height=""16"">&nbsp;</td>
                    </tr>
                  </table>";
                if (RequierePeriodo == true)
                {
                    html = html + @"
                            <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                            <tr>
                              <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont"">Válido del: " + FechaInicio + @" al " + FechaFin + @" </td>
                            </tr>
                            <tr>
                              <td height=""16"">&nbsp;</td>
                              <td height=""16"">&nbsp;</td>
                              <td height=""16"">&nbsp;</td>
                            </tr>
                          </table>
                            ";
                }
                else
                {
                            html = html + @"
                             <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                            <tr>
                          
                              <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont"">" + DiasSemana + @"</td>
                           
                            </tr>
                            <tr>
                              <td height=""16"">&nbsp;</td>
                              <td height=""16"">&nbsp;</td>
                              <td height=""16"">&nbsp;</td>
                            </tr>
                            </table>";
                }
                        html = html + @"          
                </td>
              </tr>
              <tr>
                <td style=""border-bottom:20px solid #dbdbdb;"">&nbsp;</td>
              </tr>
            </table></td>
        </tr>
      </table></td>
  </tr>
</table>
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""full"">
  <tr>
    <td align=""center""><table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""devicewidth"">
        <tr>
          <td><table width=""100%"" bgcolor=""#f1f1f1"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"">
              <tr>
                <td height=""35"">&nbsp;</td>
              </tr>
              <tr>
                <td><table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""full"">
                    <tr>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                      <td>
                        <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                          <tr>
                            <td height=""33"">&nbsp;</td>
                          </tr>
                          <tr>
                            <td bgcolor=""#ffffff"">
                              <table align=""left"" width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""inner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                                <tr>
                                  <td height=""22"">&nbsp;</td>
                                </tr>
                                <tr>
                                  <td>
                                    ";
                        if (ListaProducto.Count == 1)
                        {
                            foreach (var item in ListaProducto)
                            {
                                html = html + @"
                             <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""inner"">
                                      <tr>
                                        <td width=""39"" class=""sidespace"">&nbsp;</td>
                                        <td><table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                            <tr>
                                              <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"">" + item.NombreProducto + @"</td>
                                            </tr>
                                            <tr>
                                              <td height=""5""></td>
                                            </tr>
                                            <tr>
                                              <td style=""font:14px/19px Arial, Helvetica, sans-serif; color:#333332;"">Clave: " + item.Clave + @"</td>
                                            </tr>
                                            <tr>
                                              <td height=""20"">&nbsp;</td>
                                            </tr>
                                            <tr>
                                            </tr>
                                          </table></td>
                                        <td width=""25"" class=""sidespace"">&nbsp;</td>
                                      </tr>
                                    </table>
                            ";
                            }
                        }
                        else
                        {
                            foreach (var item in ListaProducto)
                            {
                                html = html + @"
     <!--Inicia la Tabla de los Productos-->
                              <table align=""left"" width=""50%"" bgcolor=""#ffffff"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""inner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt; float: left;"">
                                <tr>
                                  <td height=""22"">&nbsp;</td>
                                </tr>
                                <tr>
                                  <td>
                                    <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""inner"">
                                      <tr>
                                        <td width=""20"" class=""sidespace"">&nbsp;</td>
                                        <td><table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                            <tr>
                                              <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"">" + item.NombreProducto + @"</td>
                                            </tr>
                                            <tr>
                                              <td height=""5""></td>
                                            </tr>
                                            <tr>
                                              <td style=""font:14px/19px Arial, Helvetica, sans-serif; color:#333332;"">Clave: " + item.Clave + @"</td>
                                            </tr>
                                            <tr>
                                              <td height=""22"">&nbsp;</td>
                                            </tr>
                                          </table></td>
                                        <td width=""20"" class=""sidespace"">&nbsp;</td>
                                      </tr>
                                    </table>
                                  </td>
                                </tr>
                                <tr>
                                  <td height=""22"">&nbsp;</td>
                                </tr>
                                <tr>
                                  <td height=""16"" bgcolor=""#f1f1f1""></td>
                                </tr>
                              </table>
                              <!--Termina la Tabla de los Productos-->";
                            }
                        }
                        html = html + @" 
                             
                                   </td>
                                </tr>
                                <tr>
                                  <td height=""22"">&nbsp;</td>
                                </tr>
                              </table>
                            </td>
                          </tr>
                          <tr>
                            <td height=""32""></td>
                          </tr>
                        </table></td>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                    </tr>
                  </table></td>
              </tr>
            </table></td>
        </tr>
      </table></td>
  </tr>
</table>
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"">
  <tr>
    <td align=""center""><table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""devicewidth"">
        <tr>
          <td><table width=""100%"" bgcolor=""#ffffff"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"" style=""border-radius:0 0 7px 7px;"">
              <tr>
                <td height=""18"">&nbsp;</td>
              </tr>
              <tr>
                <td>
                  <table class=""inner"" align=""left"" width=""230"" border=""0"" cellspacing=""0"" cellpadding=""0"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt; text-align:center;"">
                    <tr>
                      <td width=""21"">&nbsp;</td>
                      <td>
                        <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                          <tr>
                            <td align=""center"" style=""font:11px Helvetica,  Arial, sans-serif; color:#000000;"">&copy; " + DateTime.Now.Year + @", All rights reserved </td>
                          </tr>
                          <tr>
                            <td height=""18"">&nbsp;</td>
                          </tr>
                        </table>
                      </td>
                      <td width=""21"">&nbsp;</td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table></td>
        </tr>
        <tr>
          <td height=""20"">&nbsp;</td>
        </tr>
      </table></td>
  </tr>
</table>
</body>
</html>";
                return html;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GenerarHtmlMontoEfectivo(Vales Datos)
        {
            try
            {
                string dominio = "http://www.steph.com.mx/"; //"http://www.creativasoftlineapps.com/ofelianarvaezmanual/";
                string html = "";
                List<Producto> ListaProducto = new List<Producto>();
                ListaProducto = Datos.ListaProductos;
                string NombreVale = Datos.Nombre;
                string FolioVale = Datos.Folio;
                string MontoVale = string.Format("{0:c}", Datos.Monto);
                int CantidadLimite = Datos.CantLimite;
                bool RequierePeriodo = Datos.RequierePeriodo;
                string FechaInicio = Datos.FechaInicio.ToShortDateString();
                string FechaFin = Datos.FechaFin.ToShortDateString();
                string DiasSemana = Cadena(Datos.Lunes, Datos.Martes, Datos.Miercoles, Datos.Jueves, Datos.Viernes, Datos.Sabado, Datos.Domingo);
                string Imagen = Comun.UrlLogo;

               html = @"<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">
<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,700,600' rel='stylesheet' type='text/css'>
<head>
<!--[if gte mso 12]>
> <style type=""text/css"">
> [a.btn {
	padding:15px 22px !important;
	display:inline-block !important;
}]
> </style>
> <![endif]-->
<title>kreative</title>
<style type=""text/css"">
div, p, a, li, td {
	-webkit-text-size-adjust:none;
}
.ReadMsgBody {
	width: 100%;
	background-color: #d1d1d1;
}
.ExternalClass {
	width: 100%;
	background-color: #d1d1d1;
	line-height:100%;
}
body {
	width: 100%;
	height: 100%;
	background-color: #d1d1d1;
	margin:0;
	padding:0;
	-webkit-font-smoothing: antialiased;
	-webkit-text-size-adjust:100%;
}
html {
	width: 100%;
}
img {
	-ms-interpolation-mode:bicubic;
}
table[class=full] {
	padding:0 !important;
	border:none !important;
}
table td img[class=imgresponsive] {
	width:100% !important;
	height:auto !important;
	display:block !important;
}
@media only screen and (max-width: 800px) {
body {
 width:auto!important;
}
table[class=full] {
 width:100%!important;
}
table[class=devicewidth] {
 width:100% !important;
 padding-left:20px !important;
 padding-right: 20px!important;
}
table td img.responsiveimg {
 width:100% !important;
 height:auto !important;
 display:block !important;
}
}
@media only screen and (max-width: 640px) {
table[class=devicewidth] {
 width:100% !important;
}
table[class=inner] {
 width:100%!important;
 text-align: center!important;
 clear: both;
}
table td a[class=top-button] {
 width:160px !important;
  font-size:14px !important;
 line-height:37px !important;
}
table td[class=readmore-button] {
 text-align:center !important;
}
table td[class=readmore-button] a {
 float:none !important;
 display:inline-block !important;
}
.hide {
 display:none !important;
}
table td[class=smallfont] {
 border:none !important;
 font-size:26px !important;
}
table td[class=sidespace] {
 width:10px !important;
}
}
 @media only screen and (max-width: 520px) {
}
@media only screen and (max-width: 480px) {

 table {
 border-collapse: collapse;
}
table td[class=template-img] img {
 width:100% !important;
 display:block !important;
}
}
@media only screen and (max-width: 320px) {
}
</style>
</head>
<body>
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"">
  <tr>
    <td height=""54"">&nbsp;</td>
  </tr>
</table>
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""full"">
  <tr>
    <td align=""center""><table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""devicewidth"">
        <tr>
          <td><table width=""100%"" bgcolor=""#ffffff"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"" style=""border-radius:5px 5px 0 0; background-color:#ffffff;"">
              <tr>
                <td height=""29"">&nbsp;</td>
              </tr>
              <tr>
                <td><table border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"" class=""inner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                    <tr>
                      <td width=""23"" class=""hide"">&nbsp;</td>
                      <td height=""75"" class=""inner"" valign=""middle""><a href=""#""><img class=""logo"" src=""" + dominio + @"upload/light-logo-2.png"" width=""180"" height=""61"" alt=""Logo""></a></td>
                    </tr>
                  </table>
                  <table width=""150"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""right"" class=""inner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                    <tr>
                      <td height=""15"">&nbsp;</td>
                    </tr>
                  </table></td>
              </tr>
              <tr>
                <td style=""border-bottom:1px solid #dbdbdb;"">&nbsp;</td>
              </tr>
            </table></td>
        </tr>
      </table></td>
  </tr>
</table>
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""full"">
  <tr>
    <td align=""center""><table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""devicewidth"">
        <tr>
          <td><table width=""100%"" bgcolor=""#ffffff"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"" style=""background-color:#ffffff;"">
              <tr>
                <td height=""23"">&nbsp;</td>
              </tr>
              <tr>
                <td>
                  <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                    <tr>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                      <td><table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""inner"" id=""banner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                          <tr>
                            <td style=""font:bold 27px Arial, Helvetica, sans-serif;"" class=""smallfont"">" + NombreVale + @"</td>
                          </tr>
                          <tr>
                            <td height=""20"">&nbsp;</td>
                          </tr>
                        </table>
                        <table width=""22%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""right"" class=""inner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                            <td height=""20"">&nbsp;</td>
                            <td height=""20"">&nbsp;</td>
                            <td height=""20"">&nbsp;</td>
                          </tr>
                        </table></td>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                    </tr>
                  </table>
                  <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                    <tr>
                      <td width=""3.33%"" class=""sidespace"">&nbsp;</td>
                      <td width=""93.33%""><img class=""imgresponsive"" src=""" + dominio + @"upload/FZK_7266%2002.jpg"" width=""554"" height=""atuo"" alt=""Banner"" /></td>
                      <td width=""3.33%"" class=""sidespace"">&nbsp;</td>
                    </tr>
                    <tr>
                      <td height=""20"">&nbsp;</td>
                      <td height=""20"">&nbsp;</td>
                      <td height=""20"">&nbsp;</td>
                    </tr>
                  </table>
                  <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                    <tr>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                      <td>
                        <table width=""48%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"" class=""inner"">
                          <tr>
                            <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont"">Folio: " + FolioVale + @"</td>
                          </tr>
                        </table>";
                       if (CantidadLimite == 0)
                       {
                           html = html + @"
                                   <table width=""48%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"" class=""inner"">
                                  <tr>
                                    <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont"">Válido hasta agotar existencia</td>
                                  </tr>
                                </table>";
                       }
                       else
                       {
                           html = html + @"
                                   <table width=""48%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"" class=""inner"">
                                  <tr>
                                    <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont"">Válido a los primeros " + CantidadLimite + @" clientes</td>
                                  </tr>
                                </table>";
                       }
                       html = html + @"
                    </tr>
                    <tr>
                      <td height=""16"">&nbsp;</td>
                      <td height=""16"">&nbsp;</td>
                      <td height=""16"">&nbsp;</td>
                    </tr>
                  </table>
                     <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                    <tr>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                      <td>
                        <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"" class=""inner"">
                          <tr>
                            <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont"">Monto: " + MontoVale + @"</td>
                          </tr>
                        </table>
                    </tr>
                    <tr>
                      <td height=""16"">&nbsp;</td>
                      <td height=""16"">&nbsp;</td>
                      <td height=""16"">&nbsp;</td>
                    </tr>
                  </table>";
                if (RequierePeriodo == true)
                {
                    html = html + @"
                            <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                            <tr>
                              <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont"">Válido del: " + FechaInicio + @" al " + FechaFin + @" </td>
                            </tr>
                            <tr>
                              <td height=""16"">&nbsp;</td>
                              <td height=""16"">&nbsp;</td>
                              <td height=""16"">&nbsp;</td>
                            </tr>
                          </table>
                            ";
                }
                else
                {                   
                    html = html + @"
                             <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                            <tr>
                            
                              <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont""> " + DiasSemana + @"</td>
                           
                            </tr>
                            <tr>
                              <td height=""16"">&nbsp;</td>
                              <td height=""16"">&nbsp;</td>
                              <td height=""16"">&nbsp;</td>
                            </tr>
                            </table>";
                }
                        html = html + @"          
                </td>
              </tr>
              <tr>
                <td style=""border-bottom:20px solid #dbdbdb;"">&nbsp;</td>
              </tr>
            </table></td>
        </tr>
      </table></td>
  </tr>
</table>
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""full"">
  <tr>
    <td align=""center""><table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""devicewidth"">
        <tr>
          <td><table width=""100%"" bgcolor=""#f1f1f1"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"">
              <tr>
                <td height=""35"">&nbsp;</td>
              </tr>
              <tr>
                <td><table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""full"">
                    <tr>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                      <td>
                        <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                          <tr>
                            <td height=""33"">&nbsp;</td>
                          </tr>
                          <tr>
                            <td bgcolor=""#ffffff"">
                              <table align=""left"" width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""inner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                                <tr>
                                  <td height=""22"">&nbsp;</td>
                                </tr>
                                <tr>
                                  <td>
                                    ";
                        if (ListaProducto.Count == 1)
                        {
                            foreach (var item in ListaProducto)
                            {
                                html = html + @"
                             <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""inner"">
                                      <tr>
                                        <td width=""39"" class=""sidespace"">&nbsp;</td>
                                        <td><table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                            <tr>
                                              <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"">" + item.NombreProducto + @"</td>
                                            </tr>
                                            <tr>
                                              <td height=""5""></td>
                                            </tr>
                                            <tr>
                                              <td style=""font:14px/19px Arial, Helvetica, sans-serif; color:#333332;"">Clave: " + item.Clave + @"</td>
                                            </tr>
                                            <tr>
                                              <td height=""20"">&nbsp;</td>
                                            </tr>
                                            <tr>
                                            </tr>
                                          </table></td>
                                        <td width=""25"" class=""sidespace"">&nbsp;</td>
                                      </tr>
                                    </table>
                            ";
                            }
                        }
                        else
                        {
                            foreach (var item in ListaProducto)
                            {
                                html = html + @"
     <!--Inicia la Tabla de los Productos-->
                              <table align=""left"" width=""50%"" bgcolor=""#ffffff"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""inner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt; float: left;"">
                                <tr>
                                  <td height=""22"">&nbsp;</td>
                                </tr>
                                <tr>
                                  <td>
                                    <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""inner"">
                                      <tr>
                                        <td width=""20"" class=""sidespace"">&nbsp;</td>
                                        <td><table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                            <tr>
                                              <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"">" + item.NombreProducto + @"</td>
                                            </tr>
                                            <tr>
                                              <td height=""5""></td>
                                            </tr>
                                            <tr>
                                              <td style=""font:14px/19px Arial, Helvetica, sans-serif; color:#333332;"">Clave: " + item.Clave + @"</td>
                                            </tr>
                                            <tr>
                                              <td height=""22"">&nbsp;</td>
                                            </tr>
                                          </table></td>
                                        <td width=""20"" class=""sidespace"">&nbsp;</td>
                                      </tr>
                                    </table>
                                  </td>
                                </tr>
                                <tr>
                                  <td height=""22"">&nbsp;</td>
                                </tr>
                                <tr>
                                  <td height=""16"" bgcolor=""#f1f1f1""></td>
                                </tr>
                              </table>
                              <!--Termina la Tabla de los Productos-->";
                            }
                        }
                        html = html + @" 
                             
                                   </td>
                                </tr>
                                <tr>
                                  <td height=""22"">&nbsp;</td>
                                </tr>
                              </table>
                            </td>
                          </tr>
                          <tr>
                            <td height=""32""></td>
                          </tr>
                        </table></td>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                    </tr>
                  </table></td>
              </tr>
            </table></td>
        </tr>
      </table></td>
  </tr>
</table>
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"">
  <tr>
    <td align=""center""><table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""devicewidth"">
        <tr>
          <td><table width=""100%"" bgcolor=""#ffffff"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"" style=""border-radius:0 0 7px 7px;"">
              <tr>
                <td height=""18"">&nbsp;</td>
              </tr>
              <tr>
                <td>
                  <table class=""inner"" align=""left"" width=""230"" border=""0"" cellspacing=""0"" cellpadding=""0"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt; text-align:center;"">
                    <tr>
                      <td width=""21"">&nbsp;</td>
                      <td>
                        <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                          <tr>
                            <td align=""center"" style=""font:11px Helvetica,  Arial, sans-serif; color:#000000;"">&copy; " + DateTime.Now.Year + @", All rights reserved </td>
                          </tr>
                          <tr>
                            <td height=""18"">&nbsp;</td>
                          </tr>
                        </table>
                      </td>
                      <td width=""21"">&nbsp;</td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table></td>
        </tr>
        <tr>
          <td height=""20"">&nbsp;</td>
        </tr>
      </table></td>
  </tr>
</table>
</body>
</html>";
                return html;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GenerarHtmlNxN(Vales Datos)
        {
            try
            {
                string dominio = "http://www.steph.com.mx/"; //"http://www.creativasoftlineapps.com/ofelianarvaezmanual/";
                string html = "";
                string NombreProducto = Datos.ProductoRequerido.NombreProducto;
                string ClaveProducto = Datos.ProductoRequerido.Clave;
                string FolioVale = Datos.Folio;
                string NombreVale = Datos.Nombre;
                string CantidadRequerida = Datos.CantidadRequeridaNxN.ToString();
                string CantidadGratis = Datos.CantidadGratisNxN.ToString();
                int CantidadLimite = Datos.CantLimite;
                bool RequierePerido = Datos.RequierePeriodo;
                string FechaInicio = Datos.FechaInicio.ToShortDateString();
                string FechaFin = Datos.FechaFin.ToShortDateString();
                string DiasSemana = Cadena(Datos.Lunes, Datos.Martes, Datos.Miercoles, Datos.Jueves, Datos.Viernes, Datos.Sabado, Datos.Domingo);
                html = @"<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">
<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,700,600' rel='stylesheet' type='text/css'>
<head>
<!--[if gte mso 12]>
> <style type=""text/css"">
> [a.btn {
	padding:15px 22px !important;
	display:inline-block !important;
}]
> </style>
> <![endif]-->
<title>kreative</title>
<style type=""text/css"">
div, p, a, li, td {
	-webkit-text-size-adjust:none;
}
.ReadMsgBody {
	width: 100%;
	background-color: #d1d1d1;
}
.ExternalClass {
	width: 100%;
	background-color: #d1d1d1;
	line-height:100%;
}
body {
	width: 100%;
	height: 100%;
	background-color: #d1d1d1;
	margin:0;
	padding:0;
	-webkit-font-smoothing: antialiased;
	-webkit-text-size-adjust:100%;
}
html {
	width: 100%;
}
img {
	-ms-interpolation-mode:bicubic;
}
table[class=full] {
	padding:0 !important;
	border:none !important;
}
table td img[class=imgresponsive] {
	width:100% !important;
	height:auto !important;
	display:block !important;
}
@media only screen and (max-width: 800px) {
body {
 width:auto!important;
}
table[class=full] {
 width:100%!important;
}
table[class=devicewidth] {
 width:100% !important;
 padding-left:20px !important;
 padding-right: 20px!important;
}
table td img.responsiveimg {
 width:100% !important;
 height:auto !important;
 display:block !important;
}
}
@media only screen and (max-width: 640px) {
table[class=devicewidth] {
 width:100% !important;
}
table[class=inner] {
 width:100%!important;
 text-align: center!important;
 clear: both;
}
table td a[class=top-button] {
 width:160px !important;
  font-size:14px !important;
 line-height:37px !important;
}
table td[class=readmore-button] {
 text-align:center !important;
}
table td[class=readmore-button] a {
 float:none !important;
 display:inline-block !important;
}
.hide {
 display:none !important;
}
table td[class=smallfont] {
 border:none !important;
 font-size:26px !important;
}
table td[class=sidespace] {
 width:10px !important;
}
}
 @media only screen and (max-width: 520px) {
}
@media only screen and (max-width: 480px) {

 table {
 border-collapse: collapse;
}
table td[class=template-img] img {
 width:100% !important;
 display:block !important;
}
}
@media only screen and (max-width: 320px) {
}
</style>
</head>
<body>
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"">
  <tr>
    <td height=""54"">&nbsp;</td>
  </tr>
</table>
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""full"">
  <tr>
    <td align=""center""><table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""devicewidth"">
        <tr>
          <td><table width=""100%"" bgcolor=""#ffffff"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"" style=""border-radius:5px 5px 0 0; background-color:#ffffff;"">
              <tr>
                <td height=""29"">&nbsp;</td>
              </tr>
              <tr>
                <td><table border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"" class=""inner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                    <tr>
                      <td width=""23"" class=""hide"">&nbsp;</td>
                      <td height=""75"" class=""inner"" valign=""middle""><a href=""#""><img class=""logo"" src=""" + dominio + @"upload/light-logo-2.png"" width=""180"" height=""61"" alt=""Logo""></a></td>
                    </tr>
                  </table>
                  <table width=""150"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""right"" class=""inner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                    <tr>
                      <td height=""15"">&nbsp;</td>
                    </tr>
                  </table></td>
              </tr>
              <tr>
                <td style=""border-bottom:1px solid #dbdbdb;"">&nbsp;</td>
              </tr>
            </table></td>
        </tr>
      </table></td>
  </tr>
</table>
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""full"">
  <tr>
    <td align=""center""><table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""devicewidth"">
        <tr>
          <td><table width=""100%"" bgcolor=""#ffffff"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"" style=""background-color:#ffffff;"">
              <tr>
                <td height=""23"">&nbsp;</td>
              </tr>
              <tr>
                <td>
                  <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                    <tr>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                      <td><table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""inner"" id=""banner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                          <tr>
                            <td style=""font:bold 27px Arial, Helvetica, sans-serif;"" class=""smallfont"">" + NombreVale + @"</td>
                          </tr>
                          <tr>
                            <td height=""20"">&nbsp;</td>
                          </tr>
                        </table>
                        <table width=""22%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""right"" class=""inner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                            <td height=""20"">&nbsp;</td>
                            <td height=""20"">&nbsp;</td>
                            <td height=""20"">&nbsp;</td>
                          </tr>
                        </table></td>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                    </tr>
                  </table>
                  <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                    <tr>
                      <td width=""3.33%"" class=""sidespace"">&nbsp;</td>
                      <td width=""93.33%""><img class=""imgresponsive"" src=""" + dominio + @"upload/FZK_7266%2002.jpg"" width=""554"" height=""atuo"" alt=""Banner"" /></td>
                      <td width=""3.33%"" class=""sidespace"">&nbsp;</td>
                    </tr>
                    <tr>
                      <td height=""20"">&nbsp;</td>
                      <td height=""20"">&nbsp;</td>
                      <td height=""20"">&nbsp;</td>
                    </tr>
                  </table>
                  <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                    <tr>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                      <td>
                        <table width=""48%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"" class=""inner"">
                          <tr>
                            <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont"">Folio: " + FolioVale + @"</td>
                          </tr>
                        </table>";
                        if (CantidadLimite == 0)
                        {
                            html = html + @"
                                           <table width=""48%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"" class=""inner"">
                                          <tr>
                                            <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont"">Válido hasta agotar existencia</td>
                                          </tr>
                                        </table>";
                        }
                        else
                        {
                            html = html + @"
                                           <table width=""48%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"" class=""inner"">
                                          <tr>
                                            <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont"">Válido a los primeros " + CantidadLimite + @" clientes</td>
                                          </tr>
                                        </table>";
                        }
                        html = html + @"
                    </tr>
                    <tr>
                      <td height=""16"">&nbsp;</td>
                      <td height=""16"">&nbsp;</td>
                      <td height=""16"">&nbsp;</td>
                    </tr>
                  </table>
                    ";
                if (RequierePerido == true)
                {
                    html = html + @"
                            <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                            <tr>
                              <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont"">Válido del: " + FechaInicio + @" al " + FechaFin + @" </td>
                            </tr>
                            <tr>
                              <td height=""16"">&nbsp;</td>
                              <td height=""16"">&nbsp;</td>
                              <td height=""16"">&nbsp;</td>
                            </tr>
                          </table>
                            ";
                }
                else
                {
                    html = html + @"
                             <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                            <tr>
                            
                              <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont""> " + DiasSemana + @"</td>
                           
                            </tr>
                            <tr>
                              <td height=""16"">&nbsp;</td>
                              <td height=""16"">&nbsp;</td>
                              <td height=""16"">&nbsp;</td>
                            </tr>
                            </table>";
                }
                html = html + @"          
                </td>
              </tr>
              <tr>
                <td style=""border-bottom:20px solid #dbdbdb;"">&nbsp;</td>
              </tr>
            </table></td>
        </tr>
      </table></td>
  </tr>
</table>
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""full"">
  <tr>
    <td align=""center""><table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""devicewidth"">
        <tr>
          <td><table width=""100%"" bgcolor=""#f1f1f1"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"">
              <tr>
                <td height=""35"">&nbsp;</td>
              </tr>
              <tr>
                <td><table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""full"">
                    <tr>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                      <td>
                        <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                          <tr>
                            <td height=""33"">&nbsp;</td>
                          </tr>
                          <tr>
                            <td bgcolor=""#ffffff"">
                              <table align=""left"" width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""inner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                                <tr>
                                  <td height=""22"">&nbsp;</td>
                                </tr>
                                <tr>
                                  <td><table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""inner"">
                                      <tr>
                                        <td width=""39"" class=""sidespace"">&nbsp;</td>
                                        <td><table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                            <tr>
                                              <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"">" + NombreProducto + @"</td>
                                            </tr>
                                            <tr>
                                              <td height=""5""></td>
                                            </tr>
                                            <tr>
                                              <td style=""font:14px/19px Arial, Helvetica, sans-serif; color:#333332;"">Clave: " + ClaveProducto + @"</td>
                                            </tr>
                                            <tr>
                                              <td height=""20"">&nbsp;</td>
                                          </tr>
                                            <tr>
                                              <td>
                                                <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                                  <tr>
                                                    <td style=""font: bold 14px/19px Arial, Helvetica, sans-serif; color:#333332;"">Cantidad Requerida: " + CantidadRequerida + @"</a></td>
                                                    <td width=""50%"">
                                                      <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""right"">
                                                        <tr>
                                                          <td style=""font: bold 14px/19px Arial, Helvetica, sans-serif; color:#333332;"" align=""center"" >Cantidad Gratis: " + CantidadGratis + @"</td>
                                                        </tr>
                                                      </table>
                                                    </td>
                                                  </tr>
                                                </table>
                                              </td>
                                            </tr>
                                          </table></td>
                                        <td width=""25"" class=""sidespace"">&nbsp;</td>
                                      </tr>
                                    </table></td>
                                </tr>
                                <tr>
                                  <td height=""22"">&nbsp;</td>
                                </tr>
                              </table>
                            </td>
                          </tr>
                          <tr>
                            <td height=""32""></td>
                          </tr>
                        </table></td>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                    </tr>
                  </table></td>
              </tr>
            </table></td>
        </tr>
      </table></td>
  </tr>
</table>
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"">
  <tr>
    <td align=""center""><table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""devicewidth"">
        <tr>
          <td><table width=""100%"" bgcolor=""#ffffff"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"" style=""border-radius:0 0 7px 7px;"">
              <tr>
                <td height=""18"">&nbsp;</td>
              </tr>
              <tr>
                <td>
                  <table class=""inner"" align=""left"" width=""230"" border=""0"" cellspacing=""0"" cellpadding=""0"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt; text-align:center;"">
                    <tr>
                      <td width=""21"">&nbsp;</td>
                      <td>
                        <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                          <tr>
                            <td align=""center"" style=""font:11px Helvetica,  Arial, sans-serif; color:#000000;"">&copy; " + DateTime.Now.Year + @", All rights reserved </td>
                          </tr>
                          <tr>
                            <td height=""18"">&nbsp;</td>
                          </tr>
                        </table>
                      </td>
                      <td width=""21"">&nbsp;</td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table></td>
        </tr>
        <tr>
          <td height=""20"">&nbsp;</td>
        </tr>
      </table></td>
  </tr>
</table>
</body>
</html>";
                return html;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GenerarHtmlMxN(Vales Datos)
        {
            try
            {
                string dominio = "http://www.steph.com.mx/"; //"http://www.creativasoftlineapps.com/ofelianarvaezmanual/";
                string html = "";
                string NombreVale = Datos.Nombre;
                string FolioVale = Datos.Folio;
                string NombreProducto = Datos.ProductoRequerido.NombreProducto;
                string ClaveProducto = Datos.ProductoRequerido.Clave;
                string CantidadRequerida = Datos.CantRequeridad.ToString();
                int CantidadLimite = Datos.CantLimite;
                string NombreProductoGratis = Datos.ProductoGratis.NombreProducto1;
                string ClaveProductoGratis = Datos.ProductoGratis.ClaveN;
                string CantidadGratis = Datos.CantGratis.ToString();
                bool RequierePerido = Datos.RequierePeriodo;
                string FechaInicio = Datos.FechaInicio.ToShortDateString();
                string FechaFin = Datos.FechaFin.ToShortDateString();
                string DiasSemana = Cadena(Datos.Lunes, Datos.Martes, Datos.Miercoles, Datos.Jueves, Datos.Viernes, Datos.Sabado, Datos.Domingo);

                html = @"<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">
<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,700,600' rel='stylesheet' type='text/css'>
<head>
<!--[if gte mso 12]>
> <style type=""text/css"">
> [a.btn {
	padding:15px 22px !important;
	display:inline-block !important;
}]
> </style>
> <![endif]-->
<title>kreative</title>
<style type=""text/css"">
div, p, a, li, td {
	-webkit-text-size-adjust:none;
}
.ReadMsgBody {
	width: 100%;
	background-color: #d1d1d1;
}
.ExternalClass {
	width: 100%;
	background-color: #d1d1d1;
	line-height:100%;
}
body {
	width: 100%;
	height: 100%;
	background-color: #d1d1d1;
	margin:0;
	padding:0;
	-webkit-font-smoothing: antialiased;
	-webkit-text-size-adjust:100%;
}
html {
	width: 100%;
}
img {
	-ms-interpolation-mode:bicubic;
}
table[class=full] {
	padding:0 !important;
	border:none !important;
}
table td img[class=imgresponsive] {
	width:100% !important;
	height:auto !important;
	display:block !important;
}
@media only screen and (max-width: 800px) {
body {
 width:auto!important;
}
table[class=full] {
 width:100%!important;
}
table[class=devicewidth] {
 width:100% !important;
 padding-left:20px !important;
 padding-right: 20px!important;
}
table td img.responsiveimg {
 width:100% !important;
 height:auto !important;
 display:block !important;
}
}
@media only screen and (max-width: 640px) {
table[class=devicewidth] {
 width:100% !important;
}
table[class=inner] {
 width:100%!important;
 text-align: center!important;
 clear: both;
}
table td a[class=top-button] {
 width:160px !important;
  font-size:14px !important;
 line-height:37px !important;
}
table td[class=readmore-button] {
 text-align:center !important;
}
table td[class=readmore-button] a {
 float:none !important;
 display:inline-block !important;
}
.hide {
 display:none !important;
}
table td[class=smallfont] {
 border:none !important;
 font-size:26px !important;
}
table td[class=sidespace] {
 width:10px !important;
}
}
 @media only screen and (max-width: 520px) {
}
@media only screen and (max-width: 480px) {

 table {
 border-collapse: collapse;
}
table td[class=template-img] img {
 width:100% !important;
 display:block !important;
}
}
@media only screen and (max-width: 320px) {
}
</style>
</head>
<body>
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"">
  <tr>
    <td height=""54"">&nbsp;</td>
  </tr>
</table>
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""full"">
  <tr>
    <td align=""center""><table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""devicewidth"">
        <tr>
          <td><table width=""100%"" bgcolor=""#ffffff"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"" style=""border-radius:5px 5px 0 0; background-color:#ffffff;"">
              <tr>
                <td height=""29"">&nbsp;</td>
              </tr>
              <tr>
                <td><table border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"" class=""inner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                    <tr>
                      <td width=""23"" class=""hide"">&nbsp;</td>
                      <td height=""75"" class=""inner"" valign=""middle""><a href=""#""><img class=""logo"" src=""" + dominio + @"upload/light-logo-2.png"" width=""180"" height=""61"" alt=""Logo""></a></td>
                    </tr>
                  </table>
                  <table width=""150"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""right"" class=""inner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                    <tr>
                      <td height=""15"">&nbsp;</td>
                    </tr>
                  </table></td>
              </tr>
              <tr>
                <td style=""border-bottom:1px solid #dbdbdb;"">&nbsp;</td>
              </tr>
            </table></td>
        </tr>
      </table></td>
  </tr>
</table>
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""full"">
  <tr>
    <td align=""center""><table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""devicewidth"">
        <tr>
          <td><table width=""100%"" bgcolor=""#ffffff"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"" style=""background-color:#ffffff;"">
              <tr>
                <td height=""23"">&nbsp;</td>
              </tr>
              <tr>
                <td>
                  <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                    <tr>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                      <td><table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""inner"" id=""banner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                          <tr>
                            <td style=""font:bold 27px Arial, Helvetica, sans-serif;"" class=""smallfont"">" + NombreVale + @"</td>
                          </tr>
                          <tr>
                            <td height=""20"">&nbsp;</td>
                          </tr>
                        </table>
                        <table width=""22%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""right"" class=""inner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                            <td height=""20"">&nbsp;</td>
                            <td height=""20"">&nbsp;</td>
                            <td height=""20"">&nbsp;</td>
                          </tr>
                        </table></td>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                    </tr>
                  </table>
                  <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                    <tr>
                      <td width=""3.33%"" class=""sidespace"">&nbsp;</td>
                      <td width=""93.33%""><img class=""imgresponsive"" src=""" + dominio + @"upload/FZK_7266%2002.jpg"" width=""554"" height=""atuo"" alt=""Banner"" /></td>
                      <td width=""3.33%"" class=""sidespace"">&nbsp;</td>
                    </tr>
                    <tr>
                      <td height=""20"">&nbsp;</td>
                      <td height=""20"">&nbsp;</td>
                      <td height=""20"">&nbsp;</td>
                    </tr>
                  </table>
                  <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                    <tr>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                      <td>
                        <table width=""48%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"" class=""inner"">
                          <tr>
                            <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont"">Folio: " + FolioVale + @"</td>
                          </tr>
                        </table>";
                        if (CantidadLimite == 0)
                        {
                            html = html + @"
                                           <table width=""48%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"" class=""inner"">
                                          <tr>
                                            <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont"">Válido hasta agotar existencia</td>
                                          </tr>
                                        </table>";
                        }
                        else
                        {
                            html = html + @"
                                           <table width=""48%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"" class=""inner"">
                                          <tr>
                                            <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont"">Válido a los primeros " + CantidadLimite + @" clientes</td>
                                          </tr>
                                        </table>";
                        }
                        html = html + @"
                    </tr>
                    <tr>
                      <td height=""16"">&nbsp;</td>
                      <td height=""16"">&nbsp;</td>
                      <td height=""16"">&nbsp;</td>
                    </tr>
                  </table>
                    ";
                if (RequierePerido == true)
                {
                    html = html + @"
                            <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                            <tr>
                              <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont"">Válido del: " + FechaInicio + @" al " + FechaFin + @" </td>
                            </tr>
                            <tr>
                              <td height=""16"">&nbsp;</td>
                              <td height=""16"">&nbsp;</td>
                              <td height=""16"">&nbsp;</td>
                            </tr>
                          </table>
                            ";
                }
                else
                {
                    html = html + @"
                             <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                            <tr>
                            
                              <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"" align = ""center""  whidth =""50"" class=""smallfont""> " + DiasSemana + @"</td>
                           
                            </tr>
                            <tr>
                              <td height=""16"">&nbsp;</td>
                              <td height=""16"">&nbsp;</td>
                              <td height=""16"">&nbsp;</td>
                            </tr>
                            </table>";
                }
                html = html + @"          
                </td>
              </tr>
              <tr>
                <td style=""border-bottom:20px solid #dbdbdb;"">&nbsp;</td>
              </tr>
            </table></td>
        </tr>
      </table></td>
  </tr>
</table>
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""full"">
  <tr>
    <td align=""center"">
      <table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""devicewidth"">
        <tr>
          <td>
            <table width=""100%"" bgcolor=""#f1f1f1"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"">
              <tr>
                <td>
                  <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""full"">
                    <tr>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                      <td>
                        <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                          <tr>
                            <td>
                              <!--Inicia la Tabla de los Productos-->
                              <table align=""left"" width=""48%"" bgcolor=""#ffffff"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""inner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                                <tr>
                                  <td height=""22"">&nbsp;</td>
                                </tr>
                                <tr>
                                  <td>
                                    <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""inner"">
                                      <tr>
                                        <td width=""20"" class=""sidespace"">&nbsp;</td>
                                        <td><table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                            <tr>
                                              <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"">" + NombreProducto + @"</td>
                                            </tr>
                                            <tr>
                                              <td height=""5""></td>
                                            </tr>
                                            <tr>
                                              <td style=""font:14px/19px Arial, Helvetica, sans-serif; color:#333332;"">Clave: " + ClaveProducto + @"</td>
                                            </tr>
                                            <tr>
                                              <td height=""22"">&nbsp;</td>
                                            </tr>
                                            <tr>
                                              <td>
                                                <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                                  <tr>
                                                    <td width=""50%"" align=""left"">Cantidad requeridad: " + CantidadRequerida + @"</td>
                                                  </tr>
                                                </table>
                                              </td>
                                            </tr>
                                          </table></td>
                                        <td width=""20"" class=""sidespace"">&nbsp;</td>
                                      </tr>
                                    </table>
                                  </td>
                                </tr>
                                <tr>
                                  <td height=""22"">&nbsp;</td>
                                </tr>
                                <tr>
                                  <td height=""16"" bgcolor=""#f1f1f1""></td>
                                </tr>
                              </table>
                              <table align=""right"" width=""48%"" bgcolor=""#ffffff"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""inner"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;"">
                                <tr>
                                  <td height=""22"">&nbsp;</td>
                                </tr>
                                <tr>
                                  <td>
                                    <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""inner"">
                                      <tr>
                                        <td width=""20"" class=""sidespace"">&nbsp;</td>
                                        <td>
                                          <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                            <tr>
                                              <td style=""font:bold 20px Arial, Helvetica, sans-serif; color:#333332;"">" + NombreProductoGratis + @"</td>
                                            </tr>
                                            <tr>
                                              <td height=""5""></td>
                                            </tr>
                                            <tr>
                                              <td style=""font:14px/19px Arial, Helvetica, sans-serif; color:#333332;"">Clave: " + ClaveProductoGratis + @"</td>
                                            </tr>
                                            <tr>
                                              <td height=""22"">&nbsp;</td>
                                            </tr>
                                            <tr>
                                              <td>
                                                  <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                                    <tr>
                                                      <td width=""50%"" align=""left"">Cantidad Gratis: " + CantidadGratis + @"</td>
                                                    </tr>
                                                  </table>
                                              </td>
                                            </tr>
                                          </table>
                                        </td>
                                            </tr>
                                          </table></td>
                                        <td width=""20"" class=""sidespace"">&nbsp;</td>
                                      </tr>
                                    </table>
                                  </td>
                                </tr>
                                <tr>
                                  <td height=""22"">&nbsp;</td>
                                </tr>
                                <tr>
                                  <td height=""16"" bgcolor=""#f1f1f1""></td>
                                </tr>
                              </table>
                              <!--Termina la Tabla de los Productos-->
                            </td>
                          </tr>
                          <tr>
                            <td height=""16""></td>
                          </tr>
                        </table>
                      </td>
                      <td width=""23"" class=""sidespace"">&nbsp;</td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>
<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"">
  <tr>
    <td align=""center""><table width=""600"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""devicewidth"">
        <tr>
          <td><table width=""100%"" bgcolor=""#ffffff"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"" class=""full"" style=""border-radius:0 0 7px 7px;"">
              <tr>
                <td height=""18"">&nbsp;</td>
              </tr>
              <tr>
                <td>
                  <table class=""inner"" align=""left"" width=""230"" border=""0"" cellspacing=""0"" cellpadding=""0"" style=""border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt; text-align:center;"">
                    <tr>
                      <td width=""21"">&nbsp;</td>
                      <td>
                        <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""center"">
                          <tr>
                            <td align=""center"" style=""font:11px Helvetica,  Arial, sans-serif; color:#000000;"">&copy; " + DateTime.Now.Year + @", All rights reserved </td>
                          </tr>
                          <tr>
                            <td height=""18"">&nbsp;</td>
                          </tr>
                        </table>
                      </td>
                      <td width=""21"">&nbsp;</td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table></td>
        </tr>
        <tr>
          <td height=""20"">&nbsp;</td>
        </tr>
      </table></td>
  </tr>
</table>
</body>
</html>";
                return html;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GenerarHtmlRegistoUsuario(string Usuario, string Password)
        {
            //string login = "www.stehp.com.mx/Login/Index";
            string creativa = "http://creativasoftline.com";
            string html = @"<!DOCTYPE html>
	        <html>
	        <head>
		        <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
		        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
		        <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
		        <meta name=""format-detection"" content=""telephone=no"" />
		        <title>Steph uñas & spa</title>
		        <style type=""text/css"">
			        html { background-color:#E1E1E1; margin:0; padding:0; }
			        body, #bodyTable, #bodyCell, #bodyCell{height:100% !important; margin:0; padding:0; width:100% !important;font-family:Helvetica, Arial, ""Lucida Grande"", sans-serif;}
			        table{border-collapse:collapse;}
			        table[id=bodyTable] {width:100%!important;margin:auto;max-width:500px!important;color:#b6b24c;font-weight:normal;}
			        img, a img{border:0; outline:none; text-decoration:none;height:auto; line-height:100%;}
			        a {text-decoration:none !important;border-bottom: 1px solid;}
			        h1, h2, h3, h4, h5, h6{color:#5F5F5F; font-weight:normal; font-family:Helvetica; font-size:20px; line-height:125%; text-align:Left; letter-spacing:normal;margin-top:0;margin-right:0;margin-bottom:10px;margin-left:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;}
			        .ReadMsgBody{width:100%;} .ExternalClass{width:100%;} /* Force Hotmail/Outlook.com to display emails at full width. */
			        .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div{line-height:100%;} /* Force Hotmail/Outlook.com to display line heights normally. */
			        table, td{mso-table-lspace:0pt; mso-table-rspace:0pt;} /* Remove spacing between tables in Outlook 2007 and up. */
			        #outlook a{padding:0;} /* Force Outlook 2007 and up to provide a ""view in browser"" message. */
			        img{-ms-interpolation-mode: bicubic;display:block;outline:none; text-decoration:none;} /* Force IE to smoothly render resized images. */
			        body, table, td, p, a, li, blockquote{-ms-text-size-adjust:100%; -webkit-text-size-adjust:100%; font-weight:normal!important;} /* Prevent Windows- and Webkit-based mobile platforms from changing declared text sizes. */
			        .ExternalClass td[class=""ecxflexibleContainerBox""] h3 {padding-top: 10px !important;} /* Force hotmail to push 2-grid sub headers down */

			        h1{display:block;font-size:26px;font-style:normal;font-weight:normal;line-height:100%;}
			        h2{display:block;font-size:20px;font-style:normal;font-weight:normal;line-height:120%;}
			        h3{display:block;font-size:17px;font-style:normal;font-weight:normal;line-height:110%;}
			        h4{display:block;font-size:18px;font-style:italic;font-weight:normal;line-height:100%;}
			        .flexibleImage{height:auto;}
			        .linkRemoveBorder{border-bottom:0 !important;}
			        table[class=flexibleContainerCellDivider] {padding-bottom:0 !important;padding-top:0 !important;}

			        body, #bodyTable{background-color:#E1E1E1;}
			        #emailHeader{background-color:#b6b24c;}
			        #emailBody{background-color:#FFFFFF;}
			        #emailFooter{background-color:#E1E1E1;}
			        .nestedContainer{background-color:#F8F8F8; border:1px solid #CCCCCC;}
			        .emailButton{background-color:#205478; border-collapse:separate;}
			        .buttonContent{color:#FFFFFF; font-family:Helvetica; font-size:18px; font-weight:bold; line-height:100%; padding:15px; text-align:center;}
			        .buttonContent a{color:#FFFFFF; display:block; text-decoration:none!important; border:0!important;}
			        .emailCalendar{background-color:#FFFFFF; border:1px solid #CCCCCC;}
			        .emailCalendarMonth{background-color:#205478; color:#FFFFFF; font-family:Helvetica, Arial, sans-serif; font-size:16px; font-weight:bold; padding-top:10px; padding-bottom:10px; text-align:center;}
			        .emailCalendarDay{color:#205478; font-family:Helvetica, Arial, sans-serif; font-size:60px; font-weight:bold; line-height:100%; padding-top:20px; padding-bottom:20px; text-align:center;}
			        .imageContentText {margin-top: 10px;line-height:0;}
			        .imageContentText a {line-height:0;}
			        #invisibleIntroduction {display:none !important;} /* Removing the introduction text from the view */
			        span[class=ios-color-hack] a {color:#275100!important;text-decoration:none!important;}
			        span[class=ios-color-hack2] a {color:#205478!important;text-decoration:none!important;}
			        span[class=ios-color-hack3] a {color:#8B8B8B!important;text-decoration:none!important;}
			        .a[href^=""tel""], a[href^=""sms""] {text-decoration:none!important;color:#606060!important;pointer-events:none!important;cursor:default!important;}
			        .mobile_link a[href^=""tel""], .mobile_link a[href^=""sms""] {text-decoration:none!important;color:#606060!important;pointer-events:auto!important;cursor:default!important;}

			        @media only screen and (max-width: 480px){
				        body{width:100% !important; min-width:100% !important;}
				        /*td[class=""textContent""], td[class=""flexibleContainerCell""] { width: 100%; padding-left: 10px !important; padding-right: 10px !important; }*/
				        table[id=""emailHeader""],
				        table[id=""emailBody""],
				        table[id=""emailFooter""],
				        table[class=""flexibleContainer""],
				        td[class=""flexibleContainerCell""] {width:100% !important;}
				        td[class=""flexibleContainerBox""], td[class=""flexibleContainerBox""] table {display: block;width: 100%;text-align: left;}
				        td[class=""imageContent""] img {height:auto !important; width:100% !important; max-width:100% !important; }
				        img[class=""flexibleImage""]{height:auto !important; width:100% !important;max-width:100% !important;}
				        img[class=""flexibleImageSmall""]{height:auto !important; width:auto !important;}
				        table[class=""emailButton""]{width:100% !important;}
				        td[class=""buttonContent""]{padding:0 !important;}
				        td[class=""buttonContent""] a{padding:15px !important;}
			        }
			        @media only screen and (-webkit-device-pixel-ratio:.75){
			        }
			        @media only screen and (-webkit-device-pixel-ratio:1){
			        }
			        @media only screen and (-webkit-device-pixel-ratio:1.5){
			        }
			        @media only screen and (min-device-width : 320px) and (max-device-width:568px) {
			        }
		        </style>
		        <!--[if mso 12]><style type=""text/css"">.flexibleContainer{display:block !important; width:100% !important;}</style><![endif]-->
		        <!--[if mso 14]><style type=""text/css"">.flexibleContainer{display:block !important; width:100% !important;}</style><![endif]-->
	        </head>
	        <body bgcolor=""#E1E1E1"" leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0"">
		        <center style=""background-color:#E1E1E1;"">
			        <table border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""bodyTable"" style=""table-layout: fixed;max-width:100% !important;width: 100% !important;min-width: 100% !important;"">
				        <tr>
					        <td align=""center"" valign=""top"" id=""bodyCell"">
						        <table bgcolor=""#FFFFFF""  border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" id=""emailBody"">
							        <tr>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""color:#FFFFFF;"" bgcolor=""#20adb7"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td align=""center"" valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td align=""center"" valign=""top"" class=""textContent"">
																		        <div width=""70%"" height=""auto""><img min-height=""100%"" width=""100%"" src=""" + creativa + @"upload/light-logo-2.png""></div>
																	        </td>
																	        
																        </tr>
																        <tr bgcolor=""#f1e750"">
																        	
																        </tr>
																        <tr bgcolor=""#e32826"">
																        	<td align=""center"" valign=""top"" class=""textContent""><h1 style=""color:#FFFFFF;line-height:100%;font-family:Helvetica,Arial,sans-serif;font-size:25px;font-weight:normal;margin-bottom:5px;text-align:center;"">Acceso a nuestros sistemas</h1></td>
																        </tr>
															        </table>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
							        <tr mc:hideable>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td align=""left"" valign=""top"" class=""flexibleContainerBox"">
																		        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""210"" style=""max-width: 100%;"">
																			        <tr>
																				        <td align=""left"" class=""textContent"">
																					        <h3 style=""color:#e32826;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;"">Usuario:</h3>
																					        <div style=""text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;"">" + Usuario + @"<br><br><br></div>
																				        </td>
																			        </tr>
																		        </table>
																	        </td>
																	        <td align=""right"" valign=""middle"" class=""flexibleContainerBox"">
																		        <table class=""flexibleContainerBoxNext"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""210"" style=""max-width: 100%;"">
																			        <tr>
																				        <td align=""left"" class=""textContent"">
																					        <h3 style=""color:#e32826;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;"">Password:</h3>
																					        <div style=""text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;"">" + Password + @"<br><br><br></div>
																				        </td>
																			        </tr>
																		        </table>
																	        </td>
																        </tr>
																        <tr>
																        <td align=""right"" valign=""middle"" class=""flexibleContainerBox"">
																		        <table class=""flexibleContainerBoxNext"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""210"" style=""max-width: 100%;"">
																			        <tr >
																				        <td colspan=""2"" align=""left"" class=""textContent"">
																					        <a href=""http://www.creativasoftline.com"" style=""position:absolute;width:10%;left:45%;text-decoration: none;padding: 10px;font-weight: 600;font-size: 20px;color: #ffffff;background-color: #e32826;border-radius: 6px;text-align:center;top:240px;"">Ingresar</a>
																				        </td>
																			        </tr>

																		        </table>
																	        </td>
																	    </tr>
															        </table>
															        <br><br>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
							        
						        </table>
						        <table bgcolor=""#E1E1E1"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" id=""emailFooter"">
							        <tr>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td align=""center"" valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td valign=""top"" bgcolor=""#E1E1E1"">
																		        <div style=""font-family:Helvetica,Arial,sans-serif;font-size:13px;color:#828282;text-align:center;line-height:120%;"">
																			        <div>Copyright &#169; " + DateTime.Now.Year + @" <a href=""" + creativa + @""" target=""_blank"" style=""text-decoration:none;color:#828282;""><span style=""color:#828282;"">CSL</span></a>. All&nbsp;rights&nbsp;reserved.</div>
																			        <div>Creativa Softline <a href=""" + creativa + @""" target=""_blank"" style=""text-decoration:none;color:#828282;""><span style=""color:#828282;"">comunicarse</span></a>.</div>
																		        </div>
																	        </td>
																        </tr>
															        </table>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
						        </table>
					        </td>
				        </tr>
			        </table>
		        </center>
	        </body>
        </html>
            ";
            return html;
        }

    }
}
