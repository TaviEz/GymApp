using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GymApp.Models
{
    public class TargetMuscleViewModel
    {
        public List<Gym>? Gyms { get; set; }
        public SelectList? Muscles { get; set; }
        public string? TargetMuscle { get; set; }
        public string? SearchString { get; set; }
    }
}
