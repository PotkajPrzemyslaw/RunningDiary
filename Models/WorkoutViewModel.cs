using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RunningDiary
{
    public class WorkoutViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string TypeOfWorkout { get; set; }
        public SelectList TypeOfWorkoutList { get; set; } = new SelectList(new List<string> {
            "Endurance Training", "Speed Training", "Interval Training", "Threshold Training", "Strengthening Exercises"
        });
        public DateTime DateOfWorkout { get; set; } = DateTime.Now;
        public RunnerViewModel Runner { get; set; }
        public List<ExerciseViewModel> Exercises { get; set; }

    }
}
