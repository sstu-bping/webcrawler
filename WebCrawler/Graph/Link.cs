using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrawler.Graph
{
    class Link
    {
        private String name;

        public Link(String link)
        {
            name = link;
        }

        public String Name
        {
            get
            {
                return name;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Link)
            {
                Link link = (Link)obj;
                if (link.name.Equals(this.name)) return true;
            }
            return false;
        }
    }
}
