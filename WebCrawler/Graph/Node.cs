using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrawler.Graph
{
    /// <summary>
    /// Вершина графа
    /// </summary>
    class Node
    {
        /// <summary>
        /// Ссылка вершины графа
        /// </summary>
        private Link associatedLink;

        /// <summary>
        /// Список смежности вершины графа
        /// </summary>
        private List<Link> listSm;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="link">Ссылка вершины графа</param>
        /// <param name="list">Список смежности вершины графа</param>
        public Node(Link link, List<Link> list)
        {
            associatedLink = link;
            listSm = list;
        }

        /// <summary>
        /// Возвращает ссылку вершины графа
        /// </summary>
        public Link AssociatedLink
        {
            get
            {
                return associatedLink;
            }
        }

        /// <summary>
        /// Возвращает список смежности вершины графа
        /// </summary>
        public List<Link> ListSm
        {
            get
            {
                return listSm;
            }
        }

        /// <summary>
        /// Преобразовывает вершину графа в строку
        /// </summary>
        /// <returns>Вершина графа в виде строки</returns>
        public override string ToString()
        {
            String result = "Node: " + associatedLink.Url + "\nListSm:\n";
            foreach (Link element in listSm)
            {
                result += element.Url + "\n";
            }
            result += "End of ListSm\n";
            return result;
        }
    }
}
