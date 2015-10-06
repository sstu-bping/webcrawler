using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WebCrawler.Downloader;
using WebCrawler.Parser;

namespace WebCrawler
{
    class Program
    {        
        public static void Main(string[] args)
        {
            IDownloader downloader = new FictiveDownloader();
            String path = "";
            IParser parser = new FictiveParser();
            List<String> urls = new List<String>(), showedUrls = new List<String>(), result = null;
            Console.WriteLine("Enter url:");
            urls.Add(Console.ReadLine());
            String url = "";
            while (urls.Count != 0)
            {
                url = urls[0];

                if (showedUrls.Find(x => x.Equals(url)) == null)
                {
                    downloader.Load(url, path);
                    result = parser.Parse(path);
                    showedUrls.Add(url);
                }
                else
                {
                    result = null;
                }

                if (result != null)
                {
                    foreach (String element in result) urls.Add(element);
                }
                urls.RemoveAll(x => x.Equals(url));
            }
        }
    }
}