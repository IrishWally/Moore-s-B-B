using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCloudCA.Models;
using System.Xaml;
using System.Windows.Documents;
using System.Web.UI.WebControls;
namespace WebCloudCA.Controllers
{
    public class BookingController : Controller
    {
        DAO dao = new DAO();

        //list to store our bookings
        public static List<Booking> bookinglist = new List<Booking>();
        public static List<decimal> pricelist = new List<decimal>();
        public static List<SelectListItem> roomlist = new List<SelectListItem>();


        // GET: Booking
        public ActionResult BookARoom()
        {
            ViewData["roomtype"] = GetRoomNamesList();
            return View();
        }

        private List<string> GetRoomNamesList()
        {
       
            List<string> rooms = dao.PopulateRooms();
            return rooms;
        }


        // GET: Booking
        //public ActionResult BookARoom()
        //{
        //    List<int> roomlist = new List<int> {1,2,3,4, };
        //    //List<string> listrooms = new List<string> { "The Moher Suite", "The Connacht Suite","The Wild Atlantic Way Suite","The West Suite" };
        //    ViewData["key"] = roomlist;
        //    return View();
        //}
        
        public ActionResult Save(Booking booking)
        {
           int count = 0;
            int emailcount = 0;
            //if email exists do this, else take me to registration
            emailcount = dao.CheckCustomer(booking.Email);
            if (emailcount > 1)
            {

                if (ModelState.IsValid)
                {
                    bookinglist.Add(booking);

                    dao.InsertCustomer(booking);
                    int id = dao.GetLastCustomer();
                    count = dao.InsertBooking(booking, id);

                    if (count == 1 && id > 0)
                    {
                        TempData["Message"] = "Booking Confirmed";
                        TempData["Price"] = booking.Price;
                        pricelist.Add(booking.Price);
                        return RedirectToAction("Payment", "Payment", TempData["Price"]); //,new {sendamount = amount }

                    }

                    else
                    {
                        ViewData["Message"] = dao.message;
                        return View("BookARoom");
                    }

                    //return to payment
                    //return View("BookARoom");

                }
                else
                {
                    return View("Index", "LoginRegister");
                }
            }
            
            else ViewData["Message"] = dao.message;
            return View("BookARoom", booking);
        }

        public ActionResult ShowBookings()
        {
          //  List<Booking> finalbooklist = new List<Booking>();
            List<Booking> bookinglist = dao.ShowAllBookings();
           // foreach(Booking b in bookinglist)
           // {
          //      finalbooklist.Add(b);
         //   }
            TempData["count"] = bookinglist.Count;
            ViewData["Message"] = dao.message;
            return View(bookinglist);
        }

        public ActionResult Reviews()
        {
            return View();
        }
        public ActionResult AddReview()
        {
            return View();
        }
    }
}