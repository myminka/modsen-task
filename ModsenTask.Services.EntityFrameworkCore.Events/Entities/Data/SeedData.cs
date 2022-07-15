using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModsenTask.Services.EntityFrameworkCore.Events.Context;
using System;
using System.Linq;

namespace ModsenTask.Services.EntityFrameworkCore.Events.Entities.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            EventDataContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<EventDataContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.EventDatas.Any())
            {
                context.EventDatas.AddRange(
                    new EventData
                    {
                        Name = "Graduation",
                        Description = "Easy breezy:)",
                        Organiser = "BNTU",
                        Address = new Address
                        {
                            Country = "Belarus",
                            City = "Minsk",
                            Street = "Independence Avenue",
                            HouseNumber = 67,
                        },
                        Date = new DateTime(2024, 06, 24),
                    },
                    new EventData
                    {
                        Name = "English class",
                        Description = "English class in Undeground.",
                        Organiser = "Boguslaw Sipailo",
                        Address = new Address
                        {
                            Country = "Belarus",
                            City = "Minsk",
                            Street = "Niamiha Street",
                            HouseNumber = 30,
                        },
                        Date = new DateTime(2022, 07, 18, 19, 30, 0, 0),
                    });
                context.SaveChanges();
            }
        }
    }
}
