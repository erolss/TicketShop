using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Session;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketShop.Models;
using TicketShop.Models.ViewModels;
using TicketShop.RestApiClient.Model;
using TicketShop.Settings;
using Microsoft.Extensions.Options;
using TicketShop.RestApiClient;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TicketShop.Services;
using Newtonsoft.Json;

namespace TicketShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly CustomSettings _apiSettings;

        public OrderController(IOptions<CustomSettings> settings)
        {
            this._apiSettings = settings.Value;

        }
        public ActionResult Cart()
        {
            var model = new OrderCartViewModel();
            if(ItemsInCart() > 0)
            {
                model.Events = GetEventsInCart();
                model.Total = GetTotal(model.Events);

            }
            

            ViewData["Title"] = "Cart";

            return View(model);
        }

        public ActionResult Confirmation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirmation(OrderCartViewModel order)
        {
            var session = HttpContext.Session;
            var cart = session.Get<Order>("Cart");
            
            var tApi = new TransactionApi(_apiSettings.ApiBaseUrl);

            var userId = "";
            if (User.Identity.IsAuthenticated)
            {
                userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }



            var transaction = new Transaction
            {
                TransactionID = 0,
                BuyerFirstName = order.BuyerFirstName,
                BuyerLastName = order.BuyerLastName,
                BuyerAddress = order.BuyerAddress,
                BuyerCity = order.BuyerCity,
                BuyerEmail = order.BuyerEmail,
                BuyerUserId = userId,
                TotalAmount = order.TotalAmount
            };

            //Add transaction & process payment
            Transaction newTransaction = tApi.AddTransaction(transaction);

            if (newTransaction.PaymentStatus == "PaymentApproved")
            {
                var ticketApi = new TicketApi(_apiSettings.ApiBaseUrl);
                foreach (int id in cart.Cart)
                {
                    var t = new Ticket
                    {
                        TicketEventDateID = id,
                        TransactionID = newTransaction.TransactionID
                    };
                    ticketApi.AddTicketOrder(t);
                }

                var a = new EmailSender();
                var msg = @"Hello, <br/> Thank you for your ticket purchase with us.<br/>" +
                            "Receipt:<br/>" +
                            "TransactionID: " + newTransaction.TransactionID +
                            "Total tickets bought: " + cart.Cart.Count() +
                            "Total Amount paid: " + newTransaction.TotalAmount;
                a.SendEmailAsync(newTransaction.BuyerEmail, "Thank you for your ticket purchase", msg);

                ViewData["noTickets"] = cart.Cart.Count();
                session.Remove("Cart");

            }

            
            switch (newTransaction.PaymentStatus)
            {
                case "PaymentRejected":
                    ViewData["panel-class"] = "panel-warning";
                    ViewData["PaymentStatus"] = "Payment Rejected";

                    break;
                case "UnknownError":
                    ViewData["panel-class"] = "panel-danger";
                    ViewData["PaymentStatus"] = "Unknown Error";
                    break;
                default:
                    ViewData["panel-class"] = "panel-success";
                    ViewData["PaymentStatus"] = "Payment Approved";
                    break;
                    
            }
            ViewData["Title"] = "Payment Summary";

            return View(newTransaction);

        }


        [HttpPost]
        public int AddToCart(int eventDateId)
        {
            var session = HttpContext.Session;

            var order = session.Get<Order>("Cart");

            if (order == null)
            {
                order = new Order
                {
                    Cart = new List<int>()
                };

                order.Cart.Add(eventDateId);

                session.Set("Cart", order);
            }
            else
            {
                order.Cart.Add(eventDateId);

                session.Set("Cart", order);

            }
            return order.Cart.Count();
        }

        public ActionResult RemoveItem(int eventDateId)
        {
            var session = HttpContext.Session;


            var order = session.Get<Order>("Cart");

            if (order != null)
            {
                order.Cart.Remove(eventDateId);

                session.Set("Cart", order);


            }
            return RedirectToAction("Cart");
            // return View("Cart", model);
        }


        public int RemoveFromCart(int eventDateId)
        {
            var session = HttpContext.Session;

            var order = session.Get<Order>("Cart");

            if (order != null)
            {
                order.Cart.Remove(eventDateId);

                session.Set("Cart", order);
            }

            return order.Cart.Count();

        }

        public int EmptyCart(int eventDateId)
        {
            var session = HttpContext.Session;

            var order = session.Get<Order>("Cart");

            if (order != null)
            {
                order.Cart.Clear();

                session.Set("Cart", order);
            }

            return order.Cart.Count();

        }

        public int ItemsInCart()
        {
            var session = HttpContext.Session;

            var order = session.Get<Order>("Cart");

            if (order != null)
            {
                return order.Cart.Count();

            }

            return 0;
        }

        private List<FullEventDate> GetEventsInCart()
        {
            var list = new List<FullEventDate>();
            var session = HttpContext.Session;
            var api = new EventDateApi(_apiSettings.ApiBaseUrl);

            var order = session.Get<Order>("Cart");

            if (order != null && (order.Cart != null || order.Cart.Count != 0))
            {
                foreach (var id in order.Cart)
                {

                    var ticketItem = api.GetFullEventDateById(id);
                    list.Add(ticketItem);

                }
                return list;
            }
            return null;
        }

        private double GetTotal(List<FullEventDate> events)
        {
            double total = events.Sum(item => item.Price);
            return total;
        }


        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: Default/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Default/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Default/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Default/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Default/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}