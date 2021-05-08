﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP_UI.Models.ViewModels
{
    public class MedicalBillsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        [StringLength(80,MinimumLength = 3)]
        public string Name { get; set; }
        [Display(Name = "Количество")]
        [Range(1, 2000)]
        [Required(ErrorMessage = "Неверное количество")]
        public int Quantity { get; set; }
        [Display(Name = "Тип препарата")]
        //public MedicalBillsTypeDTO MedicalBillsType;
        public string Type { get; set; }

        public IEnumerable<MedicalBillsTypeDTO> Types;
        public SelectList DataList { get; set; }
    }
}
