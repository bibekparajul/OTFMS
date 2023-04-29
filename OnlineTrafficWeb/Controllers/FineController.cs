using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineTrafficWeb.Models;
using OnlineTrafficWeb.Models.ViewModel;
using OnlineTrafficWeb.Repository.IRepository;

namespace OnlineTrafficWeb.Controllers
{
    //[Authorize(Roles="Traffic")]

    public class FineController : Controller
    {

        private readonly IUnitOfWork _unitOfWork; 

        private readonly IWebHostEnvironment _hostEnvironment;


        public FineController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)    //
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        //GET


        //GET(for Edit) (Validation remains same)
        public IActionResult Upsert(int? id)
        {
            //ViewBag ra viewdata ko satta

            FineVM fineVM = new()
            {
                Fine = new(),
                DriverList = _unitOfWork.DriversAdd.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()

                }),               
                
                //TrafficList = _unitOfWork.TrafficAdd.GetAll().Select(i => new SelectListItem
                //{
                //    Text = i.Name,
                //    Value = i.Id.ToString()

                //}),

            };

            if (id == null || id == 0)

            {


                return View(fineVM);
            }
            else
            {
                fineVM.Fine = _unitOfWork.FineAdd.GetFirstorDefault(u => u.Id == id);
                return View(fineVM);

            }


        }

        //POST
        [HttpPost]                 //used to handle the http request
        [ValidateAntiForgeryToken] //used to prevent the cross site request forgery attack
        public IActionResult Upsert(FineVM obj)
        {



            if (ModelState.IsValid)
            {
               
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (obj.Fine.Id == 0)
                {
                    _unitOfWork.FineAdd.Add(obj.Fine);

                }
                else
                {
                    _unitOfWork.FineAdd.Update(obj.Fine);


                }   //
                //for creating firstproduct
                _unitOfWork.Save();        //    
                TempData["success"] = "Fine Created Successfully";

                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //apiendpoints data tables (edit and delete ko lagi)

        #region API CALLS
        [HttpGet]

        public IActionResult GetAll()
        {
            var driversList = _unitOfWork.FineAdd.GetAll(includeProperties: "DriversAdd");
            return Json(new { data = driversList });
        }
        //delete
        [HttpDelete]                 //used to handle the http request
        public IActionResult Delete(int? id)
        {

            var obj = _unitOfWork.FineAdd.GetFirstorDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.FineAdd.Remove(obj);    //
            _unitOfWork.Save();         //
            return Json(new { success = true, message = "Successfully  deleted" });

        }
        #endregion
    }
}

