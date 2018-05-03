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
    public class PaymentController : Controller
    {
        public static List<Payment> paymentlist = new List<Models.Payment>();
        DAO dao = new DAO();
        // GET: Payment
        public ActionResult Payment()
        {
            //moher west connacht
          //  if(booking.RoomType == "")
            //ViewData["amount"] = dao.GetPrice();
            ViewData["price"]=@TempData["Price"];

            return View();
        }

        //make a payment action result
        public ActionResult MakePayment(Payment payment)
        {
            TempData["Price"] = payment.Amount;
            //do regex testing
            if (ModelState.IsValid && ValidateNum(payment.CardNumber.ToString()) == true)
            {
                
                //declare counts
                int count = 0;
                int countupdatebooking = 0;
                //getbooking id
                int id = dao.GetLastBookingId();
                //insertinto payment
                count = dao.InsertIntoPayment(payment, id);

                countupdatebooking = dao.UpdatePayment();
                if (count == 1 && countupdatebooking == 1 && id > 0)
                {
                    TempData["SuccessMessage"] = "Successful Payment";
                    
                    return RedirectToAction("Index", "Home", TempData["SuccessMessage"]);

                }
                else
                {
                    ViewData["price"] = payment.Amount;
                    ViewData["Message"] = dao.message + "Unsuccessful Payment";
                    return View("Payment",payment.Amount=(decimal)ViewData["price"]);
                }
               


            }

            else
             ViewData["message"] = "Form value error or Card Validation error";
            TempData["Price"] = payment.Amount;
            return View("Payment",payment);
        }

        public ActionResult ShowAllPayments()
        {
            paymentlist = dao.ShowAllPayments();

            return View(paymentlist);
        }


        // //htts://www.youtube.com/watch?v=lkq3ywfCQcI

        private static int[] _cleanInput;

        private static void CleanUpInput(string input) => _cleanInput = input.Where(_ => !char.Equals(_, ' ') && char.IsDigit(_)).Reverse()
        .Select(_ => int.Parse(_.ToString())).ToArray();

        private static void MultiplyValues()
        {
            for (int index = 0; index < _cleanInput.Length; index++)
            {
                if (index % 2 != 0)
                {
                    _cleanInput[index] *= 2;
                }

            }
        }
        

    private static int AddValues()
        {
            var sum = default(int);
            for (int index = 0; index < _cleanInput.Length; index++)
            {
                if (_cleanInput[index] > 9)
                {
                    foreach(var character in _cleanInput[index].ToString())
                    {
                        sum += int.Parse(character.ToString());
                    }
                    continue;
                }
                sum += _cleanInput[index];
            }
            return sum;
        }

        public static bool ValidateNum(string cardinput)
        {
            CleanUpInput(cardinput);
            MultiplyValues();
            return AddValues() % 10 == 0;
        }



}
    }

    

 //foreach (var character in _cleanInput)
 //                   {
 //                       sum += int.Parse(character.ToString());
 //                   }