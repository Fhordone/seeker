using System;
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
    public class CreateController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<HomeController> _logger;

        public CreateController(ILogger<HomeController> logger,
         DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Create()
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

        public IActionResult Search(string search)
        {
          var ListarLibro = from l in _context.Creates select l;
          if(!String.IsNullOrEmpty(search)){
            ListarLibro = ListarLibro
                          .Where(l => l.last_name.Contains(search))
                          .OrderBy(l => l.last_name);
          }
          return View("Listar",ListarLibro);
        }

        public IActionResult GetCreate()
        {
             var listCreate= _context.Creates.OrderBy(s => s.ID).ToList();
            return View("Listar",listCreate);
        }

        public IActionResult Edit(int? id)
        {
             if(id == null){
                 return NotFound();
             }
             var create = _context.Creates.Find(id);
             if(create == null){
                 return NotFound();
             }
              return View(create);
        }

        [HttpPost]
         public IActionResult Edit(int id, Create create)
        {
             if(ModelState.IsValid){
                 _context.Update(create);
                 _context.SaveChanges();
                 create.Mensaje = "El Usuario a sido modificado con Éxito";
             }
              return View(create);
        }

        public IActionResult Delete(int? id)
        {
             var create = _context.Creates.Find(id);
             _context.Creates.Remove(create);
             _context.SaveChanges();
             return RedirectToAction(nameof(GetCreate));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
