using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebCrawler.Downloader
{
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
}
