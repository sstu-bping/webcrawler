using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrawler.Downloader
{
    interface IDownloader
    {
        String Load(String url);
    }
}