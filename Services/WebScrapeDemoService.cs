using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using HtmlAgilityPack;

namespace AngularJSDemo.Services
{
    public class WebScrapeDemoService
    {
        public string TestScrape()
        {
            string headlines = "";
            HtmlDocument doc = new HtmlDocument();

            doc.OptionFixNestedTags = true;
            string url = "http://techcrunch.com/apps/";
            HttpWebRequest req = HttpWebRequest.Create(url) as HttpWebRequest;
            req.Method = "GET";
            /*Start browswer signature*/
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:31.0) Gecko/20100101 Firefox/31.0";
            req.Accept = "text/html,application/xhtml+xml, application/xml;q=0.9,*/*;q=0.8";
            req.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-us,en;q=05");

            //START BROWSER SIG
            WebResponse response = req.GetResponse();
            doc.Load(response.GetResponseStream(), true);
            if (doc.DocumentNode != null)
            {
                var articleNodes = doc.DocumentNode.SelectNodes("/html/body/div/div/div/div/div/div");

                if (articleNodes != null && articleNodes.Any())
                {
                    foreach (var articleNode in articleNodes)
                    {
                        var titleNode = articleNode.SelectSingleNode("header/h2/a");
                        headlines += "<li>" + WebUtility.HtmlDecode(titleNode.InnerText.Trim()) + "</li>";
                    }
                }
            }
            return headlines;
        }
    }
}