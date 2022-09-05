namespace BetaMovieStore.Migrations
{
    using BetaMovieStore.Models.Database;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BetaMovieStore.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BetaMovieStore.Data.AppDbContext context)
        {

            context.Customers.AddOrUpdate(
                c=>c.EmailAddress,
                new Customer {FirstName="Umara",LastName="Haroon",BillingAdress="40B Prastbolsgatan Linkoping",BillingZip="58733",BillingCity="Linkoping",DeliveryAdress="Linkoping",DeliveryZip="58733",DeliveryCity="Linkoping",EmailAddress="u@gmail.com",Phone="079 45367590" },
                new Customer { FirstName = "Hiba", LastName = "Siddig", BillingAdress = "25 hb Hoshtaubvagen", BillingZip = "56789", BillingCity = "Finspoang", DeliveryAdress = "25 HB Hoshtaubvagen", DeliveryZip = "56789", DeliveryCity = "Finspoang", EmailAddress = "hiba@gmail.com", Phone = "076 34527809" },
                new Customer { FirstName = "Mengsha", LastName = "Zhao", BillingAdress = "Rydsvagen 90C", BillingZip = "58431", BillingCity = "Linkoping", DeliveryAdress = "Rydsvagen 90C", DeliveryZip = "58431", DeliveryCity = "Linkoping", EmailAddress = "mengsha@gmail.com", Phone = "07088888" },
                new Customer { FirstName = "Zain", LastName = " ul Abedeen", BillingAdress = "40B Prastbolsgatan Linkoping", BillingZip = "58733", BillingCity = "Linkoping", DeliveryAdress = "40B Prastbolsgatan", DeliveryZip = "58733", DeliveryCity = "Linkoping", EmailAddress = "zain@gmail.com", Phone = "07234534509" },                
                new Customer { FirstName = "Bo", LastName = "Sun", BillingAdress = "Rydsvagen", BillingZip = "58431", BillingCity = "Linkoping", DeliveryAdress = "Rydsvagen", DeliveryZip = "58431", DeliveryCity = "Linkoping", EmailAddress = "sunboy@gmail.com", Phone = "0704143789" },
                new Customer { FirstName = "Nadia", LastName = "Bilal", BillingAdress = "34C Mintgatan", BillingZip = "54323", BillingCity = "Jonkoping", DeliveryAdress = "34C Mintgatan", DeliveryZip = "54323", DeliveryCity = "Jonkoping", EmailAddress = "nadia@gmail.com", Phone = "072 6784563" }

                );

            context.Movies.AddOrUpdate(
               m => m.Title,
               new Movie { Title = "Tenent", Director = "Christopher Nolan", ReleaseYear = 2020, Genre = "Sci-Fi", Price = 299, Image = "https://m.media-amazon.com/images/M/MV5BNDhiODUyN2UtYTQzZi00YTE0LWJiMWEtYTVlODEyZDQwYzRhXkEyXkFqcGdeQXVyMTA3MDk2NDg2._V1_.jpg" },
               new Movie { Title = "The Secret Life of Walter Mitty", Director = "Ben Steiller", ReleaseYear = 2014, Genre = "Comedy", Price = 299, Image = "https://m.media-amazon.com/images/M/MV5BODYwNDYxNDk1Nl5BMl5BanBnXkFtZTgwOTAwMTk2MDE@._V1_.jpg" },
               new Movie { Title = "Bullet Train", Director = " David Leitch", ReleaseYear = 2022, Genre = "Action", Price = 499, Image = "https://www.nfbio.se/sites/nfbio.se/files/styles/movie_poster/public/media-images/2022-06/bullettrain_affisch.jpg?itok=3ufYZGoR" },
               new Movie { Title = "Thor: Love and Thunder", Director = "Taika Waititi", ReleaseYear = 2022, Genre = "Comedy", Price = 499, Image = "https://www.nfbio.se/sites/nfbio.se/files/media-images/2022-07/TLAT_Payoff_Poster_SE.jpg" },

               new Movie { Title = "Top Gun: Maverick", Director = "Joseph Kosinski", ReleaseYear = 2022, Genre = "Action", Price = 499, Image = "https://m.media-amazon.com/images/M/MV5BOWQwOTA1ZDQtNzk3Yi00ZmVmLWFiZGYtNjdjNThiYjJhNzRjXkEyXkFqcGdeQXVyODE5NzE3OTE@._V1_FMjpg_UX1000_.jpg" },
               new Movie { Title = "Minioner: Berättelsen om Gru", Director = " Kyle Balda; Brad Ableson; Jonathan del Val", ReleaseYear = 2022, Genre = "Animation", Price = 399, Image = "https://m.media-amazon.com/images/M/MV5BZDQyODUwM2MtNzA0YS00ZjdmLTgzMjItZWRjN2YyYWE5ZTNjXkEyXkFqcGdeQXVyMTI2MzY1MjM1._V1_FMjpg_UX1000_.jpg" },
               new Movie { Title = "Severance", Director = "Dan Erickson", ReleaseYear = 2022, Genre = "Sci-Fi", Price = 399, Image = "https://d2iltjk184xms5.cloudfront.net/uploads/photo/file/432912/1c7b4a3ced16fb8405e54481f39d374b-severance.jpg" }


               //new Movie { Title = "", Director = "", ReleaseYear = , Genre = "", Price = , Image = "" }
                );
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
