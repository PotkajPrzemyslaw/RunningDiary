using System;
using System.Collections.Generic;

namespace RunningDiary.Core
{
    public class RunnerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<WorkoutDto> Workouts { get; set; }


    }
}
