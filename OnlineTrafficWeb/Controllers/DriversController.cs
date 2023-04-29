using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineTrafficWeb.Data;
using OnlineTrafficWeb.Models;
using OnlineTrafficWeb.Repository.IRepository;

namespace OnlineTrafficWeb.Controllers
{
    //[Authorize(Roles="Traffic")]
    public class DriversController : Controller
    {


        //crud simple 

        //    private readonly ApplicationDbContext _db;

        //    public DriversController(ApplicationDbContext db)
        //    {
        //        _db = db;
        //    }

        //    public IActionResult Index()
        //    {
        //        IEnumerable<DriversAdd> objDriversList = _db.DriversAds;
        //        return View(objDriversList);
        //    }

        //    public IActionResult Create()
        //    {

        //        return View();
        //    }

        //    //POST
        //    [HttpPost]                 //used to handle the http request
        //    [ValidateAntiForgeryToken] //used to prevent the cross site request forgery attack
        //    public IActionResult Create(DriversAdd obj)
        //    {

        //        //custom validation can be done as follows
        //        if (obj.Name == obj.LicenseNumber.ToString())
        //        {
        //            ModelState.AddModelError("name", "Name and License cannot be same");
        //        }
        //        //server side validation because name cannot be empty


        //            _db.DriversAds.Add(obj);
        //            _db.SaveChanges();
        //            TempData["success"] = "Traffic Added Successfully";
        //            return View(obj);
        //    }

        //    //GET(for Edit) (Validation remains same)
        //    public IActionResult Edit(int? id)
        //    {
        //        if (id == null || id == 0)
        //        {
        //            return NotFound();
        //        }
        //        var driversFromDb = _db.DriversAds.Find(id);
        //        if (driversFromDb == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(driversFromDb);
        //    }

        //    //POST
        //    [HttpPost]                 //used to handle the http request
        //    [ValidateAntiForgeryToken] //used to prevent the cross site request forgery attack
        //    public IActionResult Edit(DriversAdd obj)
        //    {

        //        //custom validation can be done as follows
        //        if (obj.Name == obj.LicenseNumber.ToString())
        //        {
        //            ModelState.AddModelError("name", "License cannot be same as name");
        //        }
        //        //server side validation because name cannot be empty


        //            _db.DriversAds.Update(obj);
        //            _db.SaveChanges();
        //            TempData["success"] = "Traffic Updated Successfully";
        //             return View(obj);
        //    }

        //    //GET(for Delete) 
        //    public IActionResult Delete(int? id)
        //    {
        //        if (id == null || id == 0)
        //        {
        //            return NotFound();
        //        }
        //        var driversFromDb = _db.DriversAds.Find(id);
        //        if (driversFromDb == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(driversFromDb);
        //    }

        //    //POST
        //    [HttpPost]                 //used to handle the http request
        //    [ValidateAntiForgeryToken] //used to prevent the cross site request forgery attack
        //    public IActionResult DeletePOST(int? id)
        //    {

        //        var obj = _db.DriversAds.Find(id);
        //        if (obj == null)
        //        {
        //            return NotFound();
        //        }

        //        _db.DriversAds.Remove(obj);
        //        _db.SaveChanges();
        //        TempData["success"] = "Drivers Deleted Successfully";

        //        return RedirectToAction("Index");


        //    }

        //}


        //crud simple over


        private readonly IUnitOfWork _unitOfWork; //

        public DriversController(IUnitOfWork unitOfWork)    //
        {
            _unitOfWork = unitOfWork;
        }
        //the below is used to retrieve and display the data from database and show it to page 
        //configured in Index.cshtml 
        public IActionResult Index()
        {
            IEnumerable<DriversAdd> objDriverList = _unitOfWork.DriversAdd.GetAll(); //   
            return View(objDriverList);
        }
        //GET
        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]                 //used to handle the http request
        [ValidateAntiForgeryToken] //used to prevent the cross site request forgery attack
        public IActionResult Create(DriversAdd obj)
        {

            //custom validation can be done as follows
            if (obj.Name == obj.LicenseNumber.ToString())
            {
                ModelState.AddModelError("name", "Display order cannot be same as name");
            }
            //server side validation because name cannot be empty
            if (ModelState.IsValid)
            {

                _unitOfWork.DriversAdd.Add(obj);    //
                _unitOfWork.Save();      //
                TempData["success"] = "Drivers Created Successfully";
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

            //find incase of priimary key only if not below sabai bujhxa!!!
            var driverFromDbFirst = _unitOfWork.DriversAdd.GetFirstorDefault(u => u.Id == id);    //
            if (driverFromDbFirst == null)
            {
                return NotFound();
            }
            return View(driverFromDbFirst);
        }

        //POST
        [HttpPost]                 //used to handle the http request
        [ValidateAntiForgeryToken] //used to prevent the cross site request forgery attack
        public IActionResult Edit(DriversAdd obj)
        {

            //custom validation can be done as follows
            if (obj.Name == obj.LicenseNumber.ToString())
            {
                ModelState.AddModelError("name", "Display order cannot be same as name");
            }
            //server side validation because name cannot be empty
            if (ModelState.IsValid)
            {

                _unitOfWork.DriversAdd.Update(obj);   //
                _unitOfWork.Save();        //    
                TempData["success"] = "Driver Updated Successfully";

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
            var driverFromDbFirst = _unitOfWork.DriversAdd.GetFirstorDefault(u => u.Id == id);
            if (driverFromDbFirst == null)
            {
                return NotFound();
            }
            return View(driverFromDbFirst);
        }

        //POST
        [HttpPost]                 
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            var obj = _unitOfWork.DriversAdd.GetFirstorDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.DriversAdd.Remove(obj);    //
            _unitOfWork.Save();         //
            TempData["success"] = "Drivers Deleted Successfully";

            return RedirectToAction("Index");


        }

    }
}