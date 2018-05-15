using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Repo
{
    public class ReviewRepo : ICrudable<Review>
    {
        public IEnumerable<Review> GetAllEntries()
        {
            using (MovieContext MovieDB = new MovieContext())
            {
                return MovieDB.Reviews.ToList();
            }
        }

        public Review GetByID(int ID)
        {
            using (MovieContext MovieDB = new MovieContext())
            {
                return MovieDB.Reviews.Where(r => r.ID == ID).FirstOrDefault();
            }
        }

        public int SaveOrUpdate(Review review)
        {
            using (MovieContext MovieDB = new MovieContext())
            {
                MovieDB.Entry(review).State = review.ID == 0 ? EntityState.Added : EntityState.Modified;
                return MovieDB.SaveChanges();
            }
        }

        public IEnumerable<Review> GetByMovieID(int ID)
        {
            using (MovieContext MovieDB = new MovieContext())
            {
                return MovieDB.Reviews.Where(r => r.MovieID == ID).ToList();
            }
                
        }
    }
}
