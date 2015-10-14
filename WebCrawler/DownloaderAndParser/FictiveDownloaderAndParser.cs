using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrawler.Graph;

namespace WebCrawler.DownloaderAndParser
{
    class FictiveDownloaderAndParser : IDownloaderAndParser
    {
        public Node LoadAndParse(Link link)
        {
            List<Link> list = new List<Link>();
            list.Add(new Link("www.w3c.org"));
            list.Add(new Link("www.ru.wikipedia.org"));
            Node result = new Node(link, list);
            return result;
        }
    }
}
