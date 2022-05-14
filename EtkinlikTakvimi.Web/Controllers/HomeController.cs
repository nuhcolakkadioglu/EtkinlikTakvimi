using EtkinlikTakvimi.Web.Context;
using EtkinlikTakvimi.Web.Entities;
using EtkinlikTakvimi.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EtkinlikTakvimi.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EtkinlikTakvimiContext _context;
        public HomeController(ILogger<HomeController> logger, EtkinlikTakvimiContext context)
        {
            _logger = logger;
            _context = context;
            _context.Database.Migrate();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EtkinlikGetir()
        {
            var etkinlik = _context.Events.ToList();

            return new JsonResult(etkinlik);
        }

        [HttpPost]
        public IActionResult SaveEvent(Event e)
        {
          
            if (e.Id > 0)
            {
                //update
            }
            else
            {
                _context.Events.Add(e);
            }
            _context.SaveChanges();

            return new JsonResult(e);
        }

        [HttpPost]
        public IActionResult DeleteEvent(int id)
        {
            var data = _context.Events.FirstOrDefault(m=>m.Id.Equals(id));
            _context.Events.Remove(data);
            _context.SaveChanges();
            return new JsonResult(data);
        }
        public IActionResult Rezarvasyon()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Rezarvasyon(Event e)
        {
            _context.Events.Add(e);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}