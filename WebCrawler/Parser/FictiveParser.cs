using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrawler.Parser
{
    class FictiveParser : IParser
    {
        public List<String> Parse(String site)
        {
            List<String> result = new List<String>();
            result.Add("www.w3c.org");
            result.Add("www.ru.wikipedia.org");
            return result;
        }
    }
}
