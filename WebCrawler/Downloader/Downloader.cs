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
        /// loading HTML code of page.
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
            HttpWebRequest request;
            HttpWebResponse response;
            try
            {
                  request = WebRequest.Create(url) as HttpWebRequest;
                  response = request.GetResponse() as HttpWebResponse;
            } catch (System.Net.WebException e)
            {
                return "404: " + url;
            }

            string html = "";
            using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                html = sr.ReadToEnd();
            };
            return html;
        }
    }
}
