﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using seeker.Models;
using seeker.Data;

namespace seeker.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
         DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Listar()
        {
            return View();
        }

        public IActionResult CCreate(Create objcreate)
        {
             if (ModelState.IsValid)
            {
                 
                 objcreate.Mensaje = "El Usuario a sido Registrado con Éxito"; 

                 _context.Add(objcreate);
                 _context.SaveChanges();

                 return View("Create",objcreate);   
            }
            return View("Create");
        }

        public IActionResult GetCreate()
        {
             var listCreate=_context.Creates.ToList();
             return View("Listar", listCreate);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
