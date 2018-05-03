using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using WebCloudCA.Models;

namespace WebCloudCA.Controllers
{
    public class RegisterLoginController : Controller
    {
        DAO dao = new DAO();
        public List<Customer> cuslist = new List<Customer>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(Customer customer)
        {
            int count;
            if (ModelState.IsValid)
            {
               
                string password = customer.Password;
                string match = customer.PasswordConfirmation;
                string hashed = Crypto.HashPassword(password);


                if (Crypto.VerifyHashedPassword(hashed, match))
                {
                    count = 0;
                
                   count = dao.InsertCustomerReg(customer);
                    if (count > 0)
                    {
                        ViewData["status"] = "Customer record is created successfully";
                    }
                    else
                    {
                        ViewData["status"] = "Error: " + dao.message;
                    }
                    return View("status");
                }
                else
                {
                    ViewData["status"] = "Passwords don't match";
                }





                //if (customer.Password != customer.PasswordConfirmation)
                //{
                //    ViewData["status"] = "Passwords don't match";

                //}

                //else
                //{
                //    count = dao.Insert(customer);
                //    if(count >0)
                //    {
                //        ViewData["status"] = "Customer record is created successfully";
                //    }
                //    else
                //    {
                //        ViewData["status"] = "Error: " + dao.message;
                //    }

                //}
                //return View("status");


            }

            return View("Index", customer);

        }
        public ActionResult ShowAllCustomers()
        {

            cuslist = dao.ShowAllCustomers();
            return View(cuslist);

        }

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Login(LoginModel model)
        {

            if (ModelState.IsValid)
            {

                if (model.UserRole == Role.Staff && model.Email == "staff@gmail.com" && model.Password == "dbsStaff")
                {
                    Session["Name"] = "Staff";
                    return RedirectToAction("Index", "Staff");
                }
                else if (model.UserRole == Role.Customer)
                {
                    Customer customer = new Customer();
                    customer.Email = model.Email;
                    customer.Password = model.Password;

                    string firstName = dao.CheckLogin(customer);

                    Session.Add("Name", customer.FirstName);
                    Session.Add("Email", customer.Email);
                }

                else if (model.UserRole == Role.Admin && model.Email == "admin@gmail.com" && model.Password == "dbsStaff")
                {
                    Session["Name"] = "Admin";
                    return RedirectToAction("Index", "Admin");
                }

                if (Session["Name"] != null)
                    return View("../Home/Index");

                else
                {
                    ViewData["status"] = "Error: " + dao.message;
                    return View("Status");
                }

            }
            else
            {

                return View("Login", model);
            }

        }
        public ActionResult Status()
        {
            return View();
        }

        public ActionResult Logoff()
        {
            Session.Clear();
            return View("../Home/Index");
        }


    }
}