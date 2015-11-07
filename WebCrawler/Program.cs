using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrawler.Graph;

namespace WebCrawler
{
    class Program
    {
        public static Link GetInitialLink()
        {
            Console.WriteLine("Enter url:");
            String line = Console.ReadLine();
            Link link = new Link(line);
            return link;
        }

        public static void Main(string[] args)
        {
            Link initialLink = GetInitialLink();
            LinkStorage storage = new LinkStorage(initialLink);
            GraphMaker maker = new GraphMaker();
            Link link = new Link("");
            List<Link> parseResult = new List<Link>();
            while (storage.IsNeedVisit())
            {
                parseResult = storage.Visit(out link);
                if (parseResult.Count > 0)
                {
                    maker.Make(link, parseResult);
                }
            }
        }
    }
}