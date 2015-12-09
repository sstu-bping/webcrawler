using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrawler.Graph;
using WebCrawler.Analizer;

namespace WebCrawler
{
    /// <summary>
    /// Программа
    /// </summary>
    class Program
    {
        /// <summary>
        /// Первая ссылка сайта
        /// </summary>
        private static Link initialLink;

        /// <summary>
        /// Хранилище ссылок
        /// </summary>
        private static LinkStorage storage;

        /// <summary>
        /// Содержит и строит граф
        /// </summary>
        private static GraphMaker maker = new GraphMaker();

        /// <summary>
        /// Контейнер для посещаемой
        /// в данный момент ссылки
        /// </summary>
        private static Link link = new Link("");

        /// <summary>
        /// Контейнер для результата парсинга
        /// посещаемой в данный момент ссылки
        /// </summary>
        private static List<Link> parseResult = new List<Link>();

        /// <summary>
        /// Ввод с клавиатуры
        /// первой ссылки сайта
        /// </summary>
        /// <returns>Первую ссылку сайта</returns>
        public static Link GetInitialLink()
        {
            Console.WriteLine("Enter url:");
            String line = Console.ReadLine();
            Link link = new Link(line);
            return link;
        }

        /// <summary>
        /// Точка входа в программу
        /// из операционной системы
        /// </summary>
        /// <param name="args">Аргументы,
        /// передаваемые операционной системой</param>
        public static void Main(string[] args)
        {
            initialLink = GetInitialLink();
            storage = new LinkStorage(initialLink);
            parseResult = storage.Visit(out link);
            if (link.type == LinkType.problem)
            {
                Console.WriteLine("По запрашиваемому URL ничего не найдено");
                return;
            }
            if (parseResult.Count == 0)
            {
                Console.WriteLine("Запрашиваемый URL - единственная страница сайта");
                return;
            }
            maker.Make(link, parseResult);
            while (storage.IsNeedVisit())
            {
                parseResult = storage.Visit(out link);
                if (link.type == LinkType.normal)
                {
                    maker.Make(link, parseResult);
                }
            }

            Analizer.Analizer analizer = new Analizer.Analizer(maker.Graph);
            Node []arr = maker.Graph.ListOfNodes.ToArray();

            Console.WriteLine(maker.Graph.ToString());
            Console.ReadKey();
        }
    }
}