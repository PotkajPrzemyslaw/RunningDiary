using System;
using System.Collections.Generic;

namespace RunningDiary.Core
{
    public class WorkoutDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string TypeOfWorkout { get; set; }
        public DateTime DateOfWorkout { get; set; }
        public RunnerDto Runner { get; set; }
        public List<ExerciseDto> Exercises { get; set; }
    }
}
