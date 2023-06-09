﻿using Microsoft.AspNetCore.Mvc;
using OnlineTrafficWeb.Data;
using OnlineTrafficWeb.Models;
using System.Collections.Generic;

namespace OnlineTrafficWeb.Controllers
{


    public class TrafficController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TrafficController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<TrafficAdd> objTrafficList = _db.TrafficAds;
            return View(objTrafficList);
        }

        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]                 //used to handle the http request
        [ValidateAntiForgeryToken] //used to prevent the cross site request forgery attack
        public IActionResult Create(TrafficAdd obj)
        {

            //custom validation can be done as follows
            if (obj.Name == obj.OfficerId.ToString())
            {
                ModelState.AddModelError("name", "Name and Id cannot be same");
            }
            //server side validation because name cannot be empty
            if (ModelState.IsValid)
            {

                _db.TrafficAds.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Traffic Added Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET(for Edit) (Validation remains same)
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var trafficFromDb = _db.TrafficAds.Find(id);
            if (trafficFromDb == null)
            {
                return NotFound();
            }
            return View(trafficFromDb);
        }

        //POST
        [HttpPost]                 //used to handle the http request
        [ValidateAntiForgeryToken] //used to prevent the cross site request forgery attack
        public IActionResult Edit(TrafficAdd obj)
        {

            //custom validation can be done as follows
            if (obj.Name == obj.OfficerId.ToString())
            {
                ModelState.AddModelError("name", "OfficerId cannot be same as name");
            }
            //server side validation because name cannot be empty
            if (ModelState.IsValid)
            {

                _db.TrafficAds.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Traffic Updated Successfully";
                    
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET(for Delete) 
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var trafficFromDb = _db.TrafficAds.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);   
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (trafficFromDb == null)
            {
                return NotFound();
            }
            return View(trafficFromDb);
        }

        //POST
        [HttpPost]                 //used to handle the http request
        [ValidateAntiForgeryToken] //used to prevent the cross site request forgery attack
        public IActionResult DeletePOST(int? id)
        {

            var obj = _db.TrafficAds.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.TrafficAds.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";

            return RedirectToAction("Index");


        }

    }
}
