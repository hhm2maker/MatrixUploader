using System;
using System.Net;
using System.Text;

namespace MatrixUploader
{
    public class MatrixUploader : Blog.IToBlog
    {
        private String filePath;
        public void ToBlog(string parameters)
        {
            string url = parameters;

            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;

            //这里使用DownloadString方法，如果是不需要对文件的文本内容做处理，直接保存，那么可以直接使用功能DownloadFile(url,savepath)直接进行文件保存。
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;

            filePath = AppDomain.CurrentDomain.BaseDirectory + @"Download\" + parameters.Substring(url.LastIndexOf("/") + 1);

            webClient.DownloadFileAsync(new Uri(url), filePath);
        }

        private void WebClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\Blog\DLL\matrix uploader\Matrix Firmware Uploader.bat", "\"" + filePath + "\"");
        }
    }
}
