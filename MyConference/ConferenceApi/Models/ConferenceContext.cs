using ConferenceApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApi.Models
{
    public class ConferenceContext : DbContext
    {
        public DbSet<Conference> Conference { get; set; }

        public ConferenceContext(DbContextOptions<ConferenceContext> options)
            : base(options)
        {
        }

    }
}
