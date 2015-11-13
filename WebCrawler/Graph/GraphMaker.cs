using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrawler.Graph
{
    /// <summary>
    /// Содержит внутри себя граф,
    /// в который добавляет вершины
    /// </summary>
    class GraphMaker
    {
        /// <summary>
        /// Граф
        /// </summary>
        Graph graph;

        /// <summary>
        /// Конструктор
        /// </summary>
        public GraphMaker()
        {
            graph = new Graph();
        }

        /// <summary>
        /// Возвращает граф
        /// </summary>
        public Graph Graph
        {
            get
            {
                return graph;
            }
        }

        /// <summary>
        /// Добавляет вершину в граф
        /// </summary>
        /// <param name="link">Название вершины графа</param>
        /// <param name="list">Список смежности вершины графа</param>
        public void Make(Link link, List<Link> list)
        {
            Node node = new Node(link, list);
            graph.AddNode(node);
        }
    }
}
