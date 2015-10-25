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

        string tagStart;
        string tagTwoStart;
        string tagEnd;

        public string TagStart
        {
            get { return tagStart; }

            set
            {
                tagStart = value;
            }
        }

        public string TagTwoStart
        {
            get { return tagTwoStart; }

            set
            {
                tagTwoStart = value;
            }
        }

        public string TagEnd
        {
            get { return tagEnd; }

            set
            {
                tagEnd = value;
            }
        }

        private List<Link> loadLink(string html)
        {          

            html += "<a href=\"/HelloWorldParserAndDownloader\">";                   

            TextSearcher ts = new TextSearcher(html); 

            //Объявляем очередь
            List<Link> links = new List<Link>();

            string str = null;
            bool cycle = true;           

            while(cycle){
                
                ts.Skip(tagStart);
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

        public List<Link> Parse(string text)
        {
            return loadLink(text);
        }

       
    }
}
