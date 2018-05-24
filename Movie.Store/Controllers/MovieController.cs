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
        public ActionResult Autocomplete(string term)
        {
            var repo = new MovieRepo();
            var model = repo.GetAllEntries().Where(m => m.Name.StartsWith(term))
                .Take(10)
                .Select(m => new
                {
                    label = m.Name
                });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Index(string searchTerm = null)
        {
            var repo = new MovieRepo();
            var movies = repo.GetAllEntries().Where(m => searchTerm == null || m.Name.ToLower()
            .Contains(searchTerm.ToLower())).ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("_MovieList", movies);
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