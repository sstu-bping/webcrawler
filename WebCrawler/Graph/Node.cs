using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrawler.Graph
{
    class Node
    {
        private Link associatedLink;
        private List<Link> listSm;

        public Node(Link link, List<Link> list)
        {
            associatedLink = link;
            listSm = list;
        }

        public Link AssociatedLink
        {
            get
            {
                return associatedLink;
            }
        }

        public List<Link> ListSm
        {
            get
            {
                return listSm;
            }
        }
    }
}
