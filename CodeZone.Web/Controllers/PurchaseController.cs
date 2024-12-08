using AutoMapper;
using CodeZone.DataAccess.Interfaces;
using CodeZone.DataAccess.Models;
using CodeZone.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CodeZone.Web.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PurchaseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Transaction(int? storeId, int? itemId)
        {
            var transactionVm = new StoreItemViewModel
            {
                Stores = _unitOfWork.Store.GetAll()
            };

            var items = _unitOfWork.Item.GetAll();
            transactionVm.Items = _mapper.Map<List<ItemViewModel>>(items);

            if (storeId.HasValue && itemId.HasValue)
            {
                var storeItem = _unitOfWork.StoreItem.GetByStoreAndItem(storeId.Value, itemId.Value);

                if (storeItem != null)
                {
                    _mapper.Map(storeItem, transactionVm);
                }
            }

            return View(transactionVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Transaction(StoreItemViewModel transactionVm)
        {
            if (ModelState.IsValid)
            {
                var storeItem = _unitOfWork.StoreItem.GetByStoreAndItem(transactionVm.StoreId.Value, transactionVm.ItemId.Value);

                if (storeItem != null)
                {                    
                    storeItem.Quantity += transactionVm.Quantity;
                    _unitOfWork.StoreItem.Update(storeItem);
                    _unitOfWork.Complete();
                }
                else
                {
                    var newStoreItem = _mapper.Map<StoreItem>(transactionVm);
                    _unitOfWork.StoreItem.Add(newStoreItem);
                    _unitOfWork.Complete();
                }

                var redirectParams = _mapper.Map<StoreItemViewModel>(transactionVm);
                return RedirectToAction("Transaction", redirectParams);
            }

            transactionVm.Stores = _unitOfWork.Store.GetAll();
            transactionVm.Items = _mapper.Map<List<ItemViewModel>>(_unitOfWork.Item.GetAll());
            return View(transactionVm);
        }

        public IActionResult Balance(int storeId, int itemId)
        {
            var storeItem = _unitOfWork.StoreItem.GetByStoreAndItem(storeId, itemId);

            if (storeItem != null)
            {
                return Ok(storeItem.Quantity);
            }

            return Ok(0);
        }
    }
}
