using AutoMapper;
using CodeZone.DataAccess.Interfaces;
using CodeZone.DataAccess.Models;
using CodeZone.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CodeZone.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StoreController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index(int page = 1)
        {
            int pageSize = 7;
            var totalItems = _unitOfWork.Store.GetAll().ToList();

            var storesViewModel = totalItems
                .OrderBy(s => s.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(s => _mapper.Map<StoreViewModel>(s))  
                .ToList();

            ViewBag.Page = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalItems.Count / (double)pageSize);
            ViewBag.TotalStores = totalItems.Count;

            return View(storesViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]   
        public IActionResult Create(StoreViewModel storeVm)
        {
            
            if (ModelState.IsValid)
            {
                var store = _mapper.Map<Store>(storeVm); 
                _unitOfWork.Store.Add(store);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(storeVm);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var storeInDb = _unitOfWork.Store.GetById(id.Value);

            var storeVm = _mapper.Map<StoreViewModel>(storeInDb);

            return View(storeVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StoreViewModel storeVm)
        {
            if (ModelState.IsValid)
            {
                var store = _mapper.Map<Store>(storeVm); 
                _unitOfWork.Store.Update(store);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(storeVm);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var storeInDb = _unitOfWork.Store.GetById(id.Value);
            if (storeInDb == null)
            {
                return NotFound();
            }

            var storeViewModel = _mapper.Map<StoreViewModel>(storeInDb); 
            return View(storeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteStore(StoreViewModel storeViewModel)
        {
            if (storeViewModel == null || storeViewModel.Id == 0)
            {
                return NotFound();
            }

            var storeInDb = _unitOfWork.Store.GetById(storeViewModel.Id);
            if (storeInDb == null)
            {
                return NotFound();
            }

            _unitOfWork.Store.Remove(storeInDb);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
    }
}
