using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Xml;

namespace WebCloudCA.Models
{
    public class DAO
    {
        SqlConnection conn;
        public string message = "";
        public int id;
        public void Connection()
        {
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["conString"].ConnectionString);
        }
        public int InsertCustomerReg(Customer customer)
        {
            Connection();
            int count = 0;
            SqlCommand cmd = new SqlCommand("uspInsertIntoCustomer",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@firstname", customer.FirstName );
            cmd.Parameters.AddWithValue("@lastname", customer.LastName );
            cmd.Parameters.AddWithValue("@email", customer.Email ) ;
            cmd.Parameters.AddWithValue("@phone", customer.Phone );
            cmd.Parameters.AddWithValue("@address", customer.Address );
            cmd.Parameters.AddWithValue("@password", customer.Password );
            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return count;
        }
        public int InsertCustomer(Booking booking)
        {
            Connection();
            int count = 0;
            string pass = "";
            //  string insert = "INSERT INTO Customer (firstname,lastname,email,phone,address,password) VALUES(@firstname,@lastname,@email,@phone,@address,null)";
            //SqlCommand cmd = new SqlCommand(insert, conn);
            SqlCommand cmd = new SqlCommand("uspInsertIntoCustomer",conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@firstname", booking.FirstName);
            cmd.Parameters.AddWithValue("@lastname", booking.LastName);
            cmd.Parameters.AddWithValue("@email", booking.Email);
            cmd.Parameters.AddWithValue("@phone", booking.Phone);
            cmd.Parameters.AddWithValue("@address", booking.Address);
            cmd.Parameters.AddWithValue("@password", pass);
            try
            {
                conn.Open();
                // id = (int)cmd.ExecuteScalar();
                count = cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                message = ex.Message +"cust method";

            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        public int GetLastCustomer()
        {
            
            int cusid = 0 ;
            Connection(); 
           string getlast = "SELECT MAX(customerid) FROM Customer";
            SqlCommand cmd = new SqlCommand(getlast,conn);
           // SqlCommand cmd = new SqlCommand("uspGetLastCustomer", conn);
           // cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                cusid = (int)cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                message = ex.Message + "get cus id method";

            }
            finally
            {
                conn.Close();
            }
            return cusid;
            
        }
        public int CheckCustomer(string email)
        {
            Connection();
            int count = 0;
            SqlCommand cmd = new SqlCommand("SELECT email FROM Customer WHERE email = @email", conn);
            cmd.Parameters.AddWithValue("@email",email);
            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                message = ex.Message +"Check Customer Error";
            }
            finally
            {
                conn.Close();
            }
            return count;
        }
        public decimal GetPrice()
        {
            decimal amount = 0;
            //SELECT * 
           
            Connection();
            string command = "SELECT TOP 1 bookingid, price FROM Booking ORDER BY bookingid DESC ";
            SqlCommand cmd = new SqlCommand(command,conn);

            try
            {
                conn.Open();
                amount = (decimal)cmd.ExecuteScalar();
                System.Diagnostics.Debug.WriteLine(amount);
                
            }
            catch (Exception ex)
            {
                message = ex.Message + "get amount method";

            }
            finally
            {
                conn.Close();
            }
            return amount;


        }

        public int InsertBooking(Booking booking, int id)
        {
            Connection();
            int count = 0;

            //string bookstring = "INSERT INTO Booking(arrivaldate,departuredate,noofnights,price,customerid,roomtype,review,paymentmade) VALUES (@arrivaldate,@departuredate,@noofnights,@price,@customerid,@roomtype,null,null)";
            // SqlCommand cmd = new SqlCommand(bookstring, conn);
            SqlCommand cmd = new SqlCommand("uspInsertIntoBooking",conn);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.AddWithValue("@arrivaldate", booking.ArrivalDate);
            cmd.Parameters.AddWithValue("@departuredate",booking.DepartureDate);
            cmd.Parameters.AddWithValue("@noofnights",booking.Nights);
            cmd.Parameters.AddWithValue("@price",booking.Price);
           cmd.Parameters.AddWithValue("@customerid", id);
            cmd.Parameters.AddWithValue("@roomtype", booking.RoomType);
            
            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                message = ex.Message;

            }
            finally
            {
                conn.Close();
            }
            return count;
        }

      

        public List<string> PopulateRooms()
        {
            List<string> rooms = new List<string>();
            Connection();
            SqlDataReader reader;
           // SqlCommand cmd = new SqlCommand("SELECT roomtype FROM Room", conn);
            SqlCommand cmd = new SqlCommand("uspSelectRoomTypes",conn);
            cmd.CommandType = CommandType.StoredProcedure;

            string RoomType;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RoomType = reader["roomtype"].ToString();
                    rooms.Add(RoomType);
                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return rooms;
        }



        public int UpdatePayment()
        {
            //UPDATE Booking set paymentmade = 0 WHERE bookingid = (SELECT MAX(bookingid) Booking)
            // string updatepayment = "declare @bookingnum int SELECT TOP 1 @bookingnum = bookingid   FROM Booking ORDER BY bookingid DESC UPDATE Booking set paymentmade = 0 WHERE bookingid = @bookingnum";
            // SqlCommand cmd = new SqlCommand(updatepayment, conn);

            Connection();
            int count = 0 ;
           SqlCommand cmd = new SqlCommand("uspAddPaymentStatusToBooking", conn);
            cmd.CommandType = CommandType.StoredProcedure;
          
            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                message = ex.Message;

            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        public int InsertIntoPayment(Payment payment, int id)
        {
            int count = 0;
            Connection();
            SqlCommand cmd = new SqlCommand("uspINSERTIntoPayment",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cardholdername",payment.CardHolderName);
            cmd.Parameters.AddWithValue("@cardtype", payment.CardType);
            cmd.Parameters.AddWithValue("@cardnumber", payment.CardNumber );
            cmd.Parameters.AddWithValue("@securitynum", payment.SecurityNum );
            cmd.Parameters.AddWithValue("@expmon", payment.ExpMon );
            cmd.Parameters.AddWithValue("@expyr", payment.ExpYr );
            cmd.Parameters.AddWithValue("@amount", payment.Amount );
            cmd.Parameters.AddWithValue("@bookingid", id );
            //add all
            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
           catch(Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return count;




        }

        public int GetLastBookingId()
        {

            //
            int id = 0;
            Connection();
            string getlast = "SELECT MAX(bookingid) FROM Booking";
            SqlCommand cmd = new SqlCommand(getlast, conn);
           // SqlCommand cmd = new SqlCommand("uspGetLastBookingId");
            //cmd.CommandType = CommandType.StoredProcedure;
          
            try
            {
                conn.Open();
                id = (int)cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                message = ex.Message + "get cus id method";

            }
            finally
            {
                conn.Close();
            }
            return id;

        }
        public string CheckLogin(Customer c)
        {
            c.FirstName = null;
            Connection();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("uspCheckLogin", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", c.Email);
            cmd.Parameters.AddWithValue("@pass", c.Password);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    c.FirstName = reader["FirstName"].ToString();
                }

            }
            catch (Exception ex)
            {

                message = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return c.FirstName;
        }


        public List<Booking> ShowAllBookings()
        {
            Connection();
            SqlDataReader reader;
            List<Booking> bookinglist = new List<Booking>();
            SqlCommand cmd = new SqlCommand("uspShowAllBookings", conn);
            cmd.CommandType = CommandType.StoredProcedure;
           
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Booking booking = new Booking();
                    booking.BookingId = int.Parse(reader[0].ToString());
                    booking.ArrivalDate = DateTime.Parse(reader[1].ToString());
                    booking.DepartureDate = DateTime.Parse(reader[2].ToString());
                    booking.Nights = int.Parse(reader[3].ToString());
                    booking.Price = decimal.Parse(reader[4].ToString());
                    booking.CustomerId = int.Parse(reader[5].ToString());
                    booking.RoomType = reader[6].ToString();
                   if(reader["review"].ToString() == null)
                    {
                        booking.Review = null;
                    }
                   if(reader[8].ToString() == "0")
                    {
                        booking.PaymentMade = "Paid";
                    }
                    bookinglist.Add(booking);
                }
            }
            catch(Exception ex)
            {
                message = "Error " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return bookinglist;
        }

        public List<Payment> ShowAllPayments()
        {
            Connection();
            SqlDataReader reader;
            List<Payment>paylist = new List<Payment>();
             SqlCommand cmd = new SqlCommand("uspShowAllPayments", conn);
            cmd.CommandType = CommandType.StoredProcedure;
           
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   Payment pay = new Payment();
                    pay.PaymentId = int.Parse(reader[0].ToString());
                    pay.CardHolderName = reader[1].ToString();
                    pay.CardType = reader[2].ToString();
                   pay.CardNumber = reader[3].ToString();
                    pay.SecurityNum = int.Parse(reader[4].ToString());
                    pay.ExpMon = int.Parse(reader[5].ToString());
                    pay.ExpYr = int.Parse(reader[6].ToString());
                    pay.Amount = decimal.Parse(reader[7].ToString());
                    pay.BookingId = int.Parse(reader[8].ToString());
                   
                   paylist.Add(pay);
                }
            }
            catch (Exception ex)
            {
                message = "Error " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return paylist;
        }

        public List<Customer> ShowAllCustomers()
        {
            Connection();
            SqlDataReader reader;
            List<Customer> cuslist = new List<Customer>();
            SqlCommand cmd = new SqlCommand("uspShowAllCustomers", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer cus = new Customer();
                    cus.Customerid = int.Parse(reader[0].ToString());
                   cus.FirstName = reader[1].ToString();
                    cus.LastName = reader[2].ToString();
                    cus.Email = reader[3].ToString();
                    cus.Phone = reader[4].ToString();
                    cus.Address = reader[5].ToString();
                    cus.Password = reader[6].ToString();
                    cuslist.Add(cus);
                }
            }
            catch (Exception ex)
            {
                message = "Error " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return cuslist;
        }
    }
}