using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStore.Models.Domain;
using MovieStore.Repositories.Abstract;

namespace MovieStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MovieController : Controller
    {
        
        
            private readonly IMovieService movieService;
            private readonly IActorService actorService;
            private readonly IGenreService genreService;
            private readonly IDirectorService directorService;
            public MovieController(IMovieService movieService, IGenreService genreService, IDirectorService directorService, IActorService actorService)
            {
                this.movieService = movieService;
                this.genreService = genreService;
                this.directorService = directorService;
                this.actorService = actorService;
            }
            public IActionResult Add()
            {
                var model = new Movie();
                model.ActorList = actorService.GetAll().Select(a => new SelectListItem { Text = a.ActorName, Value = a.Id.ToString() }).ToList();
                model.DirectorList = directorService.GetAll().Select(a => new SelectListItem { Text = a.DirectorName, Value = a.Id.ToString() }).ToList();
                model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() }).ToList();
                return View(model);
            }

            [HttpPost]
            public IActionResult Add(Movie model)
            {
                
                model.ActorList = actorService.GetAll().Select(a => new SelectListItem { Text = a.ActorName, Value = a.Id.ToString(), Selected = a.Id == model.ActorId }).ToList();
                model.DirectorList = directorService.GetAll().Select(a => new SelectListItem { Text = a.DirectorName, Value = a.Id.ToString(), Selected = a.Id == model.DirectorId }).ToList();
                model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
                
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var result = movieService.Add(model);
                if (result)
                {
                    TempData["msg"] = "Added Successfully";
                    return RedirectToAction(nameof(Add));
                }
                TempData["msg"] = "Error has occured on server side";
                return View(model);
            }


            public IActionResult Update(int id)
            {
                var model = movieService.FindById(id);
                model.ActorList = actorService.GetAll().Select(a => new SelectListItem { Text = a.ActorName, Value = a.Id.ToString(), Selected = a.Id == model.ActorId }).ToList();
                model.DirectorList = directorService.GetAll().Select(a => new SelectListItem { Text = a.DirectorName, Value = a.Id.ToString(), Selected = a.Id == model.DirectorId }).ToList();
                model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
                return View(model);
            }

            [HttpPost]
            public IActionResult Update(Movie model)
            {
                model.ActorList = actorService.GetAll().Select(a => new SelectListItem { Text = a.ActorName, Value = a.Id.ToString(), Selected = a.Id == model.ActorId }).ToList();
                model.DirectorList = directorService.GetAll().Select(a => new SelectListItem { Text = a.DirectorName, Value = a.Id.ToString(), Selected = a.Id == model.DirectorId }).ToList();
                model.GenreList = genreService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var result = movieService.Update(model);
                if (result)
                {
                    return RedirectToAction("GetAll");
                }
                TempData["msg"] = "Error has occured on server side";
                return View(model);
            }


            public IActionResult Delete(int id)
            {

                var result = movieService.Delete(id);
                return RedirectToAction("GetAll");
            }

            public IActionResult GetAll()
            {

                var data = movieService.GetAll();
                return View(data);
            }
        }
    
}
