using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace WebCrawler.Downloader
{
    class Downloader : IDownloader
    {
        public String Load(string url)
        {
            return getHTML(url);
        }

        protected string getHTML(string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string html = sr.ReadToEnd();
            return html;
        }

    }
}
