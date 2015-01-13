using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI;

namespace Workflow.Common
{
    public static class FTPHelper
    {
        //string ftpServerIP;
        //string ftpRemotePath;
        //string ftpUserID;
        //string ftpPassword;
        //string ftpURI;

        ///// <summary>
        ///// 连接FTP
        ///// </summary>
        ///// <param name="FtpServerIP">FTP连接地址</param>
        ///// <param name="FtpRemotePath">指定FTP连接成功后的当前目录, 如果不指定即默认为根目录</param>
        ///// <param name="FtpUserID">用户名</param>
        ///// <param name="FtpPassword">密码</param>
        //public FTPHelper(string FtpServerIP, string FtpRemotePath, string FtpUserID, string FtpPassword)
        //{
        //    ftpServerIP = FtpServerIP;
        //    ftpRemotePath = FtpRemotePath;
        //    ftpUserID = FtpUserID;
        //    ftpPassword = FtpPassword;
        //    ftpURI = "ftp://" + ftpServerIP + "/" + ftpRemotePath + "/";
        //}

        ///// <summary>
        ///// 上传
        ///// </summary>
        ///// <param name="filename"></param>
        //public void Upload(string filename)
        //{
        //    FileInfo fileInf = new FileInfo(filename);
        //    string uri = ftpURI + fileInf.Name;
        //    FtpWebRequest reqFTP;

        //    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
        //    reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
        //    reqFTP.KeepAlive = false;
        //    reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
        //    reqFTP.UseBinary = true;
        //    reqFTP.ContentLength = fileInf.Length;
        //    int buffLength = 2048;
        //    byte[] buff = new byte[buffLength];
        //    int contentLen;
        //    FileStream fs = fileInf.OpenRead();
        //    try
        //    {
        //        Stream strm = reqFTP.GetRequestStream();
        //        contentLen = fs.Read(buff, 0, buffLength);
        //        while (contentLen != 0)
        //        {
        //            strm.Write(buff, 0, contentLen);
        //            contentLen = fs.Read(buff, 0, buffLength);
        //        }
        //        strm.Close();
        //        fs.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Insert_Standard_ErrorLog.Insert("FtpWeb", "Upload Error --> " + ex.Message);
        //    }
        //}

        ///// <summary>
        ///// 下载
        ///// </summary>
        ///// <param name="filePath"></param>
        ///// <param name="fileName"></param>
        //public void Download(string filePath, string fileName)
        //{
        //    FtpWebRequest reqFTP;
        //    try
        //    {
        //        FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);

        //        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + fileName));
        //        reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
        //        reqFTP.UseBinary = true;
        //        reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
        //        FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
        //        Stream ftpStream = response.GetResponseStream();

        //        long cl = response.ContentLength;

        //        int bufferSize = 2048;
        //        int readCount;
        //        byte[] buffer = new byte[bufferSize];

        //        readCount = ftpStream.Read(buffer, 0, bufferSize);
        //        while (readCount > 0)
        //        {
        //            outputStream.Write(buffer, 0, readCount);
        //            readCount = ftpStream.Read(buffer, 0, bufferSize);
        //        }

        //        ftpStream.Close();
        //        outputStream.Close();
        //        response.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Insert_Standard_ErrorLog.Insert("FtpWeb", "Download Error --> " + ex.Message);
        //    }
        //}

        ///// <summary>
        ///// 删除文件
        ///// </summary>
        ///// <param name="fileName"></param>
        //public void Delete(string fileName)
        //{
        //    try
        //    {
        //        string uri = ftpURI + fileName;
        //        FtpWebRequest reqFTP;
        //        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

        //        reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
        //        reqFTP.KeepAlive = false;
        //        reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;

        //        string result = String.Empty;
        //        FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
        //        long size = response.ContentLength;
        //        Stream datastream = response.GetResponseStream();
        //        StreamReader sr = new StreamReader(datastream);
        //        result = sr.ReadToEnd();
        //        sr.Close();
        //        datastream.Close();
        //        response.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Insert_Standard_ErrorLog.Insert("FtpWeb", "Delete Error --> " + ex.Message + "  文件名:" + fileName);
        //    }
        //}

        ///// <summary>
        ///// 获取当前目录下明细(包含文件和文件夹)
        ///// </summary>
        ///// <returns></returns>
        //public string[] GetFilesDetailList()
        //{
        //    string[] downloadFiles;
        //    try
        //    {
        //        StringBuilder result = new StringBuilder();
        //        FtpWebRequest ftp;
        //        ftp = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI));
        //        ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
        //        ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        //        WebResponse response = ftp.GetResponse();
        //        StreamReader reader = new StreamReader(response.GetResponseStream());
        //        string line = reader.ReadLine();
        //        //line = reader.ReadLine();
        //        //line = reader.ReadLine();
        //        while (line != null)
        //        {
        //            result.Append(line);
        //            result.Append("\n");

