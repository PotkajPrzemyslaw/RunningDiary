using System;

namespace RunningDiary.Core
{
    public class ExerciseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Distance { get; set; }
        public WorkoutDto Workout { get; set; }
    }
}
