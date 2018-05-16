using MovieStore.Entities;
using MovieStore.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieStore.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            var movies = new List<Movie>();
            using (var context = new MovieContext())
            {
                movies = context.Movies.ToList();
            }
            return View(movies);
        }
    }
}