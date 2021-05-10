using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.DTOs;
using BLL.Interfaces;
using ASP_UI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP_UI.Controllers
{
    public class WriteOfListController : Controller
    {
        private readonly IMedicalBillsService _medicalBillsService;
        private readonly IMedicalBillsTypeService _medicalBillsTypeService;
        private readonly IFormService _formService;
        private readonly IWriteOfListService _writeOfListService;
        public IActionResult Index()
        {
            return View();
        }

        public WriteOfListController(IMedicalBillsService medicalBillsService, IMedicalBillsTypeService medicalBillsTypeService, IFormService formService, IWriteOfListService writeOfListService)
        {
            _medicalBillsService = medicalBillsService;
            _medicalBillsTypeService = medicalBillsTypeService;
            _formService = formService;
            _writeOfListService = writeOfListService;
        }

        public IActionResult List()
        {
            List<WriteOfListViewModel> storeViewModel = new List<WriteOfListViewModel>();
            var store = _writeOfListService.GetAll();
            foreach (WriteOfListDTO un in store)
            {
                if (!storeViewModel.Select(u => u.Name).Contains(un.MedicalBills.Name))
                {
                    WriteOfListViewModel model = new WriteOfListViewModel
                    {
                        Id = un.Id,
                        Name = un.MedicalBills.Name,
                        Type = un.MedicalBills.MedicalBillsType.Type,
                        Form = un.MedicalBills.Form.FormName,
                        Quantity = store.Where(u => u.MedicalBills.Id == un.MedicalBills.Id).Count()
                    };
                    storeViewModel.Add(model);
                }
            }

            return View(storeViewModel);
        }
    }
}
