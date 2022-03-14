using System;
using System.ComponentModel.DataAnnotations;

namespace GymApp.Models
{
    public class Gym
    {
        public int Id { get; set; }
        
        [StringLength(60, MinimumLength = 6)]
        [Required]
        public string? Excercise { get; set; }

        /*For displaying a date:*/
        /*[DataType(DataType.Date)]*/

        [Display(Name = "Focus On")]
        public string? FocusOn { get; set; }
        
        public int Sets { get; set; }

        public int Reps { get; set; }

        public double Weight { get; set; }

    }
}
