using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrawler.Graph
{
    class Graph
    {
        private List<Node> graph;

        public Graph()
        {
            graph = new List<Node>();
        }

        public List<Node> Graf
        {
            get
            {
                return graph;
            }
        }

        public void AddNode(Node node)
        {
            graph.Add(node);
        }
    }
}
