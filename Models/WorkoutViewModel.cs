using System;
using System.Collections.Generic;

namespace RunningDiary
{
    public class WorkoutViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfWorkout { get; set; }
        public RunnerViewModel Runner { get; set; }
        public List<ExerciseViewModel> Exercises { get; set; }

    }
}
