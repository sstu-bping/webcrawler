using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WebCrawler.Graph;

namespace WebCrawler.Analizer
{
    class Analizer
    {

        public Analizer(Graph.Graph graph)
        {
            this.graph = graph;
        }

        Graph.Graph graph;

        int STEPS = 3;


        /// <summary>
        /// checks possibility of reaching second node in STEPS steps
        /// </summary>
        /// <param name="firstNode">first node to check</param>
        /// <param name="secondNode">second node to check</param>
        /// <returns>true if second node is reachable; else returns false</returns>
        public bool IsReachable(Node firstNode, Node secondNode)
        {
            List<Node> nodesToCheck = new List<Node>();
            nodesToCheck.Add(firstNode);

            for(int i=0; i< STEPS; i++)
            {
                nodesToCheck = GetNextLevel(nodesToCheck);
                foreach (Node nodeToCheck in nodesToCheck)
                {
                        if (nodeToCheck!=null && nodeToCheck.Equals(secondNode))
                        {
                            return true;
                        }
                }
            }
            return false;
        }

        /// <summary>
        /// reterns all nodes from ListSm of current nodes
        /// </summary>
        /// <param name="currentNodes">current level nodes</param>
        /// <returns>nodes of next level</returns>
        private List<Node> GetNextLevel(List<Node> currentNodes)
        {
            List<Node> result = new List<Node>();
            foreach(Node node in currentNodes)
            {
                foreach (Link link in node.ListSm)
                    result.Add(ConvertLinkToNode(link));
            }
            return result;
        }

        /// <summary>
        /// Retern Node associated with Link or null in case of problem
        /// </summary>
        /// <param name="link">link to convert</param>
        private Node ConvertLinkToNode(Link link)
        {
            foreach(Node node in graph.ListOfNodes)
            {
                if (node.AssociatedLink.Equals(link))
                {
                    return node;
                }
            }
            return null;
        }

    }
}
