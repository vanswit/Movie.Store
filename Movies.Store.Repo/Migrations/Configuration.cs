namespace MovieStore.Repo.Migrations
{
    using MovieStore.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieStore.Repo.MovieContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieStore.Repo.MovieContext context)
        {
            for (int i = 0; i < 50; i++)
            {
                var random = new Random();
                var movie = new Movie() {Name = "Movie" + i, Genre = "Genre" + random.Next(1,5), YearOfRelease = random.Next(1920,2018) };
                context.Movies.AddOrUpdate(movie);
            }

            for (int i = 0; i < 75; i++)
            {
                var random = new Random();
                var review = new Review() { Body = "blabla" + i, Rating = random.Next(1, context.Movies.Count()), MovieID = random.Next(1, 10) };
                context.Reviews.AddOrUpdate(review);
            }
        }
    }
}
