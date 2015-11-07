using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrawler.Downloader;
using WebCrawler.Graph;
using WebCrawler.Parser;

namespace WebCrawler
{
    class LinkStorage
    {
        private List<Link> links, visitedLinks;
        private IDownloader downloader;
        private IParser parser;

        public LinkStorage(Link initialLink)
        {
            links = new List<Link>();
            links.Add(initialLink);
            visitedLinks = new List<Link>();
            downloader = new FictiveDownloader();
            parser = new FictiveParser();
        }

        private bool IsVisited(Link link)
        {
            bool isVisited = (visitedLinks.Find(x => x.Equals(link)) != null);
            return isVisited;
        }

        private void RemoveVisitedLinks()
        {
            if (links.Count >= 10)
            {
                foreach (Link element in visitedLinks)
                {
                    Remove(element);
                }
            }
        }

        private void Remove(Link link)
        {
            links.RemoveAll(x => x.Equals(link));
        }

        public bool IsNeedVisit()
        {
            if (links.Count == 0) return false;
            return true;
        }

        public List<Link> Visit(out Link link)
        {
            link = links[0];
            String site = "";
            List<Link> list = new List<Link>();
            if (!IsVisited(link))
            {
                site = downloader.Load(link.URL);
                list = parser.Parse(site);
                if (list.Count != 0)
                {
                    links.AddRange(list);
                }
                visitedLinks.Add(link);
            }
            Remove(link);
            RemoveVisitedLinks();
            return list;
        }
    }
}