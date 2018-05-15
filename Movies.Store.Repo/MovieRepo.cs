using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Repo
{
    public class MovieRepo : ICrudable<Movie>
    {

        public IEnumerable<Movie> GetAllEntries()
        {
            using (MovieContext MovieDB = new MovieContext())
            {
                return MovieDB.Movies.ToList();
            }
        }

        public Movie GetByID(int ID)
        {
            using (MovieContext MovieDB = new MovieContext())
            {
                return MovieDB.Movies.Where(m => m.ID == ID).FirstOrDefault();
            }
        }

        public int SaveOrUpdate(Movie movie)
        {
            using (MovieContext MovieDB = new MovieContext())
            {
                MovieDB.Entry(movie).State = movie.ID == 0? EntityState.Added : EntityState.Modified;
                return MovieDB.SaveChanges();
            }
        }
    }
}
