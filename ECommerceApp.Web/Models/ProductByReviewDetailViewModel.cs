using ECommerceApp.Application.DTOs;
using ECommerceApp.Core.Models;

namespace ECommerceApp.Web.Models
{
    public class ProductByReviewDetailViewModel
    {
        public ReviewInsertDTO ReviewInsertDTO { get; set; } = new ReviewInsertDTO();
        public Product Product { get; set; } = new Product();
    }
}