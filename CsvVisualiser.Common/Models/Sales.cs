using System.ComponentModel.DataAnnotations;

namespace CsvVisualiser.Common.Models
{
    public class Sales
    {
        public string? Segment { get; set; }

        public string? Country { get; set; }

        public string? Product { get; set; }
        
        [Display(Name = "Discount Band")]
        public string? DiscountBand { get; set; }

        [Display(Name = "Units Sold")]
        public string? UnitsSold { get; set; }

        [Display(Name = "Manufacturing Price")]
        public string? ManufacturingPrice { get; set; }

        [Display(Name = "Sale Price")]
        public string? SalePrice { get; set; }

        public DateOnly Date { get; set; }
    }
}
