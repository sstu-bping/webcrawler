using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrawler.Graph
{
    class Link
    {
        private String url;

        public Link(String link)
        {
            url = link;
        }

        public String URL
        {
            get
            {
                return url;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is Link)
            {
                Link link = (Link)obj;
                if (link.url.Equals(this.url)) return true;
            }
            return false;
        }
    }
}
