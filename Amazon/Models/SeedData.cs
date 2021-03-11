using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            AmazonDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<AmazonDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
               context.Database.Migrate();
            }

            if (!context.Books.Any())
            {
                context.Books.AddRange(

                    new Book
                    {
                        Title = "Les Miserables",
                        Author = "Victor Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        ClassificationCategory = "Fiction, Classic",
                        Price = 9.95,
                        PageLength = 1488
                    },

                    new Book
                    {
                        Title = "Team of Rivals",
                        Author = "Doris Kearns Goodwin",
                        Publisher = "Simon and Schuster",
                        ISBN = "978-0743270755",
                        ClassificationCategory = "Non-Fiction, Biography",
                        Price = 14.58,
                        PageLength = 944
                    },

                    new Book
                    {
                        Title = "The Snowball",
                        Author = "Alice Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        ClassificationCategory = "Non-Fiction, Biography",
                        Price = 21.54,
                        PageLength = 832
                    },

                    new Book
                    {
                        Title = "American Ulysses",
                        Author = "Ronald C. White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        ClassificationCategory = "Non-Fiction, Biography",
                        Price = 11.61,
                        PageLength = 864
                    },

                    new Book
                    {
                        Title = "Unbroken",
                        Author = "Laura Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        ClassificationCategory = "Non-Fiction, Historical",
                        Price = 13.33,
                        PageLength = 528
                    },

                    new Book
                    {
                        Title = "The Great Train Robbery",
                        Author = "Michael Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        ClassificationCategory = "Fiction, Historical Fiction",
                        Price = 15.95,
                        PageLength = 288
                    },

                    new Book
                    {
                        Title = "Deep Work",
                        Author = "Cal Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        ClassificationCategory = "Non-Fiction, Self-Help",
                        Price = 14.99,
                        PageLength = 304
                    },

                    new Book
                    {
                        Title = "It's Your Ship",
                        Author = "Michael Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        ClassificationCategory = "Non-Fiction, Self-Help",
                        Price = 21.66,
                        PageLength = 240
                    },

                    new Book
                    {
                        Title = "It's Your Ship",
                        Author = "Michael Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        ClassificationCategory = "Non-Fiction, Self-Help",
                        Price = 21.66,
                        PageLength = 304
                    },

                    new Book
                    {
                        Title = "The Virgin Way",
                        Author = "Richard Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        ClassificationCategory = "Non-Fiction, Business",
                        Price = 29.16,
                        PageLength = 400
                    },

                    new Book
                    {
                        Title = "Heart of Darkness",
                        Author = "Joseph Conrad",
                        Publisher = "BookRix",
                        ISBN = "978-3736800830",
                        ClassificationCategory = "Fiction, Novella",
                        Price = 12.01,
                        PageLength = 154
                    },

                    new Book
                    {
                        Title = "Sycamore Row",
                        Author = "John Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        ClassificationCategory = "Fiction, Thrillers",
                        Price = 15.03,
                        PageLength = 642
                    },

                    new Book
                    {
                        Title = "The Poisonwood Bible",
                        Author = "Barbara Kingsolver",
                        Publisher = "Harper Perennial Modern Classics",
                        ISBN = "978-0061577079",
                        ClassificationCategory = "Fiction, Literary",
                        Price = 15.59,
                        PageLength = 576
                    },

                    new Book
                    {
                        Title = "The Kite Runner",
                        Author = "Khaled Hosseini",
                        Publisher = "Riverhead Books",
                        ISBN = "978-1594631931",
                        ClassificationCategory = "Fiction, Cultural Heritage",
                        Price = 12.57,
                        PageLength = 400
                    });

                context.SaveChanges();
            }
        }
    }
}
