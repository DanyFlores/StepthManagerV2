using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StephManager.ClasesAux
{
    public static class UtilFtp
    {
        public static bool UploadFTP(string FilePath, string RemotePath, string Login, string Password)
        {
            try
            {
                using (FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    string url = Path.Combine(RemotePath, Path.GetFileName(FilePath)).ToLower();
                    FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(url);
                    ftp.Credentials = new NetworkCredential(Login, Password);
                    ftp.Method = WebRequestMethods.Ftp.UploadFile;
                    ftp.KeepAlive = false;
                    ftp.UseBinary = true;
                    ftp.ContentLength = fs.Length;
                    ftp.Proxy = null;
                    fs.Position = 0;
                    int buffLength = 2048;
                    byte[] buff = new byte[buffLength];
                    int contentLen;
                    using (Stream strm = ftp.GetRequestStream())
                    {
                        contentLen = fs.Read(buff, 0, buffLength);
                        while (contentLen != 0)
                        {
                            strm.Write(buff, 0, contentLen);
                            contentLen = fs.Read(buff, 0, buffLength);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "UtilFtp ~ UploadFTP");
                return false;
            }
        }
        public static bool DownloadFile(string FilePath, string RemotePath, string Login, string Password)
        {
            try
            {
                string url = Path.Combine(RemotePath, Path.GetFileName(FilePath));
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(url);
                ftp.Credentials = new NetworkCredential(Login, Password);
                ftp.Method = WebRequestMethods.Ftp.DownloadFile;
                ftp.KeepAlive = false;
                ftp.UseBinary = true;
                ftp.Proxy = null;
                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                Stream stream = response.GetResponseStream();
                byte[] buffer = new byte[2048];
                FileStream fs = new FileStream(FilePath, FileMode.Create);
                int ReadCount = stream.Read(buffer, 0, buffer.Length);
                while (ReadCount > 0)
                {
                    fs.Write(buffer, 0, ReadCount);
                    ReadCount = stream.Read(buffer, 0, buffer.Length);
                }
                fs.Close();
                stream.Close();
                return true;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "UtilFtp ~ DownloadFile");
                return false;
            }
        }
        public static string[] directoryListSimple(string RemotePath, string Login, string Password)
        {
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create(RemotePath);
                ftpRequest.Credentials = new NetworkCredential(Login, Password);
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                Stream ftpStream = ftpResponse.GetResponseStream();
                StreamReader ftpReader = new StreamReader(ftpStream);
                string directoryRaw = null;
                try
                {
                    while (ftpReader.Peek() != -1)
                    {
                        directoryRaw += ftpReader.ReadLine() + "|";
                    }
                }
                catch (Exception ex)
                {
                    LogError.AddExcFileTxt(ex, "UtilFtp ~ while (ftpReader.Peek() != -1)");
                    return new string[] { "" };
                }
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                try
                {
                    string[] directoryList = directoryRaw.Split("|".ToCharArray());
                    if (directoryList != null)
                        directoryList = directoryList.Where(val => val != "").ToArray();
                    return directoryList;
                }
                catch (Exception ex)
                {
                    LogError.AddExcFileTxt(ex, "UtilFtp ~ directoryList");
                    return new string[] { "" };
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "UtilFtp ~ directoryListSimple");
                return new string[] { "" };
            }
        }
    }
}
