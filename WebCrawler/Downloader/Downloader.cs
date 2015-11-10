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
        /// <summary>
        /// loading HTML code of page
        /// </summary>
        /// <param name="url">URL address of loaded page</param>
        /// <returns>String with HTML code of page</returns>
        public String Load(string url)
        {
            return getHTML(url);
        }

        protected string getHTML(string url)
        {
            //TODO: 404 error exception
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string html = "";
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                html = sr.ReadToEnd();
            };
            return html;
        }
    }
}
