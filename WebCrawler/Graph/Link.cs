using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrawler.Graph
{
    /// <summary>
    /// Ссылка
    /// </summary>
    class Link
    {
        /// <summary>
        /// URL ссылки
        /// </summary>
        private String url;

        /// <summary>
        /// Тип ссылки
        /// </summary>
        public LinkType type = LinkType.normal;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="link">URL ссылки</param>
        public Link(String link)
        {
            url = link;
        }

        /// <summary>
        /// Возвращает URL ссылки
        /// </summary>
        public String Url
        {
            get
            {
                return url;
            }
        }

        /// <summary>
        /// Получает хэш-код ссылки
        /// </summary>
        /// <returns>Хэш-код ссылки</returns>
        public override int GetHashCode()
        {
           return base.GetHashCode();
        }

        /// <summary>
        /// Сравнивает ссылку с другим объектом по значению
        /// </summary>
        /// <param name="obj">Сравниваемый объект</param>
        /// <returns>true, если объект - ссылка, и URL обеих ссылок равны;
        /// false во всех остальных случаях</returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is Link)
            {
                Link link = (Link)obj;
                if (link.url.Equals(this.url)) return true;
            }
            return false;
        }
    }
}
