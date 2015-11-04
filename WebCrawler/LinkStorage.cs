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

        public LinkStorage()
        {
            links = new List<Link>();
            visitedLinks = new List<Link>();
            downloader = new FictiveDownloader();
            parser = new FictiveParser();
        }

        public void GetInitialLink()
        {
            Console.WriteLine("Enter url:");
            Link link = new Link(Console.ReadLine());
            links.Add(link);
        }

        private bool IsVisited(Link link)
        {
            if (visitedLinks.Find(x => x.Equals(link)) == null) return false;
            return true;
        }

        private void RemoveVisitedLinks()
        {
            if (links.Count >= 10) foreach (Link element in visitedLinks) Remove(element);
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

        public Node Visit()
        {
            Link link = links[0];
            String site = "";
            List<Link> list = new List<Link>();
            if (!IsVisited(link))
            {
                site = downloader.Load(link.Name);
                list = parser.Parse(site);
                if (list.Count != 0) links.AddRange(list);
                visitedLinks.Add(link);
            }
            Remove(link);
            RemoveVisitedLinks();
            Node result = new Node(link, list);
            return result;
        }
    }
}