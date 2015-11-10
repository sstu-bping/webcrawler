using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrawler.Graph;

namespace WebCrawler.Parser
{
    class Parser : IParser
    {
        const string tagStart = "<a";
        const string tagTwoStart = "href=\"";
        const string tagEnd = "\"";
        const string HTTP = "http";


        /// <summary>
        /// method parse HTML code and extract internal links(only links from current domain)
        /// </summary>
        /// <param name="html">HTML code of page for parsing</param>
        /// <param name="initialLink">initial link. current domain with protocol. example - "http://habrahabr.ru/"</param>
        /// <returns>List of links found on the page</returns>
        public List<Link> Parse(string html, Link initialLink)
        {
            //TODO: fix
            html += "<a href=\"/HelloWorldParserAndDownloader\">";

            TextSearcher ts = new TextSearcher(html);

            //defining queue
            List<Link> links = new List<Link>();

            string str = null;
            bool cycle = true;

            while (cycle)
            {

                ts.Skip(tagStart);
                ts.Skip(tagTwoStart);
                str = ts.ReadTo(tagEnd);

                if (str.Equals("/HelloWorldParserAndDownloader"))
                {
                    cycle = false;
                    continue;
                }    

                if (IsInternalLinkl(str))
                {
                    string url = initialLink.Url + str;
                    links.Add(new Link(url));
                }
            }
            return links;
        }

        /// <summary>
        /// check URL for "http" substring
        /// </summary>
        /// <param name="str">checked URL</param>
        /// <returns>true if URL contains "http"</returns>
        private bool IsInternalLinkl(string str)
        {
            if (((str.Length >= HTTP.Length) && ((str.Substring(0, HTTP.Length).CompareTo(HTTP)) != 0)) || ((str.Length > 0) && (str.Length < HTTP.Length)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