        //            result.Remove(result.ToString().LastIndexOf("\n"), 1);
        //            reader.Close();
        //            response.Close();
        //        }
        //        return result.ToString().Split('\n');

        //    }
        //    catch (Exception ex)
        //    {
        //        downloadFiles = null;
        //        Insert_Standard_ErrorLog.Insert("FtpWeb", "GetFilesDetailList Error --> " + ex.Message);
        //        return downloadFiles;
        //    }
        //}

        ///// <summary>
        ///// 获取当前目录下文件列表(仅文件)
        ///// </summary>
        ///// <returns></returns>
        //public string[] GetFileList(string mask)
        //{
        //    string[] downloadFiles;
        //    StringBuilder result = new StringBuilder();
        //    FtpWebRequest reqFTP;
        //    try
        //    {
        //        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI));
        //        reqFTP.UseBinary = true;
        //        reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
        //        reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
        //        WebResponse response = reqFTP.GetResponse();
        //        StreamReader reader = new StreamReader(response.GetResponseStream());

        //        string line = reader.ReadLine();
        //        while (line != null)
        //        {
        //            if (mask.Trim() != string.Empty && mask.Trim() != "*.*")
        //            {
        //                string mask_ = mask.Substring(0, mask.IndexOf("*"));
        //                if (line.Substring(0, mask_.Length) == mask_)
        //                {
        //                    result.Append(line);
        //                    result.Append("\n");
        //                }
        //            }
        //            else
        //            {
        //                result.Append(line);
        //                result.Append("\n");
        //            }
        //            line = reader.ReadLine();
        //        }
        //        result.Remove(result.ToString().LastIndexOf('\n'), 1);
        //        reader.Close();
        //        response.Close();
        //        return result.ToString().Split('\n');
        //    }
        //    catch (Exception ex)
        //    {
        //        downloadFiles = null;
        //        if (ex.Message.Trim() != "远程服务器返回错误: (550) 文件不可用(例如，未找到文件，无法访问文件)。")
        //        {
        //            Insert_Standard_ErrorLog.Insert("FtpWeb", "GetFileList Error --> " + ex.Message.ToString());
        //        }
        //        return downloadFiles;
        //    }
        //}

        ///// <summary>
        ///// 获取当前目录下所有的文件夹列表(仅文件夹)
        ///// </summary>
        ///// <returns></returns>
        //public string[] GetDirectoryList()
        //{
        //    string[] drectory = GetFilesDetailList();
        //    string m = string.Empty;
        //    foreach (string str in drectory)
        //    {
        //        if (str.Trim().Substring(0, 1).ToUpper() == "D")
        //        {
        //            m += str.Substring(54).Trim() + "\n";
        //        }
        //    }

        //    char[] n = new char[] { '\n' };
        //    return m.Split(n);
        //}

        ///// <summary>
        ///// 判断当前目录下指定的子目录是否存在
        ///// </summary>
        ///// <param name="RemoteDirectoryName">指定的目录名</param>
        //public bool DirectoryExist(string RemoteDirectoryName)
        //{
        //    string[] dirList = GetDirectoryList();
        //    foreach (string str in dirList)
        //    {
        //        if (str.Trim() == RemoteDirectoryName.Trim())
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// 判断当前目录下指定的文件是否存在
        ///// </summary>
        ///// <param name="RemoteFileName">远程文件名</param>
        //public bool FileExist(string RemoteFileName)
        //{
        //    string[] fileList = GetFileList("*.*");
        //    foreach (string str in fileList)
        //    {
        //        if (str.Trim() == RemoteFileName.Trim())
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// 创建文件夹
        ///// </summary>
        ///// <param name="dirName"></param>
        //public void MakeDir(string dirName)
        //{
        //    FtpWebRequest reqFTP;
        //    try
        //    {
        //        // dirName = name of the directory to create.
        //        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + dirName));
        //        reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
        //        reqFTP.UseBinary = true;
        //        reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
        //        FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
        //        Stream ftpStream = response.GetResponseStream();

        //        ftpStream.Close();
        //        response.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Insert_Standard_ErrorLog.Insert("FtpWeb", "MakeDir Error --> " + ex.Message);
        //    }
        //}

        ///// <summary>
        ///// 获取指定文件大小
        ///// </summary>
        ///// <param name="filename"></param>
        ///// <returns></returns>
        //public long GetFileSize(string filename)
        //{
        //    FtpWebRequest reqFTP;
        //    long fileSize = 0;
        //    try
        //    {
        //        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + filename));
        //        reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;



        //        ; reqFTP.UseBinary = true;
        //        reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
        //        FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
        //        Stream ftpStream = response.GetResponseStream();
        //        fileSize = response.ContentLength;

