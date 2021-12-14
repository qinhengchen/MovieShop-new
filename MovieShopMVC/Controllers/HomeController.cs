using ApplicationCore.ServiceInterfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;
using System.Diagnostics;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //private MovieService _movieService;
        //public HomeController()
        //{
        //    _movieService = new MovieService();
        //}
        private IMovieService _movieService;
        private IGenreService _genreService;
        public HomeController(IMovieService movieService, IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var movieCards = _movieService.GetHighestGrossingMovies();
            return View(movieCards);
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            var genres = _genreService.GetAllGenres();
            return View(genres);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}