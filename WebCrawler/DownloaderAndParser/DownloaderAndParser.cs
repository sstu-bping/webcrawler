using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using WebCrawler.Graph;

namespace WebCrawler.DownloaderAndParser
{
    class DownloaderAndParser : IDownloaderAndParser
    {
        public Node LoadAndParse(Link link)
        {
            HttpWebRequest request = WebRequest.Create(link.Name) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string site = sr.ReadToEnd();
            List<Link> list = new List<Link>();
            //some parser code...
            Node result = new Node(link, list);
            return result;

        }
    }
