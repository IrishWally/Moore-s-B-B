using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCloudCA.Models;

namespace WebCloudCA.Controllers
{
    public class ContactController : Controller
    {
        public static List<Contact> contactedList= new List<Contact>();

        // GET: Contact
        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult SaveContact(Contact contact)
        {

            if (ModelState.IsValid)
            {
                contactedList.Add(contact);
                ViewData["Message"] = "Query Sent, we will get back to you as soon as possible";
                //return to Home page
                return View("../Home/Index");
            }
            else return View("ContactUs", contact);

        }
        public ActionResult ShowContactUs()
        {
            return View(contactedList);
        }

    }
}