using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WebCrawler
{
    interface IDownloader
    {
        void Load(String url, String path);
    }

    class FictiveDownloader : IDownloader
    {
        public void Load(String url, String path)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine("<html>");
            sw.WriteLine("<head>");
            sw.WriteLine("<title>Title</title>");
            sw.WriteLine("</head>");
            sw.WriteLine("<body>");
            sw.WriteLine("<p>jknhklnmkln</p>");
            sw.WriteLine("<a href=\"www.w3c.org\">w3c</a>");
            sw.WriteLine("<p>jknhklnmkln</p>");
            sw.WriteLine("<a href=\"www.ru.wikipedia.org\">Wikipedia</a>");
            sw.WriteLine("</body>");
            sw.WriteLine("</html>");
            sw.Close();
        }
    }

    interface IParser
    {
        List<String> Parse(String path);
    }

    class FictiveParser : IParser
    {
        public List<String> Parse(String path)
        {
            List<String> result = new List<String>();
            result.Add("www.w3c.org");
            result.Add("www.ru.wikipedia.org");
            return result;
        }
    }
    
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