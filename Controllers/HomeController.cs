using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Numerics;
using Universidad.Models;

namespace Universidad.Controllers
{
	[Authorize]
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
            return View(_context.Carreras.ToList());
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
			var carreras = _context.Carreras.Count();

			return Json(carreras);
		}

		public JsonResult GetDeaneriesNames()
		{
			var carreras = _context.Areas;

			return Json(carreras);
		}

		public JsonResult GetTeachersByAreas()
		{
			var query = from area in _context.Areas
						join pa in _context.ProfesoresAreas on area.IdArea equals pa.IdArea
						join persona in _context.Personas on pa.IdProfesor equals persona.IdPersona
						group area by area.Nombre into g
						orderby g.Max(a => a.IdArea) descending
						select new
						{
							id = g.Max(a => a.IdArea),
							value = g.Count(),
							name = g.Key
						};

			return Json(query);
		}

		public JsonResult GetStudentByCareers()
        {
            var query = from carrera in _context.Carreras
                        join estudiante in _context.Estudiantes on carrera.IdCarrera equals estudiante.IdCarrera
                        group estudiante by carrera.Nombre into g
                        orderby g.Max(c => c.IdCarrera)
                        select new
                        {
                            id = g.Max(c => c.IdCarrera),
							value = g.Count(),
                            name = g.Key
                        };

            return Json(query);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}