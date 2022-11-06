using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationPractic2.Models;

namespace WebApplicationPractic2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController()
        {
           
        }

        public IActionResult Index()
        {
            // Готовим данные для представления
            ViewData["Title"] = "Вокально-инструментальные ансамбли";
            var bands = MemoryDb.Bands;
            // Передаем управление "Представлению"
            return View(bands);

        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View(MemoryDb.Bands.Where(b => b.Id == id).First());
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            Band band = new Band();
            return View(band);

        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Band band)
        {

            if (ModelState.IsValid)
            {
                MemoryDb.Bands.Add(band);
                return RedirectToAction("Index");
            }
            else
                return View();

        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            List<string> countries = new List<string>();
            foreach (var item in MemoryDb.Bands)
            {
                countries.Add(item.Country);
            }
            ViewBag.Countries = countries;
            return View(nameof(Edit), MemoryDb.Bands.Where(b => b.Id == id).First());
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Band band)
        {
            if (ModelState.IsValid)
            {
                band.Id = MemoryDb.Bands.Where(b => b.Id == id).First().Id;
                int index = MemoryDb.Bands.IndexOf(MemoryDb.Bands.Where(b => b.Id == id).First());
                MemoryDb.Bands[index] = band;
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            MemoryDb.Bands.Remove(MemoryDb.Bands.Where(b => b.Id == id).First());
            return RedirectToAction("Index");
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}