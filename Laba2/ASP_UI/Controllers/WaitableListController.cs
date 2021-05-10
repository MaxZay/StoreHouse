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
    public class WaitableListController : Controller
    {
        private readonly IMedicalBillsService _medicalBillsService;
        private readonly IMedicalBillsTypeService _medicalBillsTypeService;
        private readonly IFormService _formService;
        private readonly IStoreHouseService _storeHouseServices;
        private readonly IWaitableListService _waitableListService;
        public IActionResult Index()
        {
            return View();
        }

        public WaitableListController(IMedicalBillsService medicalBillsService, IMedicalBillsTypeService medicalBillsTypeService, IFormService formService, IStoreHouseService storeHouseService, IWaitableListService waitableList)
        {
            _medicalBillsService = medicalBillsService;
            _medicalBillsTypeService = medicalBillsTypeService;
            _formService = formService;
            _storeHouseServices = storeHouseService;
            _waitableListService = waitableList;
        }

        public IActionResult List()
        {
            List<WaitableListViewModel> waitableListViewModels = new List<WaitableListViewModel>();
            var store = _waitableListService.GetAll();
            foreach (WaitableListDTO un in store)
            {
                if (!waitableListViewModels.Select(u => u.Name).Contains(un.MedicalBills.Name))
                {
                    WaitableListViewModel model = new WaitableListViewModel
                    {
                        Id = un.Id,
                        Name = un.MedicalBills.Name,
                        Type = un.MedicalBills.MedicalBillsType.Type,
                        Form = un.MedicalBills.Form.FormName,
                        Quantity = store.Where(u => u.MedicalBills.Id == un.MedicalBills.Id).Count()
                    };
                    waitableListViewModels.Add(model);
                }
            }

            return View(waitableListViewModels);
        }

        public IActionResult Create()
        {
            var viewModel = new WaitableListViewModel
            {
                TypeList = new SelectList(_medicalBillsTypeService.GetAll().ToList()),
                FormList = new SelectList(_formService.GetAll().ToList()),
                MedicalBills = new SelectList(_medicalBillsService.GetAll())
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(WaitableListViewModel waitableList)
        {
            if (ModelState.IsValid)
            {
                var list = new WaitableListDTO
                {
                    DateOfManufacture = waitableList.DateOfManufacture,
                    ShelfLife = waitableList.ShelfLife,
                    MedicalBills = _medicalBillsService.GetAll().FirstOrDefault(u => u.Name == waitableList.Name)
                };
                _waitableListService.Add(list);
                return RedirectToAction("List");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            WaitableListDTO wait = _waitableListService.GetAll().FirstOrDefault(u => u.Id == id);
            return View(wait);
        }

        [HttpPost]
        public IActionResult Delete(WaitableListDTO dTO)
        {
            try
            {
                WaitableListDTO list = _waitableListService.GetAll().FirstOrDefault(u => u.Id == dTO.Id);
                _waitableListService.Remove(list);
                _storeHouseServices.Add(ConvertTo(list));
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        private StoreHouseDTO ConvertTo(WaitableListDTO storeHouseDTO)
        {
            StoreHouseDTO writeOfList = new StoreHouseDTO
            {
                MedicalBills = storeHouseDTO.MedicalBills,
                DateOfManufacture = storeHouseDTO.DateOfManufacture,
                ShelfLife = storeHouseDTO.ShelfLife
            };
            return writeOfList;
        }


    }
}
