using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieStore.Models;
using MovieStore.Models.Domain;
using MovieStore.Repositories.Abstract;
using MovieStore.Repositories.Implementation;
using System.Diagnostics;

namespace MovieStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;
        private readonly IMovieService _movieService;

        public HomeController(ILogger<HomeController> logger, DatabaseContext context, IMovieService movieService)
        {
            _logger = logger;
            _context = context;
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            var movies = _movieService.GetAll();
            return View(movies);
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            
            var movie = _movieService.FindById(id);

            if (movie == null)
            {
                
                return NotFound();
            }

            
            return View(movie);
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