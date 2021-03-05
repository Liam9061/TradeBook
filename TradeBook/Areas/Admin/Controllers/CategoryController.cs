using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeBook.DataAccess.Repository.IRepository;
using TradeBook.Models;

namespace TradeBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            return View();
        }

        //Update and insert
        public IActionResult Upsert(int? id)
        {
            Category category = new Category();
            if (id == null)
            {
                //this is for Create request - Return empty category
                return View(category);

            }
            //This is for edit request - Return pre populated category

            category = _unitOfWork.Category.Get(id.GetValueOrDefault());
            if(category==null)
            {
                return NotFound();
            }
            return View(category);

            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Below is in case Client Validation doesn't work
        public IActionResult Upsert(Category category)
        {
            //Check if all validations are valid.
            if(ModelState.IsValid)
            {
                if (category.Id ==0)
                {
                    _unitOfWork.Category.Add(category);
                    
                }
                else
                {
                    _unitOfWork.Category.update(category);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(category);
        }



        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Category.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Category.Get(id);
            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Problem when trying to delete the Category" });
            }
            _unitOfWork.Category.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = " Category successfully deleted" });
        }

        #endregion
    }
}
