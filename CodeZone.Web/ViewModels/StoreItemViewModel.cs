using CodeZone.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace CodeZone.Web.ViewModels
{
    public class StoreItemViewModel
    {
        [Required(ErrorMessage = "Please select a store.")]
        public int? StoreId { get; set; }

        [Required(ErrorMessage = "Please select an item.")]
        public int? ItemId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }

        public List<Store>? Stores { get; set; }

        public List<ItemViewModel>? Items { get; set; }
    }
}
