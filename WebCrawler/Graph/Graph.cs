using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrawler.Graph
{
    /// <summary>
    /// Граф
    /// </summary>
    class Graph
    {
        /// <summary>
        /// Список вершин графа
        /// </summary>
        private List<Node> listOfNodes;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Graph()
        {
            listOfNodes = new List<Node>();
        }

        /// <summary>
        /// Возвращает список вершин графа
        /// </summary>
        public List<Node> ListOfNodes
        {
            get
            {
                return listOfNodes;
            }
        }

        /// <summary>
        /// Добавляет вершину в граф
        /// </summary>
        /// <param name="node">Добавляемая вершина</param>
        public void AddNode(Node node)
        {
            listOfNodes.Add(node);
        }

        /// <summary>
        /// Преобразовывает граф в строку
        /// </summary>
        /// <returns>Граф в виде строки</returns>
        public override string ToString()
        {
            String result = "Graph:\n";
            foreach (Node element in listOfNodes)
            {
                result += element.ToString();
            }
            return result;
        }
    }
}
