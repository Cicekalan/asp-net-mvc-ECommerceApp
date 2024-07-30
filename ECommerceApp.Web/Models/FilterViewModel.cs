namespace ECommerceApp.Web.Models
{
    public class FilterViewModel
    {
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string SortOrder { get; set; } = "asc";
        public string? CategoryName {get; set;}
        public bool Sorted {get;set;} = false;
    }
}