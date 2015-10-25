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
            //LinkStorage storage = new LinkStorage();
            //storage.GetInitialLink();
            //GraphMaker maker = new GraphMaker();
            //Node node = null;
            //while (storage.IsNeedVisit())
            //{
            //    node = storage.Visit();
            //    maker.Make(node);
            //}


            FictiveParser parser = new FictiveParser();
            parser.TagStart = "<a";
            parser.TagTwoStart = "href=\"";
            parser.TagEnd = "\"";

            const string FileName = "File.html";

            //Объявляем очередь5
            List<Link> links = new List<Link>();

            links = parser.Parse(FileName);

            Console.ReadLine();
           
        }
    }
}