        //        ftpStream.Close();
        //        response.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Insert_Standard_ErrorLog.Insert("FtpWeb", "GetFileSize Error --> " + ex.Message);
        //    }
        //    return fileSize;
        //}

        ///// <summary>
        ///// 改名
        ///// </summary>
        ///// <param name="currentFilename"></param>
        ///// <param name="newFilename"></param>
        //public void ReName(string currentFilename, string newFilename)
        //{
        //    FtpWebRequest reqFTP;
        //    try
        //    {
        //        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + currentFilename));
        //        reqFTP.Method = WebRequestMethods.Ftp.Rename;
        //        reqFTP.RenameTo = newFilename;
        //        reqFTP.UseBinary = true;
        //        reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
        //        FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
        //        Stream ftpStream = response.GetResponseStream();

        //        ftpStream.Close();
        //        response.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Insert_Standard_ErrorLog.Insert("FtpWeb", "ReName Error --> " + ex.Message);
        //    }
        //}

        ///// <summary>
        ///// 移动文件
        ///// </summary>
        ///// <param name="currentFilename"></param>
        ///// <param name="newFilename"></param>
        //public void MovieFile(string currentFilename, string newDirectory)
        //{
        //    ReName(currentFilename, newDirectory);
        //}

        ///// <summary>
        ///// 切换当前目录
        ///// </summary>
        ///// <param name="DirectoryName"></param>
        ///// <param name="IsRoot">true 绝对路径   false 相对路径</param> 
        //public void GotoDirectory(string DirectoryName, bool IsRoot)
        //{
        //    if (IsRoot)
        //    {
        //        ftpRemotePath = DirectoryName;
        //    }
        //    else
        //    {
        //        ftpRemotePath += DirectoryName + "/";
        //    }
        //    ftpURI = "ftp://" + ftpServerIP + "/" + ftpRemotePath + "/";
        //}

        //public class Insert_Standard_ErrorLog
        //{
        //    public static void Insert(string x, string y)
        //    {

        //    }
        //}
        
        private static void UpMakeDirectory(string uploadUrl, string username, string password)
        {
            FtpWebResponse uploadResponse = null;
            try
            {
                FtpWebRequest uploadRequest =
                    (FtpWebRequest)WebRequest.Create(new Uri("FTP:/" + uploadUrl));
                uploadRequest.Method = WebRequestMethods.Ftp.MakeDirectory; //创建目录
                uploadRequest.Credentials = new System.Net.NetworkCredential(username, password);
                uploadRequest.Proxy = null;
                uploadResponse =
                    (FtpWebResponse)uploadRequest.GetResponse();
            }
            catch
            {
                if (uploadResponse != null)
                {
                    uploadResponse.Close();
                }
            }
            if (uploadResponse != null)
            {
                uploadResponse.Close();
            }
        }



        private static FtpWebRequest GetRequest(string URI, string username, string password)
        {
            //根据服务器信息FtpWebRequest创建类的对象
            FtpWebRequest result = (FtpWebRequest)FtpWebRequest.Create(URI);
            //提供身份验证信息
            result.Credentials = new System.Net.NetworkCredential(username, password);
            //设置请求完成之后是否保持到FTP服务器的控制连接，默认值为true
            result.KeepAlive = false;
            result.Proxy = null;
            return result;
        }


        public static void FtpCheckDirectoryExist(string destFilePath, string username, string password)
        {
            //string fullDir = FtpParseDirectory(destFilePath); 
            string[] dirs = destFilePath.Trim().Split('/');  //fullDir
            string curDir = "/";
            for (int i = 0; i < dirs.Length; i++)
            {
                string dir = dirs[i]; //如果是以/开始的路径,第一个为空 
              
                if (dir != null && dir.Length > 0)
                {
                    try
                    {
                        curDir += dir + "/";
                        UpMakeDirectory(curDir, username, password);
                        //FtpMakeDir(curDir); 
                    }
                    catch (Exception)
                    { }
                }
            }
        }


        public static bool UploadFile(FileInfo fileinfo, string target, string targetDir, string hostname, string username, string password)
        {
            bool isUpload = false;
            if (targetDir.Trim() == "")
            {
                return isUpload;
            }

            string URI = "FTP://" + hostname + "/" + targetDir + "/" + target;
            System.Net.FtpWebRequest ftp = GetRequest(URI, username, password);
            FtpCheckDirectoryExist(hostname + "/" + targetDir + "/", username, password);
            ftp.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
            ftp.UseBinary = true;
            ftp.UsePassive = true;
            ftp.ContentLength = fileinfo.Length;
            const int BufferSize = 2048;
            byte[] content = new byte[BufferSize - 1 + 1];
            int dataRead;

            using (FileStream fs = fileinfo.OpenRead())
            {
                try
                {
                    using (Stream rs = ftp.GetRequestStream())
                    {
                        do
                        {
                            dataRead = fs.Read(content, 0, BufferSize);                         
                            rs.Write(content, 0, dataRead);
                        } while (!(dataRead < BufferSize));
                        rs.Close();
                    }
                    isUpload = true;
                }
                catch (Exception)
                { isUpload = false; }
                finally
                {
                    fs.Close();
                }

            }
            ftp = null;
            return isUpload;
        }
        //public void Download(string filePath, string fileName)
        //{
        //    FtpWebRequest reqFTP;
        //    try
        //    {
        //        FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);

