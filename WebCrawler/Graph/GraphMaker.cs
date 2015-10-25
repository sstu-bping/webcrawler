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

        public Graph Graf
        {
            get
            {
                return graph;
            }
        }

        public void Make(Node node)
        {
            graph.AddNode(node);
        }
    }
}
