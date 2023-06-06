using pushistin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace pushistin.Core.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }

        public SortViewModel SortViewModel { get; set; }

    }
}