        //        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI + fileName));
        //        reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
        //        reqFTP.UseBinary = true;
        //        reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
        //        FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
        //        Stream ftpStream = response.GetResponseStream();

        //        long cl = response.ContentLength;

        //        int bufferSize = 2048;
        //        int readCount;
        //        byte[] buffer = new byte[bufferSize];

        //        readCount = ftpStream.Read(buffer, 0, bufferSize);
        //        while (readCount > 0)
        //        {
        //            outputStream.Write(buffer, 0, readCount);
        //            readCount = ftpStream.Read(buffer, 0, bufferSize);
        //        }

        //        ftpStream.Close();
        //        outputStream.Close();
        //        response.Close();
        //    }
        //    catch (Exception ex)
        //    {
              
        //    }
        //}

        //public static bool fileDelete(string hostname, string targetDir, string target, string username, string password)
        //{
        //    bool success = false;
        //    System.Net.FtpWebRequest ftpWebRequest = null;
        //    System.Net.FtpWebResponse ftpWebResponse = null;
        //    Stream ftpResponseStream = null;
        //    StreamReader streamReader = null;

        //    try
        //    {
        //        string URI = "FTP://" + hostname + "/" + targetDir + "/" + target;
        //        ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(URI));
        //        ftpWebRequest.Credentials = new NetworkCredential(username, password);
        //        ftpWebRequest.KeepAlive = false;
        //        ftpWebRequest.Proxy = null;
        //        ftpWebRequest.Method = WebRequestMethods.Ftp.DeleteFile;

        //        ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
        //        long size = ftpWebResponse.ContentLength;

        //        ftpResponseStream = ftpWebResponse.GetResponseStream();
        //        streamReader = new StreamReader(ftpResponseStream);

        //        string result = String.Empty;
        //        result = streamReader.ReadToEnd();
        //        success = true;
        //    }
        //    catch (Exception)
        //    {
        //        success = false;
        //    }
        //    finally
        //    {
        //        if (streamReader != null)
        //        {
        //            streamReader.Close();
        //        }

        //        if (ftpResponseStream != null)
        //        {
        //            ftpResponseStream.Close();
        //        }

        //        if (ftpWebResponse != null)
        //        {
        //            ftpWebResponse.Close();
        //        }
        //    }

        //    return success;
        //}
        public static bool fileDelete(string hostname, string target, string username, string password)
        {
            bool success = false;
            System.Net.FtpWebRequest ftpWebRequest = null;
            System.Net.FtpWebResponse ftpWebResponse = null;
            Stream ftpResponseStream = null;
            StreamReader streamReader = null;

            try
            {
                string URI = "FTP://" + hostname + "/" + target ;
                ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(URI));
                ftpWebRequest.Credentials = new NetworkCredential(username, password);
                ftpWebRequest.KeepAlive = false;
                ftpWebRequest.Proxy = null;
                ftpWebRequest.Method = WebRequestMethods.Ftp.DeleteFile;

                ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
                long size = ftpWebResponse.ContentLength;

                ftpResponseStream = ftpWebResponse.GetResponseStream();
                streamReader = new StreamReader(ftpResponseStream);

                string result = String.Empty;
                result = streamReader.ReadToEnd();
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }

                if (ftpResponseStream != null)
                {
                    ftpResponseStream.Close();
                }

                if (ftpWebResponse != null)
                {
                    ftpWebResponse.Close();
                }
            }

            return success;
        }

        public static bool fileCheckExist(string hostname, string targetDir, string target, string username, string password)
        {
            bool success = false;
            FtpWebRequest ftpWebRequest = null;
            WebResponse webResponse = null;
            StreamReader reader = null;
            try
            {
                string URI = "FTP://" + hostname + "/" + targetDir + "/" + target;
                ftpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(URI));
                ftpWebRequest.Credentials = new NetworkCredential(username, password);
                ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                ftpWebRequest.KeepAlive = false;
                ftpWebRequest.Proxy = null;
                webResponse = ftpWebRequest.GetResponse();
                reader = new StreamReader(webResponse.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (line == target)
                    {
                        success = true;
                        break;
                    }
                    line = reader.ReadLine();
                }
            }
            catch (Exception)
            {
                success = false;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (webResponse != null)
                {
                    webResponse.Close();
                }
            }
            return success;
        }
    }
}
