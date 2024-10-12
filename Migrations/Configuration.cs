namespace asp.net_vidly.Migrations
{
    using asp.net_vidly.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<asp.net_vidly.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "asp.net_vidly.Models.ApplicationDbContext";
        }

        protected override void Seed(asp.net_vidly.Models.ApplicationDbContext context)
        {
            // Seeding Membership Types
            context.MembershipTypes.AddOrUpdate(
                m => m.MembershipTypeId,
                new MembershipType { MembershipTypeId = 1, Type = "Free", SignUpFee = 0, DiscountPercentage = 0 },
                new MembershipType { MembershipTypeId = 2, Type = "Monthly", SignUpFee = 30, DiscountPercentage = 10 },
                new MembershipType { MembershipTypeId = 3, Type = "Quarterly", SignUpFee = 70, DiscountPercentage = 15 },
                new MembershipType { MembershipTypeId = 4, Type = "Annual", SignUpFee = 150, DiscountPercentage = 20 }
            );

            // Seeding 10 Customers
            context.Customers.AddOrUpdate(
            c => c.Email,
            new Customer
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "1234567890",
                IsSubscribedToNewsLetter = true,
                MembershipTypeId = 1, // Free Membership
                BirthDate = new DateTime(1985, 3, 12)
            },
            new Customer
            {
                Name = "Jane Smith",
                Email = "jane.smith@example.com",
                PhoneNumber = "0987654321",
                IsSubscribedToNewsLetter = false,
                MembershipTypeId = 2, // Monthly Membership
                BirthDate = new DateTime(1990, 7, 25)
            },
            new Customer
            {
                Name = "Bob Johnson",
                Email = "bob.johnson@example.com",
                PhoneNumber = "5555555555",
                IsSubscribedToNewsLetter = true,
                MembershipTypeId = 3 // Quarterly Membership
            },
            new Customer
            {
                Name = "Alice Brown",
                Email = "alice.brown@example.com",
                PhoneNumber = "4444444444",
                IsSubscribedToNewsLetter = false,
                MembershipTypeId = 4, // Annual Membership
                BirthDate = new DateTime(1988, 2, 18)
            },
            new Customer
            {
                Name = "Tom Harris",
                Email = "tom.harris@example.com",
                PhoneNumber = "3333333333",
                IsSubscribedToNewsLetter = true,
                MembershipTypeId = 1, // Free Membership
                BirthDate = new DateTime(1975, 9, 3)
            },
            new Customer
            {
                Name = "Nancy White",
                Email = "nancy.white@example.com",
                PhoneNumber = "2222222222",
                IsSubscribedToNewsLetter = false,
                MembershipTypeId = 2 // Monthly Membership
            },
            new Customer
            {
                Name = "Chris Green",
                Email = "chris.green@example.com",
                PhoneNumber = "1111111111",
                IsSubscribedToNewsLetter = true,
                MembershipTypeId = 3 // Quarterly Membership
            },
            new Customer
            {
                Name = "Sara Blue",
                Email = "sara.blue@example.com",
                PhoneNumber = "6666666666",
                IsSubscribedToNewsLetter = false,
                MembershipTypeId = 4, // Annual Membership
                BirthDate = new DateTime(1995, 6, 10)
            },
            new Customer
            {
                Name = "Mike Yellow",
                Email = "mike.yellow@example.com",
                PhoneNumber = "7777777777",
                IsSubscribedToNewsLetter = true,
                MembershipTypeId = 1 // Free Membership
            },
            new Customer
            {
                Name = "Laura Black",
                Email = "laura.black@example.com",
                PhoneNumber = "8888888888",
                IsSubscribedToNewsLetter = false,
                MembershipTypeId = 2 // Monthly Membership
            }
            );

            // Seeding Genres
            context.Genres.AddOrUpdate(
                g => g.Name,
                new Genre { Name = "Action" },
                new Genre { Name = "Comedy" },
                new Genre { Name = "Drama" },
                new Genre { Name = "Horror" },
                new Genre { Name = "Thriller" },
                new Genre { Name = "Sci-Fi" },
                new Genre { Name = "Fantasy" },
                new Genre { Name = "Adventure" },
                new Genre { Name = "Romance" },
                new Genre { Name = "Documentary" }
            );

            // Save genres to the database first
            context.SaveChanges();

            // Seeding 20 Movies
            context.Movies.AddOrUpdate(
                m => m.Title,
                new Movie { Title = "Inception", ReleaseDate = new DateTime(2010, 7, 16), Director = "Christopher Nolan", Rating = 8.8, GenreId = context.Genres.Single(g => g.Name == "Sci-Fi").GenreId },
                new Movie { Title = "The Dark Knight", ReleaseDate = new DateTime(2008, 7, 18), Director = "Christopher Nolan", Rating = 9.0, GenreId = context.Genres.Single(g => g.Name == "Action").GenreId },
                new Movie { Title = "The Hangover", ReleaseDate = new DateTime(2009, 6, 5), Director = "Todd Phillips", Rating = 7.7, GenreId = context.Genres.Single(g => g.Name == "Comedy").GenreId },
                new Movie { Title = "Titanic", ReleaseDate = new DateTime(1997, 12, 19), Director = "James Cameron", Rating = 7.8, GenreId = context.Genres.Single(g => g.Name == "Romance").GenreId },
                new Movie { Title = "The Shawshank Redemption", ReleaseDate = new DateTime(1994, 9, 22), Director = "Frank Darabont", Rating = 9.3, GenreId = context.Genres.Single(g => g.Name == "Drama").GenreId },
                new Movie { Title = "The Exorcist", ReleaseDate = new DateTime(1973, 12, 26), Director = "William Friedkin", Rating = 8.0, GenreId = context.Genres.Single(g => g.Name == "Horror").GenreId },
                new Movie { Title = "The Matrix", ReleaseDate = new DateTime(1999, 3, 31), Director = "The Wachowskis", Rating = 8.7, GenreId = context.Genres.Single(g => g.Name == "Sci-Fi").GenreId },
                new Movie { Title = "Avatar", ReleaseDate = new DateTime(2009, 12, 18), Director = "James Cameron", Rating = 7.8, GenreId = context.Genres.Single(g => g.Name == "Fantasy").GenreId },
                new Movie { Title = "Interstellar", ReleaseDate = new DateTime(2014, 11, 7), Director = "Christopher Nolan", Rating = 8.6, GenreId = context.Genres.Single(g => g.Name == "Sci-Fi").GenreId },
                new Movie { Title = "Gladiator", ReleaseDate = new DateTime(2000, 5, 5), Director = "Ridley Scott", Rating = 8.5, GenreId = context.Genres.Single(g => g.Name == "Action").GenreId },
                new Movie { Title = "Pulp Fiction", ReleaseDate = new DateTime(1994, 10, 14), Director = "Quentin Tarantino", Rating = 8.9, GenreId = context.Genres.Single(g => g.Name == "Thriller").GenreId },
                new Movie { Title = "Schindler's List", ReleaseDate = new DateTime(1993, 12, 15), Director = "Steven Spielberg", Rating = 8.9, GenreId = context.Genres.Single(g => g.Name == "Drama").GenreId },
                new Movie { Title = "Braveheart", ReleaseDate = new DateTime(1995, 5, 24), Director = "Mel Gibson", Rating = 8.3, GenreId = context.Genres.Single(g => g.Name == "Action").GenreId },
                new Movie { Title = "The Godfather", ReleaseDate = new DateTime(1972, 3, 24), Director = "Francis Ford Coppola", Rating = 9.2, GenreId = context.Genres.Single(g => g.Name == "Drama").GenreId },
                new Movie { Title = "The Silence of the Lambs", ReleaseDate = new DateTime(1991, 2, 14), Director = "Jonathan Demme", Rating = 8.6, GenreId = context.Genres.Single(g => g.Name == "Thriller").GenreId },
                new Movie { Title = "Jaws", ReleaseDate = new DateTime(1975, 6, 20), Director = "Steven Spielberg", Rating = 8.0, GenreId = context.Genres.Single(g => g.Name == "Thriller").GenreId },
                new Movie { Title = "Finding Nemo", ReleaseDate = new DateTime(2003, 5, 30), Director = "Andrew Stanton", Rating = 8.1, GenreId = context.Genres.Single(g => g.Name == "Adventure").GenreId },
                new Movie { Title = "Forrest Gump", ReleaseDate = new DateTime(1994, 7, 6), Director = "Robert Zemeckis", Rating = 8.8, GenreId = context.Genres.Single(g => g.Name == "Drama").GenreId },
                new Movie { Title = "The Social Network", ReleaseDate = new DateTime(2010, 10, 1), Director = "David Fincher", Rating = 7.7, GenreId = context.Genres.Single(g => g.Name == "Drama").GenreId },
                new Movie { Title = "Saving Private Ryan", ReleaseDate = new DateTime(1998, 7, 24), Director = "Steven Spielberg", Rating = 8.6, GenreId = context.Genres.Single(g => g.Name == "Action").GenreId }
            );
        }
    }
}
