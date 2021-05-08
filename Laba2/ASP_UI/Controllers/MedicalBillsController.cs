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
    public class MedicalBillsController : Controller
    {
        private readonly IMedicalBillsService _medicalBillsService;
        private readonly IMedicalBillsTypeService _medicalBillsTypeService;
        private readonly IFormService _formService;
        private readonly List<MedicalBillsDTO> medicalBillsDTOs;

        public IActionResult Index()
        {
            return View();
        }
        public MedicalBillsController(IMedicalBillsService medicalBillsService, IMedicalBillsTypeService medicalBillsTypeService, IFormService formService)
        {
            _medicalBillsService = medicalBillsService;
            _medicalBillsTypeService = medicalBillsTypeService;
            _formService = formService;
            medicalBillsDTOs = _medicalBillsService.GetAll().ToList();
        }

        public IActionResult List()
        {
            
            var bills = _medicalBillsService.GetAll();
            return View(bills);
        }

        public IActionResult Create()
        {
            var viewModel = new MedicalBillsViewModel()
            {
                TypeList = new SelectList(_medicalBillsTypeService.GetAll().ToList()),
                FormList = new SelectList(_formService.GetAll().ToList())
            };
            viewModel.Types = _medicalBillsTypeService.GetAll().ToList();
            viewModel.Forms = _formService.GetAll().ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(MedicalBillsViewModel medicalBillsViewModel)
        {
            if (ModelState.IsValid)
            {
                var bill = new MedicalBillsDTO
                {
                    Name = medicalBillsViewModel.Name,
                    MedicalBillsType = _medicalBillsTypeService.GetAll().FirstOrDefault(u => u.Type == medicalBillsViewModel.Type),
                    Form = _formService.GetAll().FirstOrDefault(u => u.FormName == medicalBillsViewModel.Form)
                };
                _medicalBillsService.Add(bill);
                return RedirectToAction("List");
            }
            return View();
        }
    
        public IActionResult Delete(int id)
        {
            MedicalBillsDTO med = _medicalBillsService.GetAll().FirstOrDefault(u => u.Id == id);
            return View(med);
        }

        [HttpPost]
        public IActionResult Delete(MedicalBillsDTO dTO)
        {
            try
            {
                var med = _medicalBillsService.GetAll().FirstOrDefault(u => u.Id == dTO.Id);
                _medicalBillsService.Remove(med);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
           
        }

        public IActionResult Edit(int id)
        {
            var viewModel = new MedicalBillsViewModel()
            {
                Id = id,
                TypeList = new SelectList(_medicalBillsTypeService.GetAll().ToList()),
                FormList = new SelectList(_formService.GetAll().ToList())
            };
            viewModel.Types = _medicalBillsTypeService.GetAll().ToList();
            var med = _medicalBillsService.GetAll().FirstOrDefault(u => u.Id == id);
            ViewBag.Bill = med; 
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(MedicalBillsViewModel medicalBillsViewModel)
        {
            try
            {
                var dTO = new MedicalBillsDTO
                {
                    Id = _medicalBillsService.GetAll().FirstOrDefault(u => u.Id == medicalBillsViewModel.Id).Id,
                    Name = medicalBillsViewModel.Name,
                    MedicalBillsType = _medicalBillsTypeService.GetAll().FirstOrDefault(u => u.Type == medicalBillsViewModel.Type),
                    Form = _formService.GetAll().FirstOrDefault(u => u.FormName == medicalBillsViewModel.Form)
                };
                _medicalBillsService.Update(dTO);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}
