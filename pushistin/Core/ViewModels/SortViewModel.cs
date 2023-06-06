using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace pushistin.Core.ViewModels
{
    public enum SortState
    {
        [Display(Name = "Возрастание")]
        PriceAsc,
        [Display(Name = "Убывание")]
        PriceDesc,
    }
    public class SortViewModel
    {
        public SortState PriceSort { get; set; }
        public SortState Current { get; set; }

        public SortViewModel(SortState sort)
        {
            PriceSort = sort == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            Current = sort;
        }
    }
}
