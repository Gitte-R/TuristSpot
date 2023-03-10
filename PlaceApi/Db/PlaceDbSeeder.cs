using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlaceApi.Db;
using PlaceApi.Db.Models;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace PlaceApi.db
{
    public class PlaceDbSeeder
    {
        private static string GetImage(string fileName, string fileType)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Db/Images", fileName);
            var imageBytes = File.ReadAllBytes(path);
            return $"data: {fileType}; base64,{Convert.ToBase64String(imageBytes)}";
        }
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var context = new PlaceDbContext(serviceProvider.
            GetRequiredService<DbContextOptions<PlaceDbContext>>());
            if (context.Places.Any()) { return; }
            context.Places.AddRange(
                new Place
                {
                    Id = 1,
                    Name = "Coron Island",
                    Location = "Palawan, Philippines",
                    About = "Coron is one of the top destinations for tourists to add to their wish list.",
                    Reviews = 10,
                    ImageData = GetImage("coron_island.jpg", "image/jpeg"),
                    LastUpdated = DateTime.Now
                },

                new Place
                {
                    Id = 2,
                    Name = "Olsob Cebu",
                    Location = "Cebu, Philippines",
                    About = "Whale shark watching is the most popular tourist attraction in Cebu.",
                    Reviews = 3,
                    ImageData = GetImage("oslob_whalesharks.jpg", "image/jpg"),
                    LastUpdated = DateTime.Now
                }
            );
            context.SaveChanges();
        }
    }
}

        
