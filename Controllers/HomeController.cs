using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Universidad.Models;

namespace Universidad.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

		private readonly UniversidadContext _context;

		public HomeController(UniversidadContext context, ILogger<HomeController> logger)
		{
			_context = context;
			_logger = logger;
        }

        public IActionResult Index()
        {
			return RedirectToAction(actionName: "Dashboard");
		}
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Faculties()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult FAQ()
        {
            return View();
        }
        public IActionResult Teacher()
        {
            return View();  
        }
		public IActionResult Students()
		{
			return View();
		}
		public IActionResult Detail() 
        {
            return View();
        }
		public JsonResult GetProfesores()
		{
            var profesores = _context.Profesores.Count();

			return Json(profesores);
		}

		public JsonResult GetEstudiantes()
		{
			var estudiantes = _context.Estudiantes.Count();

			return Json(estudiantes);
		}

		public JsonResult GetAreas()
		{
			var areas = _context.Areas.Count();

			return Json(areas);
		}

		public JsonResult GetCarreras()
		{
			var carreras = _context.Personas.Count();

			return Json(carreras);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}