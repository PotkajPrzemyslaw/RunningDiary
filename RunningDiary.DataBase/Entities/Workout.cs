using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace RunningDiary.Database
{
    public class Workout : BaseEntity
    {
        public string Description { get; set; }
        [Required]
        public string TypeOfWorkout { get; set; }

        [NotMapped]
        public SelectList TypeOfWorkoutList { get; } = new SelectList(new List<string> {
            "Trening Wytrzymałościowy", "Trening Szybkościowy", "Trening Interwałowy", "Trening Progowy"
        });
        public DateTime DateOfWorkout { get; set; }

        [ForeignKey("Runner")]
        public int RunnerId { get; set; }

        public virtual Runner Runner { get; set; }

        [NotMapped]
        public virtual ICollection<Exercise> Excercises { get; set; }

    }
}
