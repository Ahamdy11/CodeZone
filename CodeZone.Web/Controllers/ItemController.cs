using AutoMapper;
using CodeZone.DataAccess.Data;
using CodeZone.DataAccess.Interfaces;
using CodeZone.DataAccess.Models;
using CodeZone.DataAccess.Repositories;
using CodeZone.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodeZone.Web.Controllers
{
    public class ItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ItemController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;    
        }
        public IActionResult Index(int page = 1)
        {
            int pageSize = 7;
            var totalItems = _unitOfWork.Item.GetAll().ToList();
            var itemsViewModel = totalItems
                .OrderBy(i => i.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(s=> _mapper.Map<ItemViewModel>(s))
                .ToList();

            ViewBag.Page = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalItems.Count / (double)pageSize);
            ViewBag.TotalItems = totalItems.Count;

            return View(itemsViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ItemViewModel itemVm)
        {
            if (ModelState.IsValid)
            {
                var item = _mapper.Map<Item>(itemVm);
                _unitOfWork.Item.Add(item);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(itemVm);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var itemInDb = _unitOfWork.Item.GetById(id.Value);

            var itemVm = _mapper.Map<ItemViewModel>(itemInDb);

            return View(itemVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ItemViewModel itemVm)
        {
            if (ModelState.IsValid)
            {
                var item = _mapper.Map<Item>(itemVm);
                _unitOfWork.Item.Update(item);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(itemVm);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var itemInDb = _unitOfWork.Item.GetById(id.Value);
            if (itemInDb == null)
            {
                return NotFound();
            }

            var itemViewModel = _mapper.Map<ItemViewModel>(itemInDb);
            return View(itemViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(ItemViewModel itemViewModel)
        {
            if (itemViewModel == null || itemViewModel.Id == 0)
            {
                return NotFound();
            }

            var itemInDb = _unitOfWork.Item.GetById(itemViewModel.Id);
            if (itemInDb == null)
            {
                return NotFound();
            }

            _unitOfWork.Item.Remove(itemInDb);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }
    }
}
