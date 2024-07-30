using System.Collections.Generic;
using ECommerceApp.Application.DTOs;
using ECommerceApp.Core.Models;

namespace ECommerceApp.Web.Models
{
    public class ProductInsertViewModel
    {
        public ProductInsertDTO Product { get; set; } = new ProductInsertDTO();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}