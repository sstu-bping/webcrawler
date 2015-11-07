using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrawler.Graph
{
    class GraphMaker
    {
        Graph graph;

        public GraphMaker()
        {
            graph = new Graph();
        }

        public Graph Graph
        {
            get
            {
                return graph;
            }
        }

        public void Make(Link link, List<Link> list)
        {
            Node node = new Node(link, list);
            graph.AddNode(node);
        }
    }
}
