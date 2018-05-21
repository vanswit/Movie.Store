namespace MovieStore.Repo.Migrations
{
    using MovieStore.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieStore.Repo.MovieContext>
    {
        Random random = new Random();
        enum Grades
        {
            Outstanding, Good, Ok, Bad, Terrible
        }

        public Configuration()
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MovieStore.Repo.MovieContext context)
        {
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE Movies");
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE Reviews");

            context.Movies.AddRange(GenerateMovies(50));
            context.Reviews.AddRange(GenerateReviews(150,50));
            context.SaveChanges();
        }

        private IEnumerable<Movie> GenerateMovies(int numberOfMovies)
        {
            List<Movie> movies = new List<Movie>();
            List<string> movieNames = new List<string>();
            var name = "";
            for (int i = 0; i < numberOfMovies; i++)
            {
                do
                {
                    name = GenerateMovieName();
                } while (name == "" || movieNames.Contains(name));
                movieNames.Add(name);
                
                Movie movie = new Movie() { Name = name, YearOfRelease = random.Next(1950, 2019), Genre = GenerateGenre() };
                movies.Add(movie);
            }

            return movies;
        }

        private string GenerateGenre()
        {
            string[] genres = new string[] { "Action", "Comedy", "Drama", "Thriller", "Fantasy", "Horror", "Adventure" };
            return genres[random.Next(0, genres.Count())];
        }

        private IEnumerable<Review> GenerateReviews(int numberOfReviews, int numberOfMovies)
        {
            const string bodyConst = "The movie was ";
            List<Review> reviews = new List<Review>();
            for (int i = 0; i < numberOfReviews; i++)
            {
                var grades = Enum.GetValues(typeof(Grades)).Cast<Grades>().ToList();
                Grades grade = grades[random.Next(0, 5)];
                int rating = ReturnRating(grade);
                Review review = new Review() { Body = bodyConst + grade.ToString(), MovieID = random.Next(1,numberOfMovies+1), Rating = rating };
                reviews.Add(review);
            }
            return reviews;
        }

        private string GenerateMovieName()
        {
            string[] articles = new string[] { "The ", "A ", "" };
            string[] adjectives = new string[] {"Long ","Deadly ","White ", "Black ", "Doubtfull ",
            "Grand ", "Suspicious ","Strong ","New ","Old ","Good ","Bad ","Angry ","Eternal ", "" };
            string[] nouns = new string[] {"Girl", "Boy", "Man", "Wife", "Deal", "Death",
                "War", "Kiss", "Night", "Day", "Message", "Bargain", "Event", "House", "Animal" };

            string article = articles[random.Next(0, 3)];
            string adjective = adjectives[random.Next(0, adjectives.Count())];
            string noun = nouns[random.Next(0, nouns.Count())];
            string name = article + adjective + noun;
            return name;
        }

        private int ReturnRating(Grades grade)
        {
            int rating = 0;

            switch (grade)
            {
                case Grades.Bad:
                    rating = random.Next(3, 5);
                    break;
                case Grades.Terrible:
                    rating = random.Next(1, 3);
                    break;
                case Grades.Ok:
                    rating = random.Next(5, 7);
                    break;
                case Grades.Good:
                    rating = random.Next(7, 9);
                    break;
                case Grades.Outstanding:
                    rating = random.Next(9, 11);
                    break;
                default:
                    break;
            }

            return rating;
        }
}
}
