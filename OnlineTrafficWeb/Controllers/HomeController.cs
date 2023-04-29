﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTrafficWeb.Models;
using OnlineTrafficWeb.Models.ViewModel;
using OnlineTrafficWeb.Repository.IRepository;
using Stripe.Checkout;
using System.Diagnostics;
using System.Security.Claims;

namespace OnlineTrafficWeb.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            IEnumerable<FineModel> fineList = _unitOfWork.FineAdd.GetAll(includeProperties: "DriversAdd");
            return View(fineList);
        }

        //[Authorize]

        public IActionResult Details(int fineId)
        {
            //FineModel fineobj = new()
            //{
            //    FineId = fineId,
            //    //DriversAdd = _unitOfWork.DriversAdd.GetFirstorDefault(u => u.Id == fineId)
            //};

            var fineFromDb = _unitOfWork.FineAdd.GetFirstorDefault(u => u.Id == fineId, includeProperties: "DriversAdd");

            return View(fineFromDb);
        }


        public IActionResult Pay()
        {

            var domain = "https://localhost:7185/";
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                LineItems = new List<SessionLineItemOptions>(),

                Mode = "payment",
                SuccessUrl = domain + $"Home/success",
                CancelUrl = domain + $"Home/cancel",
            };


            var sessionLineItem = new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long)(100),
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = "Fine",
                    },
                },
                Quantity = 1,
            };
            options.LineItems.Add(sessionLineItem);

            //  }

            var service = new SessionService();
            Session session = service.Create(options);
            _unitOfWork.Save();

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);


        } 

        public IActionResult Success()
        {
            return View();
        }






//[HttpPost]
//[ValidateAntiForgeryToken]
////[/*Authorize*/]
//public IActionResult Details(FineModel finepay)
//{
//    //this claim helps to find out whether user is login or not
//    var claimsIdentity = (ClaimsIdentity)User.Identity;
//    var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
//    finepay.ApplicationUserId = claim.Value;

//    ShoppingCart cartFromDB = _unitOfWork.ShoppingCart.GetFirstorDefault(
//      u => u.ApplicationUserId == claim.Value && u.ProductId == shoppingCart.ProductId);



//    _unitOfWork.Save();

//    return RedirectToAction(nameof(Index));
//}





public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
