using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using WebCrawler.Graph;
using WebCrawler.Downloader;

namespace Parser
{
    class FictiveParser : IParser
    {        

        string tagStart = "<a";
        string tagTwoStart = "href=\"";
        string tagEnd = "\"";

      

        public List<Link> Parse(string html)
        {
            //don't mind please
            html += "<a href=\"/HelloWorldParserAndDownloader\">";

            TextSearcher ts = new TextSearcher(html);

            //Объявляем очередь
            List<Link> links = new List<Link>();

            string str = null;
            bool cycle = true;

            while (cycle)
            {

                ts.Skip(tagStart);
                Console.WriteLine("debug. first skip");
                ts.Skip(tagTwoStart);
                str = ts.ReadTo(tagEnd);

                if (str.Equals("/HelloWorldParserAndDownloader"))
                {
                    cycle = false;
                    continue;
                }

                if (str.Length != 0)
                {
                    //Проверка на исходящие внешние ссылки
                    if ((str.Length >= 4) && ((str.Substring(0, 4).CompareTo("http")) != 0))
                    {
                        links.Add(new Link(str));

                    }
                    else
                        if ((str.Length >= 0) && (str.Length <= 3))
                    {
                        links.Add(new Link(str));

                    }
                }

            }

            return links;
        }

       
    }
}
