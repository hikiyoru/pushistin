using pushistin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace pushistin.Core.ViewModels
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Product> products, decimal? from, decimal? to, bool? isStock, string? searchString)
        {

            Brands = new MultiSelectList(products.Select(p => p.Brand).ToList().Distinct());
            Categorys = new MultiSelectList(products.Select(p => p.Category).ToList().Distinct());
            Pets = new MultiSelectList(products.Select(p => p.Pet).ToList().Distinct());
            From = from;
            To = to;
            IsStock = isStock;
            SearchString = searchString;
        }
        public MultiSelectList? Brands { get; private set; }
        public MultiSelectList? Categorys { get; private set; }
        public MultiSelectList? Pets { get; private set; }

        public decimal? From { get; private set; }
        public decimal? To { get; private set; }
        public bool? IsStock { get; private set; }

        public string? SearchString { get; private set; }
    }
}
