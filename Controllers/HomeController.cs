using Microsoft.AspNetCore.Mvc;
using Final_Project_PVI.Models;
using System.Diagnostics;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Final_Project_PVI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Start()
        {
            ViewData["HideMenu"] = true;
            return View();
        }
        [HttpPost]
        public IActionResult GoToMain()
        {
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Main()
        {
            return View();
        }
        public IActionResult Productos()
        {
            string xmlRuta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Productos.xml");
            XDocument doc = XDocument.Load(xmlRuta);
            var productos = doc.Descendants("Producto")
                .Select(p => new Producto
                {
                    IdProducto = (int)p.Element("IdProducto"),
                    Nombre = (string)p.Element("Nombre")
                }).ToList();

            return View(productos);
        }
    }
}
