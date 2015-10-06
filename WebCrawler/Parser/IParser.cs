using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrawler.Parser
{
    interface IParser
    {
        List<String> Parse(String path);
    }
}
