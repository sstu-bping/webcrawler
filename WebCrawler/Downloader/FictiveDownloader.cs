using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebCrawler.Downloader
{
    class FictiveDownloader : IDownloader
    {
        public String Load(String url)
        {
            StringBuilder result = new StringBuilder("<html>\n");
            result.Append("<head>\n");
            result.Append("<title>Title</title>\n");
            result.Append("</head>\n");
            result.Append("<body>\n");
            result.Append("<p>jknhklnmkln</p>\n");
            result.Append("<a href=\"www.w3c.org\">w3c</a>\n");
            result.Append("<p>jknhklnmkln</p>\n");
            result.Append("<a href=\"www.ru.wikipedia.org\">Wikipedia</a>\n");
            result.Append("</body>\n");
            result.Append("</html>");
            return result.ToString();
        }
    }
}
