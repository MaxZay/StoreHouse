using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP_UI.Models;
using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ASP_UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMedicalBillsService _medicalBillsService;
        private readonly List<MedicalBillsDTO> medicalBillsDTOs;

        //   private readonly ILogger<HomeController> _logger;

        public HomeController(IMedicalBillsService medicalBillsService)
        {
            _medicalBillsService = medicalBillsService;
            medicalBillsDTOs = _medicalBillsService.GetAll().ToList(); 
        }

        public ViewResult List()
        {
            var bills = _medicalBillsService.GetAll();
            return View(bills);
        }



        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
