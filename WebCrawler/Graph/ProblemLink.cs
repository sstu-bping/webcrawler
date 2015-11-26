using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrawler.Graph
{
    /// <summary>
    /// Ссылка на проблемную страницу
    /// </summary>
    class ProblemLink : Link
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="link">URL ссылки</param>
        public ProblemLink(String link) : base(link) {}
    }
}
