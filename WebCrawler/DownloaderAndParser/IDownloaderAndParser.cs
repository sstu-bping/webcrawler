using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrawler.Graph;

namespace WebCrawler.DownloaderAndParser
{
    interface IDownloaderAndParser
    {
        Node LoadAndParse(Link link);
    }
}
