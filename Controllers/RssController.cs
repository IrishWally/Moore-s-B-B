using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace WebCloudCA.Controllers
{
    public class RssController : Controller
    {
        // GET: Rss
        public ActionResult Index()
        {
            string url = "https://www.localenterprise.ie/galway/rss.aspx?GroupId=4437&rssVersion=Rss20";

            //creates an instance of XmlDocument
            XmlDocument xdoc = new XmlDocument();

            //loads xml to xdoc
            xdoc.Load(url);

            //DocumentElement provides you with root which is rss
            XmlNode root = xdoc.DocumentElement;

            //channel is the first element of root
            XmlNode channel = root.FirstChild;

            //assigning child nodes of channel to list which is of type XmlNodeList
            XmlNodeList list = channel.ChildNodes;

            //creting ViewData["title"] to pass on the title of channel to View
            ViewData["title"] = channel.FirstChild.InnerText;

            //creating ViewData["list"] to pass on to View
            ViewData["list"] = list;
            return View();
        }
    }
}