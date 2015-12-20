using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrawler.Downloader;
using WebCrawler.Graph;
using WebCrawler.Parser;

namespace WebCrawler
{
    /// <summary>
    /// Хранит информацию о ссылках,
    /// которые необходимо посетить
    /// и об уже посещенных ссылках
    /// а также посещает ссылки
    /// </summary>
    class LinkStorage
    {
        /// <summary>
        /// Ссылки, которые надо посетить
        /// </summary>
        private List<Link> links;

        /// <summary>
        /// Уже посещенные ссылки
        /// </summary>
        private List<Link> visitedLinks;

        /// <summary>
        /// Загружает страницы по ссылкам
        /// </summary>
        private IDownloader downloader;

        /// <summary>
        /// Ищет ссылки на загруженных страницах
        /// </summary>
        private IParser parser;

        /// <summary>
        /// Первая ссылка сайта
        /// </summary>
        private Link initialLink;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="initialLink">Первая ссылка сайта</param>
        public LinkStorage(Link initialLink)
        {
            links = new List<Link>();
            this.initialLink = initialLink;
            links.Add(initialLink);
            visitedLinks = new List<Link>();
            downloader = new Downloader.Downloader();
            parser = new Parser.Parser();
        }

        /// <summary>
        /// Проверяет, посещена ли ссылка
        /// </summary>
        /// <param name="link">Проверяемая ссылка</param>
        /// <returns>true, если ссылка посещена;
        /// false, если ссылка не посещена</returns>
        private bool IsVisited(Link link)
        {
            bool isVisited = (visitedLinks.Find(x => x.Equals(link)) != null);
            return isVisited;
        }

        /// <summary>
        /// Удаляет из links посещенные ссылки
        /// </summary>
        private void RemoveVisitedLinks()
        {
            int linkLimit = 10;
            if (links.Count >= linkLimit)
            {
                foreach (Link element in visitedLinks)
                {
                    Remove(element);
                }
            }
        }

        /// <summary>
        /// Удаляет ссылку из links
        /// </summary>
        /// <param name="link">Удаляемая ссылка</param>
        private void Remove(Link link)
        {
            links.RemoveAll(x => x.Equals(link));
        }

        /// <summary>
        /// Проверяет, нужно ли вызывать метод Visit()
        /// </summary>
        /// <returns>true, если нужно;
        /// false, если не нужно</returns>
        public bool IsNeedVisit()
        {
            if (links.Count == 0) return false;
            return true;
        }

        /// <summary>
        /// Посещает ссылки
        /// </summary>
        /// <param name="link"></param>
        /// <returns>Коллекцию ссылок, с которой связана ссылка</returns>
        public List<Link> Visit(out Link link)
        {
            link = links[0];
            String site = "";
            List<Link> list = new List<Link>();
            if (!IsVisited(link))
            {
                try
                {
                    site = downloader.Load(link.Url);
                    list = parser.Parse(site, initialLink);
                }
                catch(Exception exc)
                {
                    link.Type = LinkType.Problem;
                    list = new List<Link>();
                }
                if (list.Count != 0)
                {
                    links.AddRange(list);
                }
                visitedLinks.Add(links[0]);
            }
            else
            {
                link.Type = LinkType.Visited;
            }
            Remove(links[0]);
            RemoveVisitedLinks();
            return list;
        }
    }
}