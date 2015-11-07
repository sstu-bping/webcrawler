using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrawler.Graph
{
    class Graph
    {
        private List<Node> listOfNodes;

        public Graph()
        {
            listOfNodes = new List<Node>();
        }

        public List<Node> ListOfNodes
        {
            get
            {
                return listOfNodes;
            }
        }

        public void AddNode(Node node)
        {
            listOfNodes.Add(node);
        }
    }
}
