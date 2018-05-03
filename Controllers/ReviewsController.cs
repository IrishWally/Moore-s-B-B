using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCloudCA.Models;

namespace WebCloudCA.Controllers
{
    public class ReviewsController : Controller
    {

        public static List<Review> ReviewsList = new List<Review>();

        // GET: Reviews
        public ActionResult Review()
        {
            return View();
        }
        public ActionResult SaveReview(Review review)
        {
            if (ModelState.IsValid)
                ReviewsList.Add(review);
            ViewData["Message"] = "Thank you for your Review! I hope you had a great time with us!";
            return View("../MeetYourHost/Review");
        }
    }
}