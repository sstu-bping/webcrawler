using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrawler.DownloaderAndParser;
using WebCrawler.Graph;

namespace WebCrawler
{
    class LinkStorage
    {
        private List<Link> links, visitedLinks;
        private IDownloaderAndParser downloader;

        public LinkStorage()
        {
            links = new List<Link>();
            visitedLinks = new List<Link>();
            downloader = new FictiveDownloaderAndParser();
        }

        public void Add(Link link)
        {
            links.Add(link);
        }

        public bool IsNeedVisit()
        {
            if (links.Count == 0) return false;
            return true;
        }

        public Node Visit()
        {
            Link link = links[0];
            Node result = null;
            if (visitedLinks.Find(x => x.Equals(link)) == null)
            {
                result = downloader.LoadAndParse(link);
                visitedLinks.Add(link);
            }
            if (result != null)
            {
                List<Link> temp = result.ListSm;
                foreach (Link element in temp) links.Add(element);
            }
            links.RemoveAll(x => x.Equals(link));
            return result;
        }
    }
}
