using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using WebCrawler.Graph;
using WebCrawler.Downloader;
using Parser;

namespace WebCrawler
{
    class Program
    {
        public static void Main(string[] args)
        {
            LinkStorage storage = new LinkStorage();
            storage.GetInitialLink();
            GraphMaker maker = new GraphMaker();
            Node node = null;
            while (storage.IsNeedVisit())
            {
                node = storage.Visit();
                maker.Make(node);
            }

           
        }
    }
}
