using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrawler.Graph;

namespace WebCrawler.Parser
{
    interface IParser
    {
        List<Link> Parse(String site);
    }
}
