using ConferenceApi.Domain;
using ConferenceApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConferenceApi.Migrations
{
    public class ApplicationDatabaseInitializer
    {
        public async Task SeedAsync(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var applicationDbContext = scope.ServiceProvider.GetRequiredService<ConferenceContext>();

                await applicationDbContext.Database.EnsureDeletedAsync();
                await applicationDbContext.Database.MigrateAsync();
                await applicationDbContext.Database.EnsureCreatedAsync();

                var items = new List<Conference>
            {
                new Conference { Id = Guid.NewGuid(), Category = Category.FRONTEND, Name = "NG-BE", Date = DateTime.UtcNow, Location = new Location() { }, Url = "https://www.ng-be.org"},
                new Conference { Id = Guid.NewGuid(), Category = Category.BACKEND, Name = "Techorama", Date = DateTime.UtcNow, Location = new Location() { }, Url = "https://www.techorama.be"}
            };

                await applicationDbContext.Conference.AddRangeAsync(items);

                await applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
