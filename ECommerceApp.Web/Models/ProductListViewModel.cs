using ECommerceApp.Core.Models;

namespace ECommerceApp.Web.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public FilterViewModel Filter { get; set; } = new FilterViewModel();
    }

}