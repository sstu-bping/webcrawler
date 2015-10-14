using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WebCrawler.DownloaderAndParser;
using WebCrawler.Graph;

namespace WebCrawler
{
    class Program
    {        
        public static void Main(string[] args)
        {
            LinkStorage storage = new LinkStorage();
            Console.WriteLine("Enter url:");
            Link link = new Link(Console.ReadLine());
            storage.Add(link);
            Node node = null;
            while (storage.IsNeedVisit())
            {
                node = storage.Visit();
            }
        }
    }
}