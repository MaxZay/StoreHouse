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
    public class StoreHouseController : Controller
    {
        private readonly IMedicalBillsService _medicalBillsService;
        private readonly IMedicalBillsTypeService _medicalBillsTypeService;
        private readonly IFormService _formService;
        private readonly IStoreHouseService _storeHouseServices;
        public IActionResult Index()
        {
            return View();
        }

        public StoreHouseController(IMedicalBillsService medicalBillsService, IMedicalBillsTypeService medicalBillsTypeService, IFormService formService, IStoreHouseService storeHouseService)
        {
            _medicalBillsService = medicalBillsService;
            _medicalBillsTypeService = medicalBillsTypeService;
            _formService = formService;
            _storeHouseServices = storeHouseService;
        }

        public IActionResult List()
        {
            List<StoreHouseViewModel> storeViewModel = new List<StoreHouseViewModel>();
            var store = _storeHouseServices.GetAll();
            foreach(StoreHouseDTO un in store)
            {
                if (!storeViewModel.Select(u => u.Name).Contains(un.MedicalBills.Name))
                {
                    StoreHouseViewModel model = new StoreHouseViewModel
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

        public IActionResult Create()
        {
            var viewModel = new StoreHouseViewModel
            {
                TypeList = new SelectList(_medicalBillsTypeService.GetAll().ToList()),
                FormList = new SelectList(_formService.GetAll().ToList()),
                MedicalBills = new SelectList(_medicalBillsService.GetAll())
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(StoreHouseViewModel storeHouse)
        {
            if (ModelState.IsValid)
            {
                var store = new StoreHouseDTO
                {
                    DateOfManufacture = storeHouse.DateOfManufacture,
                    ShelfLife = storeHouse.ShelfLife,
                    MedicalBills = _medicalBillsService.GetAll().FirstOrDefault(u => u.Name == storeHouse.Name)
                };
                _storeHouseServices.Add(store);
                return RedirectToAction("List");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            StoreHouseDTO store = _storeHouseServices.GetAll().FirstOrDefault(u => u.Id == id);
            StoreHouseViewModel modelViewModel = new StoreHouseViewModel
            {
                Id = store.Id,
                Name = store.MedicalBills.Name,
                Type = store.MedicalBills.MedicalBillsType.Type,
                Form = store.MedicalBills.Form.FormName,
                Quantity = 1
            };
            return View(modelViewModel);
        }

        [HttpPost]
        public IActionResult Delete(StoreHouseViewModel storeHouseViewModel)
        {
            try
            {
                List<StoreHouseDTO> store = _storeHouseServices.GetAll().ToList();
                for (int i = 0; i < storeHouseViewModel.Quantity; i++)
                {
                    _storeHouseServices.Remove(store[i]);
                }
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}
