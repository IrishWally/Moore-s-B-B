using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCloudCA.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //if(TempData["SuccessMessage"].ToString() == "Successful Payment")
           // {
                //Successful payment message box,  enjoy your stay

            //}
            return View();
        }

        //Controller for the Reviews Page
        public ActionResult Reviews()
        {
            return View();
        }

        //controller for the MeetYourHost page
        public ActionResult MeetYourHost()
        {
            return View();
        }

        public ActionResult Suites()
        {
            return View();
        }

        public ActionResult BookARoom()
        {
            return View();
        }

        public ActionResult PlanYourStay()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }
        public ActionResult FAQ()
        {
            return View();
        }
        public ActionResult Sitemap()
        {
            return View();
        }
    }
}