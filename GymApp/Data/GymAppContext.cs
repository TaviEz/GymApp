#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GymApp.Models;

namespace GymApp.Data
{
    public class GymAppContext : DbContext
    {
        public GymAppContext (DbContextOptions<GymAppContext> options)
            : base(options)
        {
        }

        public DbSet<GymApp.Models.Gym> Gym { get; set; }
    }
}
