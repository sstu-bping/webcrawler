using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrawler.Graph
{
    class Node
    {
        private Link node;
        private List<Link> listSm;

        public Node(Link link, List<Link> list)
        {
            node = link;
            listSm = list;
        }

        public Link NODE
        {
            get
            {
                return node;
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
