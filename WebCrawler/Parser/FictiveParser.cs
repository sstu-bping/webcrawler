using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrawler.Graph;

namespace WebCrawler.Parser
{
    class FictiveParser : IParser
    {
        public List<Link> Parse(String site, Link initialLink)
        {
            List<Link> result = new List<Link>();
            result.Add(new Link("www.w3c.org"));
            result.Add(new Link("www.ru.wikipedia.org"));
            return result;
        }
    }
}
