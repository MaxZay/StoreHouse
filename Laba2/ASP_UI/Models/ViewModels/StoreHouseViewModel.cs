using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_UI.Models.ViewModels
{
    public class StoreHouseViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        [StringLength(80, MinimumLength = 3)]
        public string Name { get; set; }
        [Display(Name = "Название")]
        [StringLength(80, MinimumLength = 3)]
        public string Type { get; set; }
        [Display(Name = "Название")]
        [StringLength(80, MinimumLength = 3)]
        public string Form { get; set; }

        [Display(Name = "Количество")]
        public int Quantity { get; set; }

        [Display(Name = "Дата производства")]
        public DateTime DateOfManufacture { get; set; }
        [Display(Name = "Срок годности")]
        public DateTime ShelfLife { get; set; }

        public SelectList MedicalBills{ get; set; }
        public SelectList TypeList { get; set; }
        public SelectList FormList { get; set; }
    }
}
