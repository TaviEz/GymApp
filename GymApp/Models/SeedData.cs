using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GymApp.Data;
using System;
using System.Linq;

namespace GymApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GymAppContext(serviceProvider.GetRequiredService<DbContextOptions<GymAppContext>>()))
            {
                    if (context.Gym.Any())
                    {
                    return;   // DB has been seeded
                    }

                context.Gym.AddRange(
                    new Gym
                    {
                        Excercise = "Overhead Press DB",
                        FocusOn = "Deltoids",
                        Sets = 4,
                        Reps = 10,
                        Weight = 22.5
                    },

                    new Gym
                    {
                        Excercise = "Skullcrusher",
                        FocusOn = "Triceps",
                        Sets = 3,
                        Reps = 10,
                        Weight = 30
                    },

                    new Gym
                    {
                        Excercise = "Cable crossovers low to high",
                        FocusOn = "Upper Chest",
                        Sets = 3,
                        Reps = 11,
                        Weight = 10
                    },

                    new Gym
                    {
                        Excercise = "Pec Deck",
                        FocusOn = "Major Pec",
                        Sets = 3,
                        Reps = 10,
                        Weight = 65
                    }
                );
                context.SaveChanges();

                if (context.Gym.Any())
                {
                    return;  // DB has been seeded.
                }
            }


        }
    }
}
