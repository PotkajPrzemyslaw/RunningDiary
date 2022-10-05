using System;

namespace RunningDiary
{
    public class ExerciseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Distance { get; set; }
        public WorkoutViewModel Workout { get; set; }
    }
}
