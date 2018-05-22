using MovieStore.Entities;
using MovieStore.Models;
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

        public ActionResult Detail(int ID)
        {
            var model = new MovieDetailViewModel();
            using (var context = new MovieContext())
            {
                var movie = context.Movies.Where(m => m.ID == ID).Single();
                model.Movie = movie;
                model.Reviews = context.Reviews.Where(r => r.MovieID == movie.ID).ToList();
            }
            return View(model);
        }

        public ActionResult AddReview(int ID)
        {
            var movie = new Movie();
            using (var context = new MovieContext())
            {
                movie = context.Movies.Where(m => m.ID == ID).Single();
            }
            return View(movie);
        }

        [HttpPost]
        public ActionResult AddReview(Review review)
        {
            var repo = new ReviewRepo();
            repo.SaveOrUpdate(new Review() { Body = review.Body, Rating = review.Rating, MovieID = review.MovieID });
            return RedirectToAction("Details");
        }

        public ActionResult Edit(int ID)
        {
            var repo = new MovieRepo();
            var movie = repo.GetByID(ID);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            var repo = new MovieRepo();
            int id = repo.SaveOrUpdate(movie);
            return Redirect("~/Movie/Detail/" + id);
        }
    }
}